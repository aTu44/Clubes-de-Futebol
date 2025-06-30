[Serializable]
public class Partida
{
  
    public Clube TimeCasa { get; set; }
    
    
    public Clube TimeFora { get; set; }
    
    
    public int GolsCasa { get; set; }
    
    public int GolsFora { get; set; }
    
    public DateTime Data { get; set; }
    
    public string Tipo { get; set; }
    
    public bool Finalizada { get; set; }

    public Partida() { }

    public Partida(Clube casa, Clube fora, string tipo)
    {
        TimeCasa = casa;
        TimeFora = fora;
        Data = DateTime.Now;
        Tipo = tipo;
        Finalizada = false;
    }

    // " gera resumo de agendamento usando formatacao de data e nomes de clubes para exibicao simplificada"
    public string ObterResumoAgendamento() => $"{Data:dd/MM/yyyy HH:mm} - {TimeCasa.Nome} vs {TimeFora.Nome}";

    // " define resultado final usando gols informados e marca partida como concluida para registro historico"
    public void DefinirResultado(int golsCasa, int golsFora)
    {
        GolsCasa = golsCasa;
        GolsFora = golsFora;
        Finalizada = true;
    }
    
    // " reagenda partida usando validacao de data futura para garantir integridade do calendario"
    public void Agendar(DateTime novaData)
    {
        if (novaData <= DateTime.Now)
        {
            throw new ArgumentException("A data de agendamento deve ser futura.");
        }

        Data = novaData;
    }
    
    // " simula resultado usando media de notas dos times e aleatoriedade controlada para geracao de placar realista"
    public void Simular()
    {
        if (Finalizada) return;

        double placarCasa = TimeCasa.CalcularMediaNotas();
        double placarFora = TimeFora.CalcularMediaNotas();

        Random rand = new Random();
        double fatorCasa = placarCasa / 10.0;
        double fatorFora = placarFora / 10.0;

        GolsCasa = (int)Math.Round(rand.NextDouble() * 5 * fatorCasa);
        GolsFora = (int)Math.Round(rand.NextDouble() * 5 * fatorFora);

        // Garante que não seja empate em todos os casos
        if (GolsCasa == GolsFora)
        {
            if (fatorCasa > fatorFora) GolsCasa++;
            else if (fatorFora > fatorCasa) GolsFora++;
            else
            {
                if (rand.NextDouble() > 0.5) GolsCasa++;
                else GolsFora++;
            }
        }

        Finalizada = true;
    }

    // " formata exibicao da partida usando status e dados dos times para representacao textual diferenciada"
    public override string ToString()
    {
        if (!Finalizada) return $"[Agendada] {TimeCasa.Nome} vs {TimeFora.Nome} - {Data:dd/MM}";

        string resultado = $"{Data:dd/MM HH:mm} - {TimeCasa.Nome} {GolsCasa} x {GolsFora} {TimeFora.Nome}";
        return $"{resultado.PadRight(40)} ({Tipo})";
    }
}