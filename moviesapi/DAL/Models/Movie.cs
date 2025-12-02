using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moviesapi.DAL.Models
{
    public class Movie : Auditbase
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Classification { get; set; } = string.Empty;

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Duration { get; set; } // minutes
        
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
