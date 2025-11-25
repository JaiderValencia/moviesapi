using System.ComponentModel.DataAnnotations;

namespace moviesapi.DAL.Dtos.Movie
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Name can't be longer than 200 characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Release year is required")]
        public int ReleaseYear { get; set; }


        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 1000, ErrorMessage = "Duration must be between 1 and 1000 minutes")]
        public int Duration { get; set; }


        [Required(ErrorMessage = "Category ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Category ID must be greater than 0")]
        public int CategoryId { get; set; }


        public string CategoryName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
