namespace MyApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyApp.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
