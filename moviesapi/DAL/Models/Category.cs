using System.ComponentModel.DataAnnotations;

namespace moviesapi.DAL.Models
{
    public class Category : Auditbase
    {
        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}