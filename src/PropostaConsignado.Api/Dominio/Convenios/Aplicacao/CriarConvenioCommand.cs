using System.Text;
using CSharpFunctionalExtensions;
using MediatR;
using PropostaConsignado.Api.Dominio.Convenios.Model;

namespace PropostaConsignado.Api.Dominio.Convenios.Aplicacao
{
    public record CriarConvenioCommand : IRequest<Result<ConvenioDominio>>
    {
        private CriarConvenioCommand(string descricao, int operacao)
        {
            Descricao = descricao;
            Operacao = operacao;
        }

        public string Descricao { get; } = null!;
        public int Operacao { get; }

        public static Result<CriarConvenioCommand> Criar(string descricao, int operacao)
        {
            CriarConvenioCommand command = new(descricao, operacao);

            var validation = new ConvenioValidator().Validate(command);
            if (validation.IsValid)
                return Result.Success(command);

            var errors = validation.Errors.Select(err => err.ErrorMessage);
            StringBuilder errorMessage = new();
            foreach (string error in errors)
                errorMessage.Append(error).AppendJoin(". ");

            return Result.Failure<CriarConvenioCommand>(errorMessage.ToString());
        }
    }
}