using DoofenshmirtzsWebShop.Database.Entities;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryResponse>> getAllCategories();
    }

    public class CategoryServices : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryResponse>> getAllCategories()
        {
            List<Category> categories = await _categoryRepository.getAll();

            return categories == null ? null : categories.Select(a => new CategoryResponse
            {
                ID = a.categoryID,
                name = a.categoryName
            }).ToList();
        }
    }
}
