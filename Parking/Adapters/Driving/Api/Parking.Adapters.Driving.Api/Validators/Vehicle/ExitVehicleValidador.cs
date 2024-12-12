using FluentValidation;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Request;

namespace Parking.Adapters.Driving.Api.Mapppings
{
    public class ExitVehicleValidador : AbstractValidator<ExitVehicleRequest>
    {
        public ExitVehicleValidador()
        {
            RuleFor(x => x.Plate)
                .NotEmpty().WithMessage("A placa do veículo é obrigatória.")
                .MaximumLength(10).WithMessage("A placa não pode exceder 10 caracteres.")
                .Matches(@"^[A-Za-z0-9-]+$").WithMessage("A placa deve conter apenas letras, números e hifens.");

            RuleFor(x => x.ExitTime)
                .NotEmpty().WithMessage("A data e hora de saída são obrigatórias.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de saída não pode ser no futuro.");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("O método de pagamento é obrigatório.")
                .Must(pm => pm == "Dinheiro" || pm == "Cartão" || pm == "Pix")
                .WithMessage("O método de pagamento deve ser 'Dinheiro', 'Cartão' ou 'Pix'.");
        }
    }
}
