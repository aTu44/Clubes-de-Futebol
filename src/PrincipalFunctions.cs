// Classe principal que gerencia o sistema de clubes
class PrincipalFunctions
{
    private readonly List<Clube> clubes;
    private readonly List<Partida> partidas;

    // " inicializa sistema usando parametro opcional para carregar dados de teste como base inicial do sistema"
    public PrincipalFunctions(bool carregarDadosTeste = false)
    {
        if (carregarDadosTeste)
        {
            clubes = BancoDeDadosFutebol.GerarDadosTeste();
            partidas = BancoDeDadosFutebol.GerarPartidasTeste(clubes);
        }
        else
        {
            clubes = new List<Clube>();
            partidas = new List<Partida>();
        }
    }
    
    // "adiciona partida a lista usando insercao simples para registro de eventos do sistema"
    public void AdicionarPartida(Partida partida) => partidas.Add(partida);

    // "remove partida especifica usando comparacao de objetos para manutencao do calendario"
    public bool RemoverPartida(Partida partida) => partidas.Remove(partida);

    // " retorna todas partidas usando lista somente-leitura para consulta segura do historico"
    public IEnumerable<Partida> ObterTodasPartidas() => partidas.AsReadOnly();

    // " filtra partidas concluidas usando condicao de finalizacao para recuperacao de resultados"
    public IEnumerable<Partida> ObterPartidasFinalizadas() =>
        partidas.Where(p => p.Finalizada);

    // " obtem partidas nao realizadas usando filtro por status pendente para gerenciamento de agendamentos"
    public IEnumerable<Partida> ObterPartidasPendentes() =>
        partidas.Where(p => !p.Finalizada);
    
    // " retorna todos clubes usando colecao imutavel para acesso seguro aos dados registrados"
    public IEnumerable<Clube> ObterTodosClubes() => clubes.AsReadOnly();

    // " conta clubes cadastrados usando propriedade de lista para metricas do sistema"
    public int ObterQuantidadeClubes() => clubes.Count;
    
    // " adiciona novo clube usando verificacao de ID/nome duplicado para garantir unicidade de registros"
    public void AdicionarClube(Clube clube)
    {
        if (!clubes.Any(c => c.Id == clube.Id ||
                      c.Nome.Equals(clube.Nome, StringComparison.OrdinalIgnoreCase)))
        {
            clubes.Add(clube);
        }
        else
        {
            Console.WriteLine($"Erro: Tentativa de adicionar clube duplicado - {clube.Nome}");
        }
    }

    // " busca clube por nome usando comparacao case-insensitive para recuperacao flexivel de dados"
    public Clube? BuscarClube(string nomeClube)
    {
        if (clubes.Count == 0) return null;
        return clubes.FirstOrDefault(c => c.Nome.Equals(nomeClube, StringComparison.OrdinalIgnoreCase));
    }

    // " remove clube por ID usando busca direta para exclusao segura de entidades"
    public void RemoverClube(int id)
    {
        var clube = clubes.FirstOrDefault(c => c.Id == id);
        if (clube != null)
        {
            clubes.Remove(clube);
        }
    }
}