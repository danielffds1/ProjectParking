using Microsoft.Extensions.Logging;
using Parking.Adapters.Driven.MongoDB.Model;
using Parking.Core.Domain.Adapters.Driven.Storage.Repositories;
using Parking.Core.Domain.Adapters.Driving.Mappings;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs;

namespace Parking.Core.Application.UseCases.Vehicle
{
    public class CreateVehicleUseCase : ICreateVehicleUseCase
    {
        private readonly ILogger<CreateVehicleUseCase> _logger;
        private readonly IGenericRepositoryMongo<RegisterVehicleEntity> _vehicleRepository;
        private readonly IMapperService _mapperService;
        public CreateVehicleUseCase(
            ILogger<CreateVehicleUseCase> logger,
            IGenericRepositoryMongo<RegisterVehicleEntity> vehicleRepository,
            IMapperService mapperService
         )
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
            _mapperService = mapperService;
        }
        public async Task<CreateVehicleOutput> ExecuteAsync(CreateVehicleInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateVehicleUseCase.ExecuteAsync");

            try
            {
                var existVehicle = await _vehicleRepository.GetByPlateAsync(request.Plate);

                if (existVehicle != null)
                {
                    return new CreateVehicleOutput
                    {
                        Message = "Veículo já cadastrado",
                        IsSuccess = false,
                        BusinessRuleViolation = true

                    };
                }

                var registerVehicleDB = _mapperService.Map<CreateVehicleInput, RegisterVehicleEntity>(request);

                await _vehicleRepository.InsertAsync(registerVehicleDB);

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
