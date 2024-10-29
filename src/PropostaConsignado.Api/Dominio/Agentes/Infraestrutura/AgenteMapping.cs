using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropostaConsignado.Api.Dominio.Agentes.Model;

namespace PropostaConsignado.Api.Dominio.Agentes.Infraestrutura
{
    public class AgenteMapping : IEntityTypeConfiguration<AgenteDominio>
    {
        public void Configure(EntityTypeBuilder<AgenteDominio> builder)
        {
            builder.ToTable("Agentes");

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Login).HasMaxLength(30);
            builder.Property(p => p.Ativo);
        }
    }
}