using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropostaConsignado.Api.Controllers.Shared;
using PropostaConsignado.Api.Dominio.Operacao.Aplicacao.Requests;

namespace PropostaConsignado.Api.Controllers
{
    public class OperacaoController(IMediator mediator) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CriarOperacao([FromBody] CriarOperacaoRequest operacaoRequest, CancellationToken token)
        {
            var comando = operacaoRequest.CriarComando();
            if (comando.IsFailure)
                return BadRequest(comando.Error);

            var result = await mediator.Send(comando.Value, token);

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }
    }
}