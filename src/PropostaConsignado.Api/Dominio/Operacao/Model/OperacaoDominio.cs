using CSharpFunctionalExtensions;
using PropostaConsignado.Api.Dominio.Convenios.Model;

namespace PropostaConsignado.Api.Dominio.Operacao.Model
{
    public class OperacaoDominio
    {
        private OperacaoDominio()
        {
        }

        private OperacaoDominio(string descricao)
        {
            Descricao = descricao;
        }

        public int Id { get; }
        public string Descricao { get; } = null!;
        public IEnumerable<ConvenioDominio> Convenios { get; } = [];

        public static Result<OperacaoDominio> Criar(string descricao)
        {
            var operacao = new OperacaoDominio(descricao);
            return Result.Success(operacao);
        }
    }
}