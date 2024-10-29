using FluentValidation;
using PropostaConsignado.Api.Dominio.Convenios.Aplicacao;

namespace PropostaConsignado.Api.Dominio.Convenios.Model
{
    public class ConvenioValidator : AbstractValidator<CriarConvenioCommand>
    {
        public ConvenioValidator()
        {
            RuleFor(v => v.Descricao).NotNull().WithMessage("A descrição deve ser informada");
            RuleFor(v => v.Operacao).NotNull().WithMessage("A operação deve ser informada");
        }
    }
}