using FitnessTracker.Models.MealModels.MealPlan;
using FitnessTracker.Services.MealServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessTracker.Controllers
{
    [Authorize]
    public class MealPlanController : Controller
    {
        // GET: MealPlan
        public ActionResult Index()
        {
            MealPlanService service = CreateMealPlanService();
            var model = service.GetMealPlans();
            return View(model);
        }

        //GET: MealPlan/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: MealPlan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealPlanCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            MealPlanService service = CreateMealPlanService();

            if (service.CreateMealPlan(model))
            {
                TempData["SaveResult"] = "Your Meal Plan was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Meal Plan unable to be created.");
            return View(model);
        }

        //GET : MealPlan/Details
        public ActionResult Details(int id)
        {
            var service = CreateMealPlanService();
            var model = service.GetMealPlanById(id);

            return View(model);
        }

        //GET: MealPlan/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateMealPlanService();
            var detail = service.GetMealPlanById(id);
            var model =
                new MealPlanEdit
                {
                    MealPlanId = detail.MealPlanId,
                    Title = detail.Title,
                    Length = detail.Length
                };
            return View(model);
        }

        //POST : MealPlan/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MealPlanEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(model.MealPlanId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMealPlanService();

            if (service.UpdateMealPlan(model))
            {
                TempData["SaveResult"] = "Your Meal Plan was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Meal Plan could not be updated");
            return View(model);
        }

        //GET : MealPlan/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateMealPlanService();
            var model = service.GetMealPlanById(id);

            return View(model);
        }

        //POST : MealPlan/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMealPlan(int id)
        {
            var service = CreateMealPlanService();
            var model = service.GetMealPlanById(id);

            if (service.DeleteMealPlan(id))
            {
                TempData["SaveResult"] = "Your Meal Plan was Deleted.";

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to delete Meal Plan.");
            return View(model);
        }

        //HELPER METHODS
        private MealPlanService CreateMealPlanService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MealPlanService(userId);
            return service;
        }
    }
}