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
            ListItem pr33 = new ListItem("16:00:00", "16:00:00");
            ListItem pr34 = new ListItem("16:15:00", "16:15:00");
            ListItem pr35 = new ListItem("16:30:00", "16:30:00");
            ListItem pr36 = new ListItem("16:45:00", "16:45:00");
            ListItem pr37 = new ListItem("17:00:00", "17:00:00");
            ListItem pr38 = new ListItem("17:15:00", "17:15:00");
            //ListItem pr39 = new ListItem("17:30:00", "17:30:00");

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

            //drpHoraInicio.Items.Add(pr39);
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

            int hora_actual = buscar_hora_Actual();

            Crear_franja_sub_Hora(hora_actual); //crea la franja que esta entre las horas y el primer tecnico

            for (int x = 0; x < dt.Rows.Count; x++) //ciclo para recorrer los tecnicos
            {
                pos_dt_orden = 0;
                string idtecnico = dt.Rows[x]["idTecnico"].ToString(); 
                Revisa_Atraso(idtecnico);
                string query2 = "select * from GT_Ordenes where idTecnico = '" + idtecnico + "' ORDER by horaInicio ASC";

                SqlCommand cmd2 = new SqlCommand(query2, con);
                SqlDataAdapter da_orden = new SqlDataAdapter(cmd2);
                DataTable dt_orden = new DataTable();
                da_orden.Fill(dt_orden);

                /* Obtener las ordenes de cada tecnico */
               

                if (dt_orden.Rows.Count > 0 && (bool)dt.Rows[x]["Activo"] == true) // preguntamos si se encontro alguna orden
                {


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

                        bool marcar = false;
                        if (num_cell == hora_actual)
                        {
                            marcar = true;
                        }

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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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

                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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

                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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
                                if (marcar)
                                {
                                    tCell1.BackColor = System.Drawing.Color.Blue;
                                }
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
                                            if ((bool)dt_orden.Rows[pos_dt_orden]["pasado"])
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

                    bool Inactivo = false;
                    if ((bool)dt.Rows[x]["Activo"] == false)
                    {
                        Inactivo = true;
                        etiq.ForeColor = System.Drawing.Color.Gray;
                    }

                    for (int num_cell = 1; num_cell <= 42; num_cell++) //vamos recorriendo celda por celda y comparando si la hora concuerda con la orden
                    {
                        bool marcar = false;
                        if (num_cell == hora_actual)
                        {
                            marcar = true;
                        }

                        if ((num_cell % 2) == 0)
                        {
                            //tabla += "<td class='tableCellPlanografoHoras'></td>";
                            TableCell tCell2 = new TableCell();
                            tCell2.CssClass = "tableCellPlanografoHoras";
                            if (Inactivo)
                            {
                                tCell2.BackColor = System.Drawing.Color.Gray;
                            }
                            if (marcar)
                            {
                                tCell2.BackColor = System.Drawing.Color.Blue;
                            }

                            tRow1.Cells.Add(tCell2);

                        }
                        else
                        {
                            //tabla += "<td class='tableCellPlanografoHoras_impar'></td>";
                            TableCell tCell2 = new TableCell();
                            tCell2.CssClass = "tableCellPlanografoHoras_impar";
                            if (Inactivo)
                            {
                                tCell2.BackColor = System.Drawing.Color.Gray;
                            }
                            if (marcar)
                            {
                                tCell2.BackColor = System.Drawing.Color.Blue;
                            }

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

        private void Revisa_Atraso( string idTecnico)
        {
            DateTime actual = DateTime.Now;
            actual = format_hora_prox(actual);

            SqlConnection conex = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            string query1 = "select DISTINCT numero, horaInicio from GT_Ordenes where idTecnico = '" + idTecnico + "' ORDER by horaInicio ASC";
            conex.Open();

            SqlCommand cmd1 = new SqlCommand(query1, conex);
            SqlDataAdapter dad = new SqlDataAdapter(cmd1);
            DataTable dt_num = new DataTable();
            dad.Fill(dt_num);

            conex.Close();

            TimeSpan TS_Mover = new TimeSpan(0,0,0);
            bool  Mover = false;
            for (int x = 0; x < dt_num.Rows.Count; x++)
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                string query = "select  * from GT_Ordenes where numero = '" + dt_num.Rows[x]["numero"] + "'  ORDER by horaInicio ASC";
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                if (Mover == false)
                {
                    DateTime h_final = (DateTime)dt.Rows[0]["horaFinal"] ;
                    DateTime h_ini = (DateTime)dt.Rows[0]["horainicio"];
                    string statusss = dt.Rows[0]["Status"].ToString();
                    if (h_final < actual && h_ini  < actual && !(dt.Rows[0]["Status"].Equals("Finalizada")))
                    {
                        Mover = true;
                        if (h_ini.Date == actual.Date.AddDays(-1))
                        {
                            Eliminar_registro_id((int)dt.Rows[0]["idOrdenes"]);
                            DateTime mover_a = new DateTime(7, 30, 00);
                            TS_Mover = actual.Subtract(mover_a);
                        }
                        else if (h_ini.Date == actual.Date)
                        {
                            TS_Mover = actual.Subtract((DateTime)dt.Rows[0]["horaFinal"]);
                        }
                        else
                        {
                            break;
                        }

                        
                        DateTime inicio = (DateTime)dt.Rows[0]["horaInicio"];

                        int idordenes = int.Parse(dt.Rows[0]["numero"].ToString());
                        string dpTecnico = dt.Rows[0]["idTecnico"].ToString();
                        string dpStatus = dt.Rows[0]["Status"].ToString();

                        string[] th = dt.Rows[0]["horaTasada"].ToString().Split(',');
                        int ho = int.Parse(th[0]);
                        int mi = int.Parse(th[1]);

                        string[] he = dt.Rows[0]["horaExtra"].ToString().Split(',');
                        ho = ho + int.Parse(he[0]);
                        mi = mi + int.Parse(he[1]);

                        mi = mi * 6;
                        mi = mi + TS_Mover.Minutes;                        
                        
                        ho = ho + TS_Mover.Hours;
                        //double mii = ((double));
                        //mii = Math.Ceiling(mii);
                        mi = mi/6;
                        string htazad =  ho+","+mi;                        
                        bool finalizado = true;

                        
                        Eliminar_registro(idordenes);
                        Agregar_registro(idordenes, dpTecnico, inicio, htazad, dpStatus, finalizado, dt.Rows[0]["horaExtra"].ToString());
                    }
                }
                else
                {
                    int idordenes = int.Parse(dt.Rows[0]["numero"].ToString());
                    string dpTecnico = dt.Rows[0]["idTecnico"].ToString();
                    string dpStatus = dt.Rows[0]["Status"].ToString();
                    string htazad = dt.Rows[0]["horaTasada"].ToString();
                    bool finalizado = false;

                    DateTime inicios = (DateTime)dt.Rows[0]["horaInicio"];
                    DateTime inicio = inicios.Add(TS_Mover);

                    Eliminar_registro(idordenes);
                    Agregar_registro(idordenes, dpTecnico, inicio, htazad, dpStatus, finalizado, dt.Rows[0]["horaExtra"].ToString());
                }
            }



        }

        private bool Eliminar_registro_id(int id)
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            con.Open();
            SqlTransaction tr = con.BeginTransaction(IsolationLevel.Serializable);
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[GT_Ordenes] WHERE idOrdenes = '" + id + "'", con, tr);
            try
            {
                //Ejecuto
                cmd.ExecuteNonQuery();
                tr.Commit(); //Actualizar bd                                
                //Response.Redirect("GT_Planografo_Digital.aspx", false);
                return true;
            }
            catch (Exception ex)
            {
                //De haber un error lo capturo
                // msg = ex.Message;
                //Deshacemos la operacion
                tr.Rollback();
                return false;
            }
            finally
            {
                con.Close(); //Cerramos la conexion

            }
        }


        private void Crear_franja_sub_Hora(int hora_actual)
        {
            TableRow tRow1 = new TableRow();
            TableCell tCell1 = new TableCell();
            tCell1.CssClass = "tableCellPlanografoTecnicos";
            tCell1.Height = Unit.Pixel(2);
            Label etiq = new Label();
            etiq.CssClass = "labelTecnicos";
            //etiq.Text = dt.Rows[x]["nombre"].ToString();
            tCell1.Controls.Add(etiq);
            tRow1.Cells.Add(tCell1);
            for (int num_cell = 1; num_cell <= 42; num_cell++) //vamos recorriendo celda por celda y comparando si la hora concuerda con la orden
            {
                bool marcar = false;
                if (num_cell == hora_actual)
                {
                    marcar = true;
                }
                if ((num_cell % 2) == 0)
                {
                    //tabla += "<td class='tableCellPlanografoHoras'></td>";
                    TableCell tCell2 = new TableCell();
                    tCell2.CssClass = "tableCellPlanografoHoras";
                    if (marcar)
                    {
                        tCell2.BackColor = System.Drawing.Color.Blue;
                    }
                    tCell2.Height = Unit.Pixel(2);
                    tRow1.Cells.Add(tCell2);

                }
                else
                {
                    //tabla += "<td class='tableCellPlanografoHoras_impar'></td>";
                    TableCell tCell2 = new TableCell();
                    tCell2.CssClass = "tableCellPlanografoHoras_impar";
                    if (marcar)
                    {
                        tCell2.BackColor = System.Drawing.Color.Blue;
                    }
                    tCell2.Height = Unit.Pixel(6);
                    tRow1.Cells.Add(tCell2);
                }
            }
            tPlano.Rows.Add(tRow1);
        }

        /// <summary>
        /// se encarga de buscar la hora mas cercana para marcar la franja
        /// </summary>
        /// <returns></returns>
        private int buscar_hora_Actual()
        {
            DateTime fecha_c = DateTime.Parse(Session["fecha_consulta"].ToString());
            if (fecha_c.Date != DateTime.Now.Date)
            {
                return 0;
            }

            int numero = 0;
            DateTime fecha = DateTime.Now;
            string hora_a = fecha.Hour + "," + fecha.Minute;
            hora_a = formatear_down(hora_a);

            string[] calcular = hora_a.Split(',');
            int hora = int.Parse(calcular[0]);
            int min = int.Parse(calcular[1]);

            switch (hora)
            {
                case 7:
                    if (min == 30)
                    {
                        numero = 2;
                    }
                    else if (min == 45)
                    {
                        numero = 3;
                    }
                    break;
                case 8:
                    if (min == 0)
                    {
                        numero = 4;
                    }
                    else if (min == 15)
                    {
                        numero = 5;
                    }
                    else if (min == 30)
                    {
                        numero = 6;
                    }
                    else if (min == 45)
                    {
                        numero = 7;
                    }
                    break;
                case 9:
                    if (min == 0)
                    {
                        numero = 8;
                    }
                    else if (min == 15)
                    {
                        numero = 9;
                    }
                    else if (min == 30)
                    {
                        numero = 10;
                    }
                    else if (min == 45)
                    {
                        numero = 11;
                    }
                    break;
                case 10:
                    if (min == 0)
                    {
                        numero = 12;
                    }
                    else if (min == 15)
                    {
                        numero = 13;
                    }
                    else if (min == 30)
                    {
                        numero = 14;
                    }
                    else if (min == 45)
                    {
                        numero = 15;
                    }
                    break;
                case 11:
                    if (min == 0)
                    {
                        numero = 16;
                    }
                    else if (min == 15)
                    {
                        numero = 17;
                    }
                    else if (min == 30)
                    {
                        numero = 18;
                    }
                    else if (min == 45)
                    {
                        numero = 19;
                    }
                    break;
                case 12:
                    if (min == 0)
                    {
                        numero = 20;
                    }
                    else if (min == 15)
                    {
                        numero = 21;
                    }
                    else if (min == 30)
                    {
                        numero = 22;
                    }
                    else if (min == 45)
                    {
                        numero = 23;
                    }
                    break;
                case 13:
                    if (min == 0)
                    {
                        numero = 24;
                    }
                    else if (min == 15)
                    {
                        numero = 25;
                    }
                    else if (min == 30)
                    {
                        numero = 26;
                    }
                    else if (min == 45)
                    {
                        numero = 27;
                    }
                    break;
                case 14:
                    if (min == 0)
                    {
                        numero = 28;
                    }
                    else if (min == 15)
                    {
                        numero = 29;
                    }
                    else if (min == 30)
                    {
                        numero = 30;
                    }
                    else if (min == 45)
                    {
                        numero = 31;
                    }
                    break;
                case 15:
                    if (min == 0)
                    {
                        numero = 32;
                    }
                    else if (min == 15)
                    {
                        numero = 33;
                    }
                    else if (min == 30)
                    {
                        numero = 34;
                    }
                    else if (min == 45)
                    {
                        numero = 35;
                    }
                    break;
                case 16:
                    if (min == 0)
                    {
                        numero = 36;
                    }
                    else if (min == 15)
                    {
                        numero = 37;
                    }
                    else if (min == 30)
                    {
                        numero = 38;
                    }
                    else if (min == 45)
                    {
                        numero = 39;
                    }
                    break;
                case 17:
                    if (min == 0)
                    {
                        numero = 40;
                    }
                    else if (min == 15)
                    {
                        numero = 41;
                    }
                    else if (min == 30)
                    {
                        numero = 42;
                    }
                    break;
            }

            return numero;
        }

        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.Validate("validar");
            if (Page.IsValid)
            {
                #region AGREGAR
                if (Button1.Text.Equals("Agregar"))
                {
                    int id = int.Parse(drpOt.SelectedValue);
                    string dpTecnico = drpTecnico.SelectedValue;

                    DateTime fechainicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    string dpHoraInicio = drpHoraInicio.SelectedValue;
                    string[] inicio = dpHoraInicio.Split(':');
                    fechainicio = fechainicio.AddHours(int.Parse(inicio[0]));
                    fechainicio = fechainicio.AddMinutes(int.Parse(inicio[1]));
                    fechainicio = fechainicio.AddSeconds(int.Parse(inicio[2]));

                   
                    string htazad = htazada.Text;
                    string dpStatus = drpStatus.SelectedValue;
                    string hextra = txtHoraExtra.Text;
                   bool res =  Agregar_registro(id, dpTecnico, fechainicio, htazad, dpStatus, false, hextra);
                   if (res)
                   {
                       Response.Redirect("GT_Planografo_Digital.aspx", false);                    
                   }
                       

                }
                #endregion
                else if (Button1.Text.Equals("Actualizar"))
                {
                    int id = int.Parse(Session["id_modf"].ToString());
                    SqlConnection conex = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                    string query1 = "select * from GT_Ordenes where numero = '" + id + "'";
                    conex.Open();

                    SqlCommand cmd1 = new SqlCommand(query1, conex);
                    SqlDataAdapter dad = new SqlDataAdapter(cmd1);
                    DataTable dt_num = new DataTable();
                    dad.Fill(dt_num);

                    conex.Close();
                    DateTime aux = (DateTime)dt_num.Rows[0]["horaInicio"];
                    DateTime fechainicio =  aux.Date;
                    string dpHoraInicio = drpHoraInicio.SelectedValue;
                    string[] inicio = dpHoraInicio.Split(':');
                    fechainicio = fechainicio.AddHours(int.Parse(inicio[0]));
                    fechainicio = fechainicio.AddMinutes(int.Parse(inicio[1]));
                    fechainicio = fechainicio.AddSeconds(int.Parse(inicio[2]));

                    string hextra = txtHoraExtra.Text;

                    Eliminar_registro(id);

                    

                    string dpTecnico = drpTecnico.SelectedValue;
                    //string dpHoraInicio = drpHoraInicio.SelectedValue;
                    string htazad = htazada.Text;
                    string dpStatus = drpStatus.SelectedValue;
                    bool res = Agregar_registro(id, dpTecnico, fechainicio, htazad, dpStatus, (bool)dt_num.Rows[0]["pasado"], hextra);
                    if(res)
                        Response.Redirect("GT_Planografo_Digital.aspx", false);
                }
            }

        }

        private bool Eliminar_registro(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            con.Open();
            SqlTransaction tr = con.BeginTransaction(IsolationLevel.Serializable);
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[GT_Ordenes] WHERE numero = '" + id + "'", con, tr);
            try
            {
                //Ejecuto
                cmd.ExecuteNonQuery();
                tr.Commit(); //Actualizar bd                                
                //Response.Redirect("GT_Planografo_Digital.aspx", false);
                return true;
            }
            catch (Exception ex)
            {
                //De haber un error lo capturo
                // msg = ex.Message;
                //Deshacemos la operacion
                tr.Rollback();
                return false;
            }
            finally
            {
                con.Close(); //Cerramos la conexion

            }
        }

        private bool Agregar_registro(int id, string dpTecnico, DateTime dpHoraInicio, string htazada, string dpStatus, bool finalizado, string hextra)
        {           

            DateTime fechainicio_Aux = DateTime.Parse(Session["fecha_consulta"].ToString());// Calendar1.SelectedDate;
            DateTime fechainicio = dpHoraInicio;// new DateTime(fechainicio_Aux.Year, fechainicio_Aux.Month, fechainicio_Aux.Day, 0, 0, 0);



            DateTime fechafinal = fechainicio;


            TimeSpan formate = formatear(htazada);
            TimeSpan horextra = formatear(hextra);
            formate = formate.Add(horextra);
            
            fechafinal = fechafinal.Add(formate);
            

            #region Si la orden es finalizada antes de la hora final seleccionada


            if (dpStatus.Equals("Finalizada") && fechainicio < DateTime.Now)
            {
                fechafinal = Mover_Ordenes(int.Parse(dpTecnico), fechafinal, id);
            }

            #endregion


            //ver si cabe en el mismo dia o si hay que hacer split de 2 días
            DateTime limite = DateTime.Parse("17:30:00");
            if (fechafinal.TimeOfDay <= limite.TimeOfDay)
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                con.Open();
                SqlTransaction tr = con.BeginTransaction(IsolationLevel.Serializable);
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[GT_Ordenes] ([numero],[horaInicio],[horaTasada],[horaFinal],[status],[idTecnico], [pasado], [horaextra]) VALUES(@numero, @horainicio, @horatasada, @horafinal, @status, @idtecnico, @finalizado, @horaextras ) ", con, tr);
                cmd.Parameters.Add("@numero", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@horainicio", SqlDbType.DateTime).Value = fechainicio;
                cmd.Parameters.Add("@horafinal", SqlDbType.DateTime).Value = fechafinal;
                cmd.Parameters.Add("@horatasada", SqlDbType.VarChar).Value = htazada;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = dpStatus;
                cmd.Parameters.Add("@idtecnico", SqlDbType.Int).Value = dpTecnico;
                cmd.Parameters.Add("@finalizado", SqlDbType.Int).Value = finalizado;
                cmd.Parameters.Add("@horaextras", SqlDbType.VarChar).Value = hextra;
                try
                {
                    //Ejecuto
                    cmd.ExecuteNonQuery();
                    tr.Commit(); //Actualizar bd                                
                    //Response.Redirect("GT_Planografo_Digital.aspx", false);
                    return true;
                }
                catch (Exception ex)
                {
                    //De haber un error lo capturo
                    // msg = ex.Message;
                    //Deshacemos la operacion
                    tr.Rollback();
                    return false;
                }
                finally
                {
                    con.Close(); //Cerramos la conexion

                }
            }
            else // aqui hay que dividir en 2 la orden
            {
                DateTime fecha_partida = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 30, 00);

                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                con.Open();
                SqlTransaction tr = con.BeginTransaction(IsolationLevel.Serializable);
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[GT_Ordenes] ([numero],[horaInicio],[horaTasada],[horaFinal],[status],[idTecnico], [pasado], [horaextra]) VALUES(@numero, @horainicio, @horatasada, @horafinal, @status, @idtecnico, @finalizado, @horaextras ) ", con, tr);
                cmd.Parameters.Add("@numero", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@horainicio", SqlDbType.DateTime).Value = fechainicio;
                cmd.Parameters.Add("@horafinal", SqlDbType.DateTime).Value = fecha_partida;
                cmd.Parameters.Add("@horatasada", SqlDbType.VarChar).Value = htazada;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = dpStatus;
                cmd.Parameters.Add("@idtecnico", SqlDbType.Int).Value = dpTecnico;
                cmd.Parameters.Add("@finalizado", SqlDbType.Int).Value = finalizado;
                cmd.Parameters.Add("@horaextras", SqlDbType.VarChar).Value = hextra;
                DateTime fecha_n_inicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 00);
                fecha_n_inicio = fecha_n_inicio.AddDays(1);

                DateTime fecha_n_final = fecha_n_inicio;

                try
                {
                    //Ejecuto
                    cmd.ExecuteNonQuery();
                    tr.Commit(); //Actualizar bd                             
                    //Response.Redirect("GT_Planografo_Digital.aspx", false);
                }
                catch (Exception ex)
                {
                    //De haber un error lo capturo
                    // msg = ex.Message;
                    //Deshacemos la operacion
                    tr.Rollback();
                    return false;
                }
                finally
                {
                    con.Close(); //Cerramos la conexion

                }

                con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                con.Open();
                tr = con.BeginTransaction(IsolationLevel.Serializable);
                cmd = new SqlCommand("INSERT INTO [dbo].[GT_Ordenes] ([numero],[horaInicio],[horaTasada],[horaFinal],[status],[idTecnico], [pasado], [horaextra]) VALUES(@numero, @horainicio, @horatasada, @horafinal, @status, @idtecnico, @finalizado, @horaextras ) ", con, tr);

                TimeSpan diferencia = fechafinal.Subtract(fecha_partida);
                fecha_n_final = fecha_n_final.Add(diferencia);

                
                int ho = diferencia.Hours;
                int mi = diferencia.Minutes;
                mi = mi / 6;
                //mi = mi + fecha_n_final.TimeOfDay.Minutes;

                //ho = ho + fecha_n_final.TimeOfDay.Hours;
                //double mii = ((double));
                //mii = Math.Ceiling(mii);
                //mi = mi / 6;
                string htazad = ho + "," + mi;

                cmd.Parameters.Add("@numero", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@horainicio", SqlDbType.DateTime).Value = fecha_n_inicio;
                cmd.Parameters.Add("@horafinal", SqlDbType.DateTime).Value = fecha_n_final;
                cmd.Parameters.Add("@horatasada", SqlDbType.VarChar).Value = htazad;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = dpStatus;
                cmd.Parameters.Add("@idtecnico", SqlDbType.Int).Value = dpTecnico;
                cmd.Parameters.Add("@finalizado", SqlDbType.Int).Value = finalizado;
                cmd.Parameters.Add("@horaextras", SqlDbType.VarChar).Value = hextra;
                try
                {
                    //Ejecuto
                    cmd.ExecuteNonQuery();
                    tr.Commit(); //Actualizar bd                        
                    //Response.Redirect("GT_Planografo_Digital.aspx", false);
                    return true;
                }
                catch (Exception ex)
                {
                    //De haber un error lo capturo
                    // msg = ex.Message;
                    //Deshacemos la operacion
                    tr.Rollback();
                    return false;
                }
                finally
                {
                    con.Close(); //Cerramos la conexion

                }

            }
        }

        ///Tengo que arreglar esta vara, no esta terminada
        private DateTime Mover_Ordenes(int id, DateTime final, int ord_mod)
        {
            DateTime actual = DateTime.Now;
            actual = format_hora_prox(actual);

            TimeSpan resta = final.TimeOfDay.Subtract(actual.TimeOfDay);
            int adelantado = resta.Minutes + resta.Hours * 60;
            if (adelantado > 0)
            {

                SqlConnection conex = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                string query1 = "select DISTINCT numero from GT_Ordenes";
                conex.Open();

                SqlCommand cmd1 = new SqlCommand(query1, conex);
                SqlDataAdapter dad = new SqlDataAdapter(cmd1);
                DataTable dt_num = new DataTable();
                dad.Fill(dt_num);

                conex.Close();



                for (int x = 0; x < dt_num.Rows.Count; x++)
                {
                    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                    string query = "select  * from GT_Ordenes where numero = '" + dt_num.Rows[x]["numero"] + "' and idOrdenes != '" + ord_mod.ToString() + "'  ORDER by horaInicio ASC";
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    con.Close();


                    int idordenes = int.Parse(dt.Rows[0]["numero"].ToString());
                    string dpTecnico = dt.Rows[0]["idTecnico"].ToString();
                    string dpStatus = dt.Rows[0]["Status"].ToString();

                    DateTime new_inicio = DateTime.Parse(dt.Rows[0]["horaInicio"].ToString()).Subtract(resta);
                    //string hora_env = new_inicio;
                    bool finalizado = (bool)dt.Rows[0]["pasado"];                 

                    string htazad = dt.Rows[0]["horaTasada"].ToString();
                    Eliminar_registro(idordenes);
                    Agregar_registro(idordenes, dpTecnico, new_inicio, htazad, dpStatus, finalizado, dt.Rows[0]["horaExtra"].ToString());
                }
                return actual;
            }
            else
            {
                return final;
            }

        }

        private DateTime format_hora_prox(DateTime p)
        {
            DateTime nuevo = new DateTime(p.Year, p.Month, p.Day);
            int hora = p.Hour;
            int min = p.Minute;
            if (min > 0 && min < 15)
            {
                nuevo = nuevo.AddHours(hora);
                nuevo = nuevo.AddMinutes(15);
                return nuevo;
            }
            if (min > 15 && min < 30)
            {
                nuevo = nuevo.AddHours(hora);
                nuevo = nuevo.AddMinutes(30);
                return nuevo;
            }
            if (min > 30 && min < 45)
            {
                nuevo = nuevo.AddHours(hora);
                nuevo = nuevo.AddMinutes(45);
                return nuevo;
            }
            if (min > 45 && min < 60)
            {
                nuevo = nuevo.AddHours(hora + 1);
                nuevo = nuevo.AddMinutes(00);
                return nuevo;
            }
            return p;
        }

        private TimeSpan formatear(string p)
        {
            string[] calcular = p.Split(',');
            int hora = int.Parse(calcular[0]);
            int min = int.Parse(calcular[1]) * 6;
            TimeSpan tiempo = new TimeSpan(hora, min, 0);
            if (tiempo.Minutes > 0 && tiempo.Minutes < 15)
            {
                TimeSpan tiemp = new TimeSpan(int.Parse(tiempo.Hours.ToString()), 15, 0);
                return tiemp;
            }
            if (tiempo.Minutes > 15 && tiempo.Minutes < 30)
            {
                TimeSpan tiemp = new TimeSpan(int.Parse(tiempo.Hours.ToString()), 30, 0);
                return tiemp;
            }
            if (tiempo.Minutes > 30 && tiempo.Minutes < 45)
            {
                TimeSpan tiemp = new TimeSpan(int.Parse(tiempo.Hours.ToString()), 45, 0);
                return tiemp;
            }
            if (tiempo.Minutes > 45 && tiempo.Minutes < 60)
            {
                TimeSpan tiemp = new TimeSpan(int.Parse(tiempo.Hours.ToString())+1, 00, 0);
                return tiemp;
            }
            return tiempo;
        }

        private string formatear_down(string p)
        {
            string[] calcular = p.Split(',');
            int hora = int.Parse(calcular[0]);
            int min = int.Parse(calcular[1]);
            if (min > 0 && min < 15)
            {
                return hora + ",00";
            }
            if (min > 15 && min < 30)
            {
                return hora + ",15";
            }
            if (min > 30 && min < 45)
            {
                return hora + ",30";
            }
            if (min > 45 && min < 60)
            {
                return hora + ",45";
            }
            return p;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //Calendar1.SelectedDate = DateTime.Now;
            Button1.Text = "Agregar";
            htazada.Enabled = true;
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

            txtHoraExtra.Text = dt.Rows[0]["horaExtra"].ToString();

            Button1.Text = "Actualizar";
            htazada.Enabled = false;
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

                string[] hora_taza = htazada.Text.Split(',');
                string[] hora_extra = txtHoraExtra.Text.Split(',');

                DateTime fechafinal = fechainicio;
                //string[] final = drpHoraFinal.SelectedValue.Split(':');
                fechafinal = fechafinal.AddHours(int.Parse(hora_taza[0]));
                fechafinal = fechafinal.AddHours(int.Parse(hora_extra[0]));
                fechafinal = fechafinal.AddMinutes(int.Parse(hora_taza[1]) * 6);
                fechafinal = fechafinal.AddMinutes(int.Parse(hora_extra[1]) * 6);
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