using PropostaConsignado.Api.Dominio.Operacao.Aplicacao.Requests;

namespace PropostaConsignado.IntegrationTests.Builders.Operacao
{
    public class CriarOperacaoRequestSetupBuilder
    {
        public static CriarOperacaoRequest CriarOperacao()
        {
            var operacao = new CriarOperacaoRequestBuilder()
                .ComDescricao("Operação Teste")
                .Gerar();

            return operacao;
        }
    }
}