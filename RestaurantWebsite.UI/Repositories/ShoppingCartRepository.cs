using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantWebsite.UI.DBContext;
using RestaurantWebsite.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Repositories
{
    public class ShoppingCartRepository
    {
        private readonly MyContext _myContext;
        
        public string ShoppingCartId { set; get; }
        public List<ShoppingCartItem> ShoppingCartItems { set; get; }

        private ShoppingCartRepository(MyContext myContext)
        {
            _myContext = myContext;
        }
        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<MyContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCartRepository(context) { ShoppingCartId = cartId };
        }
        public void AddToCart(FoodItem foodItem, int amount)
        {
            var shoppingCartItem =
                    _myContext.ShoppingCartItems.SingleOrDefault(
                        s => s.FoodItem.FoodItemId == foodItem.FoodItemId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    FoodItem = foodItem,
                    Amount = 1
                };

                _myContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _myContext.SaveChanges();
        }
        public int RemoveFromCart(FoodItem foodItem)
        {
            var shoppingCartItem =
                    _myContext.ShoppingCartItems.SingleOrDefault(
                        s => s.FoodItem.FoodItemId == foodItem.FoodItemId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _myContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _myContext.SaveChanges();

            return localAmount;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _myContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.FoodItem)
                           .ToList());
        }
        public void ClearCart()
        {
            var cartItems = _myContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _myContext.ShoppingCartItems.RemoveRange(cartItems);

            _myContext.SaveChanges();
        }
        public decimal GetShoppingCartTotal()
        {
            var total = _myContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.FoodItem.Price * c.Amount).Sum();
            return total;
        }

    }
}
