using DoofenshmirtzsWebShop.Database.Entities;
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

        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }

    }
}
