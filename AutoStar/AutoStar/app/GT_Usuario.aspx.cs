using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoStar.app
{
    public partial class GT_Usuario : System.Web.UI.Page
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

            if(!Page.IsPostBack) 
            { 
            //Codificación 
            }

        }

        protected void lbInsert_Click(object sender, EventArgs e)
        {            
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
            //Accessing Edited values from the GridView
            //string str_id =  //ID
            string rol = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList2")).SelectedItem.Text;
            
            string comentarios = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_comentarios")).Text;
            string str_nombre = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_nombre")).Text;  //Company
            string str_apellido1 = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_apellido1")).Text;  //Name
            string str_apellido2 = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_apellido2")).Text;
            bool status = ((CheckBox)GridView1.FooterRow.FindControl("CheckBox3")).Checked;
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insertUsuario", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = str_nombre;
            cmd.Parameters.Add("@apellido1", SqlDbType.NVarChar).Value = str_apellido1;
            cmd.Parameters.Add("@apellido2", SqlDbType.NVarChar).Value = str_apellido2;
            cmd.Parameters.Add("@rol", SqlDbType.NVarChar).Value = rol;
            cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
            cmd.Parameters.Add("@status", SqlDbType.Bit).Value = status;
            cmd.ExecuteReader();
            //cmd.CommandText = "listarEmpleados";
            //GridView1.DataSource = cmd.ExecuteReader();
            DataBind();
            con.Close();
        } 





        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DataBind();
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            DataBind();
        }

        //This event will update information in database.

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs  e)
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
                    GridView1.EditIndex = -1;
                    row.BackColor = ColorTranslator.FromHtml("#8E7070");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = GridView1.BackColor;
                }
            }
        }

        protected void GridView1_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.ToolTip = "Click to select row";
                if (!(e.Row.RowIndex == GridView1.SelectedIndex))
                {

                    e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);

                }


            }
        }
        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    //GridView1.SelectedRow.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Delete$" + GridView1.SelectedRow.RowIndex);
                    GridView1.DeleteRow(row.RowIndex);
                    //GridView1.SetEditRow(row.RowIndex);
                    //GridView1.SelectRow(GridView1.SelectedIndex);
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
        protected void btn_editar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    //GridView1.SelectedRow.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Edit$" + GridView1.SelectedRow.RowIndex);

                    GridView1.SetEditRow(row.RowIndex);
                    //GridView1.SelectRow(GridView1.SelectedIndex);
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
        protected void btn_insertarClick(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
            String nombre = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_nombre")).Text;
            String apellido1 = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_apellido1")).Text;
            String apellido2 = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_apellido2")).Text;
            String rol = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_rol")).Text;
            String comentarios = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_comentarios")).Text;
            bool status = ((CheckBox)GridView1.FooterRow.FindControl("CheckBox3")).Checked;
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insertUsuario", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
            cmd.Parameters.Add("@apellido1", SqlDbType.NVarChar).Value = apellido1;
            cmd.Parameters.Add("@apellido2", SqlDbType.NVarChar).Value = apellido2;
            cmd.Parameters.Add("@rol", SqlDbType.NVarChar).Value = rol;
            cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
            cmd.Parameters.Add("@status", SqlDbType.Bit).Value = status;
            cmd.ExecuteReader();
            DataBind();
            con.Close();
        }

        protected void btn_buscarClick(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
            String valor = TextBox1.Text;
            String campo = DropDownList1.SelectedItem.Text;
            
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("usuariosBusqueda", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@valor", SqlDbType.NVarChar).Value = valor;
            cmd.Parameters.Add("@campo", SqlDbType.NVarChar).Value = campo;
            cmd.ExecuteReader();
            DataBind();
            con.Close();


        }

        protected void btn_guardarClick(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
            int idUsuario = int.Parse(((Label)GridView1.SelectedRow.FindControl("Label2")).Text);
            String nombre = ((TextBox)GridView1.SelectedRow.FindControl("txtfld_nombre")).Text;
            String apellido1 = ((TextBox)GridView1.SelectedRow.FindControl("txtfld_apellido1")).Text;
            String apellido2 = ((TextBox)GridView1.SelectedRow.FindControl("txtfld_apellido2")).Text;
            String rol = ((DropDownList)GridView1.SelectedRow.FindControl("DropDownList5")).SelectedItem.Text;
            String area = ((DropDownList)GridView1.SelectedRow.FindControl("DropDownList4")).SelectedItem.Text;
            String comentarios = ((TextBox)GridView1.SelectedRow.FindControl("txtfld_comentarios")).Text;
            bool status = ((CheckBox)GridView1.SelectedRow.FindControl("CheckBox1")).Checked;
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("updateUsuario", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
            cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
            cmd.Parameters.Add("@apellido1", SqlDbType.NVarChar).Value = apellido1;
            cmd.Parameters.Add("@apellido2", SqlDbType.NVarChar).Value = apellido2;
            cmd.Parameters.Add("@rol", SqlDbType.NVarChar).Value = rol;
            cmd.Parameters.Add("@area", SqlDbType.NVarChar).Value = area;
            cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
            cmd.Parameters.Add("@status", SqlDbType.Bit).Value = status;
            cmd.ExecuteReader();
            GridView1.EditIndex = -1;
            DataBind();
            con.Close();
        }
    }
}