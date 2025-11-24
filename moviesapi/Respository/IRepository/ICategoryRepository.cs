using moviesapi.DAL.Models;

namespace moviesapi.Repository.Irepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int categoryId);
        Task<bool> CreateCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int categoryId);
        Task<bool> CategoryExistsByNameAsync(string name);
        Task<bool> CategoryExistsByIdAsync(int id);
    }
}