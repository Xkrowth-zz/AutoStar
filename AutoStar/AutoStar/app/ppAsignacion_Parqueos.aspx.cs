using System;
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
    public partial class ppAsignacion_Parqueos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void irAorden(object sender , ImageClickEventArgs e) 
        {

            Panel1.Visible = true;        
        }

        protected void btncerrar_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;

        }
        protected void btn_Asignar_Click(object sender, EventArgs e)
        {
            TextBox1.Visible = false;
            DropDownList1.Visible = true;
            
        }

        protected void dropdown_onSelectedIndexChanged(object sender, EventArgs e) 
        {
            SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connect"]);
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("ordenesBusqueda", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@valor", SqlDbType.Int).Value = DropDownList1.SelectedItem.Text;
            cmd.Parameters.Add("@campo", SqlDbType.NVarChar).Value = "Numero de Orden";            
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                TextBox1.Text = sdr[0].ToString();
                TextBox2.Text = sdr["idEstado"].ToString();
                TextBox3.Text = sdr["idTecnico"].ToString();
                TextBox4.Text = sdr["idArea"].ToString();
                TextBox5.Text = sdr["idAsesor"].ToString();
                TextBox6.Text = sdr["placa"].ToString();
                TextBox7.Text = sdr["fechaIngreso"].ToString();
                TextBox8.Text = sdr["comentarios"].ToString();
                TextBox9.Text = sdr["garantia"].ToString();
                TextBox10.Text = sdr["logistica"].ToString();
                TextBox11.Text = sdr["repuestos"].ToString();
                TextBox12.Text = sdr["cliente"].ToString();
             
            }
            
            
            con.Close();
            con.Dispose();
           
                     
       
        }
        
    }
}