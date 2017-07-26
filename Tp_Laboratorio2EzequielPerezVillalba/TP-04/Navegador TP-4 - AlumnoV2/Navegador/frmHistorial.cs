using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";
        public List<string> historial;

        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            lstHistorial.DoubleClick += lstHistorial_DoubleClick;
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
            if (archivos.leer(out historial))
            {
                foreach (string datos in historial)
                {
                    this.lstHistorial.Items.Add(datos);
                }
            }
        }

        private void lstHistorial_DoubleClick(object sender, EventArgs e)
        {
            Program.fwb.IrA(this.lstHistorial.SelectedItem.ToString());
        }


    }
}
