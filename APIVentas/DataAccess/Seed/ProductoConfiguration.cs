using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using APIVentas.Models;

namespace APIVentas.DataAccess.Seed;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{


    public void Configure(EntityTypeBuilder<Producto> builder)
    {

        builder.HasData(
            new Producto() { IdProducto = "PV001", Stock = 120, ValorVenta = 3.25M, Descripcion = "Producto 1", Estado = "A", FechaIngreso = DateTime.Now, UsuarioIngreso = "sistema" },
            new Producto() { IdProducto = "PV002", Stock = 50, ValorVenta = 10.25M, Descripcion = "Producto 2", Estado = "A", FechaIngreso = DateTime.Now, UsuarioIngreso = "sistema" },
            new Producto() { IdProducto = "PV003", Stock = 220, ValorVenta = 1.15M, Descripcion = "Producto 3", Estado = "A", FechaIngreso = DateTime.Now, UsuarioIngreso = "sistema" },
            new Producto() { IdProducto = "PV004", Stock = 615, ValorVenta = 0.54M, Descripcion = "Producto 4", Estado = "A", FechaIngreso = DateTime.Now, UsuarioIngreso = "sistema" }
            );

    }

}
