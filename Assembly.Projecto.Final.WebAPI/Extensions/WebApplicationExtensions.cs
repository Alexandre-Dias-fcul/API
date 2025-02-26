using Assembly.Projecto.Final.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Assembly.Projecto.Final.WebAPI.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void EnsureDatabaseMigration(this WebApplication app)
        {
            var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();

                context.Database.EnsureDeleted();

                context.Database.Migrate();

            }
            catch (Exception ex)
            {
            }

        }
    }
}
