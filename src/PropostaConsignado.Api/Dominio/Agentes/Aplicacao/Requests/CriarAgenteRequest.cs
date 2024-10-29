
using CSharpFunctionalExtensions;

namespace PropostaConsignado.Api.Dominio.Agentes.Aplicacao.Requests
{
    public record CriarAgenteRequest
    {
        public string Login { get; set; } = null!;
        public bool Ativo { get; set; }

        public Result<CriarAgenteCommand> CriarComando()
            => CriarAgenteCommand.Criar(Login, true);
    }
}