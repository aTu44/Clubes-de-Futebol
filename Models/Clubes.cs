// Classe que representa um clube de futebol
[Serializable]
public class Clube
{
    public string Nome { get; set; }

    public int Titulos { get; set; }

    public List<Jogador> Jogadores { get; } = new List<Jogador>();

    public Tecnico Tecnico { get; set; }
    
    public int Id { get; set; }

    // "Esse construtor padrao permite serializacao usando inicializacao implicita para compatibilidade com XML"
    public Clube(){}
    
    // "Esse construtor inicializa clube basico usando nome e titulos para criacao simplificada"
    public Clube(String nome, int titulos)
    {
        Nome = nome;
        Titulos = titulos;
    }
    
    // "Esse construtor cria clube completo usando identificador adicional para controle de unicidade"
    public Clube(String nome, int titulos, int id)
    {
        Nome = nome;
        Titulos = titulos;
        Id = id;
    }

    // " adiciona jogador"
    public void AdicionarJogador(Jogador jogador) => Jogadores.Add(jogador);

    // " associa tecnico ao clube""
    public void AdicionarTecnico(Tecnico tecnico) => Tecnico = tecnico;

    // " calcula forca do time usando media de notas de jogadores validos, tecnico e titulos para avaliacao competitiva"
    public double CalcularMediaNotas()
    {
        var jogadoresValidos = Jogadores.Where(j => j.Saude).ToList();
        var notaTecnico = Tecnico?.Nota ?? 0;

        return jogadoresValidos.Any() ? 
            jogadoresValidos.Average(j => j.Nota) + (notaTecnico / 2) + (Titulos / 4) : 0;
    }

    // " verifica disponibilidade de jogadores usando contagem de saudaveis para validacao de partidas"
    public bool TemJogadoresSuficientes()
    {
        return Jogadores.Count(j => j.Saude) >= 11;
    }

    // " conta atletas disponiveis usando filtro por condicao de saude para planejamento de jogos"
    public int JogadoresDisponiveis()
    {
        return Jogadores.Count(j => j.Saude);
    }
}