using System;
using System.Drawing;
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            BarcodeLib.Barcode Codigo = new BarcodeLib.Barcode();
            Codigo.IncludeLabel = true;
            panelcb.BackgroundImage = Codigo.Encode(BarcodeLib.TYPE.CODE128, textBox2.Text, Color.Black, Color.White,200,50);
            button2.Enabled = true;
        }

       

        private void GeneradorQR_Load(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Image imgfinal = (Image)panelcb.BackgroundImage.Clone();
            SaveFileDialog Caja = new SaveFileDialog();
            Caja.AddExtension = true;
            Caja.Filter = "Image JPG (*.jpg)|*.jpg";
            Caja.ShowDialog();
            if (!string.IsNullOrEmpty(Caja.FileName))
            {

                imgfinal.Save(Caja.FileName);
            }
            imgfinal.Dispose();
        }
    }
}
