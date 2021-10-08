using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Models
{
    public class FoodItemsListViewModel
    {
        public IEnumerable<FoodItem> FoodItems { get; set; }
        public string CurrentCategory { get; set; }
    }
}
