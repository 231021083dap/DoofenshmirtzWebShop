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

namespace DoofenshmirtzsWebShopOrderTests
{
    public class OrderRepositoryTests
    {
        private readonly OrderRepository _sut;
        private readonly DoofenshmirtzWebShopContext _context;
        private readonly DbContextOptions<DoofenshmirtzWebShopContext> _options;
        public OrderRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DoofenshmirtzWebShopContext>().UseInMemoryDatabase(databaseName: "DoofenProject").Options;
            _context = new DoofenshmirtzWebShopContext(_options);
            _sut = new OrderRepository(_context);
        }
        [Fact]
        public async Task GetAll_ShouldReturnListOfOrders_WhenOrdersExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            _context.User.Add(new User { userID = 1, userEmail = "test@mail.dk", userPassword = "qazwsx123", userName = "Peepo" });
            await _context.SaveChangesAsync();
            _context.Order.Add(new Order
            {
                orderID = 1,
                orderDate = DateTime.Now,
                userID = 1
            });
            _context.Order.Add(new Order
            {
                orderID = 2,
                orderDate = DateTime.Now,
                userID = 1
                
            });
            await _context.SaveChangesAsync();
            // Act
            var result = await _sut.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<Order>>(result);


        }
        [Fact]
        public async Task GetById_ShouldReturnTheOrder_IfOrderExists() 
        {
            // Arrange 
            await _context.Database.EnsureDeletedAsync();
            _context.User.Add(new User { userID = 1, userEmail = "test@mail.dk", userPassword = "qazwsx123", userName = "Peepo" });
            await _context.SaveChangesAsync();
            int orderId = 1;
            _context.Order.Add(new Order
            {
                orderID = orderId,
                orderDate = DateTime.Now,
                userID = 1
            });
            await _context.SaveChangesAsync();
            // Act
            var result = await _sut.GetById(orderId);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Order>(result);
            Assert.Equal(orderId, result.orderID);
        }
        [Fact]
        public async Task GetById_ShouldReturnNull_IfOrderDoesNotExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int orderId = 1;
            // Act
            var result = await _sut.GetById(orderId);
            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task Create_ShouldAddIdToOrder_WhenSavingToDatabase()
        {
            // arrange
            await _context.Database.EnsureDeletedAsync();
            _context.User.Add(new User { userID = 1, userEmail = "test@mail.dk", userPassword = "qazwsx123", userName = "Peepo" });
            await _context.SaveChangesAsync();
            int ExpectedId = 1;
            Order order = new Order
            {
                orderDate = DateTime.Now,
                userID = 1
            };
            // Act
            var result = await _sut.Create(order);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Order>(result);
            Assert.Equal(ExpectedId, result.userID);
        }
        [Fact]
        public async Task Create_ShouldFailToAddOrder_WhenAddingOrderWithExistingId()
        {
            await _context.Database.EnsureDeletedAsync();
            _context.User.Add(new User { userID = 1, userEmail = "test@mail.dk", userPassword = "qazwsx123", userName = "Peepo" });
            await _context.SaveChangesAsync();
            Order order = new Order
            {
                orderID = 5,
                orderDate = DateTime.Now,
                userID = 1
            };
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
            // Act
            Func<Task> action = async () => await _sut.Create(order);


            // Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);

        }
        [Fact]
        public async Task Update_ShouldChangeValuesOnOrder_WhenOrderExists()
        {
            // arrange
            await _context.Database.EnsureDeletedAsync();
            _context.User.Add(new User { userID = 1, userEmail = "test@mail.dk", userPassword = "qazwsx123", userName = "Peepo" });
            _context.User.Add(new User { userID = 2, userEmail = "test2@mail.dk", userPassword = "qazwsx1232", userName = "Peepo2" });
            await _context.SaveChangesAsync();
            int orderId = 1;
            Order order = new Order
            {
                orderID = orderId,
                orderDate = DateTime.Now,
                userID = 1
            };
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            Order updateOrder = new Order
            {
                orderID = orderId,
                orderDate = DateTime.Now,
                userID = 2
            };
            // Act
            var result = await _sut.Update(orderId, updateOrder);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Order>(result);
            Assert.Equal(orderId, result.orderID);
            Assert.Equal(updateOrder.orderID, result.orderID);
            Assert.Equal(updateOrder.orderDate, result.orderDate);
            Assert.Equal(updateOrder.userID, result.userID);
        }
        [Fact]
        public async Task Update_ShouldReturnNull_WhenOrderDoesNotExists()
        {
            // arrange
            await _context.Database.EnsureDeletedAsync();
            int orderId = 1;
            Order updateOrder = new()
            {
                orderID = orderId,
                orderDate = DateTime.Now,
                userID = 1
            };
            // Act
            var result = await _sut.Update(orderId, updateOrder);
            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task Delete_ShouldReturnDeletedOrder_WhenOrderIsDeleted()
        {
            await _context.Database.EnsureDeletedAsync();
            _context.User.Add(new User { userID = 1, userEmail = "test@mail.dk", userPassword = "qazwsx123", userName = "Peepo" });
            await _context.SaveChangesAsync();
            int orderId = 1;
            Order order = new()
            {
                orderID = orderId,
                orderDate = DateTime.Now,
                userID = 1
            };
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            // Act
            var result = await _sut.Delete(orderId);
            var orders = await _sut.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Order>(result);
            Assert.Equal(orderId, result.orderID);
            Assert.Empty(orders);
            
        }
        [Fact]
        public async Task Delete_ShouldReturnNull_WhenOrderDoesNotExists()
        {
            await _context.Database.EnsureDeletedAsync();
            int orderId = 1;
            //Act
            var result = await _sut.Delete(orderId);
            //Assert
            Assert.Null(result);
        }

    }
}
