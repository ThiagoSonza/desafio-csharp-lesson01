using Microsoft.EntityFrameworkCore;
using PropostaConsignado.Api.Dominio.Proposta.Enumerations;
using PropostaConsignado.Api.Dominio.Proposta.Model;

namespace PropostaConsignado.Api.Dominio.Proposta.Infraestrutura
{
    public class PropostaRepositorio(PropostaDbContext context)
    {
        public async Task<bool> VerificaPropostasAbertas(string CpfProponente)
        {
            var result = await context.Propostas.CountAsync(q => q.Cpf == CpfProponente
                                                            && q.Status == (int)StatusPropostaEnum.Aberta);

            return result > 0;
        }

        public async Task Adicionar(PropostaDominio proposta, CancellationToken cancellationToken)
        {
            await context.Propostas.AddAsync(proposta, cancellationToken);
        }

        public async Task Salvar()
        {
            await context.SaveChangesAsync();
        }
    }
}