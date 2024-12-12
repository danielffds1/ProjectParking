using Parking.Core.Domain.Common;
using static Parking.Adapters.Driving.Api.Dtos.Vehicle.Response.EntryVehicleResponse;

namespace Parking.Adapters.Driving.Api.Dtos.Vehicle.Response
{
    public class EntryVehicleResponse : BaseOutput<EntryVehicleOutputDto>
    {
        public EntryVehicleResponse() { }
        public EntryVehicleOutputDto entryVehicleResponse { get; set; }

        public class EntryVehicleOutputDto
        {
            public string Plate { get; set; }
            public string Model { get; set; }
            //Marca do veículo
            public string Brand { get; set; }
            public string Owner { get; set; }
            public DateTime EntryTime { get; set; }
            public string EmployerId { get; set; }
            //Carro, moto etc
            public string VehicleType { get; set; }
            public string AllocatedParkingSpace { get; set; }
        }
    }
}
