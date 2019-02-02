using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assistente.Entidades.Atributos
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MapAttribute : Attribute
    {
        public string Titulo { get; set; }
        public short Tamanho { get; set; }
        public byte Precisao { get; set; }
        public bool Obrigatorio { get; set; }
        public string Descricao { get; set; }

        public MapAttribute(string titulo, short tamanho)
            : this(titulo, tamanho, 0) { }
        public MapAttribute(string titulo, short tamanho, byte precisao)
            : this(titulo, tamanho, 0, false) { }
        public MapAttribute(string titulo, short tamanho, byte precisao, bool obrigatorio)
            : this(titulo, tamanho, 0, false, "") { }
 
        public MapAttribute(string titulo, short tamanho, byte precisao, bool obrig, string descr)
        {
            this.Titulo = titulo;
            this.Tamanho = tamanho;
            this.Precisao = precisao;
            this.Obrigatorio = obrig;
            this.Descricao = descr;
        }
    }
}
