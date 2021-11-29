using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary1.Models
{
    public class AssociacaoProjeto
    {
        public int Id { get; set; }

        [ForeignKey("Projeto")]
        public int? IdProjeto { get; set; }
        public Projeto Projeto { get; set; }

        [ForeignKey("Funcionario")]
        public int? IdFuncionario { get; set; }
        public Funcionario Funcionario { get; set; }

    }
}
