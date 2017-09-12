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
    public partial class Vehiculos : Form
    {
        public Vehiculos()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
           //verifica que todos los campos se hallan llenado 

            if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "" | textBox5.Text == "" | textBox6.Text == "" | textBox7.Text == "")

            {
                MessageBox.Show("INGRESA TODOS LOS CAMPOS");
            }

            else

            {/// revizar conversion 


                SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
                SqlCommand cadcon;
                con.Open();
                cadcon = new SqlCommand("Insert into unidades (marca,modelo,numero,placas,capacidad,verificacion,no_circula) values ('" + textBox3.Text + "','"+textBox4.Text+"','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','"+ textBox7.Text+"')", con);
                cadcon.ExecuteNonQuery();
                MessageBox.Show("Registro Correcto");

                //limpia todos los campos 
                textBox1.Text = "";
                textBox1.Focus();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrincipalAdmin pa = new PrincipalAdmin();
            pa.Show();
            Close();
        }

        private void Vehiculos_Load(object sender, EventArgs e)
        {

        }
    }
}
