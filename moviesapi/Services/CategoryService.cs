using moviesapi.Services.IServices;
using moviesapi.Repository.Irepository;
using moviesapi.DAL.Models;
using AutoMapper;
using moviesapi.DAL.Dtos.Category;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Http.HttpResults;

namespace moviesapi.Services
{
    public class CategoryService : IcategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> CategoryExistsByIdAsync(int id)
        {
            return await _categoryRepository.CategoryExistsByIdAsync(id);
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            return await _categoryRepository.CategoryExistsByNameAsync(name);
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryUpdateCreateDto categoryDto)
        {
            var alreadyExists = await _categoryRepository.CategoryExistsByNameAsync(categoryDto.Name);

            if (alreadyExists)
                throw new InvalidOperationException($"Category with name {categoryDto.Name} already exists.");


            var category = _mapper.Map<Category>(categoryDto);

            var created = await _categoryRepository.CreateCategoryAsync(category);

            if (!created)
                throw new Exception("Failed to create category.");

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var exists = await _categoryRepository.CategoryExistsByIdAsync(categoryId);

            if (!exists)
                throw new InvalidOperationException($"Category with ID {categoryId} not found.");

            return await _categoryRepository.DeleteCategoryAsync(categoryId);
        }

        public async Task<ICollection<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();

            return _mapper.Map<ICollection<CategoryDto>>(categories);
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId)
            ??
            throw new InvalidOperationException($"Category with ID {categoryId} not found.");

            return _mapper.Map<CategoryDto?>(category);
        }

        public async Task<CategoryDto?> GetCategoryByNameAsync(string name)
        {
            var category = await _categoryRepository.GetCategoryByNameAsync(name)
            ??
            throw new InvalidOperationException($"Category with name {name} not found.");

            return _mapper.Map<CategoryDto?>(category);
        }

        public async Task<CategoryDto> UpdateCategoryAsync(CategoryUpdateCreateDto categoryDto, int categoryId)
        {
            var CategoryOnDB = await _categoryRepository.GetCategoryByIdAsync(categoryId);

            if (CategoryOnDB == null)
                throw new InvalidOperationException($"Category with ID {categoryId} not found.");


            var nameExists = await _categoryRepository.CategoryExistsByNameAsync(categoryDto.Name);
            if (nameExists && !CategoryOnDB.Name.Equals(categoryDto.Name))
                throw new InvalidOperationException($"Category with name {categoryDto.Name} already exists.");

            _mapper.Map(categoryDto, CategoryOnDB);

            var updated = await _categoryRepository.UpdateCategoryAsync(CategoryOnDB);

            if (!updated)
                throw new Exception("Failed to update category.");

            return _mapper.Map<CategoryDto>(CategoryOnDB);
        }
    }
}