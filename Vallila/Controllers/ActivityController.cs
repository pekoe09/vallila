using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vallila.Services;
using Vallila.Models.Dtos;
using Vallila.Models.ViewModels;

namespace Vallila.Controllers
{
    public class ActivityController : Controller
    {
        private IActivityService activityService;

        public ActivityController (IActivityService activityService)
        {
            this.activityService = activityService;
        }

        // GET: Activity
        public ActionResult Index()
        {
            ViewData.Add("Activities", activityService.GetAll());
            return View();
        }

        // GET: Activity/Details/5
        public ActionResult Details(int id)
        {
            ViewData.Add("Activity", activityService.GetById(id));
            return View();
        }

        // GET: Activity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activity/Create
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

        // GET: Activity/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData.Add("Activity", activityService.GetById(id));
            return View();
        }

        // POST: Activity/Edit/5
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

        // POST: Activity/Delete/5
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
