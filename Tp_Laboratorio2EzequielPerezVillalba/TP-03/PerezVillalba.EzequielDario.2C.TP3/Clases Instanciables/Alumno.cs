using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;


namespace Clases_Instanciables
{
    public sealed class Alumno: Universitario
    {
        public enum EEstadoCuenta
        {
            Becado, Deudor, AlDia
        }
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        /// <summary>
        /// Alumno Builders
        /// </summary>
        public Alumno():base()
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return ( a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor);
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a._claseQueToma == clase);
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE: " + _claseQueToma.ToString();
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }


    }
}
