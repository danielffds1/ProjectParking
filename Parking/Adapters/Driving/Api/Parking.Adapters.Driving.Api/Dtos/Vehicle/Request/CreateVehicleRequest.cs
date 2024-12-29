namespace Parking.Adapters.Driving.Api.Dtos.Vehicle.Request
{
    public class CreateVehicleRequest : VehicleRequestBase
    {
        public string Color { get; set; }
        public DateTime? DateOfCreation { get; set; }
    }
}
