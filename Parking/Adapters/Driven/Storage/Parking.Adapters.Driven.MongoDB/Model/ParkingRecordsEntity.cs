using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Parking.Adapters.Driven.MongoDB.Model
{
    public class ParkingRecordsEntity : VehicleEntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Color { get; set; }
        public string AllocatedParkingSpace { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public string PaymentMethod { get; set; }
    }
}
