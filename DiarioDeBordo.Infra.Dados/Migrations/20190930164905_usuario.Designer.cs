// <auto-generated />
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
    [Migration("20190930164905_usuario")]
    partial class usuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DiarioDeBordo.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("CPF");

                    b.Property<string>("IdColaborador")
                        .IsRequired()
                        .HasColumnName("IdColaborador");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome");

                    b.Property<int>("Status")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
