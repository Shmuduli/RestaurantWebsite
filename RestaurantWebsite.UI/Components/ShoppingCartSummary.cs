using Microsoft.AspNetCore.Mvc;
using RestaurantWebsite.UI.Models;
using RestaurantWebsite.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Components
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCartRepository _shoppingCartRespository;

        public ShoppingCartSummary(ShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRespository = shoppingCartRepository;
        }

        public IViewComponentResult Invoke()
        {

            var items = _shoppingCartRespository.GetShoppingCartItems();
            _shoppingCartRespository.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCartRespository,
                ShoppingCartTotal = _shoppingCartRespository.GetShoppingCartTotal()

            };
            return View(shoppingCartViewModel);
        }

    }
}
