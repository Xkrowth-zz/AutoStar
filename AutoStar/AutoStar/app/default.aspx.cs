using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGT_AutoStar.app
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e) 
        { 
            bool Autenticado = false;
            Autenticado = LoginCorrecto(Login1.UserName, Login1.Password); 
            e.Authenticated = Autenticado;
            if (Autenticado)
            {
                Response.Redirect("Default.aspx");
            }

        }
        private bool LoginCorrecto(string Usuario, string Contrasena) 
        {

            //string connectionString = "Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True";
            //string queryString = "SELECT * FROM GT_Posicion";
            //DataSet dataset = new DataSet();

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlDataAdapter adapter = new SqlDataAdapter();
            //    adapter.SelectCommand = new SqlCommand(queryString, connection);
            //    //adapter.SelectCommand.Parameters.Add("@btn", SqlDbType.NVarChar).Value = valor; ;
            //    DataTable dt = new DataTable();
            //    adapter.Fill(dt);
                

            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        String tipo = dt.Rows[i]["tipo"].ToString();
            //        bool stat = bool.Parse(dt.Rows[i]["status"].ToString());
            //        String buttonID = dt.Rows[i]["posicion"].ToString();
            //        ImageButton c = (ImageButton)this.parqueo_Nivel_1.FindControl(buttonID);
            //        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + tipo + " Ocupado" + "');", true);
            //        if (!(c == null))
            //        {

            //            if (tipo == "parqueo")
            //            {
            //                if (stat == true)
            //                {
            //                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " Ocupado" + "');", true);
            //                    c.ImageUrl = "~/app/Images/icons/iconParqueoOcupado.png";
            //                }

            //                else
            //                {
            //                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " Libre" + "');", true);
            //                    c.ImageUrl = "~/app/Images/icons/iconParqueoLibre.png";
            //                }
            //            }

            //            else if (tipo == "bahia")
            //            {
            //                if (stat == true)
            //                {
            //                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " Ocupado" + "');", true);
            //                    c.ImageUrl = "~/app/Images/icons/iconBahiaOcupada.png";

            //                }

            //                else
            //                {

            //                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " Libre" + "');", true);
            //                    c.ImageUrl = "~/app/Images/icons/iconBahiaLibre.png";
            //                }

            //            }

            //            else if (tipo == "grua")
            //            {
            //                if (stat == true)
            //                {
            //                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " Ocupado" + "');", true);
            //                    c.ImageUrl = "~/app/Images/icons/iconGruaOcupada.png";

            //                }

            //                else
            //                {

            //                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " Libre" + "');", true);
            //                    c.ImageUrl = "~/app/Images/icons/iconGruaLibre.png";
            //                }

            //            }

            //        }




            //    }

            //    connection.Close();
            //    connection.Dispose();



            //}



            //if (Usuario.Equals("maestros") && Contrasena.Equals("delweb"))
            //{
            //    return true;
            //}
             
            return false;
        }
        
    
        
    }
}