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
  
    public partial class Catalogo_empleados : Form
    {
       SqlConnection c = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");
        
       
        public Catalogo_empleados()
        {
            InitializeComponent();
        }

        private void consulta()

        {
            c.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select nombre,apellidos,telefono,seguro,no_nomina,cargo,fecha_nacimiento from empleados",c);

            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
          
            c.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }            

        private void Catalogo_empleados_Load(object sender, EventArgs e)
        {
            consulta();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrincipalAdmin pa = new PrincipalAdmin();
            pa.Show();
            Close();
        }

        private void consulta_nombre()

        {
            c.Open();           
            SqlCommand comand;
           // SELECT(LastName + ', ' + FirstName) AS Name
            comand = new SqlCommand("select (nombre +',' + apellidos) AS completo from empleados where no_nomina='" + nomina.Text + "'", c);
            SqlDataReader dread;
            dread = comand.ExecuteReader();
            if (dread.Read() == true)
            {
               nombre.Text = dread["completo"].ToString();
               
            }
                    c.Close();


        }

        private void eliminar_empleado()

        {
            c.Open();
            SqlCommand com;
            com = new SqlCommand("delete from empleados where no_nomina='"+nomina.Text+"'", c);
            SqlDataReader read;
            read = com.ExecuteReader();
            
                MessageBox.Show("Empleado elimindado");
            c.Close();
            consulta();

        }
        private void eliminar_Click(object sender, EventArgs e)
        {
            eliminar_empleado();
        }

        private void nomina_TextChanged(object sender, EventArgs e)
        {
            consulta_nombre();
        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
