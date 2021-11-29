using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary1.Models
{
    public class Atividade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; } 

        [ForeignKey("Projeto")]
        public int IdProjeto { get; set; }
        public Projeto Projeto { get; set; }



    }
}
