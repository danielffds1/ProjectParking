using FluentValidation;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Request;

namespace Parking.Adapters.Driving.Api.Mapppings
{
    public class CreateVehicleValidador : AbstractValidator<CreateVehicleRequest>
    {

        public CreateVehicleValidador()
        {
            RuleFor(x => x.Plate)
              .NotEmpty().WithMessage("A placa do veículo é obrigatória.")
              .MaximumLength(10).WithMessage("A placa não pode exceder 10 caracteres.");

            RuleFor(x => x.Model)
               .NotEmpty().WithMessage("O modelo do veículo é obrigatório.");

            RuleFor(x => x.Brand)
               .NotEmpty().WithMessage("A marca do veículo é obrigatória.");

            RuleFor(x => x.Color)
               .NotEmpty().WithMessage("A cor do veículo é obrigatória.");
        }
    }
}
