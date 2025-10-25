using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_GB.Entidades
{
    internal class Emprestimo
    {
        public Livro Livro { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public Emprestimo(Livro livro, Usuario usuario)
        {
            Livro = livro;
            Usuario = usuario;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = null;
        }

        public void ExibirResumoEmprestimo()
        {
            Console.WriteLine("\nResumo do Empréstimo:");
            Console.WriteLine($"Livro: {Livro.Titulo}");
            Console.WriteLine($"Usuário: {Usuario.Nome} ({Usuario.ExibirTipoUsuario()})");
            Console.WriteLine($"Data do Empréstimo: {DataEmprestimo:dd/MM/yyyy}");
            
            if (DataDevolucao.HasValue)
            {
                Console.WriteLine($"Data de Devolução: {DataDevolucao.Value.ToString("dd/MM/yyyy")}");
            }
            else
            {
                Console.WriteLine("Status: Empréstimo Ativo");
            }
        }

        public void RegistrarDevolucao()
        {
            DataDevolucao = DateTime.Now;
            Livro.Devolver();
        }
    }
}
