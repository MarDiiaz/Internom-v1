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
    public partial class PrincipalAdmin : Form
    {
        public PrincipalAdmin()
        {
            InitializeComponent();
        }

        private void PrincipalAdmin_Load(object sender, EventArgs e)
        {

        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Consultas co = new Consultas();
           co.Show();
           Close();
        }

        private void altaEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alta_Empleado ae = new Alta_Empleado();
            ae.Show();
            Close();
        }

        private void catalogoEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogo_empleados cq = new Catalogo_empleados();
            cq.Show();
            Close();
        }

        private void horariosEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Turnos tu = new Turnos();
            tu.Show();
            Close();
        }

        private void generadorQRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneradorQR qr = new GeneradorQR();
            qr.Show();
            Close();
        }

        private void credencialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Credenciales cr = new Credenciales();
            cr.Show();
            Close();
        }
    }
}
