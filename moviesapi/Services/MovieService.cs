using AutoMapper;
using moviesapi.DAL.Dtos.Movie;
using moviesapi.DAL.Models;
using moviesapi.Repository.Irepository;
using moviesapi.Services.IServices;

namespace moviesapi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<MovieDto> CreateMovieAsync(MovieUpdateCreateDto movieDto)
        {            
            var nameExists = await _movieRepository.MovieExistsByNameAsync(movieDto.Name);
            if (nameExists)
                throw new InvalidOperationException($"Movie with name '{movieDto.Name}' already exists.");
            
            var categoryExists = await _categoryRepository.CategoryExistsByIdAsync(movieDto.CategoryId);
            if (!categoryExists)
                throw new InvalidOperationException($"Category with ID {movieDto.CategoryId} does not exist.");

            var movie = _mapper.Map<Movie>(movieDto);
            var created = await _movieRepository.CreateMovieAsync(movie);

            if (!created)
                throw new Exception("Failed to create movie.");

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<bool> DeleteMovieAsync(int movieId)
        {
            var exists = await _movieRepository.MovieExistsByIdAsync(movieId);
            if (!exists)
                throw new InvalidOperationException($"Movie with ID {movieId} not found.");

            return await _movieRepository.DeleteMovieAsync(movieId);
        }

        public async Task<ICollection<MovieDto>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto?> GetMovieByIdAsync(int movieId)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(movieId);
            return _mapper.Map<MovieDto?>(movie);
        }

        public async Task<MovieDto?> GetMovieByNameAsync(string name)
        {
            var movie = await _movieRepository.GetMovieByNameAsync(name);
            return _mapper.Map<MovieDto?>(movie);
        }

        public async Task<bool> MovieExistsByIdAsync(int id)
        {
            return await _movieRepository.MovieExistsByIdAsync(id);
        }

        public async Task<bool> MovieExistsByNameAsync(string name)
        {
            return await _movieRepository.MovieExistsByNameAsync(name);
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieUpdateCreateDto movieDto, int movieId)
        {            
            var movieOnDB = await _movieRepository.GetMovieByIdAsync(movieId) ?? throw new InvalidOperationException($"Movie with ID {movieId} not found.");

            var nameExists = await _movieRepository.MovieExistsByNameAsync(movieDto.Name);
            if (nameExists && !movieOnDB.Name.Equals(movieDto.Name, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException($"Movie with name '{movieDto.Name}' already exists.");
            
            var categoryExists = await _categoryRepository.CategoryExistsByIdAsync(movieDto.CategoryId);
            if (!categoryExists)
                throw new InvalidOperationException($"Category with ID {movieDto.CategoryId} does not exist.");

            _mapper.Map(movieDto, movieOnDB);

            var updated = await _movieRepository.UpdateMovieAsync(movieOnDB);
            if (!updated)
                throw new Exception("Failed to update movie.");

            return _mapper.Map<MovieDto>(movieOnDB);
        }
    }
}
