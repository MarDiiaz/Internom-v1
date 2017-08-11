using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Internom
{        
    public partial class Reporte_Visitantes : Form
    {
        SqlConnection c = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");

        public Reporte_Visitantes()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrincipalAdmin pa = new PrincipalAdmin();
            pa.Show();
            Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            PrincipalAdmin pa = new PrincipalAdmin();
            pa.Show();
            Close();
        }

        private void Reporte_Visitantes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'internomDataSet.visitantes' Puede moverla o quitarla según sea necesario.
           // this.visitantesTableAdapter.Fill(this.internomDataSet.visitantes);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           txtfecha1.Text = dateTimePicker1.Value.ToString("yyy/MM/dd");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           txtfecha2.Text = dateTimePicker1.Value.ToString("yyy/MM/dd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Open();
            string fecha = DateTime.Today.ToString();

            SqlDataAdapter da = new SqlDataAdapter("select  nombre,compañia,persona_visitada,departamento,hora_entrada,hora_salida from visitantes where fecha BETWEEN '" + txtfecha1.Text + "' AND '" + txtfecha2.Text + "'", c);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            c.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
