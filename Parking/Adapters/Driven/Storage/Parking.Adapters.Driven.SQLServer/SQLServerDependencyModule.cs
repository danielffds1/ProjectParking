using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Parking.Adapters.Driven.SQLServer.EF;
using Parking.Adapters.Driven.SQLServer.Repositories.VehicleRepository;
using Parking.Core.Domain.Adapters.Driven.Storage.Repositories.VehicleRepository;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Parking.Adapters.Driven.SQLServer
{
    public static class SQLServerDependencyModule
    {
        public static IServiceCollection AddSqlServerDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Configura o contexto DbContext para o SQL Server usando a string de conexão
            services.AddDbContext<ParkingDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Configura uma conexão de SQL usando o SqlConnection do SQL Server
            services.AddScoped<IDbConnection>(db =>
                new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

            //Inject repositories
            services.AddScoped<IVehicleRepository, VehicleRepository>();

            return services;
        }
    }
}
