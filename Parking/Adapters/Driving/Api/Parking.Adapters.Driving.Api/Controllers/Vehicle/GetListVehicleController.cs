using Microsoft.AspNetCore.Mvc;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Response;
using Parking.Core.Domain.Adapters.Driving.Mappings;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos;

namespace Parking.Adapters.Driving.Api.Controllers.Vehicle
{
    public class GetListVehicleController : ControllerBase
    {
        private readonly IMapperService _mapperService;
        private readonly IListVehicleUseCase _getListVehicle;
        private readonly ILogger<GetListVehicleController> _logger;
        public GetListVehicleController(
            IMapperService mapperService,
            IListVehicleUseCase getListVehicle,
            ILogger<GetListVehicleController> logger
            )
        {
            _mapperService = mapperService;
            _getListVehicle = getListVehicle;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/vehicle-list")]
        public async Task<ActionResult<CreateVehicleResponse>> CreateVehicle(CancellationToken cancellatonToken)
        {

            try
            {
                var output = await _getListVehicle.ExecuteAsync(cancellatonToken);

                if (output.IsSuccess)
                {
                    return Ok(output);
                }

                if (output.BusinessRuleViolation)
                {
                    return UnprocessableEntity(output);
                }

                return StatusCode(500, output.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar veículo");
                return StatusCode(500, new { ErrorMessage = "Erro interno no servidor" });
            }
        }
    }
}
