﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using Assistente.Entidades.Base;
using NHibernate;
using NHibernate.Linq;
using Conexao.FluentNHibernate;
using Assistente.AcessoDados.Interfaces;
using NHibernate.Exceptions;
using System.Linq.Expressions;
using Assistente.Entidades.Filtros;
using Assistente.Excecoes;

namespace Assistente.AcessoDados.NHLinq
{
    public class BaseDAO<T> : IAcessoUtil, IAcesso<T> where T : Assistente.Entidades.Base.BaseID
    {
        public IList<string> Erros { get; set; }

        public BaseDAO() { Erros = new List<string>(); }

        public bool Salvar(T obj)
        {
            return Salvar(obj, null);
        }
        public bool Salvar(T obj, ITransaction objTransaction)
        {
            if (!Config.ValidaSessao()) return false;

            if (objTransaction != null)
            {
                if (!objTransaction.IsActive) { objTransaction = Config.Conexao.Sessao.BeginTransaction(); }
            }
            else { objTransaction = Config.Conexao.Sessao.BeginTransaction(); }

            try
            {
                Config.Conexao.Sessao.SaveOrUpdate(obj);
                objTransaction.Commit();
                Config.Conexao.Sessao.Flush();

                return true;
            }
            catch (SqlException)
            {
                objTransaction.Rollback();
                Config.Conexao.Sessao.Close();
                Config.Conexao.AbrirSessao(); 
                throw new Exception("Não foi possivel inluir este registro.\n\nJá existe um registro com "
                                   + "esta caracteristica.");
            }
            catch (NonUniqueObjectException)
            {
                objTransaction.Rollback();
                Config.Conexao.Sessao.Close();
                Config.Conexao.AbrirSessao();
                throw new Exception("Não foi possivel inluir este registro.\n\nJá existe um registro com "
                                   + "esta caracteristica.");
            }
            catch (GenericADOException ex)
            {
                objTransaction.Rollback();
                Config.Conexao.Sessao.Close();
                Config.Conexao.AbrirSessao();
                if (ex.Message.Contains("could not insert") && ex.Message.Contains("UNIQUE KEY"))
                    throw new Exception("Não foi possivel incluir este registro.\n\nJá existe um registro com "
                                   + "esta caracteristica.");
                else
                    throw new Exception("Náo foi possivel incluir este registro.\n\nVerifique as informações a serem salvas.");
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                Config.Conexao.Sessao.Close();
                Config.Conexao.AbrirSessao();
                throw new Exception("Náo foi possivel inluir este registro.\n\n" + ex.Message);
            }

        }
        public bool Excluir(T obj)
        {
            return Excluir(obj, null);
        }
        public bool Excluir(T obj, ITransaction objTrans)
        {
            if (!Config.ValidaSessao()) return false;

            if (typeof(T).GetInterfaces().Contains(typeof(IValidaDelete)))
                if (!((IValidaDelete)obj).PodeExcluir())
                    return false;

            if (objTrans != null)
            {
                if (!objTrans.IsActive)
                    objTrans = Config.Conexao.Sessao.BeginTransaction();
            }
            else
                objTrans = Config.Conexao.Sessao.BeginTransaction(); 

            try
            {
                Config.Conexao.Sessao.Delete(obj);
                objTrans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                objTrans.Rollback();
                Config.Conexao.Sessao.Close();
                Config.Conexao.AbrirSessao();
                throw AssistErroException.TratarErro( ex);
            }
        }
        public bool Evict(T obj)
        {
            if (!Config.ValidaSessao()) return false;

            try
            {
                Config.Conexao.Sessao.Evict(obj);
                return true;
            }
            catch (Exception ex)
            {
                Config.Conexao.Sessao.Close();
                Config.Conexao.AbrirSessao();
                throw AssistErroException.TratarErro(ex);
            }
        }
        public virtual IList<T> Retorna()
        {
            if (!Config.ValidaSessao()) return null;

            return Config.Conexao.Sessao.Linq<T>().ToList();
        }

        public virtual IList<T> Retorna(Expression<Func<T, bool>> where)
        {
            if (!Config.ValidaSessao()) return null;

            return Config.Conexao.Sessao.Linq<T>().Where(where).ToList();
        }

        public T Retorna_pId(int id)
        {
            if (!Config.ValidaSessao()) return default(T);

            return Config.Conexao.Sessao.Linq<T>().Where(x => x.Id == id).FirstOrDefault();
        }
        public T RetornaUnico(Expression<Func<T, bool>> where)
        {
            if (!Config.ValidaSessao()) return default(T);

            return Config.Conexao.Sessao.Linq<T>().Where(where).FirstOrDefault();
        }

        #region IAcessoUtil Members

        public DateTime GetDate()
        {
            var query = Config.Conexao.Sessao.CreateSQLQuery("SELECT CONVERT(VARCHAR, GETDATE(), 111);");
            DateTime results = DateTime.Parse(query.UniqueResult().ToString());

            return results;
        }

        public int NovoCodigo<T>() where T : Entidades.Base.BaseCod
        {
            try
            {
                int codigo = Config.Conexao.Sessao.Linq<T>().Max(x => x.Codigo);
                //.SetProjection(Projections.Max(coluna));
                //int codigo = criteria.UniqueResult<int>();
                if (codigo == 0)
                    return 1;
                else
                    return codigo + 1;
            }
            catch (Exception)
            {
                Config.Conexao.Sessao.Close();
                Config.Conexao.AbrirSessao();
                return 0;
            }
        }

        public int NovoCodigo<T>(string coluna) where T : BaseCod
        {
            return NovoCodigo<T>();
        }

        public IList<T> Retorna_pFiltros(List<Filtro> filtros)
        {
            try
            {
                Type genericClass = typeof(ExpressaoDinamica<>);
                Type constructedClass = genericClass.MakeGenericType(typeof(T));
                var expressaoDinamica = Activator.CreateInstance(constructedClass);

                foreach (Filtro item in filtros)
                {
                    if (!item.Utilizado) continue;

                    Expression e1 = ((ExpressaoDinamica<T>)expressaoDinamica).Propriedade(item.Propriedade);
                    Expression e2 = null;
                    Expression e = null;
                    if (item.TipoFiltro == TipoFiltro.Texto)//IsSubclassOf(typeof(string)))
                    {
                        //e2 = ((ExpressaoDinamica<T>)expressaoDinamica).Constante(item.ValorUsado1.ToString().Trim(), item.ValorUsado1.GetType());
                        e = ((ExpressaoDinamica<T>)expressaoDinamica).Contem(item.ValorUsado1.ToString().Trim(), e1);
                    }
                    else if (item.TipoFiltro == TipoFiltro.NumInteiro)//IsSubclassOf(typeof(string)))
                    {
                        if (((FiltroNumInteiro)item).TipoProcura == TipoProcura.Exato)
                        {
                            e2 = ((ExpressaoDinamica<T>)expressaoDinamica).Constante(Convert.ChangeType(item.ValorUsado1, item.Propriedade.PropertyType), item.Propriedade.PropertyType);
                            e = Expression.Equal(e1, e2);
                        }
                        else if (((FiltroNumInteiro)item).TipoProcura == TipoProcura.Entre)
                        {
                            e2 = ((ExpressaoDinamica<T>)expressaoDinamica).MaiorIgual(e1, ((ExpressaoDinamica<T>)expressaoDinamica).Constante(Convert.ChangeType(item.ValorUsado1, item.Propriedade.PropertyType), item.Propriedade.PropertyType));
                            Expression e3 = ((ExpressaoDinamica<T>)expressaoDinamica).MenorIgual(e1, ((ExpressaoDinamica<T>)expressaoDinamica).Constante(Convert.ChangeType(((FiltroNumInteiro)item).ValorUsado2, item.Propriedade.PropertyType), item.Propriedade.PropertyType));

                            e = Expression.AndAlso(e2, e3);
                        }
                        else if (((FiltroNumInteiro)item).TipoProcura == TipoProcura.Apartir)
                        {
                            e = ((ExpressaoDinamica<T>)expressaoDinamica).MaiorIgual(e1, ((ExpressaoDinamica<T>)expressaoDinamica).Constante(Convert.ChangeType(item.ValorUsado1, item.Propriedade.PropertyType), item.Propriedade.PropertyType));
                        }
                        else if (((FiltroNumInteiro)item).TipoProcura == TipoProcura.Ate)
                        {
                            e = ((ExpressaoDinamica<T>)expressaoDinamica).MenorIgual(e1, ((ExpressaoDinamica<T>)expressaoDinamica).Constante(Convert.ChangeType(item.ValorUsado1, item.Propriedade.PropertyType), item.Propriedade.PropertyType));
                        }
                    }
                    else if (item.TipoFiltro == TipoFiltro.Data)//IsSubclassOf(typeof(string)))
                    {
                        if (((FiltroData)item).TipoProcura == TipoProcura.Exato)
                        {
                            e2 = ((ExpressaoDinamica<T>)expressaoDinamica).Constante(Convert.ChangeType(item.ValorUsado1, item.Propriedade.PropertyType), item.Propriedade.PropertyType);
                            e = Expression.Equal(e1, e2);
                        }
                        else if (((FiltroData)item).TipoProcura == TipoProcura.Entre && (item.ValorUsado1 != null && ((FiltroData)item).ValorUsado2 != null))
                        {
                            e2 = ((ExpressaoDinamica<T>)expressaoDinamica).MaiorIgual(e1, ((ExpressaoDinamica<T>)expressaoDinamica).Constante(Convert.ChangeType(item.ValorUsado1, item.Propriedade.PropertyType), item.Propriedade.PropertyType));
                            Expression e3 = ((ExpressaoDinamica<T>)expressaoDinamica).MenorIgual(e1, ((ExpressaoDinamica<T>)expressaoDinamica).Constante(Convert.ChangeType(((FiltroData)item).ValorUsado2, item.Propriedade.PropertyType), item.Propriedade.PropertyType));

                            e = Expression.AndAlso(e2, e3);
                        }
                        else if (((FiltroData)item).TipoProcura == TipoProcura.Apartir || (item.ValorUsado1 != null && ((FiltroData)item).ValorUsado2 == null))
                        {
                            e = ((ExpressaoDinamica<T>)expressaoDinamica).MaiorIgual(e1, ((ExpressaoDinamica<T>)expressaoDinamica).Constante(Convert.ChangeType(item.ValorUsado1, item.Propriedade.PropertyType), item.Propriedade.PropertyType));
                        }
                        else if (((FiltroData)item).TipoProcura == TipoProcura.Ate || (item.ValorUsado1 == null && ((FiltroData)item).ValorUsado2 != null))
                        {
                            e = ((ExpressaoDinamica<T>)expressaoDinamica).MenorIgual(e1, ((ExpressaoDinamica<T>)expressaoDinamica).Constante(Convert.ChangeType(item.ValorUsado1, item.Propriedade.PropertyType), item.Propriedade.PropertyType));
                        }
                    }
                    else if (item.TipoFiltro == TipoFiltro.Checkbox && ((byte)item.ValorUsado1 == 0 || (byte)item.ValorUsado1 == 1))
                    {
                        e2 = ((ExpressaoDinamica<T>)expressaoDinamica).Constante((byte)item.ValorUsado1 == 0?false:true, item.Propriedade.PropertyType);
                        e = Expression.Equal(e1, e2);                    
                    }
                    else
                    {
                        e2 = ((ExpressaoDinamica<T>)expressaoDinamica).Constante(item.ValorUsado1, e1.Type);// item.ValorUsado1.GetType());
                        if (IsNullableType(e1.Type) && !IsNullableType(e2.Type))
                            e2 = Expression.Convert(e2, e1.Type);
                        else if (!IsNullableType(e1.Type) && IsNullableType(e2.Type))
                            e1 = Expression.Convert(e1, e2.Type);

                        e = Expression.Equal(e1, e2);
                    }


                    ((ExpressaoDinamica<T>)expressaoDinamica).AddExpressao(e);
                }

                //MethodInfo method = typeof(TrataStaticos).GetMethod("TrazerEntidade");
                //object[] arguments = { expressaoDinamica.Montar(), acessoSistema };
                //// Build a method with the specific type argument you're interested in
                //method = method.MakeGenericMethod(Global.Entidades[dc.Tabela]);
                //// The "null" is because it's a static method
                //entBase = (EntidadeBase)method.Invoke(null, arguments);
                Expression<Func<T, bool>> expressao = ((ExpressaoDinamica<T>)expressaoDinamica).Montar();
                if (expressao == null)
                    return Retorna();
                else
                    return Retorna(expressao);
                //return new List<T>();
            }
            catch (Exception ex)
            {
                throw AssistErroException.TratarErro(ex);
            }
        }

        public bool DescricaoExiste<T>(string descricao) where T : Entidades.Base.BaseCodDescr
        {
            IList<T> entidades = Config.Conexao.Sessao.Linq<T>().Where(x => x.Descricao == descricao).ToList<T>();
            if (entidades.Count > 0)
                return true;
            else
                return false;
        }

        private static bool IsNullableType(Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
        #endregion

    }
}