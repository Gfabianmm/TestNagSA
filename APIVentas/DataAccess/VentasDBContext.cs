using APIVentas.Models;
using Microsoft.EntityFrameworkCore;

namespace APIVentas.DataAccess;

public class VentasDBContext : DbContext
{
    public VentasDBContext(DbContextOptions options)
   : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<FormaPago> FormaPago { get; set; }
    public DbSet<Producto> Producto { get; set; }
    public DbSet<Factura> Factura { get; set; }
    public DbSet<FacturaDetalle> FacturaDetalle { get; set; }
    public DbSet<FacturaFormaPago> FacturaFormaPago { get; set; }

}
