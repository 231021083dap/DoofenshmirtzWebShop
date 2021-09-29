using DoofenshmirtzsWebShop.Database;
using DoofenshmirtzsWebShop.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> getAll();
        Task<Category> getByID(int categoryID);
        Task<Category> create(Category category);
        Task<Category> update(int categoryID, Category category);
        Task<Category> delete(int categoryID);
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly DoofenshmirtzWebShopContext _context;

        public CategoryRepository(DoofenshmirtzWebShopContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> getAll()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> getByID(int categoryID)
        {
            return await _context.Category.FirstOrDefaultAsync(a => a.categoryID == categoryID);
        }

        public async Task<Category> create(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> update(int categoryID, Category category)
        {
            Category updateCategory = await _context.Category.FirstOrDefaultAsync(a => a.categoryID == categoryID);
            if (updateCategory != null)
            {
                //updateCategory.categoryID = category.categoryID;
                updateCategory.categoryName = category.categoryName;
                await _context.SaveChangesAsync();
            }
            return updateCategory;
        }

        public async Task<Category> delete(int categoryID)
        {
            Category category = await _context.Category.FirstOrDefaultAsync(a => a.categoryID == categoryID);
            if (category != null)
            {
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
            }
            return category;
        }
    }
}
