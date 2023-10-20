using APIVentas.Extensions;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVentas.Models;

public class FormaPago : EntidadBase
{

    [Key]
    public Guid IdFormaPago { get; set; }

    [Required, StringLength(500)]
    public string Descripcion { get; set; }

    [Required,StringLength(2)]
    public string Estado { get; set; }

}
