using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Parking.Core.Domain.Enums;

namespace Parking.Adapters.Driven.MongoDB.Model
{
    public class VehicleEntityBase
    {
        public string Plate { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Owner { get; set; }
        public string EmployerId { get; set; }
        public string VehicleType { get; set; }

        [BsonRepresentation(BsonType.String)]
        public VehicleStatus Status { get; set; }
    }
}
