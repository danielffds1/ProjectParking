
namespace Parking.Core.Domain.Entity
{
    public class RegisterVehicle : VehicleBase
    {
        public string Color { get; set; }
        public DateTime? ExitTime { get; set; }

    }
}
