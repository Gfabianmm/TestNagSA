using APIVentas.Extensions;

namespace APIVentas.Models;

public class ProductoQuery : IQueryFilter
{
    public ProductoQuery() { }
    public ProductoQuery(string id) {
        IdProducto = id;
    }
    public string IdProducto { get; set; }
    public string Descripcion { get; set; }
    public string Estado { get; set; }

}
