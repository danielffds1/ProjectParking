using Parking.Core.Domain.Entity;

namespace Parking.Core.Domain.Adapters.Driven.Storage.Repositories.VehicleRepository
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetByIdAsync(int id);
        Task<Vehicle> AddAsync(Vehicle vehicle);
    }
}
