using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantWebsite.UI.Models;
using RestaurantWebsite.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFoodItemRepository _foodItemRepository;
        public HomeController(ILogger<HomeController> logger,IFoodItemRepository foodItemRepository)
        {
            _logger = logger;
            _foodItemRepository = foodItemRepository;
        }


        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                FoodItemOfTheWeek = _foodItemRepository.FoodItemsOfTheWeek
            };

            return View(homeViewModel);
        }
       
    }
}
