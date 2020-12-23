using FitnessTracker.Models.WorkoutModels.ExerciseModels;
using FitnessTracker.Services.WorkoutServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessTracker.Controllers
{
    public class ExerciseController : Controller
    {
        // GET: Exercise
        public ActionResult Index()
        {
            var service = CreateExerciseService();
            var model = service.GetAllExercises();

            return View(model);
        }

        // GET : Exercise/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST : Exercise/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExerciseCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateExerciseService();

            if (service.CreateExercise(model))
            {
                TempData["SaveResult"] = "Exercise Created.";

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to create exercise.");

            return View(model);
        }

        // GET : Exercise/Detail
        public ActionResult Details(int id)
        {
            var service = CreateExerciseService();
            var model = service.GetExerciseById(id);
            return View(model);
        }

        // GET : Exercise/Update
        public ActionResult Edit(int id)
        {
            var service = CreateExerciseService();
            var detail = service.GetExerciseById(id);

            var model =
                new ExerciseUpdate()
                {
                    ExerciseId = detail.ExerciseId,
                    Name = detail.Name,
                    Description = detail.Description,
                    Repetition = detail.Repetition,
                    Sets = detail.Sets,
                    Length = detail.Length,
                    Muscle = detail.Muscle,
                    Type = detail.Type
                };

            return View(model);
        }

        // POST : Exercise/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ExerciseUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateExerciseService();

            if (service.UpdateExercise(model))
            {
                TempData["SaveResult"] = "Exercise updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to update Exercise.");
            return View(model);
        }

        // GET : Exercise/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateExerciseService();
            var model = service.GetExerciseById(id);

            return View(model);
        }

        // POST : Exercise/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteExercise(int id)
        {
            var service = CreateExerciseService();

            service.DeleteExercise(id);

            TempData["SaveResult"] = "Exercise deleted";

            return RedirectToAction("Index");
        }

        //Helper Method
        private ExerciseService CreateExerciseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExerciseService(userId);

            return service;
        }
    }
}