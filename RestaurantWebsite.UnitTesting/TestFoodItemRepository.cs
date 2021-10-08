using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using RestaurantWebsite.UI.Models;
using RestaurantWebsite.UI.Repositories;

namespace RestaurantWebsite.UnitTesting
{
    public class TestFoodItemRepository
    {

        private readonly IFoodItemRepository _foodItemRepository;
        public TestFoodItemRepository()
        {
            IList<FoodItem> foodItems = new List<FoodItem>() 
            { 
               new FoodItem(){FoodItemId=1,Name="Chicken65",ShortDescription="Spicy food",LongDescription="One of the most famous food item in the restaurant",AllergyInformation="",Price=250,ImageUrl="",ImageThumbnailUrl="",IsFoodOfTheWeek=true,InStock=true,CategoryId=2} ,
               new FoodItem(){FoodItemId=2,Name="Palak Paneer",ShortDescription="Vegetarian food",LongDescription="One of the most famous food item in the restaurant",AllergyInformation="",Price=250,ImageUrl="",ImageThumbnailUrl="",IsFoodOfTheWeek=true,InStock=true,CategoryId=2},
               new FoodItem(){FoodItemId=3,Name="Chicken65",ShortDescription="Spicy food",LongDescription="One of the most famous food item in the restaurant",AllergyInformation="",Price=250,ImageUrl="",ImageThumbnailUrl="",IsFoodOfTheWeek=true,InStock=true,CategoryId=2}

,            };
            var mockFoodItemRepository = new Mock<IFoodItemRepository>();
            mockFoodItemRepository.Setup(repo => repo.GetAllFoodItems).Returns(foodItems.ToList());
            mockFoodItemRepository.Setup(repo => repo.FoodItemsOfTheWeek).Returns(foodItems.ToList());
            mockFoodItemRepository.Setup(repo => repo.GetFoodItemById(It.IsAny<int>())).Returns((int i) => foodItems.SingleOrDefault(x => x.FoodItemId == i));
            mockFoodItemRepository.SetupAllProperties();
            _foodItemRepository = mockFoodItemRepository.Object;
        }
        [Fact]
        public void TestAllFoodItems()
        {
            //int expected = 3;
            var fooditemlist = _foodItemRepository.GetAllFoodItems;
            Assert.NotNull(fooditemlist);
        }
        [Fact]
        public void TestFoodItemsoftheweek()
        {
            //int expected = 3;
            var fooditemlist = _foodItemRepository.FoodItemsOfTheWeek;
            Assert.NotNull(fooditemlist);
        }
        [Fact]
        public void TestGetFoodItem()
        {
            //Arrange
            string expected = "Palak Paneer";
            //Act
            var foodItem = _foodItemRepository.GetFoodItemById(2);
            //Assert
            Assert.Equal(expected, foodItem.Name);
        }
    }
}
