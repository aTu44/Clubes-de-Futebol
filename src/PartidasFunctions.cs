class PartidasFunctions
{
    private readonly PrincipalFunctions principal;

    // " inicializa operacoes de partidas usando instancia de PrincipalFunctions para integracao com dados principais"
    public PartidasFunctions(PrincipalFunctions principal)
    {
        this.principal = principal;
    }

    // "cria nova partida manual usando entrada de times e placar para registro de resultado direto"
    public void NovaPartidaManual()
    {
        Console.Clear();
        Console.WriteLine("=== NOVA PARTIDA MANUAL ===");

        (Clube timeCasa, Clube timeFora) = ObterTimesPartida();
        if (timeCasa == null || timeFora == null) return;

        (int golsCasa, int golsFora) = ObterPlacar(timeCasa, timeFora);
        if (golsCasa < 0 || golsFora < 0) return;

        Partida partida = new Partida(timeCasa, timeFora, "Manual");
        partida.DefinirResultado(golsCasa, golsFora);
        principal.AdicionarPartida(partida);

        Console.WriteLine($"\nResultado registrado: {timeCasa.Nome} {golsCasa} x {golsFora} {timeFora.Nome}");
        Exibir.ExibirMensagem("Partida registrada com sucesso!");
    }

    // "realiza partida simulada usando validacao de elenco e algoritmo de geracao de placar para resultado automatico"
    public void NovaPartidaSimulada()
    {
        Console.Clear();
        Console.WriteLine("=== NOVA PARTIDA SIMULADA ===");

        (Clube timeCasa, Clube timeFora) = ObterTimesPartida();
        if (timeCasa == null || timeFora == null) return;

        if (!ValidarElenco(timeCasa) || !ValidarElenco(timeFora)) return;

        Partida partida = new Partida(timeCasa, timeFora, "Simulada");
        partida.Simular();
        principal.AdicionarPartida(partida);

        Console.WriteLine($"\nResultado da simulação: {timeCasa.Nome} {partida.GolsCasa} x {partida.GolsFora} {timeFora.Nome}");
        Exibir.ExibirMensagem("Simulação concluída!");
    }

    // " exibe partidas pendentes usando listagem numerada e permite simulacao individual para conclusao de jogos"
    public void VerPartidasPendentes()
    {
        Console.Clear();
        Console.WriteLine("=== PARTIDAS PENDENTES ===");

        var pendentes = principal.ObterPartidasPendentes()
            .OrderBy(p => p.Data) // Ordenar por data
            .ToList();
        
        if (!pendentes.Any())
        {
            Exibir.ExibirMensagem("Nenhuma partida pendente!");
            return;
        }

        for (int i = 0; i < pendentes.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {pendentes[i].ObterResumoAgendamento()}");
        }

        Console.Write("\nDigite o número da partida para simular (0 para voltar): ");
        if (int.TryParse(Console.ReadLine(), out int escolha))
        {
            if (escolha == 0) return;
            if (escolha > 0 && escolha <= pendentes.Count)
            {
                Partida partida = pendentes[escolha - 1];
                partida.Simular();
                Console.WriteLine($"\nResultado: {partida.TimeCasa.Nome} {partida.GolsCasa} x {partida.GolsFora} {partida.TimeFora.Nome}");
                Exibir.ExibirMensagem("Partida simulada com sucesso!");
            }
        }
    }

    // "agenda nova partida usando entrada de data/hora e validacao de futuro para criacao de evento programado"
    public void AgendarPartida()
    {
        Console.Clear();
        Console.WriteLine("=== AGENDAR NOVA PARTIDA ===");

        (Clube timeCasa, Clube timeFora) = ObterTimesPartida();
        if (timeCasa == null || timeFora == null) return;

        DateTime dataPartida;
        bool dataValida = false;
        do
        {
            Console.Write("Data da partida (dd/mm/aaaa): ");
            string inputData = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrWhiteSpace(inputData))
            {
                Exibir.ExibirMensagem("Data não pode ser vazia!");
                return;
            }

            if (!DateTime.TryParse(inputData, out dataPartida))
            {
                Console.WriteLine("Formato inválido! Use o formato dd/mm/aaaa.");
            }
            else
            {
                dataValida = true;
            }
        } while (!dataValida);

        DateTime horaPartida;
        bool horaValida = false;
        do
        {
            Console.Write("Hora da partida (hh:mm): ");
            string inputHora = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrWhiteSpace(inputHora))
            {
                Exibir.ExibirMensagem("Hora não pode ser vazia!");
                return;
            }

            if (!DateTime.TryParse(inputHora, out horaPartida))
            {
                Console.WriteLine("Formato inválido! Use o formato hh:mm.");
            }
            else
            {
                horaValida = true;
            }
        } while (!horaValida);

        DateTime dataHoraPartida = new DateTime(
            dataPartida.Year, 
            dataPartida.Month, 
            dataPartida.Day,
            horaPartida.Hour, 
            horaPartida.Minute, 
            0);

        if (dataHoraPartida <= DateTime.Now)
        {
            Exibir.ExibirMensagem("A data/hora da partida deve ser futura!");
            return;
        }

        try
        {
            Partida partida = new Partida(timeCasa, timeFora, "Agendada");
            partida.Agendar(dataHoraPartida);
            principal.AdicionarPartida(partida);

            Console.WriteLine("\n=== PARTIDA AGENDADA COM SUCESSO ===");
            Console.WriteLine($"\n{timeCasa.Nome} vs {timeFora.Nome}");
            Console.WriteLine($"Data: {dataHoraPartida:dddd, dd/MM/yyyy}");
            Console.WriteLine($"Hora: {dataHoraPartida:HH\\hmm}");
            
            Exibir.ExibirMensagem("A partida foi adicionada ao calendário!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("\nERRO NO AGENDAMENTO:");
            Console.WriteLine(ex.Message);
            Console.WriteLine("\nPor favor, tente novamente com uma data futura.");
            Exibir.ExibirMensagem("");
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nERRO INESPERADO:");
            Console.WriteLine(ex.Message);
            Exibir.ExibirMensagem("Contate o suporte técnico.");
        }
    }

    // " exibe historico de partidas usando ordenacao decrescente por data para apresentacao cronologica invertida"
    public void VerHistoricoPartidas()
    {
        Console.Clear();
        Console.WriteLine("=== HISTÓRICO DE PARTIDAS ===");

        var historico = principal.ObterPartidasFinalizadas().ToList();
        
        if (!historico.Any())
        {
            Exibir.ExibirMensagem("Nenhuma partida registrada!");
            return;
        }

        historico.Sort((a, b) => b.Data.CompareTo(a.Data));
        
        for (int i = 0; i < historico.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {historico[i]}");
        }

        Exibir.ExibirMensagem("");
    }

    // "obtem times participantes usando entrada de nomes e validacao de existencia/clubes diferentes para selecao valida"
    private (Clube, Clube) ObterTimesPartida()
    {
        Console.Write("\nTime da casa: ");
        string casa = Console.ReadLine()?.Trim();
        var timeCasa = principal.BuscarClube(casa);

        Console.Write("Time visitante: ");
        string fora = Console.ReadLine()?.Trim();
        var timeFora = principal.BuscarClube(fora);

        if (timeCasa == null || timeFora == null)
        {
            Exibir.ExibirMensagem("Um ou ambos os clubes não foram encontrados!");
            return (null, null);
        }

        if (timeCasa.Id == timeFora.Id)
        {
            Exibir.ExibirMensagem("Um clube não pode jogar contra si mesmo!");
            return (null, null);
        }

        return (timeCasa, timeFora);
    }

    // " captura placar da partida usando entrada numerica e validacao de nao-negatividade para resultado valido"
    private (int, int) ObterPlacar(Clube timeCasa, Clube timeFora)
    {
        Console.Write($"Gols do {timeCasa.Nome}: ");
        if (!int.TryParse(Console.ReadLine(), out int golsCasa) || golsCasa < 0)
        {
            Exibir.ExibirMensagem("Valor inválido para gols!");
            return (-1, -1);
        }

        Console.Write($"Gols do {timeFora.Nome}: ");
        if (!int.TryParse(Console.ReadLine(), out int golsFora) || golsFora < 0)
        {
            Exibir.ExibirMensagem("Valor inválido para gols!");
            return (-1, -1);
        }

        return (golsCasa, golsFora);
    }

    // "Essa funcao verifica disponibilidade de elenco usando contagem de jogadores saudaveis para validar realizacao de partida"
    private bool ValidarElenco(Clube clube)
    {
        if (!clube.TemJogadoresSuficientes())
        {
            Exibir.ExibirMensagem($"{clube.Nome} não tem jogadores suficientes!");
            return false;
        }
        return true;
    }
}