using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Internom
{
    public partial class INTERNOM : Form
    {
        public INTERNOM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal pa = new Principal();
            pa.Show();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Entrada_Salida es = new Entrada_Salida();
            es.Show();
          
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Administrador m = new Administrador();
            m.Show();
        }

        private void INTERNOM_Load(object sender, EventArgs e)
        {

        }
    }
}
