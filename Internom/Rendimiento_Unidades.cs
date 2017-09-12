using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Internom
{
    public partial class Rendimiento_Unidades : Form
    {
        SqlConnection c = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");

        public Rendimiento_Unidades()
        {
            InitializeComponent();
        }


        private void consulta()
        {
            string fecha = DateTime.Today.ToString();
            c.Open();
            SqlDataAdapter da = new SqlDataAdapter("select fecha_salida,fecha_retorno,dias_transcurridos,catalogorutas.nombre,responsable,km_salida,km_llegada,km_recorridos,rendimientos.id_unidad,eco,combustible_s,combustible_r from rendimientos inner join catalogorutas on catalogorutas.id_catalogoruta = rendimientos.id_catalogoruta  inner join unidades on unidades.id_unidad = rendimientos.id_unidad where eco='"+textBox1.Text+"'", c); 
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            c.Close();

        }

        private void Rendimiento_Unidades_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            consulta();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo = aplicacion.Workbooks.Open(@"C:\Users\MarD\Desktop\Residencias\Internom-v1\Internom\Reportes\plantilla.xlsx");// Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo = null;
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        hoja_trabajo.Cells[i + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                //
                libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();

            }
        }
    }
}
