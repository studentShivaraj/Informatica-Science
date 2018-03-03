using IndproCareer.Entity.Models;
using IndproCareer.Repository.DbContext;
using IndproCareer.Repository.IRepository;
using IndproCareer.Repository.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndproCareer_2018.Controllers
{
    public class SchoolController : Controller
    {
        private ICollegeRepository _collegeRepository;
        private ISchoolRepository _schoolRepository;
        public SchoolController()
        {
            this._collegeRepository = new CollegeRepository(new ApplicationDbContext());
            this._schoolRepository = new SchoolRepository(new ApplicationDbContext());
        }
        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 3;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "Name" : sortOrder;

            IPagedList<School> schools = null;

            ApplicationDbContext db = new ApplicationDbContext();
            switch (sortOrder)
            {
                case "Name":
                    if (sortOrder.Equals(CurrentSort))
                        schools = db.Schools.OrderByDescending(m => m.Name).ToPagedList(pageIndex, pageSize);
                    else
                        schools = db.Schools.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize);
                    break;

                case "Id":
                    if (sortOrder.Equals(CurrentSort))
                        schools = db.Schools.OrderByDescending(m => m.CId).ToPagedList(pageIndex, pageSize);
                    else
                        schools = db.Schools.OrderBy(m => m.CId).ToPagedList(pageIndex, pageSize);
                    break;

                case "YOE":
                    if (sortOrder.Equals(CurrentSort))
                        schools = db.Schools.OrderByDescending(m => m.YOE).ToPagedList(pageIndex, pageSize);
                    else
                        schools = db.Schools.OrderBy(m => m.YOE).ToPagedList(pageIndex, pageSize);
                    break;

                case "Email":
                    if (sortOrder.Equals(CurrentSort))
                        schools = db.Schools.OrderByDescending(m => m.Email).ToPagedList(pageIndex, pageSize);
                    else
                        schools = db.Schools.OrderBy(m => m.Email).ToPagedList(pageIndex, pageSize);
                    break;

                case "Contact":
                    if (sortOrder.Equals(CurrentSort))
                        schools = db.Schools.OrderByDescending(m => m.Contact).ToPagedList(pageIndex, pageSize);
                    else
                        schools = db.Schools.OrderBy(m => m.Contact).ToPagedList(pageIndex, pageSize);
                    break;

                case "Pincode":
                    if (sortOrder.Equals(CurrentSort))
                        schools = db.Schools.OrderByDescending(m => m.Pincode).ToPagedList(pageIndex, pageSize);
                    else
                        schools = db.Schools.OrderBy(m => m.Pincode).ToPagedList(pageIndex, pageSize);
                    break;
                case "Default":
                    schools = db.Schools.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize);
                    break;
            }
            return View(schools);
        }


        [HttpPost]
        public ActionResult Index(string Name, int? page)
        {
            int pageSize = 3;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            ApplicationDbContext db = new ApplicationDbContext();
            var filter = from school in db.Schools select school;
            if (!string.IsNullOrEmpty(Name))
            {
                filter = filter.Where(a => a.Name.Contains(Name));
            }
            return View(filter.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize));
        }


        // GET: School/Details/5
        public ActionResult Details(int id)
        {
            return View(_schoolRepository.GetId(id));
        }

        // GET: School/Create
        public ActionResult Create()
        {
            var getCollege = _collegeRepository.GetAll();
            SelectList lstCollege = new SelectList(getCollege, "CId", "Name");
            ViewBag.Colleges = lstCollege;
            return View();
        }

        [HttpPost]
        public ActionResult Create(School school)
        {
            try
            {
                var getCollege = _collegeRepository.GetAll();
                SelectList lstCollege = new SelectList(getCollege, "CId", "Name");
                ViewBag.Colleges = lstCollege;
                _schoolRepository.Insert(school);
                _schoolRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: School/Edit/5
        public ActionResult Edit(int id)
        {
            var getCollege = _collegeRepository.GetAll();
            SelectList lstCollege = new SelectList(getCollege, "CId", "Name");
            ViewBag.Colleges = lstCollege;
            return View(_schoolRepository.GetId(id));
        }

        [HttpPost]
        public ActionResult Edit(School school)
        {
            try
            {
                var getCollege = _collegeRepository.GetAll();
                SelectList lstCollege = new SelectList(getCollege, "CId", "Name");
                ViewBag.Colleges = lstCollege;
                _schoolRepository.Update(school);
                _schoolRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: School/Delete/5
        public ActionResult Delete(int id)
        {
            School school = _schoolRepository.GetId(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                School school = _schoolRepository.GetId(id);
                _schoolRepository.Delete(id);
                _schoolRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
