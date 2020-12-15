using FitnessTracker.Models.MealModels.MealPlan;
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
            var model = new MealPlanListItem[0];
            return View(model);
        }
    }
}