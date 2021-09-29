using DoofenshmirtzsWebShop.Database.Entities;
using DoofenshmirtzsWebShop.DTOs.Requests;
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
        Task<CategoryResponse> getByID(int categoryID);
        Task<CategoryResponse> create(NewCategory newCategory);
        Task<CategoryResponse> update(int categortID, UpdateCategory updateCategory);
        Task<bool> delete(int categoryID);
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
                categoryName = a.categoryName
            }).ToList();
        }

        public async Task<CategoryResponse> getByID(int categoryID)
        {
            Category category = await _categoryRepository.getByID(categoryID);

            return category == null ? null : new CategoryResponse
            {
                ID = category.categoryID,
                categoryName = category.categoryName
            };
        }

        public async Task<CategoryResponse> create(NewCategory newCategory)
        {
            Category category = new Category
            {
                categoryName = newCategory.name
            };

            category = await _categoryRepository.create(category);
            return category == null ? null : new CategoryResponse
            {
                ID = category.categoryID,
                categoryName = category.categoryName
            };
        }

        public async Task<CategoryResponse> update(int categoryID, UpdateCategory updateCategory)
        {
            Category category = new Category
            {
                categoryName = updateCategory.name
            };

            category = await _categoryRepository.update(categoryID, category);

            return category == null ? null : new CategoryResponse
            {
                //ID = category.categoryID,
                categoryName = category.categoryName
            };
        }

        public async Task<bool> delete(int categoryID)
        {
            var result = await _categoryRepository.delete(categoryID);
            return true;
        }
    }
}
