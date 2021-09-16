using DoofenshmirtzsWebShop.Database;
using DoofenshmirtzsWebShop.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Repositories
{
    public interface IProductRepository
    {
        Task<Product> getAllProducts();
    }
    public class ProductRepository
    {
        private readonly DoofenshmirtzWebShopContext _productContext;
        public ProductRepository(DoofenshmirtzWebShopContext context)
        {
            _productContext = context;
        }

        public async Task<List<Product>> getAllProducts()
        {
            return await _productContext
        }
    }
}
