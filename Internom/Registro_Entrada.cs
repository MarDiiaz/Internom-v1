using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Internom
{
    public partial class Registro_Entrada : Form
    {
        SqlConnection cn;
        // permite realizar sentencias sql 
        SqlCommand cmd;
        SqlDataReader dr;


        
        public Registro_Entrada()
        {
            InitializeComponent();
        }

        public void llenarcombo(ComboBox cb)
        {
            try
            {
                cn = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");
                cn.Open();
                cmd = new SqlCommand("Select nombre from empleadovis ", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cb.Items.Add(dr["nombre"].ToString());
                    
                }
                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("no se lleno el cb " + ex.ToString());
            }

        }



        private void Registro_Visitas_Load(object sender, EventArgs e)
        {
            llenarcombo(comboBox1);

        }

       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // obtiene el nombre del departamento al que pertenece el empleado visitado elegido en el combobox
            SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
            string cadcon = "Select nombre_dpto  From empleadovis inner join departamentos on empleadovis.id_departamento=departamentos.id_departamento where empleadovis.nombre='" + comboBox1.Text + "'";
            //id_dpto.Text=(comboBox1.SelectedValue.ToString());
            SqlCommand cm = new SqlCommand(cadcon, con);
            con.Open();
            SqlDataReader leer = cm.ExecuteReader();

            if (leer.Read() == true)
            {
                textBox3.Text = leer["nombre_dpto"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string hora = DateTime.Now.ToShortTimeString();
            string message = "Hora Entrada: " + hora;
            string fecha = monthCalendar1.TodayDate.ToString();


            if (txtnombre.Text == "" | txtcompa.Text == "" | comboBox1.Text == "" | textBox3.Text == "")
            {
                MessageBox.Show("INGRESA TODOS LOS CAMPOS");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
                SqlCommand cadcon;
                con.Open();
                cadcon = new SqlCommand("Insert into visitantes (fecha,nombre,compañia,persona_visitada,departamento,hora_entrada,hora_salida) values ('" + fecha + "','" + txtnombre.Text + "','" + txtcompa.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + hora + "','0:00')", con);
                cadcon.ExecuteNonQuery();

                MessageBox.Show( "BIENVENIDO", message);


                txtnombre.Text = "";
                txtcompa.Text = "";
                comboBox1.Text= "";
                textBox3.Text = "";
                txtnombre.Focus();
                Close();
            }



        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
