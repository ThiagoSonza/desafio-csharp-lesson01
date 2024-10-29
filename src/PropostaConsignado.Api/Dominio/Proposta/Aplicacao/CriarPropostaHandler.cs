using CSharpFunctionalExtensions;
using MediatR;
using PropostaConsignado.Api.Dominio.Agentes.Infraestrutura;
using PropostaConsignado.Api.Dominio.Convenios.Infraestrutura;
using PropostaConsignado.Api.Dominio.Proponentes.Infraestrutura;
using PropostaConsignado.Api.Dominio.Proposta.Infraestrutura;
using PropostaConsignado.Api.Dominio.Proposta.Model;
using PropostaConsignado.Api.Dominio.Regras.Infraestrutura;

namespace PropostaConsignado.Api.Dominio.Proposta.Aplicacao
{
    public class CriarPropostaHandler(
        PropostaRepositorio propostaRepositorio,
        ProponenteRepositorio proponenteRepositorio,
        ConvenioRepositorio convenioRepositorio,
        AgenteRepositorio agenteRepositorio,
        RegraRepositorio regraPropostaRepositorio
    ) : IRequestHandler<CriaPropostaCommand, Result<PropostaDominio>>
    {
        public async Task<Result<PropostaDominio>> Handle(CriaPropostaCommand command, CancellationToken cancellationToken)
        {
            var agente = await agenteRepositorio.BuscarAgenteAtivo(command.Agente);
            if (agente.HasNoValue)
                return Result.Failure<PropostaDominio>($"Agente inválido");

            if (await propostaRepositorio.VerificaPropostasAbertas(command.Cpf))
                return Result.Failure<PropostaDominio>($"Proponente já possui outras propostas abertas");

            if (!proponenteRepositorio.VerificaCpfLiberado(command.Cpf))
                return Result.Failure<PropostaDominio>("Cpf do proponente está bloqueado/restrito");

            var convenio = await convenioRepositorio.BuscarPorCodigoEOperacao(command.Convenio, command.Operacao);
            if (convenio.HasNoValue)
                return Result.Failure<PropostaDominio>("Operação não aceita pelo convênio");

            var regras = regraPropostaRepositorio.ObterRegrasValidacaoProposta();

            var propostaResult = PropostaDominio.Criar(command, agente.Value, regras);
            if (propostaResult.IsFailure)
                return Result.Failure<PropostaDominio>(propostaResult.Error);

            await propostaRepositorio.Adicionar(propostaResult.Value, cancellationToken);
            await propostaRepositorio.Salvar();

            return Result.Success(propostaResult.Value);
        }
    }
}