using FitnessTracker.Models.MealModels.FoodItemModels;
using FitnessTracker.Services.MealServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessTracker.Controllers
{
    public class FoodItemController : Controller
    {
        // GET: FoodItem
        public ActionResult Index()
        {
            var service = CreateFoodItemService();
            var model = service.GetAllFoodItems();

            return View(model);
        }

        // GET : FoodItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST : FoodItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodItemCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateFoodItemService();

            if (service.CreateFoodItem(model))
            {
                TempData["SaveResult"] = "Created food item.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to create food item.");
            return View(model);
        }

        // GET : FoodItem/Details
        public ActionResult Details(int id)
        {
            var service = CreateFoodItemService();
            var model = service.GetFoodItemById(id);

            return View(model);
        }

        // GET : FoodItem/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateFoodItemService();
            var detail = service.GetFoodItemById(id);

            var model =
                new FoodItemUpdate()
                {
                    FoodItemId = detail.FoodItemId,
                    Name = detail.Name,
                    Quantity = detail.Quantity,
                    Calories = detail.Calories
                };

            return View(model);
        }

        // POST : FoodItem/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FoodItemUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateFoodItemService();

            if (service.UpdateFoodItem(model))
            {
                TempData["SaveResult"] = "Food item updated successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to update food item");

            return View(model);
        }

        // GET : FoodItem/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateFoodItemService();
            var model = service.GetFoodItemById(id);

            return View(model);
        }

        // POST : FoodItem/Delete
        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFoodItem(int id)
        {
            var service = CreateFoodItemService();

            service.DeleteFoodItem(id);

            TempData["SaveResult"] = "Deleted food item.";

            return RedirectToAction("Index");
        }

        //Helper methods
        private FoodItemService CreateFoodItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodItemService(userId);

            return service;
        }

        public ActionResult AddFoodItemsToMeal()
        {
            var uId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodItemForMealService(uId);

            service.CreateFoodItemsForMeals();

            TempData["SaveResult"] = "Added Food items to meal!";

            return RedirectToAction("Index", "Meal");
        }
    }
}