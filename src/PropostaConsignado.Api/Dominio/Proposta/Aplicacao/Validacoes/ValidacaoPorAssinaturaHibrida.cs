using CSharpFunctionalExtensions;
using PropostaConsignado.Api.Dominio.Proposta.Enumerations;
using PropostaConsignado.Api.Dominio.Proposta.Model;

namespace PropostaConsignado.Api.Dominio.Proposta.Aplicacao.Validacoes
{
    public class ValidacaoPorAssinaturaHibrida : IValidacaoCriarProposta
    {
        public Result Validar(PropostaDominio proposta)
        {
            if (EstadosConstants.EstadosAssinaturaHibrida.Any(q => q == proposta.Estado))
                proposta.AssinaturaHibrida();

            return Result.Success();
        }
    }
}