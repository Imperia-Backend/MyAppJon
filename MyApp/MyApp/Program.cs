namespace MyApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MyApp.Data;
    using MyApp.Models;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MiniInventarioConnection")));

            WebApplication app = builder.Build();

            using (IServiceScope scope = app.Services.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();

                if (!context.Productos.Any())
                {
                    List<Producto> productos = new List<Producto>
                    {
                        new Producto { Nombre = "Tornillos galvanizados", CodigoSKU = "TORN-001", CantidadStock = 250, FechaAlta = DateTime.Now, Activo = true },
                        new Producto { Nombre = "Papel bond A4", CodigoSKU = "PAPL-010", CantidadStock = 500, FechaAlta = DateTime.Now, Activo = true },
                        new Producto { Nombre = "Aceite industrial", CodigoSKU = "ACET-205", CantidadStock = 120, FechaAlta = DateTime.Now, Activo = true },
                        new Producto { Nombre = "Guantes de seguridad", CodigoSKU = "GANT-150", CantidadStock = 75, FechaAlta = DateTime.Now, Activo = true },
                        new Producto { Nombre = "Cinta aislante", CodigoSKU = "CINT-075", CantidadStock = 60, FechaAlta = DateTime.Now, Activo = true }
                    };

                    context.Productos.AddRange(productos);
                    context.SaveChanges();
                }
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
