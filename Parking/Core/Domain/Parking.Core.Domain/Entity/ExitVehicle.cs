namespace Parking.Core.Domain.Entity
{
    public class ExitVehicle : VehicleBase
    {
        public string Plate { get; set; }
        public DateTime ExitTime { get; set; }
        public string PaymentMethod { get; set; }
    }
}
