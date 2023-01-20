using FluentValidation;
using GrimorioTormenta.Business.Validadores;
using GrimorioTormenta.Model.DTO;

namespace Grimorio_Tormenta_Back_End.Config.Depencency_Injection
{
    public static class DIValidadores
    {
        public static IServiceCollection addValidadoresDI(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GrupoDTO>, GrupoValidator>();

            return services;
        }
    }
}
