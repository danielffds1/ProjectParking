using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs;

namespace Parking.Core.Domain.Application.UseCase.Vehicle.Dtos
{
    public interface ICreateVehicleUseCase
    {
        Task<CreateVehicleOutput> ExecuteAsync(CreateVehicleInput request, CancellationToken cancellatonToken);
    }
}
