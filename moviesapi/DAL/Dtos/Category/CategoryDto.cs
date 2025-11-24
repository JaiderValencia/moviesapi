namespace moviesapi.DAL.Dtos.Category
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}