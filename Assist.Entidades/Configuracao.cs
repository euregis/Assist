using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Assistente.Entidades
{
    public enum enuConfiguracao
    {
        [Description("Última versão atualizada")]
        UltimaVersao = 1,
        /*[Description("Exibir opção para controle de horas")]
        ExibirControleHoras=2,*/
        [Description("Posição da Tela Assistente Compacto")]
        PosTelaAssistenteCompacto=3,
        [Description("Campo Comandos Visivel")]
        CampoComandosVisivel=4,
        /*[Description("Incluir observações ao iniciar horário")]
        ObsIniciarHorario=5,*/
        /*[Description("Modo Exibição Assistente")]
        ModoExibicaoAssistente=6,*/
        [Description("Exibir Coluna Anotações")]
        ExibirColunaAnotacoes=7,
        /*[Description("Exibir Campo Horários")]
        ExibirCamposHorarios=8,*/
        [Description("Centralizador de Dados")]
        CentralizadorDados = 9,

    }
    public class Configuracao:Base.BaseCodDescr
    {
        //public virtual Validacao Validacao { get; set; }
        public virtual short Validacao { get; set; }
        public virtual string Valor { get; set; }
    }
}
