using PropostaConsignado.Api.Dominio.Proposta.Aplicacao.Validacoes;

namespace PropostaConsignado.Api.Dominio.Regras.Infraestrutura
{
    public class RegraRepositorio()
    {
        public static readonly IEnumerable<IValidacaoCriarProposta> RegrasCriacaoProposta = [
            new ValidacaoPorAssinaturaEletronica(),
            new ValidacaoPorAssinaturaFigital(),
            new ValidacaoPorAssinaturaHibrida(),
            new ValidacaoPorEstadoEValorEmprestimo(),
            new ValidacaoPorIdade()
        ];

        public IEnumerable<IValidacaoCriarProposta> ObterRegrasValidacaoProposta()
            => RegrasCriacaoProposta;
    }
}