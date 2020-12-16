using FitnessTracker.Models.WorkoutModels.WorkoutPlan;
using FitnessTracker.Services.WorkoutServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessTracker.Controllers
{
    public class WorkoutPlanController : Controller
    {
        // GET: WorkoutPlan
        public ActionResult Index()
        {
            WorkoutPlanService service = CreateWorkoutPlanService();
            var model = service.GetWorkoutPlans();

            return View(model);
        }

        //GET : WorkoutPlan/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST : WorkoutPlan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkoutPlanCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            WorkoutPlanService service = CreateWorkoutPlanService();

            if (service.CreateNewWorkoutPlan(model))
            {
                TempData["SaveResult"] = "Your Workout Plan has been created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Workout Plan was not created");
            return View(model);
        }

        //GET : WorkoutPlan/Detail
        public ActionResult Details(int id)
        {
            var service = CreateWorkoutPlanService();
            var model = service.GetWorkoutById(id);

            return View(model);
        }

        //GET : WorkoutPlan/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateWorkoutPlanService();
            var detail = service.GetWorkoutById(id);

            var model =
                new WorkoutPlanUpdate()
                {
                    WorkoutPlanId = detail.WorkoutPlanId,
                    Title = detail.Title
                };

            return View(model);
        }

        //POST : WorkoutPlan/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkoutPlanUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateWorkoutPlanService();

            if (service.UpdateWorkoutPlan(model))
            {
                TempData["SaveResult"] = "Workout Plan successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to edit Workout Plan");
            return View(model);
        }

        //GET : WorkoutPlan/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateWorkoutPlanService();
            var model = service.GetWorkoutById(id);

            return View(model);
        }

        //POST : WorkoutPlan/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWorkoutPlan(int id)
        {
            var service = CreateWorkoutPlanService();

            service.DeleteWorkoutPlan(id);

            TempData["SaveResult"] = "Workout Plan successfully deleted.";

            return RedirectToAction("Index");
        }

        //helper methods
        private WorkoutPlanService CreateWorkoutPlanService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutPlanService(userId);

            return service;
        }
    }
}