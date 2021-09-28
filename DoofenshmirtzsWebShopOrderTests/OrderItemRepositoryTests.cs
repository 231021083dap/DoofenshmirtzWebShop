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
    public class OrderItemRepositoryTests
    {
        private readonly OrderItemRepository _sut;
        private readonly DoofenshmirtzWebShopContext _context;
        private readonly DbContextOptions<DoofenshmirtzWebShopContext> _options;
        public OrderItemRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DoofenshmirtzWebShopContext>().UseInMemoryDatabase(databaseName: "Doof").Options;
            _context = new DoofenshmirtzWebShopContext(_options);
            _sut = new OrderItemRepository(_context);
        }
        [Fact]
        public async Task GetAll_ShouldReturnListOfOrderItems_WhenOrderItemsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            _context.Order.Add(new Order
            {
                orderID = 2,
                orderDate = DateTime.Now,
                userID = 2
            });
            await _context.SaveChangesAsync();
            _context.Product.Add(new Product
            {
                productID = 1,
                productName = "I-Don't-Care-Inator",
                productDescription = "Tired of listening to meaningless things all the time? try blasting them with this gun and you'll never have to hear them again!",
                productStock = 50,
                productPrice = 449,
                categoryID = 1
            });
            await _context.SaveChangesAsync();
            _context.Category.Add(new Category
            {
                categoryID = 1,
                categoryName = "blabla"
            });

            await _context.SaveChangesAsync();
            _context.OrderItem.Add(new OrderItem
            {
                orderItemID = 1,
                orderItemQuantity = 24,
                orderItemPrice = 22,
                orderID = 2,
                productID = 1

            });
            _context.OrderItem.Add(new OrderItem
            {
                orderItemID = 2,
                orderItemQuantity = 24,
                orderItemPrice = 22,
                orderID = 2,
                productID = 1

            });
            await _context.SaveChangesAsync();
            // act
            var result = await _sut.GetAll();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<OrderItem>>(result);

        }
        [Fact]
        public async Task GetById_ShouldReturnOrder_IfOrderExists()
        {
            await _context.Database.EnsureDeletedAsync();


            int orderItemId = 1;
            _context.Order.Add(new Order
            {
                orderID = 2,
                orderDate = DateTime.Now,
                userID = 2
            });
            await _context.SaveChangesAsync();
            _context.Product.Add(new Product
            {
                productID = 1,
                productName = "I-Don't-Care-Inator",
                productDescription = "Tired of listening to meaningless things all the time? try blasting them with this gun and you'll never have to hear them again!",
                productStock = 50,
                productPrice = 449,
                categoryID = 1
            });
            await _context.SaveChangesAsync();
            _context.Category.Add(new Category
            {
                categoryID = 1,
                categoryName = "blabla"
            });

            await _context.SaveChangesAsync();
            _context.OrderItem.Add(new OrderItem
            {
                orderItemID = orderItemId,
                orderItemQuantity = 24,
                orderItemPrice = 22,
                orderID = 2,
                productID = 1

            });
            await _context.SaveChangesAsync();
            // Act
            var result = await _sut.GetById(orderItemId);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<OrderItem>(result);
            Assert.Equal(orderItemId, result.orderItemID);
        }
        [Fact]
        public async Task GetById_ShouldReturnNull_IfOrderDoesNotExists()
        {
            // arrange
            await _context.Database.EnsureDeletedAsync();
            int orderItemId = 1;
            // act
            var result = await _sut.GetById(orderItemId);
            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task Create_ShouldAddIdToOrder_WhenSavingToDatabase()
        {
            await _context.Database.EnsureDeletedAsync(); 
            _context.Order.Add(new Order
            {
                orderID = 2,
                orderDate = DateTime.Now,
                userID = 2
            });
            await _context.SaveChangesAsync();
            _context.Product.Add(new Product
            {
                productID = 1,
                productName = "I-Don't-Care-Inator",
                productDescription = "Tired of listening to meaningless things all the time? try blasting them with this gun and you'll never have to hear them again!",
                productStock = 50,
                productPrice = 449,
                categoryID = 1
            });
            await _context.SaveChangesAsync();
            _context.Category.Add(new Category
            {
                categoryID = 1,
                categoryName = "blabla"
            });

            await _context.SaveChangesAsync();
            OrderItem orderItem = new OrderItem
            {
                orderItemQuantity = 24,
                orderItemPrice = 22,
                orderID = 2,
                productID = 1,
            };
            //_context.OrderItem.Add(orderItem);
            await _context.SaveChangesAsync();
            int ExpectedId = 1;
            // Act
            var result = await _sut.Create(orderItem);
            Assert.NotNull(result);
            Assert.IsType<OrderItem>(result);
            Assert.Equal(ExpectedId, result.orderItemID);

        }
        [Fact]
        public async Task Create_ShouldFailToAddOrder_WhenAddingOrderWithExistingId()
        {
            await _context.Database.EnsureDeletedAsync();
            _context.Order.Add(new Order
            {
                orderID = 2,
                orderDate = DateTime.Now,
                userID = 2
            });
            await _context.SaveChangesAsync();
            _context.Product.Add(new Product
            {
                productID = 1,
                productName = "I-Don't-Care-Inator",
                productDescription = "Tired of listening to meaningless things all the time? try blasting them with this gun and you'll never have to hear them again!",
                productStock = 50,
                productPrice = 449,
                categoryID = 1
            });
            await _context.SaveChangesAsync();
            _context.Category.Add(new Category
            {
                categoryID = 1,
                categoryName = "blabla"
            });

            await _context.SaveChangesAsync();
            OrderItem orderItem = new OrderItem
            {
                orderItemID = 5,
                orderItemQuantity = 24,
                orderItemPrice = 22,
                orderID = 2,
                productID = 1

            };
            _context.OrderItem.Add(orderItem);
            await _context.SaveChangesAsync();
            // ACt
            Func<Task> action = async () => await _sut.Create(orderItem);
            // Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }
        [Fact]
        public async Task Update_ShouldChangeValuesOnOrder_WhenOrderExists()
        {
            await _context.Database.EnsureDeletedAsync();
            _context.Order.Add(new Order
            {
                orderID = 2,
                orderDate = DateTime.Now,
                userID = 2
            });
            await _context.SaveChangesAsync();
            _context.Product.Add(new Product
            {
                productID = 1,
                productName = "I-Don't-Care-Inator",
                productDescription = "Tired of listening to meaningless things all the time? try blasting them with this gun and you'll never have to hear them again!",
                productStock = 50,
                productPrice = 449,
                categoryID = 1
            });
            await _context.SaveChangesAsync();
            _context.Category.Add(new Category
            {
                categoryID = 1,
                categoryName = "blabla"
            });
            await _context.SaveChangesAsync();
            int orderItemId = 1;
            OrderItem orderItem = new OrderItem
            {
                orderItemID = orderItemId,
                orderItemQuantity = 24,
                orderItemPrice = 22,
                orderID = 2,
                productID = 1

            };
            _context.OrderItem.Add(orderItem);
            await _context.SaveChangesAsync();
            OrderItem updateOrderItem = new OrderItem
            {
                orderItemID = 1,
                orderItemQuantity = 100,
                orderItemPrice = 100,
                orderID = 2,
                productID = 1
            };
            // Act
            var result = await _sut.Update(orderItemId, updateOrderItem);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<OrderItem>(result);
            Assert.Equal(orderItemId, result.orderItemID);
            Assert.Equal(updateOrderItem.orderItemQuantity, result.orderItemQuantity);
            Assert.Equal(updateOrderItem.orderItemPrice, result.orderItemPrice);
            Assert.Equal(updateOrderItem.orderID, result.orderID);
            Assert.Equal(updateOrderItem.productID, result.productID);
        }
        [Fact]
        public async Task Update_ShouldReturnNull_WhenOrderItemDoesNotExists()
        {
            // Arrange
           await _context.Database.EnsureDeletedAsync();
           await _context.SaveChangesAsync();
            int orderItemId = 1;
            OrderItem updateOrderItem = new()
            {
                orderItemID = orderItemId,
                orderItemQuantity = 24,
                orderItemPrice = 22,
                orderID = 2,
                productID = 1
            };
            //act
            var result = await _sut.Update(orderItemId, updateOrderItem);
            // Assert
            Assert.Null(result);

        }
        [Fact]
        public async Task Delete_ShouldReturnDeletedOrder_WhenOrderIsDeleted()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            int orderItemId = 1;
            OrderItem orderItem = new()
            {
                orderItemID = orderItemId,
                orderItemQuantity = 24,
                orderItemPrice = 22,
                orderID = 2,
                productID = 1
            };
            _context.OrderItem.Add(orderItem);
            await _context.SaveChangesAsync();
            //Act
            var result = await _sut.Delete(orderItemId);
            var orderItems = await _sut.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OrderItem>(result);
            Assert.Equal(orderItemId, result.orderItemID);
            Assert.Empty(orderItems);
        }
        [Fact]
        public async Task Delete_ShouldReturnNull_WhenOrderItemsDoesNotExists()
        {
            await _context.Database.EnsureDeletedAsync();
            int orderItemId = 1;
            //Act
            var result = await _sut.Delete(orderItemId);
            //Assert
            Assert.Null(result);
        }

    }

}
