using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Parking.Adapters.Driven.MongoDB.Model;
using Parking.Core.Domain.Adapters.Driven.Storage.Repositories;
using Parking.Core.Domain.Adapters.Driving.Mappings;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs;
using Parking.Core.Domain.Enums;

namespace Parking.Core.Application.UseCases.Vehicle
{
    public class ExitVehicleUseCase : IExitVehicleUseCase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ExitVehicleUseCase> _logger;
        private readonly IGenericRepositoryMongo<ParkingRecordsEntity> _vehicleRepository;
        private readonly IMapperService _mapperService;
        private readonly double _tarifaPorHora = 5.0;

        public ExitVehicleUseCase(
            IConfiguration configuration,
            ILogger<ExitVehicleUseCase> logger,
            IGenericRepositoryMongo<ParkingRecordsEntity> vehicleRepository,
            IMapperService mapperService
         )
        {
            _configuration = configuration;
            _logger = logger;
            _mapperService = mapperService;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<ExitVehicleOutput> ExecuteAsync(ExitVehicleInput request, CancellationToken cancellatonToken)
        {
            _logger.LogInformation("ExitVehicleUseCase.ExecuteAsync");

            double TarifaPorHora = _tarifaPorHora;

            try
            {

                var vehicle = await _vehicleRepository.GetByPlateAsync(request.Plate);

                if (vehicle == null)
                {
                    return new ExitVehicleOutput
                    {
                        Message = "Veículo não encontrado",
                        IsSuccess = false
                    };
                }

                if (vehicle.Status == VehicleStatus.Exited)
                {
                    return new ExitVehicleOutput
                    {
                        Message = "Veículo já saiu do estacionamento",
                        IsSuccess = false
                    };
                }

                // Calcular o tempo de permanência
                var entryTime = vehicle.EntryTime;
                var exitTime = request.ExitTime;
                var tempoDePermanencia = exitTime - entryTime;

                // Calcular o valor da saída
                var horasDePermanencia = Math.Ceiling(tempoDePermanencia.TotalHours);
                var valorDaSaida = horasDePermanencia * TarifaPorHora;

                // Formatar o tempo de permanência em horas e minutos
                var horas = (int)tempoDePermanencia.TotalHours;
                var minutos = tempoDePermanencia.Minutes;

                vehicle.Status = VehicleStatus.Exited;
                vehicle.ExitTime = exitTime;

                await _vehicleRepository.UpdateAsync(vehicle.Id, vehicle);

                return new ExitVehicleOutput
                {
                    Message = $"Veículo cadastrado com sucesso. Tempo de permanência: {horas} horas e {minutos} minutos. Valor da saída: R$ {valorDaSaida:F2}.",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ExitVehicleUseCase.ExecuteAsync");
            }
            return new ExitVehicleOutput();
        }
    }
}
