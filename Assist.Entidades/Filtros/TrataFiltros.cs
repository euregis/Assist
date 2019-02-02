using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace Assistente.Entidades.Filtros
{
    public class TrataFiltros
    {
        public bool filtroUtilizado = false;
        public List<Filtro> Filtros = new List<Filtro>();

        private void IncluirFiltro(Filtro filtro)
        {
            if (retornaFiltro(filtro.Propriedade.Name) == null)
                Filtros.Add(filtro);
            if (filtro.Utilizado) filtroUtilizado = true;

        }
        public void IncluirFiltroData(PropertyInfo propriedade, TipoProcura tipoProcura, string nomeExibicao,
                 Object valorUsado1, Object valorUsado2, Object valorLimpo1, Object valorLimpo2)
        {
            IncluirFiltro(new FiltroData(propriedade, tipoProcura, nomeExibicao, valorUsado1, valorUsado2, valorLimpo1, valorLimpo2));

        }
        public void IncluirFiltroNumInteiro(PropertyInfo propriedade, TipoProcura tipoProcura, string nomeExibicao,
                Object valorUsado1, Object valorUsado2, Object valorLimpo1, Object valorLimpo2)
        {
            IncluirFiltro(new FiltroNumInteiro(propriedade, tipoProcura, nomeExibicao, valorUsado1, valorUsado2, valorLimpo1, valorLimpo2));
        }
        public void IncluirFiltroValor(PropertyInfo propriedade, TipoProcura tipoProcura, string nomeExibicao,
                Object valorUsado1, Object valorUsado2, Object valorLimpo1, Object valorLimpo2)
        {
            IncluirFiltro(new FiltroDecimal(propriedade, tipoProcura, nomeExibicao, valorUsado1, valorUsado2, valorLimpo1, valorLimpo2));
        }
        public void IncluirFiltroTexto(PropertyInfo propriedade, PosicaoProcura posicaoProcura, string nomeExibicao,
                string valorUsado1, string valorLimpo1)
        {
            IncluirFiltro(new FiltroTexto(propriedade, posicaoProcura, nomeExibicao, valorUsado1, valorLimpo1));
        }

        public void IncluirFiltroCombo(PropertyInfo propriedade, string nomeExibicao, Object valorUsado1,
                Object valorLimpo1, bool isEnum, bool opcaoTodos, ArrayList lista, Type tipo)
        {
            IncluirFiltro(new FiltroCombo(propriedade, nomeExibicao, valorUsado1, valorLimpo1, isEnum, opcaoTodos, lista, tipo));
        }
        public void IncluirFiltroCheckbox(PropertyInfo propriedade, string nomeExibicao, byte valorUsado1,
                byte valorLimpo1)
        {
            IncluirFiltro(new FiltroCheckbox(propriedade, nomeExibicao, valorUsado1, valorLimpo1));
        }
        public Filtro retornaFiltro(string nomeCampo)
        {
            foreach (var item in Filtros)
            {
                if (item.Propriedade.Name == nomeCampo)
                    return item;
            }
            return null;
        }

        //private void MontarFiltro(Filtro filtro)
        //{
        //    try
        //    {
        //        if (filtro.TipoFiltro == TipoFiltro.Numerico) { }
        //        else if (filtro.TipoFiltro == TipoFiltro.Data)
        //        {
        //            switch (((FiltroData)filtro).TipoProcura)
        //            {
        //                case TipoProcura.Apartir:
        //                    filtro.Criterio = Restrictions.Ge(filtro.NomeCampo, Convert.ChangeType(filtro.ValorUsado1, filtro.TipoDados));
        //                    break;
        //                case TipoProcura.Ate:
        //                    filtro.Criterio = Restrictions.Le(filtro.NomeCampo, Convert.ChangeType(filtro.ValorUsado1, filtro.TipoDados));
        //                    break;
        //                case TipoProcura.Exato:
        //                    filtro.Criterio = Restrictions.Eq(filtro.NomeCampo, Convert.ChangeType(filtro.ValorUsado1, filtro.TipoDados));
        //                    break;
        //                case TipoProcura.Entre:
        //                    if (filtro.ValorUsado1 == null && ((FiltroData)filtro).ValorUsado2 == null) return;
        //                    else if (filtro.ValorUsado1 == null) goto case TipoProcura.Ate;
        //                    else if (((FiltroData)filtro).ValorUsado2 == null) goto case TipoProcura.Apartir;
        //                    filtro.Criterio = Restrictions.Between(filtro.NomeCampo, Convert.ChangeType(filtro.ValorUsado1, filtro.TipoDados), Convert.ChangeType(((FiltroData)filtro).ValorUsado2, ((FiltroData)filtro).TipoDados));
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //        else if (filtro.TipoFiltro == TipoFiltro.Texto && !String.IsNullOrEmpty((string)filtro.ValorUsado1))
        //        {
        //            switch (((FiltroTexto)filtro).PosicaoProcura)
        //            {
        //                case PosicaoProcura.Inicio:
        //                    filtro.Criterio = Restrictions.Like(filtro.NomeCampo, "" + filtro.ValorUsado1, MatchMode.Start);
        //                    break;
        //                case PosicaoProcura.Fim:
        //                    filtro.Criterio = Restrictions.Like(filtro.NomeCampo, "" + filtro.ValorUsado1, MatchMode.End);
        //                    break;
        //                case PosicaoProcura.Exato:
        //                    filtro.Criterio = Restrictions.Like(filtro.NomeCampo, "" + filtro.ValorUsado1, MatchMode.Exact);
        //                    break;
        //                case PosicaoProcura.Qualquer:
        //                    filtro.Criterio = Restrictions.Like(filtro.NomeCampo, "" + filtro.ValorUsado1, MatchMode.Anywhere);
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //        else if (filtro.TipoFiltro == TipoFiltro.Combo)
        //        {
        //            if (((FiltroCombo)filtro).IsEnum)
        //            {
        //                if (!((FiltroCombo)filtro).OpcaoTodos
        //                    || (((FiltroCombo)filtro).OpcaoTodos && (int)filtro.ValorUsado1 > 0))
        //                    Restrictions.Eq(filtro.NomeCampo, (int)filtro.ValorUsado1);
        //            }
        //            else
        //            {
        //                if (!((FiltroCombo)filtro).OpcaoTodos
        //                       || (((FiltroCombo)filtro).OpcaoTodos && ((string)filtro.ValorUsado1).ToUpper() != "TODOS"))
        //                    Restrictions.Eq(filtro.NomeCampo, Convert.ChangeType(filtro.ValorUsado1, filtro.TipoDados));
        //            }
        //        }
        //        else if (filtro.TipoFiltro == TipoFiltro.Valor)
        //        {
        //            switch (((FiltroValor)filtro).TipoProcura)
        //            {
        //                case TipoProcura.Apartir:
        //                    filtro.Criterio = Restrictions.Ge(filtro.NomeCampo, Convert.ChangeType(filtro.ValorUsado1, filtro.TipoDados));
        //                    break;
        //                case TipoProcura.Ate:
        //                    filtro.Criterio = Restrictions.Le(filtro.NomeCampo, Convert.ChangeType(filtro.ValorUsado1, filtro.TipoDados));
        //                    break;
        //                case TipoProcura.Exato:
        //                    filtro.Criterio = Restrictions.Eq(filtro.NomeCampo, Convert.ChangeType(filtro.ValorUsado1, filtro.TipoDados));
        //                    break;
        //                case TipoProcura.Entre:
        //                    if (double.Parse(filtro.ValorUsado1.ToString()) == 0 &&
        //                        double.Parse(((FiltroValor)filtro).ValorUsado2.ToString()) == 0)
        //                        return;
        //                    else if (double.Parse(filtro.ValorUsado1.ToString()) == 0) goto case TipoProcura.Ate;
        //                    else if (double.Parse(((FiltroValor)filtro).ValorUsado2.ToString()) == 0) goto case TipoProcura.Apartir;
        //                    filtro.Criterio = Restrictions.Between(filtro.NomeCampo, Convert.ChangeType(filtro.ValorUsado1, filtro.TipoDados), Convert.ChangeType(((FiltroValor)filtro).ValorUsado2, ((FiltroValor)filtro).TipoDados));
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }

        //}
        //public List<ICriterion> Criterios()
        //{
        //    List<ICriterion> criterios = new List<ICriterion>();
        //    foreach (Filtro item in Filtros)
        //    {
        //        item.Criterio = null;
        //        CriarCriterio(item);
        //        if (item.Criterio != null)
        //            criterios.Add(item.Criterio);
        //    }
        //    return criterios;
        //}

    }
}
