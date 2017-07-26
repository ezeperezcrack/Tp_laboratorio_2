using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Metodo de guardado de la interfaz
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool guardar(string archivo, T datos);

        /// <summary>
        /// Metodo de lectura de la interfaz
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool leer(string archivo, out T datos);
    }
}
