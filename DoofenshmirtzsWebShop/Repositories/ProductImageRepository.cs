using DoofenshmirtzsWebShop.Database;
using DoofenshmirtzsWebShop.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Repositories
{
    public interface IProductImageRepository
    {
        /*
        Task<ProductImage> create(ProductImage productImage);
        Task<ProductImage> delete(int productImageID);*/
    }

    public class ProductImageRepository // : IProductImageRepository
    {
        /*
        private readonly DoofenshmirtzWebShopContext _context;
        public ProductImageRepository(DoofenshmirtzWebShopContext context)
        {
            _context = context;
        }       
        
        public async Task<ProductImage> create(ProductImage productImage)
        {
            _context.ProductImage.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage;
        }

        public async Task<ProductImage> delete(int productImageID)
        {
            ProductImage productImage = _context.ProductImage.FirstOrDefault(p => p.productImageID == productImageID);
            if(productImage != null)
            {
                _context.ProductImage.Remove(productImage);
                await _context.SaveChangesAsync();
            }
            return productImage;
        }*/
    }
}
