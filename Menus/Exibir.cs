static class Exibir
{
    // "mostra mensagens no console usando verificacao de conteudo e captura de tecla para feedback do usuario"
    public static void ExibirMensagem(string mensagem)
    {
        if (!string.IsNullOrEmpty(mensagem))
        {
            Console.WriteLine($"\n{mensagem}");
        }
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }
}