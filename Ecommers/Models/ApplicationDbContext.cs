using Microsoft.EntityFrameworkCore;

namespace Ecommers.Models
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor para recibir las opciones de configuración
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para representar la tabla Productos
        public DbSet<Product> Productos { get; set; }
    }
}
