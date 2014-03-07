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
    public partial class GT_Tiempos_Parada : System.Web.UI.Page
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
            if (!(Session["idUsuario"] == null))
            {

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Para ingresar debe iniciar session');", true);
                Response.Redirect("Default.aspx");
            }
        }
        protected void SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            // Get the currently selected row. Because the SelectedIndexChanging event
            // occurs before the select operation in the GridView control, the
            // SelectedRow property cannot be used. Instead, use the Rows collection
            // and the NewSelectedIndex property of the e argument passed to this 
            // event handler.
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];
            //GridView1.SelectRow(e.NewSelectedIndex);


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
                    //row.BackColor = ColorTranslator.FromHtml("#8E7070");
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
                    row.BackColor = ColorTranslator.FromHtml("#8E7070");

                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = GridView1.BackColor;

                }
            }

        }


        protected void btn_buscar_Click(object sender, ImageClickEventArgs e)
        {


            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);


            String valor = TextBox1.Text;
            String campo = DropDownList1.SelectedItem.Text;

            Console.Write("Esto es valor: " + valor + " Esto es campo: " + campo);

            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");

            conn.Open();

            SqlCommand cmd = new SqlCommand("tiemposBusqueda", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            if (valor == "" | campo == "")
            {
                valor = "vacio";
                campo = "vacio";
            }
            cmd.Parameters.Add("@valor", SqlDbType.NVarChar).Value = valor;
            cmd.Parameters.Add("@campo", SqlDbType.NVarChar).Value = campo;
            cmd.ExecuteReader();
            BindData();
            con.Close();

        }


        protected void btn_crear_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);            
            String area = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList2")).SelectedItem.Text;
            String descripcion = ((TextBox)GridView1.FooterRow.FindControl("TextBox7")).Text;
            String horaInicio = ((TextBox)GridView1.FooterRow.FindControl("TextBox6")).Text;
            int duracion = int.Parse(((TextBox)GridView1.FooterRow.FindControl("TextBox9")).Text);
            string comentarios = ((TextBox)GridView1.FooterRow.FindControl("TextBox10")).Text;            
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("insertTiempos", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@area", SqlDbType.NVarChar).Value = area;
            cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
            cmd.Parameters.Add("@horaInicio", SqlDbType.Time).Value = horaInicio;
            cmd.Parameters.Add("@duracion", SqlDbType.Int).Value = duracion;            
            cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
            

            cmd.ExecuteReader();
            BindData();
            con.Close();
        }

        protected void btn_guardar_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
            int idTiempos = int.Parse(((Label)GridView1.SelectedRow.FindControl("Label1")).Text);
            String area = ((DropDownList)GridView1.SelectedRow.FindControl("DropDownList3")).SelectedItem.Text;
            String descripcion = ((TextBox)GridView1.SelectedRow.FindControl("TextBox2")).Text;
            String horaInicio = ((TextBox)GridView1.SelectedRow.FindControl("TextBox3")).Text;
            int duracion = int.Parse(((TextBox)GridView1.SelectedRow.FindControl("TextBox4")).Text);
            string comentarios = ((TextBox)GridView1.SelectedRow.FindControl("TextBox5")).Text;
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("updateTiempos", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idTiempos", SqlDbType.Int).Value = idTiempos;
            cmd.Parameters.Add("@area", SqlDbType.NVarChar).Value = area;
            cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
            cmd.Parameters.Add("@horaInicio", SqlDbType.DateTime).Value = horaInicio;
            cmd.Parameters.Add("@duracion", SqlDbType.Int).Value = duracion;
            cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
            GridView1.EditIndex = -1;

            cmd.ExecuteReader();
            BindData();
            con.Close();



        }

        private Control GetControlThatCausedPostBack(Page page)
        {
            //initialize a control and set it to null
            Control ctrl = null;

            //get the event target name and find the control
            string ctrlName = page.Request.Params.Get("__EVENTTARGET");
            if (!String.IsNullOrEmpty(ctrlName))
                ctrl = page.FindControl(ctrlName);

            //return the control to the calling method
            return ctrl;
        }
    }
}