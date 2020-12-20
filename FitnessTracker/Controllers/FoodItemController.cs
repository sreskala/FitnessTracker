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

        //Helper methods
        private FoodItemService CreateFoodItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodItemService(userId);

            return service;
        }
    }
}