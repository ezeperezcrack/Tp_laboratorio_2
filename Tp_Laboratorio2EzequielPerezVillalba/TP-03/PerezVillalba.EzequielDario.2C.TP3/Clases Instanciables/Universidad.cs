using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Xml.Serialization;


namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion = 1, Laboratorio = 2, SPD = 3, Legislacion = 4
        }

        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;

        /// <summary>
        /// Universidad Builder
        /// </summary>
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesores = new List<Profesor>();
        }

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this._profesores; }
            set { this._profesores = value; }
        }

        public Jornada this[int i]
        {
            get { return this._jornada[i]; }
            set { this._jornada[i] = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this._jornada; }
            set { this._jornada = value; }
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            return g._alumnos.Contains(a);
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            return g._profesores.Contains(i);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator ==(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item == clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }

        public static Profesor operator !=(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item != clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }



        public static Universidad operator +(Universidad u, Universidad.EClases clase)
        {
            Profesor profesor = (u == clase);
            Jornada jornada = new Jornada(clase, profesor);
            foreach (Alumno item in u.Alumnos)
            {
                if (item == clase)
                {
                    jornada = jornada + item;
                }
            }

            u.Jornadas.Add(jornada);

            return u;
        }

        public static Universidad operator +(Universidad g, Alumno a) // se considera que un alumno también puede ser profesor al mismo tiempo
        {
            if (g == a)
            {
                throw new AlumnoRepetidoException();
            }
            g.Alumnos.Add(a);
            return g;
        }

        public static Universidad operator +(Universidad g, Profesor i)  // se considera que un profesor también puede ser alumno al mismo tiempo
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }

            return g;
        }

        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");

            foreach (Jornada jor in gim._jornada)
            {
                sb.Append(jor.ToString());
                sb.AppendLine("<------------------------------------------------>\n");
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", gim);
        }

        public static bool Leer(out Universidad gim)
        {
            bool ret = false;
            Xml<Universidad> xml = new Xml<Universidad>();
            ret = xml.leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", out gim);

            return ret;
        }




    }
}
