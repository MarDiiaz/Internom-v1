using System;
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

            string fecha_vigencia = "01/07/2018";
            DateTime fe_ing = Convert.ToDateTime(fecha_vigencia);
            DateTime fe_hoy = DateTime.Now;
            TimeSpan ts = fe_ing - fe_hoy;
            int dias = ts.Days;

            // si los dias que le quedan al sistema de vigencia son menores que 10 en el panel de administrador (cada que ingrese)
            // Se mostrara una etiqueta de advertencia con los dias que le quedan al sistema
            // Una vez que los dias finalicen , el sistema quedara "Inaccesible" se mostrara un Forms donde 
            // Se notificara que ha expirado y los datos del proveedor en caso de que se dese contratar de nuevo
            // El plazo se podra manejar por 6 meses como minimo 
            if (dias<10)
            {
                label2.Text = "ADVERTENCIA";
              label1.Text="Tu sistema expira en: "+ dias + " dias";
            }
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Consultas co = new Consultas();
           co.Show();
           Close();
        }

        private void altaEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void catalogoEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void horariosEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           calculo_primavacacional tu = new calculo_primavacacional();
            tu.Show();
            Close();
        }

        private void generadorQRToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void credencialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void generadorQrToolStripMenuItem1_Click(object sender, EventArgs e)
        {

           
        }

        private void registroEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Alta_Empleado ae = new Alta_Empleado();
            ae.Show();
            Close();
        }

        private void catalogoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogo_empleados cq = new Catalogo_empleados();
            cq.Show();
            Close();
        }

        private void credencialesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void nuevaCredencialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Credenciales cr = new Credenciales();
            cr.Show();
            Close();
        }

        private void generadorCodigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneradorQR qr = new GeneradorQR();
            qr.Show();
            Close();
        }

        private void registroVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vehiculos v = new Vehiculos();
            v.Show();
            Close();
        }

        private void catalogoVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formatoInvUnidadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formatoInvUnidadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Rendimiento_Unidades ru = new Rendimiento_Unidades();
            ru.Show();
            Close();
        }

        private void primaVacacionalaguinaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calculo_primavacacional cp = new calculo_primavacacional();
            cp.Show();
            Close();
        }
    }
}
