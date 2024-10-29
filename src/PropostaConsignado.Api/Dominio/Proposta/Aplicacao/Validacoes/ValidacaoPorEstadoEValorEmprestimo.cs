using CSharpFunctionalExtensions;
using PropostaConsignado.Api.Dominio.Proposta.Model;

namespace PropostaConsignado.Api.Dominio.Proposta.Aplicacao.Validacoes
{
    public class ValidacaoPorEstadoEValorEmprestimo : IValidacaoCriarProposta
    {
        private const string ESTADO_RESTRICAO = "RS";
        private const decimal VALOR_MAXIMO = 20_000;

        public Result Validar(PropostaDominio proposta)
        {
            if (proposta.Estado == ESTADO_RESTRICAO &&
                proposta.ValorEmprestimo > VALOR_MAXIMO)
                return Result.Failure($"Valor não permitido para o estado {proposta.Estado}");

            return Result.Success();
        }
    }
}