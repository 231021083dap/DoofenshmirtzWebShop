using DoofenshmirtzsWebShop.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DoofenshmirtzsWebShop.Database
{
    public class DoofenshmirtzWebShopContext : DbContext
    {
        public DoofenshmirtzWebShopContext() { }

        public DoofenshmirtzWebShopContext(DbContextOptions<DoofenshmirtzWebShopContext> options) : base(options) { }

        public DbSet<Address> Address { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    addressID = 1,
                    addressCustomerName = "Pinky the Chihuahua",
                    addressStreetName = "2034 Danville Avenue",
                    addressPostalCode = 6969,
                    addressCountryName = "TriState Area",
                    userID = 2
                },
                new Address
                {
                    addressID = 2,
                    addressCustomerName = "Planty the PottedPlant",
                    addressStreetName = "1001 Danville Boulevard",
                    addressPostalCode = 6969,
                    addressCountryName = "TriState Area",
                    userID = 3
                }

            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    categoryID = 1,
                    categoryName = "Products"
                },
                new Category
                {
                    categoryID = 2,
                    categoryName = "Books"
                },
                new Category
                {
                    categoryID = 3,
                    categoryName = "Merch"
                }
            );


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    userID = 1,
                    userEmail = "doofen@evil.com",
                    userPassword = "DamnYouPerry",
                    userName = "EvilMaster",
                    userRole = Helpers.Role.Admin
                },
                new User
                {
                    userID = 2,
                    userEmail = "perry@platypus.com",
                    userPassword = "Doofenia",
                    userName = "Perry",
                    userRole = Helpers.Role.User
                },
                new User
                {
                    userID = 3,
                    userEmail = "planty@pottedplant.com",
                    userPassword = "Planty1234",
                    userName = "Planty",
                    userRole = Helpers.Role.User
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    orderID = 1,
                    orderDate = DateTime.Parse("2021-9-21 12:23:21"),
                    userID = 2

                },
                new Order
                {
                    orderID = 2,
                    orderDate = DateTime.Parse("2021-10-21 12:23:21"),
                    userID = 3

                },
                 new Order
                 {
                     orderID = 3,
                     orderDate = DateTime.Parse("2021-9-25 12:23:21"),
                     userID = 3

                 }

                );

            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage
                {
                    productImageID = 1,
                    productImageImage = "...",
                    productImageImageDescription = "..............",
                    productID = 1,
                },
                new ProductImage
                {
                    productImageID = 2,
                    productImageImage = ".....",
                    productImageImageDescription = "....",
                    productID = 2
                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    productID = 1,
                    productName = "The I-Don't-Care-Inator",
                    productDescription = "Tired of listening to meaningless things all the time? try blasting them with this gun and you'll never have to hear them again!",
                    productStock = 7,
                    productPrice = 49,
                    categoryID = 1
                },
                new Product
                {
                    productID = 2,
                    productName = "Kill-half-the-people-in-the-world-with-a-snap-Inator",
                    productDescription = "Dr. Heinz Doofenshmirtz' no. 1 guide to everything you need to know about being evil!",
                    productStock = 2,
                    productPrice = 299,
                    categoryID = 1
                },
                new Product
                {
                    productID = 3,
                    productName = "Shut-The-Hell-Up-Inator",
                    productDescription = "Support your local evil branch with this T-shirt!",
                    productStock = 8,
                    productPrice = 50,
                    categoryID = 1
                }
                );
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    orderItemID = 1,
                    orderItemQuantity = 1,
                    orderItemPrice = 100,
                    productID = 1,
                    orderID = 1
                },
                 new OrderItem
                 {
                     orderItemID = 2,
                     orderItemQuantity = 1,
                     orderItemPrice = 30,
                     productID = 1,
                     orderID = 1
                 },
                 new OrderItem
                 {
                     orderItemID = 3,
                     orderItemQuantity = 5,
                     orderItemPrice = 125,
                     productID = 2,
                     orderID = 2
                 },
                 new OrderItem
                 {
                     orderItemID = 4,
                     orderItemQuantity = 1,
                     orderItemPrice = 30,
                     productID = 2,
                     orderID = 2
                 },
                 new OrderItem
                 {
                     orderItemID = 5,
                     orderItemQuantity = 1,
                     orderItemPrice = 30,
                     productID = 3,
                     orderID = 3
                 },
                  new OrderItem
                  {
                      orderItemID = 6,
                      orderItemQuantity = 55,
                      orderItemPrice = 500,
                      productID = 3,
                      orderID = 3
                  }
                );


        }

    }
}
