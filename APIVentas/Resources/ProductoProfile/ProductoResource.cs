using APIVentas.Extensions;


namespace APIVentas.Resources.ProductoProfile;

public class ProductoResource : IResource
{
    public ProductoResource() { }
    public ProductoResource(string id) {
        IdProducto = id;
    }
    public string IdProducto { get; set; }
    public string Descripcion { get; set; }
    public int Stock { get; set; }
    public decimal ValorVenta { get; set; }
    public string Estado { get; set; }


}
