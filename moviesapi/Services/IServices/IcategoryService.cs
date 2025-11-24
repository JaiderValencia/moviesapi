using moviesapi.DAL.Dtos.Category;
using moviesapi.DAL.Models;

namespace moviesapi.Services.IServices
{
    public interface IcategoryService
    {
        Task<ICollection<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int categoryId);
        Task<CategoryDto?> GetCategoryByNameAsync(string name);
        Task<CategoryDto> CreateCategoryAsync(CategoryUpdateCreateDto category);
        Task<CategoryDto> UpdateCategoryAsync(CategoryUpdateCreateDto category,int categoryId);
        Task<bool> DeleteCategoryAsync(int categoryId);
        Task<bool> CategoryExistsByNameAsync(string name);
        Task<bool> CategoryExistsByIdAsync(int id);
    }
}