using APIVentas.Models;
using AutoMapper;

namespace APIVentas.Resources.ProductoProfile;

public class ProductoMapping:Profile
{
    public ProductoMapping()
    {
        CreateMap<Producto, ProductoResource>().ReverseMap();
    }
}
