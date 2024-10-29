using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropostaConsignado.Api.Dominio.Proposta.Model;

namespace PropostaConsignado.Api.Dominio.Proposta.Infraestrutura
{
    public class PropostaMapping : IEntityTypeConfiguration<PropostaDominio>
    {
        public void Configure(EntityTypeBuilder<PropostaDominio> builder)
        {
            builder.ToTable("Propostas");

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.AgenteId);
            builder.Property(p => p.Parcelas);
            builder.Property(p => p.Status);
            builder.Property(p => p.TipoAssinatura);
            builder.Property(p => p.ValorEmprestimo).HasPrecision(10, 2);

            builder.Property(p => p.Cpf).HasMaxLength(11);
            builder.Property(p => p.Nome).HasMaxLength(50);
            builder.Property(p => p.DataNascimento);
            builder.Property(p => p.Ddd).HasMaxLength(3);
            builder.Property(p => p.Telefone).HasMaxLength(10);
            builder.Property(p => p.Email).HasMaxLength(50);
            builder.Property(p => p.Estado).HasMaxLength(2);
            builder.Property(p => p.Localidade).HasMaxLength(50);
            builder.Property(p => p.Bairro).HasMaxLength(50);
            builder.Property(p => p.Logradouro).HasMaxLength(150);
            builder.Property(p => p.Numero).HasMaxLength(20);
            builder.Property(p => p.Complemento).HasMaxLength(20);
            builder.Property(p => p.Rendimento).HasPrecision(10, 2);

            builder.HasOne(fk => fk.Agente)
                   .WithMany(fk => fk.Propostas)
                   .HasForeignKey(fk => fk.AgenteId)
                   .HasConstraintName("FK_PROPOSTA_AGENTE");
        }
    }
}