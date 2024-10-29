
using CSharpFunctionalExtensions;
using PropostaConsignado.Api.Dominio.Operacao.Model;

namespace PropostaConsignado.Api.Dominio.Convenios.Model
{
    public class ConvenioDominio
    {
        private ConvenioDominio()
        {
        }

        private ConvenioDominio(string descricao, int operacao)
        {
            Descricao = descricao;
            OperacaoId = operacao;
        }

        public int Id { get; }
        public string Descricao { get; } = null!;
        public int OperacaoId { get; }
        public OperacaoDominio Operacao { get; } = null!;

        public static Result<ConvenioDominio> Criar(string descricao, int operacao)
        {
            var convenio = new ConvenioDominio(descricao, operacao);
            return Result.Success(convenio);
        }
    }
}