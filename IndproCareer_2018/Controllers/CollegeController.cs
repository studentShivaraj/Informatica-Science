using IndproCareer.Entity.Models;
using IndproCareer.Repository.DbContext;
using IndproCareer.Repository.IRepository;
using IndproCareer.Repository.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndproCareer_2018.Controllers
{

    public class CollegeController : Controller
    {       
        private ICollegeRepository _collegeRepository;
        private IUniversityRepository _universityRepository;
        public CollegeController()
        {
            this._collegeRepository = new CollegeRepository(new ApplicationDbContext());
            this._universityRepository = new UniversityRepository(new ApplicationDbContext());
        }

        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 3;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "Name" : sortOrder;

            IPagedList<College> college = null;

            ApplicationDbContext db = new ApplicationDbContext();
            switch (sortOrder)
            {
                case "Name":
                    if (sortOrder.Equals(CurrentSort))
                        college = db.Colleges.OrderByDescending(m => m.Name).ToPagedList(pageIndex, pageSize);
                    else
                        college = db.Colleges.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize);
                    break;

                case "Id":
                    if (sortOrder.Equals(CurrentSort))
                        college = db.Colleges.OrderByDescending(m => m.Id).ToPagedList(pageIndex, pageSize);
                    else
                        college = db.Colleges.OrderBy(m => m.Id).ToPagedList(pageIndex, pageSize);
                    break;

                case "YOE":
                    if (sortOrder.Equals(CurrentSort))
                        college = db.Colleges.OrderByDescending(m => m.YOE).ToPagedList(pageIndex, pageSize);
                    else
                        college = db.Colleges.OrderBy(m => m.YOE).ToPagedList(pageIndex, pageSize);
                    break;

                case "Email":
                    if (sortOrder.Equals(CurrentSort))
                        college = db.Colleges.OrderByDescending(m => m.Email).ToPagedList(pageIndex, pageSize);
                    else
                        college = db.Colleges.OrderBy(m => m.Email).ToPagedList(pageIndex, pageSize);
                    break;

                case "Contact":
                    if (sortOrder.Equals(CurrentSort))
                        college = db.Colleges.OrderByDescending(m => m.Contact).ToPagedList(pageIndex, pageSize);
                    else
                        college = db.Colleges.OrderBy(m => m.Contact).ToPagedList(pageIndex, pageSize);
                    break;

                case "Pincode":
                    if (sortOrder.Equals(CurrentSort))
                        college = db.Colleges.OrderByDescending(m => m.Pincode).ToPagedList(pageIndex, pageSize);
                    else
                        college = db.Colleges.OrderBy(m => m.Pincode).ToPagedList(pageIndex, pageSize);
                    break;
                case "Default":
                    college = db.Colleges.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize);
                    break;

            }
            return View(college);
        }

        [HttpPost]
        public ActionResult Index(string Name, int? page)
        {
            int pageSize = 3;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            ApplicationDbContext db = new ApplicationDbContext();
            var filter = from college in db.Colleges select college;
            if (!string.IsNullOrEmpty(Name))
            {
                filter = filter.Where(a => a.Name.Contains(Name));
            }
            return View(filter.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize));
        }


        // GET: College/Create
        public ActionResult Create()
        {
            var get = _universityRepository.GetAll();
            SelectList lstUniversity = new SelectList(get, "id", "Name");
            ViewBag.University = lstUniversity;
            return View();
        }

        [HttpPost]
        public ActionResult Create(College college)
        {
            var get = _universityRepository.GetAll();
            SelectList lstUniversity = new SelectList(get, "id", "Name");
            ViewBag.University = lstUniversity;
            _collegeRepository.Insert(college);
            _collegeRepository.Save();
            return RedirectToAction("Index");            
        }
             
        public ActionResult Edit(int id)
        {
            var get = _universityRepository.GetAll();
            SelectList lstUniversity = new SelectList(get, "id", "Name");
            ViewBag.University = lstUniversity;
            var getId = _collegeRepository.GetId(id);
            return View(getId);
        }

        [HttpPost]
        public ActionResult Edit(College college)
        {
            try
            {
                var get = _universityRepository.GetAll();
                SelectList lstUniversity = new SelectList(get, "id", "Name");
                ViewBag.University = lstUniversity;
                _collegeRepository.Update(college);
                _collegeRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: University/Details/5
        public ActionResult Details(int id)
        {
            var getId = _collegeRepository.GetId(id);
            return View(getId);
        }
             
        public ActionResult Delete(int id)
        {           
            College college = _collegeRepository.GetId(id);
            if (college == null)
            {
                return HttpNotFound();
            }
            return View(college);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConform(int id)
        {
            try
            {
                College college = _collegeRepository.GetId(id);
                _collegeRepository.Delete(id);
                _collegeRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ExportData()
        {
            var gridView = new GridView();
            gridView.DataSource = _collegeRepository.GetAll();
            gridView.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            var fileName = "Indpro" + DateTime.Now.ToString("yyyyMMddTHHmm") + ".xls";
            //Response.AddHeader("content-disposition", "attachment; filename=MyCalendar.xls");
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
            Response.ContentType = "application/document";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gridView.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");
        }
        
    }
}
