using RestaurantWebsite.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Models
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartRepository ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
