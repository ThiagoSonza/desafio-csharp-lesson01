using Bogus;
using PropostaConsignado.Api.Dominio.Proposta.Aplicacao.Requests;

namespace PropostaConsignado.IntegrationTests.Builders.Proposta
{
    public class CriarPropostaRequestBuilder : Faker<CriarPropostaRequest>
    {
        public CriarPropostaRequest Gerar() => Generate();

        public CriarPropostaRequestBuilder ComValorEmprestimo(decimal valorEmprestimo)
        {
            RuleFor(x => x.Valor, valorEmprestimo);
            return this;
        }

        public CriarPropostaRequestBuilder ComParcelas(int parcelas)
        {
            RuleFor(x => x.Parcelas, parcelas);
            return this;
        }

        public CriarPropostaRequestBuilder ComConvenio(int convenio)
        {
            RuleFor(x => x.Convenio, convenio);
            return this;
        }

        public CriarPropostaRequestBuilder ComOperacao(int operacao)
        {
            RuleFor(x => x.Operacao, operacao);
            return this;
        }

        public CriarPropostaRequestBuilder ComCpf(string cpf)
        {
            RuleFor(x => x.Cpf, cpf);
            return this;
        }

        public CriarPropostaRequestBuilder ComNome(string nome)
        {
            RuleFor(x => x.Nome, nome);
            return this;
        }

        public CriarPropostaRequestBuilder ComDataNascimento(DateTime dtNascimento)
        {
            RuleFor(x => x.DataNascimento, dtNascimento);
            return this;
        }

        public CriarPropostaRequestBuilder ComDdd(string ddd)
        {
            RuleFor(x => x.Ddd, ddd);
            return this;
        }

        public CriarPropostaRequestBuilder ComTelefone(string telefone)
        {
            RuleFor(x => x.Telefone, telefone);
            return this;
        }

        public CriarPropostaRequestBuilder ComEmail(string email)
        {
            RuleFor(x => x.Email, email);
            return this;
        }

        public CriarPropostaRequestBuilder ComEstado(string estado)
        {
            RuleFor(x => x.Estado, estado);
            return this;
        }

        public CriarPropostaRequestBuilder ComLocalidade(string localidade)
        {
            RuleFor(x => x.Localidade, localidade);
            return this;
        }

        public CriarPropostaRequestBuilder ComBairro(string bairro)
        {
            RuleFor(x => x.Bairro, bairro);
            return this;
        }

        public CriarPropostaRequestBuilder ComLogradouro(string logradouro)
        {
            RuleFor(x => x.Logradouro, logradouro);
            return this;
        }

        public CriarPropostaRequestBuilder ComNumero(string numero)
        {
            RuleFor(x => x.Numero, numero);
            return this;
        }

        public CriarPropostaRequestBuilder ComComplemento(string complemento)
        {
            RuleFor(x => x.Complemento, complemento);
            return this;
        }

        public CriarPropostaRequestBuilder ComRendimento(decimal rendimento)
        {
            RuleFor(x => x.Rendimento, rendimento);
            return this;
        }
    }
}