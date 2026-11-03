using ProjetoDamyNuclearEdu.Models;
using System.Text;
using System.Text.Json;

namespace ProjetoDamyNuclearEdu.Repository;

public sealed class ParticipacaoRepository
{
    private readonly string _caminho;
    private readonly JsonSerializerOptions _opcoes = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public ParticipacaoRepository(string caminho)
    {
        _caminho = Path.GetFullPath(caminho);
    }

    public List<Participacao> Listar()
    {
        if (!File.Exists(_caminho)) return [];

        var json = File.ReadAllText(_caminho, Encoding.UTF8);
        var participacoes = JsonSerializer.Deserialize<List<Participacao>>(json, _opcoes) ??
            throw new InvalidDataException("O arquivo deve conter uma lista de participações.");

        if (participacoes.Any(p => p is null))
            throw new InvalidDataException("O arquivo contém um registro vazio.");

        if (participacoes.GroupBy(p => p.Id).Any(g => g.Count() > 1) || participacoes.GroupBy(p => (p.NomeUsuario, p.NomeSessao)).Any(g => g.Count() > 1))
            throw new InvalidDataException("Os registros do arquivo violam as regras de participação.");

        return participacoes;
    }

    public void Salvar(List<Participacao> participacoes)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_caminho)!);
        var temporario = _caminho + "." + Guid.NewGuid().ToString("N") + ".tmp";

        try
        {
            var json = JsonSerializer.Serialize(participacoes, _opcoes);
            File.WriteAllText(temporario, json, Encoding.UTF8);
            File.Move(temporario, _caminho, overwrite: true);
        }
        finally
        {
            if (File.Exists(temporario))
                File.Delete(temporario);
        }
    }
}
