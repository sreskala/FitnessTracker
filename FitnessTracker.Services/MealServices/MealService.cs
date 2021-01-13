using FitnessTracker.Data;
using FitnessTracker.Data.MealData;
using FitnessTracker.Models.MealModels.FoodItemModels;
using FitnessTracker.Models.MealModels.JoiningTableModels;
using FitnessTracker.Models.MealModels.Meal;
using FitnessTracker.Models.MealModels.MealModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Services.MealServices
{
    public class MealService
    {
        //private field
        private readonly Guid _userId;

        public MealService(Guid userId)
        {
            _userId = userId;
        }

        //Get all Meals
        public IEnumerable<MealListItem> GetMeals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Meals
                    .Where(m => m.OwnerId == _userId)
                    .Select(
                        m =>
                        new MealListItem
                        {
                            MealId = m.MealId,
                            Title = m.Title
                        }
                        );
                return query.ToArray();
            }
        }

        //Create meal
        public bool CreateMeal(MealCreate model)
        {
            //Error handling
            using (var ctx = new ApplicationDbContext())
            {
                var mealPlanIds = ctx.MealPlans.Where(m => m.OwnerId == _userId).Select(m => m.MealPlanId);
                //var ownerIds = ctx.MealPlans.Where(m => m.OwnerId == _userId).Select(o => o.OwnerId);

                if (mealPlanIds.Contains(model.MealPlanId))
                {
                    var entity =
                    new Meal()
                    {
                        Title = model.Title,
                        OwnerId = _userId,
                        MealPlanId = model.MealPlanId
                    };

                    ctx.Meals.Add(entity);

                    return ctx.SaveChanges() == 1;
                } else
                {
                    return false;
                }
            }

        }

        //Get a specific meal by Id
        public MealDetail GetMealById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Meals
                    .SingleOrDefault(m => m.MealId == id && m.OwnerId == _userId);

                return new MealDetail()
                {
                    MealId = entity.MealId,
                    Title = entity.Title,
                    MealPlanId = entity.MealPlanId,
                    FoodItems =
                        ctx
                        .FoodItemForMeals
                        .Where(fm => fm.MealId == entity.MealId)
                        .Select(fm =>
                        new FoodItemForMealListItem
                        {
                            Id = fm.Id,
                            MealId = fm.MealId,
                            FoodItemId = fm.FoodItemId,
                            FoodItem = new FoodItemListItem
                            {
                                FoodItemId = fm.FoodItemId,
                                Name = fm.FoodItem.Name
                            }
                        }
                        ).ToList()
                };
            }
        }

        //Update meal
        public bool UpdateMeal(MealUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Meals
                    .SingleOrDefault(m => m.MealId == model.MealId && m.OwnerId == _userId);

                entity.Title = model.Title;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete meal
        public bool DeleteMeal(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Meals
                    .SingleOrDefault(m => m.MealId == id && m.OwnerId == _userId);

                var relatedMeal =
                    ctx
                    .MealForMealPlans
                    .SingleOrDefault(m => m.MealId == id && m.Meal.OwnerId == _userId);

                var relatedFood =
                    ctx
                    .FoodItemForMeals
                    .Where(f => f.MealId == id);

                var foodItems =
                    ctx
                    .FoodItems
                    .Where(f => f.MealId == id && f.OwnerId == _userId);

                ctx.MealForMealPlans.Remove(relatedMeal);
                ctx.FoodItemForMeals.RemoveRange(relatedFood);
                ctx.FoodItems.RemoveRange(foodItems);
                ctx.Meals.Remove(entity);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
