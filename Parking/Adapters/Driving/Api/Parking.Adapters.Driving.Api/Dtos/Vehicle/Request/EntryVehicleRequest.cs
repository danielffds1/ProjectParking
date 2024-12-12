namespace Parking.Adapters.Driving.Api.Dtos.Vehicle.Request
{
    public class EntryVehicleRequest : VehicleRequestBase
    {
        public DateTime EntryTime { get; set; }
        public string AllocatedParkingSpace { get; set; }
    }
}
