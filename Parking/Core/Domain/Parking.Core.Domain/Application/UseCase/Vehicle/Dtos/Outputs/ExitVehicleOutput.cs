using Parking.Core.Domain.Common;

namespace Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs
{
    public class ExitVehicleOutput : BaseOutput<ExitVehicleOutput>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
