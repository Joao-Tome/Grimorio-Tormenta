﻿using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Repositorio.Repositorio;

namespace Grimorio_Tormenta_Back_End.Config.Depencency_Injection
{
    public static class DIRepositorios
    {
        public static IServiceCollection addRepositoriosDI( this IServiceCollection services)
        {
            services.AddTransient<IGrupoRepositorio, GrupoRepositorio>();
            services.AddTransient<IPessoaRepositorio, PessoaRepositorio>();
            services.AddTransient<IGrupoPessoaRepositorio, GrupoPessoaRepositorio>();

            return services;
        }

    }
}
