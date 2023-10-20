using System.ComponentModel.DataAnnotations;

namespace TestNagSAApp.Domain.Producto
{
    public class ProductoDTO
    {
        public string? IdProducto { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public decimal ValorVenta { get; set; }
        [Required]
        public string Estado { get; set; }
    }
}
