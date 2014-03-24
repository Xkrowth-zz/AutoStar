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
    public partial class ppCrearPlanografo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                cargarOrdenes();
                cargarTecnicos();
                cargarHoras();
                cargarStatus();

                if (Session["fecha_consulta"] == null)
                {
                    DateTime fecha = DateTime.Now;
                    Session["fecha_consulta"] = fecha.Date.ToString("d");
                }
                if (Session["modificarOrdenesTecnicos"] != null && (bool)Session["modificarOrdenesTecnicos"] == true && Session["datosOrdenesTecnicos"] != null)
                {
                    DataTable dt_orden = (DataTable) Session["datosOrdenesTecnicos"];
                    drpTecnico.SelectedValue = dt_orden.Rows[0]["idTecnico"].ToString();
                    drpOt.Items.Add(new ListItem(dt_orden.Rows[0]["numero"].ToString(), dt_orden.Rows[0]["numero"].ToString()));
                    drpOt.SelectedValue = dt_orden.Rows[0]["numero"].ToString();
                    drpOt.Enabled = false;
                    drpOt.Visible = true;
                    llenarCliente(Session["botonID"].ToString());
//                    ventana.Visible = true;
                    Session["modificarOrdenesTecnicos"] = false;
                }
                else
                {                    
                    if (Session["opcion"] == null)
                    {
                        Session["opcion"] = true;
                    }
                    if ((bool)Session["opcion"])
                    {
                        drpOt.Enabled = true;
                        drpOt.Visible = true;
                        Button1.Text = "Agregar";
                        btneliminar.Visible = false;
                        htazada.Enabled = true;
                        ventana.Visible = true;
                        txtComentario.Visible = false;
                        Label2.Visible = true;
                        limpiarcampos();
                        llenarCliente(drpOt.SelectedValue);
                    }
                    else if ((bool)Session["opcion"] == false)
                    {
                        Button b = (Button)Session["botonModificar"];
                        string id_boton = b.ID;
                        txtComentario.Visible = false;
                        btneliminar.Visible = true;

                        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                        string query = "select * from GT_Ordenes Where numero = '" + id_boton + "' and Area = '" + Session["sel_area"].ToString() + "' ";
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

                        string[] hora_taza = htazada.Text.Split(',');
                        txtHorareal.Text = int.Parse(hora_taza[0]) + ":" + int.Parse(hora_taza[1]) * 6;

                        Button1.Text = "Actualizar";
                        horatazadaCalcular();
                        llenarCliente(id_boton);
                        //htazada.Enabled = false;
                        ventana.Visible = true;
                    }
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.Validate("validar");
            if (Page.IsValid)
            {
                #region AGREGAR
                if (Button1.Text.Equals("Agregar"))
                {
                    bool[] comidas = verificar_comidas(); // verifica que la orden no caiga entre las hoas de comida, y si lo hace le suma el tiempo extra

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



                    if (Session["drpestado"] != null && (bool)Session["drpestado"] == true && !dpStatus.Equals("Pendiente de repuestos") && !dpStatus.Equals("Pendiente de aprobación cliente") && !dpStatus.Equals("Trabajos de taller externo"))
                    {
                        bool valido = Valida_tiempo_agregar(fechainicio, htazad, hextra, dpTecnico, "-1");
                        if (valido)
                        {
                            bool res = Agregar_registro(id, dpTecnico, fechainicio, htazad, dpStatus, false, hextra, int.Parse(Session["sel_area"].ToString()), comidas[0], comidas[1], comidas[2]);
                            //if (res)
                            //{
                            if (!res)
                            {
                                Eliminar_en_estado(drpOt.SelectedValue);
                                Session["drpestado"] = false;
                                drpOt.Enabled = true;
                                //Response.Redirect("GT_Planografo_Digital.aspx", false);
                                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "cerrar();", true);
                            }
                        }

                    }

                    else if (dpStatus.Equals("Pendiente de repuestos") || dpStatus.Equals("Pendiente de aprobación cliente") || dpStatus.Equals("Trabajos de taller externo"))
                    {
                        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                        string query2 = "select * from GT_Ordenes_Estado where numero = '" + drpOt.ID + "'";
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand(query2, con);
                        SqlDataAdapter da_orden = new SqlDataAdapter(cmd2);
                        DataTable dt_orden = new DataTable();
                        da_orden.Fill(dt_orden);

                        if (dt_orden.Rows.Count == 0)
                        {
                            Agregar_A_Estados(id, dpTecnico, dpStatus);
                            //Redirect("GT_Planografo_Digital.aspx", false);
                        }

                    }
                    else
                    {
                        bool valido = Valida_tiempo_agregar(fechainicio, htazad, hextra, dpTecnico, "-1");
                        if (valido)
                        {
                            bool res = Agregar_registro(id, dpTecnico, fechainicio, htazad, dpStatus, false, hextra, int.Parse(Session["sel_area"].ToString()), comidas[0], comidas[1], comidas[2]);
                            //if (res)
                            //{
                            //Response.Redirect("GT_Planografo_Digital.aspx", false);
                            //}
                        }
                    }




                }
                #endregion
                #region MODIFICAR
                else if (Button1.Text.Equals("Actualizar"))
                {
                    int id = int.Parse(Session["id_modf"].ToString());

                    bool[] horas_comida = verificar_comidas_aux(id);

                    SqlConnection conex = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                    string query1 = "select * from GT_Ordenes where numero = '" + id + "' and Area = '" + Session["sel_area"].ToString() + "' ";
                    conex.Open();

                    SqlCommand cmd1 = new SqlCommand(query1, conex);
                    SqlDataAdapter dad = new SqlDataAdapter(cmd1);
                    DataTable dt_num = new DataTable();
                    dad.Fill(dt_num);

                    conex.Close();
                    DateTime aux = (DateTime)dt_num.Rows[0]["horaInicio"];
                    DateTime fechainicio = aux.Date;
                    string dpHoraInicio = drpHoraInicio.SelectedValue;
                    string[] inicio = dpHoraInicio.Split(':');
                    fechainicio = fechainicio.AddHours(int.Parse(inicio[0]));
                    fechainicio = fechainicio.AddMinutes(int.Parse(inicio[1]));
                    fechainicio = fechainicio.AddSeconds(int.Parse(inicio[2]));

                    string hextra = txtHoraExtra.Text;



                    string dpTecnico = drpTecnico.SelectedValue;
                    //string dpHoraInicio = drpHoraInicio.SelectedValue;
                    string htazad = htazada.Text;
                    string dpStatus = drpStatus.SelectedValue;

                    if (dpStatus.Equals("Pendiente de repuestos") || dpStatus.Equals("Pendiente de aprobación cliente") || dpStatus.Equals("Trabajos de taller externo"))
                    {
                        Eliminar_registro(id);
                        Agregar_A_Estados(id, dpTecnico, dpStatus);
                        //Response.Redirect("GT_Planografo_Digital.aspx", false);
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "cerrar();", true);
                    }
                    else
                    {
                        if (fechainicio < aux)
                        {
                            bool valido = Valida_tiempo_agregar(fechainicio, htazad, hextra, dpTecnico, id + "");
                            if (valido)
                            {
                                Eliminar_registro(id);
                                bool res = Agregar_registro(id, dpTecnico, fechainicio, htazad, dpStatus, (bool)dt_num.Rows[0]["pasado"], hextra, (int)dt_num.Rows[0]["Area"], horas_comida[0], horas_comida[1], horas_comida[2]);
                                if (!res)
                                {
                                    Mover_modificacion(dt_num);
                                    //preguntamos si movio antes                         

                                }
                                //Response.Redirect("GT_Planografo_Digital.aspx", false);
                                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "cerrar();", true);
                            }
                        }
                        else
                        {
                            Eliminar_registro(id);
                            bool res = Agregar_registro(id, dpTecnico, fechainicio, htazad, dpStatus, (bool)dt_num.Rows[0]["pasado"], hextra, (int)dt_num.Rows[0]["Area"], horas_comida[0], horas_comida[1], horas_comida[2]);
                            if (!res)
                            {
                                Mover_modificacion(dt_num);
                                //preguntamos si movio antes                         

                            }
                            //Response.Redirect("GT_Planografo_Digital.aspx", false);
                        }
                    }

                }
                #endregion
            }

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
                //Response.Redirect("GT_Planografo_Digital.aspx", false);
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

        protected void btncerrar_Click(object sender, EventArgs e)
        {
            ventana.Visible = false;
            btneliminar.Visible = false;
        }

        protected void drpOt_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList drporden = (DropDownList)sender;
            string orden_num = drporden.SelectedValue;
            comentarios();
            llenarCliente(orden_num);
        }

        private bool[] verificar_comidas()
        {
            bool[] comidas = new bool[3] { false, false, false };
            #region  convertimos los tiempos de timespan a datetime
            TimeSpan droptimeinicio = TimeSpan.Parse(drpHoraInicio.Text);
            DateTime inicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, droptimeinicio.Hours, droptimeinicio.Minutes, droptimeinicio.Seconds);

            TimeSpan droptimefinal = TimeSpan.Parse(txthorafinal.Text);
            DateTime final = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, droptimefinal.Hours, droptimefinal.Minutes, droptimefinal.Seconds);

            TimeSpan limite = new TimeSpan(17, 30, 00);
            if (droptimefinal > limite)
            {
                TimeSpan limite_inicio = new TimeSpan(7, 30, 00);

                TimeSpan resta = droptimefinal.Subtract(limite);

                limite_inicio = limite_inicio.Add(resta);
                droptimefinal = limite_inicio;
                final = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, droptimefinal.Hours, droptimefinal.Minutes, droptimefinal.Seconds);
                final = final.AddDays(1);
            }
            #endregion

            #region DESAYUNO
            TimeSpan inicio_desayuno = new TimeSpan(9, 15, 00);
            TimeSpan final_desayuno = new TimeSpan(9, 30, 00);

            if ((inicio.TimeOfDay >= inicio_desayuno && inicio.TimeOfDay < final_desayuno) || (final.TimeOfDay >= inicio_desayuno && final.TimeOfDay <= final_desayuno) || (inicio.TimeOfDay < inicio_desayuno && final.TimeOfDay > final_desayuno))
            {
                string[] tiemp_extra = txtHoraExtra.Text.Split(',');
                int min = int.Parse(tiemp_extra[1].ToString());
                min = min + 2;
                txtHoraExtra.Text = tiemp_extra[0] + "," + min;
                comidas[0] = true;
            }

            #endregion

            #region ALMUERZO
            TimeSpan inicio_almuerzo = new TimeSpan(12, 30, 00);
            TimeSpan final_almuerzo = new TimeSpan(13, 30, 00);

            if ((inicio.TimeOfDay >= inicio_almuerzo && inicio.TimeOfDay < final_almuerzo) || (final.TimeOfDay >= inicio_almuerzo && final.TimeOfDay <= final_almuerzo) || (inicio.TimeOfDay < inicio_almuerzo && final.TimeOfDay > final_almuerzo))
            {
                string[] tiemp_extra = txtHoraExtra.Text.Split(',');
                int hor = int.Parse(tiemp_extra[0].ToString());
                hor = hor + 1;
                txtHoraExtra.Text = hor + "," + tiemp_extra[1];
                comidas[1] = true;
            }

            #endregion

            #region DESAYUNO
            TimeSpan inicio_cafe = new TimeSpan(15, 15, 00);
            TimeSpan final_cafe = new TimeSpan(15, 30, 00);

            if ((inicio.TimeOfDay >= inicio_cafe && inicio.TimeOfDay < final_cafe) || (final.TimeOfDay >= inicio_cafe && final.TimeOfDay <= final_cafe) || (inicio.TimeOfDay < inicio_cafe && final.TimeOfDay > final_cafe))
            {
                string[] tiemp_extra = txtHoraExtra.Text.Split(',');
                int min = int.Parse(tiemp_extra[1].ToString());
                min = min + 2;
                txtHoraExtra.Text = tiemp_extra[0] + "," + min;
                comidas[2] = true;
            }

            #endregion

            return comidas;
        }

        private bool[] verificar_comidas_aux(int id)
        {

            SqlConnection conex = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            string query1 = "select * from GT_Ordenes where numero = '" + id + "' and Area = '" + Session["sel_area"].ToString() + "' ";
            conex.Open();

            SqlCommand cmd1 = new SqlCommand(query1, conex);
            SqlDataAdapter dad = new SqlDataAdapter(cmd1);
            DataTable dt_num = new DataTable();
            dad.Fill(dt_num);

            bool[] comidas = new bool[3] { (bool)dt_num.Rows[0]["Desayuno"], (bool)dt_num.Rows[0]["Almuerzo"], (bool)dt_num.Rows[0]["Cafe"] };

            #region  convertimos los tiempos de timespan a datetime
            TimeSpan droptimeinicio = TimeSpan.Parse(drpHoraInicio.Text);
            DateTime inicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, droptimeinicio.Hours, droptimeinicio.Minutes, droptimeinicio.Seconds);

            TimeSpan droptimefinal = TimeSpan.Parse(txthorafinal.Text);
            DateTime final = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, droptimefinal.Hours, droptimefinal.Minutes, droptimefinal.Seconds);

            TimeSpan limite = new TimeSpan(17, 30, 00);
            if (droptimefinal > limite)
            {
                TimeSpan limite_inicio = new TimeSpan(7, 30, 00);

                TimeSpan resta = droptimefinal.Subtract(limite);

                limite_inicio = limite_inicio.Add(resta);
                droptimefinal = limite_inicio;
                final = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, droptimefinal.Hours, droptimefinal.Minutes, droptimefinal.Seconds);
                final = final.AddDays(1);
            }
            #endregion

            #region DESAYUNO
            TimeSpan inicio_desayuno = new TimeSpan(9, 15, 00);
            TimeSpan final_desayuno = new TimeSpan(9, 30, 00);

            if ((inicio.TimeOfDay >= inicio_desayuno && inicio.TimeOfDay < final_desayuno) || (final.TimeOfDay >= inicio_desayuno && final.TimeOfDay <= final_desayuno) || (inicio.TimeOfDay < inicio_desayuno && final.TimeOfDay > final_desayuno))
            {
                if (!((bool)dt_num.Rows[0]["Desayuno"]))
                {
                    string[] tiemp_extra = txtHoraExtra.Text.Split(',');
                    int min = int.Parse(tiemp_extra[1].ToString());
                    min = min + 2;
                    txtHoraExtra.Text = tiemp_extra[0] + "," + min;
                    comidas[0] = true;
                }
            }
            else
            {
                comidas[0] = false;
            }

            #endregion

            #region ALMUERZO
            TimeSpan inicio_almuerzo = new TimeSpan(12, 30, 00);
            TimeSpan final_almuerzo = new TimeSpan(13, 30, 00);

            if ((inicio.TimeOfDay >= inicio_almuerzo && inicio.TimeOfDay < final_almuerzo) || (final.TimeOfDay >= inicio_almuerzo && final.TimeOfDay <= final_almuerzo) || (inicio.TimeOfDay < inicio_almuerzo && final.TimeOfDay > final_almuerzo))
            {
                if (!((bool)dt_num.Rows[0]["Almuerzo"]))
                {
                    string[] tiemp_extra = txtHoraExtra.Text.Split(',');
                    int hor = int.Parse(tiemp_extra[0].ToString());
                    hor = hor + 1;
                    txtHoraExtra.Text = hor + "," + tiemp_extra[1];
                    comidas[1] = true;
                }
            }
            else
            {
                comidas[1] = false;
            }
            #endregion

            #region CAFE
            TimeSpan inicio_cafe = new TimeSpan(15, 15, 00);
            TimeSpan final_cafe = new TimeSpan(15, 30, 00);

            if ((inicio.TimeOfDay >= inicio_cafe && inicio.TimeOfDay < final_cafe) || (final.TimeOfDay >= inicio_cafe && final.TimeOfDay <= final_cafe) || (inicio.TimeOfDay < inicio_cafe && final.TimeOfDay > final_cafe))
            {
                if (!((bool)dt_num.Rows[0]["Cafe"]))
                {
                    string[] tiemp_extra = txtHoraExtra.Text.Split(',');
                    int min = int.Parse(tiemp_extra[1].ToString());
                    min = min + 2;
                    txtHoraExtra.Text = tiemp_extra[0] + "," + min;
                    comidas[2] = true;
                }
            }
            else
            {
                comidas[2] = false;
            }

            #endregion

            return comidas;
        }

        protected bool Valida_tiempo_agregar(DateTime inicio, string htazada, string textra, string idtecnico, string numero)
        {
            int[] arreglo_hoy = new int[42];
            int[] arreglo_manana = new int[42];

            for (int j = 0; j < 42; j++)
            {
                arreglo_hoy[j] = 0;
                arreglo_manana[j] = 0;
            }

            #region calcular horas

            TimeSpan formate = formatear(htazada);
            TimeSpan horextra = formatear(textra);
            formate = formate.Add(horextra);
            DateTime final = inicio;
            final = final.Add(formate);

            #endregion

            #region seleciona las ordenes del tecnico
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            string query = "select * from GT_Ordenes Where idTecnico = '" + idtecnico + "' and numero !='" + numero + "' and Area = '" + Session["sel_area"].ToString() + "' order by horaInicio Asc";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            #endregion

            #region LLENAMOS LOS ARRAY CON 1 SI EL CUPO ESA HORA ESTA OCUPADA
            DateTime corredor = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 00);

            for (int x = 0; x < dt.Rows.Count; x++)
            {
                DateTime inicioviejo = (DateTime)dt.Rows[x]["horaInicio"];
                DateTime finalviejo = (DateTime)dt.Rows[x]["horaFinal"];
                corredor = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 00);
                if (inicioviejo.Date == DateTime.Now.Date)
                {
                    for (int y = 0; y < 42; y++)
                    {
                        if (corredor >= finalviejo)
                        {
                            y = 42;
                        }
                        else
                        {
                            if (corredor >= inicioviejo)
                            {
                                arreglo_hoy[y] = 1;
                            }
                            corredor = corredor.AddMinutes(15);
                        }
                    }

                }
                else
                {
                    corredor = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 00);
                    corredor = corredor.AddDays(1);
                    for (int y = 0; y < 42; y++)
                    {
                        if (corredor >= finalviejo)
                        {
                            y = 42;
                        }
                        else
                        {
                            if (corredor >= inicioviejo)
                            {
                                arreglo_manana[y] = 1;
                            }
                            corredor = corredor.AddMinutes(15);
                        }
                    }
                }
            }
            #endregion

            TimeSpan limite = new TimeSpan(17, 30, 00);
            if (final.TimeOfDay < limite)
            {
                corredor = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 00);

                for (int xx = 0; xx < 42; xx++)
                {
                    if (corredor >= final)
                    {
                        xx = 42;
                    }
                    else
                    {
                        if (corredor >= inicio)
                        {
                            if (arreglo_hoy[xx] == 1)
                            {
                                MessageBoxShow(this, "Choque entre Ordenes. No se puede crear una orden con estos tiempos ");
                                return false;
                            }
                        }
                        corredor = corredor.AddMinutes(15);
                    }
                }

            }
            else
            {
                corredor = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 00);

                for (int xx = 0; xx < 42; xx++)
                {
                    if (corredor >= final)
                    {
                        xx = 42;
                    }
                    else
                    {
                        if (corredor >= inicio)
                        {
                            if (arreglo_hoy[xx] == 1)
                            {
                                MessageBoxShow(this, "Choque entre Ordenes. No se puede crear una orden con estos tiempos ");
                                return false;
                            }
                        }
                        corredor = corredor.AddMinutes(15);
                    }
                }

                TimeSpan resta = final.TimeOfDay.Subtract(limite);
                DateTime final_split = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 00);
                final_split = final_split.AddDays(1);
                final_split = final_split.Add(resta);
                DateTime inicio_split = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 00);
                inicio_split = inicio_split.AddDays(1);


                corredor = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 00);
                corredor = corredor.AddDays(1);

                for (int xx = 0; xx < 42; xx++)
                {
                    if (corredor >= final_split)
                    {
                        xx = 42;
                    }
                    else
                    {
                        if (corredor >= inicio_split)
                        {
                            if (arreglo_manana[xx] == 1)
                            {
                                MessageBoxShow(this, "Choque entre Ordenes. No se puede crear una orden con estos tiempos ");
                                return false;
                            }
                        }
                        corredor = corredor.AddMinutes(15);
                    }
                }

            }

            return true;
        }

        private bool Agregar_registro(int id, string dpTecnico, DateTime dpHoraInicio, string htazada, string dpStatus, bool finalizado, string hextra, int area, bool desayuno, bool almuerzo, bool cafe)
        {
            bool movido = false;
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
                movido = true;
            }

            #endregion
            //ver si cabe en el mismo día o si hay que hacer split de 2 días
            DateTime limite = DateTime.Parse("17:30:00");
            if (fechafinal.TimeOfDay <= limite.TimeOfDay)
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                con.Open();
                SqlTransaction tr = con.BeginTransaction(IsolationLevel.Serializable);
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[GT_Ordenes] ([numero],[horaInicio],[horaTasada],[horaFinal],[status],[idTecnico], [pasado], [horaextra], [area], [Desayuno], [Almuerzo], [Cafe]) VALUES(@numero, @horainicio, @horatasada, @horafinal, @status, @idtecnico, @finalizado, @horaextras, @area, @desayuno, @almuerzo, @cafe ) ", con, tr);
                cmd.Parameters.Add("@numero", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@horainicio", SqlDbType.DateTime).Value = fechainicio;
                cmd.Parameters.Add("@horafinal", SqlDbType.DateTime).Value = fechafinal;
                cmd.Parameters.Add("@horatasada", SqlDbType.VarChar).Value = htazada;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = dpStatus;
                cmd.Parameters.Add("@idtecnico", SqlDbType.Int).Value = dpTecnico;
                cmd.Parameters.Add("@finalizado", SqlDbType.Int).Value = finalizado;
                cmd.Parameters.Add("@horaextras", SqlDbType.VarChar).Value = hextra;
                cmd.Parameters.Add("@area", SqlDbType.Int).Value = area;
                cmd.Parameters.Add("@desayuno", SqlDbType.Int).Value = desayuno;
                cmd.Parameters.Add("@almuerzo", SqlDbType.Int).Value = almuerzo;
                cmd.Parameters.Add("@cafe", SqlDbType.Int).Value = cafe;
                try
                {
                    //Ejecuto
                    cmd.ExecuteNonQuery();
                    tr.Commit(); //Actualizar bd                                
                    //Response.Redirect("GT_Planografo_Digital.aspx", false);
                    return movido;
                }
                catch (Exception ex)
                {
                    //De haber un error lo capturo
                    // msg = ex.Message;
                    //Deshacemos la operacion
                    tr.Rollback();
                    return movido;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[GT_Ordenes] ([numero],[horaInicio],[horaTasada],[horaFinal],[status],[idTecnico], [pasado], [horaextra], [area], [Desayuno], [Almuerzo], [Cafe]) VALUES(@numero, @horainicio, @horatasada, @horafinal, @status, @idtecnico, @finalizado, @horaextras, @area, @desayuno, @almuerzo, @cafe ) ", con, tr);
                cmd.Parameters.Add("@numero", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@horainicio", SqlDbType.DateTime).Value = fechainicio;
                cmd.Parameters.Add("@horafinal", SqlDbType.DateTime).Value = fecha_partida;
                cmd.Parameters.Add("@horatasada", SqlDbType.VarChar).Value = htazada;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = dpStatus;
                cmd.Parameters.Add("@idtecnico", SqlDbType.Int).Value = dpTecnico;
                cmd.Parameters.Add("@finalizado", SqlDbType.Int).Value = finalizado;
                cmd.Parameters.Add("@horaextras", SqlDbType.VarChar).Value = hextra;
                cmd.Parameters.Add("@area", SqlDbType.Int).Value = area;
                cmd.Parameters.Add("@desayuno", SqlDbType.Int).Value = desayuno;
                cmd.Parameters.Add("@almuerzo", SqlDbType.Int).Value = almuerzo;
                cmd.Parameters.Add("@cafe", SqlDbType.Int).Value = cafe;
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
                    return movido;
                }
                finally
                {
                    con.Close(); //Cerramos la conexion

                }

                con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                con.Open();
                tr = con.BeginTransaction(IsolationLevel.Serializable);
                cmd = new SqlCommand("INSERT INTO [dbo].[GT_Ordenes] ([numero],[horaInicio],[horaTasada],[horaFinal],[status],[idTecnico], [pasado], [horaextra], [Area], [Desayuno], [Almuerzo], [Cafe]) VALUES(@numero, @horainicio, @horatasada, @horafinal, @status, @idtecnico, @finalizado, @horaextras, @area, @desayuno, @almuerzo, @cafe ) ", con, tr);

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
                cmd.Parameters.Add("@area", SqlDbType.Int).Value = area;
                cmd.Parameters.Add("@desayuno", SqlDbType.Int).Value = desayuno;
                cmd.Parameters.Add("@almuerzo", SqlDbType.Int).Value = almuerzo;
                cmd.Parameters.Add("@cafe", SqlDbType.Int).Value = cafe;
                try
                {
                    //Ejecuto
                    cmd.ExecuteNonQuery();
                    tr.Commit(); //Actualizar bd                        
                    //Response.Redirect("GT_Planografo_Digital.aspx", false);
                    return movido;
                }
                catch (Exception ex)
                {
                    //De haber un error lo capturo
                    // msg = ex.Message;
                    //Deshacemos la operacion
                    tr.Rollback();
                    return movido;
                }
                finally
                {
                    con.Close(); //Cerramos la conexion

                }

            }
        }

        private void Eliminar_en_estado(string p)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            con.Open();
            SqlTransaction tr = con.BeginTransaction(IsolationLevel.Serializable);
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[GT_Ordenes_Estado] WHERE numero = '" + p + "'", con, tr);
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
            }
            finally
            {
                con.Close(); //Cerramos la conexion

            }
        }

        private void Agregar_A_Estados(int id, string dpTecnico, string dpStatus)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            con.Open();
            SqlTransaction tr = con.BeginTransaction(IsolationLevel.Serializable);
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[GT_Ordenes_Estado] ([numero],[idTecnico], [Status]) VALUES(@numero, @idtecnico, @status ) ", con, tr);
            cmd.Parameters.Add("@numero", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = dpStatus;
            cmd.Parameters.Add("@idtecnico", SqlDbType.Int).Value = dpTecnico;

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

            }
            finally
            {
                con.Close(); //Cerramos la conexion

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

        private void Mover_modificacion(DataTable dt_num)
        {

            TimeSpan mover_otros = new TimeSpan();
            DateTime inicio = (DateTime)dt_num.Rows[0]["HoraInicio"];
            TimeSpan nuevo = TimeSpan.Parse(drpHoraInicio.SelectedValue);

            mover_otros = nuevo.Subtract(inicio.TimeOfDay);

            if (dt_num.Rows[0]["horaTasada"].ToString() != htazada.Text)
            {
                string[] tazada = htazada.Text.Split(',');
                TimeSpan tstazada = new TimeSpan(int.Parse(tazada[0].ToString()), int.Parse(tazada[1].ToString()) * 6, 0);

                string[] tazada_db = dt_num.Rows[0]["horaTasada"].ToString().Split(',');
                TimeSpan tstazada_db = new TimeSpan(int.Parse(tazada_db[0].ToString()), int.Parse(tazada_db[1].ToString()) * 6, 0);

                TimeSpan resta_tasada = tstazada.Subtract(tstazada_db);

                mover_otros = mover_otros.Add(resta_tasada);
            }

            if (dt_num.Rows[0]["horaExtra"].ToString() != txtHoraExtra.Text)
            {
                string[] tazada = txtHoraExtra.Text.Split(',');
                TimeSpan tstazada = new TimeSpan(int.Parse(tazada[0].ToString()), int.Parse(tazada[1].ToString()) * 6, 0);

                string[] tazada_db = dt_num.Rows[0]["horaExtra"].ToString().Split(',');
                TimeSpan tstazada_db = new TimeSpan(int.Parse(tazada_db[0].ToString()), int.Parse(tazada_db[1].ToString()) * 6, 0);

                TimeSpan resta_tasada = tstazada.Subtract(tstazada_db);

                mover_otros = mover_otros.Add(resta_tasada);
            }
            mover_otros = format_timespan(mover_otros);
            cambiar_Otros(mover_otros, dt_num.Rows[0]["numero"].ToString(), (int)dt_num.Rows[0]["idTecnico"], inicio);

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
                TimeSpan tiemp = new TimeSpan(int.Parse(tiempo.Hours.ToString()) + 1, 00, 0);
                return tiemp;
            }
            return tiempo;
        }

        private void MessageBoxShow(Page page, string message)
        {
            Literal ltr = new Literal();
            ltr.Text = @"<script type='text/javascript'> alert('" + message + "') </script>";
            page.Controls.Add(ltr);
        }

        private DateTime Mover_Ordenes(int id, DateTime final, int ord_mod)
        {
            DateTime actual = DateTime.Now;
            actual = format_hora_prox(actual);

            TimeSpan resta = final.TimeOfDay.Subtract(actual.TimeOfDay);
            int adelantado = resta.Minutes + resta.Hours * 60;
            if (adelantado > 0)
            {

                SqlConnection conex = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                string query1 = "select DISTINCT numero from GT_Ordenes where Area = '" + Session["sel_area"].ToString() + "'";
                conex.Open();

                SqlCommand cmd1 = new SqlCommand(query1, conex);
                SqlDataAdapter dad = new SqlDataAdapter(cmd1);
                DataTable dt_num = new DataTable();
                dad.Fill(dt_num);

                conex.Close();



                for (int x = 0; x < dt_num.Rows.Count; x++)
                {
                    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                    string query = "select  * from GT_Ordenes where numero = '" + dt_num.Rows[x]["numero"] + "' and idOrdenes != '" + ord_mod.ToString() + "' and Area = '" + Session["sel_area"].ToString() + "'  ORDER by horaInicio ASC";
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

                    DateTime limite = new DateTime(new_inicio.Year, new_inicio.Month, new_inicio.Day, 7, 30, 00);
                    if ((new_inicio.Date > DateTime.Now.Date) && (new_inicio.TimeOfDay < limite.TimeOfDay))
                    {
                        new_inicio = new_inicio.AddHours(-14);
                    }

                    //string hora_env = new_inicio;
                    bool finalizado = (bool)dt.Rows[0]["pasado"];

                    string htazad = dt.Rows[0]["horaTasada"].ToString();
                    Eliminar_registro(idordenes);
                    Agregar_registro(idordenes, dpTecnico, new_inicio, htazad, dpStatus, finalizado, dt.Rows[0]["horaExtra"].ToString(), (int)dt.Rows[0]["Area"], (bool)dt.Rows[0]["Desayuno"], (bool)dt.Rows[0]["Almuerzo"], (bool)dt.Rows[0]["Cafe"]);
                }
                return actual;
            }
            else
            {
                return final;
            }

        }

        private TimeSpan format_timespan(TimeSpan p)
        {
            TimeSpan nuevo = new TimeSpan();
            int hora = p.Hours;
            int min = p.Minutes;
            if (min > 0 && min < 15)
            {
                nuevo = new TimeSpan(hora, 15, 0);
                //nuevo = nuevo.AddMinutes(15);
                return nuevo;
            }
            if (min > 15 && min < 30)
            {
                nuevo = new TimeSpan(hora, 30, 0);
                //nuevo = nuevo.AddMinutes(30);
                return nuevo;
            }
            if (min > 30 && min < 45)
            {
                nuevo = new TimeSpan(hora, 45, 00);
                //nuevo = nuevo.AddMinutes(45);
                return nuevo;
            }
            if (min > 45 && min < 60)
            {
                nuevo = new TimeSpan(hora + 1, 0, 0);
                //nuevo = nuevo.AddMinutes(00);
                return nuevo;
            }

            //------------------------si es negativo //
            if (min < 0 && min > -15)
            {
                if (hora < 0)
                {
                    nuevo = new TimeSpan(hora + 1, 00, 0);
                    //nuevo = nuevo.AddMinutes(15);
                    return nuevo;
                }
                else
                {
                    nuevo = new TimeSpan(0, 00, 0);
                    //nuevo = nuevo.AddMinutes(15);
                    return nuevo;
                }

            }
            if (min < -15 && min > -30)
            {
                nuevo = new TimeSpan(hora, -15, 0);
                //nuevo = nuevo.AddMinutes(30);
                return nuevo;
            }
            if (min < -30 && min > -45)
            {
                nuevo = new TimeSpan(hora, -30, 00);
                //nuevo = nuevo.AddMinutes(45);
                return nuevo;
            }
            if (min < -45 && min > -60)
            {
                nuevo = new TimeSpan(hora, -45, 00);
                //nuevo = nuevo.AddMinutes(00);
                return nuevo;
            }

            return p;
        }

        private void cambiar_Otros(TimeSpan mover_otros, string id, int id_tecnico, DateTime cambiado)
        {
            SqlConnection conex = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            string query1 = "select DISTINCT numero from GT_Ordenes where Area = '" + Session["sel_area"].ToString() + "' and idTecnico = '" + id_tecnico + "'";
            conex.Open();

            SqlCommand cmd1 = new SqlCommand(query1, conex);
            SqlDataAdapter dad = new SqlDataAdapter(cmd1);
            DataTable dt_num = new DataTable();
            dad.Fill(dt_num);

            conex.Close();

            for (int x = 0; x < dt_num.Rows.Count; x++)
            {
                int xx = int.Parse(dt_num.Rows[x]["numero"].ToString());
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                string query = "select  * from GT_Ordenes where numero = '" + dt_num.Rows[x]["numero"] + "' and numero != '" + id + "' and idTecnico = '" + id_tecnico + "' and Area = '" + Session["sel_area"].ToString() + "'  ORDER by horaInicio ASC";
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                if (dt.Rows.Count > 0)
                {
                    DateTime inicio_viejo = DateTime.Parse(dt.Rows[0]["horaInicio"].ToString());
                    if (inicio_viejo > cambiado)
                    {
                        int idordenes = int.Parse(dt.Rows[0]["numero"].ToString());
                        string dpTecnico = dt.Rows[0]["idTecnico"].ToString();
                        string dpStatus = dt.Rows[0]["Status"].ToString();

                        DateTime new_inicio = DateTime.Parse(dt.Rows[0]["horaInicio"].ToString()).Add(mover_otros);

                        DateTime limite = new DateTime(new_inicio.Year, new_inicio.Month, new_inicio.Day, 7, 30, 00);
                        TimeSpan limite2 = new TimeSpan(17, 15, 00);
                        if ((new_inicio.Date > DateTime.Now.Date) && (new_inicio.TimeOfDay < limite.TimeOfDay))
                        {
                            new_inicio = new_inicio.AddHours(-14);
                            //new_inicio = new_inicio.AddMinutes(-15);
                        }

                        if ((new_inicio.TimeOfDay > limite2))
                        {
                            new_inicio = new_inicio.AddHours(14);
                            //new_inicio = new_inicio.AddMinutes(15);
                        }

                        //string hora_env = new_inicio;
                        bool finalizado = (bool)dt.Rows[0]["pasado"];

                        string htazad = dt.Rows[0]["horaTasada"].ToString();
                        Eliminar_registro(idordenes);
                        Agregar_registro(idordenes, dpTecnico, new_inicio, htazad, dpStatus, finalizado, dt.Rows[0]["horaExtra"].ToString(), (int)dt.Rows[0]["Area"], (bool)dt.Rows[0]["Desayuno"], (bool)dt.Rows[0]["Almuerzo"], (bool)dt.Rows[0]["Cafe"]);
                    }
                }
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

        private void comentarios()
        {
            string numero;
            //optener # de orden
            if (Button1.Text == "Agregar")
            {
                numero = drpOt.SelectedValue;

            }
            else
            {
                numero = Session["id_modf"].ToString();
            }

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            string query = "SELECT * FROM [GT_AutoStar].[dbo].[GT_Orden_Trabajo] where numeroOrden = '" + numero + "'";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            txtComentario.Text = dt.Rows[0]["comentarios"].ToString();


        }

        private void llenarCliente(string sender)
        {
            var numero = sender;
            int id_asesor = 0;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            string query = "SELECT * FROM [GT_AutoStar].[dbo].[GT_Orden_Trabajo] where numeroOrden = '" + numero + "'";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                txtCliente.Text = dt.Rows[0]["cliente"].ToString();
                id_asesor = int.Parse(dt.Rows[0]["idAsesor"].ToString());

            }
            SqlConnection con2 = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            string query2 = "SELECT * FROM [GT_AutoStar].[dbo].[GT_Usuarios] where idUsuario = '" + id_asesor + "'";
            con2.Open();
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                txtAsesor.Text = dt2.Rows[0]["nombre"].ToString() + " " + dt2.Rows[0]["apellido1"].ToString() + " " + dt2.Rows[0]["apellido2"].ToString();
            }
            con2.Close();
        }

        protected void htazada_TextChanged(object sender, EventArgs e)
        {
            Page.Validate("validar");
            if (Page.IsValid)
            {
                horatazadaCalcular();
            }

        }

        private void horatazadaCalcular()
        {
            DateTime fechainicio_Aux = DateTime.Parse(Session["fecha_consulta"].ToString());  //Calendar1.SelectedDate;
            DateTime fechainicio = new DateTime(fechainicio_Aux.Year, fechainicio_Aux.Month, fechainicio_Aux.Day, 0, 0, 0);

            string[] inicio = drpHoraInicio.SelectedValue.Split(':');
            fechainicio = fechainicio.AddHours(int.Parse(inicio[0]));
            fechainicio = fechainicio.AddMinutes(int.Parse(inicio[1]));
            fechainicio = fechainicio.AddSeconds(int.Parse(inicio[2]));

            string[] hora_taza = htazada.Text.Split(',');
            TimeSpan hhtazada = new TimeSpan(int.Parse(hora_taza[0].ToString()), int.Parse(int.Parse(hora_taza[1]).ToString()) * 6, 0);

            txtHorareal.Text = hhtazada.ToString();

            string[] hora_extra = txtHoraExtra.Text.Split(',');
            TimeSpan hhamp = new TimeSpan(int.Parse(hora_extra[0].ToString()), int.Parse(int.Parse(hora_extra[1]).ToString()) * 6, 0);
            txtTiemAmp.Text = hhamp.ToString();

            DateTime fechafinal = fechainicio;
            //string[] final = drpHoraFinal.SelectedValue.Split(':');
            fechafinal = fechafinal.AddHours(int.Parse(hora_taza[0]));
            fechafinal = fechafinal.AddHours(int.Parse(hora_extra[0]));
            fechafinal = fechafinal.AddMinutes(int.Parse(hora_taza[1]) * 6);
            fechafinal = fechafinal.AddMinutes(int.Parse(hora_extra[1]) * 6);
            string[] text = fechafinal.ToString().Split(' ');
            txthorafinal.Text = text[1];
        }

        protected void ImageButton5_Click1(object sender, ImageClickEventArgs e)
        {
            string numero;
            //optener # de orden
            if (Button1.Text == "Agregar")
            {
                numero = drpOt.SelectedValue;

            }
            else
            {
                numero = Session["id_modf"].ToString();
            }

            if (txtComentario.Visible == true)
            {
                txtComentario.Visible = false;
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
                con.Open();
                SqlTransaction tr = con.BeginTransaction(IsolationLevel.Serializable);
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[GT_Orden_Trabajo] SET [comentarios] = @comentario WHERE numeroOrden = @numero", con, tr);
                cmd.Parameters.Add("@numero", SqlDbType.VarChar).Value = numero;
                cmd.Parameters.Add("@comentario", SqlDbType.VarChar).Value = txtComentario.Text;

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

                }
                finally
                {
                    con.Close(); //Cerramos la conexion

                }


            }
            else
            {
                txtComentario.Visible = true;
                comentarios();
            }
        }

        private void limpiarcampos()
        {
            htazada.Text = "0,0";
            txtHorareal.Text = "";
            txtHoraExtra.Text = "0,0";
            txtTiemAmp.Text = "";
            txthorafinal.Text = "";
        }

        #region Cargar Dropdown
        private void cargarStatus()
        {
            drpStatus.Items.Clear();

            ListItem pr = new ListItem("En proceso", "En proceso");
            ListItem pr2 = new ListItem("Programada", "Programada");
            ListItem pr3 = new ListItem("Finalizada", "Finalizada");
            ListItem pr4 = new ListItem("Activa", "Activa");
            ListItem pr6 = new ListItem("Aire Acondicionado", "Aire Acondicionado");
            ListItem pr7 = new ListItem("Alineado", "Alineado");
            ListItem pr8 = new ListItem("Control de calidad", "Control de calidad");
            ListItem pr9 = new ListItem("Pendiente de repuestos", "Pendiente de repuestos");
            ListItem pr10 = new ListItem("Pendiente de aprobación cliente", "Pendiente de aprobación cliente");
            ListItem pr11 = new ListItem("Trabajos de taller externo", "Trabajos de taller externo");

            drpStatus.Items.Add(pr);
            drpStatus.Items.Add(pr2);
            drpStatus.Items.Add(pr3);
            drpStatus.Items.Add(pr4);
            drpStatus.Items.Add(pr6);
            drpStatus.Items.Add(pr7);
            drpStatus.Items.Add(pr8);
            drpStatus.Items.Add(pr9);
            drpStatus.Items.Add(pr10);
            drpStatus.Items.Add(pr11);
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
            string query = "SELECT * FROM [GT_AutoStar].[dbo].[GT_Usuarios] Where idRol = '1' and Activo = '1'";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            drpTecnico.DataSource = dt;
            drpTecnico.DataValueField = "idUsuario";
            drpTecnico.DataTextField = "nombre";
            drpTecnico.DataBind();
        }

        private void cargarOrdenes()
        {
            drpOt.Items.Clear();

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GT_AutoStar;Integrated Security=True");
            string query = "select [numeroOrden] FROM [GT_AutoStar].[dbo].[GT_Orden_Trabajo] left join [GT_AutoStar].[dbo].[GT_Ordenes]  on [GT_Orden_Trabajo].[numeroOrden] = [GT_Ordenes].[numero] left join [GT_AutoStar].[dbo].[GT_Ordenes_Estado] ON [GT_Orden_Trabajo].[numeroOrden] = [GT_Ordenes_Estado].[numero] where [GT_Ordenes].[idOrdenes] is null and [GT_Ordenes_Estado].[numero] is null";
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


        
    }
}