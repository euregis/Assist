using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assistente.Entidades.Filtros;
using Assistente.Entidades;
using Assistente.Controle;
using Assistente.Excecoes;

namespace Assistente.View.Base.Forms
{
    public partial class frmFiltros : frmBase
    {
        protected TrataFiltros trataFiltros;
        private int alturaLabel = 38;
        private int alturaCampo = 34;
        private int leftLabel1 = 4;
        private int leftCampo1 = 137;
        int leftLabel2 = 255;
        int leftCampo2 = 283;
        int tabIndex = 0;

        public frmFiltros()
        {
            InitializeComponent();
            ExibirBotoes(Botoes.Confirmar, Botoes.Cancelar, Botoes.Limpar, Botoes.SepSair);
            tslTitulo.Text = "Filtros";
        }
        public TrataFiltros Carregar(TrataFiltros trataFiltros)
        {
            try
            {
                this.trataFiltros = trataFiltros;
                CarregarCampos();
                this.ShowDialog();
                return this.trataFiltros;
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
                return this.trataFiltros;
            }
        }
        protected void CarregarCampos()
        {
            for (int i = 0; i < trataFiltros.Filtros.Count; i++)
            {
                TrataCampos(trataFiltros.Filtros[i]);
            }
            this.Height = alturaCampo + 50;
        }
        protected void TrataCampos(Filtro filtro)
        {
            Label lblAte;
            Label lblTitulo;
            TextBox txtText;
            switch (filtro.TipoFiltro)
            {
                case TipoFiltro.NumInteiro:
                    lblTitulo = new Label();
                    lblTitulo.Location = new Point(4, alturaLabel);
                    lblTitulo.Name = "lbl" + filtro.Propriedade.Name;
                    lblTitulo.Size = new Size(127, 13);
                    lblTitulo.Text = filtro.NomeExibicao;
                    lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
                    lblTitulo.TabIndex = tabIndex++;

                    //ControleNumerico.ControleNumerico ctnDe = new ControleNumerico.ControleNumerico();
                    txtText = new TextBox();
                    txtText.Location = new Point(137, alturaCampo);
                    txtText.Name = "txt" + filtro.Propriedade.Name + "De";
                    txtText.Size = new Size(112, 20);
                    txtText.TabIndex = tabIndex++;
                    txtText.TextAlign = HorizontalAlignment.Right;
                    txtText.Click += new System.EventHandler(this.txtText_Click);
                    txtText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTextNumInteiro_KeyPress);
                    if (filtro.ValorUsado1 == null || filtro.ValorUsado1.ToString() == "")
                        txtText.Text = "0";
                    else
                        txtText.Text = Double.Parse(filtro.ValorUsado1.ToString()).ToString("0");

                    if (filtro.Propriedade.PropertyType == typeof(short))
                        txtText.MaxLength = 5;
                    else if (filtro.Propriedade.PropertyType == typeof(int))
                        txtText.MaxLength = 10;
                    else if (filtro.Propriedade.PropertyType == typeof(long))
                        txtText.MaxLength = 19;

                    filtro.Controle1 = txtText.Name;

                    this.Controls.Add(lblTitulo);
                    this.Controls.Add(txtText);
                    switch (((FiltroNumInteiro)filtro).TipoProcura)
                    {
                        case TipoProcura.Apartir:

                            break;
                        case TipoProcura.Ate:
                            //filtro.Criterio = Restrictions.Le(filtro.NomeCampo, Convert.ChangeType(filtro.ValorUsado1, filtro.TipoDados));
                            break;
                        case TipoProcura.Exato:


                            break;
                        case TipoProcura.Entre:
                            lblAte = new Label();
                            lblAte.Location = new Point(255, alturaLabel);
                            lblAte.Name = "lbl" + filtro.Propriedade.Name + "Ate";
                            lblAte.Size = new Size(22, 13);
                            lblAte.Text = "até";
                            lblAte.TextAlign = ContentAlignment.MiddleCenter;
                            lblAte.TabIndex = tabIndex++;

                            //ControleNumerico.ControleNumerico ctnAte = new ControleNumerico.ControleNumerico();
                            TextBox txtAte = new TextBox();
                            txtAte.Location = new Point(283, alturaCampo);
                            txtAte.Name = "ctn" + filtro.Propriedade.Name + "Ate";
                            txtAte.Size = new Size(112, 20);
                            txtAte.TabIndex = tabIndex++;
                            txtAte.TextAlign = HorizontalAlignment.Right;
                            txtAte.Click += new System.EventHandler(this.txtText_Click);
                            txtAte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTextNumInteiro_KeyPress);

                            if (((FiltroNumInteiro)filtro).ValorUsado2 == null || ((FiltroNumInteiro)filtro).ValorUsado2.ToString() == "")
                                txtAte.Text = "0";
                            else
                                txtAte.Text = Double.Parse(((FiltroNumInteiro)filtro).ValorUsado2.ToString()).ToString("0");

                            if (filtro.Propriedade.PropertyType == typeof(short))
                                txtAte.MaxLength = 5;
                            else if (filtro.Propriedade.PropertyType == typeof(int))
                                txtAte.MaxLength = 10;
                            else if (filtro.Propriedade.PropertyType == typeof(long))
                                txtAte.MaxLength = 19;

                            ((FiltroNumInteiro)filtro).Controle2 = txtAte.Name;

                            this.Controls.Add(lblAte);
                            this.Controls.Add(txtAte);
                            break;
                        default:
                            break;
                    }
                    break;
                case TipoFiltro.Data:
                    switch (((FiltroData)filtro).TipoProcura)
                    {
                        case TipoProcura.Apartir:
                            break;
                        case TipoProcura.Ate:
                            //filtro.Criterio = Restrictions.Le(filtro.NomeCampo, Convert.ChangeType(filtro.ValorUsado1, filtro.TipoDados));
                            break;
                        case TipoProcura.Exato:
                            //filtro.Criterio = Restrictions.Eq(filtro.NomeCampo, Convert.ChangeType(filtro.ValorUsado1, filtro.TipoDados));
                            break;
                        case TipoProcura.Entre:
                            lblTitulo = new Label();
                            lblTitulo.Location = new Point(4, alturaLabel);
                            lblTitulo.Name = "lbl" + filtro.Propriedade.Name;
                            lblTitulo.Size = new Size(127, 13);
                            lblTitulo.Text = filtro.NomeExibicao;
                            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
                            lblTitulo.TabIndex = tabIndex++;

                            DateTimePicker dtpDe = new DateTimePicker();
                            dtpDe.Location = new Point(137, alturaCampo);
                            dtpDe.Name = "dtp" + filtro.Propriedade.Name + "De";
                            dtpDe.Format = DateTimePickerFormat.Short;
                            dtpDe.ShowCheckBox = true;
                            dtpDe.Size = new Size(112, 20);
                            dtpDe.TabIndex = tabIndex++;
                            if (filtro.ValorUsado1 == null)
                            {
                                dtpDe.Value = DateTime.Now;
                                dtpDe.Checked = false;
                            }
                            else
                            {
                                dtpDe.Value = (DateTime)filtro.ValorUsado1;
                                dtpDe.Checked = true;
                            }
                            filtro.Controle1 = dtpDe.Name;

                            lblAte = new Label();
                            lblAte.Location = new Point(255, alturaLabel);
                            lblAte.Name = "lbl" + filtro.Propriedade.Name + "Ate";
                            lblAte.Size = new Size(22, 13);
                            lblAte.Text = "até";
                            lblAte.TextAlign = ContentAlignment.MiddleCenter;
                            lblAte.TabIndex = tabIndex++;

                            DateTimePicker dtpAte = new DateTimePicker();
                            dtpAte.Location = new Point(283, alturaCampo);
                            dtpAte.Name = "dtp" + filtro.Propriedade.Name + "Ate";
                            dtpAte.Format = DateTimePickerFormat.Short;
                            dtpAte.ShowCheckBox = true;
                            dtpAte.Size = new Size(112, 20);
                            dtpAte.TabIndex = tabIndex++;
                            if (((FiltroData)filtro).ValorUsado2 == null)
                            {
                                dtpAte.Value = DateTime.Now;
                                dtpAte.Checked = false;
                            }
                            else
                            {
                                dtpAte.Value = (DateTime)((FiltroData)filtro).ValorUsado2;
                                dtpAte.Checked = true;
                            }
                            ((FiltroData)filtro).Controle2 = dtpAte.Name;

                            this.Controls.Add(lblTitulo);
                            this.Controls.Add(dtpDe);
                            this.Controls.Add(lblAte);
                            this.Controls.Add(dtpAte);

                            break;
                        default:
                            break;
                    }

                    break;
                case TipoFiltro.Texto:
                    lblTitulo = new Label();
                    lblTitulo.Location = new Point(4, alturaLabel);
                    lblTitulo.Name = "lbl" + filtro.Propriedade.Name;
                    lblTitulo.Size = new Size(127, 13);
                    lblTitulo.Text = filtro.NomeExibicao;
                    lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
                    lblTitulo.TabIndex = tabIndex++;

                    txtText = new TextBox();
                    txtText.Location = new Point(137, alturaCampo);
                    txtText.Name = "txt" + filtro.Propriedade.Name;
                    txtText.Size = new Size(258, 21);
                    txtText.TabIndex = tabIndex++;

                    if (String.IsNullOrEmpty((string)filtro.ValorUsado1))
                        txtText.Text = "";
                    else
                        txtText.Text = "" + filtro.ValorUsado1;

                    filtro.Controle1 = txtText.Name;
                    this.Controls.Add(lblTitulo);
                    this.Controls.Add(txtText);
                    break;
                case TipoFiltro.Combo:
                    lblTitulo = new Label();
                    lblTitulo.Location = new Point(4, alturaLabel);
                    lblTitulo.Name = "lbl" + filtro.Propriedade.Name;
                    lblTitulo.Size = new Size(127, 13);
                    lblTitulo.Text = filtro.NomeExibicao;
                    lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
                    lblTitulo.TabIndex = tabIndex++;

                    ComboBox cboCombo = new ComboBox();
                    cboCombo.DropDownStyle = ComboBoxStyle.DropDownList;
                    cboCombo.FormattingEnabled = true;
                    cboCombo.Location = new Point(137, alturaCampo);
                    cboCombo.Name = "cbo" + filtro.Propriedade.Name;
                    cboCombo.Size = new Size(258, 21);
                    cboCombo.TabIndex = tabIndex++;
                    filtro.Controle1 = cboCombo.Name;
                    this.Controls.Add(lblTitulo);
                    this.Controls.Add(cboCombo);
                    this.Controls.SetChildIndex(lblTitulo, 0);
                    this.Controls.SetChildIndex(cboCombo, 0);

                    if (!((FiltroCombo)filtro).IsEnum)
                    {
                        if (((FiltroCombo)filtro).OpcaoTodos)
                            cboCombo.Items.Add("Todos");
                        if (((FiltroCombo)filtro).Lista != null)
                            foreach (var item in ((FiltroCombo)filtro).Lista)
                                cboCombo.Items.Add(item);

                        if (((FiltroCombo)filtro).OpcaoTodos && filtro.ValorUsado1 != null &&
                            filtro.ValorUsado1.ToString().ToUpper() == "TODOS")
                            cboCombo.SelectedItem = filtro.ValorUsado1.ToString();
                        else
                            cboCombo.SelectedItem = filtro.ValorUsado1;
                    }
                    else
                    {
                        //Controle.WinControls.CarregaComboEnum<enuStatusTarefa>(ref cboCombo, !((FiltroCombo)filtro).OpcaoTodos);
                        Controle.WinControls.CarregaComboEnum(ref cboCombo,
                            ((FiltroCombo)filtro).OpcaoTodos, ((FiltroCombo)filtro).Tipo);
                        cboCombo.SelectedValue = Enum.ToObject(((FiltroCombo)filtro).Tipo, filtro.ValorUsado1);
                    }




                    break;
                case TipoFiltro.Checkbox:
                    lblTitulo = new Label();
                    lblTitulo.Location = new Point(4, alturaLabel);
                    lblTitulo.Name = "lbl" + filtro.Propriedade.Name;
                    lblTitulo.Size = new Size(127, 13);
                    lblTitulo.Text = filtro.NomeExibicao;
                    lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
                    lblTitulo.TabIndex = tabIndex++;

                    CheckBox checkBox = new CheckBox();
                    checkBox.Location = new Point(137, alturaCampo + 4);
                    checkBox.Name = "chk" + filtro.Propriedade.Name;
                    checkBox.Text = "";
                    checkBox.ThreeState = true;
                    checkBox.Size = new Size(15, 14);
                    checkBox.TabIndex = tabIndex++;
                    filtro.Controle1 = checkBox.Name;
                    this.Controls.Add(lblTitulo);
                    this.Controls.Add(checkBox);
                    this.Controls.SetChildIndex(lblTitulo, 0);
                    this.Controls.SetChildIndex(checkBox, 0);

                    checkBox.CheckState = (CheckState)(byte)filtro.ValorUsado1;
                    break;
                case TipoFiltro.Decimal:
                    switch (((FiltroDecimal)filtro).TipoProcura)
                    {
                        case TipoProcura.Apartir:

                            break;
                        case TipoProcura.Ate:
                            //filtro.Criterio = Restrictions.Le(filtro.NomeCampo, Convert.ChangeType(filtro.ValorUsado1, filtro.TipoDados));
                            break;
                        case TipoProcura.Exato:
                            lblTitulo = new Label();
                            lblTitulo.Location = new Point(4, alturaLabel);
                            lblTitulo.Name = "lbl" + filtro.Propriedade.Name;
                            lblTitulo.Size = new Size(127, 13);
                            lblTitulo.Text = filtro.NomeExibicao;
                            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
                            lblTitulo.TabIndex = tabIndex++;

                            //ControleNumerico.ControleNumerico ctnDe = new ControleNumerico.ControleNumerico();
                            txtText = new TextBox();
                            txtText.Location = new Point(137, alturaCampo);
                            txtText.Name = "ctn" + filtro.Propriedade.Name + "De";
                            txtText.Size = new Size(112, 20);
                            txtText.TabIndex = tabIndex++;
                            if (filtro.ValorUsado1 == null || filtro.ValorUsado1.ToString() == "")
                                txtText.Text = "0,00";
                            else
                                txtText.Text = Double.Parse(filtro.ValorUsado1.ToString()).ToString("0.00");

                            filtro.Controle1 = txtText.Name;

                            this.Controls.Add(lblTitulo);
                            this.Controls.Add(txtText);

                            break;
                        case TipoProcura.Entre:
                            lblTitulo = new Label();
                            lblTitulo.Location = new Point(4, alturaLabel);
                            lblTitulo.Name = "lbl" + filtro.Propriedade.Name;
                            lblTitulo.Size = new Size(127, 13);
                            lblTitulo.Text = filtro.NomeExibicao;
                            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
                            lblTitulo.TabIndex = tabIndex++;

                            //ControleNumerico.ControleNumerico ctnDe = new ControleNumerico.ControleNumerico();
                            txtText = new TextBox();
                            txtText.Location = new Point(137, alturaCampo);
                            txtText.Name = "ctn" + filtro.Propriedade.Name + "De";
                            txtText.Size = new Size(112, 20);
                            txtText.TabIndex = tabIndex++;
                            if (filtro.ValorUsado1 == null)
                                txtText.Text = "0,00";
                            else
                                txtText.Text = Double.Parse(filtro.ValorUsado1.ToString()).ToString("0.00");

                            filtro.Controle1 = txtText.Name;

                            lblAte = new Label();
                            lblAte.Location = new Point(255, alturaLabel);
                            lblAte.Name = "lbl" + filtro.Propriedade.Name + "Ate";
                            lblAte.Size = new Size(22, 13);
                            lblAte.Text = "até";
                            lblAte.TextAlign = ContentAlignment.MiddleCenter;
                            lblAte.TabIndex = tabIndex++;

                            //ControleNumerico.ControleNumerico ctnAte = new ControleNumerico.ControleNumerico();
                            TextBox ctnAte = new TextBox();
                            ctnAte.Location = new Point(283, alturaCampo);
                            ctnAte.Name = "ctn" + filtro.Propriedade.Name + "Ate";
                            ctnAte.Size = new Size(112, 20);
                            ctnAte.TabIndex = tabIndex++;
                            if (((FiltroDecimal)filtro).ValorUsado2 == null)
                                ctnAte.Text = "0,00";
                            else
                                ctnAte.Text = Double.Parse(((FiltroDecimal)filtro).ValorUsado2.ToString()).ToString("0.00");

                            ((FiltroDecimal)filtro).Controle2 = ctnAte.Name;

                            this.Controls.Add(lblTitulo);
                            this.Controls.Add(txtText);
                            this.Controls.Add(lblAte);
                            this.Controls.Add(ctnAte);
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;

            }

            alturaLabel += 26;
            alturaCampo += 26;
        }

        protected override void Confirmar(object sender, EventArgs e)
        {
            try
            {
                trataFiltros.filtroUtilizado = false;
                foreach (Filtro filtro in trataFiltros.Filtros)
                {
                    filtro.Utilizado = false;
                    foreach (Control controle in this.Controls)
                    {
                        TextBox textBox = null;
                        switch (filtro.TipoFiltro)
                        {
                            case TipoFiltro.Data:
                                DateTimePicker dtp;
                                if (filtro.Controle1 == controle.Name)
                                {
                                    dtp = (DateTimePicker)controle;
                                    filtro.ValorUsado1 = dtp.Checked ? dtp.Value : (DateTime?)null;
                                    filtro.Utilizado = filtro.ValorUsado1 != filtro.ValorLimpo1;
                                }
                                else if (((FiltroData)filtro).Controle2 == controle.Name)
                                {
                                    dtp = (DateTimePicker)controle;
                                    ((FiltroData)filtro).ValorUsado2 = dtp.Checked ? dtp.Value : (DateTime?)null;
                                    filtro.Utilizado = ((FiltroData)filtro).ValorUsado2 != ((FiltroData)filtro).ValorLimpo2;
                                }
                                if (filtro.ValorUsado1 != null || ((FiltroData)filtro).ValorUsado2 != null)
                                {
                                    filtro.Utilizado = true;
                                    trataFiltros.filtroUtilizado = true;
                                }
                                break;
                            case TipoFiltro.Texto:
                                if (filtro.Controle1 == controle.Name)
                                {
                                    textBox = (TextBox)controle;
                                    filtro.ValorUsado1 = textBox.Text.Trim();
                                    filtro.Utilizado = !filtro.ValorUsado1.Equals(filtro.ValorLimpo1);
                                }
                                break;
                            case TipoFiltro.Checkbox:
                                if (filtro.Controle1 == controle.Name)
                                {
                                    CheckBox checkBox = (CheckBox)controle;
                                    filtro.ValorUsado1 = (byte)checkBox.CheckState;
                                    filtro.Utilizado = !filtro.ValorUsado1.Equals(filtro.ValorLimpo1);
                                    if (checkBox.CheckState == CheckState.Indeterminate)
                                    {
                                        filtro.Utilizado = false;
                                        trataFiltros.filtroUtilizado = true;
                                    }
                                }
                                break;
                            case TipoFiltro.Combo:
                                if (filtro.Controle1 == controle.Name)
                                {
                                    ComboBox cbo = (ComboBox)controle;
                                    if (((FiltroCombo)filtro).IsEnum)
                                    {
                                        filtro.ValorUsado1 = Enum.ToObject(((FiltroCombo)filtro).Tipo, cbo.SelectedValue);
                                        filtro.Utilizado = !filtro.ValorUsado1.Equals(filtro.ValorLimpo1);
                                        if (filtro.Utilizado) filtro.ValorUsado1 = Convert.ChangeType(filtro.ValorUsado1, filtro.Propriedade.PropertyType);
                                    }
                                    else
                                    {
                                        if (cbo.SelectedItem != null && cbo.SelectedItem.ToString() == "")
                                        {
                                            if (filtro.Propriedade.PropertyType == typeof(string))
                                                filtro.ValorUsado1 = cbo.SelectedItem;
                                            else
                                                filtro.ValorUsado1 = null;
                                        }
                                        else
                                        {
                                            filtro.ValorUsado1 = cbo.SelectedItem;
                                        }
                                        filtro.Utilizado = filtro.ValorUsado1 != null && filtro.ValorUsado1 != "Todos";
                                    }
                                }
                                break;
                            case TipoFiltro.Decimal:
                                if (filtro.Controle1 == controle.Name)
                                {
                                    textBox = (TextBox)controle;
                                    filtro.ValorUsado1 = textBox.Text;
                                    filtro.Utilizado = filtro.ValorUsado1 != filtro.ValorLimpo1;
                                }
                                else if (((FiltroDecimal)filtro).Controle2 == controle.Name)
                                {
                                    textBox = (TextBox)controle;
                                    ((FiltroDecimal)filtro).ValorUsado2 = textBox.Text;
                                    filtro.Utilizado = ((FiltroDecimal)filtro).ValorUsado2 != ((FiltroDecimal)filtro).ValorLimpo2;
                                }
                                break;
                            case TipoFiltro.NumInteiro:
                                if (filtro.Controle1 == controle.Name)
                                {
                                    textBox = (TextBox)controle;
                                    if (textBox.Text != "")
                                    {
                                        filtro.ValorUsado1 = textBox.Text;
                                        filtro.Utilizado = !filtro.ValorUsado1.Equals(filtro.ValorLimpo1) && !filtro.ValorUsado1.Equals("0");
                                    }
                                }
                                else if (((FiltroNumInteiro)filtro).Controle2 == controle.Name)
                                {
                                    textBox = (TextBox)controle;
                                    if (textBox.Text != "")
                                    {
                                        ((FiltroNumInteiro)filtro).ValorUsado2 = textBox.Text;
                                        filtro.Utilizado = (!((FiltroNumInteiro)filtro).ValorUsado2.Equals(((FiltroNumInteiro)filtro).ValorLimpo2)
                                            && !((FiltroNumInteiro)filtro).ValorUsado2.Equals("0")) || filtro.Utilizado;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    trataFiltros.filtroUtilizado = trataFiltros.filtroUtilizado || filtro.Utilizado;
                }

                this.Sair(sender, e);
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));

            }
        }
        protected override void Limpar(object sender, EventArgs e)
        {
            try
            {
                trataFiltros.filtroUtilizado = false;
                foreach (var item in trataFiltros.Filtros)
                {
                    item.Utilizado = false;
                    switch (item.TipoFiltro)
                    {
                        case TipoFiltro.Combo:
                            if (item.ValorLimpo1.ToString() != "Todos")
                            {
                                item.Utilizado = true;
                                trataFiltros.filtroUtilizado = true;
                            }
                            break;
                        case TipoFiltro.NumInteiro:
                            break;
                        case TipoFiltro.Data:
                            ((FiltroData)item).ValorUsado2 = ((FiltroData)item).ValorLimpo2;
                            if (item.ValorLimpo1 != null || ((FiltroData)item).ValorLimpo2 != null)
                            {
                                item.Utilizado = true;
                                trataFiltros.filtroUtilizado = true;
                            }
                            break;
                        case TipoFiltro.Texto:
                            if (!String.IsNullOrEmpty((string)item.ValorLimpo1))
                            {
                                item.Utilizado = true;
                                trataFiltros.filtroUtilizado = true;
                            }
                            break;
                        case TipoFiltro.Decimal:
                            ((FiltroDecimal)item).ValorUsado2 = ((FiltroDecimal)item).ValorLimpo2;
                            break;
                        default:
                            break;
                    }
                    item.ValorUsado1 = item.ValorLimpo1;

                }
                this.Sair(sender, e);
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));

            }
        }
        protected override void Cancelar(object sender, EventArgs e)
        {
            try
            {
                base.Cancelar(sender, e);
                this.Sair(sender, e);
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));

            }
        }

        private void txtText_Click(object sender, EventArgs e)
        {
            try
            {
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        private void txtTextNumInteiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                FormatMask mascara = atribuiMascara((char)e.KeyChar, ((TextBox)sender).Text);
                if (!(e.Handled = mascara.mascaraNumero(19)))
                    ((TextBox)sender).Text = mascara.mascaraNumInteiro();
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length + 1;
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private FormatMask atribuiMascara(char caractere, string texto)
        {   //preenche atributos mascara
            FormatMask objetoMascara = new FormatMask();
            objetoMascara.recebeTecla(caractere);
            objetoMascara.recebePalavra(texto);
            return objetoMascara;
        }
    }
}