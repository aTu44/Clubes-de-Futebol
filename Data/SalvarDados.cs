using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

static class Persistencia
{
    private static string BasePath = Path.Combine(Directory.GetCurrentDirectory(), "Dados");
    private static string ClubeFilePath = Path.Combine(BasePath, "clubes.xml");
    private static string PartidaFilePath = Path.Combine(BasePath, "partidas.xml");

    // "Essa funcao inicializa o diretorio de dados usando verificacao de existencia para criar pasta se necessario"
    static Persistencia()
    {
        if (!Directory.Exists(BasePath))
        {
            Directory.CreateDirectory(BasePath);
        }
    }

    // "Essa funcao salva todos os dados do sistema usando as listas de clubes e partidas do objeto principal para persistencia em XML"
    public static void SalvarDados(PrincipalFunctions principal)
    {
        SalvarClubes(principal.ObterTodosClubes().ToList());
        SalvarPartidas(principal.ObterTodasPartidas().ToList());
    }

    // "Essa funcao carrega dados persistentes usando deserializacao XML e dados de teste caso necessario para inicializar o sistema"
    public static PrincipalFunctions CarregarDados()
    {
        var principal = new PrincipalFunctions(false);
        
        var clubesCarregados = CarregarClubes();
        if (clubesCarregados != null && clubesCarregados.Any())
        {
            foreach (var clube in clubesCarregados)
            {
                principal.AdicionarClube(clube);
            }
        }

        var partidasCarregadas = CarregarPartidas(principal);
        if (partidasCarregadas != null && partidasCarregadas.Any())
        {
            foreach (var partida in partidasCarregadas)
            {
                principal.AdicionarPartida(partida);
            }
        }

        if (principal.ObterQuantidadeClubes() == 0)
        {
            var dadosTeste = BancoDeDadosFutebol.GerarDadosTeste();
            var partidasTeste = BancoDeDadosFutebol.GerarPartidasTeste(dadosTeste);
            
            foreach (var clube in dadosTeste)
            {
                principal.AdicionarClube(clube);
            }
            foreach (var partida in partidasTeste)
            {
                principal.AdicionarPartida(partida);
            }
        }

        return principal;
    }

    // "Essa funcao salva lista de clubes usando serializacao XML e tratamento de excecoes para persistencia em arquivo"
    private static void SalvarClubes(List<Clube> clubes)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(List<Clube>));
            using (var writer = new StreamWriter(ClubeFilePath))
            {
                serializer.Serialize(writer, clubes);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar clubes: {ex.Message}");
        }
    }

    // "Essa funcao carrega lista de clubes usando desserializacao XML e verificacao de arquivo para retornar dados persistentes"
    private static List<Clube> CarregarClubes()
    {
        if (!File.Exists(ClubeFilePath)) 
            return new List<Clube>();

        try
        {
            var serializer = new XmlSerializer(typeof(List<Clube>));
            using (var reader = new StreamReader(ClubeFilePath))
            {
                return (List<Clube>)serializer.Deserialize(reader);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar clubes: {ex.Message}");
            return new List<Clube>();
        }
    }

    // "Essa funcao salva lista de partidas usando serializacao XML e bloco try-catch para armazenamento em arquivo"
    private static void SalvarPartidas(List<Partida> partidas)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(List<Partida>));
            using (var writer = new StreamWriter(PartidaFilePath))
            {
                serializer.Serialize(writer, partidas);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar partidas: {ex.Message}");
        }
    }

    // "Essa funcao carrega partidas usando desserializacao XML e relacao com clubes existentes para reconstruir objetos integros"
    private static List<Partida> CarregarPartidas(PrincipalFunctions principal)
    {
        if (!File.Exists(PartidaFilePath)) 
            return new List<Partida>();

        try
        {
            var serializer = new XmlSerializer(typeof(List<Partida>));
            using (var reader = new StreamReader(PartidaFilePath))
            {
                var partidas = (List<Partida>)serializer.Deserialize(reader);
                
                foreach (var partida in partidas)
                {
                    if (partida.TimeCasa != null)
                    {
                        partida.TimeCasa = principal.BuscarClube(partida.TimeCasa.Nome);
                    }
                    
                    if (partida.TimeFora != null)
                    {
                        partida.TimeFora = principal.BuscarClube(partida.TimeFora.Nome);
                    }
                }
                
                return partidas;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar partidas: {ex.Message}");
            return new List<Partida>();
        }
    }
    
    // "Essa funcao exibe local dos arquivos usando caminho base completo para informar usuario sobre localizacao dos dados"
    public static void MostrarLocalDados()
    {
        Console.WriteLine($"Arquivos salvos em: {Path.GetFullPath(BasePath)}");
    }
}