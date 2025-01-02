using Parking.Core.Domain.Common;
using static Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs.ListVehicleOutput;

namespace Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs
{
    public class ListVehicleOutput : BaseOutput<List<ListVehicleReponseDto>>
    {
        public ListVehicleOutput()
        {
            Vehicles = new List<ListVehicleReponseDto>();
        }
        public List<ListVehicleReponseDto> Vehicles { get; set; }
        public class ListVehicleReponseDto
        {
            public string Id { get; set; }
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
