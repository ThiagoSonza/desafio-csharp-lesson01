using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropostaConsignado.Api.Dominio.Convenios.Model;

namespace PropostaConsignado.Api.Dominio.Convenios.Infraestrutura
{
    public class ConvenioMapping : IEntityTypeConfiguration<ConvenioDominio>
    {
        public void Configure(EntityTypeBuilder<ConvenioDominio> builder)
        {
            builder.ToTable("Convenios");

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Descricao).HasMaxLength(50);

            builder.HasOne(fk => fk.Operacao)
                   .WithMany(fk => fk.Convenios)
                   .HasForeignKey(fk => fk.OperacaoId)
                   .HasConstraintName("FK_CONVENIO_OPERACAO");
        }
    }
}