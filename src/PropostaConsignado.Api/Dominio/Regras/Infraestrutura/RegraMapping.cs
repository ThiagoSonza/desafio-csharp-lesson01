using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropostaConsignado.Api.Comum;
using PropostaConsignado.Api.Dominio.Proposta.Aplicacao.Validacoes;
using PropostaConsignado.Api.Dominio.Regras.Model;

namespace PropostaConsignado.Api.Dominio.Regras.Infraestrutura
{
    public class RegraMapping : IEntityTypeConfiguration<RegraDominio>
    {
        public void Configure(EntityTypeBuilder<RegraDominio> builder)
        {
            builder.ToTable("Regras");

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.TipoRegra);
            builder.Property(p => p.Regra)
                   .HasColumnType("varchar(max)")
                   .HasConversion(
                        c => c.ToNameTypeJson(),
                        s => s.ToNameTypeObject<IValidacaoCriarProposta>())
                    .IsRequired();
        }
    }
}