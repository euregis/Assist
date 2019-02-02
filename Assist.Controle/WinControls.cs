using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Assistente.Entidades.Base;
using System.Windows.Forms;
using Assistente.Negocio.Util;
using Assistente.Excecoes;

namespace Assistente.Controle
{
    public static class WinControls
    {
        public static void CarregaCombo<T>(ref ComboBox rcboControle, IList<T> itens) where T : BaseID
        {
            CarregaCombo<T>(ref rcboControle, itens, false);
        }

        public static void CarregaCombo<T>(ref ComboBox rcboControle)where T:BaseID
        {
            IList<T> itens;
            itens = Conexao.TrataDAO.getAcesso<T>().Retorna();
            CarregaCombo<T>(ref rcboControle, itens, false);

        }
        public static void CarregaCombo<T>(ref ComboBox rcboControle, IList<T> itens, Boolean distintos) where T : BaseID
        {
            rcboControle.Items.Clear();
            foreach (var item in itens)
                if (distintos)
                {
                    if (!rcboControle.Items.Contains(item.ToString()))
                        rcboControle.Items.Add(item.ToString());
                }
                else
                    rcboControle.Items.Add(item);
        }
        /// <summary>Carrega os itens de um ComboBox a partir de um Enum</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="combo"></param>
        /// <example>CarregarComboEnum<TipoPessoa>(cboTipoPessoa, false);</example>
        public static void CarregaComboEnum<T>(ref ComboBox combo, bool todos)
        {
            combo.DataSource = TrataEnum.Listar(typeof(T), todos);
            combo.DisplayMember = "Value";
            combo.ValueMember = "Key";
        }
        public static void CarregaComboEnum(ref ComboBox combo, bool todos, Type tipo)
        {
            combo.DataSource = TrataEnum.Listar(tipo, todos);
            combo.DisplayMember = "Value";
            combo.ValueMember = "Key";
        }
        public static void CarregaComboEnum<T>(ref DataGridViewComboBoxColumn combo, bool todos)
        {
            combo.DataSource = TrataEnum.Listar(typeof(T), todos);
            combo.DisplayMember = "Value";
            combo.ValueMember = "Key";
        }
        public static string CapturaArquivo()
        {
            if (Clipboard.ContainsFileDropList())
                return Clipboard.GetFileDropList()[0].ToString();
            else
                return "";
        }
        public static string CapturaTexto()
        {
            if (Clipboard.ContainsText())
                return Clipboard.GetText();
            else
                return "";
        }
        public static void EnviaTexto(string vstrTexto)
        {
            if (vstrTexto.ToString() != "") { Clipboard.SetText(vstrTexto); }
        }
        public static void OrdenarMenuContext(ref ContextMenu contextMenu)
        {
            ContextMenu ordenado = new ContextMenu();
            List<MenuItem> aux = new List<MenuItem>();

            for (int i = contextMenu.MenuItems.Count - 1; i >= 0; i--)
            {
                if (contextMenu.MenuItems[i].MenuItems.Count > 0)
                {
                    aux.Add(contextMenu.MenuItems[i]);
                    contextMenu.MenuItems.RemoveAt(i);
                }
            }

            foreach (MenuItem item in aux.OrderBy(m => m.Text))
            {
                ordenado.MenuItems.Add(item);
            }
            aux = new List<MenuItem>();

            for (int i = contextMenu.MenuItems.Count - 1; i >= 0; i--)
            {
                aux.Add(contextMenu.MenuItems[i]);
                contextMenu.MenuItems.RemoveAt(i);
            }
            foreach (MenuItem item in aux.OrderBy(m => m.Text))
            {
                ordenado.MenuItems.Add(item);
            }
            contextMenu = ordenado;

        }
        public static void OrdenarMenuItem(ref MenuItem menuItem)
        {
            MenuItem ordenado = new MenuItem();
            List<MenuItem> aux = new List<MenuItem>();

            for (int i = menuItem.MenuItems.Count - 1; i >= 0; i--)
            {
                if (menuItem.MenuItems[i].MenuItems.Count > 0)
                {
                    aux.Add(menuItem.MenuItems[i]);
                    menuItem.MenuItems.RemoveAt(i);
                }
            }

            foreach (MenuItem item in aux.OrderBy(m => m.Text))
            {
                ordenado.MenuItems.Add(item);
            }
            aux = new List<MenuItem>();

            for (int i = menuItem.MenuItems.Count - 1; i >= 0; i--)
            {
                aux.Add(menuItem.MenuItems[i]);
                menuItem.MenuItems.RemoveAt(i);
            }
            foreach (MenuItem item in aux.OrderBy(m => m.Text))
            {
                ordenado.MenuItems.Add(item);
            }
            ordenado.Text = menuItem.Text;
            menuItem = ordenado;

        }
        public static void ApresentarErro(AssistException assistEx)
        {
            MessageBox.Show(assistEx.GetMessage(), "Erro Assistente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
