using CSharpFunctionalExtensions;
using PropostaConsignado.Api.Dominio.Proposta.Model;

namespace PropostaConsignado.Api.Dominio.Agentes.Model
{
    public class AgenteDominio
    {
        private AgenteDominio(string login, bool ativo)
        {
            Login = login;
            Ativo = ativo;
        }

        public int Id { get; }
        public bool Ativo { get; }
        public string Login { get; } = null!;
        public IEnumerable<PropostaDominio>? Propostas { get; }

        public static Result<AgenteDominio> Criar(string login, bool ativo = true)
        {
            var agente = new AgenteDominio(login, ativo);
            return Result.Success(agente);
        }
    }
}