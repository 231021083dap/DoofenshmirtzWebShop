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
        [Fact]
        public async Task getAll_shouldReturnEmptyListOfCategories_whenNoCategoriesExists()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.SaveChangesAsync();

            var result = await _sut.getAll();

            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<Category>>(result);
        }

        [Fact]
        public async Task create_shouldAddIDToCategory_whenSavingToDatabase()
        {
            await _context.Database.EnsureDeletedAsync();
            int expectedID = 1;
            Category category = new Category
            {
                categoryName = "Inators"
            };

            var result = await _sut.create(category);

            Assert.NotNull(result);
            Assert.IsType<Category>(result);
            Assert.Equal(expectedID, result.categoryID);
        }

        [Fact]
        public async Task getByID_shouldReturnTheCategory_ifCategoryExists()
        {
            await _context.Database.EnsureDeletedAsync();
            int categoryID = 1;
            _context.Category.Add(new Category
            {
                categoryID = categoryID, 
                categoryName = "Inators"
            });

            await _context.SaveChangesAsync();

            var result = await _sut.getByID(categoryID);

            Assert.NotNull(result);
            Assert.IsType<Category>(result);
            Assert.Equal(categoryID, result.categoryID);
        }

        [Fact]
        public async Task getByID_shouldReturnNull_ifCategoryDoesNotExist()
        {
            await _context.Database.EnsureDeletedAsync();
            int categoryID = 1;

            var result = await _sut.getByID(categoryID);

            Assert.Null(result);
        }

        [Fact]
        public async Task create_shouldFailToAddCategory_whenAddingCategoryWithExistingID()
        {
            await _context.Database.EnsureDeletedAsync();

            Category category = new Category
            {
                categoryID = 1, 
                categoryName = "Inators"
            };

            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            Func<Task> action = async () => await _sut.create(category);

            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }

        [Fact]
        public async Task update_shouldChangeValuesOnCategory_whenCategoryExists()
        {
            await _context.Database.EnsureDeletedAsync();
            int categoryID = 1;
            Category category = new Category
            {
                categoryID = categoryID,
                categoryName = "Inators"
            };
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            Category updateCategory = new Category
            {
                categoryID = categoryID,
                categoryName = "Merch"
            };

            var result = await _sut.update(categoryID, updateCategory);

            Assert.NotNull(result);
            Assert.IsType<Category>(result);
            Assert.Equal(categoryID, result.categoryID);
            Assert.Equal(updateCategory.categoryName, result.categoryName);
        }

        [Fact]
        public async Task update_shouldReturnNull_whenCategoryDoesNotExist()
        {
            await _context.Database.EnsureDeletedAsync();
            int categoryID = 1;
            Category updateCategory = new Category
            {
                categoryID = categoryID,
                categoryName = "Inators"
            };

            var result = await _sut.update(categoryID, updateCategory);

            Assert.Null(result);
        }

        [Fact]
        public async Task delete_shouldReturnDeletedCategory_whenCatagoryIsDeleted()
        {
            await _context.Database.EnsureDeletedAsync();

            int categoryID = 1;
            Category category = new Category
            {
                categoryID = categoryID,
                categoryName = "Inators"
            };
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            var result = await _sut.delete(categoryID);
            var categories = await _sut.getAll();

            Assert.NotNull(result);
            Assert.IsType<Category>(result);
            Assert.Equal(categoryID, result.categoryID);
            Assert.Empty(categories);
        }

        [Fact]
        public async Task delete_shouldReturnNull_whenCategoryDoesNotExist()
        {
            await _context.Database.EnsureDeletedAsync();
            int categoryID = 1;

            var result = await _sut.delete(categoryID);

            Assert.Null(result);
        }
    }
}
