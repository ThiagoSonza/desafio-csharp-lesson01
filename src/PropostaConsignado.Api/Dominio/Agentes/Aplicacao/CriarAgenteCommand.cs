using System.Text;
using CSharpFunctionalExtensions;
using MediatR;
using PropostaConsignado.Api.Dominio.Agentes.Model;

namespace PropostaConsignado.Api.Dominio.Agentes.Aplicacao
{
    public record CriarAgenteCommand : IRequest<Result<AgenteDominio>>
    {
        private CriarAgenteCommand(string login, bool ativo)
        {
            Login = login;
            Ativo = ativo;
        }

        public string Login { get; }
        public bool Ativo { get; }

        public static Result<CriarAgenteCommand> Criar(string login, bool ativo)
        {
            CriarAgenteCommand command = new(login, ativo);

            var validation = new AgenteValidator().Validate(command);
            if (validation.IsValid)
                return Result.Success(command);

            var errors = validation.Errors.Select(err => err.ErrorMessage);
            StringBuilder errorMessage = new();
            foreach (string error in errors)
                errorMessage.Append(error).AppendJoin(". ");

            return Result.Failure<CriarAgenteCommand>(errorMessage.ToString());
        }
    }
}