using Microsoft.Extensions.Logging;
using Parking.Core.Domain.Adapters.Driven.Storage.Repositories;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs;
using Parking.Core.Domain.Entity;

namespace Parking.Core.Application.UseCases.Vehicle
{
    public class CreateVehicleUseCase : ICreateVehicleUseCase
    {
        private readonly ILogger<CreateVehicleUseCase> _logger;
        private readonly IGenericRepositoryMongo<RegisterVehicle> _vehicleRepository;
        public CreateVehicleUseCase(
            ILogger<CreateVehicleUseCase> logger,
            IGenericRepositoryMongo<RegisterVehicle> vehicleRepository
         )
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
        }
        public async Task<CreateVehicleOutput> ExecuteAsync(CreateVehicleInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateVehicleUseCase.ExecuteAsync");

            try
            {
                var registerVehicle = new RegisterVehicle
                {
                    Plate = request.Plate,
                    Model = request.Model,
                    Brand = request.Brand,
                    Color = request.Color,
                    Owner = request.Owner,
                    EntryTime = request.EntryTime,
                    ExitTime = request.ExitTime,
                    EmployerId = request.EmployerId,
                    VehicleType = request.VehicleType
                };

                await _vehicleRepository.InsertAsync(registerVehicle);

                return new CreateVehicleOutput
                {
                    Message = "Veículo cadastrado com sucesso",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateVehicleUseCase.ExecuteAsync");
            }

            return new CreateVehicleOutput();
        }
    }
}
