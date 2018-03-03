using IndproCareer.Entity.Models;
using IndproCareer.Repository.DbContext;
using IndproCareer.Repository.IRepository;
using IndproCareer.Repository.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IndproCareer_2018.Controllers
{
    public class RegisterController : Controller
    {
        private IRegisterRepository _registerRepository;
        public RegisterController()
        {
            this._registerRepository = new RegisterRepository(new ApplicationDbContext());            
        }


        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(_registerRepository.GetAllUser());
        }

        public ActionResult Create()
        {            
            ViewBag.Country = new SelectList(db.Countrys, "Id", "CountyName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Register register)
        {
            try
            {
                _registerRepository.Insert(register);
                _registerRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // Json Call to get state
        public JsonResult GetStates(int id)
        {
            // List<SelectListItem> states = new List<SelectListItem>();
            var stateList = this.GetState(Convert.ToInt32(id));
            var stateData = stateList.Select(m => new SelectListItem()
            {
                Text = m.StateName,
                Value = m.Id.ToString(),
            });
            return Json(stateData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCitys(int id)
        {
            var citiList = this.GetCity(Convert.ToInt32(id));
            var stateData = citiList.Select(m => new SelectListItem()
            {
                Text = m.CitiName,
                Value = m.Id.ToString(),
            });
            return Json(stateData, JsonRequestBehavior.AllowGet);
        }

        // Get State from DB by country ID
        public IList<State> GetState(int CountryId)
        {           
            return db.States.Where(m => m.Countrys.Id == CountryId).ToList();
        }

        public IList<Citi> GetCity(int Id)
        {
            return db.Citis.Where(m => m.States.Id == Id).ToList();
        }




        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "SchoolAdmin")]
        public ActionResult Login(Login objUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        var user = db.Registers.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                        if (user != null)
                        {
                            Session["UserName"] = user.UserName.ToString();
                            return RedirectToAction("UserDashBoard");
                        }
                        else
                        {
                            ViewBag.Message = "invalid Username and Passwords";
                        }
                    }

                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }

            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }



        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        //public ActionResult ForgotPassword()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        //{
           
        //    if (ModelState.IsValid)
        //    {
        //        var user = _registerRepository.FindByNameAsync(model.Email);
        //        if (user == null )
        //        {
        //            ModelState.AddModelError("", "Invalid E-mail Id for Playhome");
        //        }
        //        string code = _registerRepository.GeneratePasswordResetTokenAsync(user.Id);
        //        var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        //        // await _userService.ResetPasswordAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
        //        EmailHelper.SendEmail(model.Email, "Reset Password", "You can reset your password by clicking on below link: <br /><br /> Click  <a href=" + callbackUrl + ">here</a>");
        //        return RedirectToAction("ForgotPasswordConfirmation", "Account");
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

    }
}
