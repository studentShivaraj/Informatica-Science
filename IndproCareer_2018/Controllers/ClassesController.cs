using IndproCareer.Entity.Models;
using IndproCareer.Repository.DbContext;
using IndproCareer.Repository.IRepository;
using IndproCareer.Repository.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndproCareer_2018.Controllers
{
    public class ClassesController : Controller
    {
        IClassesRepository _classesRepository;
        ISchoolRepository _schoolRepository;
        ILanguageRepository _languageRepository;
        public ClassesController()
        {
            this._classesRepository = new ClassesRepository(new ApplicationDbContext());
            this._schoolRepository = new SchoolRepository(new ApplicationDbContext());
            this._languageRepository = new LanguageRepository(new ApplicationDbContext());
        }


        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "Name" : sortOrder;

            IPagedList<Class> classs = null;

            ApplicationDbContext db = new ApplicationDbContext();
            switch (sortOrder)
            {
                case "Name":
                    if (sortOrder.Equals(CurrentSort))
                        classs = db.Classes.OrderByDescending(m => m.Name).ToPagedList(pageIndex, pageSize);
                    else
                        classs = db.Classes.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize);
                    break;

                case "SId":
                    if (sortOrder.Equals(CurrentSort))
                        classs = db.Classes.OrderByDescending(m => m.SId).ToPagedList(pageIndex, pageSize);
                    else
                        classs = db.Classes.OrderBy(m => m.SId).ToPagedList(pageIndex, pageSize);
                    break;

                case "Madium":
                    if (sortOrder.Equals(CurrentSort))
                        classs = db.Classes.OrderByDescending(m => m.Madium).ToPagedList(pageIndex, pageSize);
                    else
                        classs = db.Classes.OrderBy(m => m.Madium).ToPagedList(pageIndex, pageSize);
                    break;

                case "Default":
                    classs = db.Classes.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize);
                    break;
            }
            return View(classs);
        }

        [HttpPost]
        public ActionResult Index(string Name, int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            ApplicationDbContext db = new ApplicationDbContext();
            var filter = from clas in db.Classes select clas;
            if (!string.IsNullOrEmpty(Name))
            {
                filter = filter.Where(a => a.Name.Contains(Name));
            }
            return View(filter.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize));
        }


        public ActionResult Details(int id)
        {
            return View(_classesRepository.GetId(id));
        }

        public ActionResult Create(List<Language> language)
        {
            var getSchool = _schoolRepository.GetAll();
            SelectList lstSchools = new SelectList(getSchool, "SId", "Name");
            ViewBag.School = lstSchools;

            //foreach (Language lang in language)
            //{
            //    Language getLang = _languageRepository.GetAll().ToList().Find(p => p.Id == lang.Id);
            //    getLang.Id = lang.Id;
            //    //updatedHobby.IsSelected = lang.IsSelected;
            //}

            return View();
        }

        [HttpPost]
        public ActionResult Create(Class cls)
        {
            try
            {
                var getSchool = _schoolRepository.GetAll();
                SelectList lstSchools = new SelectList(getSchool, "SId", "Name");
                ViewBag.School = lstSchools;
                _classesRepository.Insert(cls);
                _classesRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: University/Edit/5
        public ActionResult Edit(int id)
        {
            var getId = _classesRepository.GetId(id);
            return View(getId);
        }

        [HttpPost]
        public ActionResult Edit(Class clas)
        {
            try
            {
                _classesRepository.Update(clas);
                _classesRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: University/Delete/5
        public ActionResult Delete(int id)
        {
            // University university = db.University.Find(id);
            Class clas = _classesRepository.GetId(id);
            if (clas == null)
            {
                return HttpNotFound();
            }
            return View(clas);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConform(int id)
        {
            try
            {
                Class clas = _classesRepository.GetId(id);
                _classesRepository.Delete(id);
                _classesRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
