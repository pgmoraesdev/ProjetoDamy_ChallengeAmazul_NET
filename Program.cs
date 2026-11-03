using ProjetoDamyNuclearEdu.Models;
using ProjetoDamyNuclearEdu.Repository;

namespace ProjetoDamyNuclearEdu;

internal static class Program
{
    private static void Main()
    {
        var caminho = Path.Combine(Environment.CurrentDirectory, "dados", "participacoes.json");
        var service = new ParticipacaoService(new ParticipacaoRepository(caminho));

        Console.WriteLine("DAMY — Participações em jogos educativos sobre tecnologia nuclear");
        while (true)
        {
            Console.WriteLine("\n1 - Cadastrar participação");
            Console.WriteLine("2 - Listar todas as participações");
            Console.WriteLine("3 - Buscar por ID do jogador");
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
                    string nomeUsuario;

                    do
                    {
                        Console.Write("Nome do usuário: ");
                        nomeUsuario = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(nomeUsuario))
                            Console.WriteLine("Informe o nome do usuário.");
                    }
                    while (string.IsNullOrWhiteSpace(nomeUsuario));

                    string nomeSessao;

                    do
                    {
                        Console.Write("Nome da sessão educativa: ");
                        nomeSessao = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(nomeSessao))
                            Console.WriteLine("Informe o nome da sessão.");
                    }
                    while (string.IsNullOrWhiteSpace(nomeSessao));

                    var nova = service.Cadastrar(nomeUsuario.Trim(), nomeSessao.Trim());

                    Console.WriteLine($"Participação {nova.Id} cadastrada com zero pontos.");
                    break;
                case "2":
                    Exibir(service.Listar());
                    break;
                case "3":
                    string nomeBusca;

                    do
                    {
                        Console.Write("Nome do usuário: ");
                        nomeBusca = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(nomeBusca))
                        {
                            Console.WriteLine("Informe o nome do usuário.");
                        }
                    }
                    while (string.IsNullOrWhiteSpace(nomeBusca));

                    var participacoes = service.BuscarPorUsuario(nomeBusca.Trim());
                    Exibir(participacoes);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Escolha uma das opções do menu.");
                    break;
            }

        }

    }

    private static void Exibir(List<Participacao> participacoes)
    {
        if (participacoes.Count == 0)
        {
            Console.WriteLine("Nenhuma participação encontrada.");
            return;
        }

        Console.WriteLine("\nID | Usuário | Sessão | Pontos | Status | Entrada");

        foreach (var participacao in participacoes)
        {
            Console.WriteLine(
                $"{participacao.Id} | " +
                $"{participacao.NomeUsuario} | " +
                $"{participacao.NomeSessao} | " +
                $"{participacao.PontuacaoObtida} | " +
                $"{participacao.StatusParticipacao} | " +
                $"{participacao.DataHoraEntrada:dd/MM/yyyy HH:mm zzz}");
        }
    }
}