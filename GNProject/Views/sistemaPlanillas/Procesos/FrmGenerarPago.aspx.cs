using CAPA_DATOS;
using CAPA_ENTIDAD;
using CAPA_ENTIDAD.EntMs;
using CAPA_LOGICO;
using GNProject.Acceso;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Procesos
{
    public partial class FrmGenerarPago : System.Web.UI.Page
    {
        private void MasterUcFiltros_PeriodoChangedEvent(object sender, EventArgs e)
        {
            chkAcumMontos.Checked = false;
            chkAcumMontos_CheckedChanged(null, null);
        }
        //@001 F

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.UcFiltros_PostBackPeriodoChangedEventHandler += new EventHandler(MasterUcFiltros_PeriodoChangedEvent); //@001 I/F
            if (!Page.IsPostBack)
            {
                cargarBancos();
                cargarProcesos();
                cargarPersonal();
                cargarFiltros();
            }
        }
        private void cargarBancos()
        {
            //@003 I
            //cboBanco.DataSource = controller_GenerarArchivoBancos.getinstance().ListarBancosCombo();
            //cboBanco.DataTextField = "Descripcion";
            //cboBanco.DataValueField = "Banco_Id";
            //cboBanco.DataBind();

            String Compania_Id = Utils.fc_obtiene_Compania_Id(this);
            List<eCta_Compania> oLista_CtaCia = controllerCtaCompania.getinstance().ListarCtasCompania(Compania_Id);
            cboBanco.DataSource = oLista_CtaCia.FindAll(obj => obj.Moneda_Id == "MN"); //Soles
            cboBanco.DataTextField = "Banco";
            cboBanco.DataValueField = "Banco_Id";
            cboBanco.DataBind();
            //@003 F
            // cboConcepto.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }
        private void cargarProcesos()
        {
            ProcesosBL procesosBL = new ProcesosBL();
            cboConcepto.DataSource = procesosBL.GetProcesos();
            cboConcepto.DataTextField = "Proceso";
            cboConcepto.DataValueField = "Proceso_Id";
            cboConcepto.DataBind();
            // cboConcepto.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }
        public void cargarFiltros()
        {
            Ent_RH_Area objEArea = new Ent_RH_Area();
            cboArea.DataSource = Log_RH_Area.Lista_RH_Area(objEArea);
            cboArea.DataTextField = "Descripcion";
            cboArea.DataValueField = "Area_Id";
            cboArea.DataBind();
            //cboArea.Items.Insert(0, new ListItem("-TODOS-", "")); //@004 I/F

            Ent_Categoria_Auxiliar objECatAux = new Ent_Categoria_Auxiliar();
            cboCatAuxiliar.DataSource = Log_Categoria_Auxiliar.Lista_Categoria_Auxiliar(objECatAux);
            cboCatAuxiliar.DataTextField = "Descripcion";
            cboCatAuxiliar.DataValueField = "Categoria_Auxiliar_Id";
            cboCatAuxiliar.DataBind();
            cboCatAuxiliar.Items.Insert(0, new ListItem("-TODOS-", ""));

            Ent_Proyecto objProyecto = new Ent_Proyecto();
            cboProyecto.DataSource = Log_Proyecto.Lista_Proyecto(objProyecto);
            cboProyecto.DataTextField = "Descripcion";
            cboProyecto.DataValueField = "Proyecto_Id";
            cboProyecto.DataBind();
            //cboProyecto.Items.Insert(0, new ListItem("-TODOS-", "")); //@004 I/F
        }
        void cargarPersonal()
        {
            Func<string, string> determinaConcepto = (a) =>
            {
                string retorno = "";
                if (a == "01")         //remuneracion
                    retorno = "000313";
                else if (a == "02")      //quincena
                    retorno = "000376";
                else if (a == "03")    //vacaciones
                    retorno = "000363";
                else if (a == "04")     //gratificacion
                    retorno = "000385";
                else if (a == "05")        //cts
                    retorno = "000379";
                else if (a == "06")     //provision
                    retorno = "";
                else if (a == "07")     //utilidades
                    retorno = "000542";
                else if (a == "08")     //LIQUIDACION //@002 I/F -> 07
                    retorno = "000756";
                else if (a == "09")     //PLANILLA EXTERNA QUINCENA
                    retorno = "001397";
                return retorno;
            };
            string periodo = Utils.fc_obtiene_Periodo_Id(this);
            string concepto = determinaConcepto(cboConcepto.SelectedValue.ToString());
            string banco = cboBanco.SelectedValue.ToString();

            string Area_Ids = hdfArea.Value; //@004 I/F //cboArea.SelectedValue
            string Cat_Aux_Id = cboCatAuxiliar.SelectedValue;
            string Proyecto_Ids = hdfProyecto.Value; //@004 I/F //cboProyecto.SelectedValue;
            String Periodo_Id_Desde = cboPeriodo_Desde.SelectedValue; //@001 I/F
            String Estado_Id = cboEstadoPersonal.SelectedValue; //@005 I/F

            List<Ent_ArchivoBancos> rlista = new List<Ent_ArchivoBancos>();
            rlista = controller_GenerarArchivoBancos.getinstance().ListarPersonalBancos(concepto, banco, periodo, Area_Ids, Cat_Aux_Id, Proyecto_Ids
                , Periodo_Id_Desde //@001 I/F
                , Estado_Id); //@005 I/F

            List<Ent_GenerarArchivoEstado> infor = new List<Ent_GenerarArchivoEstado>();
            int xcodi = int.Parse(cboConcepto.SelectedValue.ToString());
            infor = controller_GenerarArchivoEstado.get_Instance().ListarEstadosArchivo(xcodi, Utils.fc_obtiene_Planilla_Id(this), periodo, "").ToList();
            if (cboEstado.SelectedValue.ToString() == "2")
            {
                int cantidad = rlista.Count;
                for (int x = 0; x <= cantidad - 1; x++)
                {
                    if (infor.Where(w => w.Personal_Id == rlista[x].PersonalId && w.Estado_Id == "1").Count() > 0)
                    {
                        rlista.RemoveAt(x);
                        x--;
                        cantidad = rlista.Count;
                    }
                }
            }
            if (cboEstado.SelectedValue.ToString() == "3")
            {
                int cantidad = rlista.Count;
                for (int x = 0; x <= cantidad - 1; x++)
                {
                    if (infor.Where(w => w.Personal_Id == rlista[x].PersonalId && w.Estado_Id == "0").Count() > 0)
                    {
                        rlista.RemoveAt(x);
                        x--;
                        cantidad = rlista.Count;
                    }
                }
            }
            gvPersonal.DataSource = null;
            gvPersonal.DataBind();
            gvPersonal.DataSource = rlista;
            gvPersonal.DataBind();
            CargarInformacionEstado();
            lblMontoTotal.Text = ""; //@004 I/F
        }

        protected void cboConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarPersonal();
        }

        protected void cboBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarPersonal();
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            lblErrorTelecredito.Text = "";
            try
            {
                #region "Comentado"
                //RQ005 - 20190505
                //Verificar
                //string xplanilla = Utils.fc_obtiene_Planilla_Id(this);
                //string xperiodo = Utils.fc_obtiene_Periodo_Id(this);

                //List<Ent_GenerarArchivoEstado> infor = new List<Ent_GenerarArchivoEstado>();
                //int xcodi = int.Parse(cboConcepto.SelectedValue.ToString());
                //infor = controller_GenerarArchivoEstado.get_Instance().ListarEstadosArchivo(xcodi, xplanilla, xperiodo, "").Where(x => x.Estado_Id == "1").ToList();

                //for (int i = 0; i <= gvPersonal.Rows.Count - 1; i++)
                //{
                //    CheckBox chk = (CheckBox)gvPersonal.Rows[i].FindControl("chksel");
                //    TextBox obs = (TextBox)gvPersonal.Rows[i].FindControl("txtobs");
                //    string xperson = gvPersonal.DataKeys[i].Value.ToString();
                //    if (chk.Checked == false && obs.Text.Trim() == ""
                //        && infor.Where(d => d.Personal_Id == xperson && d.Estado_Id == "1").Count() == 0)
                //    {
                //        Utils.fc_DisplayAlert(this, "Debe justificar porque no ha seleccionado al personal " + gvPersonal.Rows[i].Cells[2].Text.Trim());
                //        return;
                //    }
                //}
                #endregion "Comentado"

                String cia = Utils.fc_obtiene_Compania_Id(this);
                String Periodo_Id_Desde = cboPeriodo_Desde.SelectedValue; //@001 I/F
                string periodo = Utils.fc_obtiene_Periodo_Id(this);
                Func<string, string> determinaConcepto = (a) =>
                {
                    string retorno = "";
                    if (a == "01")         //remuneracion
                        retorno = "000313";
                    else if (a == "02")      //quincena
                        retorno = "000376";
                    else if (a == "03")    //vacaciones
                        retorno = "000363";
                    else if (a == "04")     //gratificacion
                        retorno = "000385";
                    else if (a == "05")        //cts
                        retorno = "000379";
                    else if (a == "06")     //provision
                        retorno = "";
                    else if (a == "07")     //utilidades
                        retorno = "000542";
                    else if (a == "08")     //LIQUIDACION //@002 I/F -> 07
                        retorno = "000756";
                    else if (a == "09")     //PLANILLA EXTERNA QUINCENA
                        retorno = "001397";
                    return retorno;
                };
                string planilla = Utils.fc_obtiene_Planilla_Id(this);
                string concepto = determinaConcepto(cboConcepto.SelectedValue);
                string moneda = "MN";
                string inicioVaca = "";
                string finalVaca = "";
                string elCodigo = planilla == "01" ? "1421110521" : "1450110550";
                inicioVaca = controller_GenerarArchivoBancos.getinstance().DatosPorPeriodo(periodo)[1];
                finalVaca = controller_GenerarArchivoBancos.getinstance().DatosPorPeriodo(periodo)[2];
                //if (txtFecha_Inicio.Text == "" || txtFecha_Inicio.Text == null)
                //    inicioVaca = DateTime.Now.Date.ToShortDateString();
                //else
                //    inicioVaca = txtFecha_Inicio.Text;

                //if (txtFecha_Final.Text == "" || txtFecha_Final.Text == null)
                //    finalVaca = DateTime.Now.Date.ToShortDateString();
                //else
                //    finalVaca = txtFecha_Final.Text;

                string personalBAM = "";
                List<PersonalSeleccionadoClass> oLista_PersonalSeleccionado = new List<PersonalSeleccionadoClass>(); //@005 I/F
                for (int i = 0; i <= gvPersonal.Rows.Count - 1; i++)
                {
                    CheckBox chk = (CheckBox)gvPersonal.Rows[i].FindControl("chksel");
                    bool esto = bool.Parse(gvPersonal.DataKeys[i].Values[1].ToString());
                    if (esto == true)
                    {
                        if (chk.Checked == true)
                        {
                            personalBAM += "'" + gvPersonal.DataKeys[i].Values[0].ToString() + "',";
                            //@005 I
                            PersonalSeleccionadoClass oPersonal = new PersonalSeleccionadoClass();
                            oPersonal.Personal_Id = gvPersonal.DataKeys[i].Values[0].ToString();
                            oPersonal.Proyecto = gvPersonal.DataKeys[i].Values[2].ToString();
                            oLista_PersonalSeleccionado.Add(oPersonal);
                            //@005 F
                        }
                    }
                }

                if (oLista_PersonalSeleccionado.Count > 0)
                {
                    personalBAM = personalBAM.Remove(personalBAM.Length - 1, 1);
                }
                else
                {
                    Utils.fc_DisplayAlert(this, "No ha seleccionado a ningun personal");
                    return;
                }

                System.Data.DataTable tablita = new System.Data.DataTable();

                //@005 I
                Boolean flExportPorProyecto = chkExportPorProyecto.Checked;
                if (flExportPorProyecto && cboBanco.SelectedValue.ToString() == "38") /*INTERAMERICANO FINANZAS*/
                {
                    Utils.fc_DisplayAlert(this, "La exportación por proyecto solo está habilitado para archivos TXT");
                    return;
                }
                //@005 F

                string fl_export_excel;
                fl_export_excel = "0";

                ProcesarInformacionEstado();
                if (cboBanco.SelectedValue.ToString() == "38") /*INTERAMERICANO FINANZAS*/
                {
                    List<string> tabli = new List<string>();
                    tabli = GenerarArchivoBanBif(periodo, concepto, moneda, personalBAM
                        , Periodo_Id_Desde //@001 I/F
                    );
                    if (tabli.Count == 0)
                    {
                        lblErrorTelecredito.Text = "No hay datos para el banco seleccionado.";
                    }
                    else
                    {
                        ExportarArchivoToList("PagoBanBif", tabli);
                    }
                }
                else
                {
                    //@005 I
                    if (flExportPorProyecto)
                    {
                        var lstObjProyectos = oLista_PersonalSeleccionado.GroupBy(p => p.Proyecto);
                        List<objFile> lstFiles = new List<objFile>();
                        foreach (var objProyecto in lstObjProyectos)
                        {
                            List<PersonalSeleccionadoClass> lstPersonal = oLista_PersonalSeleccionado.FindAll(p => p.Proyecto == objProyecto.Key);
                            String codsPersonal = string.Join(",", lstPersonal.Select(i => i.Personal_Id).ToArray());
                            tablita = GetInterfaceTelecredito(cia, periodo,
                              concepto, moneda, planilla, inicioVaca, finalVaca, elCodigo
                              , cboBanco.SelectedValue, fl_export_excel, codsPersonal
                              , Periodo_Id_Desde //@001 I/F
                            );
                            if (tablita.Rows.Count > 0)
                            {
                                byte[] file = generaArchivoByte_TXT(tablita);
                                lstFiles.Add(new objFile { file = file, nomFile = "archivoPago_" + objProyecto.Key + ".txt" });
                            }
                        }
                        if (lstFiles.Count > 0)
                        {
                            DownloadZIP_MultipleFilesTXT(lstFiles, "filePagos");
                            cargarPersonal();
                        }
                        else
                        {
                            lblErrorTelecredito.Text = "No hay datos para el banco seleccionado.";
                        }
                    }
                    else
                    {
                        //@005 F
                        String codsPersonal = string.Join(",", oLista_PersonalSeleccionado.Select(i => i.Personal_Id).ToArray());

                        tablita = GetInterfaceTelecredito(cia, periodo,
                          concepto, moneda, planilla, inicioVaca, finalVaca, elCodigo
                          , cboBanco.SelectedValue, fl_export_excel, codsPersonal
                          , Periodo_Id_Desde //@001 I/F
                        );
                        if (tablita.Rows.Count == 0)
                        {
                            lblErrorTelecredito.Text = "No hay datos para el banco seleccionado.";
                        }
                        else
                        {
                            if (fl_export_excel == "1")
                            {
                                String TABLA_HTML = "";
                                if (cboBanco.SelectedValue.Trim() == "9") //Scotiabank
                                {
                                    TABLA_HTML = "<table>";
                                    TABLA_HTML += "<tr><th>Cod. Empleado</th><th>Nombre Empleado</th><th>Concepto</th><th>Fecha de Pago</th><th>Monto a Pagar</th><th>Forma de Pago</th><th>Cod. Oficina</th><th>Cod. Cuenta</th><th>Doc. Identidad</th><th>ITF</th><th>CCI</th></tr>";
                                    foreach (DataRow row in tablita.Rows)
                                    {
                                        TABLA_HTML += row[0];
                                    }
                                    TABLA_HTML += "</table>";
                                    ExportarExcel_TablaHTML("PagoBanco", TABLA_HTML);
                                }
                                else
                                {
                                    Response.Write("<script>alert('No disponible para este banco')</script>");
                                }
                            }
                            else
                            {
                                //string ruta = "laRuta";
                                //Response.Write("<script>alert('" + tablita.Rows.Count.ToString() + "')</script>");
                                //ExportarArchivoToDataTable(ruta, tablita);
                                string nombreArchivo = "filePago";
                                byte[] file = generaArchivoByte_TXT(tablita);
                                DownloadFileTXT(file, nombreArchivo);
                                cargarPersonal();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Subproceso anulado.")
                {
                    cargarPersonal();
                }
                lblErrorTelecredito.Text = "Error: " + ex.Message + "\n Verifique le número de cuenta del personal.";
            }
        }
        public System.Data.DataTable GetInterfaceTelecredito(
            string cia, string periodo, string concepto, string moneda, string planilla,
            string fechaInicial, string fechaFinal, string codigo, string banco_id, string fl_export_excel, string personal
            , String Periodo_Id_Desde //@001 I/F
        )
        {
            using (SqlConnection cn = new SqlConnection(CAPA_DATOS.Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PROC_SCIRE1_TELECREDITO_PERSONAL", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Cia", cia);
                    cmd.Parameters.AddWithValue("@UN_PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@Concepto", concepto);
                    cmd.Parameters.AddWithValue("@Moneda", moneda);
                    cmd.Parameters.AddWithValue("@Planilla", planilla);
                    cmd.Parameters.AddWithValue("@FechaIniVaca", fechaInicial);
                    cmd.Parameters.AddWithValue("@fechaFinVaca", fechaFinal);
                    cmd.Parameters.AddWithValue("@CODIGO", codigo);
                    cmd.Parameters.AddWithValue("@Banco_Id", banco_id);
                    cmd.Parameters.AddWithValue("@v_format_tabla_xls", fl_export_excel);
                    cmd.Parameters.AddWithValue("@PersonalId", personal);
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id_Desde", Periodo_Id_Desde); //@001 I/F
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        System.Data.DataTable tabla = new System.Data.DataTable();
                        tabla.Clear();
                        da.Fill(tabla);

                        return tabla;
                    }
                }
            }
        }

        private bool ExportarArchivoToList(string sFilename, List<string> tabla, string extension)
        {
            StringBuilder str = new StringBuilder();
            string s = "";
            List<string> oLista = new List<string>();
            oLista = tabla;
            if (oLista == null || oLista.Count <= 0)
                return false;
            else
                for (int i = 0; i < oLista.Count; i++)
                {
                    string miCadena = oLista.ElementAt(i);
                    s = s + HttpUtility.HtmlDecode(miCadena);
                    //sw.WriteLine(s);
                    str.Append(s);
                    str.AppendLine();
                    s = "";
                }
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + sFilename + extension);
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.text";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            Response.Write(str.ToString());
            Response.End();
            return true;
        }
        private bool ExportarArchivoToList(string sFilename, List<string> tabla)
        {

            StringBuilder str = new StringBuilder();
            string s = "";
            List<string> oLista = new List<string>();
            oLista = tabla;
            if (oLista == null || oLista.Count <= 0)
                return false;
            else
                for (int i = 0; i < oLista.Count; i++)
                {
                    string miCadena = oLista.ElementAt(i);
                    s = s + HttpUtility.HtmlDecode(miCadena);
                    //sw.WriteLine(s);
                    str.Append(s);
                    str.AppendLine();
                    s = "";
                }
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + sFilename + ".txt");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.text";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            Response.Write(str.ToString());
            Response.End();
            return true;
        }
        #region Exportaciones_Excel
        public bool ExportarExcel_TablaHTML(String nomFile, String TABLA_HTML)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + nomFile + ".xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            //Response.Write(sb.ToString());
            Response.Write(TABLA_HTML);
            Response.End();
            return true;
        }
        public bool ExportarExcelToList(List<Exportacion> dt)
        {
            String TABLA_HTML = "";
            String tbl_HTML = "<table>{0}</table>";
            String tr_HTML = "<tr>{0}</tr>";
            String td_HTML = "<td>{0}</td>";
            String td_HTML_styleText = @"<td style='mso-number-format:\@;'>{0}</td>";
            for (int i = 0; i < dt.Count; i++)
            {
                Exportacion exp = (Exportacion)dt.ElementAt(i);

                String fila = "";
                fila += String.Format(td_HTML_styleText, exp.NSecuencia);
                fila += String.Format(td_HTML, exp.CUSPP);
                fila += String.Format(td_HTML, "0");
                fila += String.Format(td_HTML_styleText, exp.nDocumento);
                fila += String.Format(td_HTML, exp.apePar);
                fila += String.Format(td_HTML, exp.apeMar);
                fila += String.Format(td_HTML, exp.Nombre);
                fila += String.Format(td_HTML, exp.tipoMov);
                fila += String.Format(td_HTML, exp.fechMov);
                fila += String.Format(td_HTML, exp.valor);
                fila += String.Format(td_HTML, exp.M_APOVOL);
                fila += String.Format(td_HTML, exp.M_APOLVOLS);
                fila += String.Format(td_HTML, exp.M_APOEMPL);
                //fila += String.Format(td_HTML, exp.Rubro);
                fila += String.Format(td_HTML, "N");
                fila += String.Format(td_HTML, exp.Datos_afp);

                TABLA_HTML += String.Format(tr_HTML, fila);
            }
            TABLA_HTML = String.Format(tbl_HTML, TABLA_HTML);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=AFP.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            //Response.Write(sb.ToString());
            Response.Write(TABLA_HTML);
            Response.End();
            return true;

            //----------------------------------------
            //////string path = Parametros.FileServerPath;
            //////if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            //////File.Delete(path + "AFP.xls"); // DELETE THE FILE BEFORE CREATING A NEW ONE.

            //////exel = new Microsoft.Office.Interop.Excel.Application();
            //////libro = exel.Workbooks.Add(Missing.Value);
            //////hoja = (Microsoft.Office.Interop.Excel.Worksheet)libro.ActiveSheet;

            //////if (dt.Count <= 0 || dt == null)
            //////{
            //////    return false;
            //////}

            //////hoja.get_Range("a1", "a100").ColumnWidth = 4;
            //////hoja.get_Range("b1", "b100").ColumnWidth = 14;
            //////hoja.get_Range("c1", "c100").ColumnWidth = 9;
            //////hoja.get_Range("d1", "d100").ColumnWidth = 11;
            //////hoja.get_Range("e1", "e100").ColumnWidth = 17;
            //////hoja.get_Range("f1", "f100").ColumnWidth = 24;
            //////hoja.get_Range("n1", "n100").ColumnWidth = 4;

            //////hoja.get_Range("c1", "c100").EntireColumn.NumberFormat = "@";

            //////int nFila = 1;
            //////for (int i = 0; i < dt.Count; i++)
            //////{
            //////    Exportacion exp = (Exportacion)dt.ElementAt(i);
            //////    hoja.Cells[i + nFila, 1] = exp.NSecuencia;
            //////    hoja.Cells[i + nFila, 2] = exp.CUSPP;
            //////    hoja.Cells[i + nFila, 3] = exp.nDocumento;
            //////    hoja.Cells[i + nFila, 4] = exp.apePar;
            //////    hoja.Cells[i + nFila, 5] = exp.apeMar;
            //////    hoja.Cells[i + nFila, 6] = exp.Nombre;
            //////    hoja.Cells[i + nFila, 7] = exp.tipoMov;
            //////    hoja.Cells[i + nFila, 8] = exp.fechMov;
            //////    hoja.Cells[i + nFila, 9] = exp.valor;
            //////    hoja.Cells[i + nFila, 10] = exp.M_APOVOL;
            //////    hoja.Cells[i + nFila, 11] = exp.M_APOLVOLS;
            //////    hoja.Cells[i + nFila, 12] = exp.M_APOEMPL;
            //////    hoja.Cells[i + nFila, 13] = exp.Rubro;
            //////    hoja.Cells[i + nFila, 14] = exp.Datos_afp;
            //////}

            //////hoja.Name = "AFP";
            ////////hoja.SaveAs(path + "AFP.xls");
            //////libro.SaveAs(path + "AFP.xls");

            ////////CLEAR.
            //////exel.Workbooks.Close();
            //////exel.Quit();
            //////exel = null;
            //////hoja = null;

            //////descargarArchivo(path, "AFP.xls");
            //////return true;
        }
        public bool ExportarExcelToList2015(List<Exportacion2015> dt)
        {
            String TABLA_HTML = "";
            String tbl_HTML = "<table>{0}</table>";
            String tr_HTML = "<tr>{0}</tr>";
            String td_HTML = "<td>{0}</td>";
            String td_HTML_styleText = @"<td style='mso-number-format:\@;'>{0}</td>";
            for (int i = 0; i < dt.Count; i++)
            {
                Exportacion2015 exp = (Exportacion2015)dt.ElementAt(i);

                String fila = "";
                fila += String.Format(td_HTML_styleText, exp.NSecuencia);
                fila += String.Format(td_HTML, exp.CUSPP);
                fila += String.Format(td_HTML, "0");
                fila += String.Format(td_HTML_styleText, exp.nDocumento);
                fila += String.Format(td_HTML, exp.apePar);
                fila += String.Format(td_HTML, exp.apeMar);
                fila += String.Format(td_HTML, exp.Nombre);
                fila += String.Format(td_HTML, exp.rl);
                fila += String.Format(td_HTML, exp.irl);
                fila += String.Format(td_HTML, exp.crl);
                fila += String.Format(td_HTML, exp.eap);
                fila += String.Format(td_HTML, exp.valor);
                fila += String.Format(td_HTML, exp.M_APOVOL);
                fila += String.Format(td_HTML, exp.M_APOLVOLS);
                fila += String.Format(td_HTML, exp.M_APOEMPL);
                //fila += String.Format(td_HTML, exp.Rubro);
                fila += String.Format(td_HTML, "N");
                fila += String.Format(td_HTML, exp.Datos_afp);

                TABLA_HTML += String.Format(tr_HTML, fila);
            }
            TABLA_HTML = String.Format(tbl_HTML, TABLA_HTML);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=AFP.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            //Response.Write(sb.ToString());
            Response.Write(TABLA_HTML);
            Response.End();
            return true;

        }
        protected void descargarArchivo(String pRutaArchivo, String pNombreArchivo)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(pRutaArchivo + pNombreArchivo);
            if (file.Exists)
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + pNombreArchivo);
                HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
                HttpContext.Current.Response.WriteFile(file.FullName);
                HttpContext.Current.Response.End();
            }
            else
            {
                Utils.fc_DisplayAlert(this.Page, "El archivo no existe");
            }
        }
        #endregion
        /*
        private bool ExportarArchivoToDataTable(string sFilename, System.Data.DataTable tabla)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                string s = "";
                System.Data.DataTable oLista = new System.Data.DataTable();
                oLista = tabla;
                if (oLista == null || oLista.Rows.Count <= 0)
                    return false;
                else
                    for (int i = 0; i < oLista.Rows.Count; i++)
                    {
                        string miCadena = oLista.Rows[i][0].ToString();
                        s = s + HttpUtility.HtmlDecode(miCadena);
                        //sw.WriteLine(s);
                        str.Append(s);
                        str.AppendLine();
                        s = "";
                    }

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=" + sFilename + ".txt");
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.text";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                Response.Write(str.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                lblErrorTelecredito.Text = "Error: " + ex.Message;
            }
            return true;
        }
        */
        private byte[] generaArchivoByte_TXT(System.Data.DataTable tabla)
        {
            StringBuilder str = new StringBuilder();
            string s = "";
            System.Data.DataTable oLista = new System.Data.DataTable();
            oLista = tabla;

            for (int i = 0; i < oLista.Rows.Count; i++)
            {
                string miCadena = oLista.Rows[i][0].ToString();
                s = s + HttpUtility.HtmlDecode(miCadena);
                //sw.WriteLine(s);
                str.Append(s);
                str.AppendLine();
                s = "";
            }

            //--
            byte[] bytes = null;
            using (var ms = new System.IO.MemoryStream())
            {
                using (System.IO.TextWriter tw = new System.IO.StreamWriter(ms))
                {
                    tw.Write(str.ToString());
                    tw.Flush();
                    ms.Position = 0;
                    bytes = ms.ToArray();
                }
            }
            return bytes;
        }
        //@005 I
        private void DownloadFileTXT(byte[] bytes, string sFileName)
        {
            // From byte array to string
            string str = System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + sFileName + ".txt");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.text";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            Response.Write(str);
            Response.End();
        }
        private void DownloadZIP_MultipleFilesTXT(List<objFile> lstFiles, string sFileName)
        {
            Response.Clear();
            Response.BufferOutput = false;
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "attachment; filename=" + sFileName + ".zip");

            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
            {
                Int32 i = 0;
                foreach (objFile oFile in lstFiles)
                {
                    zip.AddEntry(oFile.nomFile, oFile.file);
                    i++;
                }
                zip.Save(Response.OutputStream);
            }
            Response.Close();
        }
        //@005 F

        private List<string> GenerarArchivoBanBif(string periodoid, string concepto, string moneda, string personal
            , String Periodo_Id_Desde //@001 I/F
        )
        {
            string tplanilla = "", tmoneda = "", mdeposito = "", codBanco = "038";
            //+++++ Tipo de Planilla ++++++++
            switch (concepto)
            {
                case "000313": tplanilla = "H"; break;
                case "000379": tplanilla = "C"; break;
            }
            //++++++++++  Moneda ++++++++++++++++++
            switch (moneda)
            {
                case "DO": tmoneda = "2"; break;
                case "MN": tmoneda = "1"; break;
            }
            //+++++++++++++Motivo Deposito ++++++++++++++++++
            if (tplanilla == "C")
            {
                mdeposito = "0";
            }
            else
            {

                mdeposito = "5";
            }
            //+++++++++++++ Extrayendo informacion de la BD ++++++++++++++++++
            string comando = "";
            //@001 I
            comando = "select ca.Planilla_Id, ca.Personal_Id, ca.Concepto_Id, ca.Proceso_Id"
                + ", @periodo as 'Periodo_Id', SUM(ca.Valor) as 'Valor'"
                + "into #tmpCalculos"
                + "from Calculos ca"
                + "where((@vi_Periodo_Id_Desde = '' and ca.Periodo_Id = @periodo) or(@vi_Periodo_Id_Desde != '' and ca.Periodo_Id between @vi_Periodo_Id_Desde and @periodo))"
                + "group by ca.Planilla_Id, ca.Personal_Id, ca.Concepto_Id, ca.Proceso_Id; ";
            //@001 F
            if (tplanilla == "H")
            {
                comando = "SELECT P.Nro_Doc,P.Apellido_Paterno,P.Apellido_Materno,P.Nombres,P.Nro_cta [cta],C.Valor ";
                //@001 I
                //comando += "FROM Personal P INNER JOIN Calculos C ON P.Personal_Id=C.Personal_Id ";
                comando += "FROM Personal P INNER JOIN #tmpCalculos C ON P.Personal_Id=C.Personal_Id ";
                //@001 F
                //@002 I
                //comando += "WHERE C.Periodo_Id=@periodo AND C.Concepto_Id=@concepto AND P.Banco_cta_Id='38' ";
                comando += "WHERE C.Periodo_Id=@periodo AND C.Concepto_Id=@concepto AND P.Banco_pago_cia_Id='38' ";
                //@002 F
                comando += "AND P.Personal_Id IN (" + personal + ") ";
                //comando += "WHERE C.Periodo_Id=@periodo AND C.Concepto_Id=@concepto AND P.Banco_cta_Id='2' ";
                comando += "ORDER BY P.Apellido_Paterno,P.Apellido_Materno,P.Nombres;";
            }
            else
            {
                comando = "SELECT P.Nro_Doc,P.Apellido_Paterno,P.Apellido_Materno,P.Nombres,P.Nro_cta_cts [cta],C.Valor ";
                //@001 I
                //comando += "FROM Personal P INNER JOIN Calculos C ON P.Personal_Id=C.Personal_Id ";
                comando += "FROM Personal P INNER JOIN #tmpCalculos C ON P.Personal_Id=C.Personal_Id ";
                //@001 F
                //@002 I
                //comando += "WHERE C.Periodo_Id=@periodo AND C.Concepto_Id=@concepto AND P.Banco_cta_cts_Id='38' ";
                comando += "WHERE C.Periodo_Id=@periodo AND C.Concepto_Id=@concepto AND P.Banco_pago_cts_cia_Id='38' ";
                //@002 F
                comando += "AND P.Personal_Id IN (" + personal + ") ";
                //comando += "WHERE C.Periodo_Id=@periodo AND C.Concepto_Id=@concepto AND P.Banco_cta_cts_Id='2' ";
                comando += "ORDER BY P.Apellido_Paterno,P.Apellido_Materno,P.Nombres;";
            }
            //@001 I
            comando = " drop table #tmpCalculos; ";
            //@001 F

            List<ePersonalBanco> odatos = new List<ePersonalBanco>();
            using (SqlConnection cn = new SqlConnection(CAPA_DATOS.Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@periodo", periodoid);
                    cmd.Parameters.AddWithValue("@concepto", concepto);
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id_Desde", Periodo_Id_Desde); //@001 I/F
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ePersonalBanco oinsert = new ePersonalBanco();
                        oinsert.NroDoc = dr.GetValue(0).ToString();
                        oinsert.APaterno = dr.GetValue(1).ToString();
                        oinsert.AMaterno = dr.GetValue(2).ToString();
                        oinsert.Nombres = dr.GetValue(3).ToString();
                        oinsert.NroCta = dr.GetValue(4).ToString();
                        oinsert.Monto = decimal.Parse(dr.GetValue(5).ToString());
                        odatos.Add(oinsert);
                    }
                }
            }

            List<string> lineas = new List<string>();
            for (int x = 0; x <= odatos.Count - 1; x++)
            {
                string correlativo = (x + 1).ToString().PadLeft(7, '0');
                string tipoDoc = "1";
                string documento = odatos[x].NroDoc.PadRight(11, ' ');
                string apePaterno = odatos[x].APaterno.PadRight(20, ' ');
                string apeMaterno = odatos[x].AMaterno.PadRight(20, ' ');
                string nombres = odatos[x].Nombres.PadRight(44, ' ');
                string direccion = (" ").PadLeft(60, ' ');
                string telefono = (" ").PadLeft(10, ' ');
                string numCuenta = odatos[x].NroCta.PadLeft(20, '0');
                int monto = (int)(Math.Round(odatos[x].Monto, 2) * 100);
                string deposito = monto.ToString().PadLeft(14, '0');
                string sdato = correlativo + tipoDoc + documento + apePaterno + apeMaterno + nombres + direccion + telefono + tplanilla + codBanco + numCuenta + tmoneda + deposito + mdeposito;
                lineas.Add(sdato);
            }
            return lineas;
        }

        public class ePersonalBanco
        {
            public string NroDoc { get; set; }
            public string APaterno { get; set; }
            public string AMaterno { get; set; }
            public string Nombres { get; set; }
            public string NroCta { get; set; }
            public decimal Monto { get; set; }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarPersonal();
        }
        void CargarInformacionEstado()
        {
            string planilla = Utils.fc_obtiene_Planilla_Id(this);
            string periodo = Utils.fc_obtiene_Periodo_Id(this);
            List<Ent_GenerarArchivoEstado> infor = new List<Ent_GenerarArchivoEstado>();
            int codi = int.Parse(cboConcepto.SelectedValue.ToString());
            infor = controller_GenerarArchivoEstado.get_Instance().ListarEstadosArchivo(codi, planilla, periodo, "");
            if (infor.Count > 0)
            {
                for (int i = 0; i <= gvPersonal.Rows.Count - 1; i++)
                {
                    for (int x = 0; x <= infor.Count - 1; x++)
                    {
                        string PersonalId = gvPersonal.DataKeys[i].Values[0].ToString();
                        if (infor[x].Personal_Id == PersonalId)
                        {
                            ((TextBox)gvPersonal.Rows[i].FindControl("txtobs")).Text = infor[x].Observaciones;
                            if (infor[x].Estado_Id == "1")
                            {
                                //@001 I
                                //gvPersonal.Rows[i].Cells[10].Text = infor[x].FechaAct.ToString("dd/MM/yyyy HH:mm tt");
                                gvPersonal.Rows[i].Cells[11].Text = infor[x].FechaAct.ToString("dd/MM/yyyy HH:mm tt");
                                //@001 F
                                gvPersonal.Rows[i].BackColor = System.Drawing.Color.FromArgb(150, 232, 142);
                            }
                        }
                    }
                    //@001 I
                    //string cta = gvPersonal.Rows[i].Cells[7].Text;
                    string cta = gvPersonal.Rows[i].Cells[8].Text;
                    //@001 F
                    string nombre = gvPersonal.Rows[i].Cells[2].Text;
                    Int64 cta2 = 0;
                    if (!Int64.TryParse(cta, out cta2))
                    {
                        gvPersonal.Rows[i].BackColor = System.Drawing.Color.Red;
                    }
                    if (nombre.Replace(',', ' ').Trim().Length > 40)
                    {
                        gvPersonal.Rows[i].BackColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
        void ProcesarInformacionEstado()
        {
            string planilla = Utils.fc_obtiene_Planilla_Id(this);
            string periodo = Utils.fc_obtiene_Periodo_Id(this);
            List<Ent_GenerarArchivoEstado> infor = new List<Ent_GenerarArchivoEstado>();
            int codi = int.Parse(cboConcepto.SelectedValue.ToString());
            infor = controller_GenerarArchivoEstado.get_Instance().ListarEstadosArchivo(codi, planilla, periodo, "").Where(x => x.Estado_Id == "1").ToList();
            for (int i = 0; i <= gvPersonal.Rows.Count - 1; i++)
            {
                string xperson = gvPersonal.DataKeys[i].Values[0].ToString();
                bool xestado = bool.Parse(gvPersonal.DataKeys[i].Values[1].ToString());

                Ent_GenerarArchivoEstado obj = new Ent_GenerarArchivoEstado();
                CheckBox chk = (CheckBox)gvPersonal.Rows[i].FindControl("chksel");
                string observaciones = ((TextBox)gvPersonal.Rows[i].FindControl("txtobs")).Text;
                if (xestado == true)
                {
                    if (chk.Checked == true)
                    {
                        obj.Estado_Id = "1";
                    }
                    else
                    {
                        if (infor.Where(x => x.Personal_Id == xperson).Count() > 0)
                        {
                            obj.Estado_Id = "1";
                        }
                        else
                        {
                            obj.Estado_Id = "0";
                        }
                    }
                }
                else
                {
                    obj.Estado_Id = "0";
                }
                obj.Observaciones = observaciones;

                obj.Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
                obj.Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                obj.Personal_Id = gvPersonal.DataKeys[i].Values[0].ToString();
                obj.Codigo_Id = int.Parse(cboConcepto.SelectedValue.ToString());
                obj.UsuarioReg = ClaseGlobal.Get_nombrecompleto_usuario().ToString();
                obj.UsuarioAct = ClaseGlobal.Get_nombrecompleto_usuario().ToString();
                controller_GenerarArchivoEstado.get_Instance().ProcesarEstadosArchivo(obj);

            }
        }
        protected void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarPersonal();
        }

        protected void btnobs_Click(object sender, EventArgs e)
        {
            string planilla = Utils.fc_obtiene_Planilla_Id(this);
            string periodo = Utils.fc_obtiene_Periodo_Id(this);
            List<Ent_GenerarArchivoEstado> infor = new List<Ent_GenerarArchivoEstado>();
            int codi = int.Parse(cboConcepto.SelectedValue.ToString());
            infor = controller_GenerarArchivoEstado.get_Instance().ListarEstadosArchivo(codi, planilla, periodo, "");
            for (int i = 0; i <= gvPersonal.Rows.Count - 1; i++)
            {
                string PersonalId = gvPersonal.DataKeys[i].Values[0].ToString();
                CheckBox chk = (CheckBox)gvPersonal.Rows[i].FindControl("chksel");
                if (infor.Where(x => x.Personal_Id == PersonalId).Count() == 0 && chk.Checked == false)
                {
                    ((TextBox)gvPersonal.Rows[i].FindControl("txtobs")).Text = txtobstodos.Text.Trim();
                }
            }
        }

        protected void btnEstado_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int index = gvr.RowIndex;
            string personal = gvPersonal.DataKeys[index].Values[0].ToString();
            string periodo = Utils.fc_obtiene_Periodo_Id(this);
            string resultado = controller_GenerarArchivoBancos.getinstance().ActualizarEstadoPersonalActivo(periodo, personal);
            if (resultado.Split('#')[0] == "true")
            {
                Utils.fc_JavaScript(this, "Estado actualizado correctamente.");
                cargarPersonal();
            }
            else
            {
                Utils.fc_JavaScript(this, "El estado no ha sido actualizado, contecte con soporte.");
            }
        }

        //@001 I
        protected void chkAcumMontos_CheckedChanged(object sender, EventArgs e)
        {
            String Periodo_Id_Selected = Utils.fc_obtiene_Periodo_Id(this);

            Boolean fl_visible = chkAcumMontos.Checked;
            lblPeriodo_Desde.Visible = fl_visible;
            cboPeriodo_Desde.Visible = fl_visible;
            lblNotaAcum.Visible = fl_visible;
            if (chkAcumMontos.Checked && !String.IsNullOrEmpty(Periodo_Id_Selected))
            {
                Ent_Periodo objEPeriodo = new Ent_Periodo();
                objEPeriodo.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                objEPeriodo.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                objEPeriodo.Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
                objEPeriodo.Mes_Id = "";
                objEPeriodo.Estado_Id = "02";
                DataTable dtPeriodos = Log_Periodo.Lista_Periodo(objEPeriodo);

                DataRow[] drowFind = dtPeriodos.Select("Periodo_Id = " + Periodo_Id_Selected);
                Int32 inx_Selected_fin = dtPeriodos.Rows.IndexOf(drowFind[0]);
                Int32 inx_inicio = inx_Selected_fin - 11; //Para que muestre los últimos 11 periodos

                //Int32 qt_periodos = dtPeriodos.Rows.Count;
                //Int32 index_inicio = qt_periodos - 12; //Para que muestre los últimos 11 periodos
                List<Ent_Periodo> oLista_Periodos = new List<Ent_Periodo>();
                Int32 index = 0;
                foreach (DataRow row in dtPeriodos.Rows)
                {
                    //if (Convert.ToInt32(row["Periodo_Id"].ToString()) >= Convert.ToInt32(Periodo_Id_Selected))
                    //{
                    //    break;
                    //}

                    //if (row["Periodo_Id"].ToString() != Periodo_Id_Selected && index >= index_inicio)
                    if (row["Periodo_Id"].ToString() != Periodo_Id_Selected && index >= inx_inicio && index <= inx_Selected_fin)
                    {
                        oLista_Periodos.Add(new Ent_Periodo
                        {
                            Periodo_Id = row["Periodo_Id"].ToString(),
                            Descripcion = row["Descripcion"].ToString()
                        });
                    }

                    index++;
                }

                cboPeriodo_Desde.DataSource = oLista_Periodos;
                cboPeriodo_Desde.DataTextField = "Descripcion";
                cboPeriodo_Desde.DataValueField = "Periodo_Id";
                cboPeriodo_Desde.DataBind();
                cboPeriodo_Desde.Items.Insert(0, new ListItem("-Seleccione-", ""));
            }
            else
            {
                cboPeriodo_Desde.Items.Clear();
                cboPeriodo_Desde.Items.Insert(0, new ListItem("-Seleccione-", ""));
            }

            cargarPersonal();
        }
        //@001 F

        //@005 I
        private class PersonalSeleccionadoClass
        {
            public String Personal_Id { get; set; }
            public String Proyecto { get; set; }
        }
        private class objFile
        {
            public byte[] file { get; set; }
            public String nomFile { get; set; }
        }
    }
}