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
    public partial class Credenciales : Form
    {
        public Credenciales()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\MarD\Desktop\Residencias\Internom-v1\Internom\bin\Debug\fotos";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foto.Image = Image.FromFile(openFileDialog1.FileName);
                foto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\MarD\Desktop\Residencias\Internom-v1\Internom\QR codigos";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                codigobarras.Image = Image.FromFile(openFileDialog1.FileName);
                codigobarras.SizeMode = PictureBoxSizeMode.StretchImage;
            }


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
            // Carga todos los datos del empleado para llenar la credencial 
        {
            // obtiene el nombre del empleado  que coincida con el numero de nomina ingresado
            SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
            string cadcon = "Select id_empleado,nombre,apellidos,cargo,nombre_dpto, seguro From empleados inner join departamentos on empleados.id_departamento=departamentos.id_departamento where no_nomina ='" +  textBox4.Text + "'";
            //id_dpto.Text=(comboBox1.SelectedValue.ToString());
            SqlCommand cm = new SqlCommand(cadcon, con);
            con.Open();
            SqlDataReader leer = cm.ExecuteReader();

            if (leer.Read() == true)
            {
                string nombre = leer["nombre"].ToString();
              string apellidos = leer["apellidos"].ToString();
              string cargo = leer["cargo"].ToString();
              string dpto = leer["nombre_dpto"].ToString();
                string seguro = leer["seguro"].ToString();

                string nombre_completo =  nombre + " " +  apellidos ;
                string puesto = cargo +" " +  dpto;
                txtnombre.Text = nombre_completo;
                txtnombre.TextAlign = HorizontalAlignment.Center;
                txtcargo.Text = puesto;
                txtcargo.TextAlign = HorizontalAlignment.Center;

                textBox3.Text = seguro;
                textBox3.TextAlign = HorizontalAlignment.Center;
                textBox4.TextAlign = HorizontalAlignment.Center;
                
                

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Image imgfinal = (Image)panel2.BackgroundImage.Clone();
            //SaveFileDialog Caja = new SaveFileDialog();
            //Caja.AddExtension = true;
            //Caja.Filter = "Image JPG (*.jpg)|*.jpg";
            //Caja.ShowDialog();
            //if (!string.IsNullOrEmpty(Caja.FileName))
            //{

            //    imgfinal.Save(Caja.FileName);
            //}
            //imgfinal.Dispose();
        }

        private void Credenciales_Load(object sender, EventArgs e)
        {

        }
    }
}
