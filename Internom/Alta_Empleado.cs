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
    public partial class Alta_Empleado : Form
    {
        SqlConnection cone = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");

        conexion c = new conexion();

        public Alta_Empleado()
        {
            InitializeComponent();
        }        
            private void Alta_Empleado_Load(object sender, EventArgs e)
        {
            //Creamos la conexion y mandamos llamar el metodo para obtener los dpto y llenar el combobox
            conexion c = new conexion();
            c.llenarcombo(comboBox1);
            //c.llenarcombo(TextBox1);        
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            //NAVEGACION ENTRE FORMS
            PrincipalAdmin pa = new PrincipalAdmin();
            pa.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            if (txtnombre.Text == "" | txtapellidos.Text == "" | txtcargo.Text == "" | txttelefono.Text == "" | txtseguro.Text == "" | txtnomina.Text == "" | txtnac.Text=="")

            {
                MessageBox.Show("INGRESA TODOS LOS CAMPOS");
            }

            else

            {/// revizar conversion 
                               
                c.insertar(txtnombre.Text, txtapellidos.Text, txttelefono.Text, txtseguro.Text, txtfechaingreso.Text, (Convert.ToInt32(id_dpto.Text)),txtnomina.Text, txtcargo.Text,txtnac.Text);
                //  MessageBox.Show(c.insertar(txtnombre.Text, txtapellidos.Text, txttelefono.Text, txtseguro.Text, txtfechaingreso.Text, (Convert.ToInt32(id_dpto.Text)), txtnomina.Text,txtcargo.Text));
                MessageBox.Show("Registro Correcto");
                //Limpia el formulario de registro
                txtnombre.Text = "";
                txtnombre.Focus();
                txtapellidos.Text = "";
                txttelefono.Text = "";
                txtseguro.Text = "";
                txtnomina.Text = "";
                txtcargo.Text = "";
                txtfechaingreso.Text = "";
                comboBox1.Text = "";
                txtnac.Text = "";

               
            }
        }

       

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtfechaingreso.Text = dateTimePicker1.Value.ToString("dd/MM/yyyy");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // obtiene el id del dpto elegido en el combobox
            SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
            string cadcon = "Select id_departamento From departamentos where nombre_dpto ='" + comboBox1.Text + "'"; 
            //id_dpto.Text=(comboBox1.SelectedValue.ToString());
            SqlCommand cm = new SqlCommand(cadcon, con);
            con.Open();
            SqlDataReader leer = cm.ExecuteReader();
          
            if (leer.Read()==true)
            {
                id_dpto.Text = leer["id_departamento"].ToString();
            }

        }

      
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtnac.Text = dateTimePicker2.Value.ToString("dd/MM/yyyy");
        }

        private void txtnomina_TextChanged(object sender, EventArgs e)
        {
           ///////////////cambiar el metodo de lugar 
           //     cone.Open();
           //     string cadcon = "select count (*) from empleados where no_nomina="+txtnomina.Text+"";
           //     SqlCommand cm = new SqlCommand(cadcon, cone);
            
            
           // int n=Convert.ToInt32(cm.ExecuteScalar());
           // int a = n;


           // cone.Close();
           // if (a == 1)
           // {
           //     MessageBox.Show("Numero de Nomina YA REGISTRADO");

           // }            



        }

        private void txtnac_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
