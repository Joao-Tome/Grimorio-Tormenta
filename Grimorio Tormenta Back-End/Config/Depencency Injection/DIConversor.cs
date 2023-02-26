using GrimorioTormenta.Business.Conversor;
using GrimorioTormenta.Intefaces.Conversor;

namespace Grimorio_Tormenta_Back_End.Config.Depencency_Injection
{
    public static class DIConversor
    {
        public static IServiceCollection addConversorDi(this IServiceCollection services)
        {
            services.AddScoped<IGrupoConversor, GrupoConversor>();
            services.AddScoped<IPessoaConversor, PessoaConversor>();

            return services;
        }
    }
}
