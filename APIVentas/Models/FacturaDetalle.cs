using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVentas.Models;

public class FacturaDetalle : EntidadBase
{

    [Key]
    public Guid IdFacturaDetalle { get; set; }

    [Required]
    public Guid IdFactura { get; set; }

    [StringLength(10)]
    public string IdProducto { get; set; }


    [Required]
    public int Cantidad { get; set; }

    [Required, Column(TypeName = "decimal(12, 2)")]
    public decimal Valor { get; set; }

    [Required, Column(TypeName = "decimal(12, 2)")]
    public decimal Descuento { get; set; }

    [Required, Column(TypeName = "decimal(12, 2)")]
    public decimal IVA { get; set; }

    [Required, Column(TypeName = "decimal(12, 2)")]
    public decimal Total { get; set; }

    [Required,StringLength(2)]
    public string Estado { get; set; }

    [ForeignKey("IdFactura")]
    public Factura Factura { get; set; }

    [ForeignKey("IdProducto")]
    public Producto Producto { get; set; }

}
