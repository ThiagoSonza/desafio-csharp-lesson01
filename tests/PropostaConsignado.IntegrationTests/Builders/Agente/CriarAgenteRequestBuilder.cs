using Bogus;
using PropostaConsignado.Api.Dominio.Agentes.Aplicacao.Requests;

namespace PropostaConsignado.IntegrationTests.Builders.Agente
{
    public class CriarAgenteRequestBuilder : Faker<CriarAgenteRequest>
    {
        public CriarAgenteRequest Gerar() => Generate();

        public CriarAgenteRequestBuilder ComLogin(string login)
        {
            RuleFor(x => x.Login, login);
            return this;
        }

        public CriarAgenteRequestBuilder ComAtivo(bool ativo)
        {
            RuleFor(x => x.Ativo, ativo);
            return this;
        }
    }
}