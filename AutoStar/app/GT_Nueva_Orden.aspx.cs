using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoStar.app
{
    public partial class GT_Nueva_Orden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_nueva_orden_click(object sender , EventArgs e)
        {
            try
            {
                int numOrden = int.Parse(txtfld_numero_orden.Text);
                int idDepartamento = int.Parse(txtfld_departamento.Text);
                int idPrioridad = int.Parse(txtfld_prioridad.Text);
                int idRol = int.Parse(txtfld_rol.Text);
                string placa = txtfld_placa.Text;
                int idAsesor = int.Parse(txtfld_Asesor.Text);
                int idTecnico = int.Parse(txtfld_tecnico.Text);
                DateTime fechaIngreso = clndr_fecha_ingreso.SelectedDate;
                int idEstado = int.Parse(txtfld_estado.Text);
                string comentarios = txtfld_comentarios.Text;

                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("insertOrden", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@numOrden", SqlDbType.Int).Value = numOrden;
                cmd.Parameters.Add("@idDepartamento", SqlDbType.Int).Value = idDepartamento;
                cmd.Parameters.Add("@idPrioridad", SqlDbType.Int).Value = idPrioridad;
                cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;
                cmd.Parameters.Add("@idAsesor", SqlDbType.Int).Value = idAsesor;
                cmd.Parameters.Add("@idTecnico", SqlDbType.Int).Value = idTecnico;
                cmd.Parameters.Add("@idEstado", SqlDbType.Int).Value = idEstado;
                cmd.Parameters.Add("@fechaIngreso", SqlDbType.DateTime).Value = fechaIngreso;
                cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
                cmd.Parameters.Add("@placa", SqlDbType.NVarChar).Value = placa;

                cmd.ExecuteReader();
                //cmd.CommandText = "listarEmpleados";
                //GridView1.DataSource = cmd.ExecuteReader();
                DataBind();
                conn.Close();


            }
            catch (Exception exc)
            {
                Console.WriteLine("An error occurred: '{0}'", exc);
            }


        }
    }
}