using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor:Universitario
    {
        private static Random _random;
        private Queue<Universidad.EClases> _clasesDelDia;

        /// <summary>
        /// Profesor Builders
        /// </summary>
        public Profesor() : base()
        {
            if (this._clasesDelDia == null)
                this._clasesDelDia = new Queue<Universidad.EClases>();
        }
        
        static Profesor()
        {
            _random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i._clasesDelDia.Contains(clase);
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
                this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(1, 5)); // hardwired in this case :p
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DÍA:");
            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine(); // usado así en vez de "\n" ya que guardar a disco no toma los retornos, y si los AppendLine()

            return sb.ToString();
        }

        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + "\n" + this.ParticiparEnClase();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }

    }
}
