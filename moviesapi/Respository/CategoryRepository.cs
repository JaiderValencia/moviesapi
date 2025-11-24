namespace moviesapi.Repository
{
    using Microsoft.EntityFrameworkCore;
    using moviesapi.DAL.Models;
    using moviesapi.Repository.Irepository;
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CategoryExistsByIdAsync(int id)
        {
            var exists = await _context.Categories.AsNoTracking().AnyAsync(c => c.Id == id);
            return exists;
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            var exists = await _context.Categories.AsNoTracking().AnyAsync(c => c.Name.ToLower().Equals(name.ToLower()));

            return exists;
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            category.CreatedAt = DateTime.UtcNow;

            await _context.Categories.AddAsync(category);

            return await SaveAsync();
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var category = await GetCategoryByIdAsync(categoryId);

            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);

            return await SaveAsync();
        }

        public async Task<ICollection<Category>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.AsNoTracking().ToListAsync();

            return categories;
        }

        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == categoryId);

            return category;
        }

        public async Task<Category?> GetCategoryByNameAsync(string name)
        {
            var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Name.Equals(name));

            return category;
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {

            category.UpdatedAt = DateTime.UtcNow;
            _context.Categories.Update(category);

            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;

        }
    }
}