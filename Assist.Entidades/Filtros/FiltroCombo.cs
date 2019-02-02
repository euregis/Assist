using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace Assistente.Entidades.Filtros
{
    public class FiltroCombo : Filtro
    {
        public bool IsEnum { get; set; }
        public bool OpcaoTodos { get; set; }
        public ArrayList Lista { get; set; }
        public Type Tipo { get; set; }

        public FiltroCombo() { }

        public FiltroCombo(PropertyInfo propriedade, string nomeExibicao, Object valorUsado1, 
            Object valorLimpo1, bool isEnum, bool opcaoTodos, ArrayList lista, Type tipo)
        {
            this.TipoFiltro = TipoFiltro.Combo;
            this.Propriedade = propriedade;
            this.NomeExibicao = nomeExibicao;
            this.ValorUsado1 = valorUsado1;
            this.ValorLimpo1 = valorLimpo1;
            this.IsEnum = isEnum;
            this.Lista = lista;
            this.OpcaoTodos = opcaoTodos;
            this.Tipo =tipo;
            if (valorUsado1 != null && valorUsado1.ToString() != "Todos")
                this.Utilizado = true;
        }
    }
}
