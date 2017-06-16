using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vallila.Controllers
{
    public class LoggedTimeController : Controller
    {
        // GET: LoggedTime
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoggedTime/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoggedTime/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoggedTime/Create
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

        // GET: LoggedTime/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoggedTime/Edit/5
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

        // GET: LoggedTime/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoggedTime/Delete/5
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
