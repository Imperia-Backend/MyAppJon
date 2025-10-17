namespace MyApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(200, ErrorMessage = "Product name cannot exceed 200 characters.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "SKU code is required.")]
        [StringLength(100, ErrorMessage = "SKU code cannot exceed 100 characters.")]
        public string CodigoSKU { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative.")]
        public int CantidadStock { get; set; }

        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public bool Activo { get; set; } = true;
    }
}
