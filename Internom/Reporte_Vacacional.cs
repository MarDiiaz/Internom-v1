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
    public partial class txtdias : Form
    {

        SqlConnection c = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");

        public txtdias()
        {
            InitializeComponent();
        }



        private void antiguedades()
        {                      
            ////////////// Metodo para obtener los dias de antiguedad de cada trabajador
          
            SqlCommand comando;
            comando = new SqlCommand("select fecha_ingreso,nombre,apellidos from empleados ", c);

            SqlDataReader r;
            c.Open();
            r = comando.ExecuteReader();
            if (r.Read() == true)
            {

                string  fecha_ingreso = r["fecha_ingreso"].ToString();
                string  id = r["id_empleado"].ToString();
               
                string fi = Convert.ToDateTime(fecha_ingreso).ToShortDateString();
                

                DateTime fe_ing = Convert.ToDateTime(fi);
                DateTime fe_hoy = DateTime.Now;
                TimeSpan ts = fe_hoy -fe_ing ;
               int dias = ts.Days;

                string dias_trabajados = Convert.ToString(dias);
                string dias_vaca;
                if (dias_trabajados=="365")
                {
                    dias_vaca= "6";
                
                    
                }
                else
                {
                    dias_vaca = "0";
                }
                c.Close();
                ///////////////////// FIN DEL METODO


                SqlCommand cad;
                c.Open();
                cad = new SqlCommand("insert into  vacaciones( id_empleado,antiguedad,dias_otorgados,dias_tomados,dias_restantes,prima_vacacional) values (" + id + ", '" + dias + "','"+dias_vaca+"','0','0','0' )", c);
                SqlDataReader re;
                re = cad.ExecuteReader();
                if (re.Read() == true)

                {
                }
                c.Close();

            }
        }





        

        private void button6_Click(object sender, EventArgs e)
        {
            PrincipalAdmin pa = new PrincipalAdmin();
            pa.Show();
            Close();
        }

        private void Reporte_Vacacional_Load(object sender, EventArgs e)
        {
         
        }
    }
}
