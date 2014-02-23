using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoStar.app
{
    public partial class GT_Parametros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_crearClick(object sender, ImageClickEventArgs e)
        {
            string slideshow = ((TextBox)GridView1.FooterRow.FindControl("TextBox4")).Text;
            string avisoAmarillo = ((TextBox)GridView1.FooterRow.FindControl("TextBox5")).Text;
            string avisoRojo = ((TextBox)GridView1.FooterRow.FindControl("TextBox6")).Text;
            bool status = ((CheckBox)GridView1.FooterRow.FindControl("CheckBox3")).Checked;
            string comentarios = ((TextBox)GridView1.FooterRow.FindControl("TextBox8")).Text;


            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insertParametro", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@slideShow", SqlDbType.Int).Value = slideshow;
            cmd.Parameters.Add("@status", SqlDbType.Bit).Value = status;
            cmd.Parameters.Add("@avisoRojo", SqlDbType.Int).Value = avisoRojo;
            cmd.Parameters.Add("@avisoAmarillo", SqlDbType.Int).Value = avisoAmarillo;
            cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;

            cmd.ExecuteReader();
            DataBind();
            con.Close();
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
        protected void btn_guardarClick(object sender, ImageClickEventArgs e) 
        {
            int idParametro = int.Parse(((Label)GridView1.SelectedRow.FindControl("Label1")).Text);
            string slideshow = ((TextBox)GridView1.SelectedRow.FindControl("TextBox1")).Text;
            string avisoAmarillo = ((TextBox)GridView1.SelectedRow.FindControl("TextBox2")).Text;
            string avisoRojo = ((TextBox)GridView1.SelectedRow.FindControl("TextBox3")).Text;
            bool status = ((CheckBox)GridView1.SelectedRow.FindControl("CheckBox1")).Checked;
            string comentarios = ((TextBox)GridView1.SelectedRow.FindControl("TextBox7")).Text;

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("updateParametro", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@slideShow", SqlDbType.Int).Value = slideshow;
            cmd.Parameters.Add("@status", SqlDbType.Bit).Value = status;
            cmd.Parameters.Add("@avisoRojo", SqlDbType.Int).Value = avisoRojo;
            cmd.Parameters.Add("@avisoAmarillo", SqlDbType.Int).Value = avisoAmarillo;
            cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;

            cmd.ExecuteReader();
            DataBind();
            con.Close();
        }
        protected void btn_eliminarClick(object sender, ImageClickEventArgs e) 
        {
            int idParametro = int.Parse(((Label)GridView1.SelectedRow.FindControl("Label5")).Text);
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("deleteParametro", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idParametro", SqlDbType.Int).Value = idParametro;
            cmd.ExecuteReader();
            DataBind();
            con.Close();
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

        
        
    }
}