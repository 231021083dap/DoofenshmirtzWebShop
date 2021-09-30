using DoofenshmirtzsWebShop.Repositories;
using DoofenshmirtzsWebShop.Services;
using Moq;
using System.Collections.Generic;
using Xunit;
using static Xunit.Assert;
using static Moq.It;
using DoofenshmirtzsWebShop.Database.Entities;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.DTOs.Requests;

namespace DoofenshmirtzsWebShopProductTests
{
    public class ProductServicesTests
    {
        public readonly ProductServices _sut;
        public readonly Mock<IProductRepository> _productRepository = new();

        public ProductServicesTests() => _sut = new ProductServices(_productRepository.Object);

        [Fact]
        public async void return_ListOfProducts_whenProductsAreFound()
        {
            Category category = new Category
            {
                categoryID = 1,
                categoryName = "Inators"
            };
            List<Product> product = new List<Product>();
            product.Add(new Product
            {
                productID = 1,
                productName = "I-Don't-Care-Inator",
                productDescription = "Description :*)",
                productStock = 200,
                productPrice = 299,
                categoryID = 1,
                Category = category
            });
            product.Add(new Product
            {
                productID = 2,
                productName = "Kill-Half-The-Population-In-The-World-With-A-Snap-Inator",
                productDescription = "Description lol",
                productStock = 200,
                productPrice = 299,
                categoryID = 1,
                Category = category
            });
            _productRepository.Setup(a => a.getAllProducts()).ReturnsAsync(product);
            var result = await _sut.getAllProducts();
            NotNull(result);
            Equal(2, result.Count);
            IsType<List<ProductResponse>>(result);
        }

        [Fact]
        public async void returnError_NotFound_WhenListIsEmpty()
        {
            List<Product> products = new List<Product>();
            _productRepository.Setup(a => a.getAllProducts()).ReturnsAsync(products);
            var result = await _sut.getAllProducts();
            NotNull(result);
            Empty(result);
            IsType<List<ProductResponse>>(result);
        }
        [Fact]
        public async void returnBookById_WhenBookIsFound()
        {
            Category category = new Category
            {
                categoryID = 1,
                categoryName = "Inators"
            };
            Product product = new Product
            {
                productID = 1,
                productName = "I-Don't-Care-Inator",
                productDescription = "Description :*)",
                productStock = 200,
                productPrice = 299,
                categoryID = 1,
                Category = category
            };
            _productRepository.Setup(a => a.getProductById(IsAny<int>())).ReturnsAsync(product);
            var result = await _sut.getProductById(1);
            NotNull(result);
            IsType<ProductResponse>(result);
            Equal(product.productID, result.ID);
            Equal(product.productName, result.name);
            Equal(product.productDescription, result.description);
            Equal(product.productStock, result.stock);
            Equal(product.productPrice, result.price);
            Equal(product.categoryID, result.categoryId);
        }
        [Fact]
        public async void returnError_NotFound_WhenNoProductFound()
        {
            _productRepository.Setup(a => a.getProductById(IsAny<int>())).ReturnsAsync(() => null);
            var result = await _sut.getProductById(1);
            Null(result);
        }
        [Fact]
        public async void returnNew_WhenNewProductIsCreated()
        {
            NewProduct newProduct = new NewProduct
            {
                productName = "Stop-Slacking-Off-And-Get-To-Work-Inator",
                productDescription = "the perfect gift for lazy people.",
                productStock = 400,
                productPrice = 7999,
                categoryID = 1
            };
            Product product = new Product
            {
                productID = 1,
                productName = "Stop-Slacking-Off-And-Get-To-Work-Inator",
                productDescription = "the perfect gift for lazy people.",
                productStock = 400,
                productPrice = 7999,
                categoryID = 1
            };
            _productRepository.Setup(a => a.newProduct(IsAny<Product>())).ReturnsAsync(product);
            var result = await _sut.newProduct(newProduct);
            NotNull(result);
            IsType<ProductResponse>(result);
            Equal(1, result.ID);
            Equal(newProduct.productName, result.name);
            Equal(newProduct.productDescription, result.description);
            Equal(newProduct.productStock, result.stock);
            Equal(newProduct.productPrice, result.price);
            Equal(newProduct.categoryID, result.categoryId);
        }
        [Fact]
        public async void returnUpdate_WhenProductIsUpdated()
        {
            UpdateProduct updateProduct = new UpdateProduct
            {
                name = "Steal-Your-Meme-Inator",
                description = "Steal your friends memes in the name of Evil!",
                stock = 200,
                price = 6969,
                categoryId = 1
            };
            Product product = new Product
            {
                productID = 1,
                productName = "Steal-Your-Meme-Inator",
                productDescription = "Steal your friends memes in the name of Evil!",
                productStock = 200,
                productPrice = 6969,
                categoryID = 1
            };
            _productRepository.Setup(a => a.updateProduct(IsAny<int>(), IsAny<Product>())).ReturnsAsync(product);
            var result = await _sut.updateProduct(1, updateProduct);
            NotNull(result);
            IsType<ProductResponse>(result);
            Equal(updateProduct.name, result.name);
            Equal(updateProduct.description, result.description);
            Equal(updateProduct.stock, result.stock);
            Equal(updateProduct.price, result.price);
            Equal(updateProduct.categoryId, result.categoryId);
        }
        [Fact]
        public async void returnUpdateError_WhenProductNotFound() 
        {
            UpdateProduct updateProduct = new UpdateProduct
            {
                name = "Cope-Paste-Everything-you-have-already-done-inator",
                description = "Tired of wring everything again and again? Then this inator is for you!",
                stock = 200,
                price = 7000,
                categoryId = 1
            };
            _productRepository.Setup(a => a.updateProduct(IsAny<int>(), IsAny<Product>())).ReturnsAsync(() => null);
            var result = await _sut.updateProduct(1, updateProduct);
            Null(result);
        }
        [Fact]
        public async void returnDelete_WhenProductIsYeetedOutTheWindow()
        {
            Product product = new Product
            {
                productID = 1,
                productName = "Delete-This-Inator-Inator",
                productDescription = "The most useless Inator in existence",
                productStock = 1,
                productPrice = 9000000,
                categoryID = 1
            };
            _productRepository.Setup(a => a.deleteProduct(IsAny<int>())).ReturnsAsync(product);
            var result = await _sut.deleteProduct(1);
            True(result);
        }
    }
}
