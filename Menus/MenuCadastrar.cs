class MenuCadastrar : Menu
{
    private readonly CadastrarFunctions cadastrar;

    // " inicializa submenu de cadastro usando instancia de CadastrarFunctions para operacoes especificas"
    public MenuCadastrar(PrincipalFunctions principal) : base(principal)
    {
        cadastrar = new CadastrarFunctions(principal);
    }

    // " exibe opcoes de cadastro usando menu textual para selecao de entidades a serem registradas"
    public void ExibirMenuCadastrar()
    {
        Console.Clear();
        Console.WriteLine("===== CADASTRO DE DADOS =====");
        Console.WriteLine($"\nO que deseja cadastrar?");
        Console.WriteLine("\n[1] Cadastrar Clube");
        Console.WriteLine("[2] Cadastrar Jogador");
        Console.WriteLine("[3] Cadastrar Tecnico");
        Console.WriteLine("[0] Voltar\n");
        Console.Write("Escolha uma opção: ");
    }

    // " direciona operacoes usando delegacao para CadastrarFunctions conforme opcao selecionada"
    public override void ProcessarOpcao(int opcao)
    {
        switch (opcao)
        {
            case 1: cadastrar.CadastrarClube(); break;
            case 2: cadastrar.CadastrarJogador(); break;
            case 3: cadastrar.CadastrarTecnico(); break;
            case 0: return; // Volta ao menu anterior
            default: Exibir.ExibirMensagem("Opção inválida!"); break;
        }
    }
    
    // " gerencia fluxo do submenu usando loop controlado para manter usuario nesta tela ate selecionar voltar"
    public override void Executar()
    {
        while (true)
        {
            ExibirMenuCadastrar();
            
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