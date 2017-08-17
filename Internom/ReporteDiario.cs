using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Internom
{
    public partial class ReporteDiario : Form
    {
        SqlConnection c = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");

        public ReporteDiario()
        {
            InitializeComponent();
        }

        private void consulta()
        {
            string fecha = DateTime.Today.ToString();
            c.Open();
            SqlDataAdapter da = new SqlDataAdapter("select  no_nomina, nombre ,apellidos,hora_ingreso,entrada_comida,salida_comida,hora_salida,horas_trabajadas,tiempo_comida from horarios inner join empleados on empleados.id_empleado = horarios.id_empleado where fecha='"+fecha+"'", c);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            c.Close();

        }
        private void ReporteDiario_Load(object sender, EventArgs e)
        {
            consulta();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrincipalAdmin pa = new PrincipalAdmin();
            pa.Show();
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion  = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook  libros_trabajo =  aplicacion.Workbooks.Open("C:\\Users\\MarD\\Desktop\\Residencias\\Internom-v1\\Internom\\Reportes\\reported.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo
                for (int i = 0 , a=12; i < dataGridView1.Rows.Count - 1; i++ , a++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        hoja_trabajo.Cells[a + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }

        }
    }
}
