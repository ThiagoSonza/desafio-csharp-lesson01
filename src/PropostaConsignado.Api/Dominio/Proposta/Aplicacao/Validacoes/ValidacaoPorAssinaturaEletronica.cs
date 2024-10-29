using CSharpFunctionalExtensions;
using PropostaConsignado.Api.Dominio.Proposta.Enumerations;
using PropostaConsignado.Api.Dominio.Proposta.Model;

namespace PropostaConsignado.Api.Dominio.Proposta.Aplicacao.Validacoes
{
    public class ValidacaoPorAssinaturaEletronica : IValidacaoCriarProposta
    {
        public Result Validar(PropostaDominio proposta)
        {
            bool EhAssinaturaHibrida = EstadosConstants.EstadosAssinaturaHibrida.Any(q => q == proposta.Estado);

            var EstadoDoPrefixoTelefoneProponente = EstadosConstants.PrefixosPorEstados
                .FirstOrDefault(q => q.Value.Contains(proposta.Ddd)).Key;

            if (!EhAssinaturaHibrida && EstadoDoPrefixoTelefoneProponente == proposta.Estado)
                proposta.AssinaturaEletronica();

            return Result.Success();
        }
    }
}