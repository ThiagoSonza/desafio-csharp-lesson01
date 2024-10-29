using System.Text;
using CSharpFunctionalExtensions;
using MediatR;
using PropostaConsignado.Api.Dominio.Operacao.Model;

namespace PropostaConsignado.Api.Dominio.Operacao.Aplicacao
{
    public record CriarOperacaoCommand : IRequest<Result<OperacaoDominio>>
    {
        private CriarOperacaoCommand(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; } = null!;

        public static Result<CriarOperacaoCommand> Criar(string descricao)
        {
            CriarOperacaoCommand command = new(descricao);

            var validation = new OperacaoValidator().Validate(command);
            if (validation.IsValid)
                return Result.Success(command);

            var errors = validation.Errors.Select(err => err.ErrorMessage);
            StringBuilder errorMessage = new();
            foreach (string error in errors)
                errorMessage.Append(error).AppendJoin(". ");

            return Result.Failure<CriarOperacaoCommand>(errorMessage.ToString());
        }
    }
}