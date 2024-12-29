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

            RuleFor(x => x.Owner)
                .NotEmpty().WithMessage("O nome do proprietário do veículo é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do proprietário não pode exceder 100 caracteres.");

            RuleFor(x => x.EmployerId)
                .NotEmpty().WithMessage("O ID do funcionário responsável é obrigatório.")
                .Length(5, 50).WithMessage("O ID do funcionário deve ter entre 5 e 50 caracteres.");

            RuleFor(x => x.Color)
               .NotEmpty().WithMessage("A cor do veículo é obrigatória.");

            RuleFor(x => x.VehicleType)
                .NotEmpty().WithMessage("O tipo de veículo é obrigatório.")
                .Must(vt => vt == "Carro" || vt == "Moto" || vt == "Caminhao" || vt == "Outro")
                .WithMessage("O tipo de veículo deve ser 'Carro', 'Moto', 'Caminhao' ou 'Outro'.");
        }
    }
}
