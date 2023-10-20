using APIVentas.Extensions;

namespace APIVentas.Models;

public class EntidadBase: IEntity
{
    public string UsuarioIngreso { get; set; }
    public DateTime FechaIngreso { get; set; }
    public string UsuarioModificacion { get; set; }
    public DateTime FechaModificacion { get; set; }
}
