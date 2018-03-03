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
    public class LanguageController : Controller
    {
        ILanguageRepository _languageRepository;
        public LanguageController()
        {
            this._languageRepository = new LanguageRepository(new ApplicationDbContext());
        }
        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "Name" : sortOrder;
            IPagedList<Language> language = null;

            ApplicationDbContext db = new ApplicationDbContext();
            switch (sortOrder)
            {
                case "Name":
                    if (sortOrder.Equals(CurrentSort))
                        language = db.Languages.OrderByDescending(m => m.Name).ToPagedList(pageIndex, pageSize);
                    else
                        language = db.Languages.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize);
                    break;

                case "Default":
                    language = db.Languages.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize);
                    break;
            }
            return View(language);
        }

        [HttpPost]
        public ActionResult Index(string Name, int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            ApplicationDbContext db = new ApplicationDbContext();
            var filter = from lang in db.Languages select lang;
            if (!string.IsNullOrEmpty(Name))
            {
                filter = filter.Where(a => a.Name .Contains(Name));
            }
            return View(filter.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Language language)
        {
            try
            {
                _languageRepository.Insert(language);
                _languageRepository.Save();
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
            var getId = _languageRepository.GetId(id);
            return View(getId);
        }

        [HttpPost]
        public ActionResult Edit(Language language)
        {
            try
            {
                _languageRepository.Update(language);
                _languageRepository.Save();
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
            var getId = _languageRepository.GetId(id);
            return View(getId);
        }

        // GET: University/Delete/5
        public ActionResult Delete(int id)
        {
            Language language = _languageRepository.GetId(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConform(int id)
        {
            try
            {
                Language language = _languageRepository.GetId(id);
                _languageRepository.Delete(id);
                _languageRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
