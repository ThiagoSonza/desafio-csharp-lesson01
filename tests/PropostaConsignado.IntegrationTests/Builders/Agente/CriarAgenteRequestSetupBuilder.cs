using PropostaConsignado.Api.Dominio.Agentes.Aplicacao.Requests;

namespace PropostaConsignado.IntegrationTests.Builders.Agente
{
    public class CriarAgenteRequestSetupBuilder
    {
        public static CriarAgenteRequest CriarAgente()
        {
            var agente = new CriarAgenteRequestBuilder()
                .ComLogin("AGENTE_01")
                .ComAtivo(true)
                .Gerar();

            return agente;
        }
    }
}