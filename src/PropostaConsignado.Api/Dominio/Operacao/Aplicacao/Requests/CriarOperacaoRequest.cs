using CSharpFunctionalExtensions;

namespace PropostaConsignado.Api.Dominio.Operacao.Aplicacao.Requests
{
    public record CriarOperacaoRequest
    {
        public string Descricao { get; set; } = null!;

        public Result<CriarOperacaoCommand> CriarComando()
            => CriarOperacaoCommand.Criar(Descricao);

    }
}