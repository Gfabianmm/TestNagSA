using APIVentas.Extensions;
using APIVentas.Resources.ProductoProfile;
using System.ComponentModel.DataAnnotations;

namespace APIVentas.Resources.FacturaProfile;

public class FacturaDetalleResource : IResource
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

    [Required,StringLength(2)]
    public string Estado { get; set; }
    public ProductoResource Producto { get; set; }

}
