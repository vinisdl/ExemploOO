using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_GB.Entidades
{
    internal class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public bool Disponivel { get; set; }

        public Livro(string titulo, string autor, string isbn)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            Disponivel = true;
        }

        public bool Emprestar()
        {
            if (Disponivel)
            {
                Disponivel = false;
                Console.WriteLine("Livro emprestado com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Livro não está disponível para empréstimo.");
                return false;
            }
        }

        public void Devolver()
        {
            Disponivel = true;
            Console.WriteLine("Livro devolvido com sucesso!");
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Disponível: {(Disponivel ? "Sim" : "Não")}");
        }
    }
}
