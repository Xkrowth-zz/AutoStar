using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoStar.app
{
    public partial class GT_Acceso_Menu1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_buscarClick(object sender, ImageClickEventArgs e)
        {
            String valor = TextBox1.Text;
            String campo = DropDownList1.SelectedItem.Text;            
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("accesoBusquedas", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@valor", SqlDbType.NVarChar).Value = valor;
            cmd.Parameters.Add("@campo", SqlDbType.NVarChar).Value = campo;            
            cmd.ExecuteReader();
            DataBind();
            con.Close();

        }

        protected void lbInsert_Click(object sender, ImageClickEventArgs e)
        {

            String rol = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList5")).SelectedItem.Text;
            String opcion = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList4")).SelectedItem.Text;
            String comentarios = ((TextBox)GridView1.FooterRow.FindControl("TextBox7")).Text;
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);            
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insertAcceso", conn);
            cmd.CommandType = CommandType.StoredProcedure;            
            cmd.Parameters.Add("@rol", SqlDbType.NVarChar).Value = rol;
            cmd.Parameters.Add("@opcion", SqlDbType.NVarChar).Value = opcion;            
            cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
            cmd.ExecuteReader();
            DataBind();
            con.Close();
          
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

        protected void btn_guardarClick(object sender, ImageClickEventArgs e)
        {
            int idAcceso = int.Parse(((Label)GridView1.SelectedRow.FindControl("Label6")).Text);
            String rol = ((DropDownList)GridView1.SelectedRow.FindControl("DropDownList3")).SelectedItem.Text;
            String opcion = ((DropDownList)GridView1.SelectedRow.FindControl("DropDownList2")).SelectedItem.Text;
            String comentarios = ((TextBox)GridView1.SelectedRow.FindControl("TextBox2")).Text;
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("updateAcceso", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idAcceso", SqlDbType.Int).Value = idAcceso;
            cmd.Parameters.Add("@rol", SqlDbType.NVarChar).Value = rol;
            cmd.Parameters.Add("@opcion", SqlDbType.NVarChar).Value = opcion;
            cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
            cmd.ExecuteReader();
            DataBind();
            con.Close();

        }
        protected void btn_eliminar_Click(object sender, ImageClickEventArgs e)
        {

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
    }
}