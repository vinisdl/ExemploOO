using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_GB.Entidades
{
    internal abstract class Usuario
    {
        public string Nome { get; set; }
        public int ID { get; set; }

        public Usuario(string nome, int id)
        {
            Nome = nome;
            ID = id;
        }

        public abstract string ExibirTipoUsuario();
    }
}
