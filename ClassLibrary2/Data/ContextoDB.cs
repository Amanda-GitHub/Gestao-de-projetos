using ClassLibrary1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Data
{
    public class ContextoDB : DbContext
    {
        public DbSet<AssociacaoProjeto> AssociacaoProjetos { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=Projetos; Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().HasData(
                new Funcionario() { Id = 1 ,Nome ="Aline Dantas", Funcao="Programador", IdChefe = 1, IdSubChefe = null },
                new Funcionario() { Id = 2, Nome = "Sergio Rodrigues", Funcao = "Programador", IdChefe = null, IdSubChefe = 1 },
                new Funcionario() { Id = 3, Nome = "Marcos Silva", Funcao = "Programador", IdChefe = null, IdSubChefe = null },
                new Funcionario() { Id = 4, Nome = "Paula Machado", Funcao = "Programador", IdChefe = null, IdSubChefe = 2 }
                );
            modelBuilder.Entity<Projeto>().HasData(
                new Projeto() { Id = 1, Nome = "Site Vendas", DataInicio = new DateTime(2020, 11, 20), Duracao = 40, IdResponsavel = 2 },
                new Projeto() { Id = 2, Nome = "Sistema de faturacao", DataInicio = new DateTime(2021, 01, 05), Duracao = 160, IdResponsavel = 1 },
                new Projeto() { Id = 3, Nome = "App mobile", DataInicio = new DateTime(2021, 06, 10), Duracao = 48, IdResponsavel = 3 }
                );
            modelBuilder.Entity<Atividade>().HasData(
                new Atividade() { Id = 1, Nome ="Criação código", Duracao = 24, IdProjeto = 1},
                new Atividade() { Id = 2, Nome = "Criação BD", Duracao = 8, IdProjeto = 1 },
                new Atividade() { Id = 3, Nome = "Populate BD", Duracao = 24, IdProjeto = 2 },
                new Atividade() { Id = 4, Nome = "Teste produção", Duracao = 60, IdProjeto = 2 },
                new Atividade() { Id = 5, Nome = "Criação parte gráfica", Duracao = 16, IdProjeto = 3 },
                new Atividade() { Id = 6, Nome = "Populate BD", Duracao = 20, IdProjeto = 3 }
                );
            modelBuilder.Entity<AssociacaoProjeto>().HasData(
                new AssociacaoProjeto() { Id = 1, IdFuncionario = 1, IdProjeto = 2 },
                new AssociacaoProjeto() { Id = 2, IdFuncionario = 1, IdProjeto = 3 },
                new AssociacaoProjeto() { Id = 3, IdFuncionario = 2, IdProjeto = 2 },
                new AssociacaoProjeto() { Id = 4, IdFuncionario = 4, IdProjeto = 3 },
                new AssociacaoProjeto() { Id = 5, IdFuncionario = 3, IdProjeto = 1 },
                new AssociacaoProjeto() { Id = 6, IdFuncionario = 2, IdProjeto = 1 }
                );
                
        }
    }
}
