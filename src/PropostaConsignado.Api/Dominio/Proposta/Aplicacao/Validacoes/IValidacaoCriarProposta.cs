using CSharpFunctionalExtensions;
using PropostaConsignado.Api.Dominio.Proposta.Model;

namespace PropostaConsignado.Api.Dominio.Proposta.Aplicacao.Validacoes
{
    public interface IValidacaoCriarProposta
    {
        Result Validar(PropostaDominio proposta);
    }
}