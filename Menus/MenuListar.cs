class MenuListar : Menu
{
    private readonly ListarFunctions listar;

    // " inicializa submenu de listagem usando instancia de ListarFunctions para operacoes de consulta"
    public MenuListar(PrincipalFunctions principal) : base(principal)
    {
        listar = new ListarFunctions(principal);
    }

    // " exibe opcoes de listagem usando menu textual para selecao de entidades a serem consultadas"
    public void ExibirMenuListar()
    {
        Console.Clear();
        Console.WriteLine("===== LISTAR DADOS =====");
        Console.WriteLine($"\nO que deseja listar?");
        Console.WriteLine("\n[1] Listar dados de um Clube");
        Console.WriteLine("[2] Listar dados de um Jogador");
        Console.WriteLine("[3] Listar dados de um Técnico");
        Console.WriteLine("[4] Listar todos os clubes");
        Console.WriteLine("[0] Voltar\n");
        Console.Write("Escolha uma opção: ");
    }

    // " direciona operacoes de listagem usando delegacao para ListarFunctions conforme entidade selecionada"
    public override void ProcessarOpcao(int opcao)
    {
        switch (opcao)
        {
            case 1: listar.ListarDadosClube(); break;
            case 2: listar.ListarDadosJogador(); break;
            case 3: listar.ListarDadosTecnico(); break;
            case 4: listar.ListarClubes(); break;
            case 0: return; // Volta ao menu anterior
            default: Exibir.ExibirMensagem("Opção inválida!"); break;
        }
    }

    // " gerencia fluxo do submenu usando loop continuo com tratamento de entrada para manter contexto de listagem"
    public override void Executar()
    {
        while (true)
        {
            ExibirMenuListar();
            
            if (!int.TryParse(Console.ReadLine(), out int opcao))
            {
                Exibir.ExibirMensagem("Opção inválida!");
                continue;
            }

            if (opcao == 0) break;

            ProcessarOpcao(opcao);
        }
    }
}