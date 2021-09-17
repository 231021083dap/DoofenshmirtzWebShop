using DoofenshmirtzsWebShop.Controllers;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using static Xunit.Assert;

namespace DoofenshmirtzsWebShopProductTests
{
    public class ProductControllerTests
    {
        private readonly ProductController _sut;
        private readonly Mock<IProductService> _productService = new();

        public ProductControllerTests()
        {
            _sut = new ProductController(_productService.Object);
        }

        [Fact]
        public async void ReturnStatusCode200_OK_WhenProductIsFound()
        {
            List<ProductResponse> product = new();
            product.Add(new ProductResponse
            {
                ID = 1,
                name = "I-Don't-Care-Inator",
                description = "Tired of listening to meaningless things all the time? try blasting them with this gun and you'll never have to hear them again!",
                stock = 50,
                price = 449,
                categoryId = 1
            });
            product.Add(new ProductResponse
            {
                ID = 2,
                name = "Evil 101",
                description = "Dr. Heinz Doofenshmirtz' no. 1 guide to everything you need to know about being evil!",
                stock = 445,
                price = 20,
                categoryId = 2
            });
            product.Add(new ProductResponse
            {
                ID = 3,
                name = "i-heart-Doofenshmirtz",
                description = "Support your local evil branch with this T-shirt!",
                stock = 231,
                price = 60,
                categoryId = 3
            });
            _productService.Setup(s => s.getAllProducts()).ReturnsAsync(product);

            var result = await _sut.getAllProducts();
            var statusCodeResult = (IStatusCodeActionResult)result;
            Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void ReturnStatusCode204_NullError_WhenNoProductsExists()
        {
            List<ProductResponse> product = new();
            _productService.Setup(s => s.getAllProducts()).ReturnsAsync(product);

            var result = await _sut.getAllProducts();
            var statusCoseResult = (IStatusCodeActionResult)result;
            Equal(204, statusCoseResult.StatusCode);
        }

        [Fact]
        public async void ReturnStatusCode404_NotFound_WhenNoProductsFound()
        {
            int Id = 1;
            _productService.Setup(s => s.getProductById(It.IsAny<int>())).ReturnsAsync(() => null);
            var result = await _sut.getProductById(Id);
            var StatudCodeResult = (IStatusCodeActionResult)result;
            Equal(404, StatudCodeResult.StatusCode);
        }

        [Fact]
        public async void ReturnStatusCode500_InternalServerError_WhenServerWantsToSayFuckYou()
        {
            _productService.Setup(s => s.getAllProducts()).ReturnsAsync(() => throw new Exception("REEEEEEEE"));

            var result = await _sut.getAllProducts();
            var statusCoseResult = (IStatusCodeActionResult)result;
            Equal(500, statusCoseResult.StatusCode);
        }
    }
}
