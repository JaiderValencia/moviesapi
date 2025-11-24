using Microsoft.EntityFrameworkCore;

namespace moviesapi.DAL.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // DbSets section
        public DbSet<Category> Categories { get; set; }
    }
}