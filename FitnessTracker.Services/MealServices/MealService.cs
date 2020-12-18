using FitnessTracker.Data;
using FitnessTracker.Data.MealData;
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
            using(var ctx = new ApplicationDbContext())
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
            var entity =
                new Meal()
                {
                    Title = model.Title,
                    OwnerId = _userId,
                    MealPlanId = model.MealPlanId
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Meals.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //Get a specific meal by Id
        public MealDetail GetMealById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Meals
                    .Single(m => m.MealId == id && m.OwnerId == _userId);

                return new MealDetail()
                {
                    MealId = entity.MealId,
                    Title = entity.Title,
                    MealPlanId = entity.MealPlanId
                };
            }
        }

        //Update meal
        public bool UpdateMeal(MealUpdate model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Meals
                    .Single(m => m.MealId == model.MealId && m.OwnerId == _userId);

                entity.Title = model.Title;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete meal
        public bool DeleteMeal(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Meals
                    .Single(m => m.MealId == id && m.OwnerId == _userId);

                var related =
                    ctx
                    .MealForMealPlans
                    .Single(m => m.MealId == id && m.Meal.OwnerId == _userId);

                ctx.MealForMealPlans.Remove(related);
                ctx.Meals.Remove(entity);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
