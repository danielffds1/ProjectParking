namespace Parking.Adapters.Driving.Api.Dtos.Vehicle.Request
{
    public class CreateVehicleRequest : VehicleRequestBase
    {
        public string Color { get; set; }
        public DateTime? Create { get; set; }
    }
}
