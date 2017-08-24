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

        private void Permisos_Load(object sender, EventArgs e)
        {
            incidencias(checkedListBox1);
            textBox18.Focus();
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {


        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {

        }
    }
}
