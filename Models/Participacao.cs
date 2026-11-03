using System.Text.Json.Serialization;

namespace ProjetoDamyNuclearEdu.Models
{
    public class Participacao
    {
        public int Id { get; private set; }
        public string NomeUsuario { get; private set; }
        public string NomeSessao { get; private set; }
        public int PontuacaoObtida { get; private set; }
        public DateTimeOffset DataHoraEntrada { get; private set; }
        public string StatusParticipacao { get; private set; }
        protected Participacao() { }

        [JsonConstructor]
        public Participacao(int id, string nomeUsuario, string nomeSessao, int pontuacaoObtida, DateTimeOffset dataHoraEntrada, string statusParticipacao)
        {
            if (id <= 0)
                throw new ArgumentException("Os identificadores devem ser números inteiros positivos.");

            if (string.IsNullOrWhiteSpace(nomeUsuario))
                throw new ArgumentException("O nome do usuário deve ser informado.");

            if (!NomeValido(nomeUsuario))
                throw new ArgumentException("O nome do usuário deve conter pelo menos uma letra.");

            if (string.IsNullOrWhiteSpace(nomeSessao))
                throw new ArgumentException("O nome da sessão deve ser informado.");

            if (pontuacaoObtida < 0)
                throw new ArgumentException("A pontuação não pode ser negativa.");

            if (dataHoraEntrada == default)
                throw new ArgumentException("A data de entrada é obrigatória.");

            if (statusParticipacao is not ("aguardando" or "jogando" or "concluida" or "abandonada"))
                throw new ArgumentException("O status da participação é inválido.");

            if (statusParticipacao == "aguardando" && pontuacaoObtida != 0)
                throw new ArgumentException("Uma participação aguardando deve ter zero pontos.");

            Id = id;
            NomeUsuario = nomeUsuario;
            NomeSessao = nomeSessao;
            PontuacaoObtida = pontuacaoObtida;
            DataHoraEntrada = dataHoraEntrada;
            StatusParticipacao = statusParticipacao;
        }

        public static bool NomeValido(string? nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return false;

            foreach (char caractere in nome)
            {
                if (char.IsLetter(caractere))
                    return true;
            }

            return false;
        }
    }
}