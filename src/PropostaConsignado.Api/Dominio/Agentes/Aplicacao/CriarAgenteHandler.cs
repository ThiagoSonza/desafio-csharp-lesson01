using CSharpFunctionalExtensions;
using MediatR;
using PropostaConsignado.Api.Dominio.Agentes.Infraestrutura;
using PropostaConsignado.Api.Dominio.Agentes.Model;

namespace PropostaConsignado.Api.Dominio.Agentes.Aplicacao
{
    public class CriarAgenteHandler(AgenteRepositorio agenteRepositorio) : IRequestHandler<CriarAgenteCommand, Result<AgenteDominio>>
    {
        public async Task<Result<AgenteDominio>> Handle(CriarAgenteCommand command, CancellationToken cancellationToken)
        {
            var agenteResult = AgenteDominio.Criar(command.Login, command.Ativo);
            if (agenteResult.IsFailure)
                return Result.Failure<AgenteDominio>(agenteResult.Error);

            await agenteRepositorio.Adicionar(agenteResult.Value, cancellationToken);
            await agenteRepositorio.Salvar();

            return Result.Success(agenteResult.Value);
        }
    }
}