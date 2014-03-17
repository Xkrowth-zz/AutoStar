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

                        if (opcion == "Orden de Trabajo")
                        {
                            tieneAcceso = true;
                        }

                    }

                    if (tieneAcceso == false)
                    {
                        Response.Redirect("default.aspx");
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
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                                
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    e.Row.ToolTip = "Click to select row";
                    e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);

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
        protected void btn_orden_editar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    //GridView1.SelectedRow.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Edit$" + GridView1.SelectedRow.RowIndex);

                    GridView1.SetEditRow(row.RowIndex);                                        
                    row.BackColor = ColorTranslator.FromHtml("#8E7070");                    
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ((Label)GridView1.SelectedRow.FindControl("Label7")).Text.ToString() + " Ocupado" + "');", true);
                    
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = GridView1.BackColor;
                    
                }
            }

        }       

        
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try 
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);


                String valor = txtSearch.Text;
                String campo = DropDownList1.SelectedItem.Text;

                Console.Write("Esto es valor: " + valor + " Esto es campo: " + campo);

                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");

                conn.Open();

                SqlCommand cmd = new SqlCommand("ordenesBusqueda", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                if (valor == "" | campo == "")
                {
                    valor = "vacio";
                    campo = "vacio";
                }
                cmd.Parameters.Add("@valor", SqlDbType.NVarChar).Value = valor;
                cmd.Parameters.Add("@campo", SqlDbType.NVarChar).Value = campo;
                cmd.ExecuteReader();
                GridView1.DataBind();
                con.Close();
            }
            catch(Exception ex)
            {

            }
            
            

        }


        protected void link_insertClick(object sender, EventArgs e)
        {
            try 
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["connect"]);
                int numeroOrden = int.Parse(((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_numeroOrden")).Text);
                String Asesor = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList5")).SelectedItem.Text;
                String Estado = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList2")).SelectedItem.Text;
                String Tecnico = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList3")).SelectedItem.Text;
                String Area = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList4")).SelectedItem.Text;
                string placa = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_placa")).Text;
                String fecha = ((TextBox)GridView1.FooterRow.FindControl("TextBox14")).Text;
                String garantia = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_garantia")).Text;
                String repuestos = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_repuestos")).Text;
                String logistica = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_logistica")).Text;
                string comentarios = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_comentarios")).Text;
                string cliente = ((TextBox)GridView1.FooterRow.FindControl("txtfld_insert_cliente")).Text;
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");

                fecha = DateTime.Parse(fecha).ToString("dd/MM/yyyy");

                conn.Open();

                SqlCommand cmd = new SqlCommand("insertOrden", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@numeroOrden", SqlDbType.Int).Value = numeroOrden;
                cmd.Parameters.Add("@Asesor", SqlDbType.NVarChar).Value = Asesor;
                cmd.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = Estado;
                cmd.Parameters.Add("@Tecnico", SqlDbType.NVarChar).Value = Tecnico;
                cmd.Parameters.Add("@Area", SqlDbType.NVarChar).Value = Area;
                cmd.Parameters.Add("@placa", SqlDbType.NVarChar).Value = placa;
                cmd.Parameters.Add("@fechaIngreso", SqlDbType.NVarChar).Value = fecha;
                cmd.Parameters.Add("@garantia", SqlDbType.NVarChar).Value = garantia;
                cmd.Parameters.Add("@repuestos", SqlDbType.NVarChar).Value = repuestos;
                cmd.Parameters.Add("@logistica", SqlDbType.NVarChar).Value = logistica;
                cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
                cmd.Parameters.Add("@cliente", SqlDbType.NVarChar).Value = cliente;

                cmd.ExecuteReader();
                GridView1.DataBind();
                con.Close();
                
            }
            catch(Exception ex)
            {

            }
                
            
            
        }

        protected void btn_orden_guardar_Click(object sender, ImageClickEventArgs e)
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
                String area = ((DropDownList)GridView1.SelectedRow.FindControl("DropDownList13")).SelectedItem.Text;
                String fecha = ((TextBox)GridView1.SelectedRow.FindControl("TextBox2")).Text;
                String repuestos = ((TextBox)GridView1.SelectedRow.FindControl("TextBox9")).Text;
                String logistica = ((TextBox)GridView1.SelectedRow.FindControl("TextBox13")).Text;
                String garantia = ((TextBox)GridView1.SelectedRow.FindControl("TextBox11")).Text;
                String comentarios = ((TextBox)GridView1.SelectedRow.FindControl("TextBox8")).Text;
                String cliente = ((TextBox)GridView1.SelectedRow.FindControl("TextBox1")).Text;



                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + fecha + " UPDATE');", true);



                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("updateOrden", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idOrdenTrabajo", SqlDbType.Int).Value = idOrdenTrabajo;
                cmd.Parameters.Add("@numeroOrden", SqlDbType.Int).Value = numeroOrden;
                cmd.Parameters.Add("@Asesor", SqlDbType.NVarChar).Value = Asesor;
                cmd.Parameters.Add("@area", SqlDbType.NVarChar).Value = area;
                cmd.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = Estado;
                cmd.Parameters.Add("@Tecnico", SqlDbType.NVarChar).Value = Tecnico;
                cmd.Parameters.Add("@placa", SqlDbType.NVarChar).Value = placa;
                cmd.Parameters.Add("@fechaIngreso", SqlDbType.NVarChar).Value = fecha;
                cmd.Parameters.Add("@comentarios", SqlDbType.NVarChar).Value = comentarios;
                cmd.Parameters.Add("@repuestos", SqlDbType.NVarChar).Value = repuestos;
                cmd.Parameters.Add("@logistica", SqlDbType.NVarChar).Value = logistica;
                cmd.Parameters.Add("@garantia", SqlDbType.NVarChar).Value = garantia;
                cmd.Parameters.Add("@cliente", SqlDbType.NVarChar).Value = cliente;

                cmd.ExecuteReader();
                GridView1.EditIndex = -1;
                GridView1.DataBind();
                con.Close();
            
                

            

        }

        protected void fecha(object sender , EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ((TextBox)GridView1.FooterRow.FindControl("TextBox14")).Text + " metodo fecha');", true);
        }

        
    }
}