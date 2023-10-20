using APIVentas.Extensions;

namespace APIVentas.Resources.FacturaProfile;

public class FacturaFormaPagoResource : IResource
{
    public Guid? IdFacturaFormaPago { get; set; }
    public Guid IdFormaPago { get; set; }
    public string? Descripcion { get; set; }
    public decimal Valor { get; set; }
    public string Estado { get; set; }
}
