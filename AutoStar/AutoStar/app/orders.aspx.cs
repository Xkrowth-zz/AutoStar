using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;




namespace AutoStar.app
{
    public partial class orders : System.Web.UI.Page
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
                cmd.CommandText = "Update Empleados set nombre='" + str_nombre + "',apellido1='" + str_apellido1 + "',apellido2='" + str_apellido2 + "' where idEmpleado='" + str_id+ "'";
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

        protected void Submit_Click1()
        {
 
        }
    }
}