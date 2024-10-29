using Bogus;
using PropostaConsignado.Api.Dominio.Operacao.Aplicacao.Requests;

namespace PropostaConsignado.IntegrationTests.Builders.Operacao
{
    public class CriarOperacaoRequestBuilder : Faker<CriarOperacaoRequest>
    {
        public CriarOperacaoRequest Gerar() => Generate();

        public CriarOperacaoRequestBuilder ComDescricao(string descricao)
        {
            RuleFor(x => x.Descricao, descricao);
            return this;
        }
    }
}