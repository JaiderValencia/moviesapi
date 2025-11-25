using moviesapi.DAL.Dtos.Movie;

namespace moviesapi.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetAllMoviesAsync();
        Task<MovieDto?> GetMovieByIdAsync(int movieId);
        Task<MovieDto?> GetMovieByNameAsync(string name);
        Task<MovieDto> CreateMovieAsync(MovieUpdateCreateDto movieDto);
        Task<MovieDto> UpdateMovieAsync(MovieUpdateCreateDto movieDto, int movieId);
        Task<bool> DeleteMovieAsync(int movieId);
        Task<bool> MovieExistsByIdAsync(int id);
        Task<bool> MovieExistsByNameAsync(string name);
    }
}
