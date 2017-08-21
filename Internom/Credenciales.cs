﻿using System;
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
        { //Incializa un componente SaveFileDialog.
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //Cuando buscas archivos te muestra todos los .bmp.
            saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            //Titulo
            saveFileDialog.Title = "Guardar gráfico como imagen";
            // preguntamos si elegiste un nombre de archivo.
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Extención del archivo por defecto segun el filtro del saveFileDialog
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        saveFileDialog.DefaultExt = "jpg";
                        break;

                    case 2:
                        saveFileDialog.DefaultExt = "bmp";
                        break;

                    case 3:
                        saveFileDialog.DefaultExt = "gif";
                        break;
                }
                //Obtenemos alto y ancho del panel
                int width = panel1.Width;
                int height = panel1.Height;
                //Inicializamos un objeto BitMap con las dimensiones del Panel
                Bitmap bitMap = new Bitmap(width, height);
                //Inicializamos un objeto Rectangle en la posicion 0,0 y con dimensiones iguales a las del panel.
                //0,0 y las mismas dimensiones del panel porque queremos tomar todo el panel
                // o si solo queremos tomar una parte pues podemos dar un punto de inicio diferente y dimensiones distintas.
                Rectangle rec = new Rectangle(0, 0, width, height);
                //Este metodo hace la magia de copiar las graficas a el objeto Bitmap
                panel1.DrawToBitmap(bitMap, rec);
                // Y por ultimo salvamos el archivo pasando como parametro el nombre que asignamos en el saveDialogFile
                bitMap.Save(saveFileDialog.FileName);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //Incializa un componente SaveFileDialog.
            SaveFileDialog save = new SaveFileDialog();
            //Cuando buscas archivos te muestra todos los .bmp.
          save.Filter= "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            //Titulo
            save.Title = "Guardar gráfico como imagen";
            // preguntamos si elegiste un nombre de archivo.
            if (save.ShowDialog() == DialogResult.OK)
            {
                //Extención del archivo por defecto segun el filtro del saveFileDialog
                switch (save.FilterIndex)
                {
                    case 1:
                        save.DefaultExt = "jpg";
                        break;

                    case 2:
                        save.DefaultExt = "bmp";
                        break;

                    case 3:
                        save.DefaultExt = "gif";
                        break;
                }
                //Obtenemos alto y ancho del panel
                int width = panel2.Width;
                int height = panel2.Height;
                //Inicializamos un objeto BitMap con las dimensiones del Panel
                Bitmap bit = new Bitmap(width, height);
                //Inicializamos un objeto Rectangle en la posicion 0,0 y con dimensiones iguales a las del panel.
                //0,0 y las mismas dimensiones del panel porque queremos tomar todo el panel
                // o si solo queremos tomar una parte pues podemos dar un punto de inicio diferente y dimensiones distintas.
                Rectangle rec = new Rectangle(0, 0, width, height);
                //Este metodo hace la magia de copiar las graficas a el objeto Bitmap
                panel2.DrawToBitmap(bit, rec);
                // Y por ultimo salvamos el archivo pasando como parametro el nombre que asignamos en el saveDialogFile
                bit.Save(save.FileName);
            }
        }

        private void Credenciales_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
