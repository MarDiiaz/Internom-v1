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
    public partial class Reporte_Vacacional : Form
    {

        SqlConnection c = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");

        public Reporte_Vacacional()
        {
            InitializeComponent();
        }



        private void antiguedades()
        {
            ////////////// Metodo para obtener los dias de antiguedad de cada trabajador

           
        }







        private void button6_Click(object sender, EventArgs e)
        {
            PrincipalAdmin pa = new PrincipalAdmin();
            pa.Show();
            Close();
        }

        private void Reporte_Vacacional_Load(object sender, EventArgs e)
        {

        }

        private void no_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtdiasantes_TextChanged(object sender, EventArgs e)
        {
            string dias1 = txtdiasvaca.Text;
            string dias2 = txtdiasantes.Text;

            int a = Convert.ToInt32(dias1);
            int b = Convert.ToInt32(dias2);
            int sum = a + b;
            string total = Convert.ToString(sum);
            txttotaldias.Text = total;

        }

        private void txtrestantes_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttomados_TextChanged(object sender, EventArgs e)
        {

            if (txttomados.Text=="")
            {
                
            }
            int tt = Convert.ToInt32(txttotaldias.Text);
            int tom = Convert.ToInt32(txttomados.Text);
            int rest = tt - tom;

            txtrestantes.Text = rest.ToString();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
                SqlCommand cadcon;
                con.Open();
                cadcon = new SqlCommand("Insert into permisos (descripcion,fecha_elaboracion,fecha_solicitada,id_empleado,incidencia) values ('','" + textBox1.Text + "','" + textBox2.Text + "'," + id_emple.Text + ",'Tomo Dias de Vacaciones ')", con);
                cadcon.ExecuteNonQuery();

                // MessageBox.Show(salid);
                MessageBox.Show("Vacaciones Registradas");



            }
            catch (Exception ex)
            {

                MessageBox.Show("verifica los datos " + ex.ToString());

            }

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
          textBox1.Text = dateTimePicker2.Value.ToString("dd/MM/yyyy");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
          textBox2.Text = dateTimePicker3.Value.ToString("dd/MM/yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand comando;
            comando = new SqlCommand("select fecha_ingreso,nombre,apellidos,id_empleado from empleados  where no_nomina='" + nomina.Text + "'", c);

            SqlDataReader r;
            c.Open();
            r = comando.ExecuteReader();
            if (r.Read() == true)
            {

                string fecha_ingreso = r["fecha_ingreso"].ToString();
                string id = r["id_empleado"].ToString();
                id_emple.Text = id;
                string nombre = r["nombre"].ToString();
                string apellidos = r["apellidos"].ToString();
                string nombre_completo = nombre + " " + apellidos;
                txtnombre.Text = nombre_completo;
                txtfecha_ingreso.Text = fecha_ingreso;
                // string fecha_hoy = DateTime.Now.ToLongDateString();


                string fi = Convert.ToDateTime(fecha_ingreso).ToShortDateString();

                DateTime fe_ing = Convert.ToDateTime(fi);
                DateTime fe_hoy = DateTime.Now;
                TimeSpan ts = fe_hoy - fe_ing;
                int dias = ts.Days;

                string dias_trabajados = Convert.ToString(dias);


                txtdias.Text = dias_trabajados;

                int anios = dias / 365;
                txtanios.Text = anios.ToString();
                int diasvac = 0;
                if (anios <= 0.9)
                {

                    diasvac = 0;
                }

                else if (anios >= 0.1 & anios <= 1.9)
                {
                    diasvac = 6;
                }
                else if (anios >= 2 & anios <= 2.9)
                {
                    diasvac = 8;

                }
                else if (anios >= 3 & anios <= 3.9)
                {
                    diasvac = 10;
                }
                else if (anios >= 4 & anios <= 4.9)
                {

                    diasvac = 12;

                }
                else if (anios >= 5 & anios <= 9.9)
                {
                    diasvac = 14;
                }

                else if (anios >= 10)
                {
                    diasvac = 16;
                }
                txtdiasvaca.Text = diasvac.ToString();

                c.Close();

                ///////////////////// FIN DEL METODO



            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
