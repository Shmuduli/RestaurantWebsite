using Microsoft.AspNetCore.Mvc;
using RestaurantWebsite.UI.Models;
using RestaurantWebsite.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IFoodItemRepository _foodItemRepository;
        private readonly ShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartController(IFoodItemRepository foodItemRepository, ShoppingCartRepository shoppingCartRepository)
        {
            _foodItemRepository = foodItemRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public IActionResult Index()
        {

            var items = _shoppingCartRepository.GetShoppingCartItems();
            _shoppingCartRepository.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart =_shoppingCartRepository,
                ShoppingCartTotal = _shoppingCartRepository.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }
        public RedirectToActionResult AddToShoppingCart(int foodId)
        {
            var selectedFood = _foodItemRepository.GetAllFoodItems.FirstOrDefault(p => p.FoodItemId == foodId);

            if (selectedFood != null)
            {
                _shoppingCartRepository.AddToCart(selectedFood, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int foodId)
        {
            var selectedFood = _foodItemRepository.GetAllFoodItems.FirstOrDefault(p => p.FoodItemId == foodId);

            if (selectedFood != null)
            {
                _shoppingCartRepository.RemoveFromCart(selectedFood);
            }
            return RedirectToAction("Index");
        }
    }
}
