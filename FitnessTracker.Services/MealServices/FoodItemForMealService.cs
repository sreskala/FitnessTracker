using FitnessTracker.Data;
using FitnessTracker.Data.MealData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Services.MealServices
{
    public class FoodItemForMealService
    {
        //private field
        private readonly Guid _userId;

        public FoodItemForMealService(Guid userId)
        {
            _userId = userId;
        }

        //Create all food items for each meal
        public bool CreateFoodItemsForMeals()
        {
            using(var ctx = new ApplicationDbContext())
            {
                List<int> currentFoodItemsForMeals = new List<int>();
                bool add = true;

                foreach(FoodItemForMeal current in ctx.FoodItemForMeals)
                {
                    currentFoodItemsForMeals.Add(current.FoodItemId);
                }

                foreach(FoodItem foodItem in ctx.FoodItems)
                {
                    foreach(int exId in currentFoodItemsForMeals)
                    {
                        if(exId == foodItem.FoodItemId)
                        {
                            add = false;
                            break;
                        }
                    }

                    if (add)
                    {
                        var foodItemForMeal =
                            new FoodItemForMeal()
                            {
                                MealId = foodItem.MealId,
                                FoodItemId = foodItem.FoodItemId
                            };

                        ctx.FoodItemForMeals.Add(foodItemForMeal);
                    }

                    add = true;
                }

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
