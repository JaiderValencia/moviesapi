using Microsoft.EntityFrameworkCore;
using moviesapi.DAL.Models;
using moviesapi.Repository.Irepository;

namespace moviesapi.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            movie.CreatedAt = DateTime.UtcNow;
            await _context.Movies.AddAsync(movie);
            return await SaveAsync();
        }

        public async Task<bool> DeleteMovieAsync(int movieId)
        {
            var movie = await GetMovieByIdAsync(movieId);

            if (movie == null)
                return false;

            _context.Movies.Remove(movie);
            return await SaveAsync();
        }

        public async Task<ICollection<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies
                .Include(m => m.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Movie?> GetMovieByIdAsync(int movieId)
        {
            return await _context.Movies
                .Include(m => m.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == movieId);
        }

        public async Task<Movie?> GetMovieByIdForUpdateAsync(int movieId)
        {
            return await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == movieId);
        }

        public async Task<Movie?> GetMovieByNameAsync(string name)
        {
            return await _context.Movies
                .Include(m => m.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Name.Equals(name));
        }

        public async Task<bool> MovieExistsByIdAsync(int id)
        {
            return await _context.Movies.AsNoTracking().AnyAsync(m => m.Id == id);
        }

        public async Task<bool> MovieExistsByNameAsync(string name)
        {
            return await _context.Movies.AsNoTracking().AnyAsync(m => m.Name.Equals(name));
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            movie.UpdatedAt = DateTime.UtcNow;
            _context.Movies.Update(movie);
            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
