using Parking.Core.Domain.Common;
using static Parking.Adapters.Driving.Api.Dtos.Vehicle.Response.CreateVehicleResponse;

namespace Parking.Adapters.Driving.Api.Dtos.Vehicle.Response
{
    public class CreateVehicleResponse : BaseOutput<VehicleOutputDto>
    {
        public CreateVehicleResponse() { }
        public VehicleOutputDto vehicleResponse { get; set; }

        public class VehicleOutputDto
        {
            public int Id { get; set; }
            public string Plate { get; set; }
            public string Model { get; set; }
            public string Brand { get; set; }
            public string Color { get; set; }
            public string Owner { get; set; }
            public DateTime EntryTime { get; set; }
            public DateTime? ExitTime { get; set; }
            public string EmployerId { get; set; }
            public string VehicleType { get; set; }
        }
    }
}
