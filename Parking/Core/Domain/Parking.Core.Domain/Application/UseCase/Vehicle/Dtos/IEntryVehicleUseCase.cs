using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs;

namespace Parking.Core.Domain.Application.UseCase.Vehicle.Dtos
{
    public interface IEntryVehicleUseCase
    {
        Task<EntryVehicleOutput> ExecuteAsync(EntryVehicleInput request, CancellationToken cancellatonToken);
    }
}
