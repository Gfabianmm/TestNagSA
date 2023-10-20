using APIVentas.Models;
using AutoMapper;

namespace APIVentas.Resources.FormaPagoProfile;

public class FormaPagoMapping:Profile
{
    public FormaPagoMapping()
    {
        CreateMap<FormaPago, FormaPagoResource>().ReverseMap();
    }
}
