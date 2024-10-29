using PropostaConsignado.Api.Dominio.Proposta.Aplicacao.Validacoes;

namespace PropostaConsignado.Api.Dominio.Regras.Model
{
    public class RegraDominio
    {
        public int Id { get; }
        public int TipoRegra { get; }
        public IValidacaoCriarProposta Regra { get; } = null!;
    }
}