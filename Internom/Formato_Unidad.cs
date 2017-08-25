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
    public partial class Formato_Unidad : Form
    {
        public Formato_Unidad()
        {
            InitializeComponent();
        }

        private void textBox44_TextChanged(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

           
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {

        }

        private void Formato_Unidad_Load(object sender, EventArgs e)
        {
            conexion c = new conexion();
            c.catalogorutas(comboruta);
        }
    }
}
