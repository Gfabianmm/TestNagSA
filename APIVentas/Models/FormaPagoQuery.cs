using APIVentas.Extensions;
using System.ComponentModel.DataAnnotations;

namespace APIVentas.Models;

public class FormaPagoQuery : IQueryFilter
{
    public Guid? IdFormaPago { get; set; }
    public string? Descripcion { get; set; }
    public string? Estado { get; set; }

}
