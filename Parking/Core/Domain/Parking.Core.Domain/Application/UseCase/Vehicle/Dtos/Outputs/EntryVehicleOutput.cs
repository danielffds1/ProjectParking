using Parking.Core.Domain.Common;
using static Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs.EntryVehicleOutput;

namespace Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs
{
    public class EntryVehicleOutput : BaseOutput<EntryOutputDto>
    {
        public EntryVehicleOutput() : base()
        {
        }
        public EntryOutputDto entryVehicle { get; set; }

        public class EntryOutputDto
        {
            public int Id { get; set; }
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
