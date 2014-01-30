using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoStar.app
{
    public partial class GT_Rol : System.Web.UI.Page
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

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            // Get the currently selected row. Because the SelectedIndexChanging event
            // occurs before the select operation in the GridView control, the
            // SelectedRow property cannot be used. Instead, use the Rows collection
            // and the NewSelectedIndex property of the e argument passed to this 
            // event handler.
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];
            //GridView1.SelectRow(e.NewSelectedIndex);


        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {

                // when mouse is over the row, save original color to new attribute, and change it to highlight color
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");

                // when mouse leaves the row, change the bg color to its original value  
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");


            }
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    GridView1.SelectedRow.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + GridView1.SelectedRow.RowIndex);

                    //GridView1.SetEditRow(row.RowIndex);
                    //GridView1.SelectRow(row.RowIndex);
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    //GridView1.SelectedRow.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = GridView1.BackColor;
                    //row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    //row.ToolTip = "Click to select this row.";
                }
            }
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                GridView1.SelectedIndex = e.Row.RowIndex;
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                Console.Write("This is the row index selected " + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";

            }
        }
        protected void btn_eliminarClick(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    GridView1.DeleteRow(row.RowIndex);
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = GridView1.BackColor;
                }
            }

        }
        protected void btn_editarClick(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    //GridView1.SelectedRow.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Edit$" + GridView1.SelectedRow.RowIndex);

                    GridView1.SetEditRow(row.RowIndex);                    
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");                    
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = GridView1.BackColor;
                }
            }

        }


        protected void btn_buscarClick(object sender, ImageClickEventArgs e)
        {


            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);


            String valor = TextBox1.Text;
            String campo = DropDownList1.SelectedItem.Text; 
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("rolesBusqueda", conn);
            cmd.CommandType = CommandType.StoredProcedure;            
            cmd.Parameters.Add("@valor", SqlDbType.NVarChar).Value = valor;
            cmd.Parameters.Add("@campo", SqlDbType.NVarChar).Value = campo;
            cmd.ExecuteReader();
            GridView1.DataBind();
            con.Close();

        }

        protected void btn_crearClick(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);

            String descripcion = ((TextBox)GridView1.FooterRow.FindControl("TextBox3")).Text;
            String comentarios = ((TextBox)GridView1.FooterRow.FindControl("TextBox4")).Text;
            
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("insertRol", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
            cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;

            cmd.ExecuteReader();
            DataBind();
            con.Close();
        }

        protected void btn_guardarClick(object sender, ImageClickEventArgs e)
        {
            // Iterates through the rows of the GridView control
            foreach (GridViewRow row in GridView1.Rows)
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);                
                int idRol = int.Parse(((Label)GridView1.SelectedRow.FindControl("Label1")).Text);
                string descripcion = ((TextBox)GridView1.SelectedRow.FindControl("TextBox1")).Text;
                string comentarios = ((TextBox)GridView1.SelectedRow.FindControl("TextBox2")).Text;
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("updateRol", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;                
                cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;                
                cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
                cmd.ExecuteReader();
                DataBind();
                con.Close();

            }


        }

 
    }
}