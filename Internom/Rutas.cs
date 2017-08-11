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
    public partial class Rutas : Form
    {
        public Rutas()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Rutas_Load(object sender, EventArgs e)
        {
            conexion c = new conexion();
            c.catalogorutas(comboBox1);
        }
    }
}
