using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;

namespace Parking.Core.Domain.Adapters.Driven.Storage.Repositories.VehicleRepository
{
    public interface IVehicleRepository
    {
        Task<CreateVehicleInput> GetByIdAsync(int id);
        Task<CreateVehicleInput> AddAsync(CreateVehicleInput vehicle);
    }
}
