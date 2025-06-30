using System;
using System.Collections.Generic;
using System.Linq;





// Classe que gera dados de exemplo para testes
public static class BancoDeDadosFutebol
{
    public static List<Clube> GerarDadosTeste()
    {
        var clubes = new List<Clube>
        {
            new Clube("Flamengo", 10, 1),
            new Clube("Palmeiras", 12, 2),
            new Clube("Corinthians", 8, 3),
            new Clube("São Paulo", 6, 4),
            new Clube("Vasco", 4, 5),
            new Clube("Grêmio", 7, 6),
            new Clube("Internacional", 5, 7),
            new Clube("Atlético Mineiro", 9, 8),
            new Clube("Cruzeiro", 6, 9)
        };

        // Obter referências aos clubes
        var flamengo = clubes[0];
        var palmeiras = clubes[1];
        var corinthians = clubes[2];
        var saoPaulo = clubes[3];
        var vasco = clubes[4];
        var gremio = clubes[5];
        var internacional = clubes[6];
        var atleticoMG = clubes[7];
        var cruzeiro = clubes[8];

        // Adicionar jogadores e técnico ao Flamengo
        flamengo.AdicionarJogador(new Jogador("Gabigol", 9.0, true));
        flamengo.AdicionarJogador(new Jogador("Pedro", 8.5, true));
        flamengo.AdicionarJogador(new Jogador("Arrascaeta", 9.0, true));
        flamengo.AdicionarJogador(new Jogador("Gerson", 8.3, true));
        flamengo.AdicionarJogador(new Jogador("Thiago Maia", 7.8, false));
        flamengo.AdicionarJogador(new Jogador("Victor Hugo", 7.5, true));
        flamengo.AdicionarJogador(new Jogador("Ayrton Lucas", 8.0, true));
        flamengo.AdicionarJogador(new Jogador("Filipe Luís", 7.9, true));
        flamengo.AdicionarJogador(new Jogador("David Luiz", 8.0, true));
        flamengo.AdicionarJogador(new Jogador("Léo Pereira", 7.8, true));
        flamengo.AdicionarJogador(new Jogador("Wesley", 7.5, true));
        flamengo.AdicionarJogador(new Jogador("Santos", 7.9, true));
        flamengo.AdicionarTecnico(new Tecnico("Tite", 9.0));

        // Adicionar jogadores e técnico ao Palmeiras
        palmeiras.AdicionarJogador(new Jogador("Rony", 8.3, true));
        palmeiras.AdicionarJogador(new Jogador("Endrick", 8.5, true));
        palmeiras.AdicionarJogador(new Jogador("Raphael Veiga", 8.8, true));
        palmeiras.AdicionarJogador(new Jogador("Zé Rafael", 8.0, true));
        palmeiras.AdicionarJogador(new Jogador("Richard Ríos", 7.7, true));
        palmeiras.AdicionarJogador(new Jogador("Mayke", 7.9, true));
        palmeiras.AdicionarJogador(new Jogador("Piquerez", 8.0, true));
        palmeiras.AdicionarJogador(new Jogador("Gustavo Gómez", 8.5, true));
        palmeiras.AdicionarJogador(new Jogador("Murilo", 8.0, true));
        palmeiras.AdicionarJogador(new Jogador("Marcos Rocha", 7.8, true));
        palmeiras.AdicionarJogador(new Jogador("Weverton", 9.0, true));
        palmeiras.AdicionarTecnico(new Tecnico("Abel Ferreira", 9.0));

        // Adicionar jogadores e técnico ao Corinthians
        corinthians.AdicionarJogador(new Jogador("Yuri Alberto", 8.2, true));
        corinthians.AdicionarJogador(new Jogador("Roger Guedes", 8.3, false));
        corinthians.AdicionarJogador(new Jogador("Renato Augusto", 8.4, true));
        corinthians.AdicionarJogador(new Jogador("Giuliano", 7.8, true));
        corinthians.AdicionarJogador(new Jogador("Fausto Vera", 7.9, true));
        corinthians.AdicionarJogador(new Jogador("Ruan Oliveira", 7.5, true));
        corinthians.AdicionarJogador(new Jogador("Fagner", 7.8, true));
        corinthians.AdicionarJogador(new Jogador("Gil", 7.7, true));
        corinthians.AdicionarJogador(new Jogador("Bruno Méndez", 8.0, true));
        corinthians.AdicionarJogador(new Jogador("Bidu", 7.3, true));
        corinthians.AdicionarJogador(new Jogador("Cássio", 8.8, true));
        corinthians.AdicionarTecnico(new Tecnico("Mano Menezes", 7.8));

        // Adicionar jogadores e técnico ao São Paulo
        saoPaulo.AdicionarJogador(new Jogador("Luciano", 8.0, true));
        saoPaulo.AdicionarJogador(new Jogador("Calleri", 8.5, true));
        saoPaulo.AdicionarJogador(new Jogador("James Rodríguez", 8.7, true));
        saoPaulo.AdicionarJogador(new Jogador("Lucas Moura", 8.3, true));
        saoPaulo.AdicionarJogador(new Jogador("Pablo Maia", 8.0, true));
        saoPaulo.AdicionarJogador(new Jogador("Alisson", 7.8, true));
        saoPaulo.AdicionarJogador(new Jogador("Rafinha", 8.0, true));
        saoPaulo.AdicionarJogador(new Jogador("Arboleda", 8.2, true));
        saoPaulo.AdicionarJogador(new Jogador("Beraldo", 7.9, true));
        saoPaulo.AdicionarJogador(new Jogador("Welington", 7.7, true));
        saoPaulo.AdicionarJogador(new Jogador("Jandrei", 8.1, true));
        saoPaulo.AdicionarTecnico(new Tecnico("Dorival Júnior", 8.2));

        // Adicionar jogadores e técnico ao Vasco
        vasco.AdicionarJogador(new Jogador("Vegetti", 7.8, true));
        vasco.AdicionarJogador(new Jogador("Payet", 8.3, true));
        vasco.AdicionarJogador(new Jogador("Praxedes", 7.5, true));
        vasco.AdicionarJogador(new Jogador("Jair", 7.0, false));
        vasco.AdicionarJogador(new Jogador("Paulão", 7.2, true));
        vasco.AdicionarJogador(new Jogador("Mateus Carvalho", 7.3, true));
        vasco.AdicionarJogador(new Jogador("Pumita", 7.1, true));
        vasco.AdicionarJogador(new Jogador("Léo Jardim", 7.9, true));
        vasco.AdicionarJogador(new Jogador("Medel", 7.8, true));
        vasco.AdicionarJogador(new Jogador("Léo", 7.4, true));
        vasco.AdicionarJogador(new Jogador("Robson", 7.3, true));
        vasco.AdicionarTecnico(new Tecnico("Ramón Díaz", 7.8));

        // Adicionar jogadores e técnico ao Grêmio
        gremio.AdicionarJogador(new Jogador("Suárez", 9.3, true));
        gremio.AdicionarJogador(new Jogador("Cristaldo", 8.0, true));
        gremio.AdicionarJogador(new Jogador("Villasanti", 7.9, true));
        gremio.AdicionarJogador(new Jogador("Pepê", 8.1, true));
        gremio.AdicionarJogador(new Jogador("Nathan", 7.6, true));
        gremio.AdicionarJogador(new Jogador("Kannemann", 8.0, true));
        gremio.AdicionarJogador(new Jogador("Geromel", 7.9, true));
        gremio.AdicionarJogador(new Jogador("Reinaldo", 7.5, false));
        gremio.AdicionarJogador(new Jogador("Fábio", 7.7, true));
        gremio.AdicionarJogador(new Jogador("Grando", 7.8, true));
        gremio.AdicionarTecnico(new Tecnico("Renato Gaúcho", 8.3));

        // Adicionar jogadores e técnico ao Internacional
        internacional.AdicionarJogador(new Jogador("Enner Valencia", 8.6, true));
        internacional.AdicionarJogador(new Jogador("Wanderson", 8.1, true));
        internacional.AdicionarJogador(new Jogador("Alan Patrick", 8.3, true));
        internacional.AdicionarJogador(new Jogador("Aránguiz", 8.2, true));
        internacional.AdicionarJogador(new Jogador("Maurício", 7.9, true));
        internacional.AdicionarJogador(new Jogador("Vitão", 8.0, true));
        internacional.AdicionarJogador(new Jogador("Mercado", 7.9, true));
        internacional.AdicionarJogador(new Jogador("Renê", 7.7, true));
        internacional.AdicionarJogador(new Jogador("Rochet", 8.1, true));
        internacional.AdicionarTecnico(new Tecnico("Eduardo Coudet", 8.1));

        // Adicionar jogadores e técnico ao Atlético Mineiro
        atleticoMG.AdicionarJogador(new Jogador("Hulk", 9.2, true));
        atleticoMG.AdicionarJogador(new Jogador("Paulinho", 8.3, true));
        atleticoMG.AdicionarJogador(new Jogador("Zaracho", 8.1, true));
        atleticoMG.AdicionarJogador(new Jogador("Edenilson", 7.9, true));
        atleticoMG.AdicionarJogador(new Jogador("Allan", 7.8, true));
        atleticoMG.AdicionarJogador(new Jogador("Jemerson", 7.9, true));
        atleticoMG.AdicionarJogador(new Jogador("Réver", 7.8, true));
        atleticoMG.AdicionarJogador(new Jogador("Rubens", 7.7, true));
        atleticoMG.AdicionarJogador(new Jogador("Dodô", 7.7, true));
        atleticoMG.AdicionarJogador(new Jogador("Everson", 8.4, true));
        atleticoMG.AdicionarTecnico(new Tecnico("Gabriel Milito", 8.0));

        // Adicionar jogadores e técnico ao Cruzeiro
        cruzeiro.AdicionarJogador(new Jogador("Bruno Rodrigues", 7.8, true));
        cruzeiro.AdicionarJogador(new Jogador("Gilberto", 7.5, true));
        cruzeiro.AdicionarJogador(new Jogador("Matheus Pereira", 8.1, true));
        cruzeiro.AdicionarJogador(new Jogador("Nikão", 7.6, true));
        cruzeiro.AdicionarJogador(new Jogador("Lucas Romero", 7.7, true));
        cruzeiro.AdicionarJogador(new Jogador("Lucas Silva", 7.4, true));
        cruzeiro.AdicionarJogador(new Jogador("Marquinhos Cipriano", 7.2, false));
        cruzeiro.AdicionarJogador(new Jogador("Luciano Castán", 7.6, true));
        cruzeiro.AdicionarJogador(new Jogador("Neris", 7.5, true));
        cruzeiro.AdicionarJogador(new Jogador("William", 7.3, true));
        cruzeiro.AdicionarJogador(new Jogador("Rafael Cabral", 8.0, true));
        cruzeiro.AdicionarTecnico(new Tecnico("Fernando Seabra", 7.5));

        return clubes;
    }
    
    public static List<Partida> GerarPartidasTeste(List<Clube> clubes)
    {
        var partidas = new List<Partida>();
        
        if (clubes.Count < 9) return partidas;

        // Obter referências aos clubes
        var flamengo = clubes[0];
        var palmeiras = clubes[1];
        var corinthians = clubes[2];
        var saoPaulo = clubes[3];
        var vasco = clubes[4];
        var gremio = clubes[5];
        var internacional = clubes[6];
        var atleticoMG = clubes[7];
        var cruzeiro = clubes[8];

        // Partidas finalizadas
        var partida1 = new Partida(flamengo, palmeiras, "Simulada");
        partida1.Simular();
        partidas.Add(partida1);

        var partida2 = new Partida(corinthians, saoPaulo, "Manual");
        partida2.DefinirResultado(2, 1);
        partidas.Add(partida2);

        var partida3 = new Partida(gremio, internacional, "Simulada");
        partida3.Simular();
        partidas.Add(partida3);

        var partida4 = new Partida(atleticoMG, cruzeiro, "Simulada");
        partida4.Simular();
        partidas.Add(partida4);

        var partida5 = new Partida(saoPaulo, vasco, "Manual");
        partida5.DefinirResultado(3, 0);
        partidas.Add(partida5);

        var partida6 = new Partida(cruzeiro, flamengo, "Simulada");
        partida6.Simular();
        partidas.Add(partida6);

        var partida7 = new Partida(palmeiras, internacional, "Simulada");
        partida7.Simular();
        partidas.Add(partida7);

        var partida8 = new Partida(cruzeiro, corinthians, "Manual");
        partida8.DefinirResultado(1, 1);
        partidas.Add(partida8);

        // Partidas pendentes
        partidas.Add(new Partida(palmeiras, corinthians, "Simulada"));
        partidas.Add(new Partida(vasco, gremio, "Simulada"));
        partidas.Add(new Partida(internacional, atleticoMG, "Simulada"));
        partidas.Add(new Partida(flamengo, saoPaulo, "Simulada"));
        partidas.Add(new Partida(corinthians, cruzeiro, "Simulada"));
        partidas.Add(new Partida(cruzeiro, gremio, "Simulada"));
        partidas.Add(new Partida(saoPaulo, palmeiras, "Simulada"));
        partidas.Add(new Partida(vasco, cruzeiro, "Simulada"));

        return partidas;
    }
}



// Classe de entrada do programa
class Programa
{

    static async Task Main(string[] args)
    {
    PrincipalFunctions principal;
    Persistencia.MostrarLocalDados();
        
        // Tentar carregar dados salvos
        try
        {
            principal = Persistencia.CarregarDados();
            Console.WriteLine("Dados carregados com sucesso!");
        }
        catch
        {
            // Se falhar, carrega dados de teste
            principal = new PrincipalFunctions(true);
            Console.WriteLine("Usando dados de teste");
        }
        
        Menu menuPrincipal = new Menu(principal);
        menuPrincipal.Executar();
    }

}