using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1_Calculadora
{
    public class Numero
    {
        public double numero;

        public Numero() { }
        public Numero(string numero)
        {
            setNumero(numero);
        }
        public Numero(double n)
        {
            this.numero = n;
        }


        private double validarNumero(string num)
        {
            double ret;
            double.TryParse(num, out ret);
            return ret;
        }
        private void setNumero(string numero)
        {
            this.numero = validarNumero(numero);
        }

    }
}
