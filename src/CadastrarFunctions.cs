class CadastrarFunctions
{
    private readonly PrincipalFunctions principal;

    // "inicializa operacoes de cadastro usando instancia de PrincipalFunctions para integracao com dados principais"
    public CadastrarFunctions(PrincipalFunctions principal)
    {
        this.principal = principal;
    }

    // "registra novo clube usando entrada de nome e titulos com validacao de unicidade para criacao de entidade unica"
    public void CadastrarClube()
    {
        Console.Clear();
        Console.WriteLine("=== NOVO CADASTRO DE CLUBE ===");

        Console.Write("\nNome do clube: ");
        string? nome = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(nome))
        {
            Exibir.ExibirMensagem("Nome inválido!");
            return;
        }
        if (principal.BuscarClube(nome) != null)
        {
            Exibir.ExibirMensagem("Clube já cadastrado!");
            return;
        }
        Console.Write("Quantidade de títulos: ");
        if (!int.TryParse(Console.ReadLine(), out int titulos))
        {
            Exibir.ExibirMensagem("Número inválido para títulos!");
            return;
        }

        int novoId = principal.ObterQuantidadeClubes() + 1;

        var novoClube = new Clube(nome, titulos, novoId);

        principal.AdicionarClube(novoClube);
        Exibir.ExibirMensagem($"Clube {nome} cadastrado com sucesso! ID: {novoClube.Id}");
    }

    // "adiciona jogador a clube existente usando busca por nome e validacao de dados para composicao de elenco"
    public void CadastrarJogador()
    {
        Console.Clear();
        Console.WriteLine("=== CADASTRO DE JOGADOR ===");

        Console.Write("\nClube para adicionar: ");
        string nomeClube = Console.ReadLine()?.Trim();

        var clube = principal.BuscarClube(nomeClube);
        if (clube == null)
        {
            Exibir.ExibirMensagem("Clube não encontrado!");
            return;
        }

        Console.Write("\nNome do jogador: ");
        string nomeJogador = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(nomeJogador))
        {
            Exibir.ExibirMensagem("Nome inválido para jogador!");
            return;
        }

        Console.Write("Nota do jogador (0-10): ");
        if (!double.TryParse(Console.ReadLine(), out double nota) || nota < 0 || nota > 10)
        {
            Exibir.ExibirMensagem("Nota inválida! Deve ser entre 0 e 10.");
            return;
        }

        Console.Write("Jogador está saudável? (s/n): ");
        bool saude = Console.ReadLine()?.Trim().ToLower() == "s";

        var novoJogador = new Jogador(nomeJogador, nota, saude);

        clube.AdicionarJogador(novoJogador);
        Exibir.ExibirMensagem($"Jogador {nomeJogador} adicionado ao {clube.Nome}!");
    }

    // "associa tecnico a clube usando verificacao de existencia e faixa de notas para definicao de comando tecnico"
    public void CadastrarTecnico()
    {
        Console.Clear();
        Console.WriteLine("=== CADASTRO DE TÉCNICO ===");

        Console.Write("\nClube para adicionar: ");
        string nomeClube = Console.ReadLine()?.Trim();

        var clube = principal.BuscarClube(nomeClube);
        if (clube == null)
        {
            Exibir.ExibirMensagem("Clube não encontrado!");
            return;
        }

        Console.Write("\nNome do técnico: ");
        string nomeTecnico = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(nomeTecnico))
        {
            Exibir.ExibirMensagem("Nome inválido para técnico!");
            return;
        }

        Console.Write("Nota do técnico (0-10): ");
        if (!double.TryParse(Console.ReadLine(), out double nota) || nota < 0 || nota > 10)
        {
            Exibir.ExibirMensagem("Nota inválida! Deve ser entre 0 e 10.");
            return;
        }

        var novoTecnico = new Tecnico(nomeTecnico, nota);

        clube.AdicionarTecnico(novoTecnico);
        Exibir.ExibirMensagem($"Técnico {nomeTecnico} adicionado ao {clube.Nome}!");
    }
}