using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vallila.Controllers
{
    public class BusinessUnitController : Controller
    {
        // GET: BusinessUnit
        public ActionResult Index()
        {
            return View();
        }

        // GET: BusinessUnit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BusinessUnit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessUnit/Create
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

        // GET: BusinessUnit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BusinessUnit/Edit/5
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

        // GET: BusinessUnit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BusinessUnit/Delete/5
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
