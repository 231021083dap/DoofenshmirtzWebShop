using DoofenshmirtzsWebShop.Controllers;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Services;
using DoofenshmirtzsWebShop.Database.Entities;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using static Xunit.Assert;
using DoofenshmirtzsWebShop.Database;
using DoofenshmirtzsWebShop.Repositories;

namespace DoofenshmirtzsWebShopProductTests
{
    public class ProductRepositoryTests
    {
        private DbContextOptions<DoofenshmirtzWebShopContext> _options;
        private readonly DoofenshmirtzWebShopContext _context;
        private readonly ProductRepository _sut;

        [Fact]
        public async void deleteAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        public ProductRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DoofenshmirtzWebShopContext>()
                .UseInMemoryDatabase(databaseName: "DoofenshmirtzWebShopProduct")
                .Options;
            _context = new DoofenshmirtzWebShopContext(_options);
            _sut = new ProductRepository(_context);
        }

        []
    }
}
