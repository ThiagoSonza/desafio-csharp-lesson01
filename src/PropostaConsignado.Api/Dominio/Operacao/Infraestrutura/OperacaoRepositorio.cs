using PropostaConsignado.Api.Dominio.Operacao.Model;

namespace PropostaConsignado.Api.Dominio.Operacao.Infraestrutura
{
    public class OperacaoRepositorio(PropostaDbContext context)
    {
        public async Task Adicionar(OperacaoDominio operacao, CancellationToken cancellationToken)
        {
            await context.Operacoes.AddAsync(operacao, cancellationToken);
        }

        public async Task Salvar()
        {
            await context.SaveChangesAsync();
        }

    }
}