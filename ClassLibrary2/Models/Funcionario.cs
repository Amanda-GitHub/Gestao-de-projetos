using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary1.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }

        [ForeignKey("Chefe")]
        public int? IdChefe { get; set; }
        public Funcionario Chefe { get; set; }

        [ForeignKey("SubChefe")]
        public int? IdSubChefe { get; set; }
        public Funcionario SubChefe { get; set; }

        public ICollection<AssociacaoProjeto> AssociacaoProjetos { get; set; }

        public ICollection<Projeto> Projetos;

        public ICollection<Funcionario> Responsaveis;

    }
}
