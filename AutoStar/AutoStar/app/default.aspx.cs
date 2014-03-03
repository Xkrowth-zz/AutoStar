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
        protected string _contraseña;
        protected string _usuario;
        protected int idUsuario;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + Session["idUsuario"] +" al inicio');", true);
            if(!(Session["idUsuario"] == null))
            {
                panel_login.Visible = false;
                login.Visible = false;
                logout.Visible = true;
                if (!(Session["loggedin"] == null)) { loggedin.Text = Session["loggedin"].ToString(); } 
                string connectionString = "Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True";
                string queryString = "SELECT btn FROM GT_Opcion_Menu JOIN GT_Acceso_Menu AS temp ON GT_Opcion_Menu.idOpcionMenu = temp.idOpcion  JOIN GT_Usuarios ON GT_Usuarios.idRol = temp.idRol WHERE idUsuario = " + Session["idUsuario"];

                DataSet dataset = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(queryString, connection);
                    //adapter.SelectCommand.Parameters.Add("@btn", SqlDbType.NVarChar).Value = valor; ;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        String buttonID = dt.Rows[i]["btn"].ToString();
                        ImageButton c = (ImageButton)(this.Table1.FindControl(buttonID));
                        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + tipo + " Ocupado" + "');", true);
                        if (!(c == null))
                        {
                            c.Enabled = true;
                            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " Existe" + "');", true);


                        }
                        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " No Existe" + "');", true);
                    }

                    connection.Close();
                    connection.Dispose();



                }
            }
            else 
            {
                panel_login.Visible = true;
                login.Visible = true;
                logout.Visible = false;
            }
            
        }

        protected void Login1_Authenticate(object sender, EventArgs e) 
        { 
            bool Autenticado = false;
            Autenticado = LoginCorrecto(usuario.Text, contraseña.Text);             
            if (Autenticado)
            {
                panel_login.Visible = false;
                login.Visible = false;
                logout.Visible = true;
                if (!(Session["loggedin"] == null)) { loggedin.Text = Session["loggedin"].ToString(); }
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + idUsuario + " al login');", true);
                string connectionString = "Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True";
                string queryString = "SELECT btn FROM GT_Opcion_Menu JOIN GT_Acceso_Menu AS temp ON GT_Opcion_Menu.idOpcionMenu = temp.idOpcion  JOIN GT_Usuarios ON GT_Usuarios.idRol = temp.idRol WHERE idUsuario = "+ Session["idUsuario"];

                DataSet dataset = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(queryString, connection);
                    //adapter.SelectCommand.Parameters.Add("@btn", SqlDbType.NVarChar).Value = valor; ;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        String buttonID = dt.Rows[i]["btn"].ToString();
                        ImageButton c = (ImageButton)(this.Table1.FindControl(buttonID));
                        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + tipo + " Ocupado" + "');", true);
                        if (!(c == null))
                        {
                            c.Enabled = true;
                            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " Existe" + "');", true);


                        }
                        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " No Existe" + "');", true);
                    }

                    connection.Close();
                    connection.Dispose();



                }



                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('entro');", true);
                //Response.Redirect("Default.aspx");
            }

        }
        private bool LoginCorrecto(string Usuario, string Contrasena) 
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('loginCorrecto');", true);
            string connectionString = "Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True";
            //string queryString = "SELECT btn FROM GT_Opcion_Menu JOIN GT_Acceso_Menu AS temp ON GT_Opcion_Menu.idOpcionMenu = temp.idOpcion  JOIN GT_Usuarios ON GT_Usuarios.idRol = temp.idRol WHERE nickname = @nickname AND password = @password";
            string queryString = "SELECT * FROM GT_Usuarios WHERE nickname=@nickname and password = @password";
            DataSet dataset = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(queryString, connection);
                adapter.SelectCommand.Parameters.Add("@nickname", SqlDbType.NVarChar).Value = Usuario;
                adapter.SelectCommand.Parameters.Add("@password", SqlDbType.NVarChar).Value = Contrasena;
                //adapter.SelectCommand.Parameters.Add("@btn", SqlDbType.NVarChar).Value = valor; ;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Session["idUsuario"] = int.Parse(dt.Rows[0]["idUsuario"].ToString());
                    Session["loggedin"] = dt.Rows[0]["nombre"].ToString();
                    connection.Close();
                    connection.Dispose();
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('return true');", true);
                    return true;
                }
                else 
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "El usuario o la contraseña es incorrecto", "alert('El usuario o la contraseña es incorrecto');", true);
                    connection.Close();
                    connection.Dispose();
                    
                    return false;
                }
                
            }           
             
           
        }

        protected void logout_Click(object sender , ImageClickEventArgs e) 
        {
            panel_login.Visible = true;
            login.Visible = true;
            logout.Visible = false;
            Session["loggedin"] = null;
            Session["idUsuario"] = null;
            loggedin.Text = "";
        }
        
    
        
    }
}