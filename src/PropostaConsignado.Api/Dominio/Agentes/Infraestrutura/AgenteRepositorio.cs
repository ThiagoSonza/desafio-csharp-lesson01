using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PropostaConsignado.Api.Dominio.Agentes.Model;

namespace PropostaConsignado.Api.Dominio.Agentes.Infraestrutura
{
    public class AgenteRepositorio(PropostaDbContext context)
    {
        public async Task Adicionar(AgenteDominio agente, CancellationToken cancellationToken)
        {
            await context.Agentes.AddAsync(agente, cancellationToken);
        }

        public async Task Salvar()
        {
            await context.SaveChangesAsync();
        }

        public async Task<Maybe<AgenteDominio>> BuscarAgenteAtivo(string agente)
        {
            var result = await context.Agentes.FirstOrDefaultAsync(q => q.Ativo
                                                                    && q.Login == agente);

            return result;
        }
    }
}