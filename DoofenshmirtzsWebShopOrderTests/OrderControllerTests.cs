using DoofenshmirtzsWebShop.Controllers;
using DoofenshmirtzsWebShop.DTOs.Requests;
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
        [Fact]
        public async void GetAll_ShouldReturnStatusCode204_WhenNoDataExists()
        {
            // Arrange
            List<OrderResponse> orders = new();

            _orderService.Setup(s => s.GetAllOrders()).ReturnsAsync(orders);
            //Act
            var result = await _sut.GetAll();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);

        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenNullIsReturnedFromService()
        {
            //Arange
            List<OrderResponse> orders = new();
            _orderService.Setup(s => s.GetAllOrders()).ReturnsAsync(() => null);
            //Act
            var result = await _sut.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            List<OrderResponse> orders = new();
            _orderService.Setup(s => s.GetAllOrders()).ReturnsAsync(() => throw new Exception("This is an expcetion"));
            // Act
            var result = await _sut.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode200_WhenDataExists()
        {
            // Arrange
            int orderId = 1;
            OrderResponse order = new OrderResponse
            {
                ID = orderId,
                date = DateTime.Parse("2021-9-21 12:23:21")
            };
            _orderService.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync(order);
            // Assert
            var result = await _sut.GetById(orderId);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);

        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode404_WhenOrderDoesNotExist()
        {
            // Arrange
            int orderId = 1;
            _orderService.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync(() => null);
            // Act 
            var result = await _sut.GetById(orderId);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);

        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            _orderService.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync(() => throw new Exception("This is an Exception"));
            // Act
            var result = await _sut.GetById(1);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Create_ShouldreturnStatusCode200_WhenDataIsCreated()
        {
            // Arrange
            int orderId = 1;
            NewOrder newOrder = new NewOrder
            {
                
                userID = 2
            };
            OrderResponse order = new OrderResponse
            {
                ID = orderId,
                date = DateTime.Parse("2021-9-21 12:23:21"),
            };
            _orderService.Setup(s => s.Create(It.IsAny<NewOrder>())).ReturnsAsync(order);
            // Act
            var result = await _sut.Create(newOrder);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Create_ShouldreturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            int orderId = 1;
            NewOrder newOrder = new NewOrder
            {
                userID = 2
            };
            _orderService.Setup(s => s.Create(It.IsAny<NewOrder>())).ReturnsAsync(() => throw new Exception("This is an "));
            // Act
            var result = await _sut.Create(newOrder);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);


        }
        [Fact]
        public async void Update_ShouldReturnStatusCode200_WhenDataIsSaved()
        {
            // Arrange
            int orderId = 1;
            UpdateOrder updateOrder = new UpdateOrder
            {
                userID = 2
            };
            OrderResponse order = new OrderResponse
            {
                ID = orderId,
                date = DateTime.Parse("2021-9-21 12:23:21")

            };
            _orderService.Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateOrder>())).ReturnsAsync(order);
            // Act
            var result = await _sut.Update(orderId, updateOrder);
            // Assert 
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Update_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            int orderId = 1;
            UpdateOrder order = new UpdateOrder
            {
                userID = 2
            };
            _orderService.Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateOrder>())).ReturnsAsync(() => null);
            // Act
            var result = await _sut.Update(orderId, order);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Delete_ShouldReturnStatusCode204_WhenOrderIsDeleted()
        {
            int orderId = 1;
            _orderService.Setup(s => s.Delete(It.IsAny<int>())).ReturnsAsync(true);
            // Act
            var result = await _sut.Delete(orderId);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Delete_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            int orderId = 1;
            _orderService.Setup(s => s.Delete(It.IsAny<int>())).ReturnsAsync(() => throw new Exception("This is an exception"));
            // Act
            var result = await _sut.Delete(orderId);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
