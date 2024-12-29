using Parking.Core.Domain.Enums;

namespace Parking.Core.Domain.Entity
{
    public class VehicleBase
    {
        public string Id { get; set; }
        public string Plate { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Owner { get; set; }
        public string EmployerId { get; set; }
        public string VehicleType { get; set; }
        public VehicleStatus Status { get; set; }
    }
}
