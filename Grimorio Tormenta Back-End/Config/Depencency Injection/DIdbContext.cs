using GrimorioTormenta.Repositorio.Config;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Grimorio_Tormenta_Back_End.Config.Depencency_Injection
{
    public static class DIdbContext
    {
        public static IServiceCollection addDbContextDI( this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            services.AddScoped<DbContext, AppDbContext>();
            services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            return services;
        }

    }
}
