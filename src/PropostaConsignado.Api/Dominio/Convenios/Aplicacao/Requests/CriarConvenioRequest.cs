using CSharpFunctionalExtensions;

namespace PropostaConsignado.Api.Dominio.Convenios.Aplicacao.Requests
{
    public record CriarConvenioRequest
    {
        public string Descricao { get; set; } = null!;
        public int Operacao { get; set; }

        public Result<CriarConvenioCommand> CriarComando()
            => CriarConvenioCommand.Criar(Descricao, Operacao);
    }
}