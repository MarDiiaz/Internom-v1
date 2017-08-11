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
    public partial class Administrador : Form
    {
       

        public Administrador()
        {
            InitializeComponent();
        }

        private void LoginAdmin_Load(object sender, EventArgs e)
        {
            conexion c = new conexion();
            c.catalogous(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        //evento al dar click en login

        private void button1_Click(object sender, EventArgs e)
        {

            //si el campo usuario esta vacio entonces lanza un mensaje 
            if (string.IsNullOrEmpty(comboBox1.Text))
            {

                MessageBox.Show("Ingresa el usuario");

                return;

            }
            // si el campo contraseña esta vacio y el del usuario lleno  lanza un mensaje 
            else if (string.IsNullOrEmpty(contraseña.Text))
            {


                MessageBox.Show("Ingresa la contraseña");

            }
            // si el campo usuario y contraseña se encuentran llenos 
            //con los datos correctos entonces dara acceso al panel del administrador
           

            SqlConnection c = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");
            SqlCommand comando;
            comando = new SqlCommand("select * from usuarios where nombre='" + comboBox1.Text + "' and contraseña ='"+contraseña.Text+"'", c);

            SqlDataReader r;
            c.Open();
            r = comando.ExecuteReader();
            string hora = DateTime.Now.ToShortTimeString();
           
            string fecha = DateTime.Today.ToShortDateString();
            if (r.Read() == true)
            {
                txtid.Text = r["id_usuario"].ToString();
                SqlConnection cone = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");
               
                SqlCommand ins = new SqlCommand("Insert into accesos values('"+txtid.Text+"','"+fecha+"','"+hora+"')",cone);
                SqlDataReader rea;
                cone.Open();
                rea = ins.ExecuteReader();
                PrincipalAdmin pa = new PrincipalAdmin();
                pa.Show();
                Close();
            }
            
           

            // en caso contrario lanza un msj 
            else
            {

                MessageBox.Show("Datos incorrectos");
            }
           
        }

        
            
       

        private void button2_Click_2(object sender, EventArgs e)
        {
           
            Close();

        }
    }
}
