using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Request;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Response;
using Parking.Core.Domain.Adapters.Driving.Mappings;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;

namespace Parking.Adapters.Driving.Api.Controllers.Vehicle
{
    public class PostExitVehicleController : ControllerBase
    {
        private readonly IExitVehicleUseCase _postExitVehicle;
        private readonly IMapperService _mapperService;
        private readonly IValidator<ExitVehicleRequest> _validator;
        private readonly ILogger<PostExitVehicleController> _logger;
        public PostExitVehicleController(
            IExitVehicleUseCase postExitVehicle,
            IMapperService mapperService,
            IValidator<ExitVehicleRequest> validator,
            ILogger<PostExitVehicleController> logger
            )
        {
            _postExitVehicle = postExitVehicle;
            _mapperService = mapperService;
            _validator = validator;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/vehicle-exit")]
        public async Task<ActionResult<ExitVehicleResponse>> ExitVehicle([FromBody] ExitVehicleRequest request, CancellationToken cancellatonToken)
        {
            var validationInput = _validator.Validate(request);

            _logger.LogInformation("Saída do veículo do parking");
            if (!validationInput.IsValid)
            {
                _logger.LogWarning("Dados inválidos para saída do veículo");
                return BadRequest(validationInput);
            }

            //Mapear request para input
            var input = _mapperService.Map<ExitVehicleRequest, ExitVehicleInput>(request);
            try
            {
                var output = await _postExitVehicle.ExecuteAsync(input, cancellatonToken);

                if (output.IsSuccess)
                {
                    return Ok(output.Message);
                }

                if (output.BusinessRuleViolation)
                {
                    return UnprocessableEntity(output);
                }

                return StatusCode(500, output.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro na saída do veículo");
                return StatusCode(500, new { ErrorMessage = "Erro interno no servidor" });
            }
        }
    }
}
