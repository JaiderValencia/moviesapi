using moviesapi.DAL.Models;

namespace moviesapi.Repository.Irepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetAllMoviesAsync();
        Task<Movie?> GetMovieByIdAsync(int movieId);
        Task<Movie?> GetMovieByNameAsync(string name);
        Task<bool> CreateMovieAsync(Movie movie);
        Task<bool> UpdateMovieAsync(Movie movie);
        Task<bool> DeleteMovieAsync(int movieId);
        Task<bool> MovieExistsByIdAsync(int id);
        Task<bool> MovieExistsByNameAsync(string name);
    }
}
