using DiarioDeBordo.Dominio.Entidades;
using DiarioDeBordo.Infra.Dados.Mapeamento;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiarioDeBordo.Infra.Dados.Contexto
{
    public class DiarioContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    optionsBuilder.UseSqlServer("server=DFCPT0054D\\BDLOCAL;database=DiarioDeBordo;trusted_connection=true;"); // Máquina local - Thiago
            //if (!optionsBuilder.IsConfigured)
            //    optionsBuilder.UseSqlServer("server=DFCPT0048D;database=DiarioDeBordo;trusted_connection=true;"); // Máquina local - Charles
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("server=DFCPT000407D;database=DiarioDeBordo;trusted_connection=true;"); // Novo servidor
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
            modelBuilder.Entity<Atividade>(new AtividadeMap().Configure);
            modelBuilder.Entity<AtividadeEfetuada>(new AtividadeEfetuadaMap().Configure);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<AtividadeEfetuada> AtividadesEfetuadas { get; set; }
    }
}
