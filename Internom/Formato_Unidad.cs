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
    public partial class Formato_Unidad : Form
    {
        public Formato_Unidad()
        {
            InitializeComponent();
        }
        

        private void Formato_Unidad_Load(object sender, EventArgs e)
        {
            //carga las rutas 
            conexion c = new conexion();
            c.catalogorutas(comboruta);
            c.catalogounidades(comboeco);
            //obtiene la fecha de hoy 
            string fecha = DateTime.Now.ToShortDateString();
            textBox23.Text = fecha;
            // obtiene la hora actuual 
            string hora = DateTime.Now.ToShortTimeString();
            textBox13.Text = hora;
            textBox24.Focus();
        }

        
        private void comboruta_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_ruta.Text = comboruta.ValueMember.ToString();
        }

        private void comboeco_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
            string cadcon = "Select marca, modelo,placas,id_unidad from unidades where eco='"+comboeco.Text+"'";
            //id_dpto.Text=(comboBox1.SelectedValue.ToString());
            SqlCommand cm = new SqlCommand(cadcon, con);
            con.Open();
            SqlDataReader leer = cm.ExecuteReader();

            if (leer.Read() == true)
            {
                textBox15.Text = leer["marca"].ToString();
                textBox27.Text = leer["modelo"].ToString();
                textBox34.Text = leer["placas"].ToString();
                id_eco.Text = leer["id_unidad"].ToString();             
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox23.Text == "" | textBox13.Text == "" | comboruta.Text == "" | textBox24.Text == "" | comboeco.Text == "" | textBox21.Text == "" | textBox40.Text == "")
            {
                MessageBox.Show("Faltan Datos");
            }
            else
            {
                try
                {

                    SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
                    SqlCommand cadcon;
                    con.Open();
                    cadcon = new SqlCommand("Insert into rendimientos (fecha_salida,fecha_retorno,dias_transcurridos,id_catalogoruta,responsable,km_salida,km_llegada,km_recorridos,id_unidad,combustible_s,combustible_r) values ('" + textBox23.Text + "','  ','0','" + id_ruta.Text + "','" + textBox24.Text + "'," + textBox21.Text + ",'0','0','" + id_eco.Text + "','" + textBox40.Text + "','0')", con);
                    cadcon.ExecuteNonQuery();

                    // MessageBox.Show(salida);
                    MessageBox.Show("Registro Correcto");
                    textBox23.Text = "";
                    textBox13.Text = "";
                    textBox24.Text = "";
                    textBox15.Text = "";
                    textBox27.Text = "";
                    textBox34.Text = "";
                    textBox21.Text = "";
                    textBox40.Text = "";
                    comboruta.Text="";
                    comboeco.Text="";
                    id_eco.Text = "";
                    id_ruta.Text = "";
                }
                catch (Exception ex)
                {

                    MessageBox.Show("verifica los datos " + ex.ToString());
                    Formato_Unidad_Load(this, new EventArgs()); 
                }

            }
        }

      

        private void button6_Click(object sender, EventArgs e)
        {
            INTERNOM inte = new INTERNOM();
            inte.Show();
            Close();
        }
    }
}
