﻿using CleanArch.Dominio.Abstracoes;
using CleanArch.Infrastutura.Context;
using CleanArch.Infrastutura.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace CleanArch.CrossCutting.AppDependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlConection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(sqlConection));
            services.AddScoped<IMembroRepositorio, MembroRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMembroDapperRepositorio, MembroDapperRepositorio>();
            services.AddSingleton<IDbConnection>(provider =>
            {
                var connection = new SqlConnection(sqlConection);
                connection.Open();
                return connection;
            });

            var myhandlers = AppDomain.CurrentDomain.Load("CleanArch.Aplicacao");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));

            return services;
        }
    }
}
