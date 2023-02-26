using GrimorioTormenta.Business.Instancia;
using GrimorioTormenta.Intefaces.Instancia;

namespace Grimorio_Tormenta_Back_End.Config.Depencency_Injection
{
    public static class DIInstacias
    {
        public static IServiceCollection addInstanciasDI(this IServiceCollection services)
        {
            services.AddScoped<IGrupoInstancia, GrupoInstancia>();
            services.AddScoped<IPessoaInstancia, PessoaInstancia>();

            return services;
        }

    }
}
