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
    public partial class calculo_primavacacional : Form
    {
        SqlConnection c = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");

        public calculo_primavacacional()
        {
            InitializeComponent();
        }

        private void Turnos_Load(object sender, EventArgs e)
        {

        }

      
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Today.ToString();
            c.Open();
            string cadcon = "Select empleados.id_empleado,nombre,apellidos,fecha_ingreso, salario_diario From empleados  inner join salarios on empleados.id_empleado=salarios.id_empleado where no_nomina ='" + no.Text + "'";
            //id_dpto.Text=(comboBox1.SelectedValue.ToString());
            SqlCommand cm = new SqlCommand(cadcon, c);
          
            SqlDataReader leer = cm.ExecuteReader();

            if (leer.Read() == true)
            {
                string nombre = leer["nombre"].ToString();
                string apellidos = leer["apellidos"].ToString();
                string fecha_in = leer["fecha_ingreso"].ToString();
                string salario = leer["salario_diario"].ToString();
                txtnombre.Text = nombre + " " + apellidos;
                txtsalario.Text = salario;


                ///////



                string fi = Convert.ToDateTime(fecha_in).ToShortDateString();

                DateTime fe_ing = Convert.ToDateTime(fi);
                DateTime fe_hoy = DateTime.Now;
                TimeSpan ts = fe_hoy - fe_ing;
                int dias = ts.Days;
                string dias_trabajados = Convert.ToString(dias);

                txtdiaslaborados.Text = dias_trabajados;
                /////////

               



            }
        }

        private void txtdiasvaca_TextChanged(object sender, EventArgs e)
        {
            if (txtdiasvaca.Text=="")
            {

            }       
            decimal dias_anio = 365;
            decimal dias_tomados = Convert.ToInt32(txtdiasvaca.Text);
            decimal fact =  dias_tomados/ dias_anio;        
            txtfactorvaca.Text = fact.ToString();

            decimal diaslab = Convert.ToDecimal(txtdiaslaborados.Text);

            decimal dias_p = fact * diaslab;
            txtdiaspropor.Text = dias_p.ToString();

           //decimal salario_diario = Convert.ToDecimal(txtsalario.Text);
            decimal dinero_vacaciones = dias_p * salario_diario;
            dinerovaca.Text = dinero_vacaciones.ToString();

            decimal a = 25;
            decimal b = 100;
            decimal po = a / b;
            decimal  prima = dinero_vacaciones * po  ;
            textBox9.Text = prima.ToString();


        }
    }
}
