using System.ComponentModel.DataAnnotations;

namespace moviesapi.DAL.Dtos.Movie
{
    public class MovieUpdateCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Name can't be longer than 200 characters")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000, ErrorMessage = "Description can't be longer than 1000 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Classification is required")]
        [MaxLength(10, ErrorMessage = "Classification can't be longer than 10 characters")]
        public string Classification { get; set; } = string.Empty;

        [Required(ErrorMessage = "Release year is required")]
        [Range(1900, 2100, ErrorMessage = "Release year must be between 1900 and 2100")]
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 1000, ErrorMessage = "Duration must be between 1 and 1000 minutes")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Category ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Category ID must be greater than 0")]
        public int CategoryId { get; set; }
    }
}
