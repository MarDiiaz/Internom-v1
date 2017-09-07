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
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteDiario rd = new  ReporteDiario();
            rd.Show();
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrincipalAdmin pa = new PrincipalAdmin();
            pa.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
           Reporte_Visitantes rv = new Reporte_Visitantes();
            rv.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reporte_Vacacional rva = new Reporte_Vacacional();
            rva.Show();
            Close();
        }

        private void Consultas_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reporte_permisos rp = new Reporte_permisos();
            rp.Show();
            Close();
        }
    }
}
