using FluentValidation;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Request;

namespace Parking.Adapters.Driving.Api.Mapppings
{
    public class EntryVehicleValidador : AbstractValidator<EntryVehicleRequest>
    {
        public EntryVehicleValidador()
        {
            RuleFor(x => x.Plate)
            .NotEmpty().WithMessage("A placa do veículo é obrigatória.")
            .MaximumLength(10).WithMessage("A placa não pode exceder 10 caracteres.")
            .Matches(@"^[A-Za-z0-9-]+$").WithMessage("A placa deve conter apenas letras, números e hifens.");

            RuleFor(x => x.Model)
                .NotEmpty().WithMessage("O modelo do veículo é obrigatório.");

            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("A marca do veículo é obrigatória.");

            RuleFor(x => x.Owner)
                .NotEmpty().WithMessage("O nome do proprietário do veículo é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do proprietário não pode exceder 100 caracteres.");

            RuleFor(x => x.EntryTime)
                .NotEmpty().WithMessage("A data e hora de entrada são obrigatórias.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de entrada não pode ser no futuro.");

            RuleFor(x => x.EmployerId)
                .NotEmpty().WithMessage("O ID do funcionário responsável é obrigatório.")
                .Length(5, 50).WithMessage("O ID do funcionário deve ter entre 5 e 50 caracteres.");

            RuleFor(x => x.VehicleType)
                .NotEmpty().WithMessage("O tipo de veículo é obrigatório.")
                .Must(vt => vt == "Carro" || vt == "Moto" || vt == "Caminhao" || vt == "Outro")
                .WithMessage("O tipo de veículo deve ser 'Carro', 'Moto', 'Caminhao' ou 'Outro'.");

            RuleFor(x => x.AllocatedParkingSpace)
                .NotEmpty().WithMessage("A vaga alocada é obrigatória.")
                .Matches(@"^[A-Za-z0-9]+$").WithMessage("A vaga deve conter apenas letras e números.")
                .MaximumLength(10).WithMessage("A vaga não pode exceder 10 caracteres.");
        }
    }
}
