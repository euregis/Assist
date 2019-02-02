using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assistente.Negocio.Util
{
    public static class Serializacao
    {
        /// <summary>
        /// Serializa um objeto para binario e salva com a extenção BIN.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="caminho"></param>
        public static void Serializa(object obj, string caminho)
        {
            Serializa(obj, caminho, false);
        }
        /// <summary>
        /// Serializa um objeto para binario e salva com a extenção BIN.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="caminho"></param>
        public static void SerializaXml(object obj, string caminho)
        {
            Serializa(obj, caminho, true);
        }
        /// <summary>
        /// Serializa um objeto para binario e salva com a extenção BIN.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="caminho"></param>
        public static void Serializa(object obj, string caminho, bool xml)
        {
            try
            {
                FileStream arquivo = new FileStream(caminho, FileMode.Create);
                if (xml)
                {
                    XmlSerializer ser = new XmlSerializer(obj.GetType());
                    ser.Serialize(arquivo, obj);
                }
                else
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(arquivo, obj);
                }
                arquivo.Close();
            }
            catch
            {
                throw;
            }
        }
        public static T Deserializa<T>(string caminho, bool xml)
        {
            try
            {
                T entityRet;
                FileStream arquivo = new FileStream(caminho, FileMode.Open);
                if (xml)
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    entityRet = (T)ser.Deserialize(arquivo);
                }
                else
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    entityRet = (T)bf.Deserialize(arquivo);
                }
                arquivo.Close();
                return entityRet;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Deserializa um objeto binario
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="caminho"></param>
        /// <returns></returns>
        public static T Deserializa<T>(string caminho)
        {
            return Deserializa<T>(caminho, false);
        }

        /// <summary>
        /// Deserializa um objeto binario
        /// </summary>
        /// <param name="caminho"></param>
        /// <returns></returns>
        public static object Deserializa(string caminho)
        {
            return Deserializa<object>(caminho);
        }

        /// <summary>
        /// Deserializa um objeto XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="caminho"></param>
        /// <returns></returns>
        public static T DeserializaXml<T>(string caminho)
        {
            return Deserializa<T>(caminho, true);
        }

        /// <summary>
        /// Deserializa um objeto XML
        /// </summary>
        /// <param name="caminho"></param>
        /// <returns></returns>
        public static object DeserializaXml(string caminho)
        {
            return Deserializa<object>(caminho, true);
        }
    }
}
