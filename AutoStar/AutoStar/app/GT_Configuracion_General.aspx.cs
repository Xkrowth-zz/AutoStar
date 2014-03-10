using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGT_AutoStar.app
{
    public partial class configGeneral : System.Web.UI.Page
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
    }
}