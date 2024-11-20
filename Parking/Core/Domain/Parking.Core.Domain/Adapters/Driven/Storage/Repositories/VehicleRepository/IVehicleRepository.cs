﻿using Parking.Core.Domain.Entity;

namespace Parking.Core.Domain.Adapters.Driven.Storage.Repositories.VehicleRepository
{
    public interface IVehicleRepository
    {
        Task<RegisterVehicle> GetByIdAsync(int id);
        Task<RegisterVehicle> AddAsync(RegisterVehicle vehicle);
    }
}
