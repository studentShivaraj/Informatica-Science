﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndproCareer_2018.Controllers
{
    public class LearnJsController : Controller
    {
        // GET: LearnJs
        public ActionResult Index()
        {
            return View();
        }

        // GET: LearnJs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LearnJs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LearnJs/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LearnJs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LearnJs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LearnJs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LearnJs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
