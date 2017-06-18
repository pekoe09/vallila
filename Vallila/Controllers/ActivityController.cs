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
            return View(activityService.GetAll());
        }

        // GET: Activity/Details/5
        public ActionResult Details(int id)
        {
            return View(activityService.GetById(id));
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
            return View(activityService.GetById(id));
        }

        // POST: Activity/Edit/5
        [HttpPost]
        public ActionResult Edit(ActivityDTO activityDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ActivityViewModel activityViewModel = activityService.Save(activityDTO);
                    TempData["success"] = String.Format("Activity {0} has been updated!", activityViewModel.Name);
                    return RedirectToAction("Index");
                }
                else
                {
                    ActivityViewModel activityViewModel = activityService.GetById((int)activityDTO.Id);
                    return View(activityViewModel);
                }
            }
            catch
            {
                ActivityViewModel activityViewModel = activityService.GetById((int)activityDTO.Id);
                return View(activityViewModel);
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
