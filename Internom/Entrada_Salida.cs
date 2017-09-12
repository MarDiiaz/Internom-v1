using System;
using System.Windows.Forms;

namespace Internom
{
    public partial class Entrada_Salida : Form
    {
        public Entrada_Salida()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registro_Entrada re = new Registro_Entrada();
            re.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registro_salida rs = new Registro_salida();
            rs.Show();
            Close();

        }

        private void Entrada_Salida_Load(object sender, EventArgs e)
        {

        }

    }
}
