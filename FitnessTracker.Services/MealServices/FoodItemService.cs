using FitnessTracker.Data;
using FitnessTracker.Models.MealModels.FoodItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Services.MealServices
{
    public class FoodItemService
    {
        //private field
        private readonly Guid _userId;

        public FoodItemService(Guid userId)
        {
            _userId = userId;
        }

        //Get all food items
        public IEnumerable<FoodItemListItem> GetAllFoodItems()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .FoodItems
                    .Where(f => f.OwnerId == _userId)
                    .Select(
                        f =>
                        new FoodItemListItem
                        {
                            FoodItemId = f.FoodItemId,
                            Name = f.Name,
                            MealId = f.MealId
                        }
                        );
                return query.ToArray();
            }
        }

        //Create a food item
        public bool CreateFoodItem(FoodItemCreate model)
        {
            var entity =
                new FoodItem()
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Calories = model.Calories,
                    OwnerId = _userId,
                    MealId = model.MealId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FoodItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get food item by id
        public FoodItemDetail GetFoodItemById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FoodItems
                    .Single(f => f.FoodItemId == id && f.OwnerId == _userId);

                return new FoodItemDetail()
                {
                    FoodItemId = entity.FoodItemId,
                    Name = entity.Name,
                    Quantity = entity.Quantity,
                    Calories = entity.Calories,
                    MealId = entity.MealId
                };
            }
        }

        //Update food item
        public bool UpdateFoodItem(FoodItemUpdate model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FoodItems
                    .Single(f => f.FoodItemId == model.FoodItemId && f.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Quantity = model.Quantity;
                entity.Calories = model.Calories;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete food item
        public bool DeleteFoodItem(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FoodItems
                    .Single(f => f.FoodItemId == id && f.OwnerId == _userId);

                var related =
                    ctx
                    .FoodItemForMeals
                    .Single(fi => fi.FoodItemId == id && fi.FoodItem.OwnerId == _userId);

                ctx.FoodItemForMeals.Remove(related);
                ctx.FoodItems.Remove(entity);
                return ctx.SaveChanges() > 0;
            }
        }
    }
}
