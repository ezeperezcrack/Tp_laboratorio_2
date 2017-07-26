using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> :IArchivo<T>
    {
        /// <summary>
        /// implementacion del metodo guardar de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna true si guardó los datos o una excepcion si no</returns>
        public bool guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                Stream stream = new FileStream(archivo, FileMode.Create);
                xml.Serialize(stream, datos);
                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// implementacion del metodo leer de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna true si leyó los datos o una excepcion si no</returns>
        public bool leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                StreamReader reader = new StreamReader(archivo);
                datos = (T)xml.Deserialize(reader);
                reader.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
