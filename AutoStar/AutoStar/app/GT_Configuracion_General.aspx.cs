using System;
using System.Collections.Generic;
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

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Para ingresar debe iniciar session');", true);
                Response.Redirect("Default.aspx");
            }
        }
    }
}