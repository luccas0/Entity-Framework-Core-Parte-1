using Desafio1_IsolarMapeamento.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_IsolarMapeamento.Dados
{
    public class PersonagemContext : DbContext
    {
        public DbSet<Personagem> Personagens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AluraFilmes;Trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personagem>()
                .ToTable("lotr_characters");

            modelBuilder.Entity<Personagem>()
                .Property(p => p.Id)
                .HasColumnName("character_id");

            modelBuilder.Entity<Personagem>()
                .Property(p => p.Nome)
                .HasColumnName("character_name")
                .HasColumnType("varchar(60)")
                .IsRequired();
        }
    }
}
