namespace Parking.Adapters.Driving.Api.Dtos.Vehicle.Request
{
    public class VehicleRequestBase
    {
        public string Plate { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Owner { get; set; }
        public string EmployerId { get; set; }
        public string VehicleType { get; set; }
    }
}
