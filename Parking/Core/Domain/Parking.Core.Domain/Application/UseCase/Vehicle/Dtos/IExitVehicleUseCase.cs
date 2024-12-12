using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs;

namespace Parking.Core.Domain.Application.UseCase.Vehicle.Dtos
{
    public interface IExitVehicleUseCase
    {
        Task<ExitVehicleOutput> ExecuteAsync(ExitVehicleInput request, CancellationToken cancellatonToken);
    }
}
