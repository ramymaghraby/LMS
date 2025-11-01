using LMS.BLL.Model;
using LMS.BLL.Repository;
using LMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BLL.Service
{
    public class CategoryService : ICategoryService
    {
        GenericRepository<Category> _categoryRepo = new GenericRepository<Category>();

        public async Task<List<CategoryDTO>> GetAllCategroies()
        {
            var categories = await _categoryRepo.GetAll(c => c.IsActive);
            var categoriesDTO = new List<CategoryDTO>();
            if (categories == null) 
                return categoriesDTO;
            foreach (var category in categories) {
                var categoryDTO = new CategoryDTO()
                {
                    Name = category.Name,
                    Id = category.Id,
                    IsActive = category.IsActive,
                    CreatedOn = category.CreatedOn,
                    Description = category.Description,
                    Books = category.Books
                };
                categoriesDTO.Add(categoryDTO);
            };
            return categoriesDTO;
        }

        public async Task<CategoryDTO> GetCategoryById(int categoryId)
        {
            var category = await _categoryRepo.GetBy(c => c.Id == categoryId);
            var categoryDTO = new CategoryDTO()
            {
                Name = category.Name,
                Id = category.Id,
                IsActive = category.IsActive,
                CreatedOn = category.CreatedOn,
                Description = category.Description,
                Books = category.Books

            };
            return categoryDTO;

        }
        public async Task CreateCategory(CategoryDTO categoryDTO)
        {
            Category category = new Category() 
            {
                Name = categoryDTO.Name,
                Id = categoryDTO.Id,
                IsActive = categoryDTO.IsActive,
                Books = categoryDTO.Books,
                CreatedOn = categoryDTO.CreatedOn,
                Description = categoryDTO.Description,
            };
            await _categoryRepo.CreateAsync(category);
        }
        public async Task UpdateCategory(CategoryDTO categoryDTO)
        {
            Category category = new Category()
            {
                Name = categoryDTO.Name,
                Id = categoryDTO.Id,
                IsActive = categoryDTO.IsActive,
                Books = categoryDTO.Books,
                CreatedOn = categoryDTO.CreatedOn,
                Description = categoryDTO.Description,
            };
            await _categoryRepo.UpdateAsync(category);
        }
        public async Task DeleteCategory(CategoryDTO categoryDTO)
        {
            Category category = new Category()
            {
                Name = categoryDTO.Name,
                Id = categoryDTO.Id,
                IsActive = categoryDTO.IsActive,
                Books = categoryDTO.Books,
                CreatedOn = categoryDTO.CreatedOn,
                Description = categoryDTO.Description,
            };
            await _categoryRepo.DeleteAsync(category);

        }
    }
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategroies();
        Task<CategoryDTO> GetCategoryById(int categoryId);
        Task CreateCategory(CategoryDTO categoryDTO);
        Task UpdateCategory(CategoryDTO categoryDTO);
        Task DeleteCategory(CategoryDTO categoryDTO);
    }
}
