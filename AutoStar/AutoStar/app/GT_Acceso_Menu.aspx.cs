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
            if (!(Session["idUsuario"] == null))
            {
                string connectionString = "Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True";
                string queryString = "SELECT * FROM GT_Opcion_Menu JOIN GT_Acceso_Menu AS temp ON GT_Opcion_Menu.idOpcionMenu = temp.idOpcion  JOIN GT_Usuarios ON GT_Usuarios.idRol = temp.idRol WHERE idUsuario = " + Session["idUsuario"];

                DataSet dataset = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(queryString, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    bool tieneAcceso = false;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        String opcion = dt.Rows[i]["descripcion"].ToString();

                        if (opcion == "Configuracion General")
                        {
                            tieneAcceso = true;
                        }
                        
                    }

                    if (tieneAcceso == false)
                    {
                        Response.Redirect("GT_Configuracion_General.aspx");
                    }

                    connection.Close();
                    connection.Dispose();



                }

                
            }
            else 
            {
               ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Para ingresar debe iniciar session');", true);
               Response.Redirect("Default.aspx");
            }

        }      

        protected void btn_buscarClick(object sender, ImageClickEventArgs e)
        {
            try
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
            catch (Exception ex) 
            {

            }
            

        }

        protected void lbInsert_Click(object sender, ImageClickEventArgs e)
        {

            try 
            {
                String rol = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList5")).SelectedItem.Text;
                String opcion = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList4")).SelectedItem.Text;
                String comentarios = ((TextBox)GridView1.FooterRow.FindControl("TextBox7")).Text;
                bool status = ((CheckBox)GridView1.FooterRow.FindControl("CheckBox3")).Checked;
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("insertAcceso", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@rol", SqlDbType.NVarChar).Value = rol;
                cmd.Parameters.Add("@opcion", SqlDbType.NVarChar).Value = opcion;
                cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = status;
                cmd.ExecuteReader();
                DataBind();
                con.Close();
            }
            catch(Exception ex)
            {

            }
            
          
        }

        protected void btn_editar_Click(object sender, EventArgs e)
        {

            try 
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.RowIndex == GridView1.SelectedIndex)
                    {
                        
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
            catch(Exception ex)
            {

            }
            

        }

        protected void btn_guardarClick(object sender, ImageClickEventArgs e)
        {
            try 
            {
                int idAcceso = int.Parse(((Label)GridView1.SelectedRow.FindControl("Label6")).Text);
                String rol = ((DropDownList)GridView1.SelectedRow.FindControl("DropDownList3")).SelectedItem.Text;
                String opcion = ((DropDownList)GridView1.SelectedRow.FindControl("DropDownList2")).SelectedItem.Text;
                String comentarios = ((TextBox)GridView1.SelectedRow.FindControl("TextBox2")).Text;
                bool status = ((CheckBox)GridView1.SelectedRow.FindControl("CheckBox1")).Checked;
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("updateAcceso", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idAcceso", SqlDbType.Int).Value = idAcceso;
                cmd.Parameters.Add("@rol", SqlDbType.NVarChar).Value = rol;
                cmd.Parameters.Add("@opcion", SqlDbType.NVarChar).Value = opcion;
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = status;
                cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
                cmd.ExecuteReader();
                GridView1.EditIndex = -1;
                DataBind();
                con.Close();
            }
            catch(Exception ex)
            {

            }
            

        }
        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            try 
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
            catch(Exception ex)
            {

            }
            

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

        private void ChangeControlStatus(bool status)
        {

            foreach (Control c in Page.Controls)
                foreach (Control ctrl in c.Controls)

                    if (ctrl is TextBox)

                        ((TextBox)ctrl).Enabled = status;

                    else if (ctrl is Button)

                        ((Button)ctrl).Enabled = status;

                    else if (ctrl is RadioButton)

                        ((RadioButton)ctrl).Enabled = status;

                    else if (ctrl is ImageButton)

                        ((ImageButton)ctrl).Enabled = status;

                    else if (ctrl is CheckBox)

                        ((CheckBox)ctrl).Enabled = status;

                    else if (ctrl is DropDownList)

                        ((DropDownList)ctrl).Enabled = status;

                    else if (ctrl is HyperLink)

                        ((HyperLink)ctrl).Enabled = status;

                    else if (ctrl is GridView)

                        ((GridView)ctrl).Enabled = status;

        }
        private void ClearControls()
        {
            foreach (Control c in Page.Controls)
            {
                foreach (Control ctrl in c.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ((TextBox)ctrl).Text = string.Empty;
                    }
                }
            }
        }
    }
}