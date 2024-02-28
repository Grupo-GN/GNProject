using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Presistence;
using BusienssLogic.CA.oFiltros;
using BusienssLogic.CA.oControlAsistencia;
using System.Data;
using System.Collections;
using BusienssLogic.CA.oPasarPlanilla;
using BusienssLogic.CA.oRegistrarMarcaciones;
using BusienssLogic.CA.oGenerarFaltas;
using static BusienssLogic.CA.oRegistrarMarcaciones.Controller_RegistrarMarcaciones;

namespace GNProject.Views.ControlAsisten.CA.caControlAsistencia
{
    public partial class ca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Usuario_Id"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }

                cboPlanilla.DataSource = Get_Planilla_List();
                cboPlanilla.DataValueField = "Planilla_Id";
                cboPlanilla.DataTextField = "Descripcion";
                cboPlanilla.DataBind();
                cboPlanilla.SelectedIndex = 0;
                CargarPeriodo();
                //txtfechaini.Text = DateTime.Now.ToShortDateString();
                //txtfechafin.Text = DateTime.Now.ToShortDateString();
                string usuario = Session["Usuario_Id"].ToString();
                //Cargar Localidad
                cboLocalidad.DataSource = controller_FiltrosCA.Get_Instance().Get_Localidad_List(usuario);
                cboLocalidad.DataValueField = "Area_Id";
                cboLocalidad.DataTextField = "Descripcion";
                cboLocalidad.DataBind();
                cboLocalidad.SelectedValue = "";
                cargarPersonal();
                //Cargar Personal

                ListarAsistencias();
                //20190114
                cargarCentroCosto();
                cargarTurno();


            }
        }
        private void CargarPeriodo()
        {
            ArrayList rlist = new ArrayList();
            rlist = Get_Periodo_List(cboPlanilla.SelectedValue, DateTime.Now.ToShortDateString());
            List<Periodo> rPeriodo = new List<Periodo>();
            rPeriodo = Get_Periodo_New(cboPlanilla.SelectedValue, DateTime.Now.ToShortDateString());
            CmbPeridos.DataSource = rlist;
            CmbPeridos.DataValueField = "Periodo_Id";
            CmbPeridos.DataTextField = "Descripcion";
            CmbPeridos.DataBind();
            if (rlist.Count > 0)
            {
                foreach (var item in rPeriodo)
                {
                    if (item.Periodo_Id.ToString() == CmbPeridos.SelectedValue)
                    {
                        txtfechaini.Text = item.Fecha_Ini.ToShortDateString();
                        txtfechafin.Text = item.Fecha_Fin.ToShortDateString();
                    }

                }

            }

            CmbPeridos.SelectedIndex = 0;


        }
        private void ListarAsistencias()
        {
            string usuario = Session["Usuario_Id"].ToString();
            DateTime fecha_inicio = DateTime.Parse(txtfechaini.Text);
            DateTime fecha_fin = DateTime.Parse(txtfechafin.Text);
            if (controller_ca.getInstance().Get_ListarAsistencias(fecha_inicio, fecha_fin) <= 0)
            {
                MostrarMensaje("El proceso de Registro de Asistencia para esta fecha esta cerrado. Favor de solicitar la Apertura al Area de Recursos Humanos. Gracias Gestion de negocios.");
                return;
            }
            DataTable dtAsistencias = new DataTable();
            DateTime fechaInicio = Convert.ToDateTime(this.txtfechaini.Text);
            DateTime fechaFin = Convert.ToDateTime(this.txtfechafin.Text);
            string planilla = cboPlanilla.SelectedValue;
            string periodo = CmbPeridos.SelectedValue;
            if ((cboLocalidad.SelectedValue == ""))
            {
                if ((cboPersonal.SelectedValue == "TODOS"))
                {
                    dtAsistencias = controller_ca.getInstance().Get_ListarAsistenciasMarcaciones(fechaInicio, fechaFin, "", "", usuario, planilla, periodo);
                }
                else
                {
                    dtAsistencias = controller_ca.getInstance().Get_ListarAsistenciasMarcaciones(fechaInicio, fechaFin, cboPersonal.SelectedValue, "", usuario, planilla, periodo);
                }
            }
            else if ((cboPersonal.SelectedValue == "TODOS"))
            {
                dtAsistencias = controller_ca.getInstance().Get_ListarAsistenciasMarcaciones(fechaInicio, fechaFin, "", cboLocalidad.SelectedValue, usuario, planilla, periodo);
            }
            else
            {
                dtAsistencias = controller_ca.getInstance().Get_ListarAsistenciasMarcaciones(fechaInicio, fechaFin, cboPersonal.SelectedValue, cboLocalidad.SelectedValue, usuario, planilla, periodo);
            }
            if ((dtAsistencias.Rows.Count <= 0))
            {
                lblMensaje.Text = "No hay ninguna Asistencia Registrada";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                btnCalcularHE.Visible = false;
            }
            else
            {
                lblMensaje.Text = (dtAsistencias.Rows.Count.ToString() + " Registros Encontrados.");
                lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;
                btnCalcularHE.Visible = true;
            }
            gvAsistencia.DataSource = dtAsistencias;
            gvAsistencia.DataBind();
        }


        private void MostrarMensaje(string msj)
        {
            string ScriptAlertRpta;
            ScriptAlertRpta = ("<script languaje=\'javascript\' type=\'text/javascript\'>alert(\'"
                        + (msj + "\');</script>"));
            ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertRpta", ScriptAlertRpta, false);
        }
        private void cargarPersonal()
        {
            string usuario = Session["Usuario_Id"].ToString();
            cboPersonal.DataSource = controller_ca.getInstance().Get_Personal_By_Filtros(cboLocalidad.SelectedValue, usuario, CmbPeridos.SelectedValue, cboPlanilla.SelectedValue);
            cboPersonal.DataValueField = "Personal_Id";
            cboPersonal.DataTextField = "Nombres";
            cboPersonal.DataBind();
        }
        //20190114
        private void cargarCentroCosto()
        {
            cboAsigCC.DataSource = controller_ca.getInstance().Get_CargarCentroCostos();
            cboAsigCC.DataValueField = "ccosto_id";
            cboAsigCC.DataTextField = "Descripcion";
            cboAsigCC.DataBind();
        }
        private void cargarTurno()
        {
            cboAsigTurno.DataSource = controller_ca.getInstance().Get_CargarTurnos();
            cboAsigTurno.DataValueField = "Turno_Id";
            cboAsigTurno.DataTextField = "Nombre";
            cboAsigTurno.DataBind();
        }
        //NUEVO 03.10.2020
        [WebMethod]
        public static ArrayList Get_Planilla_List()
        {
            return controller_PasarPlanilla.Get_Instance().Get_Planilla_List();
        }


        [WebMethod]
        public static ArrayList Get_Periodo_List(string Planilla_Id, string Fecha)
        {
            DateTime nfecha = DateTime.Parse(Fecha);
            return Controller_RegistrarMarcaciones.GetInstance().Get_Periodo_List(Planilla_Id, nfecha);
        }
        [WebMethod]
        public List<Periodo> Get_Periodo_New(string Planilla_Id, string fecha)
        {
            DateTime nfecha = DateTime.Parse(fecha);
            return Controller_RegistrarMarcaciones.GetInstance().Get_Periodo_New(Planilla_Id, nfecha);
        }
        //FIN 03.10.2020

        [WebMethod]
        public static List<RH_Area> Get_Localidad_List(string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Localidad_List(Personal_Id);
        }
        //30.09.2020 antiguo

        [WebMethod]
        public static List<areas_planillas_sofya> Get_Localidad_List_OLD(string Personal_Id)
        {
            return controller_FiltrosCA.Get_Instance().Get_Localidad_List_OLD(Personal_Id);
        }

        protected void cboLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvAsistencia.EditIndex = -1;
            //lblselect.Text = cmbPersonal.SelectedValue;
            cargarPersonal();
            ListarAsistencias();
        }

        protected void cboPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvAsistencia.EditIndex = -1;
            //lblselect.Text = cmbPersonal.SelectedValue;
            ListarAsistencias();
        }

        protected void txtfechaini_TextChanged(object sender, EventArgs e)
        {
            gvAsistencia.EditIndex = -1;
            //lblselect.Text = cmbPersonal.SelectedValue;
            ListarAsistencias();
        }

        protected void txtfechafin_TextChanged(object sender, EventArgs e)
        {
            gvAsistencia.EditIndex = -1;
            //lblselect.Text = cmbPersonal.SelectedValue;
            ListarAsistencias();
        }

        protected void gvAsistencia_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAsistencia.EditIndex = -1;
            ListarAsistencias();
        }

        protected void gvAsistencia_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAsistencia.EditIndex = e.NewEditIndex;
            ListarAsistencias();
        }

        protected void gvAsistencia_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string Asistencia_Id;
                Asistencia_Id = gvAsistencia.DataKeys[e.RowIndex].Value.ToString();
                TextBox txt_hora_ingreso = (TextBox)gvAsistencia.Rows[e.RowIndex].FindControl("txtHraIngreso");
                TextBox txt_hora_salida = (TextBox)gvAsistencia.Rows[e.RowIndex].FindControl("txtHraSalida");
                TextBox txt_observacion = (TextBox)gvAsistencia.Rows[e.RowIndex].FindControl("txtObservaciones");
                txt_observacion.Text = txt_observacion.Text.Split('|')[0];
                txt_observacion.Text += "| Ultima Actualizacion por :" + Session["Usuario_Id"].ToString() + " Fecha: " + DateTime.Now.ToString();

                //2018
                DropDownList cboccosto = (DropDownList)gvAsistencia.Rows[e.RowIndex].FindControl("cboccosto");
                DropDownList cboturno = (DropDownList)gvAsistencia.Rows[e.RowIndex].FindControl("cboturno");

                DataTable dtrpta;
                dtrpta = controller_ca.getInstance().Get_ControlAsistencia(int.Parse(Asistencia_Id), txt_hora_ingreso.Text, txt_hora_salida.Text, txt_observacion.Text, cboccosto.SelectedValue.ToString(), cboturno.SelectedValue.ToString());
                int rpta;
                string no_msj;
                rpta = Convert.ToInt32(dtrpta.Rows[0][0].ToString());
                no_msj = dtrpta.Rows[0][1].ToString();
                MostrarMensaje(no_msj);
                gvAsistencia.EditIndex = -1;
                ListarAsistencias();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }

        protected void gvAsistencia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAsistencia.PageIndex = e.NewPageIndex;
            ListarAsistencias();
        }

        protected void btnCalcularHE_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha_inicio;
                DateTime fecha_final;
                fecha_inicio = Convert.ToDateTime(txtfechaini.Text);
                fecha_final = Convert.ToDateTime(txtfechafin.Text);
                // Dim dt As New DataTable
                // dt = cl.RUNTABLA("fps_spu_calculos_ca_rangos_fechas", fecha_inicio, fecha_final)
                // Dim msj As String
                // msj = dt.Rows(0)(1).ToString()
                string otrom = UpdateHEWilder(fecha_inicio, fecha_final);
                lblMensajeEH.Text = otrom;
                MostrarMensaje(otrom);
                // MostrarMensaje(msj)
                ListarAsistencias();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }
        string UpdateHEWilder(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dtAsistencias = new DataTable();
            dtAsistencias = controller_ca.getInstance().Get_SelectAsistencia(fechaInicio, fechaFin, cboLocalidad.SelectedValue);
            string Asistencia_Id;
            string hora_ingreso;
            string hora_salida;
            string observacion;
            string resp;
            int con = 0;
            // Dim top As Decimal
            // If (dtAsistencias.Rows.Count > 500) Then
            //     top = dtAsistencias.Rows.Count / 500
            // End If
            // For i As Integer = 0 To top
            // Next
            foreach (DataRow dr in dtAsistencias.Rows)
            {
                Asistencia_Id = dr[0].ToString();
                //string fa = Asistencia_Id;
                //if ((Asistencia_Id == "252643"))
                //{
                //    Asistencia_Id = Asistencia_Id;
                //}
                hora_ingreso = dr[1].ToString();
                hora_salida = dr[2].ToString();
                observacion = dr[3].ToString().Trim();
                resp = controller_ca.getInstance().Get_ProcesarAsistencia(int.Parse(Asistencia_Id), hora_ingreso, hora_salida, observacion).Rows[0][1].ToString();
                if ((resp != "Se actualizo la Asistencia Satisfactoriamente."))
                {
                    con = 0;
                    return resp;
                }
                else
                {
                    con = (con + 1);
                }
            }
            return (con + "Registro Actualizado");
        }

        protected void btnactu_Click(object sender, EventArgs e)
        {
            int tipo = int.Parse(rbtipo.SelectedValue.ToString());
            string valor = txthoramod.Text.Trim();
            if (valor != "")
            {
                TimeSpan hora;
                if (TimeSpan.TryParse(valor, out hora))
                {
                    DateTime fecha;
                    if (DateTime.TryParse(DateTime.Now.ToString("dd/MM/yyyy") + " " + valor, out fecha))
                    {
                        fecha = fecha.AddSeconds(30);
                        hora = TimeSpan.Parse(fecha.ToString("hh:mm:ss"));
                        for (int i = 0; i <= gvAsistencia.Rows.Count - 1; i++)
                        {
                            CheckBox chk = (CheckBox)gvAsistencia.Rows[i].FindControl("chksel");
                            if (chk.Checked == true)
                            {
                                int asistenciaid = int.Parse(gvAsistencia.DataKeys[i].Values[0].ToString());
                                string resultado = controller_ca.getInstance().ModificarHoraIngresoSalida(asistenciaid, hora.ToString(), tipo);
                            }
                        }
                    }
                    else
                    {
                        MostrarMensaje("La información definida no tiene el formato correcto. (hh:mm)");
                        return;
                    }
                    MostrarMensaje("Información actualizada.");
                    ListarAsistencias();
                    //btnCalcularHE_Click(null, null);
                    txthoramod.Text = "";
                }
                else
                {
                    MostrarMensaje("La información definida no tiene el formato correcto. (hh:mm)");
                }
            }
            else
            {
                MostrarMensaje("La información no está definida, debe tener el formato: hh:mm ");
            }
        }

        protected void btnAsig1_Click(object sender, EventArgs e)
        {
            string ccostoid = "";
            if (cboAsigCC.SelectedValue != null)
            {
                ccostoid = cboAsigCC.SelectedValue.ToString();
                int cant = 0;
                for (int i = 0; i <= gvAsistencia.Rows.Count - 1; i++)
                {
                    CheckBox chk = (CheckBox)gvAsistencia.Rows[i].FindControl("chksel");
                    if (chk.Checked == true)
                    {
                        int asistenciaid = int.Parse(gvAsistencia.DataKeys[i].Values[0].ToString());
                        string resultado = controller_ca.getInstance().ModificarCentroCosto(asistenciaid, ccostoid);
                        if (resultado.Split('#')[0] == "true")
                        {
                            cant++;
                        }
                    }
                }
                MostrarMensaje("Información actualizada." + cant.ToString() + " filas actualizadas.");
                ListarAsistencias();
            }
            else
            {
                MostrarMensaje("Seleccione el Centro de Costo.");
            }
        }

        protected void btnAsig2_Click(object sender, EventArgs e)
        {
            string turnoid = "";
            if (cboAsigTurno.SelectedValue != null)
            {
                turnoid = cboAsigTurno.SelectedValue.ToString();
                int cant = 0;
                for (int i = 0; i <= gvAsistencia.Rows.Count - 1; i++)
                {
                    CheckBox chk = (CheckBox)gvAsistencia.Rows[i].FindControl("chksel");
                    if (chk.Checked == true)
                    {
                        int asistenciaid = int.Parse(gvAsistencia.DataKeys[i].Values[0].ToString());
                        string resultado = controller_ca.getInstance().ModificarTurno(asistenciaid, turnoid);
                        if (resultado.Split('#')[0] == "true")
                        {
                            cant++;
                        }
                    }
                }
                MostrarMensaje("Información actualizada." + cant.ToString() + " filas actualizadas.");
                ListarAsistencias();
            }
            else
            {
                MostrarMensaje("Seleccione el Turno.");
            }
        }

        protected void gvAsistencia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow row = e.Row;
                DropDownList cbocc = (DropDownList)e.Row.FindControl("cboccosto");
                if (cbocc != null)
                {
                    cbocc.DataTextField = "Descripcion";
                    cbocc.DataValueField = "ccosto_id";
                    cbocc.DataSource = controller_ca.getInstance().Get_CargarCentroCostos();
                    cbocc.DataBind();
                    cbocc.SelectedValue = gvAsistencia.DataKeys[e.Row.RowIndex].Values[1].ToString();
                }
                DropDownList cbotur = (DropDownList)e.Row.FindControl("cboturno");
                if (cbotur != null)
                {
                    cbotur.DataTextField = "Nombre";
                    cbotur.DataValueField = "Turno_Id";
                    cbotur.DataSource = controller_ca.getInstance().Get_CargarTurnos();
                    cbotur.DataBind();
                    cbotur.SelectedValue = gvAsistencia.DataKeys[e.Row.RowIndex].Values[2].ToString();
                }
            }
        }

        protected void cboPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {

            CargarPeriodo();
            cargarPersonal();
            ListarAsistencias();

        }

        protected void cboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {

            CargarPeriodo();
            cargarPersonal();
            ListarAsistencias();

        }
        // nueva accion reproceso --- 23.02.2021
        protected void btnRecalcular_Click(object sender, EventArgs e)
        {
            string Periodo_Id = "";
            string Area_Id = "";
            string Personal_id = "";
            string planilla_id = "";
            DateTime vi_fecha_inicio = DateTime.Now;
            DateTime vi_fecha_fin = DateTime.Now;
            Periodo_Id = CmbPeridos.SelectedValue;
            planilla_id = cboPlanilla.SelectedValue;
            Personal_id = cboPersonal.SelectedValue;
            Area_Id = cboLocalidad.SelectedValue;
            string F1 = DateTime.Parse(txtfechaini.Text).ToString("yyyy-MM-dd");
            string F2 = DateTime.Parse(txtfechafin.Text).ToString("yyyy-MM-dd");
            vi_fecha_inicio = DateTime.Parse(F1);
            vi_fecha_fin = DateTime.Parse(F2);
            string msgenera = "";
            string msgeliminaF = "";


            List<string> rListInsert = new List<string>();
            List<string> rListMuestra = new List<string>();
            List<MarcasN> ListMarcasN = new List<MarcasN>();
            DataTable dtpersonal = new DataTable();
            DataTable dtlimpiar = new DataTable();
            dtpersonal = Controller_CAGenerarFaltas.GetInstance().ListaPersonal(Area_Id, Periodo_Id, planilla_id);
            //Controller_CAGenerarFaltas.GetInstance().listaPersonalSinMarcaciones(Periodo_Id, Area_Id, vi_fecha_inicio, vi_fecha_fin);
            // genera faltas
            msgeliminaF = Controller_CAGenerarFaltas.GetInstance().Proceso_FaltaElimina(Periodo_Id, Area_Id, vi_fecha_inicio, vi_fecha_fin, planilla_id, Personal_id);
            msgenera = Controller_CAGenerarFaltas.GetInstance().Set_GenerarFaltas_Persona(planilla_id, Periodo_Id, Area_Id, vi_fecha_inicio.ToShortDateString(), vi_fecha_fin.ToShortDateString(), Personal_id);

            // proceso de sincronzar marcaciones
            if (Personal_id == "TODOS")
            {
                ListMarcasN = new List<MarcasN>();
                string Personal_Nuevo = "";
                foreach (DataRow item in dtpersonal.Rows)
                {
                    Personal_Nuevo = item["co_trabajador_id"].ToString();
                    ListMarcasN = Controller_RegistrarMarcaciones.GetInstance().ImportarMarcaciones2(vi_fecha_inicio, vi_fecha_fin, Personal_Nuevo);

                    if (ListMarcasN.Count > 0)
                    {

                        foreach (var N in ListMarcasN)
                        {
                            msgenera = "";
                            string salida = N.HORASALIDA.ToShortTimeString();
                            string entrada = N.HORAINGRESO.ToShortTimeString();
                            if (entrada == "00:00")
                            {
                                entrada = "";
                            }
                            if (salida == "00:00")
                            {
                                salida = "";
                            }
                            msgenera = N.CODPER + "|" + N.FECHA + "|" + entrada + "|" + salida;
                            rListInsert.Add(msgenera);
                        }
                    }

                    dtlimpiar = Controller_CAGenerarFaltas.GetInstance().LimpiaMarcas(item["Personal_Id"].ToString());



                }
                foreach (DataRow item in dtpersonal.Rows)
                {
                    dtlimpiar = Controller_RegistrarMarcaciones.GetInstance().ActualizarFaltas(item["Personal_Id"].ToString(), "1", "");
                }
                rListMuestra = Controller_RegistrarMarcaciones.GetInstance().RegistrarMarcaciones(rListInsert);
            }
            else
            {
                string CodigoPer = "";
                foreach (DataRow item in dtpersonal.Rows)
                {
                    if (item["Personal_Id"].ToString() == Personal_id)
                    {
                        CodigoPer = item["co_trabajador_id"].ToString();
                        break;
                    }
                }
                if (CodigoPer != "")
                {
                    dtlimpiar = Controller_CAGenerarFaltas.GetInstance().LimpiaMarcas(Personal_id);
                    ListMarcasN = new List<MarcasN>();
                    ListMarcasN = Controller_RegistrarMarcaciones.GetInstance().ImportarMarcaciones2(vi_fecha_inicio, vi_fecha_fin, CodigoPer);
                    foreach (var N in ListMarcasN)
                    {
                        msgenera = "";
                        string salida = N.HORASALIDA.ToShortTimeString();
                        string entrada = N.HORAINGRESO.ToShortTimeString();
                        if (entrada == "00:00")
                        {
                            entrada = "";
                        }
                        if (salida == "00:00")
                        {
                            salida = "";
                        }
                        msgenera = N.CODPER + "|" + N.FECHA + "|" + entrada + "|" + salida;
                        rListInsert.Add(msgenera);
                    }
                    rListMuestra = Controller_RegistrarMarcaciones.GetInstance().RegistrarMarcaciones(rListInsert);

                    dtlimpiar = Controller_RegistrarMarcaciones.GetInstance().ActualizarFaltas(Personal_id, "1", "");
                }

            }

            if (Personal_id == "TODOS")
            {
                // Response.Write("<script language=javascript>alert('EL PROCESO PARA TODOS LOS EMPLEADOS SE REGISTRO CON EXITO');</script>");
                MostrarMensaje("EL PROCESO PARA TODOS LOS EMPLEADOS SE REGISTRO CON EXITO");

            }
            else
            {
                string cadena = "EL PROCESO PARA " + cboPersonal.SelectedItem.ToString() + " SE REGISTRO CON EXITO";
                MostrarMensaje(cadena);
                //Response.Write("<script language=javascript>alert("+ cadena + ");</script>");

            }
            ListarAsistencias();

            // rListMuestra = Controller_RegistrarMarcaciones.GetInstance().RegistrarMarcaciones(rListInsert);




        }

        protected void btnFalta_Click(object sender, EventArgs e)
        {

            if (chkreprocesar.Checked == false)
            {
                btnFalta.Text = "REASIGNAR FALTAS";
                int cant = 0;
                DataTable dt_falta = new DataTable();
                for (int i = 0; i <= gvAsistencia.Rows.Count - 1; i++)
                {
                    CheckBox chk = (CheckBox)gvAsistencia.Rows[i].FindControl("chksel");
                    if (chk.Checked == true)
                    {
                        int asistenciaid = int.Parse(gvAsistencia.DataKeys[i].Values[0].ToString());
                        string resultado = Controller_CAGenerarFaltas.GetInstance().Actualizar_Falta(asistenciaid);

                        if (resultado == "OK")
                        {
                            cant++;
                        }
                    }
                }
                MostrarMensaje("Información actualizada." + cant.ToString() + " filas actualizadas.");
                ListarAsistencias();
            }
            else
            {
                //reprocesamos las faltas 

                int cant = 0;
                DataTable dt_falta = new DataTable();
                for (int i = 0; i <= dgvfalta.Rows.Count - 1; i++)
                {
                    CheckBox chk = (CheckBox)dgvfalta.Rows[i].FindControl("chksel");
                    if (chk.Checked == true)
                    {
                        int asistenciaid = int.Parse(dgvfalta.DataKeys[i].Values[0].ToString());
                        string resultado = Controller_CAGenerarFaltas.GetInstance().Actualizar_Falta(asistenciaid);

                        if (resultado == "OK")
                        {
                            cant++;
                        }
                    }
                }
                MostrarMensaje("Información actualizada." + cant.ToString() + " filas actualizadas.");
                ListarAsistencias();
            }

        }



        protected void btnelimina_Click(object sender, EventArgs e)
        {
            int cant = 0;
            DataTable dt_falta = new DataTable();
            for (int i = 0; i <= gvAsistencia.Rows.Count - 1; i++)
            {
                CheckBox chk = (CheckBox)gvAsistencia.Rows[i].FindControl("chksel");
                if (chk.Checked == true)
                {
                    int asistenciaid = int.Parse(gvAsistencia.DataKeys[i].Values[0].ToString());
                    string resultado = Controller_CAGenerarFaltas.GetInstance().Elimina_Reg_Controlasistencia(asistenciaid);

                    if (resultado == "OK")
                    {
                        cant++;
                    }
                }
            }
            MostrarMensaje("Información Eliminada." + cant.ToString() + " filas eliminadas.");
            ListarAsistencias();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            pnl01.Visible = true;
            pnl02.Visible = false;
            btnFalta.Text = "REASIGNAR FALTAS";
        }

        protected void btnmos_Click(object sender, EventArgs e)
        {
            pnl01.Visible = false;
            pnl02.Visible = true;
            DateTime fecha_inicio = DateTime.Parse(txtfechaini.Text);
            DateTime fecha_fin = DateTime.Parse(txtfechafin.Text);
            DataTable dts = new DataTable();
            dts = Controller_CAGenerarFaltas.GetInstance().Listar_FaltasProceso(fecha_inicio, fecha_fin);
            dgvfalta.DataSource = dts;
            dgvfalta.DataBind();
            btnFalta.Text = "REPROCESAR FALTAS";
        }
    }
}