using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropostaConsignado.Api.Controllers.Shared;
using PropostaConsignado.Api.Dominio.Convenios.Aplicacao.Requests;

namespace PropostaConsignado.Api.Controllers
{
    public class ConvenioController(IMediator mediator) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CriarConvenio([FromBody] CriarConvenioRequest convenioRequest, CancellationToken token)
        {
            var comando = convenioRequest.CriarComando();
            if (comando.IsFailure)
                return BadRequest(comando.Error);

            var result = await mediator.Send(comando.Value, token);

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }
    }
}