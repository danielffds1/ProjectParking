namespace Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs
{
    public class ExitVehicleInput
    {
        public string Plate { get; set; }
        public DateTime ExitTime { get; set; }
        public string PaymentMethod { get; set; }
    }
}
