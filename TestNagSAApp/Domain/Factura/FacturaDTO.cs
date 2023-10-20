using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestNagSAApp.Domain.Factura
{
    public class FacturaDTO
    {
        public FacturaDTO() {
            Fecha=DateTime.Now;
            FacturaDetalle = new List<FacturaDetalleDTO>();
            FacturaFormaPago= new List<FacturaFormaPagoDTO>();
        }
        public Guid? IdFactura { get; set; }

        [Required, StringLength(500)]
        public string Cliente { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required, Column(TypeName = "decimal(12, 2)")]
        public decimal Descuento { get; set; }

        [Required, Column(TypeName = "decimal(12, 2)")]
        public decimal IVA { get; set; }

        [Required, Column(TypeName = "decimal(12, 2)")]
        public decimal ValorTotal { get; set; }

        [Required, StringLength(2)]
        public string Estado { get; set; }

        public List<FacturaDetalleDTO> FacturaDetalle { get; set; }
        public List<FacturaFormaPagoDTO> FacturaFormaPago { get; set; }
    }
}
