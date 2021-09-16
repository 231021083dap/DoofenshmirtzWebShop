using DoofenshmirtzsWebShop.Database;
using DoofenshmirtzsWebShop.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> getAll();
    }

    public class CategoryRepository
    {
        private readonly DoofenshmirtzWebShopContext _context;

        public CategoryRepository(DoofenshmirtzWebShopContext context)
        {
            _context = context;
        }

        public Task<List<Category>> getAll()
        {
            throw new ArgumentException();
        }
    }
}
