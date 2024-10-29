
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PropostaConsignado.Api.Dominio.Convenios.Model;

namespace PropostaConsignado.Api.Dominio.Convenios.Infraestrutura
{
    public class ConvenioRepositorio(PropostaDbContext context)
    {
        public async Task Adicionar(ConvenioDominio convenio, CancellationToken cancellationToken)
        {
            await context.Convenios.AddAsync(convenio, cancellationToken);
        }

        public async Task Salvar()
        {
            await context.SaveChangesAsync();
        }

        public async Task<Maybe<ConvenioDominio>> BuscarPorCodigoEOperacao(int convenio, int operacao)
        {
            var result = await context.Convenios
                .FirstOrDefaultAsync(q => q.Id == convenio
                                        && q.OperacaoId == operacao);

            return result ?? Maybe<ConvenioDominio>.None;
        }
    }
}