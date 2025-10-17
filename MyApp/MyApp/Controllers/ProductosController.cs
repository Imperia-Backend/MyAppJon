namespace MyApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyApp.Data;
    using MyApp.Models;

    public class ProductosController : Controller
    {
        private readonly AppDbContext context;

        public ProductosController(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Producto> productos = await this.context.Productos
                .AsNoTracking()
                .OrderBy(producto => producto.Nombre)
                .ToListAsync();

            return this.View(productos);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(producto);
            }

            producto.FechaAlta = DateTime.Now;

            this.context.Productos.Add(producto);
            await this.context.SaveChangesAsync();

            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Producto? producto = await this.context.Productos.FindAsync(id);

            if (producto == null)
            {
                return this.NotFound();
            }

            return this.View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(producto);
            }

            try
            {
                this.context.Update(producto);
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool exists = await this.ProductoExists(producto.Id);

                if (!exists)
                {
                    return this.NotFound();
                }

                throw;
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Producto? producto = await this.context.Productos
                .AsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Id == id);

            if (producto == null)
            {
                return this.NotFound();
            }

            return this.View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Producto? producto = await this.context.Productos.FindAsync(id);

            if (producto == null)
            {
                return this.NotFound();
            }

            this.context.Productos.Remove(producto);
            await this.context.SaveChangesAsync();

            return this.RedirectToAction(nameof(this.Index));
        }

        private async Task<bool> ProductoExists(int id)
        {
            bool exists = await this.context.Productos.AnyAsync(entity => entity.Id == id);
            return exists;
        }
    }
}
