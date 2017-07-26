using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;
        /// <summary>
        /// Universitario Builders
        /// </summary>
        public Universitario() : base()
        { }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) :base(nombre,apellido,dni,nacionalidad)
        {
            this._legajo = legajo;
        }

        /// <summary>
        /// Metodo abstracto de Universitario
        /// </summary>
        /// <returns>Devuelve una cadena</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Metodo virtual de universitario
        /// </summary>
        /// <returns>Devuelve una cadena con los datos del Universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NÚMERO: " + this._legajo.ToString());
            return sb.ToString();
        }
    }
}
