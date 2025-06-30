class Menu
{
    protected PrincipalFunctions principal;

    // " inicializa o menu usando instancia de PrincipalFunctions para acesso aos dados do sistema"
    public Menu(PrincipalFunctions principal)
    {
        this.principal = principal;
    }

    // " exibe o menu principal usando contagem de clubes e partidas para mostrar opcoes de gerenciamento"
    public void ExibirMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("===== SISTEMA DE CLUBES DE FUTEBOL =====");
        Console.WriteLine($"\nClubes: {principal.ObterQuantidadeClubes()} | Partidas: {principal.ObterTodasPartidas().Count()}");
        Console.WriteLine("\n[1] Cadastrar Dados");
        Console.WriteLine("[2] Gerenciar Partidas");
        Console.WriteLine("[3] Listar Dados");
        Console.WriteLine("[4] Excluir Dados");
        Console.WriteLine("[5] Salvar Dados");
        Console.WriteLine("[0] Sair\n");
        Console.Write("Escolha uma opção: ");
    }

    // " processa selecao do usuario usando switch-case para direcionar para submenus especificos"
    public virtual void ProcessarOpcao(int opcao)
    {
        switch (opcao)
        {
            case 1:
                new MenuCadastrar(principal).Executar();
                break;
            case 2:
                new MenuPartidas(principal).Executar();
                break;
            case 3:
                new MenuListar(principal).Executar();
                break;
            case 4:
                new MenuExcluir(principal).Executar();
                break;
            case 5:
                Persistencia.SalvarDados(principal);
                Exibir.ExibirMensagem("Dados salvos com sucesso!");
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Exibir.ExibirMensagem("Opção inválida!");
                break;
        }
    }

    // " executa o fluxo principal do menu usando loop continuo com validacao de entrada para controle do programa"
    public virtual void Executar()
    {
        while (true)
        {
            ExibirMenuPrincipal();

            if (!int.TryParse(Console.ReadLine(), out int opcao))
            {
                Exibir.ExibirMensagem("Opção inválida!");
                continue;
            }

            if (opcao == 0)
            {
                Persistencia.SalvarDados(principal);
                Environment.Exit(0);
            }

            ProcessarOpcao(opcao);
        }
    }
}