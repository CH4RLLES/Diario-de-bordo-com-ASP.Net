using DiarioDeBordo.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiarioDeBordo.Infra.Dados.Mapeamento
{
    public class AtividadeEfetuadaMap : IEntityTypeConfiguration<AtividadeEfetuada>
    {
        public void Configure(EntityTypeBuilder<AtividadeEfetuada> builder)
        {
            builder.ToTable("AtividadesEfetuadas");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.DataAtividade)
                .IsRequired()
                .HasColumnName("DataAtividade");

            builder.Property(c => c.ProcessoSEI)
                .HasColumnName("ProcessoSEI");

            builder.Property(c => c.TipoAtendimento)
                .IsRequired()
                .HasColumnName("TipoAtendimento");

            builder.Property(c => c.IdAtividade)
                .IsRequired()
                .HasColumnName("IdAtividade");

            builder.Property(c => c.Quantidade)
                .HasColumnName("Quantidade");

            builder.Property(c => c.IdUsuario)
                .IsRequired()
                .HasColumnName("UsuarioAtividade");

            builder.Property(c => c.DataHoraCadastro)
                .IsRequired()
                .HasColumnName("DataHoraCadastro");

            builder.HasOne(f => f.UsuarioAtividade)
                .WithMany();
            builder.HasOne(f => f.AtividadeFeita)
                .WithMany();
        }
    }
}
