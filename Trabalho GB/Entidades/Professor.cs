using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_GB.Entidades
{
    internal class Professor : Usuario
    {
        public string Departamento { get; set; }

        public Professor(string nome, int id, string departamento) : base(nome, id)
        {
            Departamento = departamento;
        }

        public override string ExibirTipoUsuario()
        {
            return "Professor";
        }
    }
}
