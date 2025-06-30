class MenuPartidas : Menu
{
    private readonly PartidasFunctions partidasFunctions;

    // " inicializa submenu de partidas usando instancia de PartidasFunctions para operacoes relacionadas a jogos"
    public MenuPartidas(PrincipalFunctions principal) : base(principal)
    {
        partidasFunctions = new PartidasFunctions(principal);
    }

    // " exibe opcoes de gerenciamento de partidas usando menu textual para selecao de acoes sobre jogos"
    public void ExibirMenuPartidas()
    {
        Console.Clear();
        Console.WriteLine("===== MENU DE PARTIDAS =====");
        Console.WriteLine("\n[1] Nova Partida Manual");
        Console.WriteLine("[2] Nova Partida Simulada");
        Console.WriteLine("[3] Ver Partidas Pendentes");
        Console.WriteLine("[4] Agendar Partida");
        Console.WriteLine("[5] Ver Histórico de Partidas");
        Console.WriteLine("[0] Voltar\n");
        Console.Write("Escolha uma opção: ");
    }

    // " direciona operacoes de partidas usando delegacao para PartidasFunctions conforme acao selecionada"
    public override void ProcessarOpcao(int opcao)
    {
        switch (opcao)
        {
            case 1:
                partidasFunctions.NovaPartidaManual();
                break;
            case 2:
                partidasFunctions.NovaPartidaSimulada();
                break;
            case 3:
                partidasFunctions.VerPartidasPendentes();
                break;
            case 4: 
                partidasFunctions.AgendarPartida();
                break;
            case 5:
                partidasFunctions.VerHistoricoPartidas();
                break;
            case 0:
                return;
            default:
                Exibir.ExibirMensagem("Opção inválida!");
                break;
        }
    }

    // " gerencia fluxo do submenu usando loop continuo com validacao de entrada para manter contexto de partidas"
    public override void Executar()
    {
        while (true)
        {
            ExibirMenuPartidas();

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