using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Internom
{
    public partial class Registro_salida : Form
    {        
        SqlConnection cn;      
        SqlCommand cmd;
        SqlDataReader dr;
        public Registro_salida()
        {
            InitializeComponent();
        }



        public void llenarcombo(ComboBox cb)
        {
            try
            {
                cn = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");
                cn.Open();
                string fecha =DateTime.Today.ToString();

                cmd = new SqlCommand("Select id_visitante,nombre from visitantes where fecha='"+fecha+"' and hora_salida='0:00'", cn);
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


        private void Registro_salida_Load(object sender, EventArgs e)
        {
           
            llenarcombo(comboBox1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string hora = DateTime.Now.ToShortTimeString();
            string message = "Hora Salida: " + hora;
            


            if ( comboBox1.Text == "" )
            {
                MessageBox.Show("Selecciona tu nombre");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
                SqlCommand cadcon;
                con.Open();
                cadcon = new SqlCommand("update visitantes set hora_salida = '"+hora+"' where id_visitante= '"+txtid.Text+"'", con);
                cadcon.ExecuteNonQuery();

                MessageBox.Show( "Hasta Pronto", message);
                txtid.Text = "";
                Close();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToLongTimeString();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // obtiene el id del empleado elegido en el combobox
            SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
            string cadcon = "Select id_visitante From visitantes where nombre ='" + comboBox1.Text + "'";
            //id_dpto.Text=(comboBox1.SelectedValue.ToString());
            SqlCommand cm = new SqlCommand(cadcon, con);
            con.Open();
            SqlDataReader leer = cm.ExecuteReader();

            if (leer.Read() == true)
            {
                txtid.Text = leer["id_visitante"].ToString();
            }
        }
    }
}
