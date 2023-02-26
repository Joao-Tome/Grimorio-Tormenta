using FluentValidation;
using GrimorioTormenta.Business.Validadores.FluentValidation;
using GrimorioTormenta.Business.Validadores.Validadores;
using GrimorioTormenta.Intefaces.Validadores;
using GrimorioTormenta.Model.DTO;

namespace Grimorio_Tormenta_Back_End.Config.Depencency_Injection
{
    public static class DIValidadores
    {
        public static IServiceCollection addValidadoresDI(this IServiceCollection services)
        {
            services = addValidadoresFluentValidationDI(services);
            services = addCustomValidadoresDI(services);

            return services;
        }

        private static IServiceCollection addValidadoresFluentValidationDI(IServiceCollection services)
        {
            services.AddScoped<IValidator<GrupoDTO>, GrupoFluentValidator>();
            services.AddScoped<IValidator<PessoaDTO>, PessoaFluentValidator>();

            return services;
        }

        private static IServiceCollection addCustomValidadoresDI(IServiceCollection services)
        {
            services.AddScoped<IValidador<GrupoDTO>, GrupoValidador>();
            services.AddScoped<IValidador<PessoaDTO>, PessoaValidador>();

            return services;
        }

    }
}
