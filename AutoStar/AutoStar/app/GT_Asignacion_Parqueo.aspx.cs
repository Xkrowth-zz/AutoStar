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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_bahiasClick(object sender, ImageClickEventArgs e)
        {
            Label1.Visible = true;
            DropDownList1.Visible = true;
            
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

            Panel1.Visible = true;        
        }

        protected void btncerrar_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            
        }
    }
}