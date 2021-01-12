using FitnessTracker.Data;
using FitnessTracker.Data.MealData;
using FitnessTracker.Models.MealModels.JoiningTableModels;
using FitnessTracker.Models.MealModels.Meal;
using FitnessTracker.Models.MealModels.MealPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Services.MealServices
{
    public class MealPlanService
    {
        //private field
        private readonly Guid _userId;

        public MealPlanService(Guid userId)
        {
            _userId = userId;
        }

        //CREATE A MEALPLAN
        public bool CreateMealPlan(MealPlanCreate model)
        {
            var entity =
                new MealPlan()
                {
                    Title = model.Title,
                    DateCreatedUtc = DateTimeOffset.Now,
                    Length = model.Length,
                    OwnerId = _userId
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.MealPlans.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET ALL MEALPLANS
        public IEnumerable<MealPlanListItem> GetMealPlans()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .MealPlans
                    .Where(m => m.OwnerId == _userId)
                    .Select(
                        m =>
                        new MealPlanListItem
                        {
                            MealPlanId = m.MealPlanId,
                            Title = m.Title,
                            DateCreatedUtc = m.DateCreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }

        //GET MEALPLAN BY ID
        public MealPlanDetail GetMealPlanById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MealPlans
                    .SingleOrDefault(m => m.MealPlanId == id && m.OwnerId == _userId);

                return
                    new MealPlanDetail
                    {
                        MealPlanId = entity.MealPlanId,
                        Title = entity.Title,
                        DateCreatedUtc = entity.DateCreatedUtc,
                        DateModifiedUtc = entity.DateModifiedUtc,
                        Length = entity.Length,
                        Meals =
                                ctx
                                .MealForMealPlans
                                .Where(mp => mp.MealPlanId == entity.MealPlanId)
                                .Select(mp =>
                                new MealForMealPlanListItem
                                {
                                    Id = mp.Id,
                                    MealPlanId = mp.MealPlanId,
                                    MealId = mp.MealId,
                                    Meal = new MealListItem
                                    {
                                        MealId = mp.MealId,
                                        Title = mp.Meal.Title
                                    }
                                }).ToList()
                    };
            }
        }

        //EDIT MEALPLAN BY ID
        public bool UpdateMealPlan(MealPlanEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .MealPlans
                    .SingleOrDefault(m => m.MealPlanId == model.MealPlanId && m.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Length = model.Length;
                entity.DateModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE MEALPLAN BY ID
        public bool DeleteMealPlan(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MealPlans
                    .SingleOrDefault(m => m.MealPlanId == id && m.OwnerId == _userId);

                ctx.MealPlans.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
