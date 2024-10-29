using System.Text;
using CSharpFunctionalExtensions;
using MediatR;
using PropostaConsignado.Api.Dominio.Proposta.Model;

namespace PropostaConsignado.Api.Dominio.Proposta.Aplicacao
{
    public record CriaPropostaCommand : IRequest<Result<PropostaDominio>>
    {
        private CriaPropostaCommand(string cpf, string nome, DateTime dataNascimento, string ddd, string telefone, string email,
                                    string estado, string localidade, string bairro, string logradouro, string numero, string complemento,
                                    decimal rendimento, decimal valorEmprestimo, int parcelasEmprestimo, int convenio, int operacao, string agente)
        {
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
            ValorEmprestimo = valorEmprestimo;
            ParcelasEmprestimo = parcelasEmprestimo;
            Convenio = convenio;
            Operacao = operacao;
            Agente = agente;
        }

        // Dados da proposta
        public string Agente { get; }
        public decimal ValorEmprestimo { get; }
        public int ParcelasEmprestimo { get; }
        public int Convenio { get; }
        public int Operacao { get; }

        // Dados do proponente
        public string Cpf { get; }
        public string Nome { get; }
        public DateTime DataNascimento { get; }
        public string Ddd { get; }
        public string Telefone { get; }
        public string Email { get; }
        public string Estado { get; }
        public string Localidade { get; }
        public string Bairro { get; }
        public string Logradouro { get; }
        public string Numero { get; }
        public string Complemento { get; }
        public decimal Rendimento { get; }

        public static Result<CriaPropostaCommand> Criar(string cpf, string nome, DateTime dataNascimento, string ddd, string telefone, string email,
                                                        string estado, string localidade, string bairro, string logradouro, string numero, string complemento,
                                                        decimal rendimento, decimal valorEmprestimo, int parcelasEmprestimo, int convenio, int operacao, string agente)
        {
            CriaPropostaCommand command = new(cpf, nome, dataNascimento, ddd, telefone, email,
                                            estado, localidade, bairro, logradouro, numero, complemento,
                                            rendimento, valorEmprestimo, parcelasEmprestimo, convenio, operacao, agente);

            var validation = new PropostaValidator().Validate(command);
            if (validation.IsValid)
                return Result.Success(command);

            var errors = validation.Errors.Select(err => err.ErrorMessage);
            StringBuilder errorMessage = new();
            foreach (string error in errors)
                errorMessage.Append(error).AppendJoin(". ");

            return Result.Failure<CriaPropostaCommand>(errorMessage.ToString());
        }
    }
}