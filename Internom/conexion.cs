using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Internom
{
    class conexion
    {

        // conexion sql 19/07/2017
        SqlConnection cn;
        // permite realizar sentencias sql 
        SqlCommand cmd;
        SqlDataReader dr;

        //System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();

        //conexion a la base de datos
        public conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=MARDIAZ\\SQLEXPRESS;Initial Catalog=internom;Initial Catalog=internom;Integrated Security=True");
                cn.Open();
                // MessageBox.Show("conectado");
            }
            catch (Exception ex)
            {

                MessageBox.Show("conexion fallida: " + ex.ToString());
            }


        }
        //metodo para obtener los valores de la tabla dptos para llenar el combobox (alta empleado)
        public void llenarcombo(ComboBox cb)
        {

            try
            {
                cmd = new SqlCommand("Select nombre_dpto , id_departamento from departamentos ", cn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cb.Items.Add(dr["nombre_dpto"].ToString());
                    ///el valor del combobox sera el id del departamento 
                    cb.ValueMember = (dr["id_departamento"].ToString());
                    cb.DisplayMember = (dr["nombre_dpto"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("no se lleno el cb " + ex.ToString());
            }

        }



        //

        public void catalogorutas(ComboBox cr)
        {

            try
            {
                cmd = new SqlCommand("Select nombre, id_catalogoruta from catalogorutas ", cn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cr.Items.Add(dr["nombre"].ToString());
                    ///el valor del combobox sera el id del departamento 
                    cr.ValueMember = (dr["id_catalogoruta"].ToString());
                    cr.DisplayMember = (dr["nombre"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("no se lleno el cb " + ex.ToString());
            }

        }
        //
        public void catalogous(ComboBox us)
        {

            try
            {
                cmd = new SqlCommand("Select nombre, id_usuario , contraseña from usuarios ", cn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    us.Items.Add(dr["nombre"].ToString());
                    ///el valor del combobox sera el id del departamento 
                    us.ValueMember = (dr["id_usuario"].ToString());
                    us.DisplayMember = (dr["nombre"].ToString());
                    //string contra = dr["contraseña"].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("no se lleno el cb " + ex.ToString());
            }

        }

        // catalogo unidades
        public void catalogounidades(ComboBox un)
        {

            try
            {
                cmd = new SqlCommand("Select eco, id_unidad from unidades ", cn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    un.Items.Add(dr["eco"].ToString());
                    ///el valor del combobox sera el id del departamento 
                    un.ValueMember = (dr["id_unidad"].ToString());
                    un.DisplayMember = (dr["eco"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("no se lleno el cb " + ex.ToString());
            }

        }



        // metodo para insertar un empleado a la base de datos 

        public string insertar(string txtnombre, string txtapellidos, string txttelefono, string txtseguro, string txtfecha, int id_dpto, string nomina, string txtcargo , string txtnac)
        {

            string salida = "registro correcto";
            try
            {

                //cmd = new SqlCommand("Insert into departamentos(nombre,apellidos,telefono,seguro,fecha_ingreso,id_departamento,cargo) values('" + txtnombre + "','" + txtapellidos + "','" + txttelefono + "','" + txtseguro + "','" + txtfecha + "'," + id_dpto + ",'" + txtcargo + "')", cn);
                //cmd.ExecuteNonQuery();
                cmd = new SqlCommand("Insert into empleados(nombre,apellidos,telefono,seguro,fecha_ingreso,id_departamento,no_nomina,cargo,fecha_nacimiento)values('" + txtnombre + "','" + txtapellidos + "','" + txttelefono + "','" + txtseguro + "','" + txtfecha + "'," + id_dpto + ",'" + nomina + "','" + txtcargo + "','"+txtnac+"')", cn);
                cmd.ExecuteNonQuery();

                //cn.Close();

            }
            catch (Exception ex)
            {

                salida = "no registrado:" + ex.ToString();

            }

            return salida;



        }



        
    }
}
