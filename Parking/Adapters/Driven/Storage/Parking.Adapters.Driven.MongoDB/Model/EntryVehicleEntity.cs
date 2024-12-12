using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Parking.Adapters.Driven.MongoDB.Model
{
    public class EntryVehicleEntity : VehicleEntityBase
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public string AllocatedParkingSpace { get; set; }
    }
}
