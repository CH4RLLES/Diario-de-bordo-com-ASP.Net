using DiarioDeBordo.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiarioDeBordo.Infra.Dados.Mapeamento
{
    public class AtividadeMap : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.ToTable("Atividades");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnName("Descricao");
            builder.Property(c => c.Sistema)
                .HasColumnName("Sistema");
            builder.Property(c => c.Quantidade)
                .HasColumnName("Quantidade");
            builder.Property(c => c.NumProcesso)
                .HasColumnName("NumProcesso");
            builder.Property(c => c.IdPai)
                .HasColumnName("IdPai");

            builder.Ignore(f => f.AtividadePai);
            builder.Ignore(i => i.AtividadesFilhos);
        }
    }
}
