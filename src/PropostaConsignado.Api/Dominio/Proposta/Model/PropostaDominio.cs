using CSharpFunctionalExtensions;
using PropostaConsignado.Api.Dominio.Agentes.Model;
using PropostaConsignado.Api.Dominio.Proposta.Aplicacao;
using PropostaConsignado.Api.Dominio.Proposta.Aplicacao.Validacoes;
using PropostaConsignado.Api.Dominio.Proposta.Enumerations;

namespace PropostaConsignado.Api.Dominio.Proposta.Model
{
    public class PropostaDominio
    {
        private PropostaDominio()
        {
        }

        private PropostaDominio(string cpf, string nome, DateTime dataNascimento, string ddd, string telefone, string email,
                                string estado, string localidade, string bairro, string logradouro, string numero, string complemento,
                                decimal rendimento, int agente, int parcelasEmprestimo, int statusProposta, decimal valorEmprestimo)
        {
            AgenteId = agente;
            Parcelas = parcelasEmprestimo;
            Status = statusProposta;
            ValorEmprestimo = valorEmprestimo;
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Ddd = ddd;
            Telefone = telefone;
            Email = email;
            Estado = estado;
            Localidade = localidade;
            Bairro = bairro;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Rendimento = rendimento;
        }

        // Dados da proposta
        public int Id { get; }
        public int AgenteId { get; }
        public int Parcelas { get; }
        public int Status { get; }
        public int TipoAssinatura { get; private set; }
        public decimal ValorEmprestimo { get; }

        // Dados do proponente
        public string Cpf { get; } = null!;
        public string Nome { get; } = null!;
        public DateTime DataNascimento { get; }
        public string Ddd { get; } = null!;
        public string Telefone { get; } = null!;
        public string Email { get; } = null!;
        public string Estado { get; } = null!;
        public string Localidade { get; } = null!;
        public string Bairro { get; } = null!;
        public string Logradouro { get; } = null!;
        public string Numero { get; } = null!;
        public string Complemento { get; } = null!;
        public decimal Rendimento { get; }

        public AgenteDominio Agente { get; } = null!;

        public static Result<PropostaDominio> Criar(CriaPropostaCommand command, AgenteDominio agente, IEnumerable<IValidacaoCriarProposta> regras)
        {
            var proposta = new PropostaDominio(command.Cpf, command.Nome, command.DataNascimento, command.Ddd, command.Telefone, command.Email,
                                                command.Estado, command.Localidade, command.Bairro, command.Logradouro, command.Numero, command.Complemento,
                                                command.Rendimento, agente.Id, command.ParcelasEmprestimo, (int)StatusPropostaEnum.Aberta, command.ValorEmprestimo);

            foreach (var regra in regras)
            {
                var result = regra.Validar(proposta);
                if (result.IsFailure)
                    return Result.Failure<PropostaDominio>(result.Error);
            }

            return Result.Success(proposta);
        }

        public void AssinaturaHibrida()
            => TipoAssinatura = (int)TipoAssinaturaEnum.AssinaturaHibrida;

        public void AssinaturaEletronica()
            => TipoAssinatura = (int)TipoAssinaturaEnum.AssinaturaEletronica;

        public void AssinaturaFigital()
            => TipoAssinatura = (int)TipoAssinaturaEnum.AssinaturaFigital;
    }
}