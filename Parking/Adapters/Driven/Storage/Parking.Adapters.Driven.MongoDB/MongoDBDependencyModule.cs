using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using MongoDB.Driver;
using Parking.Adapters.Driven.MongoDB.Contexts;

namespace Parking.Adapters.Driven.MongoDB
{
    public static class MongoDBDependencyModule
    {
        public static void AddMongoDBDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoConnectionString = configuration["MongoDbSettings:ConnectionString"];
            var mongoDatabaseName = configuration["MongoDbSettings:DatabaseName"];

            var mongoClient = new MongoClient(mongoConnectionString);

            // Registra o MongoClient como um serviço singleton
            services.AddSingleton<IMongoClient>(mongoClient);

            // Registra o contexto MongoDB
            services.AddScoped<MongoDBContext>(provider =>
            {
                var client = provider.GetRequiredService<IMongoClient>();
                return new MongoDBContext(client, mongoDatabaseName);
            });

            // Registrar repositórios aqui
        }
    }
}
