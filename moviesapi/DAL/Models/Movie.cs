using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moviesapi.DAL.Models
{
    public class Movie : Auditbase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
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
