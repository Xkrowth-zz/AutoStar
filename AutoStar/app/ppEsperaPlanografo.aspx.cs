using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace AutoStar.app
{
    public partial class ppEsperaPlanografo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            estado1.Controls.Clear();
            estado2.Controls.Clear();
            estado3.Controls.Clear();

            cargar_estado1(Session["Estados_botones"].ToString());
            cargar_estado2(Session["Estados_botones"].ToString());
            cargar_estado3(Session["Estados_botones"].ToString());
        }

        private void cargar_estado3(string idtecnico)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            //"select DISTINCT numero, horaInicio from GT_Ordenes where idTecnico = '" + idTecnico + "' and Area = '" + drpAreas.SelectedValue + "' ORDER by horaInicio ASC";
            string query2 = "select * from GT_Ordenes_Estado where idTecnico = '" + idtecnico + "' and Status = 'Trabajos de taller externo' ORDER by id ASC";
            con.Open();
            SqlCommand cmd2 = new SqlCommand(query2, con);
            SqlDataAdapter da_orden = new SqlDataAdapter(cmd2);
            DataTable dt_orden = new DataTable();
            da_orden.Fill(dt_orden);
            for (int x = 0; x < dt_orden.Rows.Count; x++)
            {
                Button boton = new Button();
                boton.CssClass = "btnEstadoEspera";
                boton.Text = dt_orden.Rows[x]["numero"].ToString();
                boton.ID = dt_orden.Rows[x]["numero"].ToString();
                boton.Click += new EventHandler(this.Estados_Click);
                boton.UseSubmitBehavior = false;
                //boton.OnClientClick="window.showModalDialog('http://localhost:1874/app/ppCrearPlanografo.aspx','Search','width=1025,height=700,left=150,top=200,scrollbars=1,toolbar=no,status=1')";
                estado3.Controls.Add(boton);
                estado3.Controls.Add(new LiteralControl("<br />"));

            }

            con.Close();


        }

        private void cargar_estado2(string idtecnico)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            string query2 = "select * from GT_Ordenes_Estado where idTecnico = '" + idtecnico + "' and Status = 'Pendiente de aprobación cliente' ORDER by id ASC";
            con.Open();
            SqlCommand cmd2 = new SqlCommand(query2, con);
            SqlDataAdapter da_orden = new SqlDataAdapter(cmd2);
            DataTable dt_orden = new DataTable();
            da_orden.Fill(dt_orden);
            for (int x = 0; x < dt_orden.Rows.Count; x++)
            {
                Button boton = new Button();
                boton.CssClass = "btnEstadoEspera";
                boton.Text = dt_orden.Rows[x]["numero"].ToString();
                boton.ID = dt_orden.Rows[x]["numero"].ToString();
                boton.Click += new EventHandler(this.Estados_Click);
                boton.UseSubmitBehavior = false;
                //boton.OnClientClick="window.showModalDialog('http://localhost:1874/app/ppCrearPlanografo.aspx','Search','width=1025,height=700,left=150,top=200,scrollbars=1,toolbar=no,status=1')";
                estado2.Controls.Add(boton);
                estado2.Controls.Add(new LiteralControl("<br />"));
            }

            con.Close();
        }

        private void cargar_estado1(string idtecnico)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            string query2 = "select * from GT_Ordenes_Estado where idTecnico = '" + idtecnico + "' and Status = 'Pendiente de repuestos' ORDER by id ASC";
            con.Open();
            SqlCommand cmd2 = new SqlCommand(query2, con);
            SqlDataAdapter da_orden = new SqlDataAdapter(cmd2);
            DataTable dt_orden = new DataTable();
            da_orden.Fill(dt_orden);
            for (int x = 0; x < dt_orden.Rows.Count; x++)
            {
                Button boton = new Button();
                boton.CssClass = "btnEstadoEspera";
                boton.Text = dt_orden.Rows[x]["numero"].ToString();
                boton.ID = dt_orden.Rows[x]["numero"].ToString();
                boton.Click += new EventHandler(this.Estados_Click);
                boton.UseSubmitBehavior = false;
               // boton.OnClientClick = "window.showModalDialog('http://localhost:1874/app/ppCrearPlanografo.aspx','Search','width=1025,height=700,left=150,top=200,scrollbars=1,toolbar=no,status=1')";
                estado1.Controls.Add(boton);
                estado1.Controls.Add(new LiteralControl("<br />"));
            }

            con.Close();
        }

        private void Estados_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.Date == DateTime.Now.Date)
            {
                Session["modificarOrdenesTecnicos"] = true;
                Button boton = (Button)sender;
                Session["drpestado"] = true;
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                string query2 = "select * from GT_Ordenes_Estado where numero = '" + boton.ID + "'";
                con.Open();
                SqlCommand cmd2 = new SqlCommand(query2, con);
                SqlDataAdapter da_orden = new SqlDataAdapter(cmd2);
                DataTable dt_orden = new DataTable();
                da_orden.Fill(dt_orden);

                if (dt_orden.Rows.Count > 0)
                {
                    Session["datosOrdenesTecnicos"] = dt_orden;
                    Session["botonID"] = boton.ID;
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "llamar_ventana();", true);
                    //drpTecnico.SelectedValue = dt_orden.Rows[0]["idTecnico"].ToString();
                    //drpOt.Items.Add(new ListItem(dt_orden.Rows[0]["numero"].ToString(), dt_orden.Rows[0]["numero"].ToString()));
                    //drpOt.SelectedValue = dt_orden.Rows[0]["numero"].ToString();
                    //drpOt.Enabled = false;
                    //drpOt.Visible = true;
                    //llenarCliente(boton.ID);
                    //ventana.Visible = true;
                }
            }
            else
            {
                MessageBoxShow(Page, "No se puede agregar en el día de mañana");
            }

        }

        private void MessageBoxShow(Page page, string message)
        {
            Literal ltr = new Literal();
            ltr.Text = @"<script type='text/javascript'> alert('" + message + "') </script>";
            page.Controls.Add(ltr);
        }

    }
}