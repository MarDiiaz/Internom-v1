using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Internom
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string fecha_hoy = DateTime.Now.ToShortDateString();
            string fecha_vigencia = "01/07/2018";

            if (fecha_hoy == fecha_vigencia)
            {              
                Application.Run(new Vigencia_SW());
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new INTERNOM());
            }
        }
    }
}
