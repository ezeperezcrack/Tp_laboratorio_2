using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    static class Program
    {
        public static frmWebBrowser fwb;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            fwb = new frmWebBrowser();
            Application.Run(fwb);
        }
    }
}
