using FitnessTracker.Data;
using FitnessTracker.Data.MealData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Services.MealServices
{
    public class MealForMealPlanService
    {
        //private field
        private readonly Guid _userId;

        public MealForMealPlanService(Guid userId)
        {
            _userId = userId;
        }

        //Create all meals for each mealplan
        public bool CreateMealsForMealPlans()
        {
            using(var ctx = new ApplicationDbContext())
            {
                List<int> currentMealsForMealPlan = new List<int>();

                bool add = true;

                foreach(MealForMealPlan current in ctx.MealForMealPlans)
                {
                    currentMealsForMealPlan.Add(current.MealId);
                }

                foreach(Meal meal in ctx.Meals)
                {
                    foreach(int exId in currentMealsForMealPlan)
                    {
                        if(exId == meal.MealId)
                        {
                            add = false;
                            break;
                        }
                    }

                    if(add)
                    {
                        var mealForMealPlan =
                            new MealForMealPlan()
                            {
                                MealPlanId = meal.MealPlanId,
                                MealId = meal.MealId
                            };
                        ctx.MealForMealPlans.Add(mealForMealPlan);
                    }

                    add = true;
                }

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
