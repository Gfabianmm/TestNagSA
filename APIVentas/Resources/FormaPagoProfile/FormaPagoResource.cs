using APIVentas.Extensions;
using System.ComponentModel.DataAnnotations;

namespace APIVentas.Resources.FormaPagoProfile;

public class FormaPagoResource: IResource
{
    public FormaPagoResource() { 
    }

    public FormaPagoResource(Guid id)
    {
        IdFormaPago = id;
    }
    public Guid IdFormaPago { get; set; }

    [Required, StringLength(500)]
    public string Descripcion { get; set; }

    [Required, StringLength(2)]
    public string Estado { get; set; }
}
