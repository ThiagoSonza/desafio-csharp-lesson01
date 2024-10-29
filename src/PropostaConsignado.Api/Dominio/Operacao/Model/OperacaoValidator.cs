using FluentValidation;
using PropostaConsignado.Api.Dominio.Operacao.Aplicacao;

namespace PropostaConsignado.Api.Dominio.Operacao.Model
{
    public class OperacaoValidator : AbstractValidator<CriarOperacaoCommand>
    {
        public OperacaoValidator()
        {
            RuleFor(v => v.Descricao).NotNull().WithMessage("A descrição deve ser informada.");
        }
    }
}