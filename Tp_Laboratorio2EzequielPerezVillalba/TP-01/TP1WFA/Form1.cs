using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tp1_Calculadora;

namespace TP1WFA
{
    public partial class Form1 : Form
    {
        string aux1;
        string aux2;
        string operador;
        double resultado;
        Numero numero1 = new Numero();
        Numero numero2 = new Numero();

        public Form1()
        {
            InitializeComponent();
            this.textNumero2.Text = numero1.numero.ToString();
            this.textNumero1.Text = numero2.numero.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CC();
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            Numero operando1 = new Numero(aux1);
            Numero operando2 = new Numero(aux2);
            resultado = Calculadora.operar(operando1, operando2, operador);
            Numero resultadoFinal = new Numero(resultado);
            this.lblResultado.Text = resultadoFinal.numero.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            operador = Calculadora.validarOperador(this.cmbOperacion.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            aux2 = this.textNumero2.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            aux1 = this.textNumero1.Text;
        }

        public void CC()
        {
            this.lblResultado.Text = "0";
            this.textNumero2.Text = numero1.numero.ToString();
            this.textNumero1.Text = numero2.numero.ToString();
        }

        
    }
}
