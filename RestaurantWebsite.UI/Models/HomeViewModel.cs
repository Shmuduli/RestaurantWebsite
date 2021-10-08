using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Models
{
    public class HomeViewModel
    {
        public IEnumerable<FoodItem> FoodItemOfTheWeek { get; set; }
    }
}
