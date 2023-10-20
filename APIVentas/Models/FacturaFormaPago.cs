using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVentas.Models;

public class FacturaFormaPago : EntidadBase
{

    [Key]
    public Guid IdFacturaFormaPago { get; set; }

    [Required]
    public Guid IdFactura { get; set; }

    [Required]
    public Guid IdFormaPago { get; set; }

    [Required, Column(TypeName = "decimal(12, 2)")]
    public decimal Valor { get; set; }

    [Required, StringLength(2)]
    public string Estado { get; set; }

    [ForeignKey("IdFactura")]
    public Factura Factura { get; set; }

    [ForeignKey("IdFormaPago")]
    public FormaPago FormaPago { get; set; }
}
