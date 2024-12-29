using Parking.Core.Domain.Entity;

namespace Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs
{
    public class CreateVehicleInput : VehicleBase
    {
        public string Color { get; set; }
        public DateTime? DateOfCreation { get; set; }
    }
}
