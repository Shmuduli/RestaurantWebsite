using RestaurantWebsite.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Repositories
{
    public interface IFoodItemRepository
    {
        IEnumerable<FoodItem> FoodItemsOfTheWeek { get; }
        IEnumerable<FoodItem> GetAllFoodItems { get; }
        FoodItem GetFoodItemById(int foodItemId);
        
    }
}
