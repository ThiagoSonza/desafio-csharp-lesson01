using FluentValidation;
using PropostaConsignado.Api.Dominio.Agentes.Aplicacao;

namespace PropostaConsignado.Api.Dominio.Agentes.Model
{
    public class AgenteValidator : AbstractValidator<CriarAgenteCommand>
    {
        public AgenteValidator()
        {
            RuleFor(v => v.Login).NotNull().WithMessage("O login do agente deve ser informado");
        }
    }
}