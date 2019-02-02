using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assistente.Entidades;
using Assistente.Entidades.Configuracoes;

namespace Assistente.Negocio
{
    public static class Geral
    {
        public const string PastaPlugins = @"Assistente\PlugIns";
        public static Ambiente AmbienteLocal;
        public static Config Config;
        public static string CentralizadorDados;

        public static Tarefa Clonar(Tarefa t)
        {
            Tarefa tNova= new Tarefa();
            tNova.Cliente = t.Cliente;
            tNova.Descricao = t.Descricao;
            tNova.Status = t.Status;
            tNova.Prioridade = t.Prioridade;
            tNova.Categoria = t.Categoria;
            tNova.PrazoTermino = t.PrazoTermino;
            tNova.DataTermino = t.DataTermino;
            tNova.Solicitante = t.Solicitante;
            tNova.Responsavel = t.Responsavel;

            return tNova;
        }

        public static string ObtemMudancas(Tarefa tOld, Tarefa tNew)
        {
            string mudancas = "";

            if (tOld.Cliente != null && tNew.Cliente != null && tOld.Cliente.Nome != tNew.Cliente.Nome)
                mudancas += "Projeto alterado de \"" + tOld.Cliente.Nome + "\" para \"" + tNew.Cliente.Nome + "\"\r\n\r\n";

            if (tOld.Descricao != tNew.Descricao)
                mudancas += "Descrição alterado de \"" + (string.IsNullOrEmpty(tOld.Descricao) ? "vazio" : tOld.Descricao)
                    + "\" para \"" + (string.IsNullOrEmpty(tNew.Descricao) ? "vazio" : tNew.Descricao) + "\"\r\n\r\n";

            if (tOld.Status != 0 && tNew.Status != 0 && tOld.Status != tNew.Status)
                mudancas += "Status alterado de \"" + Util.TrataEnum.ObterDescricao((enuStatusTarefa)tOld.Status)
                    + "\" para \"" + Util.TrataEnum.ObterDescricao((enuStatusTarefa)tNew.Status) + "\"\r\n\r\n";

            if (tOld.Prioridade != 0 && tNew.Prioridade != 0 && tOld.Prioridade != tNew.Prioridade)
                mudancas += "Prioridade alterada de \"" + Util.TrataEnum.ObterDescricao((enuPrioridadeTarefa)tOld.Prioridade)
                    + "\" para \"" + Util.TrataEnum.ObterDescricao((enuPrioridadeTarefa)tNew.Prioridade) + "\"\r\n\r\n";

            if (tOld.Categoria != 0 && tNew.Categoria != 0 && tOld.Categoria != tNew.Categoria)
                mudancas += "Prioridade alterada de \"" + Util.TrataEnum.ObterDescricao((enuCategoriaTarefa)tOld.Categoria)
                    + "\" para \"" + Util.TrataEnum.ObterDescricao((enuCategoriaTarefa)tNew.Categoria) + "\"\r\n\r\n";

            if (tOld.PrazoTermino != tNew.PrazoTermino)
                mudancas += "Prazo alterada de \"" + (tOld.PrazoTermino == null ? "vazio" : ((DateTime)tOld.PrazoTermino).ToShortDateString())
                    + "\" para \"" + (tNew.PrazoTermino == null ? "vazio" : ((DateTime)tNew.PrazoTermino).ToShortDateString()) + "\"\r\n\r\n";

            if (tOld.DataTermino != tNew.DataTermino)
                mudancas += "Término alterada de \"" + (tOld.DataTermino == null ? "vazio" : ((DateTime)tOld.DataTermino).ToShortDateString())
                    + "\" para \"" + (tNew.DataTermino == null ? "vazio" : ((DateTime)tNew.DataTermino).ToShortDateString()) + "\"\r\n\r\n";

            if (tOld.Solicitante != tNew.Solicitante)
                mudancas += "Solicitante alterado de \"" + (string.IsNullOrEmpty(tOld.Solicitante) ? "vazio" : tOld.Solicitante)
                    + "\" para \"" + (string.IsNullOrEmpty(tNew.Solicitante) ? "vazio" : tNew.Solicitante) + "\"\r\n\r\n";

            if (tOld.Responsavel != tNew.Responsavel)
                mudancas += "Responsável alterado de \"" + (string.IsNullOrEmpty(tOld.Responsavel) ? "vazio" : tOld.Responsavel)
                    + "\" para \"" + (string.IsNullOrEmpty(tNew.Responsavel) ? "vazio" : tNew.Responsavel) + "\"\r\n\r\n";


            return mudancas.Trim()==""?null:mudancas.Trim();
        }
    }
}
