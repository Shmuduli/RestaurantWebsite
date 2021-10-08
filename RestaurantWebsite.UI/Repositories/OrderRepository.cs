using RestaurantWebsite.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantWebsite.UI.DBContext;
namespace RestaurantWebsite.UI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyContext _myContext;
        private readonly ShoppingCartRepository _shoppingCartRepository;

        public OrderRepository(MyContext myContext,ShoppingCartRepository shoppingCartRepository)
        {
            _myContext = myContext;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _shoppingCartRepository.ShoppingCartItems;
            order.OrderTotal = _shoppingCartRepository.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();
            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    FoodItemId = shoppingCartItem.FoodItem.FoodItemId,
                    Price = shoppingCartItem.FoodItem.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _myContext.Orders.Add(order);

            _myContext.SaveChanges();

        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            List<OrderDetail> orderDetails = (from i in _myContext.OrderDetails where i.OrderId == orderId select i).ToList();
            return orderDetails;
           
        }
    }
}
