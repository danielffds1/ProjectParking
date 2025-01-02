using Parking.Core.Domain.Common;
using static Parking.Adapters.Driving.Api.Dtos.Vehicle.Response.ListVehicleResponse;

namespace Parking.Adapters.Driving.Api.Dtos.Vehicle.Response
{
    public class ListVehicleResponse : BaseOutput<List<ListVehicleReponseDto>>
    {
        public ListVehicleResponse()
        {
            Vehicles = new List<ListVehicleReponseDto>();
        }
        public List<ListVehicleReponseDto> Vehicles { get; set; }

        public class ListVehicleReponseDto
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
