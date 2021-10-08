using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantWebsite.UI.Models;
using RestaurantWebsite.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public int orderID;
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCartRepository _shoppingCartRepository;
        private readonly IFoodItemRepository _foodItemRepository;

        public OrderController(IOrderRepository orderRepository, ShoppingCartRepository shoppingCartRepository,IFoodItemRepository foodItemRepository)
        {
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _foodItemRepository = foodItemRepository;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
           
            var items = _shoppingCartRepository.GetShoppingCartItems();
            _shoppingCartRepository.ShoppingCartItems = items;

            if (_shoppingCartRepository.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some fooditems first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                HttpContext.Session.SetString("orderid", order.OrderId.ToString());
                _shoppingCartRepository.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }
        
        public IActionResult CheckoutComplete()
        {
            string ord = HttpContext.Session.GetString("orderid");
            int orderId = Convert.ToInt32(ord);
            List<FoodItem> foodItems =new List<FoodItem>();
            List<OrderDetail> orderDetails = _orderRepository.GetOrderDetails(orderId);
            decimal total=0;
            foreach( var order in orderDetails)
            {
                total =total+ order.Price;
                FoodItem foodItem = _foodItemRepository.GetFoodItemById(order.FoodItemId);
                foodItems.Add(foodItem);
            }
            ViewBag.Total = total;

            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious food!";
            return View(foodItems);
        }
    }
}
