using RestaurantWebsite.UI.DBContext;
using RestaurantWebsite.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private MyContext _myContext = null;

        public AdminRepository(MyContext myContext)
        {
            _myContext = myContext;
        }
        public bool Validate(Admin admin)
        {
            Admin _admin = _myContext.Admin.SingleOrDefault(i => i.LoginId == admin.LoginId && i.Password == admin.Password);
            if (_admin != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<FoodItem> ViewAllFoodItemsByAdmin()
        {
            List<FoodItem> foodItemsList = null;
            List<FoodItem> foodItems = _myContext.FoodItems.ToList();
            if (foodItems.Count > 0)
            {
                foodItemsList = new List<FoodItem>();
            }
            foreach (var foodItem in foodItems)
            {
                foodItemsList.Add(new FoodItem()
                {
                    FoodItemId = foodItem.FoodItemId,
                    Name = foodItem.Name,
                    ShortDescription = foodItem.ShortDescription,
                    LongDescription = foodItem.LongDescription,
                    AllergyInformation = foodItem.AllergyInformation,
                    Price = foodItem.Price,
                    ImageUrl = foodItem.ImageUrl,
                    ImageThumbnailUrl = foodItem.ImageThumbnailUrl,
                    IsFoodOfTheWeek = foodItem.IsFoodOfTheWeek,
                    InStock = foodItem.InStock,
                    CategoryId = foodItem.CategoryId,
                    Category = _myContext.Categories.SingleOrDefault(i => i.CategoryId == foodItem.CategoryId),
                  //  SalesCount = _myContext.OrderDetails.Where(i => i.FoodItemId == foodItem.FoodItemId).Sum(i => i.Amount)
                });
            }
            return foodItemsList;
        
        }
    }
}
