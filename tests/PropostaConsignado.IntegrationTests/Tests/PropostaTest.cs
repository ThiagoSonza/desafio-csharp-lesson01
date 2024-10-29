using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using PropostaConsignado.IntegrationTests.Builders.Agente;
using PropostaConsignado.IntegrationTests.Builders.Convenio;
using PropostaConsignado.IntegrationTests.Builders.Operacao;
using PropostaConsignado.IntegrationTests.Builders.Proposta;
using PropostaConsignado.IntegrationTests.Setups;

namespace PropostaConsignado.IntegrationTests.Tests
{
    [Collection("Teste Integracao Collection")]
    public class PropostaTest(TesteIntegracaoSetup testeIntegracaoSetup) : Base(testeIntegracaoSetup)
    {
        [Fact]
        public async Task DeveRetornarSucesso_AoInserirProposta()
        {
            // Arrange
            var agente = CriarAgenteRequestSetupBuilder.CriarAgente();
            var operacao = CriarOperacaoRequestSetupBuilder.CriarOperacao();
            var convenio = CriarConvenioRequestSetupBuilder.CriarConvenio();
            var proposta = CriarPropostaRequestSetupBuilder.CriarProposta("USER01");

            // Act
            await TesteIntegracaoSetup.HttpClient.PostAsync("api/agente", JsonContent.Create(agente));
            await TesteIntegracaoSetup.HttpClient.PostAsync("api/operacao", JsonContent.Create(operacao));
            await TesteIntegracaoSetup.HttpClient.PostAsync("api/convenio", JsonContent.Create(convenio));
            var response = await TesteIntegracaoSetup.HttpClient.PostAsync("api/proposta", JsonContent.Create(proposta.Value));

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}