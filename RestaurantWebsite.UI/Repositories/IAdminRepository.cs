using RestaurantWebsite.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Repositories
{
    public interface IAdminRepository
    {
        bool Validate(Admin admin);
        IEnumerable<FoodItem> ViewAllFoodItemsByAdmin();

    }
}
