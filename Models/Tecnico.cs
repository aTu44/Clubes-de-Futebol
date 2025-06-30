[Serializable]
public class Tecnico
{
 
    public string Nome { get; set; }
    
  
    public double Nota { get; set; }

    // "Esse construtor padrao permite serializacao usando inicializacao implicita para compatibilidade com XML"
    public Tecnico() { }

    public Tecnico(String nome, double nota)
    {
        Nome = nome;
        Nota = nota;
    }
}