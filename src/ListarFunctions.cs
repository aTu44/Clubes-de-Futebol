class ListarFunctions
{
    private readonly PrincipalFunctions principal;

    // "inicializa operacoes de listagem usando instancia de PrincipalFunctions para acesso a dados principais"
    public ListarFunctions(PrincipalFunctions principal)
    {
        this.principal = principal;
    }

    // "exibe dados completos de clube usando busca por nome e detalhamento de elenco/titulos para apresentacao detalhada"
    public void ListarDadosClube()
    {
        Console.Clear();
        Console.WriteLine("=== LISTAR DADOS DE UM CLUBE ===");

        Console.Write("\nNome do clube: ");
        string? nomeClube = Console.ReadLine()?.Trim();

        var clube = principal.BuscarClube(nomeClube);
        if (clube == null)
        {
            Exibir.ExibirMensagem("Clube não encontrado!");
            return;
        }

        Console.WriteLine($"\n{clube.Nome.ToUpper()} (ID: {clube.Id})");
        Console.WriteLine($"Títulos: {clube.Titulos}");
        Console.WriteLine($"Jogadores: {clube.Jogadores.Count} ({clube.JogadoresDisponiveis()} disponíveis)");

        if (clube.Tecnico != null)
        {
            Console.WriteLine($"\nTécnico: {clube.Tecnico.Nome} [Nota: {clube.Tecnico.Nota:F1}]");
        }
        else
        {
            Console.WriteLine("\nTécnico: Não cadastrado");
        }

        if (clube.Jogadores.Count > 0)
        {
            Console.WriteLine("\nJogadores:");
            foreach (var jogador in clube.Jogadores)
            {
                Console.WriteLine($"- {jogador.Nome} [Nota: {jogador.Nota:F1}] | " +
                                $"{(jogador.Saude ? "Saudável" : "Lesionado")}");
            }
        }
        else
        {
            Console.WriteLine("\nNenhum jogador cadastrado");
        }

        Exibir.ExibirMensagem("");
    }

    // "localiza e mostra informacoes de jogador usando pesquisa global e exibicao de clube associado para contextualizacao"
    public void ListarDadosJogador()
    {
        Console.Clear();
        Console.WriteLine("=== LISTAR DADOS DE UM JOGADOR ===");

        Console.Write("\nNome do jogador: ");
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
            jogadorEncontrado = clube.Jogadores.FirstOrDefault(j => j.Nome.Equals(nomeJogador, StringComparison.OrdinalIgnoreCase));

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

        Console.WriteLine($"\nNome: {jogadorEncontrado.Nome}");
        Console.WriteLine($"Nota: {jogadorEncontrado.Nota:F1}");
        Console.WriteLine($"Saúde: {(jogadorEncontrado.Saude ? "Saudável" : "Lesionado")}");
        Console.WriteLine($"Clube: {clubeDoJogador.Nome} (ID: {clubeDoJogador.Id})");

        Exibir.ExibirMensagem("");
    }

    // " busca e apresenta dados de tecnico usando varredura em clubes e exibicao de time vinculado para referencia"
    public void ListarDadosTecnico()
    {
        Console.Clear();
        Console.WriteLine("=== LISTAR DADOS DE UM TÉCNICO ===");

        Console.Write("\nNome do técnico: ");
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

        Console.WriteLine($"\nNome: {tecnicoEncontrado.Nome}");
        Console.WriteLine($"Nota: {tecnicoEncontrado.Nota:F1}");
        Console.WriteLine($"Clube: {clubeDoTecnico.Nome} (ID: {clubeDoTecnico.Id})");

        Exibir.ExibirMensagem("");
    }

    // "lista todos clubes com detalhes usando agrupamento por ID e exibicao hierarquica de jogadores/tecnico para visao geral"
    public void ListarClubes()
    {
        Console.Clear();
        Console.WriteLine("=== CLUBES CADASTRADOS ===");
        
        var todosClubes = principal.ObterTodosClubes().ToList();

        if (!todosClubes.Any())
        {
            Exibir.ExibirMensagem("Nenhum clube cadastrado!");
            return;
        }

        var clubesUnicos = todosClubes
            .GroupBy(c => c.Id)
            .Select(g => g.First())
            .ToList();

        foreach (var clube in clubesUnicos)
        {
            Console.WriteLine($"\n{clube.Nome.ToUpper()} (ID: {clube.Id})");
            Console.WriteLine($"Títulos: {clube.Titulos}");
            Console.WriteLine($"Jogadores: {clube.Jogadores.Count} ({clube.JogadoresDisponiveis()} disponíveis)");

            Console.WriteLine(clube.Tecnico != null
                ? $"\nTécnico: {clube.Tecnico.Nome} [Nota: {clube.Tecnico.Nota:F1}]"
                : "\nTécnico: Não cadastrado");

            if (clube.Jogadores.Count > 0)
            {
                Console.WriteLine("\nJogadores:");
                foreach (var jogador in clube.Jogadores)
                {
                    Console.WriteLine($"- {jogador.Nome} [Nota: {jogador.Nota:F1}] | " +
                                    $"{(jogador.Saude ? "Saudável" : "Lesionado")}");
                }
            }
            else
            {
                Console.WriteLine("\nNenhum jogador cadastrado");
            }

            Console.WriteLine("----------------------------------");
        }

        Exibir.ExibirMensagem(""); 
    }
}