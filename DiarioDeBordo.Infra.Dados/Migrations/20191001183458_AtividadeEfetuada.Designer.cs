﻿// <auto-generated />
using System;
using DiarioDeBordo.Infra.Dados.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiarioDeBordo.Infra.Dados.Migrations
{
    [DbContext(typeof(DiarioContext))]
    [Migration("20191001183458_AtividadeEfetuada")]
    partial class AtividadeEfetuada
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DiarioDeBordo.Dominio.Entidades.Atividade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Atividades");
                });

            modelBuilder.Entity("DiarioDeBordo.Dominio.Entidades.AtividadeEfetuada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AtividadeFeitaId");

                    b.Property<DateTime>("DataAtividade")
                        .HasColumnName("DataAtividade");

                    b.Property<string>("ProcessoSEI")
                        .HasColumnName("ProcessoSEI");

                    b.Property<int>("TipoAtendimento")
                        .HasColumnName("TipoAtendimento");

                    b.Property<Guid>("TipoAtividadeFeitaId");

                    b.Property<Guid>("UsuarioAtividadeId");

                    b.HasKey("Id");

                    b.HasIndex("AtividadeFeitaId");

                    b.HasIndex("TipoAtividadeFeitaId");

                    b.HasIndex("UsuarioAtividadeId");

                    b.ToTable("AtividadesEfetuadas");
                });

            modelBuilder.Entity("DiarioDeBordo.Dominio.Entidades.TipoAtividade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao");

                    b.HasKey("Id");

                    b.ToTable("TiposAtividades");
                });

            modelBuilder.Entity("DiarioDeBordo.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("CPF");

                    b.Property<int>("ControleAcesso")
                        .HasColumnName("ControleAcesso");

                    b.Property<Guid>("IdColaborador")
                        .HasColumnName("IdColaborador");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome");

                    b.Property<int>("Status")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DiarioDeBordo.Dominio.Entidades.AtividadeEfetuada", b =>
                {
                    b.HasOne("DiarioDeBordo.Dominio.Entidades.Atividade", "AtividadeFeita")
                        .WithMany()
                        .HasForeignKey("AtividadeFeitaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiarioDeBordo.Dominio.Entidades.TipoAtividade", "TipoAtividadeFeita")
                        .WithMany()
                        .HasForeignKey("TipoAtividadeFeitaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiarioDeBordo.Dominio.Entidades.Usuario", "UsuarioAtividade")
                        .WithMany()
                        .HasForeignKey("UsuarioAtividadeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
