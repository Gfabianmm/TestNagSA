using System.ComponentModel.DataAnnotations;

namespace TestNagSAApp.Domain.Factura
{
    public class FacturaDetalleDTO
    {
        public Guid IdFacturaDetalle { get; set; }

        [Required, StringLength(10)]
        public string IdProducto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public decimal Descuento { get; set; }

        [Required]
        public decimal IVA { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required, StringLength(2)]
        public string Estado { get; set; }
    }
}
