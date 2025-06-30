[Serializable]
public class Jogador
{
    public string Nome { get; set; }

    public double Nota { get; set; }

    public bool Saude { get; set; }

    // "Esse construtor padrao permite serializacao usando inicializacao implicita para compatibilidade com XML"
    public Jogador(){}

    public Jogador(string nome, double nota, bool saude)
    {
        Nome = nome;
        Nota = nota;
        Saude = saude;
    }
}