using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vallila.Controllers
{
    public class NationalHolidayController : Controller
    {
        // GET: NationalHoliday
        public ActionResult Index()
        {
            return View();
        }

        // GET: NationalHoliday/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NationalHoliday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NationalHoliday/Create
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

        // GET: NationalHoliday/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NationalHoliday/Edit/5
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

        // GET: NationalHoliday/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NationalHoliday/Delete/5
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
