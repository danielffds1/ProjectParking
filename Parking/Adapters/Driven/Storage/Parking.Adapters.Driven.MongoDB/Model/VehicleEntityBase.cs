namespace Parking.Adapters.Driven.MongoDB.Model
{
    public class VehicleEntityBase
    {
        public string Plate { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Owner { get; set; }
        public DateTime EntryTime { get; set; }
        public string EmployerId { get; set; }
        public string VehicleType { get; set; }
    }
}
