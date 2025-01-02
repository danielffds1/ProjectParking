using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Parking.Core.Application.UseCases.Vehicle;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos;

namespace Parking.Core.Application
{
    public static class ApplicationDependencyModule
    {
        public static IServiceCollection AddApplicationDependencyModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICreateVehicleUseCase, CreateVehicleUseCase>();
            services.AddScoped<IEntryVehicleUseCase, EntryVehicleUseCase>();
            services.AddScoped<IExitVehicleUseCase, ExitVehicleUseCase>();
            services.AddScoped<IListVehicleUseCase, ListVehiclesUseCase>();

            return services;
        }

    }
}
