using MongoDB.Bson.Serialization.Attributes;

namespace Parking.Adapters.Driven.MongoDB.Model
{
    public class ExitVehicleEntity : VehicleEntityBase
    {
        [BsonIgnore]
        public string Plate { get; set; }
        public DateTime ExitTime { get; set; }
        public string PaymentMethod { get; set; }
    }
}
