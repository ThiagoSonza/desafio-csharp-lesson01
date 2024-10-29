using PropostaConsignado.Api.Dominio.Convenios.Aplicacao.Requests;

namespace PropostaConsignado.IntegrationTests.Builders.Convenio
{
    public class CriarConvenioRequestSetupBuilder
    {
        public static CriarConvenioRequest CriarConvenio()
        {
            var convenio = new CriarConvenioRequestBuilder()
                .ComDescricao("Convenio Teste")
                .ComOperacao(1)
                .Gerar();

            return convenio;
        }
    }
}