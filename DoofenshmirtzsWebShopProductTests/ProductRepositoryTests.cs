using DoofenshmirtzsWebShop.Controllers;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Services;
using DoofenshmirtzsWebShop.Database.Entities;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using static Xunit.Assert;
using DoofenshmirtzsWebShop.Database;
using DoofenshmirtzsWebShop.Repositories;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShopProductTests
{
    public class ProductRepositoryTests
    {
        private DbContextOptions<DoofenshmirtzWebShopContext> _options;
        private readonly DoofenshmirtzWebShopContext _context;
        private readonly ProductRepository _sut;

        public ProductRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DoofenshmirtzWebShopContext>()
                .UseInMemoryDatabase(databaseName: "DoofenshmirtzWebShopProducts")
                .Options;
            _context = new DoofenshmirtzWebShopContext(_options);
            _sut = new ProductRepository(_context);
        }

        [Fact]
        public async Task return_ListOfProducts_WhenProductsAreFound()
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
                categoryName = "Books"
            });
            _context.Category.Add(new Category
            {
                categoryID = 3,
                categoryName = "Merchandise"
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
            _context.Product.Add(new Product {
                productID = 2,
                productName = "Evil 101",
                productDescription = "Dr. Heinz Doofenshmirtz' no. 1 guide to everything you need to know about being evil!",
                productStock = 445,
                productPrice = 20,
                categoryID = 2
            });
            _context.Product.Add(new Product
            {
                productID = 3,
                productName = "i-heart-Doofenshmirtz",
                productDescription = "Support your local evil branch with this T-shirt!",
                productStock = 231,
                productPrice = 60,
                categoryID = 3
            });
            await _context.SaveChangesAsync();
            var result = await _sut.getAllProducts();
            NotNull(result);
            IsType<List<Product>>(result);
            Equal(3, result.Count);
        }

        [Fact]
        public async Task ReturnBookById_IfSpecificProductIsFound()
        {
            await _context.Database.EnsureDeletedAsync();
            _context.Category.Add(new Category
            {
                categoryID = 1,
                categoryName = "Inators"
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
            var result = await _sut.getProductById(1);
            NotNull(result);
            IsType<Product>(result);
            Equal(1, result.productID);
        }
        [Fact]
        public async Task ReturnError_Null_IfProductNotFound()
        {
            await _context.Database.EnsureDeletedAsync();
            var result = await _sut.getProductById(1);
            Null(result);
        }
        [Fact]
        public async Task ReturnNewProduct_IfNewProductIsCreated()
        {
            await _context.Database.EnsureDeletedAsync();
            Product product = new Product
            {
                productName = "I-Don't-Care-Inator",
                productDescription = "Tired of listening to meaningless things all the time? try blasting them with this gun and you'll never have to hear them again!",
                productStock = 50,
                productPrice = 449,
                categoryID = 1
            };
            var result = await _sut.newProduct(product);

            NotNull(result);
            IsType<Product>(result);
            Equal(1, result.productID);

        }
        [Fact]
        public async Task ReturnError_ProductAlreadyExists_IfAddingNewProductThatExists()
        {
            await _context.Database.EnsureDeletedAsync();
            Product product = new Product
            {
                productName = "I-Don't-Care-Inator",
                productDescription = "Tired of listening to meaningless things all the time? try blasting them with this gun and you'll never have to hear them again!",
                productStock = 50,
                productPrice = 449,
                categoryID = 1
            };
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            Func<Task> action = async () => await _sut.newProduct(product);
            var ex = await ThrowsAsync<ArgumentException>(action);
            Contains("An item with the same key has already been added", ex.Message);
        }
        [Fact]
        public async Task ReturnUpdatedProduct_IfProductIsUpdated()
        {
            await _context.Database.EnsureDeletedAsync();
            Product product = new Product
            {
                productName = "I-Don't-Care-Inator",
                productDescription = "Tired of listening to meaningless things all the time? try blasting them with this gun and you'll never have to hear them again!",
                productStock = 50,
                productPrice = 449,
                categoryID = 1
            };
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            Product updateProduct = new Product
            {
                productName = "I-Don't-Care-Inator",
                productDescription = "Tired of listening to meaningless things all the time? try blasting them with this gun and you'll never have to hear them again!",
                productStock = 60,
                productPrice = 449,
                categoryID = 1
            };
            var result = await _sut.updateProduct(1, updateProduct);
            NotNull(result);
            IsType<Product>(result);
            Equal(1, result.productID);
            Equal(updateProduct.productName, result.productName);
            Equal(updateProduct.productDescription, result.productDescription);
            Equal(updateProduct.productStock, result.productStock);
            Equal(updateProduct.productPrice, result.productPrice);
            Equal(updateProduct.categoryID, result.categoryID);
        }
        [Fact]
        public async Task Update_ReturnError_ProductNotFound_IfProductDoesntExists()
        {
            await _context.Database.EnsureDeletedAsync();
            Product updateProduct = new Product
            {
                productID = 1,
                productName = "I-Don't-Care-Inator",
                productDescription = "Tired of listening to meaningless things all the time? try blasting them with this gun and you'll never have to hear them again!",
                productStock = 50,
                productPrice = 449,
                categoryID = 1
            };
            var result = await _sut.updateProduct(1, updateProduct);
            Null(result);
        }
        [Fact]
        public async Task return_DeleteProduct_WhenDeletingProduct()
        {
            await _context.Database.EnsureDeletedAsync();
            Product product = new Product
            {
                productID = 1,
                productName = "I-Don't-Care-Inator",
                productDescription = "Tired of listening to meaningless things all the time? try blasting them with this gun and you'll never have to hear them again!",
                productStock = 50,
                productPrice = 449,
                categoryID = 1
            };
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            var result = await _sut.deleteProduct(1);
            var products = await _sut.getAllProducts();

            NotNull(result);
            IsType<Product>(result);
            Equal(1, result.productID);
            Empty(products);
        }
        [Fact]
        public async Task returnError_ProductNotFound_WhenProductDoesntExists()
        {
            await _context.Database.EnsureDeletedAsync();
            var result = await _sut.deleteProduct(1);
            Null(result);
        }
    }
}
