using DiarioDeBordo.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiarioDeBordo.Infra.Dados.Mapeamento
{
    public class TipoAtividadeMap : IEntityTypeConfiguration<TipoAtividade>
    {
        public void Configure(EntityTypeBuilder<TipoAtividade> builder)
        {
            builder.ToTable("TiposAtividades");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnName("Descricao");
        }
    }
}
