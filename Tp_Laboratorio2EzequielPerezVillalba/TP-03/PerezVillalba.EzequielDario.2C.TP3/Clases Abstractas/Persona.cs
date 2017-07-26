using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public class Persona
    {
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = this.ValidarNombreApellido(value); }
        }
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad= value; }
        }

        public int DNI
        {
            get { return this._dni; }
            set
            {
                    if (((int)this.Nacionalidad) != -1)   
                    this._dni = this.ValidarDNI(this.Nacionalidad, value);
            }
        }

        public string Nombre
        {
            get { return this._nombre; }

            set { this._nombre = this.ValidarNombreApellido(value); }
        }

        public string StringToDNI
        {
            set { this._dni = this.ValidarDNI(this.Nacionalidad, value); }
        }

        /// <summary>
        /// Persona Builders
        /// </summary>
        public Persona()
        {
            this._nacionalidad = (ENacionalidad)(-1);
            this._dni = -1;
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        
        /// <summary>
        /// Sobreescritura del metodo ToString en Persona
        /// </summary>
        /// <returns>Devuelve una cadena con los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this._apellido + ", " + this._nombre);
            sb.AppendLine("NACIONALIDAD: " + this._nacionalidad.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Metodo que valida el número de dni
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Devuelve el dni validado o una excepción</returns>
        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && (dato < 1 || dato > 89999999))
            {
                throw new DniInvalidoException();
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato < 90000000)
            {
                throw new NacionalidadInvalidaException(); // debería ser DniInvalidoException() ?
            }

            return dato;
        }

        /// <summary>
        /// Metodo que valida la cadena que contiene al número de dni
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Devuelve un dni int validado o una excepción</returns>
        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            dato = dato.Replace(" ", "");
            dato = dato.Replace(".", "");
            dato = dato.Replace("-", "");
            dato = dato.Replace(",", "");
            dato = dato.Replace("\t", "");

            if (dato.Length > 9 || !int.TryParse(dato, out dni))
            {
                throw new DniInvalidoException();
            }

            return ValidarDNI(nacionalidad, dni);
        }

        /// <summary>
        /// Metodo que valida la cadena que contiene al nombre o apellido
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Devuelve el nombre o apellido validado o null</returns>
        private string ValidarNombreApellido(string dato)
        {
            string result=null;
            if (dato != null)
            {
                Match match = Regex.Match(dato, @"^[\u00e1\u00e9\u00ed\u00f3\u00fa\u0301\u00c1\u00c9\u00cd\u00d3\u00dañÑA-Za-z]+$", RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    result = dato;
                }
            }
            return result;
        }
    }
}
