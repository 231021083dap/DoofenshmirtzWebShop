using DoofenshmirtzsWebShop.Database;
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

            _sut = new CategoryRepository(_context);
        }

        [Fact]
        public async Task getAll_shouldReturnListOfCategories_whenCategoriesExists()
        {
            
        }
    }
}
