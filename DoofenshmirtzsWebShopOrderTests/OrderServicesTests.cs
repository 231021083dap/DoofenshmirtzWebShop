using DoofenshmirtzsWebShop.Database.Entities;
using DoofenshmirtzsWebShop.DTOs.Requests;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Repositories;
using DoofenshmirtzsWebShop.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DoofenshmirtzsWebShopOrderTests
{
    public class OrderServicesTests
    {
        private readonly OrderServices _sut;
        private readonly Mock<IOrderRepository> _orderRepository = new();
        private readonly Mock<IOrderItemRepository> _orderItemRepository = new();
        private readonly Mock<IProductRepository> _productRepository = new();
        private readonly Mock<IUserRepository> _userRepository = new();

        public OrderServicesTests()
        {
            _sut = new OrderServices(_orderRepository.Object, _userRepository.Object, _productRepository.Object, _orderItemRepository.Object);
        }
        [Fact]
        public async void GetAll_ShouldReturnListOfOrders_WhenOrdersExists()
        {
            //Arrange
            List<Order> orders = new();
            orders.Add(new Order
            {
                orderID = 1,
                orderDate = DateTime.Parse("2021-9-25 12:23:21"),
                User = new User
                {
                    userID = 1,
                    userEmail = "doofen@evil.com",
                    userPassword = "DamnYouPerry",
                    userName = "EvilMaster"
                }
            });
            orders.Add(new Order
            {
                orderID = 2,
                orderDate = DateTime.Parse("2021-9-25 12:23:21"),
                User = new User
                {
                    userID = 2,
                    userEmail = "doofeasdn@evil.com",
                    userPassword = "DamnasdYouPerry",
                    userName = "EvilMasdaster"
                }
            });
            _orderRepository.Setup(o => o.GetAll()).ReturnsAsync(orders);
            // Act
            var result = await _sut.GetAllOrders();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<OrderResponse>>(result);
        }
        [Fact]
        public async void GetAll_ShouldReturnEmptyListOfOrderResponses_WhenNoOrdersExist()
        {
            // arrange
            List<Order> orders = new();
            _orderRepository
                .Setup(a => a.GetAll())
                .ReturnsAsync(orders);
            //act
            var result = await _sut.GetAllOrders();
            //Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<OrderResponse>>(result);
        }
        [Fact]
        public async void Create_ShouldReturnOrderResponse_WHenCreateIsSuccesful()
        {
            List<CartItemsRequest> cartItems = new();
            cartItems.Add(new CartItemsRequest
            {
                amount = 1,
                price = 2,
                productName = "ting",
                ProductID = 1
            });
            cartItems.Add(new CartItemsRequest
            {
                amount = 51,
                price = 22,
                productName = "ting2",
                ProductID = 2
            });
            NewOrder newOrder = new NewOrder
            {
                userID = 2,
                cartItems = cartItems
            };
            int orderId = 1;
            OrderItem orderItem = new OrderItem
            {
                orderID = orderId,
                orderItemQuantity = 100,
                orderItemPrice = 100,
                productID = 2,
                orderItemID = 1
            };
            Order order = new Order
            {
                orderID = orderId,
                orderDate = DateTime.Parse("2021-9-25 12:23:21"),
                userID = 2
            };
            List<Address> addresses = new();
            addresses.Add(new Address
            {
                addressID = 1,
                addressCountryName = "Danmark",
                addressCustomerName = "jeppe",
                addressPostalCode = 2300,
                addressStreetName = "Ejler billes alle",
                userID = 2
            });
            User user = new User
            {
                userID = 2,
                userEmail = "asd",
                userName = "asd",
                userPassword = "Aasd",
                userRole = DoofenshmirtzsWebShop.Helpers.Role.User,
                address = addresses
            };
            Product product = new Product
            {
                productID = 1,
                productName = "da",
                productPrice = 222,
                productStock = 1,
            };

            _orderRepository
                .Setup(s => s.Create(It.IsAny<Order>()))
                .ReturnsAsync(order);
            _orderItemRepository.Setup(s => s.Create(It.IsAny<OrderItem>()))
                .ReturnsAsync(orderItem);
            _userRepository.Setup(s => s.getByID(It.IsAny<int>()))
                .ReturnsAsync(user);
            _productRepository.Setup(s => s.getProductById(It.IsAny<int>()))
                .ReturnsAsync(product);
            // ACt
            var result = await _sut.Create(newOrder);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<OrderResponse>(result);
            Assert.Equal(orderId, result.ID);
            Assert.True(result.date > DateTime.MinValue);
            Assert.Equal(newOrder.userID, result.User.ID);
            Assert.Equal(cartItems.Count, result.OrderItems.Count);
        }




        [Fact]
        public async void getByID_ShouldReturnOrderResponse_WhenOrderExists()
        {
            int orderId = 1;
            Order order = new Order
            {
                orderID = orderId,
                orderDate = DateTime.Parse("2021-9-25 12:23:21"),
                User = new User
                {
                    userID = 1,
                    userEmail = "test@gmail.com",
                    userPassword = "asndølasd",
                    userName = "Jabby",
                    userRole = DoofenshmirtzsWebShop.Helpers.Role.User
                },
                

            };
            _orderRepository.Setup(a => a.GetById(It.IsAny<int>())).ReturnsAsync(order);
            // Act
            var result = await _sut.GetById(orderId);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<OrderResponse>(result);
            Assert.Equal(order.orderID, result.ID);
            Assert.Equal(order.orderDate, result.date);
            Assert.Equal(order.userID, result.User.ID);
        }
        [Fact]
        public async void GetById_ShouldReturnNull_WhenAuthorDoesNotExists()
        {
            // arrange
            int orderId = 1;

            _orderRepository
                .Setup(a => a.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            var result = await _sut.GetById(orderId);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async void Update_shouldReturnNull_WhenOrderDoesNotExists()
        {
            UpdateOrder updateOrder = new UpdateOrder
            {
                orderDate = DateTime.Parse("2021-9-25 12:23:21"),
                userID = 2,
            };
            int orderId = 1;

            _orderRepository
                .Setup(a => a.Update(It.IsAny<int>(), It.IsAny<Order>()))
                .ReturnsAsync(() => null);

            // Act
            var result = await _sut.Update(orderId, updateOrder);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async void Delete_ShouldReturnTrue_WhenDeleteIsSuccessful()
        {
            // Arrange
            int orderId = 1;
            Order order = new Order
            {
                orderID = orderId,
                orderDate = DateTime.Parse("2021-9-21 12:23:21"),
                User = new User
                {
                    userID = 2,
                    userEmail = "doofeasdn@evil.com",
                    userPassword = "DamnasdYouPerry",
                    userName = "EvilMasdaster"
                }
            };
            _orderRepository
            .Setup(a => a.Delete(orderId))
            .ReturnsAsync(order);
            // Act
            var result = await _sut.Delete(orderId);

            //Assert
            Assert.True(result);

        }
    }
}
