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
    public partial class Formato_Unidad_Retorno : Form
    {
        public Formato_Unidad_Retorno()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // autocompleta el formato de salida de la unidad con los datos ingresados en la fecha de salida

            SqlConnection cn;
            // permite realizar sentencias sql 
            SqlCommand cmd;
            SqlDataReader dr;
            cn = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");
            cn.Open();
            cmd = new SqlCommand("select fecha_salida, dias_transcurridos, rendimientos.id_catalogoruta,catalogorutas.nombre,responsable,km_salida,rendimientos.id_unidad,eco,marca,modelo,placas,combustible_s from rendimientos inner join catalogorutas on catalogorutas.id_catalogoruta = rendimientos.id_catalogoruta  inner join unidades on unidades.id_unidad = rendimientos.id_unidad where fecha_retorno = '01/01/1900' and km_llegada = 0; ", cn);
            dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                textBox23.Text = dr["fecha_salida"].ToString();
                textBox13.Text = "---";
                comboruta.Text = dr["nombre"].ToString();
                textBox24.Text = dr["responsable"].ToString();
                comboeco.Text = dr["eco"].ToString();
                textBox15.Text = dr["marca"].ToString();
                textBox27.Text = dr["modelo"].ToString();
                textBox34.Text = dr["placas"].ToString();
                textBox40.Text = dr["combustible_s"].ToString();
                textBox21.Text = dr["km_salida"].ToString();
                textBox17.Text = dr["id_unidad"].ToString();
                
                string fecha = DateTime.Now.ToShortDateString();
                textBox6.Text = fecha;

                string fi = Convert.ToDateTime(textBox23.Text).ToShortDateString();


                DateTime fe_ing = Convert.ToDateTime(fi);
                DateTime fe_hoy = DateTime.Now;
                TimeSpan ts = fe_hoy - fe_ing;
                int dias = ts.Days;
                dias_t.Text = dias.ToString();
                


            }

            dr.Close();
        }


        public void catalogounidades(ComboBox eco)
        {
            SqlConnection cn;
            // permite realizar sentencias sql 
            SqlCommand cmd;
            SqlDataReader dr;
            cn = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");
            cn.Open();
            try
            {
                cmd = new SqlCommand("select fecha_salida, dias_transcurridos, rendimientos.id_catalogoruta,catalogorutas.nombre,responsable,km_salida,rendimientos.id_unidad,eco,marca,modelo,placas,combustible_s from rendimientos inner join catalogorutas on catalogorutas.id_catalogoruta = rendimientos.id_catalogoruta  inner join unidades on unidades.id_unidad = rendimientos.id_unidad where fecha_retorno = '01/01/1900' and km_llegada = 0; ", cn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    eco.Items.Add(dr["eco"].ToString());
                    ///el valor del combobox sera el id del departamento 
                    eco.ValueMember = (dr["id_unidad"].ToString());
                    eco.DisplayMember = (dr["eco"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("no se lleno el cb " + ex.ToString());
            }

        }


        private void Formato_Unidad_Retorno_Load(object sender, EventArgs e)
        {

            catalogounidades(comboBox1);



        }

        private void button2_Click(object sender, EventArgs e)
        {



        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" | textBox9.Text == "" | textBox7.Text == "")
            {
                MessageBox.Show("Faltan Datos");
            }
            else
            {
                try
                {
                    int totaldias = Convert.ToInt32(dias_t.Text);
                    int km_ss =  Convert.ToInt32( textBox21.Text);
                    int km_rr = Convert.ToInt32(textBox9.Text);
                    int km_tot = km_rr - km_ss;


                    SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
                    SqlCommand cadcon;
                    con.Open();
                    cadcon = new SqlCommand("update rendimientos set fecha_retorno='"+textBox6.Text+"' , dias_transcurridos='"+totaldias+"', km_llegada='"+textBox9.Text+ "' , km_recorridos='"+km_tot+"' , combustible_r='" + textBox7.Text + "' where id_unidad='"+textBox17.Text+"' and km_salida='"+textBox21.Text+"' ", con);
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
                    textBox17.Text = "";
                    textBox4.Text = "";
                    textBox7.Text = "";
                    textBox9.Text = "";
                    textBox6.Text = "";
                    comboruta.Text = "";
                    comboeco.Text = "";
                    dias_t.Text = "";
                    comboBox1.Text = "";
                    

                }
                catch (Exception ex)
                {

                    MessageBox.Show("verifica los datos " + ex.ToString());
                    
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
