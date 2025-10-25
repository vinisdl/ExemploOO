using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_GB.Entidades
{
    internal class Aluno : Usuario
    {
        public string Curso { get; set; }

        public Aluno(string nome, int id, string curso) : base(nome, id)
        {
            Curso = curso;
        }

        public override string ExibirTipoUsuario()
        {
            return "Aluno";
        }
    }
}
