using DiarioDeBordo.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiarioDeBordo.Infra.Dados.Mapeamento
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdColaborador)
                .IsRequired()
                .HasColumnName("IdColaborador");
            builder.Property(c => c.CPF)
                .IsRequired()
                .HasColumnName("CPF");
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome");
            builder.Property(c => c.Status)
                .IsRequired()
                .HasColumnName("Status");
            builder.Property(c => c.ControleAcesso)
                .IsRequired()
                .HasColumnName("ControleAcesso");
            builder.Property(c => c.Superintendencia)
                .IsRequired()
                .HasColumnName("Superintendencia");
        }
    }
}
