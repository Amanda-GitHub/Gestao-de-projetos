using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Models
{
    class Atividade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; } //ver duracao em horas

        //[ForeignKey("Projeto")]
        //public int IdProjeto { get; set; }
        //public Projeto Projeto { get; set; }



    }
}
