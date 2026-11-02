using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public Participacao(string nomeUsuario, string nomeSessao, int pontuacaoObtida, DateTimeOffset dataHoraEntrada, string statusParticipacao)
        {
            if (Id <= 0)
                throw new ArgumentException("Os identificadores devem ser números inteiros positivos.");

            if (NomeUsuario == "" || NomeUsuario == null)
                throw new ArgumentException("O nome do usuário deve ser informado.");

            if (NomeSessao == "" || NomeSessao == null)
                throw new ArgumentException("O nome do sessão deve ser informad.");

            if (Id <= 0)
                throw new ArgumentException("Os identificadores devem ser números inteiros positivos.");

            if (pontuacaoObtida < 0)
                throw new ArgumentException("A pontuação não pode ser negativa.");

            if (dataHoraEntrada == default)
                throw new ArgumentException("A data de entrada é obrigatória.");

            if (statusParticipacao is not ("aguardando" or "jogando" or "concluida" or "abandonada"))
                throw new ArgumentException("O status da participação é inválido.");

            if (statusParticipacao == "aguardando" && pontuacaoObtida != 0)
                throw new ArgumentException("Uma participação aguardando deve ter zero pontos.");

            NomeUsuario = nomeUsuario;
            NomeSessao = nomeSessao;
            PontuacaoObtida = pontuacaoObtida;
            DataHoraEntrada = dataHoraEntrada;
            StatusParticipacao = statusParticipacao;
        }
    }
}