using Microsoft.EntityFrameworkCore;
using RestaurantWebsite.UI.DBContext;
using RestaurantWebsite.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Repositories
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly MyContext _myContext;
        public FoodItemRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public IEnumerable<FoodItem> FoodItemsOfTheWeek
        {
            get
            {
                return _myContext.FoodItems.Include(c => c.Category).Where(p => p.IsFoodOfTheWeek);
            }
        }

        public IEnumerable<FoodItem> GetAllFoodItems
        {
            get
            {
                return _myContext.FoodItems.Include(c => c.Category);
            }
        }

        public FoodItem GetFoodItemById(int foodItemId)
        {
            return _myContext.FoodItems.FirstOrDefault(p => p.FoodItemId == foodItemId);
        }
    }
}
