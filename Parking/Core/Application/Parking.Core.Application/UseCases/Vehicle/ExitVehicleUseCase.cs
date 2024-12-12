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
    public class ExitVehicleUseCase : IExitVehicleUseCase
    {
        private readonly ILogger<ExitVehicleUseCase> _logger;
        private readonly IGenericRepositoryMongo<ExitVehicleEntity> _vehicleRepository;
        private readonly IGenericRepositoryMongo<EntryVehicleEntity> _vehicleEntryRepository;
        private readonly IMapperService _mapperService;
        public ExitVehicleUseCase(
            ILogger<ExitVehicleUseCase> logger,
            IGenericRepositoryMongo<ExitVehicleEntity> vehicleRepository,
            IGenericRepositoryMongo<EntryVehicleEntity> vehicleEntryRepository,
            IMapperService mapperService
         )
        {
            _logger = logger;
            _mapperService = mapperService;
            _vehicleRepository = vehicleRepository;
            _vehicleEntryRepository = vehicleEntryRepository;
        }

        public async Task<ExitVehicleOutput> ExecuteAsync(ExitVehicleInput request, CancellationToken cancellatonToken)
        {
            _logger.LogInformation("ExitVehicleUseCase.ExecuteAsync");

            double TarifaPorHora = 10.0;

            try
            {
                var exitVehicle = new ExitVehicle
                {
                    Plate = request.Plate,
                    ExitTime = request.ExitTime,
                    PaymentMethod = request.PaymentMethod
                };

                var vehicle = await _vehicleEntryRepository.GetByPlateAsync(exitVehicle.Plate);

                if (vehicle == null)
                {
                    return new ExitVehicleOutput
                    {
                        Message = "Veículo não encontrado",
                        IsSuccess = false
                    };
                }

                // Calcular o tempo de permanência
                var entryTime = vehicle.EntryTime;
                var exitTime = exitVehicle.ExitTime;
                var tempoDePermanencia = exitTime - entryTime;

                // Calcular o valor da saída
                var horasDePermanencia = Math.Ceiling(tempoDePermanencia.TotalHours);
                var valorDaSaida = horasDePermanencia * TarifaPorHora;

                // Mapear e inserir a entidade de saída
                var exitVehicleDB = _mapperService.Map<ExitVehicle, ExitVehicleEntity>(exitVehicle);
                await _vehicleRepository.InsertAsync(exitVehicleDB);

                return new ExitVehicleOutput

                {
                    Message = $"Veículo cadastrado com sucesso. Tempo de permanência: {tempoDePermanencia.TotalHours:F2} horas. Valor da saída: R${valorDaSaida:F2}.",
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
