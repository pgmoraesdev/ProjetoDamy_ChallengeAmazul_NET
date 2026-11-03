namespace ProjetoDamyNuclearEdu;
internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("DAMY — Participações em jogos educativos sobre tecnologia nuclear");
        while (true)
        {
            Console.WriteLine("\n1 - Cadastrar participação");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");
            var opcao = Console.ReadLine();

            if (opcao is null or "0")
            {
                Console.WriteLine("Até a próxima!");
                return;
            }
            
            switch (opcao.Trim())
            {
                case "1":                    
                    Console.WriteLine($"Cadastrando nova participação");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Escolha uma das opções do menu.");
                    break;
            }
    }
}