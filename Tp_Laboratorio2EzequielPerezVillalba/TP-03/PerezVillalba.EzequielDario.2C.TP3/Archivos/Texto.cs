using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// implementacion del metodo guardar de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna true si guardó los datos o una excepcion si no</returns>
        public bool guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo);
                sw.Write(datos.ToString());
                sw.Close();
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
        public bool leer(string archivo, out string datos)
        {
            try
            {
                StreamReader sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
