﻿using DoofenshmirtzsWebShop.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    addressID = 1,
                    addressCustomerName = "Test McTesting",
                    addressStreetName = "Danville 101",
                    addressPostalCode = 6969,
                    addressCountryName = "Carkeys",
                    userID = 1
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
                    userEmail = "test@test.dk",
                    userPassword = "Test1234",
                    userName = "Test101",
                    userRole = Helpers.Role.User
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    orderID = 1,
                    orderDate = DateTime.Now,
                    userID = 1
                },
                new Order
                {
                    orderID = 2,
                    orderDate = DateTime.Now,
                    userID = 2
                },
                 new Order
                 {
                    orderID = 3,
                    orderDate = DateTime.Now,
                    userID = 3
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


        }

    }
}
