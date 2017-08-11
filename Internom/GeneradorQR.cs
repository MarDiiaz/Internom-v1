using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Internom
{
    public partial class GeneradorQR : Form
    {
        public GeneradorQR()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            qrCodeImgControl1.Text = textBox1.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrincipalAdmin pa = new PrincipalAdmin();
            pa.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtiene la imagen del codigo generado
            Image img = (Image)qrCodeImgControl1.Image.Clone();
            // Guarda la imagen 
            SaveFileDialog sv = new SaveFileDialog();
            sv.AddExtension = true;
            sv.Filter = "Image JPG (*.jpg)|*.jpg";
            sv.ShowDialog();
            if (!string.IsNullOrEmpty(sv.FileName))
            {
                img.Save(sv.FileName);

            }
            img.Dispose();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
    }
}
