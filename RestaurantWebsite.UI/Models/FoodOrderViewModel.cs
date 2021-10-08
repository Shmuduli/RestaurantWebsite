using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Models
{
    public class FoodOrderViewModel
    {
        List<OrderDetail> orderDetail { set; get; }
        List<FoodItem> foodItems { set; get; }
    }
}
