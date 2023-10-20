using System.ComponentModel.DataAnnotations;

namespace TestNagSAApp.Domain.Factura
{
    public class FacturaFormaPagoDTO
    {

        public Guid? IdFacturaFormaPago { get; set; }

        [Required]
        public Guid IdFormaPago { get; set; }
        public string Descripcion { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public string Estado { get; set; }
    }
}
