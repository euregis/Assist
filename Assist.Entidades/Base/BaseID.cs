using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assistente.Entidades.Atributos;

namespace Assistente.Entidades.Base
{
    [Serializable]
    public class BaseID : IEntidade
    {
        public BaseID() { }
        //[Map("Id", 15)]
        [NonSerialized]
        private int _Id;

        public virtual int Id
        {
            get { return _Id; }
            private set { _Id = value; }
        }
    }
}
