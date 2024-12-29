using Parking.Core.Domain.Common;
using static Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs.CreateVehicleOutput;

namespace Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs
{
    public class CreateVehicleOutput : BaseOutput<VehicleOutputDto>
    {
        public CreateVehicleOutput() : base()
        {
        }
        public VehicleOutputDto vehicle { get; set; }

        public class VehicleOutputDto
        {
            public int Id { get; set; }
            public string Plate { get; set; }
            public string Model { get; set; }
            public string Brand { get; set; }
            public string Color { get; set; }
            public string Owner { get; set; }
            public DateTime EntryTime { get; set; }
            public string EmployerId { get; set; }
            public string VehicleType { get; set; }
        }
    }
}
