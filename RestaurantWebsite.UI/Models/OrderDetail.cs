using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int FoodItemId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public FoodItem FoodItem { set; get; }
        public Order Order { get; set; }
    }
}
