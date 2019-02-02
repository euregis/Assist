using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Assistente.Entidades;

namespace Assistente.Negocio
{
    public enum StatusValidacao
    {
        [Description("Aguardando")]
        Aguardando,
        [Description("Sucesso")]
        Sucesso,
        [Description("Erro")]
        Erro
    }
    public enum ModoExibicaoAssistente
    {
        [Description("SysTray")]
        SysTray,
        [Description("Compacto")]
        Compacto,
        [Description("Systray e Compacto")]
        Systray_Compacto,
    }
    public enum TipoValidacao
    {
        [Description("Todos")]
        Todos = 0,
        [Description("Nenhuma")]
        Nenhuma = 1,
        [Description("Sim ou Não")]
        SimNao,
        [Description("Numérico")]
        Numerico,
        [Description("Alfanumérico")]
        Alfanumérico,
        [Description("Preenchido")]
        Preenchido,
        [Description("Caminho Existe")]
        CaminhoExiste,
        [Description("Nome do Cliente é Único")]
        NomeClienteDuplicado,
        [Description("Modo Exibição Assistente")]
        ModoExibicaoAssistente,
        [Description("Unico Horario em Andamento")]
        UnicoHorarioAndamento,
        [Description("Order dos Horários")]
        OrdemHorarios,
        [Description("Arquivo ou Caminho Existe")]
        ArquivoExiste,
        [Description("Arquivo Existe")]
        ArquivoCaminhoExiste,
        [Description("Referencias PlugIn")]
        ReferenciasPlugIn,
    }
    public class Validacao
    {
        public int Ordem {get;set;}
        public string Descricao {get;set;}
        public TipoValidacao[] Tipos { get; set; }
        public object[] Valores { get; set; }
        public StatusValidacao Status { get; set; }
        public string MsgRetorno { get; set; }
        public object Campo { get; set; }
        public object Label { get; set; }
        public bool Valido{ get; set; }
    }
}
