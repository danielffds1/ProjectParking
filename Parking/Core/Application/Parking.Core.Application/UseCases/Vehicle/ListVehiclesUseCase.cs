using Microsoft.Extensions.Logging;
using Parking.Adapters.Driven.MongoDB.Model;
using Parking.Core.Domain.Adapters.Driven.Storage.Repositories;
using Parking.Core.Domain.Adapters.Driving.Mappings;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs;

namespace Parking.Core.Application.UseCases.Vehicle
{
    public class ListVehiclesUseCase : IListVehicleUseCase
    {
        private readonly ILogger<ListVehiclesUseCase> _logger;
        private readonly IMapperService _mapperService;
        private readonly IGenericRepositoryMongo<ParkingRecordsEntity> _vehicleRepository;

        public ListVehiclesUseCase(
            ILogger<ListVehiclesUseCase> logger,
            IMapperService mapperService,
            IGenericRepositoryMongo<ParkingRecordsEntity> vehicleRepository
            )
        {
            _logger = logger;
            _mapperService = mapperService;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<ListVehicleOutput> ExecuteAsync(CancellationToken cancellatonToken)
        {
            _logger.LogInformation("ListVehiclesUseCase.ExecuteAsync");
            try
            {
                var listVehicle = await _vehicleRepository.GetAllAsync();

                if (listVehicle == null)
                {
                    return new ListVehicleOutput
                    {
                        Message = "Nenhum veículo encontrado",
                        IsSuccess = false
                    };
                }

                var vehicleDtos = listVehicle.Select(vehicle => _mapperService.Map<ParkingRecordsEntity, ListVehicleOutput.ListVehicleReponseDto>(vehicle)).ToList();

                return new ListVehicleOutput
                {
                    Vehicles = vehicleDtos,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar veículos");
            }
            return new ListVehicleOutput();
        }
    }
}
