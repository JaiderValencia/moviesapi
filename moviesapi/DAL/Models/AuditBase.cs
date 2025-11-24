using System.ComponentModel.DataAnnotations;

namespace moviesapi.DAL.Models
{
    public class Auditbase
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
    }
}