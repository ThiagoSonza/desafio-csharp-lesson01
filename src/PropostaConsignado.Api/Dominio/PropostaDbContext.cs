using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PropostaConsignado.Api.Dominio.Agentes.Model;
using PropostaConsignado.Api.Dominio.Convenios.Model;
using PropostaConsignado.Api.Dominio.Operacao.Model;
using PropostaConsignado.Api.Dominio.Proposta.Model;
using PropostaConsignado.Api.Dominio.Regras.Model;

namespace PropostaConsignado.Api.Dominio
{
    public class PropostaDbContext(DbContextOptions<PropostaDbContext> options) : DbContext(options)
    {
        public DbSet<PropostaDominio> Propostas { get; set; }
        public DbSet<AgenteDominio> Agentes { get; set; }
        public DbSet<RegraDominio> Regras { get; set; }
        public DbSet<ConvenioDominio> Convenios { get; set; }
        public DbSet<OperacaoDominio> Operacoes { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<string>()
                .AreUnicode(false)
                .HaveMaxLength(500);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}