using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;
using System.Windows.Forms;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;
        public delegate void DescargaCompleta(string salida);
        public delegate void ProgresoDeDescarga(int avance);
        public event DescargaCompleta dc;
        public event ProgresoDeDescarga pdd;


        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;
                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.pdd(e.ProgressPercentage);
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.html = e.Result;
                this.dc(this.html);
            }
            catch (Exception ex)
            {
                this.dc("Error: " + ex.InnerException.Message);
            }
        }
    }
}
