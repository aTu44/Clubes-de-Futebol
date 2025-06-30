class MenuExcluir : Menu
{
    private readonly ExcluirFunctions excluir;

    // " inicializa submenu de exclusao usando instancia de ExcluirFunctions para operacoes de remocao"
    public MenuExcluir(PrincipalFunctions principal) : base(principal)
    {
        excluir = new ExcluirFunctions(principal);
    }

    // " exibe opcoes de exclusao usando menu textual para selecao de entidades a serem removidas"
    public void ExibirMenuExcluir()
    {
        Console.Clear();
        Console.WriteLine("===== EXCLUIR DADOS =====");
        Console.WriteLine($"\nO que deseja excluir?");
        Console.WriteLine("\n[1] Excluir Clube");
        Console.WriteLine("[2] Excluir Jogador");
        Console.WriteLine("[3] Excluir Técnico");
        Console.WriteLine("[4] Excluir Partida Agendada");
        Console.WriteLine("[0] Voltar\n");
        Console.Write("Escolha uma opção: ");
    }

    // " direciona operacoes de exclusao usando delegacao para ExcluirFunctions conforme entidade selecionada"
    public override void ProcessarOpcao(int opcao)
    {
        switch (opcao)
        {
            case 1: excluir.ExcluirClube(); break;
            case 2: excluir.ExcluirJogador(); break;
            case 3: excluir.ExcluirTecnico(); break;
            case 4: excluir.ExcluirPartidaAgendada(); break;
            case 0: return; // Volta ao menu anterior
            default: Exibir.ExibirMensagem("Opção inválida!"); break;
        }
    }

    // " gerencia fluxo do submenu usando loop controlado para manter usuario nesta tela ate selecionar voltar"
    public override void Executar()
    {
        while (true)
        {
            ExibirMenuExcluir();

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