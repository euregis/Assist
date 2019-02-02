using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Assistente.Entidades.Configuracoes
{
    [Serializable]
    public class Config
    {
        public string CaminhoBase = "";
        public List<string> PlugInsUtilizados = new List<string>();
        public List<string> PlugInsUtilizar = new List<string>();
        public List<string> PlugInsExcluidos = new List<string>();

        public virtual void AddPlugInUtilizado(string plugIn)
        {
            PlugInsUtilizar.Remove(plugIn);
            PlugInsExcluidos.Remove(plugIn);
            for (int i = 0; i < PlugInsUtilizados.Count; i++)
            {
                if (Path.GetFileName(PlugInsUtilizados[i]) == Path.GetFileName(plugIn))
                    return;
            }
            PlugInsUtilizados.Add(plugIn);
        }
        public virtual void AddPlugInUtilizar(string plugIn)
        {
            PlugInsExcluidos.Remove(plugIn);
            for (int i = 0; i < PlugInsUtilizar.Count; i++)
            {
                if (Path.GetFileName(PlugInsUtilizar[i]) == Path.GetFileName(plugIn))
                    return;
            }
            PlugInsUtilizar.Add(plugIn);
        }
        public virtual void AddPlugInExcluido(string plugIn)
        {
            PlugInsUtilizar.Remove(plugIn);
            PlugInsUtilizados.Remove(plugIn);
            for (int i = 0; i < PlugInsExcluidos.Count; i++)
            {
                if (Path.GetFileName(PlugInsExcluidos[i]) == Path.GetFileName(plugIn))
                    return;
            }
            PlugInsExcluidos.Add(plugIn);

        }
    }
}
