using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using APIVentas.Models;

namespace APIVentas.DataAccess.Seed;

public class FormaPagoConfiguration : IEntityTypeConfiguration<FormaPago>
{
    public void Configure(EntityTypeBuilder<FormaPago> builder)
    {

        builder.HasData(
            new FormaPago() { IdFormaPago = Guid.NewGuid(), Descripcion = "Efectivo", Estado = "A", FechaIngreso = DateTime.Now, UsuarioIngreso = "sistema" },
            new FormaPago { IdFormaPago = Guid.NewGuid(), Descripcion = "Cheque", Estado = "A", FechaIngreso = DateTime.Now, UsuarioIngreso = "sistema" },
            new FormaPago { IdFormaPago = Guid.NewGuid(), Descripcion = "Tarjeta de Crédito", Estado = "A", FechaIngreso = DateTime.Now, UsuarioIngreso = "sistema" }
            );

    }

}
