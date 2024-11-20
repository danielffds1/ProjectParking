using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Request;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Response;
using Parking.Core.Domain.Adapters.Driving.Mappings;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;

namespace Parking.Adapters.Driving.Api.Controllers.Vehicle
{
    public class PostCreateVehicleController : ControllerBase
    {
        private readonly ICreateVehicleUseCase _postCreateVehicle;
        private readonly IMapperService _mapperService;
        private readonly IValidator<CreateVehicleRequest> _validator;
        private readonly ILogger<PostCreateVehicleController> _logger;
        public PostCreateVehicleController(
            ICreateVehicleUseCase postCreateVehicle,
            IMapperService mapperService,
            IValidator<CreateVehicleRequest> validator,
            ILogger<PostCreateVehicleController> logger
            )
        {
            _postCreateVehicle = postCreateVehicle;
            _mapperService = mapperService;
            _validator = validator;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/vehicle")]
        public async Task<ActionResult<CreateVehicleResponse>> CreateVehicle([FromBody] CreateVehicleRequest request, CancellationToken cancellatonToken)
        {
            var validationInput = _validator.Validate(request);

            _logger.LogInformation("Iniciando a criação do veículo");
            if (!validationInput.IsValid)
            {
                _logger.LogWarning("Dados inválidos no pedido de criação de veículo");
                return BadRequest(validationInput);
            }

            //Mapear request para input
            var input = _mapperService.Map<CreateVehicleRequest, CreateVehicleInput>(request);
            try
            {
                var output = await _postCreateVehicle.ExecuteAsync(input, cancellatonToken);

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
