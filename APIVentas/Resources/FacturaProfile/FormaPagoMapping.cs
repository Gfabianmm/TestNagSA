using APIVentas.Models;
using APIVentas.Resources.FacturaProfile;
using AutoMapper;

namespace APIVentas.Resources.FormaPagoProfile;

public class FacturaMapping : Profile
{
    public FacturaMapping()
    {
        CreateMap<Factura, FacturaResource>().ReverseMap();
        CreateMap<FacturaDetalle, FacturaDetalleResource>().ReverseMap();
        CreateMap<FacturaFormaPago, FacturaFormaPagoResource>()
            .ForMember(a => a.Descripcion, b => b.MapFrom(c => c.FormaPago.Descripcion))
            .ReverseMap();
    }
}
