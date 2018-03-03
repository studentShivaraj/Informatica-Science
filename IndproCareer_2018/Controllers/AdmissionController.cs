using IndproCareer.Entity.Models;
using IndproCareer.Repository.DbContext;
using IndproCareer.Repository.IRepository;
using IndproCareer.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndproCareer_2018.Controllers
{
    public class AdmissionController : Controller
    {
        private IAdmissionRepository _admissionRepository;

        public AdmissionController()
        {
            this._admissionRepository = new AdmissionRepository(new ApplicationDbContext());
        }

        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(_admissionRepository.GetAllAdmission());
        }

        public ActionResult Create()
        {
            ViewBag.Nationality = new SelectList(db.Countrys, "Id", "CountyName");
            //Admission mode = new Admission();
            //int temp = (((mode.SecuredMark) * 100) / ((mode.TotalMarks)));
            //mode.Percentage = temp;
            return View();
        }


        [HttpPost]
        public ActionResult Create(Admission model)
        {
            try
            {              
                _admissionRepository.Insert(model);
                _admissionRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        // Json Call to get state
        public JsonResult GetStates1(int id)
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

        public JsonResult GetCitys1(int id)
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



    }
}
