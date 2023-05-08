using GrimorioTormenta.Business.Services;
using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Intefaces.Services;
using GrimorioTormenta.Repositorio.Repositorio;

namespace Grimorio_Tormenta_Back_End.Config.Depencency_Injection
{
    public static class DIServices
    {
        public static IServiceCollection addServicesDI(this IServiceCollection services)
        {
            services.AddTransient<ITokenServices, TokenServices>();
            services.AddTransient<IPessoaServices, PessoaServices>();

            return services;
        }
    }
}
