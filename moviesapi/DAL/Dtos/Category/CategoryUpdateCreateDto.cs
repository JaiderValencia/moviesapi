namespace moviesapi.DAL.Dtos.Category
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryUpdateCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; } = string.Empty;
    }
}