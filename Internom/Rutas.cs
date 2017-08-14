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
    public partial class Rutas : Form
    {

        public Rutas()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Rutas_Load(object sender, EventArgs e)
        {
            conexion c = new conexion();
            c.catalogorutas(comboBox1);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // obtiene el nombre del empleado  que coincida con el numero de nomina ingresado
            SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
            string cadcon = "Select id_empleado,nombre,apellidos,cargo From empleados where no_nomina ='" + textBox1.Text + "'";
            //id_dpto.Text=(comboBox1.SelectedValue.ToString());
            SqlCommand cm = new SqlCommand(cadcon, con);
            con.Open();
            SqlDataReader leer = cm.ExecuteReader();

            if (leer.Read() == true)
            {
                textBox2.Text = leer["nombre"].ToString();
                textBox3.Text = leer["apellidos"].ToString();
                id.Text = leer["id_empleado"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hora = DateTime.Now.ToShortTimeString();
            string message = "Hora Entrada: " + hora;
            DateTime dt = new DateTime();
            string fecha = monthCalendar1.TodayDate.ToString();


            ///////

            if (textBox1.Text == "")

            {

                MessageBox.Show("INGRESA TU NO. NOMINA");
            }

            else
            {  ///////

                //CAMBIAR IDIOMA FECHAS 
                //Thread.CurrentThread.CurrentCulture = new CultureInfo("es-Es");
                string a = " " + dt.DayOfWeek;


                //----- REALIZAR CONSULTA EN  tb horarios select hora_ingreso from horarios where id_empleado = id.text 

                SqlConnection cone = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
                SqlCommand comand;
                comand = new SqlCommand("Select hora_salida,fecha_salida from rutas where id_empleado='" + id.Text + "' ORDER BY fecha_salida desc", cone);
                SqlDataReader dread;
                cone.Open();
                dread = comand.ExecuteReader();
                if (dread.Read() == true)
                {
                    valuehora.Text = dread["hora_salida"].ToString();
                    fechahoy.Text = dread["fecha_salida"].ToString();

                }
                cone.Close();

                //------ Realizar comparacion si la fecha de registro es diferente a la fecha a la fecha de hoy entonces le permitira realizar su acceso 

                if (fechahoy.Text != fecha.ToString() || fechahoy.Text == "")
                {
                    string salida = "Acceso Correcto";
                    try
                    {
                        SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
                        SqlCommand cadcon;
                        con.Open();
                        cadcon = new SqlCommand("Insert into rutas (fecha_salida,fecha_llegada,hora_salida,hora_llegada,notas,horas_trabajadas,id_catalogoruta,id_empleado) values ('" + fecha + "','','" + hora + "','00:00','"+textBox4.Text+"','00:00','"+textBox5.Text+"'," + id.Text + ")", con);
                        cadcon.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        salida = "no registrado:" + ex.ToString();
                    }
                    MessageBox.Show(salida);
                    MessageBox.Show(message, a);

                }
                else
                {
                    MessageBox.Show("HORA ENTRADA YA REGISTRADA");
                }


                //------ Habilitar boton entrada ELSE MSGBOX "HORA ENTRADA YA REGISTRADA "
                //------Limpia todos los campos

                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                id.Text = "";
                valuehora.Text = "";
                fechahoy.Text = "";
                textBox1.Text = "";


            }
        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // obtiene el id de la ruta  elegido en el combobox
            SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
            string cadcon = "Select id_catalogoruta From catalogorutas where nombre ='" + comboBox1.Text + "'";
            //id_dpto.Text=(comboBox1.SelectedValue.ToString());
            SqlCommand cm = new SqlCommand(cadcon, con);
            con.Open();
            SqlDataReader leer = cm.ExecuteReader();

            if (leer.Read() == true)
            {
                textBox5.Text = leer["id_catalogoruta"].ToString();
            }
        }
        private void horas_trabajada()
        {
            string fecha = monthCalendar1.TodayDate.ToString();
            ////////////// Metodo para obtener las horas trabajadas diarias de cada trabajador 
            SqlConnection c = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");
            SqlCommand comando;
            comando = new SqlCommand("select fecha_salida, hora_salida,hora_llegada, id_empleado from rutas  where id_empleado ='" + id.Text + "' and fecha_llegada='" + fecha + "'", c);

            SqlDataReader r;
            c.Open();
            r = comando.ExecuteReader();
            if (r.Read() == true)
            {
                string hora_ingreso = r["hora_salida"].ToString();
                string id_empleado = r["id_empleado"].ToString();
                string hora_salida = r["hora_llegada"].ToString();
                string hi = Convert.ToDateTime(hora_ingreso).ToShortTimeString(); ;
                string hs = Convert.ToDateTime(hora_salida).ToShortTimeString();

                DateTime hhi = Convert.ToDateTime(hi);
                DateTime hhs = Convert.ToDateTime(hs);

                TimeSpan total = hhs.TimeOfDay - hhi.TimeOfDay;
                string horas_trabajadas = total.ToString();
                c.Close();
                ///////////////////// FIN DEL METODO


                SqlCommand cad;
                c.Open();
                cad = new SqlCommand("update rutas set horas_trabajadas='" + horas_trabajadas + "' where id_empleado='" + id.Text + "' and  fecha_llegada='" + fecha + "'", c);
                SqlDataReader re;
                re = cad.ExecuteReader();
                if (re.Read() == true)

                {
                    MessageBox.Show("horas trabajadas: ", horas_trabajadas);
                }
                c.Close();

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string hora = DateTime.Now.ToShortTimeString();
            string message = "Hora Entrada: " + hora;
            DateTime dt = new DateTime();
            string fecha = monthCalendar1.TodayDate.ToString();
            string fecha2 = monthCalendar1.TodayDate.ToString("yyyy/dd/Mm");


            ///////

            if (textBox1.Text == "")

            {

                MessageBox.Show("INGRESA TU NO. NOMINA");
            }

            else
            {  ///////

                //CAMBIAR IDIOMA FECHAS 
                //Thread.CurrentThread.CurrentCulture = new CultureInfo("es-Es");
                string a = " " + dt.DayOfWeek;


                //----- REALIZAR CONSULTA EN  tb horarios select hora_ingreso from horarios where id_empleado = id.text 

                SqlConnection cone = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
                SqlCommand comand;
                comand = new SqlCommand("Select hora_llegada,fecha_llegada from rutas where id_empleado='" + id.Text + "' ", cone);
                SqlDataReader dread;
                cone.Open();
                dread = comand.ExecuteReader();
                if (dread.Read() == true)
                {
                    string salida = dread["hora_llegada"].ToString();
                    valuehora.Text = Convert.ToDateTime(salida).ToShortTimeString();
                    fechahoy.Text = dread["fecha_llegada"].ToString();

                }
                cone.Close();

                //------ Realizar comparacion si la fecha de registro es diferente a la fecha a la fecha de hoy entonces le permitira realizar su acceso 

                if (fechahoy.Text != fecha.ToString() || fechahoy.Text == "" || valuehora.Text == "0:00")
                {
                    string salida = "Acceso Correcto";
                    try
                    {
                        SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
                        SqlCommand cadcon;
                        con.Open();
                        cadcon = new SqlCommand("update rutas set hora_llegada= '" + hora + "', fecha_llegada='"+fecha+"' where id_empleado = " + id.Text + " ", con);
                        cadcon.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        salida = "no registrado:" + ex.ToString();
                    }


                    horas_trabajada();
                    MessageBox.Show(salida);
                    MessageBox.Show(message, a);

                }
                else
                {
                    MessageBox.Show("HORA SALIDA YA REGISTRADA");
                }
                //------ Habilitar boton entrada ELSE MSGBOX "HORA ENTRADA YA REGISTRADA "
                //------Limpia todos los campos

                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                id.Text = "";
                valuehora.Text = "";
                fechahoy.Text = "";
                textBox1.Text = "";

            }
        }
    }
}