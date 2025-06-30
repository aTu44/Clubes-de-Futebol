class ExcluirFunctions
{
    private readonly PrincipalFunctions principal;

    // "inicializa operacoes de exclusao usando instancia de PrincipalFunctions para integracao com dados principais"
    public ExcluirFunctions(PrincipalFunctions principal)
    {
        this.principal = principal;
    }

    // "remove clube usando busca por nome e confirmacao interativa para exclusao segura de entidade e dados associados"
    public void ExcluirClube()
    {
        Console.Clear();
        Console.WriteLine("=== EXCLUIR CLUBE ===");

        Console.Write("\nNome do clube a excluir: ");
        string? nomeClube = Console.ReadLine()?.Trim();

        var clube = principal.BuscarClube(nomeClube);
        if (clube == null)
        {
            Exibir.ExibirMensagem("Clube não encontrado!");
            return;
        }

        Console.WriteLine("\nDETALHES DO CLUBE:");
        Console.WriteLine($"Nome: {clube.Nome}");
        Console.WriteLine($"ID: {clube.Id}");
        Console.WriteLine($"Títulos: {clube.Titulos}");
        Console.WriteLine($"Jogadores: {clube.Jogadores.Count}");
        Console.WriteLine($"Técnico: {(clube.Tecnico != null ? clube.Tecnico.Nome : "Nenhum")}");

        Console.Write($"\nTem certeza que deseja excluir o clube {clube.Nome} e todos os seus dados? (s/n): ");
        if (Console.ReadLine()?.Trim().ToLower() != "s")
        {
            Exibir.ExibirMensagem("Operação cancelada.");
            return;
        }

        principal.RemoverClube(clube.Id);
        Exibir.ExibirMensagem($"Clube {clube.Nome} excluído com sucesso!");
    }

    // "deleta jogador usando pesquisa em todos clubes e confirmacao para remocao seletiva de atletas"
    public void ExcluirJogador()
    {
        Console.Clear();
        Console.WriteLine("=== EXCLUIR JOGADOR ===");

        Console.Write("\nNome do jogador a excluir: ");
        string? nomeJogador = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(nomeJogador))
        {
            Exibir.ExibirMensagem("Nome inválido!");
            return;
        }

        Jogador? jogadorEncontrado = null;
        Clube? clubeDoJogador = null;

        foreach (var clube in principal.ObterTodosClubes())
        {
            jogadorEncontrado = clube.Jogadores.FirstOrDefault(j =>
                j.Nome.Equals(nomeJogador, StringComparison.OrdinalIgnoreCase));
            if (jogadorEncontrado != null)
            {
                clubeDoJogador = clube;
                break;
            }
        }

        if (jogadorEncontrado == null)
        {
            Exibir.ExibirMensagem("Jogador não encontrado!");
            return;
        }

        Console.WriteLine("\nDETALHES DO JOGADOR:");
        Console.WriteLine($"Nome: {jogadorEncontrado.Nome}");
        Console.WriteLine($"Nota: {jogadorEncontrado.Nota:F1}");
        Console.WriteLine($"Saúde: {(jogadorEncontrado.Saude ? "Saudável" : "Lesionado")}");
        Console.WriteLine($"\nCLUBE ATUAL: {clubeDoJogador.Nome} (ID: {clubeDoJogador.Id})");

        Console.Write($"\nTem certeza que deseja excluir o jogador {jogadorEncontrado.Nome}? (s/n): ");
        if (Console.ReadLine()?.Trim().ToLower() != "s")
        {
            Exibir.ExibirMensagem("Operação cancelada.");
            return;
        }

        clubeDoJogador.Jogadores.Remove(jogadorEncontrado);
        Exibir.ExibirMensagem($"Jogador {jogadorEncontrado.Nome} excluído com sucesso!");
    }

    // "elimina tecnico usando varredura em clubes e confirmacao para remocao de comissao tecnica"
    public void ExcluirTecnico()
    {
        Console.Clear();
        Console.WriteLine("=== EXCLUIR TÉCNICO ===");

        Console.Write("\nNome do técnico a excluir: ");
        string? nomeTecnico = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(nomeTecnico))
        {
            Exibir.ExibirMensagem("Nome inválido!");
            return;
        }

        Tecnico? tecnicoEncontrado = null;
        Clube? clubeDoTecnico = null;

        foreach (var clube in principal.ObterTodosClubes())
        {
            if (clube.Tecnico != null &&
                clube.Tecnico.Nome.Equals(nomeTecnico, StringComparison.OrdinalIgnoreCase))
            {
                tecnicoEncontrado = clube.Tecnico;
                clubeDoTecnico = clube;
                break;
            }
        }

        if (tecnicoEncontrado == null)
        {
            Exibir.ExibirMensagem("Técnico não encontrado!");
            return;
        }

        Console.WriteLine("\nDETALHES DO TÉCNICO:");
        Console.WriteLine($"Nome: {tecnicoEncontrado.Nome}");
        Console.WriteLine($"Nota: {tecnicoEncontrado.Nota:F1}");
        Console.WriteLine($"\nCLUBE ATUAL: {clubeDoTecnico.Nome} (ID: {clubeDoTecnico.Id})");

        Console.Write($"\nTem certeza que deseja excluir o técnico {tecnicoEncontrado.Nome}? (s/n): ");
        if (Console.ReadLine()?.Trim().ToLower() != "s")
        {
            Exibir.ExibirMensagem("Operação cancelada.");
            return;
        }

        clubeDoTecnico.Tecnico = null;
        Exibir.ExibirMensagem($"Técnico {tecnicoEncontrado.Nome} excluído com sucesso!");
    }
    
    // "cancela partida agendada usando listagem numerada e selecao interativa para remocao de jogos pendentes"
    public void ExcluirPartidaAgendada()
    {
        Console.Clear();
        Console.WriteLine("=== EXCLUIR PARTIDA AGENDADA ===");
        
        var pendentes = principal.ObterPartidasPendentes().ToList();
        if (pendentes.Count == 0)
        {
            Exibir.ExibirMensagem("Não há partidas agendadas!");
            return;
        }
        
        Console.WriteLine("\nPartidas agendadas:\n");
        for (int i = 0; i < pendentes.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {pendentes[i].TimeCasa.Nome} vs {pendentes[i].TimeFora.Nome} - {pendentes[i].Data:dd/MM}");
        }
        
        Console.Write("\nDigite o número da partida a ser excluída (0 para cancelar): ");
        if (int.TryParse(Console.ReadLine(), out int escolha))
        {
            if (escolha == 0) return;
            
            if (escolha > 0 && escolha <= pendentes.Count)
            {
                Partida partida = pendentes[escolha - 1];
                
                Console.WriteLine($"\nTem certeza que deseja excluir esta partida agendada?");
                Console.WriteLine($"\n{partida.TimeCasa.Nome} vs {partida.TimeFora.Nome}");
                Console.WriteLine($"Data: {partida.Data:dd/MM/yyyy}");
                Console.Write("\nConfirmar exclusão? (s/n): ");
                
                if (Console.ReadLine().Trim().ToLower() == "s")
                {
                    if (principal.RemoverPartida(partida))
                    {
                        Exibir.ExibirMensagem("Partida agendada excluída com sucesso!");
                    }
                    else
                    {
                        Exibir.ExibirMensagem("Erro ao excluir partida!");
                    }
                }
                else
                {
                    Exibir.ExibirMensagem("Operação cancelada.");
                }
            }
            else
            {
                Exibir.ExibirMensagem("Número inválido!");
            }
        }
        else
        {
            Exibir.ExibirMensagem("Entrada inválida!");
        }
    }
}