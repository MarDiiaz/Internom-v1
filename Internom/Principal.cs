using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Internom
{
    public partial class Principal : Form
    {
        SqlConnection c = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");
       
        public Principal()
        {
            InitializeComponent();
            
        }
       
        private void fecha_nac()

        {
            c.Open();
            string fecha = monthCalendar1.TodayDate.ToString();
            int dia_hoy = DateTime.Now.Day;
            int mes_actual = DateTime.Now.Month;
            string cadcon = "Select nombre,apellidos,fecha_nacimiento from empleados where  month (fecha_nacimiento)= '"+mes_actual+"'and DAY ( fecha_nacimiento) = '"+dia_hoy+"'";
            SqlCommand cm = new SqlCommand(cadcon,c);
            SqlDataReader dat = cm.ExecuteReader();

            if (dat.Read()==true)
            {

                felicitacion.Text= (dat["nombre"].ToString()+"  "+ dat["apellidos"].ToString() );
                
                label8.Text = " Feliz Cumpleaños";

            }
            
            c.Close();
            
        }


        private void Form1_activate(object sender, EventArgs e)
        {
            no.Focus();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
          fecha_nac();
        }
       
      
        private void Administrador_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

      
        private void horas_trabajada()
        {
            string fecha = monthCalendar1.TodayDate.ToString();
            ////////////// Metodo para obtener las horas trabajadas diarias de cada trabajador 
            SqlConnection c = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");
            SqlCommand comando;
            comando = new SqlCommand("select fecha, hora_ingreso,hora_salida,entrada_comida,salida_comida, id_empleado from horarios  where id_empleado ='" + id.Text + "' and fecha='" + fecha + "'", c);

            SqlDataReader r;
            c.Open();
            r = comando.ExecuteReader();
            if (r.Read() == true)
            {
                string hora_ingreso = r["hora_ingreso"].ToString();
                string id_empleado = r["id_empleado"].ToString();
                string hora_salida = r["hora_salida"].ToString();
                string entrada_comida = r["entrada_comida"].ToString();
                string salida_comida = r["salida_comida"].ToString();
                string ec = Convert.ToDateTime(entrada_comida).ToShortTimeString();
                string sc = Convert.ToDateTime(salida_comida).ToShortTimeString();
                string hi = Convert.ToDateTime(hora_ingreso).ToShortTimeString(); 
                string hs = Convert.ToDateTime(hora_salida).ToShortTimeString();

                DateTime hhi = Convert.ToDateTime(hi);
                DateTime hhs = Convert.ToDateTime(hs);
                DateTime hec = Convert.ToDateTime(ec);
                DateTime hsc = Convert.ToDateTime(sc);

                TimeSpan total = hhs.TimeOfDay - hhi.TimeOfDay;
                string horas_trabajadas = total.ToString();
                TimeSpan tiempo_com = hsc.TimeOfDay - hec.TimeOfDay;
                TimeSpan horas_netas = total - tiempo_com;
                string horas_trabajadas_netas = horas_netas.ToString();
                string tiempo_comida = tiempo_com.ToString();
                c.Close();
                ///////////////////// FIN DEL METODO

              
                SqlCommand cad;
                c.Open();
                cad = new SqlCommand("update horarios set horas_trabajadas='" + horas_trabajadas_netas + "', tiempo_comida='"+tiempo_comida+"' where id_empleado='" + id.Text +"' and  fecha='" + fecha + "'", c);
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
            string message = "Hora Salida: " + hora;
            DateTime dt = new DateTime();
            string fecha = monthCalendar1.TodayDate.ToString();
            string fecha2 = monthCalendar1.TodayDate.ToString("yyyy/dd/Mm");


            if (no.Text == "")

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
                comand = new SqlCommand("Select hora_salida,fecha from horarios where id_empleado='" + id.Text + "' ORDER BY fecha desc", cone);
                SqlDataReader dread;
                cone.Open();
                dread = comand.ExecuteReader();
                if (dread.Read() == true)
                {
                    string salida = dread["hora_salida"].ToString();
                    valuehora.Text = Convert.ToDateTime(salida).ToShortTimeString();
                    fechahoy.Text = dread["fecha"].ToString();
                   
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
                        cadcon = new SqlCommand("update horarios set hora_salida= '" + hora + "' where id_empleado = " + id.Text + " and fecha = '" + fecha + "'", con);
                        cadcon.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        salida = "no registrado:" + ex.ToString();
                    }


                    horas_trabajada();                   
                 //   MessageBox.Show(salida);
                    MessageBox.Show("HASTA MAÑANA", message );

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
                no.Text = "";
                no.Focus();

            }
        }

      
        

        

        private void button1_Click(object sender, EventArgs e)

        {
            string hora = DateTime.Now.ToShortTimeString();
            string message = "Hora Entrada: " + hora;
            DateTime dt = new DateTime();
            string fecha = monthCalendar1.TodayDate.ToString();


            ///////

            if (no.Text == "")

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
                comand = new SqlCommand("Select hora_ingreso,fecha from horarios where id_empleado='" + id.Text + "' ORDER BY fecha desc", cone);
                SqlDataReader dread;
                cone.Open();
                dread = comand.ExecuteReader();
                if (dread.Read() == true)
                {
                    valuehora.Text = dread["hora_ingreso"].ToString();
                    fechahoy.Text = dread["fecha"].ToString();

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
                        cadcon = new SqlCommand("Insert into horarios (fecha,hora_ingreso,entrada_comida,salida_comida,hora_salida,horas_trabajadas,tiempo_comida,id_empleado) values ('" + fecha + "','" + hora + "','00:00','00:00','00:00','00:00','00:00'," + id.Text + ")", con);
                        cadcon.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        salida = "no registrado:" + ex.ToString();
                    }
                   // MessageBox.Show(salida);
                    MessageBox.Show("BIENVENIDO", message);

                }
                else
                {
                   // MessageBox.Show("HORA ENTRADA YA REGISTRADA");
                    button3_Click(this, new EventArgs());
             

                }


                //------ Habilitar boton entrada ELSE MSGBOX "HORA ENTRADA YA REGISTRADA "
                //------Limpia todos los campos
               
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                id.Text = "";
                valuehora.Text = "";
                fechahoy.Text = "";
                no.Text = "";
                no.Focus();
                


            }
        }

       

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            // obtiene el nombre del empleado  que coincida con el numero de nomina ingresado
            SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
            string cadcon = "Select id_empleado,nombre,apellidos,cargo From empleados where no_nomina ='" + no.Text + "'";
            //id_dpto.Text=(comboBox1.SelectedValue.ToString());
            SqlCommand cm = new SqlCommand(cadcon, con);
            con.Open();
            SqlDataReader leer = cm.ExecuteReader();

            if (leer.Read() == true)
            {
                textBox2.Text = leer["nombre"].ToString();
                textBox3.Text = leer["apellidos"].ToString();
                textBox4.Text = leer["cargo"].ToString();
                id.Text = leer["id_empleado"].ToString();
                //string imagen;
                //imagen = textBox2.Text + ".jpg";
                //// la carpeta de imagene sse encuentra ubicada en internom\bin\\debug\\fotos
                //foto.Load(Application.StartupPath + @"\fotos\" +imagen);
                //foto.SizeMode = PictureBoxSizeMode.StretchImage;

            }

            

        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            string hora = DateTime.Now.ToShortTimeString();
            string message = "Hora Entrada: " + hora;
            DateTime dt = new DateTime();
            string fecha = monthCalendar1.TodayDate.ToString();

            if (no.Text == "")

            {
                MessageBox.Show("INGRESA TU NO. NOMINA");
            }

            else
            {
                string a = " " + dt.DayOfWeek;
                //----- REALIZAR CONSULTA EN  tb horarios select hora_ingreso from horarios where id_empleado = id.text 

                SqlConnection cone = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
                SqlCommand comand;
                comand = new SqlCommand("Select fecha,entrada_comida from horarios where id_empleado='" + id.Text + "' ORDER BY fecha desc", cone);
                SqlDataReader dread;
                cone.Open();
                dread = comand.ExecuteReader();
                if (dread.Read() == true)
                {
                    string entrada_comer = dread["entrada_comida"].ToString();
                    valuehora.Text = Convert.ToDateTime(entrada_comer).ToShortTimeString();
                    fechahoy.Text = dread["fecha"].ToString();
                    
                    

                }
                cone.Close();

                //------ Realizar comparacion si la fecha de registro es diferente a la fecha a la fecha de hoy entonces le permitira realizar su acceso 

                if (fechahoy.Text != fecha.ToString() || fechahoy.Text == "" || valuehora.Text=="0:00")
                {
                    string salida = "Acceso Correcto";
                    try
                    {
                        SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
                        SqlCommand cadcon;
                        con.Open();
                        cadcon = new SqlCommand("update horarios set entrada_comida='"+hora+ "' where id_empleado=" + id.Text + " and fecha='" + fecha + "'", con);
                        cadcon.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        salida = "no registrado:" + ex.ToString();
                    }
                    //MessageBox.Show(salida);
                    MessageBox.Show( "BUEN PROVECHO", message);

                }
                else
                {
                    //MessageBox.Show("HORA ENTRADA YA REGISTRADA");
                    button4_Click(this, new EventArgs());

                }


                //------ Habilitar boton entrada ELSE MSGBOX "HORA ENTRADA YA REGISTRADA "
                //------Limpia todos los campos

                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                id.Text = "";
                valuehora.Text = "";
                fechahoy.Text = "";
                no.Text = "";
                no.Focus();
                

            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string hora = DateTime.Now.ToShortTimeString();
           
            no.Focused.ToString();
            string message = "Hora Entrada: " + hora;
            DateTime dt = new DateTime();
            string fecha = monthCalendar1.TodayDate.ToString();

            if (no.Text == "")

            {
                MessageBox.Show("INGRESA TU NO. NOMINA");
            }

            else
            {
                string a = " " + dt.DayOfWeek;
                //----- REALIZAR CONSULTA EN  tb horarios select hora_ingreso from horarios where id_empleado = id.text 

                SqlConnection cone = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
                SqlCommand comand;
                comand = new SqlCommand("Select fecha,salida_comida from horarios where id_empleado='" + id.Text + "' ORDER BY fecha desc", cone);
                SqlDataReader dread;
                cone.Open();
                dread = comand.ExecuteReader();
                if (dread.Read() == true)
                {
                    string salida_comer = dread["salida_comida"].ToString();
                    valuehora.Text = Convert.ToDateTime(salida_comer).ToShortTimeString();
                    fechahoy.Text = dread["fecha"].ToString();
                   

                }
                cone.Close();

                //------ Realizar comparacion si la fecha de registro es diferente a la fecha a la fecha de hoy entonces le permitira realizar su acceso 

                if (fechahoy.Text != fecha.ToString() || fechahoy.Text == "" || valuehora.Text=="0:00")
                {
                    string salida = "Acceso Correcto";
                    try
                    {
                        SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
                        SqlCommand cadcon;
                        con.Open();
                        cadcon = new SqlCommand("update horarios set salida_comida = '"+hora+ "' where id_empleado = " + id.Text + " and fecha = '" + fecha + "'", con);
                        cadcon.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        salida = "no registrado:" + ex.ToString();
                    }
                    //MessageBox.Show(salida);
                    MessageBox.Show(message, a);

                }
                else
                {
                    // MessageBox.Show("HORA ENTRADA YA REGISTRADA");
                    button2_Click(this, new EventArgs());

                }


                //------ Habilitar boton entrada ELSE MSGBOX "HORA ENTRADA YA REGISTRADA "
                //------Limpia todos los campos

                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                id.Text = "";
                valuehora.Text = "";
                fechahoy.Text = "";
                no.Text = "";
                no.Focus();
            }
        }

      

        private void registroVisitantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entrada_Salida es = new Entrada_Salida();
            es.Show();
        }

        private void rutasToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Rutas r = new Rutas();
            r.Show();
            Close();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Permisos per = new Permisos();
            per.Show();
            Close();
        }
    }
}
