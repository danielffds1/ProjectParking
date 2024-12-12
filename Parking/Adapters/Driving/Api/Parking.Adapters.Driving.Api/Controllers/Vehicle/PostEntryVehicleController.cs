using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Request;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Response;
using Parking.Core.Domain.Adapters.Driving.Mappings;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;

namespace Parking.Adapters.Driving.Api.Controllers.Vehicle
{
    public class PostEntryVehicleController : ControllerBase
    {
        private readonly IEntryVehicleUseCase _postEntryVehicle;
        private readonly IMapperService _mapperService;
        private readonly IValidator<EntryVehicleRequest> _validator;
        private readonly ILogger<PostEntryVehicleController> _logger;
        public PostEntryVehicleController(
            IEntryVehicleUseCase postEntryVehicle,
            IMapperService mapperService,
            IValidator<EntryVehicleRequest> validator,
            ILogger<PostEntryVehicleController> logger
            )
        {
            _postEntryVehicle = postEntryVehicle;
            _mapperService = mapperService;
            _validator = validator;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/vehicle-entry")]
        public async Task<ActionResult<EntryVehicleResponse>> CreateVehicle([FromBody] EntryVehicleRequest request, CancellationToken cancellatonToken)
        {
            var validationInput = _validator.Validate(request);

            _logger.LogInformation("Iniciando a criação do veículo");
            if (!validationInput.IsValid)
            {
                _logger.LogWarning("Dados inválidos no pedido de criação de veículo");
                return BadRequest(validationInput);
            }

            //Mapear request para input
            var input = _mapperService.Map<EntryVehicleRequest, EntryVehicleInput>(request);
            try
            {
                var output = await _postEntryVehicle.ExecuteAsync(input, cancellatonToken);

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
                _logger.LogError(ex, "Erro ao criar veículo");
                return StatusCode(500, new { ErrorMessage = "Erro interno no servidor" });
            }
        }
    }
}
