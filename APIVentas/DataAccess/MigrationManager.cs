using Microsoft.EntityFrameworkCore;

namespace APIVentas.DataAccess;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<VentasDBContext>())
            {

                appContext.Database.Migrate();
            }
        }
        return host;
    }
}
