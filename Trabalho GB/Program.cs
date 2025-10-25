using Trabalho_GB.Entidades;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== SISTEMA DE GERENCIAMENTO DE BIBLIOTECA ===\n");

        Console.WriteLine("--- CADASTRO DE LIVROS ---");
        Livro livro1 = new Livro("Introdução à POO", "João Santos", "978-1234567890");
        Livro livro2 = new Livro("C# Avançado", "Maria Silva", "978-0987654321");
        Livro livro3 = new Livro("Algoritmos e Estruturas de Dados", "Pedro Oliveira", "978-1122334455");
        
        Console.WriteLine("Livros cadastrados com sucesso!\n");

        Console.WriteLine("--- CADASTRO DE USUÁRIOS ---");
        Aluno aluno1 = new Aluno("João Silva", 1, "Ciência da Computação");
        Professor professor1 = new Professor("Dr. Carlos Mendes", 2, "Engenharia de Software");
        
        Console.WriteLine($"Aluno cadastrado: {aluno1.Nome} - Curso: {aluno1.Curso}");
        Console.WriteLine($"Professor cadastrado: {professor1.Nome} - Departamento: {professor1.Departamento}\n");

        Console.WriteLine("--- EMPRÉSTIMOS DE LIVROS ---");
        
        Console.WriteLine("\nEmpréstimo 1:");
        Emprestimo? emprestimo1 = null;
        if (livro1.Emprestar())
        {
            emprestimo1 = new Emprestimo(livro1, aluno1);
        }

        Console.WriteLine("\nEmpréstimo 2:");
        Emprestimo? emprestimo2 = null;
        if (livro2.Emprestar())
        {
            emprestimo2 = new Emprestimo(livro2, professor1);
        }

        Console.WriteLine("\nTentativa de emprestar livro já emprestado:");
        livro1.Emprestar();

        Console.WriteLine("\n--- RESUMO DOS EMPRÉSTIMOS ---");
        if (emprestimo1 != null)
        {
            emprestimo1.ExibirResumoEmprestimo();
        }
        
        if (emprestimo2 != null)
        {
            emprestimo2.ExibirResumoEmprestimo();
        }

        Console.WriteLine("\n--- INFORMAÇÕES DOS LIVROS ---");
        Console.WriteLine("\nLivro 1:");
        livro1.ExibirInformacoes();
        
        Console.WriteLine("\nLivro 2:");
        livro2.ExibirInformacoes();
        
        Console.WriteLine("\nLivro 3:");
        livro3.ExibirInformacoes();

        Console.WriteLine("\n--- DEVOLUÇÃO DE LIVROS ---");
        if (emprestimo1 != null)
        {
            Console.WriteLine($"\nDevolvendo livro: {livro1.Titulo}");
            emprestimo1.RegistrarDevolucao();
            
            emprestimo1.ExibirResumoEmprestimo();
        }

        Console.WriteLine("\n--- VERIFICAÇÃO DE DISPONIBILIDADE ---");
        Console.WriteLine("\nLivro 1 após devolução:");
        livro1.ExibirInformacoes();

        Console.WriteLine("\n--- NOVO EMPRÉSTIMO DO LIVRO DEVOLVIDO ---");
        if (livro1.Emprestar())
        {
            Emprestimo emprestimo3 = new Emprestimo(livro1, professor1);
            emprestimo3.ExibirResumoEmprestimo();
        }

        Console.WriteLine("\n=== FIM DO SISTEMA ===");
    }
}