using Microsoft.AspNetCore.Mvc;
using RestaurantWebsite.UI.Models;
using RestaurantWebsite.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly IFoodItemRepository _foodItemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public FoodItemController(IFoodItemRepository foodItemRepository, ICategoryRepository categoryRepository)
        {
            _foodItemRepository = foodItemRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<FoodItem> foodItems;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                foodItems = _foodItemRepository.GetAllFoodItems.OrderBy(p => p.FoodItemId);
                currentCategory = "All FoodItems";
            }
            else
            {
                foodItems = _foodItemRepository.GetAllFoodItems.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.FoodItemId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new FoodItemsListViewModel
            {
                FoodItems =foodItems ,
                CurrentCategory = currentCategory
            });
        }
        public IActionResult Details(int id)
        {
            var foodItem=_foodItemRepository.GetFoodItemById(id);
            if (foodItem == null)
                return NotFound();

            return View(foodItem);
        }

    }
}
