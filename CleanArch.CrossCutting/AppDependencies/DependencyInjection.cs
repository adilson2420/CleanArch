using CleanArch.Dominio.Abstracoes;
using CleanArch.Infrastutura.Context;
using CleanArch.Infrastutura.Migrations;
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
            var server = configuration["DbServer"] ?? "localhost";
            var port = configuration["DbPort"] ?? "1450";
            var user = configuration["DbUser"] ?? "SA";
            var passowrd = configuration["Password"] ?? "DOCk126#";
            var database = configuration["Database"] ?? "Admin_CleanArch";
            //var sqlConection = configuration.GetConnectionString("DefaultConnection");
            var conectionString = $"Server = {server}; initial catalog = {database}; Persist Security Info = true; User ID = {user}; Password = {passowrd}; TrustServerCertificate=True;";


            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conectionString));
            services.AddScoped<IMembroRepositorio, MembroRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMembroDapperRepositorio, MembroDapperRepositorio>();
            services.AddSingleton<IDbConnection>(provider =>
            {
                var connection = new SqlConnection(conectionString);
                connection.Open();
                return connection;
            });

            var myhandlers = AppDomain.CurrentDomain.Load("CleanArch.Aplicacao");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));

            return services;
        }
    }
}
