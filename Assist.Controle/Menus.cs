using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assistente.Negocio;
using Assistente.Entidades;
using System.Collections;
using Assistente.Negocio.Util;
using System.Windows.Forms;
//using Assistente.PlugIn;
using System.ComponentModel;

namespace Assistente.Controle
{
    public enum enuMenuGerencia
    {
        [Description("Horários")]
        Horarios,        
        [Description("Projetos")]
        Projetos,
        [Description("Tarefas")]
        Tarefas,
    }
    public enum enuMenuUtil
    {
        [Description("Configuração")]
        Configuracao
    }
    public enum enuMenuConfiguracao
    {
        //[Description("Entidades")]
        //Entidades,
        //[Description("Validacões")]
        //Validacoes,
        [Description("Opções...")]
        Opcoes,
        [Description("Plug-Ins")]
        PlugIn,
    }

    public static class Menus
    {
        
        //public static ContextMenu MenuPrincipal(ref EventHandler eventMenu)
        //{
        //    ContextMenu ContMenu = new ContextMenu();
        //    int lintIndex = 0;

        //    //ContMenu.MenuItems.Add(lintIndex++, carregaContextMenuAtalhos(ref eventAtalhos));
        //    MenuItem itemMenu;

        //    itemMenu = MenuGerenciamento(ref eventMenu);//new MenuItem(TrataEnum.ObterDescricao(enuMenuGeral.Gerenciamento));
        //    ContMenu.MenuItems.Add((int)enuMenuGeral.Gerenciamento, itemMenu);

        //    itemMenu = MenuUtilitarios(ref eventMenu);
        //    ContMenu.MenuItems.Add((int)enuMenuGeral.Utilitarios, itemMenu);
        //    lintIndex = (int)enuMenuGeral.Utilitarios + 1;
        //    if (Host.CarregarPlugIns())
        //    {
        //        foreach (PlugIn.IPlugIn plugIn in Host.PlugIns)
        //        {
        //            if (enuMenuGeral.Principal != plugIn.MenuPai)
        //                ContMenu.MenuItems[(int)plugIn.MenuPai].MenuItems.Add((MenuItem)plugIn.Menu());
        //            else
        //                ContMenu.MenuItems.Add(lintIndex++, (MenuItem)plugIn.Menu());
        //        }
        //    }

        //    //itemMenu = ContMenu.MenuItems[(int)enuMenuGeral.Utilitarios];
        //    //WinControls.OrdenarMenuItem(ref itemMenu);
        //    //itemMenu = ContMenu.MenuItems[(int)enuMenuGeral.Gerenciamento];
        //    //WinControls.OrdenarMenuItem(ref itemMenu);

        //    WinControls.OrdenarMenuContext(ref ContMenu);
            
        //    ContMenu.MenuItems.Add("-"); lintIndex++;
        //    ContMenu.MenuItems.Add(lintIndex, new MenuItem(TrataEnum.ObterDescricao(enuMenuGeral.Sair), new System.EventHandler(LerMenu)));
        //    ContMenu.MenuItems[lintIndex++].Tag = "Principal " + (int)enuMenuGeral.Sair;

        //    return ContMenu;
        //}

        //public static MenuItem MenuGerenciamento(ref EventHandler eventMenu)
        //{
        //    MenuItem itemMenu = new MenuItem(TrataEnum.ObterDescricao(enuMenuGeral.Gerenciamento));
        //    //Int32 lintIndex = 0;

        //    //itemMenu.MenuItems.Add((int)enuMenuGerencia.PlugIn, new MenuItem(TrataEnum.ObterDescricao(enuMenuGerencia.PlugIn), eventMenu));

        //    //itemMenu.MenuItems[(int)enuMenuGerencia.PlugIn].Tag = "Gerenciamento " + ((int)enuMenuGerencia.PlugIn).ToString();
        //    foreach (enuMenuGerencia item in Enum.GetValues(typeof(enuMenuGerencia)))
        //    {
        //        if (item == enuMenuGerencia.Tarefas)
        //            itemMenu.MenuItems.Add((byte)item, carregaContextMenuTarefa(ref eventMenu));
        //        else
        //            itemMenu.MenuItems.Add((byte)item,
        //                new MenuItem(TrataEnum.ObterDescricao(item), eventMenu));
        //        itemMenu.MenuItems[(byte)item].Tag = "Gerenciamento " + (byte)item;
        //    }
        //    return itemMenu;

        //}

        //public static MenuItem MenuUtilitarios(ref EventHandler eventMenu)
        //{
        //    MenuItem itemMenu = new MenuItem(TrataEnum.ObterDescricao(enuMenuGeral.Utilitarios));
        //    //Int32 lintIndex = 0;

        //    //itemMenu.MenuItems.Add((int)enuMenuUtil.Configuracao, MenuConfiguracao(ref eventMenu));
        //    //itemMenu.MenuItems[(int)enuMenuUtil.Configuracao].Tag = "Utilitario " + ((int)enuMenuUtil.Configuracao).ToString();

        //    foreach (enuMenuUtil item in Enum.GetValues(typeof(enuMenuUtil)))
        //    {
        //        switch (item)
        //        {
        //            case enuMenuUtil.Configuracao:
        //                itemMenu.MenuItems.Add((int)enuMenuUtil.Configuracao, MenuConfiguracao(ref eventMenu));
        //                break;
        //            default:
        //                itemMenu.MenuItems.Add((byte)item,
        //                    new MenuItem(TrataEnum.ObterDescricao(item), eventMenu)); 
        //                    break;
        //        }
                
        //        itemMenu.MenuItems[(byte)item].Tag = "Utilitario " + (byte)item;
        //    }

        //    return itemMenu;

        //}

        public static MenuItem MenuConfiguracao(ref EventHandler eventMenu)
        {
            MenuItem itemMenu = new MenuItem(TrataEnum.ObterDescricao(enuMenuUtil.Configuracao));

            foreach (enuMenuConfiguracao item in Enum.GetValues(typeof(enuMenuConfiguracao)))
            {
                itemMenu.MenuItems.Add((byte)item,
                    new MenuItem(TrataEnum.ObterDescricao(item), eventMenu));
                itemMenu.MenuItems[(byte)item].Tag = "Configuracao " + (byte)item;
            }


            return itemMenu;
        }
        //public static void LerMenu(Object sender, System.EventArgs e)
        //{
        //    Object[] controle = { "", "" };
        //    if (sender is Control)
        //    {
        //        controle[0] = ((Control)sender).Tag;
        //        controle[1] = ((Control)sender).Text;
        //    }
        //    else if (sender is MenuItem)
        //    {
        //        controle[0] = ((MenuItem)sender).Tag;
        //        controle[1] = ((MenuItem)sender).Text;
        //    }
        //    int valor = int.Parse(controle[0].ToString().Substring(controle[0].ToString().IndexOf(" ")));
        //    //menuItem.Tag.ToString().Substring(0,menuItem.Tag.ToString().IndexOf(" ")-1);
        //    switch (controle[0].ToString().Substring(0, controle[0].ToString().IndexOf(" ")))
        //    {
        //        case "Principal":
        //            switch (valor)
        //            {
        //                case (int)enuMenuGeral.Sair:
        //                    if (Application.OpenForms.Count > 1)
        //                    {
        //                        MessageBox.Show("Existem outras janelas abertas. "
        //                            + "Elas deverão ser fechadas antes de finalizar o Assistente.", 
        //                            "Assistente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        break;
        //                    }
        //                    if (MessageBox.Show("Deseja realmente sair do Assistente?", "Sair",
        //                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //                    {
        //                        Application.Exit();
        //                    } 
        //                    break;
        //            }
        //            break;
        //        default:
        //            break;
        //    }


        //}
        public static ContextMenu carregaContextMenuTarefa(int idTarefa, ref EventHandler eventPasta)
        {
            bool temMenuCliente = false;
            ContextMenu contextMenu = new ContextMenu();
            Int32 lintIndexPasta = 0;
            try
            {
                Tarefa tarefa = Conexao.TrataDAO.getAcesso<Tarefa>().Retorna_pId(idTarefa);

                foreach (Pasta pasta in Conexao.TrataDAO.getAcesso<Pasta>()
                    .Retorna(x => x.Tarefa == tarefa && x.Ambiente == Geral.AmbienteLocal).OrderBy(x => x.Descricao))
                {
                    if (CheckURLValid(pasta.Caminho) || pasta.Caminho.ToLower().StartsWith("starteam:") 
                        || new System.IO.DirectoryInfo(pasta.Caminho).Exists || new System.IO.FileInfo(pasta.Caminho).Exists )
                    {
                        contextMenu.MenuItems.Add(lintIndexPasta,
                        new MenuItem(pasta.Descricao, eventPasta));//, new System.EventHandler(Show_Click)));
                        contextMenu.MenuItems[lintIndexPasta].Tag = "PastaT " + pasta.Id.ToString();

                        lintIndexPasta++;
                    }
                }

                if (tarefa.Cliente != null)
                {
                    foreach (Pasta pasta in Conexao.TrataDAO.getAcesso<Pasta>()
                        .Retorna(x => x.Cliente == tarefa.Cliente && x.Ambiente == Geral.AmbienteLocal).OrderBy(x=>x.Descricao))
                    {

                        if (CheckURLValid(pasta.Caminho) || pasta.Caminho.ToLower().StartsWith("starteam:") 
                            || new System.IO.DirectoryInfo(pasta.Caminho).Exists || new System.IO.FileInfo(pasta.Caminho).Exists )
                        {
                            if (lintIndexPasta > 0 && !temMenuCliente) { contextMenu.MenuItems.Add("-"); lintIndexPasta++; }
                            contextMenu.MenuItems.Add(lintIndexPasta,
                            new MenuItem(pasta.Descricao, eventPasta));//, new System.EventHandler(Show_Click)));
                            contextMenu.MenuItems[lintIndexPasta].Tag = "PastaC " + pasta.Id.ToString();

                            lintIndexPasta++;
                            temMenuCliente = true;
                        }
                    }
                    if (!string.IsNullOrEmpty(tarefa.Cliente.CodigoRegis))
                    {
                        if (lintIndexPasta > 0) { contextMenu.MenuItems.Add("-"); lintIndexPasta++; }
                        contextMenu.MenuItems.Add(lintIndexPasta,
                            new MenuItem(tarefa.Cliente.CodigoRegis, eventPasta));//, new System.EventHandler(Show_Click)));
                        contextMenu.MenuItems[lintIndexPasta].Tag = "PastaD " + tarefa.Cliente.CodigoRegis;
                    }
                }

                return contextMenu;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static MenuItem carregaContextMenuTarefa(ref EventHandler eventMenu)
        {
            MenuItem itemMenu = new MenuItem(TrataEnum.ObterDescricao(enuMenuGerencia.Tarefas));
            Int32 lintIndex = 0;

            IList<Tarefa> tarefas = Conexao.TrataDAO.getTarefa().RetornaMenu();

            foreach (Tarefa tarefa in tarefas)
            {
                itemMenu.MenuItems.Add(lintIndex, new MenuItem(
                    (tarefa.Cliente!=null?tarefa.Cliente.Nome + " -> ":"") + tarefa.Descricao, eventMenu));

                itemMenu.MenuItems[lintIndex].Tag = TrataEnum.ObterDescricao(enuMenuGerencia.Tarefas) + " " + tarefa.Id.ToString();
                
                lintIndex++;
            }

            if (lintIndex > 0) { itemMenu.MenuItems.Add("-"); lintIndex++; }

            itemMenu.MenuItems.Add(lintIndex,
                new MenuItem("Novo", eventMenu));
            itemMenu.MenuItems[lintIndex].Tag = TrataEnum.ObterDescricao(enuMenuGerencia.Tarefas) + " 0";
            lintIndex++;

            itemMenu.MenuItems.Add(lintIndex,
                new MenuItem("Lista", eventMenu));
            itemMenu.MenuItems[lintIndex].Tag = TrataEnum.ObterDescricao(enuMenuGerencia.Tarefas) + " -1";
            lintIndex++;

            itemMenu.MenuItems.Add(lintIndex,
                new MenuItem("Observação", eventMenu));
            itemMenu.MenuItems[lintIndex].Tag = TrataEnum.ObterDescricao(enuMenuGerencia.Tarefas) + " -2";
            //itemMenu.MenuItems[lintIndex].Checked = 
            //    Conversor.ParaBool(Conexao.TrataDAO.getConfiguracao().Retorna_pCodigo((int)enuConfiguracao.ObsIniciarHorario).Valor);
            lintIndex++;
            return itemMenu;

        }
        public static bool CheckURLValid(string source)
        {
            Uri uriResult;
            return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        }
        
    }
}
