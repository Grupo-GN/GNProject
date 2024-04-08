using CAPA_ENTIDAD;
using CAPA_LOGICO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Contrato_RRHH
{
    public partial class FrmRenovaContrato : System.Web.UI.Page
    {
        Ent_Contratos objEContratos;
        Ent_Personal objEPersonal;
        CAPA_LOGICO.BUSPersonal objNegPersonal = new BUSPersonal();

        private void MasterUcFiltros_PeriodoChangedEvent(object sender, EventArgs e)
        {
            btnVer_Click(null, null);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.UcFiltros_PostBackPeriodoChangedEventHandler += new EventHandler(MasterUcFiltros_PeriodoChangedEvent);
            if (!Utils.fc_ValidaFiltros(this.Page))
            {
                if (Request.QueryString["block"] == null)
                    Response.Redirect("~/Default.aspx?block=1");

            }

            if (!Page.IsPostBack)
            {
                btnAbrirRenovarContratos.Visible = false;

                Carga_combo_Categoria_Auxiliar();

                chkEnviar.Visible = false;
                lblMen.Visible = false;
                txtMen.Visible = false;
                Label3.Visible = false;
                txtDestinatario.Visible = false;
                btnEnviar.Visible = false;

                if ((Request.QueryString["PID"] == null) == false)
                {
                    //cboPlanilla.SelectedValue = Request.QueryString"PLID");
                    //Utils.fc_obtiene_Planilla_Id=Request.QueryString["PLID"];
                    //cboPlanilla_SelectedIndexChanged(sender, e);
                    cboCategoria_Auxiliar.SelectedValue = Request.QueryString["SID"].ToString();
                    //cboPeriodo.SelectedValue = Request.QueryString("PEID");
                    btnVer_Click(sender, e);
                }
                else
                {
                    btnVer_Click(sender, e);
                }
            }

            if (Request.QueryString["N"] == "1")
            {
                Session["New"] = "1";
            }
            else
            {
                Session["New"] = "0";
            }

        }

        void Carga_combo_Categoria_Auxiliar()
        {
            Ent_Categoria_Auxiliar objECat_Aux = new Ent_Categoria_Auxiliar();
            cboCategoria_Auxiliar.DataSource = Log_Categoria_Auxiliar.Lista_Categoria_Auxiliar(objECat_Aux);
            cboCategoria_Auxiliar.DataTextField = "Descripcion";
            cboCategoria_Auxiliar.DataValueField = "Categoria_Auxiliar_Id";
            cboCategoria_Auxiliar.DataBind();
            cboCategoria_Auxiliar.Items.Insert(0, new ListItem("TODOS"));
        }
        Int32 mes;

        private void Lista_Personal(String PeriodoId, String Area, Int32 mes, String anio)
        {
            try
            {
                string Areas = "";
                if (cboCategoria_Auxiliar.SelectedValue == "TODOS")
                { Areas = "0"; }
                else
                { Areas = (cboCategoria_Auxiliar.SelectedValue); }

                objEContratos = new Ent_Contratos();
                objEContratos.PeriodoId = Utils.fc_obtiene_Periodo_Id(this);
                objEContratos.Area = Areas;
                objEContratos.Anio = anio;
                objEContratos.Mes = mes;
                DataTable dtPersonal = new DataTable();
                dtPersonal = Log_Contratos.Lista_Renovar_Contratos_RenovadosPRC(objEContratos);
                if (dtPersonal.Rows.Count == 0)
                {
                    ////Ejecuta Procedimiento para Obtener los Contratos que se vencen el mes actual
                    DataTable dtP = Log_Contratos.GenerarRegistrosFinContrato_Mes(objEContratos);
                    dtPersonal = Log_Contratos.Lista_Renovar_Contratos_RenovadosPRC(objEContratos);
                }
                //dtPersonal.Columns.Add(new DataColumn("Mod", typeof(string)));
                Session["dtPersonal"] = dtPersonal;
                grvListaPersonal.DataSource = Session["dtPersonal"];
                grvListaPersonal.DataBind();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void cboCategoria_Auxiliar_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkEnviar.Checked = false;

            lblMen.Visible = false;
            txtMen.Visible = false;
            Label3.Visible = false;
            txtDestinatario.Visible = false;
            btnEnviar.Visible = false;

            txtMen.Text = "";
            txtDestinatario.Text = "";

            btnVer_Click(null, null);
        }

        protected void btnModificar_Click(object sender, System.EventArgs e)
        {
            Session["New"] = "0";
            GridViewRow row = (GridViewRow)(((Button)sender).NamingContainer);

            Button button1 = (Button)row.FindControl("btnModificar");
            string Personal_Id = button1.CommandName.ToString().Trim();

            if (button1.Text == "Modificar")
                Session["Modificar"] = true;
            else
                Session["Modificar"] = false;

            Response.Redirect("FrmFichaCondiciones.aspx?Personal_Id=" + Personal_Id + "&Periodo_Id=" + Utils.fc_obtiene_Periodo_Id(this) + "&Seccion=" + cboCategoria_Auxiliar.SelectedValue.ToString() + "&");
        }

        protected void grvListaPersonal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            grvListaPersonal.PageIndex = e.NewPageIndex;


        }


        protected void grvListaPersonal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string fecha = "";
            //   if e.Row.RowType = DataControlRowType.DataRow 
            string nomMes = (Utils.fc_obtiene_Mes_Id_Nombre(this));
            string cadMes = nomMes.Substring(0, 4).ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (cadMes)
                {
                    case "ENER": fecha = "1"; break;
                    case "FEBR": fecha = "2"; break;
                    case "MARZ": fecha = "3"; break;
                    case "ABRI": fecha = "4"; break;
                    case "MAYO": fecha = "5"; break;
                    case "JUNI": fecha = "6"; break;
                    case "JULI": fecha = "7"; break;
                    case "AGOS": fecha = "8"; break;
                    case "SETI": fecha = "9"; break;
                    case "OCTU": fecha = "10"; break;
                    case "NOVI": fecha = "11"; break;
                    case "DICI": fecha = "12"; break;
                }
                string celda = Convert.ToDateTime(e.Row.Cells[7].Text).Month.ToString();

                if (fecha != celda)
                {
                    Button button1 = (Button)e.Row.FindControl("btnModificar");
                    button1.Text = "Modificar";
                }
            }
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Utils.fc_DisplayAlert(this, "Consultar con el Admin del sistema"); //no migrado, no se usa
                                                                               //////string Nombres = "";
                                                                               //////string NombresProx = "";
                                                                               //////string contenidoProx = "";
                                                                               //////string Personal_Id = "";


            //////foreach (GridViewRow fila in grvListaPersonal.Rows)

            //////{
            //////    CheckBox chk = (CheckBox)fila.FindControl("chkCheck");
            //////    if (chk.Checked == true)
            //////    {
            //////        Personal_Id = grvListaPersonal.DataKeys[fila.RowIndex].Values["Personal_Id"].ToString();

            //////        string Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
            //////        string Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);

            //////        DataTable dt = new DataTable();
            //////        dt = objNegPersonal.ListaDataxPersonalId(Personal_Id);
            //////        DataTable dt2 = new DataTable();
            //////        dt2 = objNegPersonal.ListaDataxPersonalIdAct(Personal_Id, Periodo_Id);


            //////        string Localidad = objNegPersonal.GetLocalidadxPersonal(Personal_Id);

            //////        int Seccion_Id = Convert.ToInt32(dt2.Rows[0]["Seccion_Id"].ToString());


            //////        DateTime FechaCese = (Convert.ToDateTime(dt2.Rows[0]["Fecha_cese"].ToString()));

            //////        DateTime Fech = DateTime.Parse("01/01/1900");


            //////        DateTime Fecha = DateTime.Today;

            //////        DateTime finfecha = (Convert.ToDateTime(dt2.Rows[0]["Fecha_fin_contrato"].ToString()));


            //////        string Fechita = "";

            //////        if (FechaCese != Fech && finfecha < Fecha)
            //////        {
            //////            Fechita = (Convert.ToDateTime(dt2.Rows[0]["Fecha_fin_contrato"].ToString())).ToString("MM/dd/yyyy");

            //////        }
            //////        else
            //////        {
            //////            Fechita = DateTime.Today.ToString("MM/dd/yyyy");
            //////        }
            //////        string FechaFinContrato = string.Format("{0:MM/dd/yyyy}", (Convert.ToDateTime(dt2.Rows[0]["Fecha_fin_contrato"].ToString())));
            //////        string diferencia;

            //////        DateTime FechaFin = (Convert.ToDateTime(dt2.Rows[0]["Fecha_fin_contrato"].ToString()));

            //////        if (Fecha < FechaFin)
            //////        {

            //////            List<CAPA_ENTIDAD.Ent_DiferenciaFechas> rList = new List<CAPA_ENTIDAD.Ent_DiferenciaFechas> { };
            //////            rList = Log_Contratos.DiferenciaFechas(Fechita, FechaFinContrato);


            //////            int meses = int.Parse(rList[0].Meses.ToString());
            //////            int dias = int.Parse(rList[0].Dias.ToString());

            //////            if (meses != 0)
            //////            {
            //////                if (meses == 1)
            //////                {
            //////                    if (dias == 1)
            //////                    { diferencia = meses + "mes y " + dias + " día"; }
            //////                    else
            //////                    { diferencia = meses + "mes y " + dias + " días"; }
            //////                }
            //////                else
            //////                {
            //////                    if (dias == 1)
            //////                    { diferencia = meses + "meses y " + dias + " día"; }
            //////                    else
            //////                    { diferencia = meses + "meses y " + dias + "días"; }
            //////                }
            //////            }
            //////            else
            //////            {
            //////                if (dias == 1)
            //////                { diferencia = dias + " día"; }
            //////                else
            //////                { diferencia = dias + " días"; }
            //////            }


            //////        }

            //////        else
            //////        {
            //////            diferencia = "0";
            //////        }

            //////        DataTable dt3 = new DataTable();
            //////        dt3 = Log_Contratos.Reporte_TiempoServicio(Personal_Id, Fechita);

            //////        Nombres = Nombres + "<tr><td>" + Localidad + "</td>"
            //////                                    + "<td>" + dt.Rows[0]["Apellido_Paterno"].ToString() + " " + dt.Rows[0]["Apellido_Materno"].ToString() + " " + dt.Rows[0]["Nombres"].ToString() + "</td>"
            //////                                    + "<td>" + dt3.Rows[0]["Cargo"].ToString() + "</td>"
            //////                                    + "<td>" + string.Format("{0:dd/MM/yyyy}", (Convert.ToDateTime(dt2.Rows[0]["Fecha_ingreso"].ToString()))) + "</td>"
            //////                                    + "<td>" + string.Format("{0:dd/MM/yyyy}", (Convert.ToDateTime(dt2.Rows[0]["Fecha_ini_contrato"].ToString()))) + "</td>"
            //////                                    + "<td>" + string.Format("{0:dd/MM/yyyy}", (Convert.ToDateTime(dt2.Rows[0]["Fecha_fin_contrato"].ToString()))) + "</td>"
            //////                                     + "<td>" + dt3.Rows[0]["Anios"] + "</td><td>" + dt3.Rows[0]["Meses"] + "</td><td>" + dt3.Rows[0]["Dias"] + "</td><td>" + dt3.Rows[0]["TipoContrato"] + "</td>"
            //////                                     + "<td>" + diferencia + "</td></tr>";


            //////        int aniosprox = Convert.ToInt32(dt3.Rows[0]["Anios"].ToString());
            //////        int mesprox = Convert.ToInt32(dt3.Rows[0]["Meses"].ToString());
            //////        //if ((aniosprox == 3 && mesprox >= 4) || (aniosprox == 4 && mesprox <= 5))
            //////        if ((aniosprox == 3 && mesprox >= 11) || (aniosprox == 4 && mesprox <= 1))
            //////        {
            //////            NombresProx = NombresProx + "<tr><td>" + dt.Rows[0]["Apellido_Paterno"].ToString() + " " + dt.Rows[0]["Apellido_Materno"].ToString() + " " + dt.Rows[0]["Nombres"].ToString() + "</td></tr>";
            //////            contenidoProx = "Asimismo informamos del Personal que esta próximo a cumplir 04 años.<p><table border='1' bordercolor='black' cellspading='5'>" + NombresProx + "</table>";
            //////        }
            //////    }


            //////    chk.Checked = false;


            //////}

            //////if (Personal_Id.Trim() == string.Empty)
            //////{
            //////    Utils.fc_DisplayAlert(this, "Seleccionar un Personal");
            //////    return;
            //////}

            //////string correos = "";
            //////string destinatario = "";
            //////System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            //////string Subject = "ADMINISTRACION - Correo automatico de solicitud de renovacion de contratos de trabajo ";

            //////DataTable dtcorreos = new DataTable();
            //////dtcorreos = Log_Contratos.Lista_Correos_Contratos();

            //////try
            //////{
            //////    for (int i = 0; i <= dtcorreos.Rows.Count - 1; i++)
            //////    {
            //////        correos = dtcorreos.Rows[i]["email"].ToString();

            //////        if (correos != "")
            //////        {
            //////            msg.To.Add(correos);
            //////        }


            //////    }
            //////}
            //////catch (Exception ex)
            //////{
            //////    Utils.fc_DisplayAlert(this, "Presenta Formato Incorrecto de Correos");
            //////}

            //////if (txtDestinatario.Text != "")
            //////{
            //////    destinatario = txtDestinatario.Text.Trim();
            //////    msg.To.Add(destinatario);
            //////}

            //////msg.From = new MailAddress("info@gestiondenegociosrs.com", "Gestion de Negocios", System.Text.Encoding.UTF8);

            //////msg.Subject = Subject;
            //////msg.SubjectEncoding = System.Text.Encoding.UTF8;

            //////msg.Body = "<font style='font-family: Arial; font-size: 12px; color: #003366'>"
            //////               + "Estimado Edgardo:<p>Por medio de la presente remito la relación del personal contratado cuyo vencimiento se encuentra próximo, la cual se detalle en la relación adjunta."
            //////               + "Requiero las indicaciones del periodo de renovación o la decisión de no renovar estos contratos de trabajo.<p>"
            //////               + "Se copia la presente a la Gerencia Respectiva para la toma de decisión y su coordinación con el Area de Recursos Humanos.<p>"
            //////               + txtMen.Text + " <Br /><Br /> "
            //////               + contenidoProx + "<p>Pd. Correo de Envío automático de contratos pendiente de renovación<BR/>"
            //////               + "El cálculo del tiempo de servicio (Años, Meses, Dias) es de acuerdo a la finalización del presente contrato.<Br/><Br/>"
            //////               + "<table border='1' bordercolor='black' cellspading='5'><tr bgcolor='black'><td><font color='white'>Localidad</td>"
            //////               + "<td><font color='white'>Nombre</td><td><font color='white'>Cargo</td><td><font color='white'>FechaIngreso</td><td><font color='white'>FechaInicioContrato</td> "
            //////               + "<td><font color='white'>FechaFinContrato</td><td><font color='white'>Años</td><td><font color='white'>Meses</td><td><font color='white'>Dias</td><td><font color='white'>TipoContrato</td><td><font color='white'>Culminación</td>"
            //////               + "</tr>" + Nombres + "</table><p>Atentamente,<br>Gestion de Negocios R&S Asociados SAC.<br>www.gestiondenegociosrs.com.pe<br>Teléfonos: 4750778 – 7875740</font>";
            //////msg.IsBodyHtml = true;
            //////msg.BodyEncoding = System.Text.Encoding.UTF8;

            //////System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

            //////client.Credentials = new System.Net.NetworkCredential("info@gestiondenegociosrs.com", "soporte*ti");
            //////client.Host = "smtp.1and1.com";
            //////client.EnableSsl = true;

            //////try
            //////{
            //////    client.Send(msg);
            //////    Utils.fc_DisplayAlert(this, "La lista ha sido enviado Satisfactoriamente...");

            //////}

            //////catch (Exception ex)
            //////{
            //////    Utils.fc_DisplayAlert(this, "No se logro terminar el proceso. Error al enviar el correo. ");


            //////}




        }


        protected void chkEnviar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnviar.Checked == true)
            {
                lblMen.Visible = true;
                txtMen.Visible = true;
                Label3.Visible = true;
                txtDestinatario.Visible = true;
                btnEnviar.Visible = true;
            }
            else
            {
                lblMen.Visible = false;
                txtMen.Visible = false;
                Label3.Visible = false;
                txtDestinatario.Visible = false;
                btnEnviar.Visible = false;

                txtMen.Text = "";
                txtDestinatario.Text = "";
            }
        }
        protected void btnVer_Click(object sender, EventArgs e)
        {
            //string nomperiodo = (Utils.fc_obtiene_Periodo_Id_Nombre(this));
            //string cadperiodo = nomperiodo.Substring(0, 4).ToString();

            //switch (cadperiodo)
            //{
            //    case "ENER": mes = 1; break;
            //    case "FEBR": mes = 2; break;
            //    case "MARZ": mes = 3; break;
            //    case "JUNI": mes = 6; break;
            //    case "JULI": mes = 7; break;
            //    case "AGOS": mes = 8; break;
            //    case "SETI": mes = 9; break;
            //    case "OCTU": mes = 10; break;
            //    case "NOVI": mes = 11; break;
            //    case "DICI": mes = 12; break;
            //}

            //string Anio;
            //Anio = nomperiodo.Substring(nomperiodo.Length - 4, 4).ToString();

            Lista_Personal(Utils.fc_obtiene_Periodo_Id(this), cboCategoria_Auxiliar.SelectedValue, 0, "0");

            if (grvListaPersonal.Rows.Count <= 0)
            {
                chkEnviar.Visible = false;
                lblMensaje.Visible = true;
                lblMensaje.Text = "No Se Encontraron Datos...";

                lblMensaje.ForeColor = System.Drawing.Color.Red;
                // btnActualizarContrato.Visible = false;

                btnEnviar.Visible = false;
                btnAbrirRenovarContratos.Visible = false;
            }
            else
            {
                //chkEnviar.Visible = true;
                lblMensaje.Visible = true;
                lblMensaje.Text = grvListaPersonal.Rows.Count.ToString() + " Registros Encontrados...";
                lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;
                // btnActualizarContrato.Visible = True;
                //  btnEnviar.Visible = True
                btnAbrirRenovarContratos.Visible = true;
            }

            //btnActualizarContrato.Visible = False //TMb se oculto columna OBSERVACIONES
            btnEnviar.Visible = false;

        }

        protected void btnRenovar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones 
                int index = 0;
                string msg_error = "";
                foreach (GridViewRow row in grvListaPersonal.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chkCheck");
                    if (chk.Checked)
                    {
                        string fechafinActual = row.Cells[7].Text.Trim();
                        if (Convert.ToDateTime(fechafinActual) > Convert.ToDateTime(txtFechaInicioContrato.Text))
                        {
                            msg_error = "La fecha de inicio contrato debe ser mayor a la fecha final del contrato actual";
                            string ScriptAlertValidacion = "<script languaje='javascript' type='text/javascript'>alert('" + msg_error + "');</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertErrorValida", ScriptAlertValidacion, false);
                            return;
                        }
                    }

                    index = index + 1;
                }

                string Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
                string Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                DateTime dt_fe_ini_contrato = Convert.ToDateTime(txtFechaInicioContrato.Text);
                DateTime dt_fe_fin_contrato = Convert.ToDateTime(txtFechaFinalContrato.Text);
                index = 0;
                int cont_renovados = 0;
                int cont_error = 0;
                msg_error = "";
                foreach (GridViewRow row in grvListaPersonal.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chkCheck");
                    if (chk.Checked)
                    {
                        try
                        {
                            string Personal_Id = grvListaPersonal.DataKeys[index].Values["Personal_Id"].ToString();

                            String rpta = CAPA_DATOS.oRRHH.controllerContratoNuevo.getInstance().ActualizaFinContrato_Renovacion(Personal_Id, Planilla_Id, Periodo_Id, dt_fe_ini_contrato, dt_fe_fin_contrato);

                            cont_renovados = cont_renovados + 1;
                        }
                        catch (Exception ex)
                        {
                            cont_error = cont_error + 1;
                            msg_error = msg_error + ex.Message.Replace("'", "");
                        }
                    }

                    index = index + 1;
                }

                string msg = "";
                if (cont_renovados > 0)
                {
                    msg = "Se renovó (" + cont_renovados.ToString() + ") contrato(s) correctamente";
                }

                if (cont_error > 0)
                {
                    msg = msg + @"\n(" + cont_error.ToString() + ") error(es) en la renovación. Detalle Error: " + msg_error;
                }

                string ScriptAlertRpta = "<script languaje='javascript' type='text/javascript'>alert('" + msg + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertRpta", ScriptAlertRpta, false);
                if (cont_renovados > 0)
                {
                    mpRenovarContratos.Hide();
                    btnVer_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                string ScriptAlertRpta = "<script languaje='javascript' type='text/javascript'>alert('Error: " + ex.Message + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertError", ScriptAlertRpta, false);
            }
        }

    }
}