using FitnessTracker.Data;
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
    }
}
