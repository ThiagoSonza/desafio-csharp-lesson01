using CSharpFunctionalExtensions;
using PropostaConsignado.Api.Dominio.Proposta.Model;

namespace PropostaConsignado.Api.Dominio.Proposta.Aplicacao.Validacoes
{
    public class ValidacaoPorIdade : IValidacaoCriarProposta
    {
        private const int IDADE_MAXIMA = 80;

        public Result Validar(PropostaDominio proposta)
        {
            if (CalculaIdadeProponente(proposta.DataNascimento, proposta.Parcelas))
                return Result.Failure("Numero de parcelas ultrapassa o limite.");

            return Result.Success();
        }

        private static bool CalculaIdadeProponente(DateTime dataNascimento, int parcelas)
        {
            DateTime dataUltimaParcela = DateTime.Now.AddMonths(parcelas + 1);
            int idadeProponenteNaUltimaParcela = dataUltimaParcela.Year - dataNascimento.Year;

            return idadeProponenteNaUltimaParcela > IDADE_MAXIMA;
        }
    }
}