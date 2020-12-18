using FitnessTracker.Models.WorkoutModels.WorkoutModels;
using FitnessTracker.Services.WorkoutServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessTracker.Controllers
{
    public class WorkoutController : Controller
    {
        // GET: Workout
        public ActionResult Index()
        {
            var service = CreateWorkoutService();
            var model = service.GetAllWorkouts();

            return View(model);
        }

        // GET : Workout/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST : Workout/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkoutCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateWorkoutService();

            if (service.CreateWorkout(model))
            {
                TempData["SaveResult"] = "Workout created successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not create workout");
            return View(model);
        }

        //HELPER METHODS
        public WorkoutService CreateWorkoutService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutService(userId);

            return service;
        }

        public ActionResult AddWorkoutsToWorkoutPlan()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutForWorkoutPlanService(userId);

            service.CreateWorkoutsForWorkoutPlans();

            TempData["SaveResult"] = "Added workouts to workout plans.";

            return RedirectToAction("Index");
        }
    }
}