using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Internom
{
    public partial class ReporteDiario : Form
    {
        SqlConnection c = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");

        public ReporteDiario()
        {
            InitializeComponent();
        }

        private void consulta()
        {
            string fecha = DateTime.Today.ToString();
            c.Open();
            SqlDataAdapter da = new SqlDataAdapter("select fecha, no_nomina, nombre ,apellidos,hora_ingreso,entrada_comida,salida_comida,hora_salida,horas_trabajadas from horarios inner join empleados on empleados.id_empleado = horarios.id_empleado where fecha='"+fecha+"'", c);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            c.Close();

        }
        private void ReporteDiario_Load(object sender, EventArgs e)
        {
            consulta();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrincipalAdmin pa = new PrincipalAdmin();
            pa.Show();
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
