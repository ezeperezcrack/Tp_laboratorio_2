using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;
        public Texto(string archivo)
        {
            this._archivo = archivo;
        }

        public bool guardar(string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + this._archivo, true);
                sw.WriteLine(datos.ToString());
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al guardar: " + this._archivo + e.Message, "Error al intentar guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        public bool leer(out List<string> datos)
        {
            datos = new List<string>();

            try
            {
                StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + this._archivo);
                while (!sr.EndOfStream)
                {
                    datos.Add(sr.ReadLine());
                }
                sr.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al leer: " + this._archivo + e.Message, "Error al intentar leer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

    }
}
