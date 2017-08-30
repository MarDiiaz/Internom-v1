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
    public partial class Permisos : Form
    {
        public Permisos()
        {
            InitializeComponent();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }


        public void incidencias(CheckedListBox cb)
        { // conexion sql 19/07/2017
            SqlConnection cn;
            // permite realizar sentencias sql 
            SqlCommand cmd;
            SqlDataReader dr;

            try
            {
                cn = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");
                cn.Open(); 
                cmd = new SqlCommand("Select nombre_inc , id_incidencia from incidencias ", cn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cb.Items.Add(dr["nombre_inc"].ToString());
                    ///el valor del combobox sera el id del departamento 
                    cb.ValueMember = (dr["id_incidencia"].ToString());
                    cb.DisplayMember = (dr["nombre_inc"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("no se lleno el cb " + ex.ToString());
            }

        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

       
        private void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int width = panel1.Width;
            int height = panel1.Height;
            ScrollProperties p = this.VerticalScroll;
         // Bitmap bmp = new Bitmap(width, p.LargeChange, panel1.CreateGraphics());

            Bitmap bmp = new Bitmap(width, height, panel1.CreateGraphics());
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, width,height));
            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)bmp.Height / (float)bmp.Width);
            e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
        }





        private void Permisos_Load(object sender, EventArgs e)
        {
            incidencias(checkedListBox1);
            textBox18.Focus();
            string fecha = DateTime.Now.ToShortDateString();
            textBox13.Text = fecha;
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {


        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {
           
        }



        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            checkedListBox1.ClearSelected();


            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
                doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(doc_PrintPage);
            DialogResult result = printDialog1.ShowDialog();
           // printPreviewDialog1.Document = doc;
            //printPreviewDialog1.ShowDialog();
           doc.Print();
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            // obtiene el nombre del empleado  que coincida con el numero de nomina ingresado
            SqlConnection con = new SqlConnection("Data Source = MARDIAZ\\SQLEXPRESS; Initial Catalog = internom; Initial Catalog = internom; Integrated Security = True");
            string cadcon = "Select id_empleado,nombre,apellidos,cargo,nombre_dpto From empleados inner join  departamentos on empleados.id_departamento = departamentos.id_departamento where no_nomina ='" + textBox18.Text + "'";
            //id_dpto.Text=(comboBox1.SelectedValue.ToString());
            SqlCommand cm = new SqlCommand(cadcon, con);
            con.Open();
            SqlDataReader leer = cm.ExecuteReader();

            if (leer.Read() == true)
            {
                textBox19.Text = leer["nombre_dpto"].ToString();
               string name = leer["nombre"].ToString();
                string last_name = leer["apellidos"].ToString();

                textBox15.Text =  name + last_name;
                //string imagen;
                //imagen = textBox2.Text + ".jpg";
                //// la carpeta de imagene sse encuentra ubicada en internom\bin\\debug\\fotos
                //foto.Load(Application.StartupPath + @"\fotos\" +imagen);
                //foto.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           textBox14.Text = dateTimePicker1.Value.ToString("dd/MM/yyyy");
        }
    }
}
