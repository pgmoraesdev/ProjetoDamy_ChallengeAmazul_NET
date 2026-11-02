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
        public DateTime DataHoraEntrada { get; private set; }
        public string StatusParticipacao { get; private set; }
        protected Participacao() { }

        public Participacao(string nomeUsuario, string nomeSessao, int pontuacaoObtida, DateTime dataHoraEntrada, string statusParticipacao)
        {
            NomeUsuario = nomeUsuario;
            NomeSessao = nomeSessao;
            PontuacaoObtida = pontuacaoObtida;
            DataHoraEntrada = dataHoraEntrada;
            StatusParticipacao = statusParticipacao;
        }
    }
}