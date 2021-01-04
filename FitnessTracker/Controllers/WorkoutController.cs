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

        // GET : Workout/Detail
        public ActionResult Details(int id)
        {
            var service = CreateWorkoutService();
            var model = service.GetWorkoutById(id);

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

        // GET : Workout/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateWorkoutService();
            var detail = service.GetWorkoutById(id);

            var model =
                new WorkoutUpdate()
                {
                    WorkoutId = detail.WorkoutId,
                    Title = detail.Title
                };

            return View(model);
        }

        // POST : Workout/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkoutUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateWorkoutService();

            if (service.UpdateWorkout(model))
            {
                TempData["SaveResult"] = "Workout updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not update model");
            return View(model);
        }

        // GET : Workout/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateWorkoutService();
            var model = service.GetWorkoutById(id);

            return View(model);
        }

        // POST : Workout/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWorkout(int id)
        {
            var service = CreateWorkoutService();
            service.DeleteWorkout(id);

            TempData["SaveResult"] = "Workout deleted.";

            return RedirectToAction("Index");
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

            return RedirectToAction("Index", "WorkoutPlan");
        }
    }
}