using DoofenshmirtzsWebShop.Database.Entities;
using DoofenshmirtzsWebShop.DTOs.Requests;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Services
{
    public interface IProductService
    {
        Task<List<ProductResponse>> getAllProducts();
        Task<ProductResponse> getProductById(int productId);
        Task<ProductResponse> newProduct(NewProduct product);
        Task<ProductResponse> updateProduct(int productiId, UpdateProduct product);
        Task<bool> deleteProduct(int productId);
    }
    public class ProductServices : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductResponse>> getAllProducts()
        {
            List<Product> products = await _productRepository.getAllProducts();
            return products == null ? null : products.Select(a => new ProductResponse
            {
                ID = a.productID,
                name = a.productName,
                description = a.productDescription,
                stock = a.productStock,
                price = a.productPrice,
                categoryId = a.categoryID,
                category = new ProductCategoryResponse
                {
                    joinCategoryId = a.Category.categoryID,
                    categoryName = a.Category.categoryName
                },
                imageGallery = a.ImageList.Select(b => new ProductProductImageResponse
                {
                    ID = b.productImageID,
                    image = b.productImageImage
                }).ToList()
            }).ToList();
        }
        public async Task<ProductResponse> getProductById(int productId)
        {
            Product product = await _productRepository.getProductById(productId);
            return product == null ? null : new ProductResponse
            {
                ID = product.productID,
                name = product.productName,
                description = product.productDescription,
                stock = product.productStock,
                price = product.productPrice,
                categoryId = product.categoryID,
                category = new ProductCategoryResponse
                {
                    joinCategoryId = product.Category.categoryID,
                    categoryName = product.Category.categoryName
                },
                imageGallery = product.ImageList.Select(b => new ProductProductImageResponse
                {
                    ID = b.productImageID,
                    image = b.productImageImage
                }).ToList()
            };
        }
        public async Task<ProductResponse> newProduct(NewProduct newProduct)
        {
            Product product = new Product
            {
                productName = newProduct.name,
                productDescription = newProduct.description,
                productStock = newProduct.stock,
                productPrice = newProduct.price,
                categoryID = newProduct.categoryId
            };
            product = await _productRepository.newProduct(product);

            return product == null ? null : new ProductResponse
            {
                ID = product.productID,
                name = product.productName,
                description = product.productDescription,
                stock = product.productStock,
                price = product.productPrice,
                categoryId = product.categoryID
            };
        }
        public async Task<ProductResponse> updateProduct(int productId, UpdateProduct updateProduct)
        {
            Product product = new Product
            {
                productName = updateProduct.name,
                productDescription = updateProduct.description,
                productStock = updateProduct.stock,
                productPrice = updateProduct.price,
                categoryID = updateProduct.categoryId
            };
            product = await _productRepository.updateProduct(productId, product);

            return product == null ? null : new ProductResponse
            {
                ID = product.productID,
                name = product.productName,
                description = product.productDescription,
                stock = product.productStock,
                price = product.productPrice,
                categoryId = product.categoryID
            };
        }
        public async Task<bool> deleteProduct(int productId)
        {
            var result = await _productRepository.deleteProduct(productId);
            return true;
        }
        
    }
}
