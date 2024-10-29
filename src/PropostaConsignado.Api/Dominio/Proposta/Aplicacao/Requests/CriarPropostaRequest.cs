using CSharpFunctionalExtensions;

namespace PropostaConsignado.Api.Dominio.Proposta.Aplicacao.Requests
{
    public record CriarPropostaRequest
    {
        // Dados da proposta
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
        public int Convenio { get; set; }
        public int Operacao { get; set; }

        // Dados do proponente
        public string Cpf { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public string Ddd { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Localidade { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public string Logradouro { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string Complemento { get; set; } = null!;
        public decimal Rendimento { get; set; }

        public Result<CriaPropostaCommand> CriarComando(string usuario)
            => CriaPropostaCommand.Criar(Cpf, Nome, DataNascimento, Ddd, Telefone, Email,
                                        Estado, Localidade, Bairro, Logradouro, Numero, Complemento,
                                        Rendimento,
                                        Valor, Parcelas, Convenio, Operacao,
                                        usuario);
    }
}