
using IndproCareer.Entity.Models;
using IndproCareer.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndproCareer.Repository.Repository;
using IndproCareer.Repository.IRepository;

using System.IO;
using System.Web.UI;
using PagedList;
using System.Web.UI.WebControls;


namespace IndproCareer_2018.Controllers
{
    public class UniversityController : Controller
    {
        private IUniversityRepository _universityRepository;
        public UniversityController()
        {
            this._universityRepository = new UniversityRepository(new ApplicationDbContext());
        }

        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "Name" : sortOrder;

            IPagedList<University> university = null;
            ApplicationDbContext db = new ApplicationDbContext();
            switch (sortOrder)
            {
                case "Name":
                    if (sortOrder.Equals(CurrentSort))
                        university = db.University.OrderByDescending(m => m.Name).ToPagedList(pageIndex, pageSize);
                    else
                        university = db.University.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize);
                    break;
              
                case "YOE":
                    if (sortOrder.Equals(CurrentSort))
                        university = db.University.OrderByDescending(m => m.YOE).ToPagedList(pageIndex, pageSize);
                    else
                        university = db.University.OrderBy(m => m.YOE).ToPagedList(pageIndex, pageSize);
                    break;
                case "Slogan":
                    if (sortOrder.Equals(CurrentSort))
                        university = db.University.OrderByDescending(m => m.Slogan).ToPagedList(pageIndex, pageSize);
                    else
                        university = db.University.OrderBy(m => m.Slogan).ToPagedList(pageIndex, pageSize);
                    break;
                case "Default":
                    university = db.University.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize);
                    break;
                    
            }
            return View(university);
        }


        [HttpPost]
        public ActionResult Index(string Name, int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            ApplicationDbContext db = new ApplicationDbContext();
            var filter = from uni in db.University select uni;
            if (!string.IsNullOrEmpty(Name))
            {
                filter = filter.Where(a => a.Name.Contains(Name));
            }
            return View(filter.OrderBy(m => m.Name).ToPagedList(pageIndex, pageSize));
        }

        // GET: University/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(University university)
        {
            try
            {
                _universityRepository.Insert(university);
                _universityRepository.Save();
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
            var getId = _universityRepository.GetId(id);
            return View(getId);
        }

        [HttpPost]
        public ActionResult Edit(University university)
        {
            try
            {
                _universityRepository.Update(university);
                _universityRepository.Save();
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
            var getId = _universityRepository.GetId(id);
            return View(getId);
        }

        // GET: University/Delete/5
        public ActionResult Delete(int id)
        {          
            University university = _universityRepository.GetId(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);


        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConform(int id)
        {
            try
            {
                University university = _universityRepository.GetId(id);
                _universityRepository.Delete(id);
                _universityRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult ExportData(int id, University university)
        {
            var gridView = new GridView();
            gridView.DataSource = _universityRepository.GetExportData(id);
            gridView.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            var Name = _universityRepository.GetId(id).Name;
            var fileName = Name + DateTime.Now.ToString("_yyyyMMddTHHmm") + ".docx";
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
            return View("Index", university);
        }



    }
}
