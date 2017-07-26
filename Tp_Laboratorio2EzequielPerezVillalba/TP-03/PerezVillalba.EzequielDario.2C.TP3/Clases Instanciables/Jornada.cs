using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        /// <summary>
        /// Jornada Builders
        /// </summary>
        public Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno alu in j._alumnos)
            {
                if (alu == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno alu in j._alumnos)
            {
                if (alu == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }

            j._alumnos.Add(a);

            return j;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASE DE ");
            sb.Append(this._clase);
            sb.Append(" POR ");
            sb.Append(this._instructor);
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno alu in this._alumnos)
            {
                sb.AppendLine(alu.ToString());
            }
            return sb.ToString();
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto t = new Texto();
            return t.guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", jornada.ToString());
        }

        public static string Leer()
        {
            string buffer;
            Texto t = new Texto();

            t.leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", out buffer);
            return buffer;
        }
    }
}
