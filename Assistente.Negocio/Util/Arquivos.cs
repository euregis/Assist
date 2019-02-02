using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace Assistente.Negocio.Util
{
    public static class Arquivos
    {
        public static bool CaminhoExiste(string vstrCaminho)
        {
            try
            {
                return new DirectoryInfo(vstrCaminho).Exists;
            }
            catch (Exception) { return false; }
        }
        public static bool ArquivoExiste(string vstrArquivo)
        {
            try
            {
                return new FileInfo(vstrArquivo).Exists;
            }
            catch (Exception) { return false; }
        }
        public static bool ExcluirArquivo(string caminhoArquivo)
        {
            try
            {
                if (ArquivoExiste(caminhoArquivo))
                    new FileInfo(caminhoArquivo).Delete();

                return true;
            }
            catch (Exception) { return false; }
        }
        public static bool CopiarArquivo(string caminhoArquivo, string destino, bool substituir)
        {
            try
            {
                if (ArquivoExiste(caminhoArquivo) 
                    && caminhoArquivo != Path.Combine(destino, Arquivos.CapturarNomeArquivo(caminhoArquivo)))
                {
                    if (ArquivoExiste(Path.Combine(destino, Arquivos.CapturarNomeArquivo(caminhoArquivo))) && substituir)
                        if (!ExcluirArquivo(Path.Combine(destino, Arquivos.CapturarNomeArquivo(caminhoArquivo))))
                            return false;
                    FileSystem.CopyFile(caminhoArquivo, Path.Combine(destino, new FileInfo(caminhoArquivo).Name), substituir);
                }
                return true;
            }
            catch (Exception) { return false; }
        }
        public static bool RenomearArquivo(string caminho, string novoNome)
        {
            try
            {
                if (ArquivoExiste(caminho))
                {
                    System.IO.File.Move(caminho, Path.Combine( CapturarCaminhoArquivo(caminho),  novoNome));
                    return true;
                }
                else
                    return false;
            }
            catch (Exception) { return false; }
        }
        public static bool CopiarArquivoDeixarRecente(string caminhoArquivo, string destino)
        {
            try
            {
                if (ArquivoExiste(caminhoArquivo))
                {
                    if (ArquivoExiste(Path.Combine(destino, Arquivos.CapturarNomeArquivo(caminhoArquivo))))

                        if (new FileInfo(caminhoArquivo).LastWriteTime >
                        new FileInfo(Path.Combine(destino, Arquivos.CapturarNomeArquivo(caminhoArquivo))).LastWriteTime)
                        {
                            if (!ExcluirArquivo(Path.Combine(destino, Arquivos.CapturarNomeArquivo(caminhoArquivo))))
                                return false;
                        }
                        else
                            return true;
                    FileSystem.CopyFile(caminhoArquivo, Path.Combine(destino, new FileInfo(caminhoArquivo).Name), true);
                }
                else
                    throw new FileNotFoundException("Arquivo de origem não encontrado", caminhoArquivo);
                return true;
        }
            catch (Exception) { return false; }
        }
        public static string CapturarNomeArquivo(string caminho)
        {
            return CapturarNomeArquivo(caminho, true);
        }

        public static string CapturarNomeArquivo(string caminho, bool comExtensao)
        {
            if (comExtensao)
                return Path.GetFileName(caminho);
            else
                return Path.GetFileNameWithoutExtension(caminho);
        }
        public static string CapturarCaminhoArquivo(string caminho)
        {
            if (ArquivoExiste(caminho))
                return Path.GetDirectoryName(caminho);
            else
                return "";
        }
        public static void CriarPasta(string caminho)
        {
            if (!CaminhoExiste(caminho))
                new DirectoryInfo(caminho).Create();
        }
    }
}
