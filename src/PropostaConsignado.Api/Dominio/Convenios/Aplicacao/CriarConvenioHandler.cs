using CSharpFunctionalExtensions;
using MediatR;
using PropostaConsignado.Api.Dominio.Convenios.Infraestrutura;
using PropostaConsignado.Api.Dominio.Convenios.Model;

namespace PropostaConsignado.Api.Dominio.Convenios.Aplicacao
{
    public class CriarConvenioHandler(ConvenioRepositorio convenioRepositorio) : IRequestHandler<CriarConvenioCommand, Result<ConvenioDominio>>
    {
        public async Task<Result<ConvenioDominio>> Handle(CriarConvenioCommand command, CancellationToken cancellationToken)
        {
            var convenioResult = ConvenioDominio.Criar(command.Descricao, command.Operacao);
            if (convenioResult.IsFailure)
                return Result.Failure<ConvenioDominio>(convenioResult.Error);

            await convenioRepositorio.Adicionar(convenioResult.Value, cancellationToken);
            await convenioRepositorio.Salvar();

            return Result.Success(convenioResult.Value);
        }
    }
}