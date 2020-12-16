using FitnessTracker.Models.GoalModels;
using FitnessTracker.Services.GoalServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessTracker.Controllers
{
    public class GoalController : Controller
    {
        // GET: Goal
        public ActionResult Index()
        {
            var service = CreateGoalService();
            var model = service.GetAllGoals();

            return View(model);
        }

        // GET: Goal/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST : Goal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GoalCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateGoalService();

            if (service.CreateGoal(model))
            {
                TempData["SaveResult"] = "Goal created successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Failed to create goal.");
            return View(model);
        }

        //GET : Goal/Detail
        public ActionResult Details(int id)
        {
            var service = CreateGoalService();
            var model = service.GetGoalById(id);

            return View(model);
        }

        //GET : Goal/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateGoalService();
            var detail = service.GetGoalById(id);

            var model =
                new GoalEdit()
                {
                    GoalId = detail.GoalId,
                    Title = detail.Title,
                    Description = detail.Description,
                    Completed = detail.Completed
                };

            return View(model);
        }

        //POST : Goal/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GoalEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(model.GoalId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGoalService();

            if (service.UpdateGoal(model))
            {
                TempData["SaveResult"] = "Goal was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to update goal");
            return View(model);
        }

        //GET : Goal/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateGoalService();
            var model = service.GetGoalById(id);

            return View(model);
        }

        //POST : Goal/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGoal(int id)
        {
            var service = CreateGoalService();
            service.DeleteGoal(id);

            TempData["SaveResult"] = "Goal deleted.";

            return RedirectToAction("Index");
        }

        //HELPER METHODS
        private GoalService CreateGoalService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GoalService(userId);

            return service;
        }
    }
}