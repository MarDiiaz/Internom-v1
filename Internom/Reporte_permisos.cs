using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Internom
{
    public partial class Reporte_permisos : Form
    {
        SqlConnection c = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");

        public Reporte_permisos()
        {
            InitializeComponent();
        }

        private void Reporte_permisos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                for (int i = 0;  i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        hoja_trabajo.Cells[i + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                //libros_trabajo.Application.ActiveWorkbook.SaveCopyAs(@"C:\Users\MarD\Desktop\Residencias\Internom-v1\Internom\Reportes\reportecopi.xlsx");
                //libros_trabajo.Application.ActiveWorkbook.Save();

                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = dateTimePicker2.Value.ToShortDateString();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            PrincipalAdmin pa = new PrincipalAdmin();
            pa.Show();
            Close();
        }


        private void consulta()
        {
            //string fecha = DateTime.Today.ToString();
            c.Open();
            SqlDataAdapter da = new SqlDataAdapter("select nombre,apellidos,no_nomina,fecha_elaboracion,fecha_solicitada,incidencia from permisos inner join empleados on empleados.id_empleado = permisos.id_empleado where fecha_elaboracion between '" + textBox1.Text + "' and '" + textBox2.Text + "'", c);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            c.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            consulta();
        }
    }
}
