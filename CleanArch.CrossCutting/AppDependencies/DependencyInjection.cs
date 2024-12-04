using CleanArch.Dominio.Abstracoes;
using CleanArch.Infrastutura.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.CrossCutting.AppDependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlConection = configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<IMembroRepositorio, MembroRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
