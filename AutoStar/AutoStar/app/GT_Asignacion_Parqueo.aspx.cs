﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoStar.app
{
    public partial class GT_Asignacion_Parqueo : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["idUsuario"] == null))
            {

                string connectionString = "Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True";
                string queryString = "SELECT * FROM GT_Posicion";
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
                        String tipo = dt.Rows[i]["tipo"].ToString();
                        bool stat = bool.Parse(dt.Rows[i]["status"].ToString());
                        String buttonID = dt.Rows[i]["posicion"].ToString();
                        ImageButton c = (ImageButton)this.parqueo_Nivel_1.FindControl(buttonID);
                        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + tipo + " Ocupado" + "');", true);
                        if (!(c == null))
                        {

                            if (tipo == "parqueo")
                            {
                                if (stat == true)
                                {
                                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " Ocupado" + "');", true);
                                    c.ImageUrl = "~/app/Images/icons/iconParqueoOcupado.png";
                                }

                                else
                                {
                                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " Libre" + "');", true);
                                    c.ImageUrl = "~/app/Images/icons/iconParqueoLibre.png";
                                }
                            }

                            else if (tipo == "bahia")
                            {
                                if (stat == true)
                                {
                                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " Ocupado" + "');", true);
                                    c.ImageUrl = "~/app/Images/icons/iconBahiaOcupada.png";

                                }

                                else
                                {

                                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " Libre" + "');", true);
                                    c.ImageUrl = "~/app/Images/icons/iconBahiaLibre.png";
                                }

                            }

                            else if (tipo == "grua")
                            {
                                if (stat == true)
                                {
                                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " Ocupado" + "');", true);
                                    c.ImageUrl = "~/app/Images/icons/iconGruaOcupada.png";

                                }

                                else
                                {

                                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonID + " Libre" + "');", true);
                                    c.ImageUrl = "~/app/Images/icons/iconGruaLibre.png";
                                }

                            }

                        }




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
            


            //label1.Text = dt.Rows[0]["phone"].toString();




        }

        protected void btn_bahiasClick(object sender, ImageClickEventArgs e)
        {
            Label1.Visible = true;
            DropDownList1.Visible = true;            
            parqueo_Nivel_1.Visible = false;
            
        }
        protected void onIndexChanged(object sender , EventArgs e)
        {

            String selectedItem = DropDownList1.SelectedItem.Text;

            if (selectedItem == "Mercedez-Benz")
            {
                bahiasCDJR.Visible = false;
                bahiasMercedez.Visible = true;
            }
            else if (selectedItem == "CDJR")
            {
                bahiasMercedez.Visible = false;
                bahiasCDJR.Visible = true;
            }
        }
        protected void irAorden(object sender , ImageClickEventArgs e) 
        {
            
                    
        }

        //protected void btncerrar_Click(object sender, EventArgs e)
        //{
        //    Panel1.Visible = false;
            
        //}

        
        protected void Abrir_Click(object sender, EventArgs e)
        {
            string vtn = "window.open('GT_Usuarios.aspx','Dates','scrollbars=yes,resizable=yes','height=300', 'width=300')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }

        

        protected void parqueos_Click(object sender , ImageClickEventArgs e) 
        {
            bahiasCDJR.Visible = false; 
            bahiasMercedez.Visible = false;            
            Label1.Visible = false;
            DropDownList1.Visible = false;
            parqueo_Nivel_1.Visible = true;


        }

        protected void asignarParqueo(object sender , ImageClickEventArgs e) 
        {
            ImageButton buttonClicked = (ImageButton)sender;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonClicked.ID + "');", true);
        }
    }
}