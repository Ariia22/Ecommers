using Ecommers.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Productos { get; set; }

    }
}
