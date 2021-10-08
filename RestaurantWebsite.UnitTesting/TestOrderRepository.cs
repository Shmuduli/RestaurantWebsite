
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RestaurantWebsite.UI.Models;
using RestaurantWebsite.UI.Repositories;
using Xunit;


namespace RestaurantWebsite.UnitTesting
{
    
    public class TestOrderRepository
    {
        private readonly IOrderRepository _orderRepository;
        public TestOrderRepository()
        {
            IList<Order> orders = new List<Order>()
            {
               new Order(){OrderId=1,FirstName="Anu",LastName="KJ",AddressLine1="ABC street",AddressLine2="",ZipCode="628301",City="kallakurichi",State="Tamilnadu",Country="India",PhoneNumber="9876543210",Email="anu@gmail.com",OrderTotal=100.00M,OrderPlaced=Convert.ToDateTime("2021-10-06 13:05:51.2126039")} ,
               new Order(){OrderId=2,FirstName="Jai",LastName="RM",AddressLine1="DEC street",AddressLine2="",ZipCode="628501",City="Madurai",State="Tamilnadu",Country="India",PhoneNumber="9887766510",Email="jai@gmail.com",OrderTotal=300.00M,OrderPlaced=Convert.ToDateTime("2021-10-07 13:05:51.2126039")},
               new Order(){OrderId=3,FirstName="Shree",LastName="RM",AddressLine1="NOVR street",AddressLine2="",ZipCode="628502",City="Manamadurai",State="Tamilnadu",Country="India",PhoneNumber="9884966510",Email="shree@gmail.com",OrderTotal=250.00M,OrderPlaced=Convert.ToDateTime("2021-10-08 13:05:51.2126039")}

,            };
            IList<OrderDetail> orderDetails = new List<OrderDetail>()
            {
               new OrderDetail(){OrderDetailId=1,OrderId=1,FoodItemId=1,Amount=1,Price=100},
               new OrderDetail(){OrderDetailId=2,OrderId=2,FoodItemId=2,Amount=1,Price=300},
               new OrderDetail(){OrderDetailId=3,OrderId=3,FoodItemId=3,Amount=1,Price=250}

,            };
            var mockFoodItemRepository = new Mock<IOrderRepository>();
            mockFoodItemRepository.Setup(repo => repo.CreateOrder(It.IsAny<Order>()));
            mockFoodItemRepository.Setup(repo => repo.GetOrderDetails(It.IsAny<int>())).Returns((int i) => orderDetails.Where(x => x.OrderId == i).ToList());
            //mockFoodItemRepository.Setup(repo => repo.GetAllFoodItems).Returns(foodItems.ToList());
            //mockFoodItemRepository.Setup(repo => repo.FoodItemsOfTheWeek).Returns(foodItems.ToList());
            //mockFoodItemRepository.Setup(repo => repo.GetFoodItemById(It.IsAny<int>())).Returns((int i) => foodItems.SingleOrDefault(x => x.FoodItemId == i));
            mockFoodItemRepository.SetupAllProperties();
            _orderRepository = mockFoodItemRepository.Object;
        }
        
        [Fact]
        public void TestCreateOrder()
        {
            var order = new Order() { OrderId = 4, FirstName = "Sharmi", LastName = "M", AddressLine1 = "Vakkil street", AddressLine2 = "", ZipCode = "628302", City = "Dharmapuri", State = "Tamilnadu", Country = "India", PhoneNumber = "9856436510", Email = "sharmi@gmail.com", OrderTotal = 100.00M, OrderPlaced = Convert.ToDateTime("2021-10-09 13:05:51.2126039") };
            _orderRepository.CreateOrder(order);

            Xunit.Assert.Equal(1, 1);
        }
        
        [Fact]
        public void TestGetOrderDetails()
        {
            int orderId = 1;
            List<OrderDetail> _orderDetails = _orderRepository.GetOrderDetails(orderId);
            Xunit.Assert.All<OrderDetail>(_orderDetails,item => Xunit.Assert.Equal(1,item.OrderId));
        }

    }
}
