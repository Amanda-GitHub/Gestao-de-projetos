using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1.Models
{
    public class Projeto
    {
        public int Id { get; set; }        
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Duracao  { get; set; }

        [ForeignKey("Responsavel")]
        public int IdResponsavel { get; set; }
        public Funcionario Responsavel { get; set; }

        public ICollection<AssociacaoProjeto> AssociacaoProjetos { get; set; }
        public ICollection<Atividade> Atividades { get; set; }
    }
}
