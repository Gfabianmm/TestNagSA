using APIVentas.Extensions;
using System.ComponentModel.DataAnnotations;

namespace APIVentas.Resources.ProductoProfile;

public class ProductoResource : IResource
{
    public ProductoResource() { }
    public ProductoResource(string id) {
        IdProducto = id;
    }

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
