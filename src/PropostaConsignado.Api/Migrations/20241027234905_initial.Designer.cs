﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropostaConsignado.Api.Dominio;

#nullable disable

namespace PropostaConsignado.Api.Migrations
{
    [DbContext(typeof(PropostaDbContext))]
    [Migration("20241027234905_initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PropostaConsignado.Api.Dominio.Agentes.Model.AgenteDominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Agentes", (string)null);
                });

            modelBuilder.Entity("PropostaConsignado.Api.Dominio.Convenios.Model.ConvenioDominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("OperacaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperacaoId");

                    b.ToTable("Convenios", (string)null);
                });

            modelBuilder.Entity("PropostaConsignado.Api.Dominio.Operacao.Model.OperacaoDominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Operacoes", (string)null);
                });

            modelBuilder.Entity("PropostaConsignado.Api.Dominio.Proposta.Model.PropostaDominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgenteId")
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ddd")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("varchar(3)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Parcelas")
                        .HasColumnType("int");

                    b.Property<decimal>("Rendimento")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("TipoAssinatura")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorEmprestimo")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("AgenteId");

                    b.ToTable("Propostas", (string)null);
                });

            modelBuilder.Entity("PropostaConsignado.Api.Dominio.Regras.Model.RegraDominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Regra")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<int>("TipoRegra")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Regras", (string)null);
                });

            modelBuilder.Entity("PropostaConsignado.Api.Dominio.Convenios.Model.ConvenioDominio", b =>
                {
                    b.HasOne("PropostaConsignado.Api.Dominio.Operacao.Model.OperacaoDominio", "Operacao")
                        .WithMany("Convenios")
                        .HasForeignKey("OperacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CONVENIO_OPERACAO");

                    b.Navigation("Operacao");
                });

            modelBuilder.Entity("PropostaConsignado.Api.Dominio.Proposta.Model.PropostaDominio", b =>
                {
                    b.HasOne("PropostaConsignado.Api.Dominio.Agentes.Model.AgenteDominio", "Agente")
                        .WithMany("Propostas")
                        .HasForeignKey("AgenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PROPOSTA_AGENTE");

                    b.Navigation("Agente");
                });

            modelBuilder.Entity("PropostaConsignado.Api.Dominio.Agentes.Model.AgenteDominio", b =>
                {
                    b.Navigation("Propostas");
                });

            modelBuilder.Entity("PropostaConsignado.Api.Dominio.Operacao.Model.OperacaoDominio", b =>
                {
                    b.Navigation("Convenios");
                });
#pragma warning restore 612, 618
        }
    }
}
