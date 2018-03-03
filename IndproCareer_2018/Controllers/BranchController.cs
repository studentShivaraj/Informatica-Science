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
    public class BranchController : Controller
    {
        private ICollegeRepository _collegeRepository;
        private IBranchRepository _branchRepository;
        public BranchController()
        {
            this._collegeRepository = new CollegeRepository(new ApplicationDbContext());
            this._branchRepository = new BranchRepository(new ApplicationDbContext());
        }

        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 3;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "Name" : sortOrder;

            IPagedList<Branch> branch = null;

            ApplicationDbContext db = new ApplicationDbContext();
            switch (sortOrder)
            {
                case "Name":
                    if (sortOrder.Equals(CurrentSort))
                        branch = db.Branchs.OrderByDescending(m => m.Name).ToPagedList(pageIndex, pageSize);
                    else
                        branch = db.Branchs.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize);
                    break;

                case "CId":
                    if (sortOrder.Equals(CurrentSort))
                        branch = db.Branchs.OrderByDescending(m => m.CId).ToPagedList(pageIndex, pageSize);
                    else
                        branch = db.Branchs.OrderBy(m => m.CId).ToPagedList(pageIndex, pageSize);
                    break;

                case "Default":
                    branch = db.Branchs.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize);
                    break;
            }
            return View(branch);
        }

        [HttpPost]
        public ActionResult Index(string Name, int? page)
        {
            int pageSize = 3;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            ApplicationDbContext db = new ApplicationDbContext();
            var filter = from branch in db.Branchs select branch;
            if (!string.IsNullOrEmpty(Name))
            {
                filter = filter.Where(a => a.Name.Contains(Name));
            }
            return View(filter.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize));
        }



        // GET: College/Create
        public ActionResult Create()
        {
            var get = _collegeRepository.GetAll();
            SelectList lstColleges = new SelectList(get, "CId", "Name");
            ViewBag.Branch = lstColleges;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            var get = _collegeRepository.GetAll();
            SelectList lstColleges = new SelectList(get, "CId", "Name");
            ViewBag.Branch = lstColleges;

            _branchRepository.Insert(branch);
            _branchRepository.Save();
            return RedirectToAction("Index");
           
        }

        public ActionResult Edit(int id)
        {
            var get = _collegeRepository.GetAll();
            SelectList lstColleges = new SelectList(get, "CId", "Name");
            ViewBag.Branch = lstColleges;

            var getId = _branchRepository.GetId(id);
            return View(getId);
        }

        [HttpPost]
        public ActionResult Edit(Branch branch)
        {
            try
            {
                var get = _collegeRepository.GetAll();
                SelectList lstColleges = new SelectList(get, "CId", "Name");
                ViewBag.Branch = lstColleges;

                _branchRepository.Update(branch);
                _branchRepository.Save();
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
            var getId = _branchRepository.GetId(id);
            return View(getId);
        }

        public ActionResult Delete(int id)
        {
            Branch branch = _branchRepository.GetId(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConform(int id)
        {
            try
            {
                Branch branch = _branchRepository.GetId(id);
                _branchRepository.Delete(id);
                _branchRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



    }
}
