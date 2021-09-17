using DoofenshmirtzsWebShop.Database.Entities;
using DoofenshmirtzsWebShop.DTOs.Requests;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Repositories;
using DoofenshmirtzsWebShop.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DoofenshmirtzsWebshopCategoryTests
{
    public class CategoryServiceTests
    {
        private readonly CategoryServices _sut;
        private readonly Mock<ICategoryRepository> _categoryRepository = new();

        public CategoryServiceTests()
        {
            _sut = new CategoryServices(_categoryRepository.Object);
        }

        [Fact]
        public async void getAll_shouldReturnListOfCategoryResponses_whenCategoryExists()
        {
            List<Category> categories = new();

            categories.Add(new Category
            {
                categoryID = 1, 
                categoryName = "Inators"
            });

            categories.Add(new Category
            {
                categoryID = 2,
                categoryName = "Merch"
            });

            _categoryRepository.Setup(c => c.getAll())
                .ReturnsAsync(categories);

            var result = await _sut.getAllCategories();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<CategoryResponse>>(result);
        }

        [Fact]
        public async void create_shouldReturnCategoryResponse_whenCreateIsSuccess()
        {
            int categoryID = 1;
            NewCategory newCategory = new NewCategory
            {
                categoryName = "Inators"
            };

            Category category = new Category
            {
                categoryID = categoryID, 
                categoryName = "Inators"
            };

            _categoryRepository.Setup(c => c.create(It.IsAny<Category>()))
                .ReturnsAsync(category);

            var result = await _sut.create(newCategory);

            Assert.NotNull(result);
            Assert.IsType<CategoryResponse>(result);
            Assert.Equal(categoryID, result.ID);
            Assert.Equal(newCategory.categoryName, result.name);
        }


    }
}
