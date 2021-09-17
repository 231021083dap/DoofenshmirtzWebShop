using DoofenshmirtzsWebShop.Controllers;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace DoofenshmirtzsWebshopCategoryTests
{
    public class CategoryControllerTests
    {
        private readonly CategoryController _sut;
        private readonly Mock<ICategoryService> _categoryService = new();

        public CategoryControllerTests()
        {
            _sut = new CategoryController(_categoryService.Object);
        }

        [Fact]
        public async void getAll_shouldReturnStatusCode200_whenDataExists()
        {
            List<CategoryResponse> categories = new();

            categories.Add(new CategoryResponse
            {
                ID = 1,
                name = "Products"
            });

            categories.Add(new CategoryResponse
            {
                ID = 2,
                name = "Books"
            });

            categories.Add(new CategoryResponse
            {
                ID = 3,
                name = "Merch"
            });

            _categoryService
                .Setup(s => s.getAllCategories())
                .ReturnsAsync(categories);

            var result = await _sut.getAll();

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void getAll_shouldReturnStatusCode204_whenNoDataExists()
        {
            List<CategoryResponse> categories = new();

            _categoryService.Setup(s => s.getAllCategories())
                .ReturnsAsync(categories);

            var result = await _sut.getAll();

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void getAll_shouldReturnStatusCode500_whenNullIsReturnedFromService()
        {
            List<CategoryResponse> categories = new();

            _categoryService.Setup(s => s.getAllCategories())
                .ReturnsAsync(() => null);

            var result = await _sut.getAll();

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        
        [Fact]
        public async void getAll_shouldReturnStatusCode500_whenExceptionIsRaised()
        {

            _categoryService.Setup(s => s.getAllCategories())
                .ReturnsAsync(() => throw new System.Exception("This is an exception"));

            var result = await _sut.getAll();

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void getByID_shouldReturnStatusCode404_whenCategoryDoesNotExist()
        {
            int categoryID = 1;
            _categoryService.Setup(s => s.getByID(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            var result = await _sut.getByID(categoryID);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
    }
}
