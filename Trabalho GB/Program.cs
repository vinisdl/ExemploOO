using Trabalho_GB.Entidades;

internal class Program
{

    private static readonly List<Livro> livros = new List<Livro>();
    private static readonly List<Usuario> usuarios = new List<Usuario>();
    private static readonly List<Emprestimo> emprestimos = new List<Emprestimo>();
    private static readonly (
        int CadastrarLivro,
        int CadastrarUsuario,
        int EmprestarLivro,
        int DevolverLivro,
        int VerificarDisponibilidade,
        int ListarDatabase,
        int Sair
    ) OpcaoMenu = (1, 2, 3, 4, 5, 6, 7);

    private static void Main(string[] args)
    {
        // Configurando para aceitar ~ no console.readline
        try
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            Console.InputEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
        }
        catch
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.InputEncoding = System.Text.Encoding.Default;
        }

        Console.WriteLine("=== SISTEMA DE GERENCIAMENTO DE BIBLIOTECA ===\n");

        Livro livro1, livro2, livro3;
        LivrosBase(out livro1, out livro2, out livro3);
        Aluno aluno1;
        Professor professor1;
        UsuariosBase(out aluno1, out professor1);

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
        Emprestimo? emprestimo3 = null;
        if (livro1.Emprestar())
        {
            emprestimo3 = new Emprestimo(livro1, professor1);
            emprestimo3.ExibirResumoEmprestimo();
        }
        emprestimos.AddRange(new Emprestimo[] { emprestimo1, emprestimo2, emprestimo3 });
        Console.WriteLine("\n=== FIM DA SIMULAÇÂO ===");
        
        int opcao = 0;

        do
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine($"{OpcaoMenu.CadastrarLivro} - Cadastrar Livro");
            Console.WriteLine($"{OpcaoMenu.CadastrarUsuario} - Cadastrar Usuário");
            Console.WriteLine($"{OpcaoMenu.EmprestarLivro} - Emprestar Livro");
            Console.WriteLine($"{OpcaoMenu.DevolverLivro} - Devolver Livro");
            Console.WriteLine($"{OpcaoMenu.VerificarDisponibilidade} - Verificar Disponibilidade");
            Console.WriteLine($"{OpcaoMenu.ListarDatabase} - Listar DataBase");
            Console.WriteLine($"{OpcaoMenu.Sair} - Sair");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
                opcao = -1;


            switch (opcao)
            {
                case var _  when OpcaoMenu.CadastrarLivro == opcao:
                    CadastrarLivro();
                    break;
                case var _ when OpcaoMenu.CadastrarLivro == opcao:
                    CadastrarUsuario();
                    break;
                case var _ when OpcaoMenu.EmprestarLivro == opcao:
                    EmprestarLivro();
                    break;
                case var _ when OpcaoMenu.DevolverLivro == opcao:
                    DevolverLivro();
                    break;
                case var _ when OpcaoMenu.VerificarDisponibilidade == opcao:
                    VerificarDisponibilidade();
                    break;
                case var _ when OpcaoMenu.ListarDatabase == opcao:
                    ListarTudo();
                    break;
                case var _ when OpcaoMenu.Sair == opcao:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        } while ((opcao) != OpcaoMenu.Sair);
    }

    private static void ListarTudo()
    {
        Console.WriteLine("\n--- LISTAGEM DE TODOS OS ELEMENTOS ---");
        Console.WriteLine("\n--- LIVROS: --- ");
        foreach (Livro livro in livros)
        {
            livro.ExibirInformacoes();
        }
        Console.WriteLine("\n--- USUÁRIOS: --- ");
        foreach (Usuario usuario in usuarios)
        {
            usuario.ExibirInformacoes();
        }
        Console.WriteLine("\n--- EMPRESTIMOS: --- ");
        foreach (Emprestimo emprestimo in emprestimos)
        {
            emprestimo.ExibirResumoEmprestimo();
        }
        Console.WriteLine("\n");
    }

    private static void CadastrarLivro()
    {
        Console.WriteLine("\n--- CADASTRO DE LIVROS ---");
        Console.Write("Digite o título do livro: ");
        string titulo = Console.ReadLine();
        Console.Write("Digite o autor do livro: ");
        string autor = Console.ReadLine();
        Console.Write("Digite o ISBN do livro: ");
        string isbn = Console.ReadLine();

        Livro livro = new Livro(titulo, autor, isbn);
        livros.Add(livro);
        Console.WriteLine("Livro cadastrado com sucesso!\n");
    }

    private static void CadastrarUsuario()
    {
        Console.WriteLine("\n--- CADASTRO DE USUÁRIOS ---");
        Console.Write("Digite o nome do usuário: ");
        string nome = Console.ReadLine();
        Console.Write("Digite o tipo de usuário (1 - Aluno, 2 - Professor): ");
        int tipo = int.Parse(Console.ReadLine());
        if (tipo == 1)
        {
            Console.Write("Digite o curso do aluno: ");
            string curso = Console.ReadLine();
            Usuario usuario = new Aluno(nome, GetUserId(), curso);
            usuarios.Add(usuario);
        }
        else if (tipo == 2)
        {
            Console.Write("Digite o departamento do professor: ");
            string departamento = Console.ReadLine();
            Usuario usuario = new Professor(nome, GetUserId(), departamento);
            usuarios.Add(usuario);
        }
        else
        {
            Console.WriteLine("Tipo de usuário inválido");
            return;
        }
        Console.WriteLine("Usuário cadastrado com sucesso!\n");
    }

    private static int GetUserId()
    {
        return usuarios.Max(x => x.ID) + 1;
    }

    private static void EmprestarLivro()
    {
        Console.WriteLine("\n--- EMPRÉSTIMO DE LIVROS ---");
        Console.Write("Digite o ISBN do livro: ");
        string isbn = Console.ReadLine();
        Livro livro = livros.FirstOrDefault(l => l.ISBN == isbn);
        if (livro == null)
        {
            Console.WriteLine("Livro não encontrado");
            return;
        }
        Console.Write("Digite o nome do usuário: ");
        string nome = Console.ReadLine();
        Usuario usuario = usuarios.FirstOrDefault(u => u.Nome == nome);
        if (usuario == null)
        {
            Console.WriteLine("Usuário não encontrado");
            return;
        }
        Emprestimo emprestimo = new Emprestimo(livro, usuario);
        emprestimos.Add(emprestimo);
        Console.WriteLine("Livro emprestado com sucesso!\n");
    }

    private static void DevolverLivro()
    {
        Console.WriteLine("\n--- DEVOLUÇÃO DE LIVROS ---");
        Console.Write("Digite o ISBN do livro: ");
        string isbn = Console.ReadLine();
        Livro livro = livros.FirstOrDefault(l => l.ISBN == isbn);
        emprestimos.RemoveAll(x => x.Livro == livro);

        livro.Disponivel = true;
        Console.WriteLine("Livro devolvido com sucesso!\n");

    }
    private static void VerificarDisponibilidade()
    {
        Console.WriteLine("\n--- VERIFICAÇÃO DE DISPONIBILIDADE ---");
        Console.Write("Digite o ISBN do livro: ");
        string isbn = Console.ReadLine();
        Livro livro = livros.FirstOrDefault(l => l.ISBN == isbn);

        if (livro == null)
        {
            Console.WriteLine("Livro não encontrado");
            return;
        }
        Console.WriteLine($"Livro: {livro.Titulo} - Disponível: {(livro.Disponivel ? "Sim" : "Não")}");
    }


    private static void UsuariosBase(out Aluno aluno1, out Professor professor1)
    {
        Console.WriteLine("--- CADASTRO DE USUÁRIOS ---");
        aluno1 = new Aluno("João Silva", 1, "Ciência da Computação");
        professor1 = new Professor("Dr. Carlos Mendes", 2, "Engenharia de Software");
        usuarios.AddRange(new Usuario[] { aluno1, professor1 });

        Console.WriteLine($"Aluno cadastrado: {aluno1.Nome} - Curso: {aluno1.Curso}");
        Console.WriteLine($"Professor cadastrado: {professor1.Nome} - Departamento: {professor1.Departamento}\n");
    }

    private static void LivrosBase(out Livro livro1, out Livro livro2, out Livro livro3)
    {
        Console.WriteLine("--- CADASTRO DE LIVROS ---");
        livro1 = new Livro("Introdução à POO", "João Santos", "978-1234567890");
        livro2 = new Livro("C# Avançado", "Maria Silva", "978-0987654321");
        livro3 = new Livro("Algoritmos e Estruturas de Dados", "Pedro Oliveira", "978-1122334455");
        livros.AddRange(new Livro[] { livro1, livro2, livro3 });

        Console.WriteLine("Livros cadastrados com sucesso!\n");
    }
}