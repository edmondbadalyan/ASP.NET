using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<CustomerCategory> CustomerCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerCategory>()
                .HasKey(cc => new { cc.CustomerId, cc.CategoryId });
        }
    }
}
