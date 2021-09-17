using DoofenshmirtzsWebShop.Database;
using DoofenshmirtzsWebShop.Database.Entities;
using DoofenshmirtzsWebShop.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DoofenshmirtzsWebshopCategoryTests
{
    public class CategoryRepositoryTests
    {
        private readonly CategoryRepository _sut;
        private readonly DoofenshmirtzWebShopContext _context;
        private readonly DbContextOptions<DoofenshmirtzWebShopContext> _options;

        public CategoryRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DoofenshmirtzWebShopContext>()
                .UseInMemoryDatabase(databaseName: "DoofenshmirtzWebShopCatagory")
                .Options;
            _context = new DoofenshmirtzWebShopContext(_options);
            _sut = new CategoryRepository(_context);
        }

        [Fact]
        public async Task getAll_shouldReturnListOfCategories_whenCategoriesExists()
        {
            await _context.Database.EnsureDeletedAsync();
            _context.Category.Add(new Category
            {
                categoryID = 1,
                categoryName = "Inators"
            });

            _context.Category.Add(new Category
            {
                categoryID = 2, 
                categoryName = "Merch"
            });

            await _context.SaveChangesAsync();
            
            var result = await _sut.getAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<Category>>(result);
        }
    }
}
