using Parking.Core.Domain.Entity;

namespace Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs
{
    public class EntryVehicleInput : VehicleBase
    {
        public string AllocatedParkingSpace { get; set; }
        public DateTime EntryTime { get; set; }

    }
}
