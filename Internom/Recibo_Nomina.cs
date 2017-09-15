using System.Drawing;
using System.Windows.Forms;

namespace Internom
{
    public partial class Recibo_Nomina : Form
    {
        public Recibo_Nomina()
        {
            InitializeComponent();
        }

        private void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // crea un rectangulo del tamaño del panel para poder imprimirlo 
            int width = panel1.Width;
            int height = panel1.Height;
            ScrollProperties p = this.VerticalScroll;
            // Bitmap bmp = new Bitmap(width, p.LargeChange, panel1.CreateGraphics());

            Bitmap bmp = new Bitmap(width, height, panel1.CreateGraphics());
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)bmp.Height / (float)bmp.Width);
            e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
        }
    }
}
