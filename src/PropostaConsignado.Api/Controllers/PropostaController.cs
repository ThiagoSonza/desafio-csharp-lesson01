using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropostaConsignado.Api.Controllers.Shared;
using PropostaConsignado.Api.Dominio.Proposta.Aplicacao.Requests;

namespace PropostaConsignado.Api.Controllers
{
    public class PropostaController(IMediator mediator) : BaseController
    {
        private const string USUARIO = "AGENTE_01";

        [HttpPost]
        public async Task<IActionResult> CriarProposta([FromBody] CriarPropostaRequest proposta, CancellationToken token)
        {
            var comando = proposta.CriarComando(USUARIO);
            if (comando.IsFailure)
                return BadRequest(comando.Error);

            var result = await mediator.Send(comando.Value, token);

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }
    }
}