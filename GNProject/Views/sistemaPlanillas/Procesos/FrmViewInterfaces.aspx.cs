using CAPA_ENTIDAD.EntMs;
using CAPA_LOGICO;
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
    public partial class FrmViewInterfaces : System.Web.UI.Page
    {
        InterfacesExportacion objInt = new InterfacesExportacion();

        //////Microsoft.Office.Interop.Excel.Application exel;
        //////Microsoft.Office.Interop.Excel.Workbook libro;
        //////Microsoft.Office.Interop.Excel.Worksheet hoja;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                FillDDL();
                iniciaMensaje();
                loadCombo();
                lblErrorPlame.Text = "";
                cargarProcesos();
                txtFecha.Text = DateTime.Now.Date.ToShortDateString();
                txtFecha_Inicio.Text = DateTime.Now.Date.ToShortDateString();
                txtFecha_Final.Text = DateTime.Now.Date.ToShortDateString();
                //@001 I
                CAPA_DATOS.DAOPersonal oDAOPersonal = new CAPA_DATOS.DAOPersonal();
                DataTable dtArea = oDAOPersonal.ListaArea();
                cboArea.DataSource = dtArea;
                cboArea.DataValueField = "Area_Id";
                cboArea.DataTextField = "Descripcion";
                cboArea.DataBind();

                DataTable dtProyecto = oDAOPersonal.ListaProyecto();
                cboProyecto.DataSource = dtProyecto;
                cboProyecto.DataValueField = "Proyecto_Id";
                cboProyecto.DataTextField = "Descripcion";
                cboProyecto.DataBind();

                DataTable dtCCosto = oDAOPersonal.ListaCCosto();
                cboCCosto.DataSource = dtCCosto;
                cboCCosto.DataValueField = "CCosto_Id";
                cboCCosto.DataTextField = "Descripcion";
                cboCCosto.DataBind();

                //cboTelecred.SelectedValue = "0";
                cboTelecred.SelectedValue = "2";
                //@001 F
            }
        }

        private void FillDDL()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            InterfacesBL interfacesBL = new InterfacesBL();
            ddlInterfaces.DataTextField = "Descripcion";
            ddlInterfaces.DataValueField = "Interface_ID";
            ddlInterfaces.DataSource = interfacesBL.GetInterfaces(1);
            ddlInterfaces.DataBind();

            /*CAPA_LOGICO.BUSPersonal objNegPersonal = new BUSPersonal();
            DataTable dtBancos = objNegPersonal.ListaBancos();
            for (int i = dtBancos.Rows.Count - 1; i >= 0; i--)
            {
                String banco_id = dtBancos.Rows[i]["Banco_Id"].ToString().Trim();
                //if (banco_id != "2" && banco_id != "11" && banco_id != "9")
                if (banco_id != "2" && banco_id != "11" && banco_id != "9" && banco_id != "38")
                { //BCP | CONTINENTAL | SCOTIABANK PERU
                    dtBancos.Rows.RemoveAt(i);
                }
            }
            cboBanco.DataSource = dtBancos;
            */
            cboBanco.DataSource = CAPA_DATOS.controller_GenerarArchivoBancos.getinstance().ListarBancosCombo();
            cboBanco.DataTextField = "Descripcion";
            cboBanco.DataValueField = "Banco_Id";
            cboBanco.DataBind();
            cboBanco.SelectedValue = "2 "; //BCP por defecto
        }

        private void loadCombo()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboPlame.DataSource = objInt.GetListaPlame_Listar();
            cboPlame.DataTextField = "ms_ms_EstructuraPlame_Descripcion";
            cboPlame.DataValueField = "ms_ms_EstructuraPlame_Estructura";
            cboPlame.DataBind();
        }

        protected void ddlPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            PeriodoBL periodoBL = new PeriodoBL();
            //ddlPeriodo.DataTextField = "Descripcion";
            //ddlPeriodo.DataValueField = "Periodo_Id";
            //ddlPeriodo.DataSource = periodoBL.GetPeriodoPorPlanilla(ddlPlanilla.SelectedValue);
            //ddlPeriodo.DataBind();
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            InterfacesBL interfacesBL = new InterfacesBL();
            CompaniaBL companiaBL = new CompaniaBL();

            DataTable dtInterface = interfacesBL.GetInterface(Convert.ToInt32(ddlInterfaces.SelectedValue));
            DataTable dtCompania = companiaBL.GetCompania("01");

            DataTable result = new DataTable();
            string Estructura = Convert.ToString(dtInterface.Rows[0]["Estructura"]);

            if (Estructura == "1")
            {
                result = interfacesBL.GetInterface1("01");
            }
            else if (Estructura == "2") //establesco por defecto el 2.1 (No hay el 2)
            {
                result = interfacesBL.GetInterface2_1(Utils.fc_obtiene_Periodo_Id(this));//ddlPeriodo.SelectedValue);
            }
            else if (Estructura == "3")
            {
                result = interfacesBL.GetInterface3(Utils.fc_obtiene_Periodo_Id(this));//ddlPeriodo.SelectedValue);
            }
            else if (Estructura == "4")
            {
                string nuevo = Utils.fc_obtiene_Periodo_Id(this);
                result = interfacesBL.GetInterface4(nuevo);// ddlPeriodo.SelectedValue);
            }
            else if (Estructura == "5")
            {
                string codigoPeriodo = Utils.fc_obtiene_Periodo_Id(this);
                result = interfacesBL.GetInterface5(codigoPeriodo, "");//ddlPeriodo.SelectedValue);
            }
            else if (Estructura == "6")
            {
                string codigoPeriodo = Utils.fc_obtiene_Periodo_Id(this);
                result = interfacesBL.GetInterface6(codigoPeriodo);//ddlPeriodo.SelectedValue);
            }
            else if (Estructura == "9")
            {
                result = interfacesBL.GetInterface9(Utils.fc_obtiene_Periodo_Id(this));//ddlPeriodo.SelectedValue);
            }
            else if (Estructura == "10")
            {
                result = interfacesBL.GetInterface10(Utils.fc_obtiene_Periodo_Id(this));//ddlPeriodo.SelectedValue);
            }
            else if (Estructura == "11")
            {
                result = interfacesBL.GetInterface11(Utils.fc_obtiene_Periodo_Id(this));//ddlPeriodo.SelectedValue);
            }

            //  Echo Michael
            else if (Estructura == "17")
            {
                result = interfacesBL.GetInterface17(Utils.fc_obtiene_Periodo_Id(this));//ddlPeriodo.SelectedValue);
            }
            else if (Estructura == "23")
            {
                result = interfacesBL.GetInterface23(Utils.fc_obtiene_Periodo_Id(this));//ddlPeriodo.SelectedValue);
            }

            string FileName = "RP_" + dtCompania.Rows[0]["RUC"];// + dtInterface.Rows[0]["Extension"];
                                                                //string FileName = "RP_" + dtCompania.Rows[0]["RUC"] + ".est";

            #region comentado
            //string path = @"D:\Interfaces\" + FileName;
            //string path = @"C:\Interfaces\" + FileName;

            #region mantenimientoMichael

            //string activeDir = @"c:\";
            ////Create a new subfolder under the current active folder
            //string newPath = System.IO.Path.Combine(activeDir, "Interfaces");

            //// Create the subfolder
            //if (!System.IO.File.Exists(newPath))
            //{
            //    System.IO.Directory.CreateDirectory(newPath);
            //}

            #endregion

            //FileStream fs = null;

            //if (!File.Exists(path))
            //{
            //    fs = File.Create(path);
            //    fs.Close();
            //}

            //if (File.Exists(path))
            //{
            //    using (StreamWriter sw = new StreamWriter(path))
            //    {
            //        foreach (DataRow row in result.Rows)
            //        {
            //            sw.WriteLine(row[0]);
            //        }
            //        sw.Close();
            //    }

            //}

            //Process.Start(path);

            //carga el dataset 
            // DataTable mDatos;
            //mDatos = result;
            //EnviaCSV(mDatos, FileName);
            #endregion

            if (result.Rows.Count > 0)
            {
                exportarArchivo(FileName, result, dtInterface.Rows[0]["Extension"].ToString());
            }
            else
            {
                lblError.Text = "Imposible Exportar... No hay Registros que coincidan con el Filtro";
                //string script = "<script languaje='javascript' type='text/javascript'>if (self.moveBy) {for (i = 10; i > 0; i--) {for (j = 6; j > 0; j--) {self.moveBy(0, i);self.moveBy(i, 0);self.moveBy(0, -i);self.moveBy(-i, 0);}}}</script>";
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "MovPntlla", script, false);
            }

        }

        #region AutomatisarDescarga

        private string ConvierteCSV(DataTable pDatos)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string pDelimitadorColumnas = ",";
            string pDelimitadorRegistros = Environment.NewLine;


            //Variables Locales
            string mSalida = "";
            string mRegistro;
            int mContadorRegistros = 0;
            int mContadorColumnas = 0;
            string mValor = "";
            string mNombreColumna = "";

            //Solo si hay datos
            if (pDatos != null)
            {
                if (pDatos.Rows.Count > 0)
                {

                    //fila de titulos de columna
                    mContadorColumnas = 0;
                    mRegistro = "";
                    //para cada columna
                    while (mContadorColumnas < pDatos.Columns.Count)
                    {

                        mNombreColumna = pDatos.Columns[mContadorColumnas].ColumnName;

                        if (mRegistro != "")
                        {
                            mRegistro = mRegistro + pDelimitadorColumnas;
                        }

                        //mValor = """" + mNombreColumna + """";
                        mValor = mNombreColumna;
                        mRegistro = mRegistro + mValor;

                        mContadorColumnas = mContadorColumnas + 1;

                    }

                    mSalida = mSalida + mRegistro;

                    //procesa los registros del dataset
                    while (mContadorRegistros < pDatos.Rows.Count)
                    {
                        if (mSalida != "")
                        {
                            mSalida = mSalida + pDelimitadorRegistros;
                        }
                        mRegistro = "";
                        mContadorColumnas = 0;
                        //para cada columna	
                        int n = pDatos.Columns.Count;
                        while (mContadorColumnas < n)
                        {
                            if (mRegistro != "")
                            {
                                mRegistro = mRegistro + pDelimitadorColumnas;
                            }

                            mValor = pDatos.Rows[mContadorRegistros][mContadorColumnas].ToString();
                            //If InStr(mValor, pDelimitadorColumnas) > 0 Then
                            //    mValor = """" & mValor & """"
                            //End If
                            if (mValor.IndexOf(pDelimitadorColumnas) > 0)
                            {
                                mValor += mValor;
                            }

                            mRegistro = mRegistro + mValor;
                            mContadorColumnas = mContadorColumnas + 1;
                        }
                        //añade el registro
                        mSalida = mSalida + mRegistro;
                        mContadorRegistros = mContadorRegistros + 1;
                    }
                }

            }

            return mSalida;
        }

        private void DescargaCSV(string pCSV, string pNombreCSV)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //Obtiene la respuesta actual
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;

            //Borra la respuesta
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();

            //Tipo de contenido para forzar la descarga
            response.ContentType = "application/octet-stream";
            response.AddHeader("Content-Disposition", "attachment; filename=" + pNombreCSV);

            //Convierte el string a array de bytes
            byte[] buffer = new byte[pCSV.Length];
            int mContador = 0;
            while (mContador < pCSV.Length)
            {
                //buffer(mContador) = Asc(Mid(pCSV, mContador + 1, 1));
                //buffer[mContador] =  Convert.ToByte(pCSV.Substring(mContador + 1, 0));
                mContador = mContador + 1;
            }

            //Envia los bytes
            response.BinaryWrite((byte[])buffer);
            response.End();

        }

        private void EnviaCSV(DataTable pDatos, string pNombreFicheroCSV)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //pNombreFicheroCSV="datos.csv";
            //Convirte el DataSet a String en CSV
            string mSalida;
            mSalida = ConvierteCSV(pDatos);
            //Envia el String en CSV
            DescargaCSV(mSalida, pNombreFicheroCSV);
        }

        private bool exportarArchivo(string sFilename, DataTable tabla, string extension)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            StringBuilder str = new StringBuilder();
            string s = "";

            DataTable dsContactos = tabla;
            if (dsContactos == null)
                return false;

            for (int o = 0; o < dsContactos.Rows.Count; o++)
            {
                for (int j = 0; j < dsContactos.Columns.Count; j++)
                {
                    string cadena = dsContactos.Rows[o][j].ToString();
                    s = s + HttpUtility.HtmlDecode(cadena);
                    string formato = s;
                    str.Append(formato);
                    s = "";
                }
                str.AppendLine();
            }
            lblError.Text = "";
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

        #endregion

        #region mantenimientoMichael
        private void iniciaMensaje()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblError.Text = string.Empty;
            lblError.Text = "";
        }

        protected void ddlInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            iniciaMensaje();
        }

        #endregion


        private bool ExportarArchivoToList(string sFilename, List<string> tabla, string extension)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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

        protected void btnGenerarPlame_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string periodo = Utils.fc_obtiene_Periodo_Id(this);
            Func<string> extension = () => objInt.GetListaPlame_BuscarExtension(cboPlame.SelectedValue);

            string pdt = "0601";
            string anio = DateTime.Now.Year.ToString();
            int elPeriodo = int.Parse(objInt.GetMesPorPeriodo(Utils.fc_obtiene_Periodo_Id(this)));
            string mes = elPeriodo > 0 && elPeriodo < 10 ? "0" + elPeriodo.ToString() : elPeriodo.ToString();
            //20180617
            string ruc = objInt.GetNroRucEmpresa(Utils.fc_obtiene_Compania_Id(this));

            string fileName = pdt + anio + mes + ruc;

            if (cboPlame.SelectedValue == "14")       //LA ESTRUCTURA 14
            {
                List<string> res = objInt.GetListaPlame_Exportacion_DatosJornada(periodo);
                //if (ExportarArchivoToList(fileName, objInt.GetListaPlame_Exportacion_DatosJornada(periodo), extension()))
                if (ExportarArchivoToList(fileName, res, extension()))
                {
                    //lblErrorPlame.Text = "" + objInt.GetListaPlame_Exportacion_DatosJornada(periodo).Count;//"";
                    lblErrorPlame.Text = "" + res.Count;//"";
                }
                else
                {
                    lblErrorPlame.Text = "ERROR... Imposible generar el Archivo de Texto, ya que no hay datos en el PERIODO Seleccionado";
                }
            }
            else if (cboPlame.SelectedValue == "18")     //LA ESTRUCTURA 18
            {
                if (ExportarArchivoToList(fileName, objInt.GetListaPlame_Exportacion_DetalleIngreso(periodo), extension()))
                {
                    lblErrorPlame.Text = "";
                }
                else
                {
                    lblErrorPlame.Text = "ERROR... Imposible generar el Archivo de Texto, ya que no hay datos en el PERIODO Seleccionado";
                }
            }

            else if (cboPlame.SelectedValue == "15")     //LA ESTRUCTURA 15
            {
                List<string> res = objInt.GetListaPlame_Exportacion_Descanso(periodo);
                //if (ExportarArchivoToList(fileName, objInt.GetListaPlame_Exportacion_Descanso(periodo), extension()))
                if (ExportarArchivoToList(fileName, res, extension()))
                {
                    //lblErrorPlame.Text = "" + objInt.GetListaPlame_Exportacion_Descanso(periodo).Count; ;
                    lblErrorPlame.Text = "" + res.Count;
                }
                else
                {
                    lblErrorPlame.Text = "ERROR... Imposible generar el Archivo de Texto, ya que no hay datos en el PERIODO Seleccionado";
                }
            }
            lblErrorPlame.Text = "No se puede Exportar Aun esa Interfaces";
        }


        public System.Data.DataTable GetInterfaceTelecredito(
           string cia, string periodo, string concepto, string moneda, string planilla,
           string fechaInicial, string fechaFinal, string codigo, string banco_id, string fl_export_excel)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            using (SqlConnection cn = new SqlConnection(CAPA_DATOS.Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PROC_SCIRE1_TELECREDITO", cn))
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

        protected void btnGenerarTelecredito_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblErrorTelecredito.Text = "";
            //@001 I
            String Area_Ids = txhAreaIds.Value;
            String Proyecto_Ids = txhProyectoIds.Value;
            String CCosto_Ids = txhCCostoIds.Value;
            //@001 F

            //excel 2015 - afp
            if (rbModo.SelectedValue == "0" && cboTelecred.SelectedValue == "2")
            {
                if (ExportarExcelToList2015(objInt.GetListaAfp_ExportacionExcel2015(Utils.fc_obtiene_Periodo_Id(this), Area_Ids, Proyecto_Ids, CCosto_Ids))) //@001 I/F
                {
                    lblErrorTelecredito.Text = "";
                    // Utils.fc_DisplayAlert(this.Page,"Exportacion Correcta");
                }
                else
                {
                    lblErrorTelecredito.Text = "ERROR... Imposible generar el Libro de Excel, ya que no hay datos en el PERIODO Seleccionado";
                }
            }
            //@001 I
            /*
            //excel y afp
            if (rbModo.SelectedValue == "0" && cboTelecred.SelectedValue == "0")
            {

                if (ExportarExcelToList(objInt.GetListaAfp_ExportacionExcel(Utils.fc_obtiene_Periodo_Id(this))))
                {
                    lblErrorTelecredito.Text = "";
                    // Utils.fc_DisplayAlert(this.Page,"Exportacion Correcta");
                }
                else
                {
                    lblErrorTelecredito.Text = "ERROR... Imposible generar el Libro de Excel, ya que no hay datos en el PERIODO Seleccionado";
                }

            }
            //archivo y afp
            else if (rbModo.SelectedValue == "1" && cboTelecred.SelectedValue == "0")
            {

                if (ExportarArchivoToList("ruta", objInt.GetListaAfp_Exportacion(Utils.fc_obtiene_Periodo_Id(this))))
                {
                    lblErrorTelecredito.Text = "";
                }
                else
                {
                    lblErrorTelecredito.Text = "ERROR... Imposible generar el Archivo de Texto, ya que no hay datos en el PERIODO Seleccionado";
                }

            }
            //archivo text / excel  telecredito
            else if (cboTelecred.SelectedValue == "1")
            {
                string cia = "01";
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
                    else if (a == "08")     //LIQUIDACION
                        retorno = "000756";
                    return retorno;
                };
                string planilla = Utils.fc_obtiene_Planilla_Id(this);
                string concepto = determinaConcepto(cboConcepto.SelectedValue);
                string moneda = cboMoneda.SelectedValue;
                string inicioVaca = "";
                string finalVaca = "";
                string elCodigo = planilla == "01" ? "1421110521" : "1450110550";

                if (txtFecha_Inicio.Text == "" || txtFecha_Inicio.Text == null)
                    inicioVaca = DateTime.Now.Date.ToShortDateString();
                else
                    inicioVaca = txtFecha_Inicio.Text;

                if (txtFecha_Final.Text == "" || txtFecha_Final.Text == null)
                    finalVaca = DateTime.Now.Date.ToShortDateString();
                else
                    finalVaca = txtFecha_Final.Text;

                System.Data.DataTable tablita = new System.Data.DataTable();

                string fl_export_excel;
                if (rbModo.SelectedValue == "0")
                    fl_export_excel = "1";
                else
                    fl_export_excel = "0";

                //20180706
                if (cboBanco.SelectedValue.ToString() == "38")
                {
                   List<string> tabli=new List<string>();
                   tabli = GenerarArchivoBanBif(periodo, concepto, moneda);
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
                    tablita = GetInterfaceTelecredito(cia, periodo,
                      concepto, moneda, planilla, inicioVaca, finalVaca, elCodigo
                      , cboBanco.SelectedValue, fl_export_excel);
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
                            string ruta = "laRuta";
                            //Response.Write("<script>alert('" + tablita.Rows.Count.ToString() + "')</script>");
                            ExportarArchivoToDataTable(ruta, tablita);
                        }
                    }
                }
            }
            */
            //@001 F
        }


        private bool ExportarArchivoToList(string sFilename, List<string> tabla)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

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

        private void cargarProcesos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            ProcesosBL procesosBL = new ProcesosBL();
            cboConcepto.DataSource = procesosBL.GetProcesos();
            cboConcepto.DataTextField = "Proceso";
            cboConcepto.DataValueField = "Proceso_Id";
            cboConcepto.DataBind();
            // cboConcepto.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }


        private bool ExportarArchivoToDataTable(string sFilename, System.Data.DataTable tabla)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

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
            return true;
        }


        #region Exportaciones_Excel
        public bool ExportarExcel_TablaHTML(String nomFile, String TABLA_HTML)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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
           
        }
        public bool ExportarExcelToList2015(List<Exportacion2015> dt)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            String Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);

            //@003 I
            //String codRegimenAFP = "N";
            //if (Planilla_Id == "02") /*Obrero*/ { codRegimenAFP = "C"; }
            //@003 F

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
                fila += String.Format(td_HTML, exp.TDoc);
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
                //fila += String.Format(td_HTML, "N");
                //@003 I
                //fila += String.Format(td_HTML, codRegimenAFP);
                fila += String.Format(td_HTML, exp.CodRegimenAFP);
                //@003 F
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
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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


        //20180706
        private List<string> GenerarArchivoBanBif(string periodoid, string concepto, string moneda)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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
            if (tplanilla == "H")
            {
                comando = "SELECT P.Nro_Doc,P.Apellido_Paterno,P.Apellido_Materno,P.Nombres,P.Nro_cta [cta],C.Valor ";
                comando += "FROM Personal P INNER JOIN Calculos C ON P.Personal_Id=C.Personal_Id ";
                comando += "WHERE C.Periodo_Id=@periodo AND C.Concepto_Id=@concepto AND P.Banco_cta_Id='38' ";
                //comando += "WHERE C.Periodo_Id=@periodo AND C.Concepto_Id=@concepto AND P.Banco_cta_Id='2' ";
                comando += "ORDER BY P.Apellido_Paterno,P.Apellido_Materno,P.Nombres";
            }
            else
            {
                comando = "SELECT P.Nro_Doc,P.Apellido_Paterno,P.Apellido_Materno,P.Nombres,P.Nro_cta_cts [cta],C.Valor ";
                comando += "FROM Personal P INNER JOIN Calculos C ON P.Personal_Id=C.Personal_Id ";
                comando += "WHERE C.Periodo_Id=@periodo AND C.Concepto_Id=@concepto AND P.Banco_cta_cts_Id='38' ";
                //comando += "WHERE C.Periodo_Id=@periodo AND C.Concepto_Id=@concepto AND P.Banco_cta_cts_Id='2' ";
                comando += "ORDER BY P.Apellido_Paterno,P.Apellido_Materno,P.Nombres";
            }
            List<ePersonalBanco> odatos = new List<ePersonalBanco>();
            using (SqlConnection cn = new SqlConnection(CAPA_DATOS.Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@periodo", periodoid);
                    cmd.Parameters.AddWithValue("@concepto", concepto);
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
    }
}