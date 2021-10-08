using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantWebsite.UI.Models;

namespace RestaurantWebsite.UI.DBContext
{
    public class MyContext : IdentityDbContext<IdentityUser>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admin { set; get; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Login> Logins { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Veg" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Non Veg" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Drinks" });

            //seed pies

            modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            {
                FoodItemId = 1,
                Name = "Watermelon Granita",
                Price = 100,
                ShortDescription = "Watermelon Granita",
                LongDescription =
                    "",
                CategoryId = 1,
                ImageUrl = "https://i.ibb.co/NnCpYy9/watermelon-lychee-granita-1.jpg",
                InStock = true,
                IsFoodOfTheWeek = true,
                ImageThumbnailUrl = "https://i.ibb.co/NnCpYy9/watermelon-lychee-granita-1.jpg",
                AllergyInformation = ""
            });

            modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            {
                FoodItemId = 2,
                Name = "Chicken Nizami",
                Price = 300,
                ShortDescription = "You'll love it!",
                LongDescription =
                    "",
                CategoryId = 2,
                ImageUrl = "https://i.ibb.co/y5hK1zZ/22-jpg.png",
                InStock = true,
                IsFoodOfTheWeek = true,
                ImageThumbnailUrl = "https://i.ibb.co/y5hK1zZ/22-jpg.png",
                AllergyInformation = ""
            });

            modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            {
                FoodItemId = 3,
                Name = "Paneer Tikka",
                Price =250 ,
                ShortDescription = "Paneer Tikka.",
                LongDescription =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 1,
                ImageUrl = "https://i.ibb.co/kmrQqzQ/paneertikka.jpg",
                InStock = true,
                IsFoodOfTheWeek = true,
                ImageThumbnailUrl = "https://i.ibb.co/kmrQqzQ/paneertikka.jpg",
                AllergyInformation = ""
            });

            modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            {
                FoodItemId = 4,
                Name = "Palak Paneer",
                Price = 200,
                ShortDescription = "Palak Paneer",
                LongDescription =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 1,
                ImageUrl = "https://i.ibb.co/ry3Vxjm/palakpaneer.jpg",
                InStock = true,
                IsFoodOfTheWeek = false,
                ImageThumbnailUrl = "https://i.ibb.co/ry3Vxjm/palakpaneer.jpg",
                AllergyInformation = ""
            });

            modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            {
                FoodItemId = 5,
                Name = "Mango Mastani",
                Price = 150,
                ShortDescription = "Happy holidays with this drink!",
                LongDescription =
                    "A thick mango milkshake with ice cream scoops drooling over it, Mango Mastani is an amazing beverage for the summer season. Mastani is a dessert drink originated in Pune, it is a rich and satisfying dessert.",
                CategoryId = 3,
                ImageUrl = "https://i.ibb.co/Wx5zXtQ/mango-mastani-1.png",
                InStock = true,
                IsFoodOfTheWeek = false,
                ImageThumbnailUrl =
                    "https://i.ibb.co/Wx5zXtQ/mango-mastani-1.png",
                AllergyInformation = ""
            });
            modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            {
                FoodItemId = 6,
                Name = "Lassi",
                Price = 120,
                ShortDescription = "Happy holidays with this drink!",
                LongDescription =
                  "A chilled glass of lassi made with yogurt to cool down on a hot summer day. Prepare sweet or salty lassi at home with this easy recipe made with a handful of ingredients in just a few minutes.",
                CategoryId = 3,
                ImageUrl = "https://i.ibb.co/kxrQGG8/Lassi-1.png",
                InStock = true,
                IsFoodOfTheWeek = false,
                ImageThumbnailUrl =
                  "https://i.ibb.co/kxrQGG8/Lassi-1.png ",
                AllergyInformation = ""
            });
            modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            {
                FoodItemId = 7,
                Name = "Iced Coffee",
                Price = 160,
                ShortDescription = "A layer of flavours with nutmeg, coffee and ice cream, topped off with coffee ice cubes!",
                LongDescription =
                 "A layer of flavours nutmeg, coffee and ice cream, topped off with coffee ice cubes!",
                CategoryId = 3,
                ImageUrl = "https://i.ibb.co/pZh3jnS/Iced-Coffee-1.png",
                InStock = true,
                IsFoodOfTheWeek = false,
                ImageThumbnailUrl =
                 "https://i.ibb.co/pZh3jnS/Iced-Coffee-1.png",
                AllergyInformation = ""
            });
        
            modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            {
                FoodItemId = 8,
                Name = "Chicken 65",
                Price = 250,
                ShortDescription = "Chicken 65",
                LongDescription =
                                "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 2,
                ImageUrl = "https://i.ibb.co/Lk9qSDf/Chicken-65-1.png",
                InStock = true,
                IsFoodOfTheWeek = true,
                ImageThumbnailUrl = "https://i.ibb.co/Lk9qSDf/Chicken-65-1.png",
                AllergyInformation = ""
            });
            //modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            //{
            //    FoodItemId = 6,
            //    Name = "Cranberry Pie",
            //    Price = 17.95M,
            //    ShortDescription = "A Christmas favorite",
            //    LongDescription =
            //        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            //    CategoryId = 3,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cranberrypie.jpg",
            //    InStock = true,
            //    IsFoodOfTheWeek = false,
            //    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cranberrypiesmall.jpg",
            //    AllergyInformation = ""
            //});

            //modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            //{
            //    FoodItemId = 7,
            //    Name = "Peach Pie",
            //    Price = 15.95M,
            //    ShortDescription = "Sweet as peach",
            //    LongDescription =
            //        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            //    CategoryId = 1,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/peachpie.jpg",
            //    InStock = false,
            //    IsFoodOfTheWeek = false,
            //    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/peachpiesmall.jpg",
            //    AllergyInformation = ""
            //});

            //modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            //{
            //    FoodItemId = 8,
            //    Name = "Pumpkin Pie",
            //    Price = 12.95M,
            //    ShortDescription = "Our Halloween favorite",
            //    LongDescription =
            //        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            //    CategoryId = 3,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpie.jpg",
            //    InStock = true,
            //    IsFoodOfTheWeek = true,
            //    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpiesmall.jpg",
            //    AllergyInformation = ""
            //});


            //modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            //{
            //    FoodItemId = 9,
            //    Name = "Rhubarb Pie",
            //    Price = 15.95M,
            //    ShortDescription = "My God, so sweet!",
            //    LongDescription =
            //        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            //    CategoryId = 1,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpie.jpg",
            //    InStock = true,
            //    IsFoodOfTheWeek = true,
            //    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpiesmall.jpg",
            //    AllergyInformation = ""
            //});

            //modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            //{
            //    FoodItemId = 10,
            //    Name = "Strawberry Pie",
            //    Price = 15.95M,
            //    ShortDescription = "Our delicious strawberry pie!",
            //    LongDescription =
            //        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            //    CategoryId = 1,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypie.jpg",
            //    InStock = true,
            //    IsFoodOfTheWeek = false,
            //    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypiesmall.jpg",
            //    AllergyInformation = ""
            //});

            //modelBuilder.Entity<FoodItem>().HasData(new FoodItem
            //{
            //    FoodItemId = 11,
            //    Name = "Strawberry Cheese Cake",
            //    Price = 18.95M,
            //    ShortDescription = "You'll love it!",
            //    LongDescription =
            //        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
            //    CategoryId = 2,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrycheesecake.jpg",
            //    InStock = false,
            //    IsFoodOfTheWeek = false,
            //    ImageThumbnailUrl =
            //        "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrycheesecakesmall.jpg",
            //    AllergyInformation = ""
            //});
        }
    }
}
