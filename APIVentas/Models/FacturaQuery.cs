using APIVentas.Extensions;

namespace APIVentas.Models;

public class FacturaQuery : IQueryFilter
{
    public FacturaQuery() { }
    public FacturaQuery(Guid id) { 
        IdFactura = id;
    }
    public Guid? IdFactura { get; set; }
    public string? Cliente { get; set; }
    public DateTime? Fecha { get; set; }
    public string? Estado { get; set; }

}
