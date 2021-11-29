using ClassLibrary1.Models;
using System;

namespace ClassLibrary1
{
    public class Projeto
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int Duracao  { get; set; } //em horas - verificar

        //[Foreignkey("Funcionario")]

        //public int IdFuncionarioResponsavel { get; set; }
        //public Funcionario Funcionario { get; set; }

    }
}
