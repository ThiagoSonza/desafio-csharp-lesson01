using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropostaConsignado.Api.Dominio.Operacao.Model;

namespace PropostaConsignado.Api.Dominio.Operacao.Infraestrutura
{
    public class OperacaoMapping : IEntityTypeConfiguration<OperacaoDominio>
    {
        public void Configure(EntityTypeBuilder<OperacaoDominio> builder)
        {
            builder.ToTable("Operacoes");

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Descricao).HasMaxLength(50);
        }
    }
}