using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :  base(options) { }

        public DbSet<Product> Products { get; set; }

    }
}
