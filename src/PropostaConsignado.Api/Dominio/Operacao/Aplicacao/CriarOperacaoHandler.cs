using CSharpFunctionalExtensions;
using MediatR;
using PropostaConsignado.Api.Dominio.Operacao.Infraestrutura;
using PropostaConsignado.Api.Dominio.Operacao.Model;

namespace PropostaConsignado.Api.Dominio.Operacao.Aplicacao
{
    public class CriarOperacaoHandler(OperacaoRepositorio operacaoRepositorio) : IRequestHandler<CriarOperacaoCommand, Result<OperacaoDominio>>
    {
        public async Task<Result<OperacaoDominio>> Handle(CriarOperacaoCommand command, CancellationToken cancellationToken)
        {
            var operacaoResult = OperacaoDominio.Criar(command.Descricao);
            if (operacaoResult.IsFailure)
                return Result.Failure<OperacaoDominio>(operacaoResult.Error);

            await operacaoRepositorio.Adicionar(operacaoResult.Value, cancellationToken);
            await operacaoRepositorio.Salvar();

            return Result.Success(operacaoResult.Value);
        }
    }
}