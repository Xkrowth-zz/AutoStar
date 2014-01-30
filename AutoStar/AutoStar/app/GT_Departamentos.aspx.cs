using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoStar.app
{
    public partial class GT_Departamentos : System.Web.UI.Page
    {
        protected void BindData()
        {
            if (!Page.IsPostBack)
            {
                DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LevelUp;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "listarEmpleados";
            //cmd.Connection = con;

            //    con.Open();
            //    GridView1.EmptyDataText = "No Records Found";
            //    GridView1.DataSource = cmd.ExecuteReader();
            //    GridView1.DataBind();

            //    con.Close();
            //    con.Dispose();


        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DataBind();
        }

        //This event shows how to delete a row on delete LinkButton click.

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connect"]);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            Label deleteId = (Label)GridView1.Rows[e.RowIndex].FindControl("idEmpleado");
            cmd.CommandText = "Delete from Empleado where idEmpleado='" + deleteId.Text + "'";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            DataBind();
        }

        //This event is used to show a row in editable mode.

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            DataBind();
        }

        //This event will update information in database.

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connect"]);
            //Accessing Edited values from the GridView
            string str_id = GridView1.Rows[e.RowIndex].Cells[0].Text; //ID
            string str_nombre = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text; //Company
            string str_apellido1 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text; //Name
            string str_apellido2 = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text; //Title
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update Empleados set nombre='" + str_nombre + "',apellido1='" + str_apellido1 + "',apellido2='" + str_apellido2 + "' where idEmpleado='" + str_id + "'";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            DataBind();
            con.Close();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void btn_departamentos_pnl_eliminar_eliminar_Click(object sender, EventArgs e)     // Panel Eliminar
        {
            SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connect"]);
            //Accessing Edited values from the GridView
            //string str_id =  //ID
            int idDepartamentos = int.Parse(txtfld_departamentos_pnl_eliminar_idDepartamento.Text);
            string descripcion = txtfld_departamentos_pnl_eliminar_descripcion.Text;  //Company
            string comentarios = txtfld_departamentos_pnl_eliminar_comentarios.Text; //Name


            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("deleteDepartamento", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idDepartamento", SqlDbType.Int).Value = idDepartamentos;
            cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
            cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
            cmd.ExecuteReader();
            //cmd.CommandText = "listarEmpleados";
            //GridView1.DataSource = cmd.ExecuteReader();
            DataBind();
            con.Close();

        }
        protected void btn_departamentos_pnl_eliminar_cancelar_Click(object sender, EventArgs e)
        {
            pnl_departamentos_eliminar.Enabled = false;
            pnl_departamentos_eliminar.Visible = false;
        }
        protected void btn_roles_pnl_crear_cancelar_Click(object sender, EventArgs e)        // Panel Nuevo
        {
            pnl_departamentos_crear.Enabled = false;
            pnl_departamentos_crear.Visible = false;

            
        }
        protected virtual void btn_departamentos_pnl_crear_crear_click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connect"]);
            //Accessing Edited values from the GridView
            //string str_id =  //ID
            //int idRol = int.Parse(txtfld_roles_pnl_crear_idRol.Text);
            string descripcion = txtfld_departamentos_pnl_crear_descripcion.Text;  //Company
            string comentarios = txtfld_departamentos_pnl_crear_comentarios.Text; //Name


            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insertDepartamento", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@index", SqlDbType.Int).Value = idRol;
            cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
            cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
            cmd.ExecuteReader();
            //cmd.CommandText = "listarEmpleados";
            //GridView1.DataSource = cmd.ExecuteReader();
            DataBind();
            con.Close();

        }
        protected void btn_departamentos_pnl_editar_cancelar_Click(object sender, EventArgs e)        // Panel Editar
        {
            pnl_departamentos_editar.Enabled = false;
            pnl_departamentos_editar.Visible = false;
        }
        protected void btn_departamentos_pnl_editar_editar_click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connect"]);
            //Accessing Edited values from the GridView
            //string str_id =  //ID
            int idDepartamento = int.Parse(txtfld_departamentos_pnl_editar_idDepartamento.Text);
            int idRol = int.Parse(txtfld_departamentos_pnl_editar_idDepartamento.Text);
            string descripcion = txtfld_departamentos_pnl_editar_descripcion.Text;  //Company
            string comentarios = txtfld_departamentos_pnl_editar_comentarios.Text; //Name


            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("updateDepartamento", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idDepartamento", SqlDbType.Int).Value = idDepartamento;
            //cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;
            cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
            cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
            cmd.ExecuteReader();
            //cmd.CommandText = "listarEmpleados";
            //GridView1.DataSource = cmd.ExecuteReader();
            DataBind();
            con.Close();
        }
        protected virtual void btn_departamentos_editar_click(object sender, EventArgs e)  // Opcion Editar
        {
            //Restriccion Deshabilita el Resto
            pnl_departamentos_crear.Visible = false;
            pnl_departamentos_crear.Enabled = false;

            pnl_departamentos_eliminar.Visible = false;
            pnl_departamentos_eliminar.Enabled = false;

            pnl_departamentos_editar.Visible = true;
            pnl_departamentos_editar.Enabled = true;



        }
        protected virtual void btn_departamentos_nuevo_click(object sender, EventArgs e)   // Opcion Nuevo
        {
            pnl_departamentos_editar.Visible = false;
            pnl_departamentos_editar.Enabled = false;

            pnl_departamentos_eliminar.Visible = false;
            pnl_departamentos_eliminar.Enabled = false;

            pnl_departamentos_crear.Visible = true;
            pnl_departamentos_crear.Enabled = true;



        }
        protected virtual void btn_departamentos_eliminar_click(object sender, EventArgs e)  //Opcion Eliminar
        {

            pnl_departamentos_editar.Visible = false;
            pnl_departamentos_editar.Enabled = false;

            pnl_departamentos_crear.Visible = false;
            pnl_departamentos_crear.Enabled = false;

            pnl_departamentos_eliminar.Visible = true;
            pnl_departamentos_eliminar.Enabled = true;
        }
        protected virtual void txtfld_departamentos_pnl_editar_idUsuario_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("Select nombre from empleados where idEmpleados ='" + txtfld_tareas_pnl_editar_idUsuario.Text + "'", conn);
            //cmd.CommandText = "listarEmpleados";
            //GridView1.DataSource = cmd.ExecuteReader();            
            //txtfld_tareas_pnl_editar_nombre.Text = cmd.ExecuteReader().ToString();
            //conn.Close();
        }
        protected virtual void txtfld_departamentos_pnl_eliminar_idUsuario_TextChanged(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=LevelUp;Integrated Security=True");
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("Select nombre from empleados where idEmpleados ='" + txtfld_tareas_pnl_editar_idUsuario.Text + "'", conn);
            //cmd.CommandText = "listarEmpleados";
            //GridView1.DataSource = cmd.ExecuteReader();            
            //txtfld_taraes_pnl_editar_nombre.Text = cmd.ExecuteReader().ToString();
            //conn.Close();
        }
    }
}