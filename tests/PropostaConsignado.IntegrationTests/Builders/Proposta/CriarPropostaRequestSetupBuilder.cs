using CSharpFunctionalExtensions;
using PropostaConsignado.Api.Dominio.Proposta.Aplicacao;
using PropostaConsignado.Api.Dominio.Proposta.Aplicacao.Requests;

namespace PropostaConsignado.IntegrationTests.Builders.Proposta
{
    public class CriarPropostaRequestSetupBuilder
    {
        public static Result<CriaPropostaCommand> CriarProposta(string usuario)
        {
            var propostaRequest = new CriarPropostaRequestBuilder()
                .ComValorEmprestimo(30_000)
                .ComParcelas(12)
                .ComConvenio(1)
                .ComOperacao(1)
                .ComCpf("85754578024")
                .ComNome("Guilherme Castro")
                .ComDataNascimento(new DateTime(2000, 01, 01))
                .ComDdd("51")
                .ComTelefone("36148921")
                .ComEmail("email@dominio.com.br")
                .ComEstado("RS")
                .ComLocalidade("Porto Alegre")
                .ComBairro("Centro")
                .ComLogradouro("")
                .ComNumero("13")
                .ComComplemento("apto 01")
                .ComRendimento(5_000)
                .Gerar();

            return CriarComando(propostaRequest, usuario);
        }

        private static Result<CriaPropostaCommand> CriarComando(CriarPropostaRequest propostaRequest, string usuario)
            => CriaPropostaCommand.Criar(propostaRequest.Cpf, propostaRequest.Nome, propostaRequest.DataNascimento, propostaRequest.Ddd, propostaRequest.Telefone, propostaRequest.Email,
                                        propostaRequest.Estado, propostaRequest.Localidade, propostaRequest.Bairro, propostaRequest.Logradouro, propostaRequest.Numero, propostaRequest.Complemento,
                                        propostaRequest.Rendimento, propostaRequest.Valor, propostaRequest.Parcelas, propostaRequest.Convenio, propostaRequest.Operacao, usuario);
    }
}