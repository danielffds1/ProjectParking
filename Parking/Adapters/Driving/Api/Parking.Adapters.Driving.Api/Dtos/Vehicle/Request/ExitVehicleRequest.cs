namespace Parking.Adapters.Driving.Api.Dtos.Vehicle.Request
{
    public class ExitVehicleRequest
    {
        public string Plate { get; set; }
        public DateTime ExitTime { get; set; }
        public string PaymentMethod { get; set; }
    }
}
