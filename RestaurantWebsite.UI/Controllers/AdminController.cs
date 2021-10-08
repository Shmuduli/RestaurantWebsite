using Microsoft.AspNetCore.Mvc;
using RestaurantWebsite.UI.Models;
using RestaurantWebsite.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Controllers
{
    public class AdminController : Controller
    {
        private IAdminRepository _adminRepository = null;
        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isLogged = _adminRepository.Validate(admin);
                    if (isLogged == true)
                        return RedirectToAction(controllerName: "Admin", actionName: "AdminDashboard");
                    else
                    {
                        ViewBag.Error = "Invalid credentials!";
                        return View("Login");
                    }

                }
                catch (Exception ex)
                {
                    return Content(ex.InnerException.Message);
                }
            }
            else
            {
                ViewBag.Error = "Enter all mandatory inputs!";
                return View("Login");
            }

        }
        public IActionResult AdminDashboard()
        {
            try
            {
                var foodItems = _adminRepository.ViewAllFoodItemsByAdmin();
                return View(foodItems);
            }
            catch(Exception ex)
            {
                return Content(ex.InnerException.Message);
            }
            
        }
    }
}
