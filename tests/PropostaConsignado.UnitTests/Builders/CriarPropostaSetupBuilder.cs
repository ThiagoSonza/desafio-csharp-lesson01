using CSharpFunctionalExtensions;
using PropostaConsignado.Api.Dominio.Proposta.Aplicacao;
using PropostaConsignado.Api.Dominio.Proposta.Aplicacao.Requests;
using PropostaConsignado.UnitTests.Builders.Proposta;

namespace PropostaConsignado.UnitTests.Builders
{
    public class CriarPropostaSetupBuilder
    {
        public static Result<CriaPropostaCommand> CriarPropostaCommandComEstadoEValor(string usuario, string estado, decimal valorEmprestimo)
        {
            var propostaRequest = new CriarPropostaRequestBuilder()
                .ComValorEmprestimo(valorEmprestimo)
                .ComParcelas(12)
                .ComConvenio(1)
                .ComOperacao(1)
                .ComCpf("85754578024")
                .ComNome("Guilherme Castro")
                .ComDataNascimento(new DateTime(2000, 01, 01))
                .ComDdd("51")
                .ComTelefone("36148921")
                .ComEmail("email@dominio.com.br")
                .ComEstado(estado)
                .ComLocalidade("Porto Alegre")
                .ComBairro("Centro")
                .ComLogradouro("")
                .ComNumero("13")
                .ComComplemento("apto 01")
                .ComRendimento(5_000)
                .Gerar();

            return CriarComando(propostaRequest, usuario);
        }

        public static Result<CriaPropostaCommand> CriarPropostaCommandComDataNascimentoEParcelas(string usuario, DateTime dataNascimento, int parcelas)
        {
            var propostaRequest = new CriarPropostaRequestBuilder()
                .ComValorEmprestimo(50_000)
                .ComParcelas(parcelas)
                .ComConvenio(1)
                .ComOperacao(1)
                .ComCpf("13727340070")
                .ComNome("Manoel Salles")
                .ComDataNascimento(dataNascimento)
                .ComDdd("51")
                .ComTelefone("36148921")
                .ComEmail("email@dominio.com.br")
                .ComEstado("SC")
                .ComLocalidade("Barra Velha")
                .ComBairro("Centro")
                .ComLogradouro("Rua Paraná")
                .ComNumero("428")
                .ComComplemento("apto 01")
                .ComRendimento(8_300)
                .Gerar();

            return CriarComando(propostaRequest, usuario);
        }

        public static Result<CriaPropostaCommand> CriarPropostaCommandComEstadoEPrefixoTelefone(string usuario, string estado, string prefix)
        {
            var propostaRequest = new CriarPropostaRequestBuilder()
                .ComValorEmprestimo(1_000)
                .ComParcelas(12)
                .ComConvenio(1)
                .ComOperacao(1)
                .ComCpf("75840929000")
                .ComNome("Cícero Pedroso")
                .ComDataNascimento(new DateTime(1980, 01, 01))
                .ComDdd(prefix)
                .ComTelefone("36148921")
                .ComEmail("email@dominio.com.br")
                .ComEstado(estado)
                .ComLocalidade("Barão")
                .ComBairro("Centro")
                .ComLogradouro("Rua Leonardo Celso Mombach")
                .ComNumero("68")
                .ComComplemento("apto 01")
                .ComRendimento(3_500)
                .Gerar();

            return CriarComando(propostaRequest, usuario);
        }

        private static Result<CriaPropostaCommand> CriarComando(CriarPropostaRequest propostaRequest, string usuario)
            => CriaPropostaCommand.Criar(propostaRequest.Cpf, propostaRequest.Nome, propostaRequest.DataNascimento, propostaRequest.Ddd, propostaRequest.Telefone, propostaRequest.Email,
                                        propostaRequest.Estado, propostaRequest.Localidade, propostaRequest.Bairro, propostaRequest.Logradouro, propostaRequest.Numero, propostaRequest.Complemento,
                                        propostaRequest.Rendimento, propostaRequest.Valor, propostaRequest.Parcelas, propostaRequest.Convenio, propostaRequest.Operacao, usuario);
    }
}