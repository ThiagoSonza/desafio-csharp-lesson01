using Bogus;
using PropostaConsignado.Api.Dominio.Convenios.Aplicacao.Requests;

namespace PropostaConsignado.IntegrationTests.Builders.Convenio
{

    public class CriarConvenioRequestBuilder : Faker<CriarConvenioRequest>
    {
        public CriarConvenioRequest Gerar() => Generate();

        public CriarConvenioRequestBuilder ComDescricao(string descricao)
        {
            RuleFor(x => x.Descricao, descricao);
            return this;
        }

        public CriarConvenioRequestBuilder ComOperacao(int operacao)
        {
            RuleFor(x => x.Operacao, operacao);
            return this;
        }
    }
}