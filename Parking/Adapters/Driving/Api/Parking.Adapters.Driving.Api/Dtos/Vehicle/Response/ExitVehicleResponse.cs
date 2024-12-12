using Parking.Core.Domain.Common;
using static Parking.Adapters.Driving.Api.Dtos.Vehicle.Response.ExitVehicleResponse;

namespace Parking.Adapters.Driving.Api.Dtos.Vehicle.Response
{
    public class ExitVehicleResponse : BaseOutput<ExitVehicleOutputDto>
    {
        public ExitVehicleResponse() { }
        public ExitVehicleOutputDto entryVehicleResponse { get; set; }

        public class ExitVehicleOutputDto
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
