using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Internom
{
    public partial class Rendimiento_Unidades : Form
    {
        SqlConnection c = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");

        public Rendimiento_Unidades()
        {
            InitializeComponent();
        }


        private void consulta()
        {
            string fecha = DateTime.Today.ToString();
            c.Open();
            SqlDataAdapter da = new SqlDataAdapter("select fecha_salida,fecha_retorno,dias_transcurridos,catalogorutas.nombre,responsable,km_salida,km_llegada,km_recorridos,rendimientos.id_unidad,eco,combustible_s,combustible_r from rendimientos inner join catalogorutas on catalogorutas.id_catalogoruta = rendimientos.id_catalogoruta  inner join unidades on unidades.id_unidad = rendimientos.id_unidad where eco='"+textBox1.Text+"'", c); 
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            c.Close();

        }

        private void Rendimiento_Unidades_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            consulta();
        }
    }
}
