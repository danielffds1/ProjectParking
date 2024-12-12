using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Parking.Adapters.Driven.MongoDB.Model
{
    public class RegisterVehicleEntity : VehicleEntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Color { get; set; }
        public DateTime? ExitTime { get; set; }
    }
}
