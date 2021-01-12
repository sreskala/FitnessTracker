using FitnessTracker.Models.MealModels.Meal;
using FitnessTracker.Models.MealModels.MealModels;
using FitnessTracker.Services.MealServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessTracker.Controllers
{
    public class MealController : Controller
    {
        // GET: Meal
        public ActionResult Index()
        {
            var service = CreateMealService();
            var model = service.GetMeals();
            return View(model);
        }

        // GET : Meal/Detail
        public ActionResult Details(int id)
        {
            var service = CreateMealService();
            var model = service.GetMealById(id);

            return View(model);
        }

        //GET : Meal/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST : Meal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateMealService();

            if (service.CreateMeal(model))
            {
                TempData["SaveResult"] = "Meal successfully created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to create meal.");
            return View(model);
        }

        //GET : Meal/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateMealService();
            var detail = service.GetMealById(id);

            var model =
                new MealUpdate()
                {
                    MealId = detail.MealId,
                    Title = detail.Title
                };

            return View(model);
        }

        //POST : Meal/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MealUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateMealService();

            if (service.UpdateMeal(model))
            {
                TempData["SaveResult"] = "Meal was updated.";

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to update meal.");

            return View(model);
        }

        // GET : Meal/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateMealService();
            var model = service.GetMealById(id);

            return View(model);
        }

        // POST : Meal/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMeal(int id)
        {
            var service = CreateMealService();
            var model = service.GetMealById(id);

            if(service.DeleteMeal(id))
            {
                TempData["SaveResult"] = "Meal deleted.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to delete meal.");
            return View(model);
        }

        //HELPER METHOD
        public MealService CreateMealService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MealService(userId);

            return service;
        }

        public ActionResult AddMealsToMealPlan()
        {
            var uId = Guid.Parse(User.Identity.GetUserId());
            var service = new MealForMealPlanService(uId);

            service.CreateMealsForMealPlans();

            TempData["SaveResult"] = "Meals added.";

            return RedirectToAction("Index", "MealPlan");
        }
    }
}