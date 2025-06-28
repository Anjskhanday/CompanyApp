using Company.Model;
using Microsoft.EntityFrameworkCore;

namespace Company.CompanyDbContext
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CompanyA> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
