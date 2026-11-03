using ProjetoDamyNuclearEdu.Models;
using ProjetoDamyNuclearEdu.Repository;

public sealed class ParticipacaoService
{
    private readonly ParticipacaoRepository _repository;

    public ParticipacaoService(ParticipacaoRepository repository)
    {
        _repository = repository;
    }

    public Participacao Cadastrar(string nomeUsuario, string nomeSessao)
    {        
        var participacoes = _repository.Listar();

        if (participacoes.Any(p => p.NomeUsuario == nomeUsuario && p.NomeSessao == nomeSessao))
            throw new InvalidOperationException("O jogador já tem uma participação nesta sessão.");

        var id = participacoes.Count == 0 ? 1 : checked(participacoes.Max(p => p.Id) + 1);
        var participacao = new Participacao(id, nomeUsuario, nomeSessao, 0, DateTimeOffset.Now, "aguardando");

        participacoes.Add(participacao);
        _repository.Salvar(participacoes);
        return participacao;
    }
}