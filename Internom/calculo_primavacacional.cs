using System;
using System.Data.SqlClient;
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
                textBox16.Text = salario;


                ///////
                //vamos a obtener el año en curso y concatenarlo con la variable fecha_primero
                // para obtener los dias laborados durante el año en curso del trabajador 
                string fecha_primero = "01/01/";
                int fecha_actual = DateTime.Now.Year;
                string anio_actual = Convert.ToString(fecha_actual);
                string inicio_anio_actual = fecha_primero + anio_actual;


                string fi = Convert.ToDateTime(fecha_in).ToShortDateString();
                // obtenemos los dias trabajados durante el año del trabajador  
                DateTime fe_ing = Convert.ToDateTime(inicio_anio_actual);
                DateTime fe_hoy = DateTime.Now;
                TimeSpan ts = fe_hoy - fe_ing;
                int dias = ts.Days;
                string dias_trabajados = Convert.ToString(dias);

                txtdiaslaborados.Text = dias_trabajados;
                textBox14.Text = dias_trabajados;
                /////////


                c.Close();


            }
        }

        private void txtdiasvaca_TextChanged(object sender, EventArgs e)
        {
            if (txtdiasvaca.Text == "")
            {
                MessageBox.Show("Cuantos dias tomara de vacaciones ");
            }
            else
            {
                decimal dias_anio = 365;
                decimal dias_tomados = Convert.ToInt32(txtdiasvaca.Text);
                // obtenemos un factor que sera el resultado de los dias de vacaciones que el trabajador tomara
                // entre los dias del año este factos es para las vacaciones 

                decimal fact = dias_tomados / dias_anio;
                txtfactorvaca.Text = fact.ToString();
                decimal d = Convert.ToDecimal(textBox11.Text);
                // obtenemos un factor que sera el resultado de los dias de vacaciones que el trabajador tomara
                // entre los dias del año este factos es para el aguinaldo 
                decimal facag = d / dias_anio;



                textBox12.Text = Convert.ToString(facag);
                //CAMBIAR 
                decimal diaslab = Convert.ToDecimal(txtdiaslaborados.Text);

                // obtenemos los dias que le corresponden al trabajador para ser pagados como vacaciones 
                // se obtiene multiplicando el factor que obtuvimos antes * los das laborados durante el año 



                decimal diasaguinaldo = facag * diaslab;
                textBox15.Text = Convert.ToString(diasaguinaldo);


                // obtenemos los dias que le corresponden al trabajador para ser pagados como aguinaldo
                // se obtiene multiplicando el factor que obtuvimos antes * los das laborados durante el año 

                decimal dias_p = fact * diaslab;
                txtdiaspropor.Text = dias_p.ToString();



                decimal salario_diario = Convert.ToDecimal(txtsalario.Text);
                // obtenemos el monto correspondiente a pagar al trabajador como  vacaciones 
                decimal dinero_vacaciones = dias_p * salario_diario;
                dinerovaca.Text = dinero_vacaciones.ToString();

                // obtenemos el monto correspondiente a pagar al trabajador como aguinaldo 
                decimal dinero_aguinaldo = salario_diario * diasaguinaldo;
                aguinaldo.Text = Convert.ToString(dinero_aguinaldo);

                decimal a = 25;
                decimal b = 100;
                decimal po = a / b;
                // obtenemos el monto correspondiente a pagar al trabajador como prima vacacional 
                decimal prima = dinero_vacaciones * po;
                textBox9.Text = prima.ToString();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrincipalAdmin pa = new PrincipalAdmin();
            pa.Show();
            Close();
        }
    }
}
