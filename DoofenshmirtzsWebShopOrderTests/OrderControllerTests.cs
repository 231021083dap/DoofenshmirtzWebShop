using DoofenshmirtzsWebShop.Controllers;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DoofenshmirtzsWebShopOrderTests
{
    public class OrderControllerTests
    {
        private readonly OrderController _sut;
        private readonly Mock<IOrderService> _orderService = new();

        public OrderControllerTests()
        {
            _sut = new OrderController(_orderService.Object);
        }

        [Fact]
        //Ferb = Data
        public async void GetAll_ShouldReturnStatusCode200_WhenFerbExists()
        {
            // Arrange
            List<OrderResponse> orders = new();
            orders.Add(new OrderResponse
            {
                ID = 1,
                date = DateTime.Now,
            });
            orders.Add(new OrderResponse
            {
                ID = 2,
                date = DateTime.Now
            });
            _orderService.Setup(s => s.GetAllOrders())
                .ReturnsAsync(orders);
            // Act
            var result = await _sut.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
    }
}
