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
using System.Text.RegularExpressions;


namespace AutoStar.app
{
    public partial class GT_Estado_Orden_Trabajo : System.Web.UI.Page
    {
        private string SearchString = "";
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
        protected void btn_orden_eliminar_Click(object sender, EventArgs e)
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
        protected void btn_orden_editar_Click(object sender, EventArgs e)
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

        public string HighlightText(string InputTxt)
        {
            string Search_Str = txtSearch.Text;
            // Setup the regular expression and add the Or operator.
            Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);
            // Highlight keywords by calling the
            //delegate each time a keyword is found.
            return RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));
        }

        public string ReplaceKeyWords(Match m)
        {
            return ("<span class=highlight>" + m.Value + "</span>");
        }
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {

            
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);            
            

            String valor = txtSearch.Text;
            String campo = DropDownList1.SelectedItem.Text;

            Console.Write("Esto es valor: " + valor + " Esto es campo: " + campo);

            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");

            conn.Open();

            SqlCommand cmd = new SqlCommand("ordenesBusqueda", conn);           
            
            cmd.CommandType = CommandType.StoredProcedure;
            if(valor == "" | campo ==""){
                valor = "vacio";
                campo = "vacio";
            }
            cmd.Parameters.Add("@valor", SqlDbType.NVarChar).Value = valor;
            cmd.Parameters.Add("@campo", SqlDbType.NVarChar).Value = campo;
            cmd.ExecuteReader();
            GridView1.DataBind();
            con.Close();

        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            //  Simple clean up text to return the Gridview to it's default state
            txtSearch.Text = "";
            SearchString = "";
            GridView1.DataBind();
        }

        protected void link_insertClick(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
            int numeroOrden = int.Parse(((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_numeroOrden")).Text);
            String Asesor = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList5")).SelectedItem.Text;
            String Estado = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList2")).SelectedItem.Text;
            String Tecnico = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList3")).SelectedItem.Text;
            String Area = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList4")).SelectedItem.Text;
            string placa = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_placa")).Text;
            int dia = int.Parse(((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).SelectedItem.Text);
            int mes = int.Parse(((DropDownList)GridView1.FooterRow.FindControl("DropDownList7")).SelectedItem.Text);
            int año = int.Parse(((DropDownList)GridView1.FooterRow.FindControl("DropDownList8")).SelectedItem.Text);
            String garantia = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_garantia")).Text;
            String respuestas = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_respuestas")).Text;
            String logistica = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_logistica")).Text;
            string comentarios = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_comentarios")).Text;
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("insertOrden", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@numeroOrden", SqlDbType.Int).Value = numeroOrden;            
            cmd.Parameters.Add("@Asesor", SqlDbType.NVarChar).Value = Asesor;            
            cmd.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = Estado;            
            cmd.Parameters.Add("@Tecnico", SqlDbType.NVarChar).Value = Tecnico;
            cmd.Parameters.Add("@Area", SqlDbType.NVarChar).Value = Area;
            cmd.Parameters.Add("@placa", SqlDbType.NVarChar).Value = placa;
            cmd.Parameters.Add("@dia", SqlDbType.Int).Value = dia;
            cmd.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
            cmd.Parameters.Add("@año", SqlDbType.Int).Value = año;
            cmd.Parameters.Add("@garantia", SqlDbType.NVarChar).Value = garantia;
            cmd.Parameters.Add("@respuestas", SqlDbType.NVarChar).Value = respuestas;
            cmd.Parameters.Add("@logistica", SqlDbType.NVarChar).Value = logistica;
            cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;

            cmd.ExecuteReader();            
            DataBind();
            con.Close();
        }

        protected void btn_orden_guardar_Click(object sender, ImageClickEventArgs e)
        {
            // Iterates through the rows of the GridView control
            foreach (GridViewRow row in GridView1.Rows)
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
                //Accessing Edited values from the GridView
                //string str_id =  //ID
                int idOrdenTrabajo = int.Parse(((Label)GridView1.SelectedRow.FindControl("Label1")).Text);

                int numeroOrden = int.Parse(((TextBox)GridView1.SelectedRow.FindControl("txtfld_numeroOrden")).Text);
                String Asesor = ((DropDownList)GridView1.SelectedRow.FindControl("DropDownList12")).SelectedItem.Text;
                String Estado = ((DropDownList)GridView1.SelectedRow.FindControl("DropDownList15")).SelectedItem.Text;
                String Tecnico = ((DropDownList)GridView1.SelectedRow.FindControl("DropDownList14")).SelectedItem.Text;
                String placa = ((TextBox)GridView1.SelectedRow.FindControl("TextBox5")).Text;
                int dia = int.Parse(((DropDownList)GridView1.SelectedRow.FindControl("DropDownList9")).SelectedItem.Text);
                int mes = int.Parse(((DropDownList)GridView1.SelectedRow.FindControl("DropDownList10")).SelectedItem.Text);
                int año = int.Parse(((DropDownList)GridView1.SelectedRow.FindControl("DropDownList11")).SelectedItem.Text);
                TextBox comentarios = (TextBox)GridView1.SelectedRow.FindControl("TextBox8");
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("updateOrden", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idOrdenTrabajo", SqlDbType.Int).Value = idOrdenTrabajo;
                cmd.Parameters.Add("@numeroOrden", SqlDbType.Int).Value = numeroOrden;
                cmd.Parameters.Add("@Asesor", SqlDbType.NVarChar).Value = Asesor;
                cmd.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = Estado;
                cmd.Parameters.Add("@Tecnico", SqlDbType.NVarChar).Value = Tecnico;
                cmd.Parameters.Add("@placa", SqlDbType.NVarChar).Value = placa;
                cmd.Parameters.Add("@dia", SqlDbType.Int).Value = dia;
                cmd.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
                cmd.Parameters.Add("@año", SqlDbType.Int).Value = año;
                cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios.Text;
                cmd.ExecuteReader();
                DataBind();
                con.Close();

            }


        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}