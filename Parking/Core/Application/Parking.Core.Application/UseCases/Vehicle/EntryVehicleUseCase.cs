using Microsoft.Extensions.Logging;
using Parking.Adapters.Driven.MongoDB.Model;
using Parking.Core.Domain.Adapters.Driven.Storage.Repositories;
using Parking.Core.Domain.Adapters.Driving.Mappings;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs;
using Parking.Core.Domain.Entity;

namespace Parking.Core.Application.UseCases.Vehicle
{
    public class EntryVehicleUseCase : IEntryVehicleUseCase
    {
        private readonly ILogger<EntryVehicleUseCase> _logger;
        private readonly IGenericRepositoryMongo<EntryVehicleEntity> _vehicleRepository;
        private readonly IMapperService _mapperService;
        public EntryVehicleUseCase(
            ILogger<EntryVehicleUseCase> logger,
            IGenericRepositoryMongo<EntryVehicleEntity> vehicleRepository,
            IMapperService mapperService
         )
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
            _mapperService = mapperService;
        }
        public async Task<EntryVehicleOutput> ExecuteAsync(EntryVehicleInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateVehicleUseCase.ExecuteAsync");

            try
            {
                var entryVehicle = new EntryVehicle
                {
                    Plate = request.Plate,
                    Model = request.Model,
                    Brand = request.Brand,
                    Owner = request.Owner,
                    EntryTime = request.EntryTime,
                    EmployerId = request.EmployerId,
                    VehicleType = request.VehicleType,
                    AllocatedParkingSpace = request.AllocatedParkingSpace
                };

                var entryVehicleDB = _mapperService.Map<EntryVehicle, EntryVehicleEntity>(entryVehicle);

                await _vehicleRepository.InsertAsync(entryVehicleDB);

                return new EntryVehicleOutput
                {
                    Message = "Veículo cadastrado com sucesso",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateVehicleUseCase.ExecuteAsync");
            }

            return new EntryVehicleOutput();
        }
    }
}
