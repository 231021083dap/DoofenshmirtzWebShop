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

        public DbSet<Address> Address { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }

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
        }

    }
}
