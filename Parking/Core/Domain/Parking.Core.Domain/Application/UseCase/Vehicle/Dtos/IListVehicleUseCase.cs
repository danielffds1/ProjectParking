using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs;

namespace Parking.Core.Domain.Application.UseCase.Vehicle.Dtos
{
    public interface IListVehicleUseCase
    {
        Task<ListVehicleOutput> ExecuteAsync(CancellationToken cancellatonToken);
    }
}
