using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVentas.Models;

public class Factura : EntidadBase
{

    [Key]
    public Guid IdFactura { get; set; }

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

    public List<FacturaDetalle> FacturaDetalle { get; set; }

}
