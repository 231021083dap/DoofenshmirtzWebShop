using DoofenshmirtzsWebShop.Database;
using DoofenshmirtzsWebShop.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DoofenshmirtzsWebShop.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> getAllProducts();
        Task<Product> getProductById(int productId);
        Task<Product> newProduct(Product product);
        Task<Product> updateProduct(int productiId, Product product);
        Task<Product> deleteProduct(int productId);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly DoofenshmirtzWebShopContext _productContext;
        public ProductRepository(DoofenshmirtzWebShopContext context)
        {
            _productContext = context;
        }

        public async Task<List<Product>> getAllProducts()
        {
            return await _productContext.Product.Include(a => a.categoryID).ToListAsync();
        }
        public async Task<Product> getProductById(int productId)
        {
            return await _productContext.Product.Include(a => a.categoryID).FirstOrDefaultAsync(a => a.productID == productId);
        }
        public async Task<Product> newProduct(Product product)
        {
            _productContext.Product.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
        public async Task<Product> updateProduct(int productId, Product product)
        {
            Product updateProduct = await _productContext.Product.FirstOrDefaultAsync(a => a.productID == productId);
            if (product != null)
            {
                updateProduct.productName = product.productName;
                updateProduct.productDescription = product.productDescription;
                updateProduct.productStock = product.productStock;
                updateProduct.productPrice = product.productPrice;
                updateProduct.categoryID = product.categoryID;
            }
            return updateProduct;
        }
        public async Task<Product> deleteProduct(int productId)
        {
            Product product = await _productContext.Product.FirstOrDefaultAsync(a => a.productID == productId);
            if (product != null)
            {
                _productContext.Product.Remove(product);
                await _productContext.SaveChangesAsync();
            }
            return product;
        }
    }
}
