using System.ComponentModel.DataAnnotations;

namespace TestNagSAApp.Domain.FormaPago;

public class FormaPagoDTO
{
    public Guid IdFormaPago { get; set; }

    [Required, StringLength(500,ErrorMessage ="La descripción no puede tener más de 500 caracteres")]
    public string Descripcion { get; set; }

    [Required, StringLength(2)]
    public string Estado { get; set; }
}
