using FluentValidation;
using PropostaConsignado.Api.Dominio.Proposta.Aplicacao;

namespace PropostaConsignado.Api.Dominio.Proposta.Model
{
    public class PropostaValidator : AbstractValidator<CriaPropostaCommand>
    {
        public PropostaValidator()
        {
            RuleFor(v => v.Agente).NotNull().WithMessage("O agente é inválido");

            RuleFor(v => v.ValorEmprestimo).NotNull().WithMessage("O valor do empréstimo deve ser informado");
            RuleFor(v => v.ParcelasEmprestimo).NotNull().WithMessage("A quantia de parcelas deve ser informada");
            RuleFor(v => v.Convenio).NotNull().WithMessage("O código do convênio deve ser informado");
            RuleFor(v => v.Operacao).NotNull().WithMessage("O código da operação deve ser informado");

            RuleFor(v => v.Cpf).NotNull().WithMessage("O cpf do proponente deve ser informado");
            RuleFor(v => v.Nome).NotNull().WithMessage("O nome do proponente deve ser informado");
            RuleFor(v => v.DataNascimento).NotNull().WithMessage("A data de nascimento do proponente deve ser informada");
            RuleFor(v => v.Ddd).NotNull().WithMessage("O DDD do telefone do proponente deve ser informado");
            RuleFor(v => v.Telefone).NotNull().WithMessage("O telefone do proponente deve ser informado");
            RuleFor(v => v.Email).NotNull().WithMessage("O e-mail do proponente deve ser informado");
            RuleFor(v => v.Estado).NotNull().WithMessage("O Estado do proponente deve ser informada");
            RuleFor(v => v.Localidade).NotNull().WithMessage("A localidade do proponente deve ser informada");
            RuleFor(v => v.Bairro).NotNull().WithMessage("O bairro do proponente deve ser informado");
            RuleFor(v => v.Logradouro).NotNull().WithMessage("O logradouro do proponente deve ser informado");
            RuleFor(v => v.Numero).NotNull().WithMessage("O número da residência do proponente deve ser informado");
            RuleFor(v => v.Complemento).NotNull().WithMessage("O complemento da residência do proponente deve ser informado");
            RuleFor(v => v.Rendimento).NotNull().WithMessage("O rendimento mensal do proponente deve ser informado");
        }
    }
}