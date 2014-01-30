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
    public partial class GT_Planografo_Digital : System.Web.UI.Page
    {

        int pos_dt_orden = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ventana.Visible = false;
                cargarOrdenes();
                cargarTecnicos();
                cargarHoras();
                cargarStatus();

                if (Session["fecha_consulta"] != null && !Session["fecha_consulta"].Equals(""))
                {
                    fecha_actual.Text = Session["fecha_consulta"].ToString();
                    DateTime fecha = DateTime.Parse(Session["fecha_consulta"].ToString());
                    if (fecha.Date != DateTime.Now.Date)
                    {
                        btndias.Enabled = false;
                        btnatras.Enabled = true;
                    }
                    else
                    {
                        btndias.Enabled = true;
                        btnatras.Enabled = false;
                    }
                }
                else
                {
                    DateTime fecha = DateTime.Now;
                    Session["fecha_consulta"] = fecha.Date.ToString("d");
                    fecha_actual.Text = fecha.Date.ToString("d");
                    btnatras.Enabled = false;
                }
            }
            

            crearTabla();

        }


        #region CARGAR DROPDOWNLIST
        private void cargarStatus()
        {
            drpStatus.Items.Clear();

            ListItem pr = new ListItem("En proceso", "En proceso");
            ListItem pr2 = new ListItem("Programada", "Programada");
            ListItem pr3 = new ListItem("Finalizada", "Finalizada");
            ListItem pr4 = new ListItem("Activa", "Activa");
            ListItem pr5 = new ListItem("Finalizada", "Finalizada");
            ListItem pr6 = new ListItem("Aire Acondicionado", "Aire Acondicionado");
            ListItem pr7 = new ListItem("Alineado", "Alineado");
            ListItem pr8 = new ListItem("Control de calidad", "Control de calidad");

            drpStatus.Items.Add(pr);
            drpStatus.Items.Add(pr2);
            drpStatus.Items.Add(pr3);
            drpStatus.Items.Add(pr4);
            drpStatus.Items.Add(pr5);
            drpStatus.Items.Add(pr6);
            drpStatus.Items.Add(pr7);
            drpStatus.Items.Add(pr8);
        }

        private void cargarHoras()
        {
            //drpHoraFinal.Items.Clear();
            drpHoraInicio.Items.Clear();

            ListItem pr = new ListItem("7:30:00", "7:30:00");
            ListItem pr2 = new ListItem("7:45:00", "7:45:00");
            ListItem pr3 = new ListItem("8:00:00", "8:00:00");
            ListItem pr4 = new ListItem("8:15:00", "8:15:00");
            ListItem pr5 = new ListItem("8:30:00", "8:30:00");
            ListItem pr6 = new ListItem("8:45:00", "8:45:00");
            ListItem pr7 = new ListItem("9:00:00", "9:00:00");
            ListItem pr8 = new ListItem("9:15:00", "9:15:00");
            ListItem pr9 = new ListItem("9:30:00", "9:30:00");
            ListItem pr10 = new ListItem("10:00:00", "10:00:00");
            ListItem pr11 = new ListItem("10:15:00", "10:15:00");
            ListItem pr12 = new ListItem("10:30:00", "10:30:00");
            ListItem pr13 = new ListItem("10:45:00", "10:45:00");
            ListItem pr14 = new ListItem("11:00:00", "11:00:00");
            ListItem pr14s = new ListItem("11:15:00", "11:15:00");
            ListItem pr15 = new ListItem("11:30:00", "11:30:00");
            ListItem pr16 = new ListItem("11:45:00", "11:45:00");
            ListItem pr17 = new ListItem("12:00:00", "12:00:00");
            ListItem pr18 = new ListItem("12:15:00", "12:15:00");
            ListItem pr19 = new ListItem("12:30:00", "12:30:00");
            ListItem pr20 = new ListItem("12:45:00", "12:45:00");
            ListItem pr21 = new ListItem("13:00:00", "13:00:00");
            ListItem pr22 = new ListItem("13:15:00", "13:15:00");
            ListItem pr23 = new ListItem("13:30:00", "13:30:00");
            ListItem pr24 = new ListItem("13:45:00", "13:45:00");
            ListItem pr25 = new ListItem("14:00:00", "14:00:00");
            ListItem pr26 = new ListItem("14:15:00", "14:15:00");
            ListItem pr27 = new ListItem("14:30:00", "14:30:00");
            ListItem pr28 = new ListItem("14:45:00", "14:45:00");
            ListItem pr29 = new ListItem("15:00:00", "15:00:00");
            ListItem pr30 = new ListItem("15:15:00", "15:15:00");
            ListItem pr31 = new ListItem("15:30:00", "15:30:00");
            ListItem pr32 = new ListItem("15:45:00", "15:45:00");
            ListItem pr33 = new ListItem("16:00:00", "16:30:00");
            ListItem pr34 = new ListItem("16:15:00", "16:15:00");
            ListItem pr35 = new ListItem("16:30:00", "16:30:00");
            ListItem pr36 = new ListItem("16:45:00", "16:45:00");
            ListItem pr37 = new ListItem("17:00:00", "17:00:00");
            ListItem pr38 = new ListItem("17:15:00", "17:15:00");
            ListItem pr39 = new ListItem("17:30:00", "17:30:00");

            drpHoraInicio.Items.Add(pr);
            //drpHoraFinal.Items.Add(pr);

            drpHoraInicio.Items.Add(pr2);
            //drpHoraFinal.Items.Add(pr2);

            drpHoraInicio.Items.Add(pr3);
            //drpHoraFinal.Items.Add(pr3);

            drpHoraInicio.Items.Add(pr4);
            //drpHoraFinal.Items.Add(pr4);

            drpHoraInicio.Items.Add(pr5);
            //drpHoraFinal.Items.Add(pr5);

            drpHoraInicio.Items.Add(pr6);
            //drpHoraFinal.Items.Add(pr6);

            drpHoraInicio.Items.Add(pr7);
            //drpHoraFinal.Items.Add(pr7);

            drpHoraInicio.Items.Add(pr8);
            //drpHoraFinal.Items.Add(pr8);

            drpHoraInicio.Items.Add(pr9);
            //drpHoraFinal.Items.Add(pr9);

            drpHoraInicio.Items.Add(pr10);
            //drpHoraFinal.Items.Add(pr10);

            drpHoraInicio.Items.Add(pr11);
            //drpHoraFinal.Items.Add(pr11);

            drpHoraInicio.Items.Add(pr12);
            //drpHoraFinal.Items.Add(pr12);

            drpHoraInicio.Items.Add(pr13);
            //drpHoraFinal.Items.Add(pr13);

            drpHoraInicio.Items.Add(pr14);
            //drpHoraFinal.Items.Add(pr14);

            drpHoraInicio.Items.Add(pr14s);
            //drpHoraFinal.Items.Add(pr14s);

            drpHoraInicio.Items.Add(pr15);
            //drpHoraFinal.Items.Add(pr15);

            drpHoraInicio.Items.Add(pr16);
            //drpHoraFinal.Items.Add(pr16);

            drpHoraInicio.Items.Add(pr17);
            // drpHoraFinal.Items.Add(pr17);

            drpHoraInicio.Items.Add(pr18);
            //drpHoraFinal.Items.Add(pr18);

            drpHoraInicio.Items.Add(pr19);
            //drpHoraFinal.Items.Add(pr19);

            drpHoraInicio.Items.Add(pr20);
            //drpHoraFinal.Items.Add(pr20);

            drpHoraInicio.Items.Add(pr21);
            //drpHoraFinal.Items.Add(pr21);

            drpHoraInicio.Items.Add(pr22);
            //drpHoraFinal.Items.Add(pr22);

            drpHoraInicio.Items.Add(pr23);
            //drpHoraFinal.Items.Add(pr23);

            drpHoraInicio.Items.Add(pr24);
            //drpHoraFinal.Items.Add(pr24);

            drpHoraInicio.Items.Add(pr25);
            //drpHoraFinal.Items.Add(pr25);

            drpHoraInicio.Items.Add(pr26);
            //drpHoraFinal.Items.Add(pr26);

            drpHoraInicio.Items.Add(pr27);
            //drpHoraFinal.Items.Add(pr27);

            drpHoraInicio.Items.Add(pr28);
            //drpHoraFinal.Items.Add(pr28);

            drpHoraInicio.Items.Add(pr29);
            //drpHoraFinal.Items.Add(pr29);

            drpHoraInicio.Items.Add(pr30);
            //drpHoraFinal.Items.Add(pr30);

            drpHoraInicio.Items.Add(pr31);
            //drpHoraFinal.Items.Add(pr31);

            drpHoraInicio.Items.Add(pr32);
            //drpHoraFinal.Items.Add(pr32);

            drpHoraInicio.Items.Add(pr33);
            //drpHoraFinal.Items.Add(pr33);

            drpHoraInicio.Items.Add(pr34);
            // drpHoraFinal.Items.Add(pr34);

            drpHoraInicio.Items.Add(pr35);
            //drpHoraFinal.Items.Add(pr35);

            drpHoraInicio.Items.Add(pr36);
            //drpHoraFinal.Items.Add(pr36);

            drpHoraInicio.Items.Add(pr37);
            //drpHoraFinal.Items.Add(pr37);

            drpHoraInicio.Items.Add(pr38);
            //drpHoraFinal.Items.Add(pr38);

            drpHoraInicio.Items.Add(pr39);
            //drpHoraFinal.Items.Add(pr39);
        }

        private void cargarTecnicos()
        {
            drpTecnico.Items.Clear();

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            string query = "SELECT * FROM [GT_AutoStar].[dbo].[GT_Tecnicos]";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            drpTecnico.DataSource = dt;
            drpTecnico.DataValueField = "idTecnico";
            drpTecnico.DataTextField = "nombre";
            drpTecnico.DataBind();
        }

        private void cargarOrdenes()
        {
            drpOt.Items.Clear();

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            string query = "select [numeroOrden] FROM [GT_AutoStar].[dbo].[GT_Orden_Trabajo] left join [GT_AutoStar].[dbo].[GT_Ordenes]  on [GT_Orden_Trabajo].[numeroOrden] = [GT_Ordenes].[numero] where [GT_Ordenes].[idOrdenes] is null";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            drpOt.DataSource = dt;
            drpOt.DataValueField = "numeroOrden";
            drpOt.DataTextField = "numeroOrden";
            drpOt.DataBind();
        }
        #endregion

        #region PLANOGRAFO

        protected string crearTabla()
        {

            string tabla = ""; // "<tr><td class='tableCellPlanografoHoras'>Hola</td></tr>";

            //SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connect"]);
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            string query = "select * from GT_Tecnicos order by idTecnico Desc";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);



            for (int x = 0; x < dt.Rows.Count; x++) //ciclo para recorrer los tecnicos
            {
                pos_dt_orden = 0;
                string idtecnico = dt.Rows[x]["idTecnico"].ToString();
                string query2 = "select * from GT_Ordenes where idTecnico = '" + idtecnico + "' ORDER by horaInicio ASC";

                SqlCommand cmd2 = new SqlCommand(query2, con);
                SqlDataAdapter da_orden = new SqlDataAdapter(cmd2);
                DataTable dt_orden = new DataTable();
                da_orden.Fill(dt_orden);

                /* Obtener las ordenes de cada tecnico */

                if (dt_orden.Rows.Count > 0) // preguntamos si se encontro alguna orden
                {
                    // tabla += "<tr> <td class='tableCellPlanografoTecnicos'> <label class='labelTecnicos'>" + dt.Rows[x]["nombre"].ToString() + "</label></td>";
                    TableRow tRow = new TableRow();
                    TableCell tCell = new TableCell();

                    tCell.CssClass = "tableCellPlanografoTecnicos";
                    Label etiqueta = new Label();
                    etiqueta.CssClass = "labelTecnicos";
                    etiqueta.Text = dt.Rows[x]["nombre"].ToString();

                    tCell.Controls.Add(etiqueta);

                    tRow.Cells.Add(tCell);


                    for (int num_cell = 1; num_cell <= 42; num_cell++) //vamos recorriendo celda por celda y comparando si la hora concuerda con la orden
                    {
                        TableCell tCell1 = new TableCell();
                        Button boton = new Button();



                        switch (num_cell) // relaciona el numero de celda con la hora 
                        {
                            case 1:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";                               
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                tRow.Cells.Add(tCell1);
                                break;
                            case 2:
                                //tabla += "<td class='tableCellPlanografoHoras'";                                
                                tCell1.CssClass = "tableCellPlanografoHoras";

                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    string[] get_hora = get_fecha[1].Split(':');
                                    if (get_hora[0].Equals("7") && get_hora[1].Equals("30")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }
                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            //tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";


                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";

                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;


                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 3:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";                                  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";

                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("7") && get_hora[1].Equals("45")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }
                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }


                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 4:
                                // tabla += "<td class='tableCellPlanografoHoras'";                                  
                                tCell1.CssClass = "tableCellPlanografoHoras";

                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("8") && get_hora[1].Equals("00")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;

                                        }
                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }

                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 5:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'"; 
                                //TableCell tCell5 = new TableCell();
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";

                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("8") && get_hora[1].Equals("15")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }

                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 6:
                                //tabla += "<td class='tableCellPlanografoHoras'";                                 
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("8") && get_hora[1].Equals("30")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 7:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";                                  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";

                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("8") && get_hora[1].Equals("45")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 8:
                                //tabla += "<td class='tableCellPlanografoHoras'";
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("9") && get_hora[1].Equals("00")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 9:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("9") && get_hora[1].Equals("15")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 10:
                                //tabla += "<td class='tableCellPlanografoHoras'";
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("9") && get_hora[1].Equals("30")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 11:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("9") && get_hora[1].Equals("45")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 12:
                                //tabla += "<td class='tableCellPlanografoHoras'";
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("10") && get_hora[1].Equals("00")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 13:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("10") && get_hora[1].Equals("15")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 14:
                                //tabla += "<td class='tableCellPlanografoHoras'";  
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("10") && get_hora[1].Equals("30")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 15:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("10") && get_hora[1].Equals("45")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 16:
                                //tabla += "<td class='tableCellPlanografoHoras'";  
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("11") && get_hora[1].Equals("00")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 17:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("11") && get_hora[1].Equals("15")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 18:
                                //tabla += "<td class='tableCellPlanografoHoras'";  
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("11") && get_hora[1].Equals("30")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 19:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');

                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("11") && get_hora[1].Equals("45")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 20:
                                //tabla += "<td class='tableCellPlanografoHoras'";
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("12") && get_hora[1].Equals("00")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 21:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("12") && get_hora[1].Equals("15")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 22:
                                //tabla += "<td class='tableCellPlanografoHoras'";  
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("12") && get_hora[1].Equals("30")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 23:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("12") && get_hora[1].Equals("45")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 24:
                                //tabla += "<td class='tableCellPlanografoHoras'";
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("13") && get_hora[1].Equals("00")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 25:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("13") && get_hora[1].Equals("15")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 26:
                                //tabla += "<td class='tableCellPlanografoHoras'";
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("13") && get_hora[1].Equals("30")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 27:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("13") && get_hora[1].Equals("45")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 28:
                                //tabla += "<td class='tableCellPlanografoHoras'";
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("14") && get_hora[1].Equals("00")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 29:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("14") && get_hora[1].Equals("15")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 30:
                                //tabla += "<td class='tableCellPlanografoHoras'";  
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("14") && get_hora[1].Equals("30")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 31:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("14") && get_hora[1].Equals("45")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }
                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 32:
                                //tabla += "<td class='tableCellPlanografoHoras'";  
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("15") && get_hora[1].Equals("00")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }
                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 33:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("15") && get_hora[1].Equals("15")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 34:
                                //tabla += "<td class='tableCellPlanografoHoras'";  
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("15") && get_hora[1].Equals("30")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 35:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("15") && get_hora[1].Equals("45")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }
                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 36:
                                //tabla += "<td class='tableCellPlanografoHoras'";  
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("16") && get_hora[1].Equals("00")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }
                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 37:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("16") && get_hora[1].Equals("15")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 38:
                                //tabla += "<td class='tableCellPlanografoHoras'";  
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("16") && get_hora[1].Equals("30")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 39:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("16") && get_hora[1].Equals("45")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }
                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 40:
                                //tabla += "<td class='tableCellPlanografoHoras'";  
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("17") && get_hora[1].Equals("00")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }
                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 41:
                                //tabla += "<td class='tableCellPlanografoHoras_impar'";  
                                tCell1.CssClass = "tableCellPlanografoHoras_impar";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("17") && get_hora[1].Equals("15")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            case 42:
                                //tabla += "<td class='tableCellPlanografoHoras'";  
                                tCell1.CssClass = "tableCellPlanografoHoras";
                                if (dt_orden.Rows.Count > pos_dt_orden) // verificamos que existan ordenes pendientes
                                {
                                    string[] get_fecha = dt_orden.Rows[pos_dt_orden]["horaInicio"].ToString().Split(' ');
                                    string[] get_hora = get_fecha[1].Split(':');
                                    DateTime fecha_guardada = DateTime.Parse(get_fecha[0].ToString());
                                    string[] solo_fecha = Session["fecha_consulta"].ToString().Split(' ');
                                    DateTime fecha_seleccionada = DateTime.Parse(solo_fecha[0].ToString());

                                    if (get_hora[0].Equals("17") && get_hora[1].Equals("30")) // verificamos que esta sea la hora correspondiente a la celda
                                    {
                                        if (!DateTime.Equals(fecha_guardada, fecha_seleccionada))
                                        {
                                            pos_dt_orden++;
                                            tRow.Cells.Clear();
                                            tRow.Cells.Add(tCell);
                                            num_cell = 0;
                                            break;
                                        }

                                        else
                                        {
                                            DateTime final = new DateTime();
                                            final = (DateTime)dt_orden.Rows[pos_dt_orden]["horaFinal"];
                                            DateTime inicio = new DateTime();
                                            inicio = (DateTime)dt_orden.Rows[pos_dt_orden]["horaInicio"];

                                            TimeSpan resta = final.Subtract(inicio);
                                            int tiempo_Trans = resta.Hours * 60 + resta.Minutes;


                                            int columnas = tiempo_Trans / 15;

                                            // tabla += " colspan='" + columnas + "'><button  class='botonTecnicos'  runat='server' onserverclickk='cargar_act' value='"+dt_orden.Rows[pos_dt_orden]["idOrdenes"].ToString()+"'>" + dt_orden.Rows[pos_dt_orden]["numero"].ToString() + "</button>";
                                            tCell1.ColumnSpan = columnas;
                                            boton.Text = dt_orden.Rows[pos_dt_orden]["numero"].ToString();
                                            boton.ID = boton.Text;
                                            boton.Click += new EventHandler(this.Modificar_Click);
                                            boton.CssClass = "botonTecnicos";
                                            DateTime actual = DateTime.Now;
                                            TimeSpan falta = final.Subtract(actual);
                                            int t_Trans = falta.Hours * 60 + falta.Minutes;
                                            if (t_Trans <= 30 && t_Trans > 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Yellow;
                                            }
                                            else if (t_Trans < 0)
                                            {
                                                boton.BackColor = System.Drawing.Color.Red;
                                            }

                                            tCell1.Controls.Add(boton);

                                            num_cell += columnas - 1;
                                            pos_dt_orden++;
                                        }
                                    }
                                }
                                tRow.Cells.Add(tCell1);
                                break;
                            default:
                                pos_dt_orden++;
                                num_cell = 0;
                                break;
                        }
                    }
                    //tabla += "</tr>";
                    tPlano.Rows.Add(tRow);
                }
                else
                {
                    // tabla += "<tr> <td class='tableCellPlanografoTecnicos'> <label class='labelTecnicos'>" + dt.Rows[x]["nombre"].ToString() + "</label></td>";

                    TableRow tRow1 = new TableRow();
                    TableCell tCell1 = new TableCell();
                    tCell1.CssClass = "tableCellPlanografoTecnicos";

                    Label etiq = new Label();
                    etiq.CssClass = "labelTecnicos";
                    etiq.Text = dt.Rows[x]["nombre"].ToString();

                    tCell1.Controls.Add(etiq);
                    tRow1.Cells.Add(tCell1);



                    for (int num_cell = 1; num_cell <= 42; num_cell++) //vamos recorriendo celda por celda y comparando si la hora concuerda con la orden
                    {
                        if ((num_cell % 2) == 0)
                        {
                            //tabla += "<td class='tableCellPlanografoHoras'></td>";
                            TableCell tCell2 = new TableCell();
                            tCell2.CssClass = "tableCellPlanografoHoras";
                            tRow1.Cells.Add(tCell2);

                        }
                        else
                        {
                            //tabla += "<td class='tableCellPlanografoHoras_impar'></td>";
                            TableCell tCell2 = new TableCell();
                            tCell2.CssClass = "tableCellPlanografoHoras_impar";
                            tRow1.Cells.Add(tCell2);
                        }


                    }
                    // tabla += "</tr>";
                    tPlano.Rows.Add(tRow1);
                }

            }


            con.Close();
            return tabla;
        }

        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.Validate("validar");
            if (Page.IsValid)
            {
                if (Button1.Text.Equals("Agregar"))
                {
                    DateTime fechainicio_Aux = DateTime.Parse(Session["fecha_consulta"].ToString());// Calendar1.SelectedDate;
                    DateTime fechainicio = new DateTime(fechainicio_Aux.Year, fechainicio_Aux.Month, fechainicio_Aux.Day, 0, 0, 0);


                    string[] inicio = drpHoraInicio.SelectedValue.Split(':');
                    fechainicio = fechainicio.AddHours(int.Parse(inicio[0]));
                    fechainicio = fechainicio.AddMinutes(int.Parse(inicio[1]));
                    fechainicio = fechainicio.AddSeconds(int.Parse(inicio[2]));

                    DateTime fechafinal = fechainicio;


                    string formate = formatear(htazada.Text);
                    string[] hora_taza = formate.Split(':');

                    //string[] final = drpHoraFinal.SelectedValue.Split(':');
                    fechafinal = fechafinal.AddHours(int.Parse(hora_taza[0]));
                    fechafinal = fechafinal.AddMinutes(int.Parse(hora_taza[1]));

                    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                    con.Open();
                    SqlTransaction tr = con.BeginTransaction(IsolationLevel.Serializable);
                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[GT_Ordenes] ([numero],[horaInicio],[horaTasada],[horaFinal],[status],[idTecnico]) VALUES(@numero, @horainicio, @horatasada, @horafinal, @status, @idtecnico ) ", con, tr);
                    cmd.Parameters.Add("@numero", SqlDbType.Int).Value = int.Parse(drpOt.SelectedValue);
                    cmd.Parameters.Add("@horainicio", SqlDbType.DateTime).Value = fechainicio;
                    cmd.Parameters.Add("@horafinal", SqlDbType.DateTime).Value = fechafinal;
                    cmd.Parameters.Add("@horatasada", SqlDbType.VarChar).Value = htazada.Text;
                    cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = drpStatus.SelectedValue;
                    cmd.Parameters.Add("@idtecnico", SqlDbType.Int).Value = drpTecnico.SelectedValue;
                    try
                    {
                        //Ejecuto
                        cmd.ExecuteNonQuery();
                        tr.Commit(); //Actualizar bd    
                        cargarOrdenes();
                        cargarTecnicos();
                        cargarHoras();
                        cargarStatus();
                        //crearTabla();
                        Response.Redirect("GT_Planografo_Digital.aspx", false);
                    }
                    catch (Exception ex)
                    {
                        //De haber un error lo capturo
                        // msg = ex.Message;
                        //Deshacemos la operacion
                        tr.Rollback();
                    }
                    finally
                    {
                        con.Close(); //Cerramos la conexion

                    }

                }
                else if (Button1.Text.Equals("Actualizar"))
                {
                    string formate = formatear(htazada.Text);
                    string[] hora_taza = formate.Split(':');

                    DateTime fechainicio = DateTime.Parse(Session["fecha_consulta"].ToString());  //Calendar1.SelectedDate;

                    string[] inicio = drpHoraInicio.SelectedValue.Split(':');
                    fechainicio = fechainicio.AddHours(int.Parse(inicio[0]));
                    fechainicio = fechainicio.AddMinutes(int.Parse(inicio[1]));
                    fechainicio = fechainicio.AddSeconds(int.Parse(inicio[2]));

                    DateTime fechafinal = fechainicio;

                    fechafinal = fechafinal.AddHours(int.Parse(hora_taza[0]));
                    fechafinal = fechafinal.AddMinutes(int.Parse(hora_taza[1]));

                    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                    con.Open();
                    SqlTransaction tr = con.BeginTransaction(IsolationLevel.Serializable);
                    int id = int.Parse(Session["id_modf"].ToString());
                    SqlCommand cmd = new SqlCommand("UPDATE [GT_Ordenes] SET [horaInicio] = @horainicio,[horaTasada] = @horatasada, [horaFinal] = @horafinal,[status] = @status,[idTecnico] =@idtecnico  WHERE  numero = '" + id + "'", con, tr);
                    cmd.Parameters.Add("@horainicio", SqlDbType.DateTime).Value = fechainicio;
                    cmd.Parameters.Add("@horafinal", SqlDbType.DateTime).Value = fechafinal;
                    cmd.Parameters.Add("@horatasada", SqlDbType.VarChar).Value = htazada.Text;
                    cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = drpStatus.SelectedValue;
                    cmd.Parameters.Add("@idtecnico", SqlDbType.Int).Value = drpTecnico.SelectedValue;
                    try
                    {
                        //Ejecuto
                        cmd.ExecuteNonQuery();
                        tr.Commit(); //Actualizar bd    
                        cargarOrdenes();
                        cargarTecnicos();
                        cargarHoras();
                        cargarStatus();
                        //crearTabla();
                        Response.Redirect("GT_Planografo_Digital.aspx", false);
                    }
                    catch (Exception ex)
                    {
                        //De haber un error lo capturo
                        // msg = ex.Message;
                        //Deshacemos la operacion
                        tr.Rollback();
                    }
                    finally
                    {
                        con.Close(); //Cerramos la conexion

                    }
                }
            }

        }

        private string formatear(string p)
        {
            string[] calcular = p.Split(':');
            int hora = int.Parse(calcular[0]);
            int min = int.Parse(calcular[1]);
            if (min > 0 && min < 15)
            {
                return p[0] + ":15";
            }
            if (min > 15 && min < 30)
            {
                return p[0] + ":30";
            }
            if (min > 30 && min < 45)
            {
                return p[0] + ":45";
            }
            if (min > 45 && min < 60)
            {
                hora += 1;
                return hora + ":00";
            }
            return p;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //Calendar1.SelectedDate = DateTime.Now;
            Button1.Text = "Agregar";
            ventana.Visible = true;
        }

        protected void cargar_act(object sender, ImageClickEventArgs e)
        {

        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string id_boton = b.ID;

            btneliminar.Visible = true;

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            string query = "select * from GT_Ordenes Where numero = '" + id_boton + "'";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            Session["id_modf"] = id_boton;
            drpOt.Visible = false;
            Label2.Visible = false;
            string[] hinicos = dt.Rows[0]["horaInicio"].ToString().Split(' ');
            string[] fecha = hinicos[0].Split('/');
            //Calendar1.SelectedDate = new DateTime(int.Parse(fecha[2]), int.Parse(fecha[1]), int.Parse(fecha[0]));
            htazada.Text = dt.Rows[0]["horaTasada"].ToString();
            string hinicio = hinicos[1];
            drpHoraInicio.SelectedValue = hinicio;
            string[] hfinals = dt.Rows[0]["horaFinal"].ToString().Split(' ');
            string hfinal = hfinals[1];
            txthorafinal.Text = hfinal;
            string status = dt.Rows[0]["status"].ToString();
            drpStatus.SelectedValue = status;
            string tecnico = dt.Rows[0]["idTecnico"].ToString();
            drpTecnico.SelectedValue = tecnico;

            Button1.Text = "Actualizar";
            ventana.Visible = true;

        }
      

        protected void htazada_TextChanged(object sender, EventArgs e)
        {
            Page.Validate("validar");
            if (Page.IsValid)
            {
                DateTime fechainicio_Aux = DateTime.Parse(Session["fecha_consulta"].ToString());  //Calendar1.SelectedDate;
                DateTime fechainicio = new DateTime(fechainicio_Aux.Year, fechainicio_Aux.Month, fechainicio_Aux.Day, 0, 0, 0);

                string[] inicio = drpHoraInicio.SelectedValue.Split(':');
                fechainicio = fechainicio.AddHours(int.Parse(inicio[0]));
                fechainicio = fechainicio.AddMinutes(int.Parse(inicio[1]));
                fechainicio = fechainicio.AddSeconds(int.Parse(inicio[2]));

                string[] hora_taza = htazada.Text.Split(':');

                DateTime fechafinal = fechainicio;
                //string[] final = drpHoraFinal.SelectedValue.Split(':');
                fechafinal = fechafinal.AddHours(int.Parse(hora_taza[0]));
                fechafinal = fechafinal.AddMinutes(int.Parse(hora_taza[1]));
                string[] text = fechafinal.ToString().Split(' ');
                txthorafinal.Text = text[1];
            }
        }

        protected void btndias_Click(object sender, EventArgs e)
        {         
                DateTime fecha = DateTime.Now;
                fecha = fecha.AddDays(1);
                Session["fecha_consulta"] = fecha.Date.ToString("d");
                Response.Redirect("GT_Planografo_Digital.aspx", false);   

        }

        protected void btnatras_Click(object sender, EventArgs e)
        {            
            DateTime fecha = DateTime.Now;
            Session["fecha_consulta"] = fecha.Date.ToString("d");
            fecha_actual.Text = fecha.Date.ToString("d");
            Response.Redirect("GT_Planografo_Digital.aspx", false);
        }

        protected void btncerrar_Click(object sender, EventArgs e)
        {
            ventana.Visible = false;
            btneliminar.Visible = false;
        }

        protected void btneliminar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            con.Open();
            SqlTransaction tr = con.BeginTransaction(IsolationLevel.Serializable);
            int id = int.Parse(Session["id_modf"].ToString());
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[GT_Ordenes] WHERE numero = '" + id + "'", con, tr);           
            
            try
            {
                //Ejecuto
                cmd.ExecuteNonQuery();
                tr.Commit(); //Actualizar bd                   
                //crearTabla();
                Response.Redirect("GT_Planografo_Digital.aspx", false);
            }
            catch (Exception ex)
            {                
                tr.Rollback();
            }
            finally
            {
                con.Close(); //Cerramos la conexion

            }
        }

    }
}