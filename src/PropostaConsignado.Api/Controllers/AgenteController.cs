using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropostaConsignado.Api.Controllers.Shared;
using PropostaConsignado.Api.Dominio.Agentes.Aplicacao.Requests;

namespace PropostaConsignado.Api.Controllers
{
    public class AgenteController(IMediator mediator) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CriarAgente([FromBody] CriarAgenteRequest agenteRequest, CancellationToken token)
        {
            var comando = agenteRequest.CriarComando();
            if (comando.IsFailure)
                return BadRequest(comando.Error);

            var result = await mediator.Send(comando.Value, token);

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }
    }
}