using ClassLibrary1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsultaTrabalhadoresPorProjeto();
            ConsultaProjetoPorTrabalhador();
            ConsultaProjetosDuracao();
        }

        private static void ConsultaTrabalhadoresPorProjeto()
        {
            using (ContextoDB bd = new ContextoDB())
            {
                Console.WriteLine("*LISTA TRABALHADORES POR PROJETO*");
                var consulta = bd.Funcionarios.Include("AssociacaoProjetos.Projeto");
                foreach (var nome in consulta)
                {
                    Console.WriteLine($"Funcionário: {nome.Nome}");
                    foreach (var projeto in nome.AssociacaoProjetos)
                    {
                        Console.WriteLine($"Projeto: {projeto.Projeto.Nome}");
                    }
                }

            }
        }

        private static void ConsultaProjetoPorTrabalhador()
        {
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine("*LISTA PROJETOS POR TRABALHADOR*");

            using (ContextoDB bd = new ContextoDB())
            {
                var consulta = bd.Projetos.Include("AssociacaoProjetos.Funcionario");
                foreach (var projeto in consulta)
                {
                    Console.WriteLine($"Projeto: {projeto.Nome}");
                    foreach (var funcionario in projeto.AssociacaoProjetos)
                    {
                        Console.WriteLine($"Funcionário: {funcionario.Funcionario.Nome}");
                    }
                }
            }
                
        }
        private static void ConsultaProjetosDuracao()
        {
            using (ContextoDB bd = new ContextoDB())
            {
                
                var query = from p in bd.Projetos
                            join a in bd.Atividades on p.Id equals a.IdProjeto                             
                            select new { projeto = p.Nome, atividade = a.Nome, duracao = a.Duracao };

                Console.WriteLine("_________________________________________________________");
                Console.WriteLine("*LISTA PROJETOS E DURAÇÃO ATIVIDADES*");
                foreach (var item in query)
                {
                   
                    Console.WriteLine($"Projeto: {item.projeto} - Atividade: {item.atividade} - Duração: {item.duracao}");
                }

                //Console.WriteLine("*LISTA PROJETOS E DURAÇÃO ATIVIDADES*");
                //var consulta = bd.Projetos.Include("Atividades.Projeto");
                //foreach (var projeto in consulta)
                //{
                //    Console.WriteLine($"Projeto: {projeto.Nome}");
                //    foreach (var atividade in projeto.Atividades)
                //    {
                //        Console.WriteLine($"Atividade: {atividade.Nome}, Duração em horas: {atividade.Duracao} Total atividades: {atividade.Duracao}");
                //    }
                //}

            }
        }
    }
}
