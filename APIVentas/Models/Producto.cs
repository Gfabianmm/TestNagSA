using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVentas.Models;

public class Producto : EntidadBase
{

    [Key, StringLength(10)]
    public string IdProducto { get; set; }

    [Required, StringLength(500)]
    public string Descripcion { get; set; }

    [Required]
    public int Stock { get; set; }

    [Required, Column(TypeName = "decimal(12, 2)")]
    public decimal ValorVenta { get; set; }

    [Required,StringLength(2)]
    public string Estado { get; set; }


}
