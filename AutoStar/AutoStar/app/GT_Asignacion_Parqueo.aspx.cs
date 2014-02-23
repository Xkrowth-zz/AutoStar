using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoStar.app
{
    public partial class GT_Asignacion_Parqueo : System.Web.UI.Page
    {
        int ordenbahia1 = 0; int ordenbahia11 = 0;
        int ordenbahia2 = 0; int ordenbahia12 = 0;
        int ordenbahia3 = 0; int ordenbahia13 = 0;
        int ordenbahia4 = 0; int ordenbahia14 = 0;
        int ordenbahia5 = 0; int ordenbahia15 = 0;
        int ordenbahia6 = 0; int ordenbahia16 = 0;
        int ordenbahia7 = 0; int ordenbahia17 = 0;
        int ordenbahia8 = 0; 
        int ordenbahia9 = 0; 
        int ordenbahia10 = 0;

        int grua1, grua2, grua3, grua4 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_bahiasClick(object sender, ImageClickEventArgs e)
        {
            Label1.Visible = true;
            DropDownList1.Visible = true;
            Label2.Visible = false;
            DropDownList2.Visible = false;
            parqueo_Nivel_1.Visible = false;
            parqueo_nivel_2.Visible = false;
            parqueo_nivel_3.Visible = false;
            
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

        protected void DropDownList2_onSelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownList2.SelectedItem.Value == "Nivel 1")
            {
                parqueo_Nivel_1.Visible = true;
                parqueo_nivel_2.Visible = false;
                parqueo_nivel_3.Visible = false;
            }
            else if (DropDownList2.SelectedItem.Value == "Nivel 2")
            {
                parqueo_Nivel_1.Visible = false;
                parqueo_nivel_2.Visible = true;
                parqueo_nivel_3.Visible = false;
            }
            else if (DropDownList2.SelectedItem.Value == "Nivel 3")
            {
                parqueo_Nivel_1.Visible = false;
                parqueo_nivel_2.Visible = false;
                parqueo_nivel_3.Visible = true;
            }
        }

        protected void parqueos_Click(object sender , ImageClickEventArgs e) 
        {
            bahiasCDJR.Visible = false; 
            bahiasMercedez.Visible = false;
            Label2.Visible = true;
            DropDownList2.Visible = true;
            Label1.Visible = false;
            DropDownList1.Visible = false;

        }

        protected void asignarParqueo(object sender , ImageClickEventArgs e) 
        {
            ImageButton buttonClicked = (ImageButton)sender;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + buttonClicked.ID + "');", true);
        }
    }
}