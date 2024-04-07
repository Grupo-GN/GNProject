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
    public partial class FrmConsultarContratos : System.Web.UI.Page
    {
        const String Concepto_Id_D_BASICO = "000001";
        const String Concepto_Id_D_MONTO_MOVILIDAD = "000850";
        const String Concepto_Id_D_MONTO_VALE_ALIMENTOS = "000851";

        Ent_Contratos objEContratos;
        Ent_Personal objEPersonal;


        Ent_Categoria_Auxiliar2 objECategoria2;
        //CAPA_LOGICO.Log_Categoria_Auxiliar2 objNCategoria2 = new Log_Categoria_Auxiliar2();
        CAPA_LOGICO.BUSPersonal objNegPersonal = new BUSPersonal();

        // Ent_Prm_CategoriaAux objEPrm_CategoriaAux;
        private void MasterUcFiltros_PeriodoChangedEvent(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnBuscar_Click(null, null);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            this.Master.UcFiltros_PostBackPeriodoChangedEventHandler += new EventHandler(MasterUcFiltros_PeriodoChangedEvent);
            if (!Utils.fc_ValidaFiltros(this.Page))
            {
                if (Request.QueryString["block"] == null)
                    Response.Redirect("~/Default.aspx?block=1");
                //Session["Compania_Id"] = "01";
                //Session["ABC"] = "";
                Session["Fecha_ini_contrato"] = "";
                Session["Fecha_fin_contrato"] = "";
            }

            if (!Page.IsPostBack)
            {
                btnBuscar.Visible = false;
                Carga_combo_Categoria_Auxiliar();
                btnBuscar_Click(null, null);
            }
        }

        void Carga_combo_Categoria_Auxiliar()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Categoria_Auxiliar objECat_Aux = new Ent_Categoria_Auxiliar();
            cboCategoria_Auxiliar.DataSource = Log_Categoria_Auxiliar.Lista_Categoria_Auxiliar(objECat_Aux);
            cboCategoria_Auxiliar.DataTextField = "Descripcion";
            cboCategoria_Auxiliar.DataValueField = "Categoria_Auxiliar_Id";
            cboCategoria_Auxiliar.DataBind();
            cboCategoria_Auxiliar.Items.Insert(0, new ListItem("TODOS"));
        }

        Int32 mes;
        protected void cboCategoriaAuxiliar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnBuscar_Click(null, null);
        }
        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //string codperiodo = (Utils.fc_obtiene_Periodo_Id(this));
            //string nomperiodo=(Utils.fc_obtiene_Periodo_Id_Nombre(this));

            //string cadperiodo = nomperiodo.Substring(0, 4).ToString();

            //switch (cadperiodo)
            //{
            //            case "ENER": mes = 1; break;
            //            case "FEBR": mes = 2; break;
            //            case "MARZ": mes = 3; break;
            //            case "JUNI": mes = 6; break;
            //            case "JULI": mes = 7; break;
            //            case "AGOS": mes =8; break;
            //            case "SETI":mes = 9; break;
            //            case "OCTU": mes = 10; break;
            //            case "NOVI": mes = 11; break;
            //            case "DICI": mes = 12; break;
            //}

            //string Anio;
            //Anio = nomperiodo.Substring(nomperiodo.Length - 4, 4).ToString();
            Lista_Personal(Utils.fc_obtiene_Periodo_Id(this), cboCategoria_Auxiliar.SelectedValue, 0, "0");
        }

        private void Lista_Personal(String PeriodoId, String Area, Int32 mes, String anio)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Areas = "";
                if (cboCategoria_Auxiliar.SelectedValue == "TODOS")
                { Areas = "0"; }
                else
                { Areas = (cboCategoria_Auxiliar.SelectedValue); }

                objEContratos = new Ent_Contratos();
                //objEPersonal._Periodo_Id = Periodo_Id;
                //if (Apellidos_y_Nombres.Trim() != "")
                //    objEPersonal._Nombres = Apellidos_y_Nombres;
                objEContratos.PeriodoId = Utils.fc_obtiene_Periodo_Id(this);
                objEContratos.Area = Areas;
                objEContratos.Anio = anio;
                objEContratos.Mes = mes;
                DataTable dtPersonal = new DataTable();
                dtPersonal = Log_Contratos.Lista_Renovar_Contratos(objEContratos);

                //if (grvLista.Rows.Count <= 0)
                //{
                //   // lblError.Text = "No se Encontraron Registros...";
                //    return;
                //}
                //lblError.Text = "";
                //TabContainer1.ActiveTabIndex = 0;

                //dtPersonal.Columns.Add(new DataColumn("Mod", typeof(string)));

                DataTable dtContratosRenovados = Log_Contratos.Lista_Renovar_Contratos_Renovados(objEContratos);
                foreach (DataRow row in dtContratosRenovados.Rows)
                {
                    DataRow newrow = dtPersonal.NewRow();
                    newrow[0] = row[0];
                    newrow[1] = row[1];
                    newrow[2] = row[2];
                    newrow[3] = row[3];
                    newrow[4] = row[4];
                    newrow[5] = row[5];
                    newrow[6] = row[6];
                    newrow[7] = row[7];
                    newrow[8] = row[8];
                    newrow[9] = row[9];
                    //newrow[10] = "1";
                    dtPersonal.Rows.Add(newrow);
                }

                grvLista.DataSource = dtPersonal;
                grvLista.DataBind();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);

            }
        }

        protected void grvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            //string codperiodo = (Utils.fc_obtiene_Periodo_Id(this));
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
            string Anio = "";
            //Anio = nomperiodo.Substring(nomperiodo.Length - 4, 4).ToString();

            grvLista.PageIndex = e.NewPageIndex;
            Lista_Personal(Utils.fc_obtiene_Periodo_Id(this), cboCategoria_Auxiliar.SelectedValue, mes, Anio);

            //Lista_Personal(Utils.fc_obtiene_Periodo_Id(this), cboCategoria_Auxiliar.SelectedValue, mes, Anio);
        }
        //protected void grvLista_PreRender(object sender, EventArgs e)
        //{
        //    Lista_Personal(Utils.fc_obtiene_Periodo_Id(this), cboCategoria_Auxiliar.SelectedValue, mes, Anio);
        //}
        protected void grvLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string FechaIngreso = "";
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button button = (Button)e.Row.FindControl("btnGuardar");


                string nomMes = (Utils.fc_obtiene_Mes_Id_Nombre(this));
                string cadMes = nomMes.Substring(0, 4).ToString();

                switch (cadMes)

                {

                    case "ENER": FechaIngreso = "1"; break;
                    case "FEBR": FechaIngreso = "2"; break;
                    case "MARZ": FechaIngreso = "3"; break;
                    case "JUNI": FechaIngreso = "6"; break;
                    case "JULI": FechaIngreso = "7"; break;
                    case "AGOS": FechaIngreso = "8"; break;
                    case "SETI": FechaIngreso = "9"; break;
                    case "OCTU": FechaIngreso = "10"; break;
                    case "NOVI": FechaIngreso = "11"; break;
                    case "DICI": FechaIngreso = "12"; break;
                }

                string Anio;
                Anio = nomMes.Substring(nomMes.Length - 4, 4).ToString();

                // if ((String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(e.Row.Cells[5].Text).Month.ToString())!=FechaIngreso)) == (String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dt2.Rows[0]["Fecha_ini_contrato"]))) )
                string a = Convert.ToDateTime(e.Row.Cells[5].Text).Month.ToString();
                string b = Convert.ToDateTime(e.Row.Cells[5].Text).Year.ToString();
                if ((a.Equals(FechaIngreso)) && (b.Equals(Anio)))
                //   if (((Convert.ToDateTime(e.Row.Cells[5].Text).Month.ToString())equals(FechaIngreso) && ((Convert.ToDateTime(e.Row.Cells[5].Text).Year.ToString()) = Anio))){
                { e.Row.Cells[5].ForeColor = System.Drawing.Color.Red; }


            }

        }



        protected void btnImprimir_Click(object sender, System.EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            GridViewRow row = (GridViewRow)(((Button)sender).NamingContainer);
            Button button = (Button)row.FindControl("btnImprimir");
            string Personal_Id = button.CommandName.ToString();
            string Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
            string Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);


            DataTable dt = new DataTable();
            dt = objNegPersonal.ListaDataxPersonalId(Personal_Id);
            DataTable dt2 = new DataTable();
            dt2 = objNegPersonal.ListaDataxPersonalIdAct(Personal_Id, Periodo_Id);

            String Nro_Doc = dt.Rows[0]["Nro_Doc"].ToString();
            String Nombres = dt.Rows[0]["Nombres"].ToString();
            String Apellidos = dt.Rows[0]["Apellido_Paterno"].ToString().ToUpper() + " " + dt.Rows[0]["Apellido_Materno"].ToString().ToUpper();
            String Direccion = dt.Rows[0]["Direccion"].ToString();

            String Tipo_Contrato_Id = dt2.Rows[0]["Tipo_Contrato_Id"].ToString();
            String Cargo_Id = dt2.Rows[0]["Cargo_Id"].ToString();

            String Fecha_Ingreso = (Convert.ToDateTime(dt2.Rows[0]["Fecha_ingreso"].ToString())).ToString("dd/MM/yyyy");
            String Fecha_Ini_Contrato = (Convert.ToDateTime(dt2.Rows[0]["Fecha_ini_contrato"].ToString())).ToString("dd/MM/yyyy");
            String Fecha_Fin_Contrato = (Convert.ToDateTime(dt2.Rows[0]["Fecha_fin_contrato"].ToString())).ToString("dd/MM/yyyy");

            string NomCargo = dt2.Rows[0]["NomCargo"].ToString();

            //-------------------
            Ent_D_Fijos entFijos = new Ent_D_Fijos();
            entFijos.Periodo_Id = Periodo_Id;
            entFijos.Personal_Id = Personal_Id;
            DataTable dtDFijos = CAPA_LOGICO.Log_D_Fijos.Lista_D_Fijos(entFijos, "");
            List<Ent_D_Fijos> lstDFijos = new List<Ent_D_Fijos>();
            lstDFijos = (from DataRow dr in dtDFijos.Rows
                         select new Ent_D_Fijos
                         {
                             Periodo_Id = dr["Periodo_Id"].ToString(),
                             Personal_Id = dr["Personal_Id"].ToString(),
                             Concepto_Id = dr["Concepto_Id"].ToString(),
                             Valor = Convert.ToDecimal(dr["Valor"])
                         }).ToList();

            String SueldoBruto = string.Format("{0:N2}", lstDFijos.Find(fijo => fijo.Concepto_Id == Concepto_Id_D_BASICO).Valor); //D_BASICO
                                                                                                                                  //-----------------

            String txtFiscalizado = "";
            if (dt2.Rows[0]["Categoria2_Id"].ToString() == "01")
            { txtFiscalizado = "No Sujeto a Fiscalización"; }
            else if (dt2.Rows[0]["Categoria2_Id"].ToString() == "02")
            { txtFiscalizado = "Sujeto a Fiscalización"; }


            // Obtiene las funciones
            DataTable dtFunciones = Log_Cargo_Funciones.List_Cargo(dt.Rows[0]["Personal_Id"].ToString(), dt2.Rows[0]["Cargo_Id"].ToString());
            List<String> lstFunciones = new List<String>();
            foreach (DataRow rowFc in dtFunciones.Rows)
            {
                if (rowFc["Personal_Id"].ToString() != "0")
                {
                    lstFunciones.Add(rowFc["Funcion"].ToString());
                }
            }
            //////Funciones(dt.Rows[0]["Personal_Id"].ToString(), dt2.Rows[0]["Cargo_Id"].ToString()); //carga chkFunciones y chklstFunc
            //////ListItemCollection lst = new ListItemCollection();
            //////for (int index = 0; index < chklstFunc.Items.Count; index++)
            //////{
            //////    if (chklstFunc.Items[index].Selected)
            //////    {
            //////        lst.Add(chklstFunc.Items[index]);
            //////    }

            //////}
            //////Session["lsbFunciones"] = lst;

            //IMPRIME CONTRATO DESDE PLANTILLA
            CAPA_DATOS.oRRHH.controllerContratosPlantilla oControllerPlantillaContratos = new CAPA_DATOS.oRRHH.controllerContratosPlantilla();
            String tx_plantilla_contrato = oControllerPlantillaContratos.getPlantillaContrato_HTML(Tipo_Contrato_Id, Cargo_Id);
            if (String.IsNullOrEmpty(tx_plantilla_contrato))
            {
                //Mensaje1.Text = "No se encontró una plantilla para el siguiente Tipo de Contrato y Cargo.";
                //Mensaje1.ForeColor = System.Drawing.Color.DarkOrange;
                string msg = "No se encontró una plantilla para el siguiente Tipo de Contrato y Cargo.";
                string scriptMSG;
                scriptMSG = "<script language='javascript' type='text/javascript'>alert('" + msg + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "JSAlert", scriptMSG, false);

                return;
            }

            // Reemplazando palabras clave de plantilla de contrato
            string TIPO_RENOVACION = "";
            if ((Fecha_Ingreso != Fecha_Ini_Contrato))
                TIPO_RENOVACION = "RENOVACIÓN DE ";
            string NOMBRE_TRABAJADOR = Nombres.ToUpper() + " " + Apellidos.Trim().ToUpper();
            string DNI_TRABAJADOR = Nro_Doc.Trim();
            string DIRECCION_TRABAJADOR = Direccion.ToUpper();
            string CARGO_TRABAJADOR = NomCargo;
            string FISCALIZACION = txtFiscalizado;
            string FUNCIONES_CARGO = "";
            if (lstFunciones.Count > 0)
            {
                for (int index = 0; index <= lstFunciones.Count - 1; index++)
                {
                    if ((index == 0))
                    {
                        FUNCIONES_CARGO = "<b>EL TRABAJADOR</b>, consiente  de la responsabilidad del cargo asignado, se obliga a:<br>";
                        FUNCIONES_CARGO += lstFunciones[index].ToString();
                    }
                    else
                        FUNCIONES_CARGO += "<br>" + lstFunciones[index].ToString();
                }
            }
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-PE");
            DateTime feinicontrato = Convert.ToDateTime(Fecha_Ini_Contrato);
            string FE_INICIO_CONTRATO = feinicontrato.Day.ToString() + " de " + ci.DateTimeFormat.GetMonthName(feinicontrato.Month) + " del " + feinicontrato.Year.ToString();
            DateTime fefincontrato = Convert.ToDateTime(Fecha_Fin_Contrato);
            string FE_FINAL_CONTRATO = fefincontrato.Day.ToString() + " de " + ci.DateTimeFormat.GetMonthName(fefincontrato.Month) + " del " + fefincontrato.Year.ToString();
            string PERIODO_PRUEBA = "";
            //No Aplica
            //if ((Request.QueryString["Personal_Id"] == null))
            //{
            //    if ((Convert.ToInt32(Request.QueryString["Id"].ToString().Trim()) != 0))
            //        PERIODO_PRUEBA = "El presente periodo incluye el periodo de prueba de 3 meses.";
            //}
            string SUELDO_TRABAJADOR_NUMERO = string.Format("{0:N2}", Convert.ToDecimal(SueldoBruto));
            string SUELDO_TRABAJADOR_LETRA = enLetras(SueldoBruto) + " Nuevos Soles";
            string FECHA_FIRMA_CONTRATO = string.Format("{0:dd 'de' MMMM 'del' yyyy}", Convert.ToDateTime(Fecha_Ini_Contrato).AddDays(-1));

            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[TIPO_RENOVACION]", TIPO_RENOVACION);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[NOMBRE_TRABAJADOR]", NOMBRE_TRABAJADOR);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[DNI_TRABAJADOR]", DNI_TRABAJADOR);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[DIRECCION_TRABAJADOR]", DIRECCION_TRABAJADOR);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[CARGO_TRABAJADOR]", CARGO_TRABAJADOR);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[FISCALIZACION]", FISCALIZACION);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[FUNCIONES_CARGO]", FUNCIONES_CARGO);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[FE_INICIO_CONTRATO]", FE_INICIO_CONTRATO);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[FE_FINAL_CONTRATO]", FE_FINAL_CONTRATO);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[PERIODO_PRUEBA]", PERIODO_PRUEBA);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[SUELDO_TRABAJADOR_NUMERO]", SUELDO_TRABAJADOR_NUMERO);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[SUELDO_TRABAJADOR_LETRA]", SUELDO_TRABAJADOR_LETRA);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[FECHA_FIRMA_CONTRATO]", FECHA_FIRMA_CONTRATO);

            // Abre ventana para impresión
            string script_impresion;
            script_impresion = "<script language='javascript' type='text/javascript'>fn_VistaPreliminar('" + tx_plantilla_contrato + "');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "WindowOpenContrato", script_impresion, false);


            //string script;
            ////  Script = "<script language='javascript' type='text/javascript'>window.open('VistaContratoPlazoIndeterminado.aspx','Impresion','width=700,height=500,scrollbars=yes');</script>"
            ////    script = "window.open('VistaContratoNecesidadMercado.aspx','width=900,height=800,scrollbars=yes');";
            //script = "window.open('VistaContratoNecesidadMercado.aspx','Impresion','width=700,height=500,scrollbars=yes')";
            ////  Session["ABC"] = Convert.ToDateTime(dt2.Rows[0]["Fecha_Ini_Contrato"].ToString()).ToString("dd/MM/yyyy"); 
            //Utils.fc_JavaScript(this, script);
            //// ScriptManager.RegisterStartupScript( "WindowOpen", script, false);

            //if (dt.Rows[0]["Tipo_Contrato_Id"].ToString() == "04")
            //{
            //    if (Cargo.Contains("SUPERVISOR DE DESPACHO"))
            //        script = "window.open('VistaContratoNecesidadMercadoSup.aspx','Impresion','width=700,height=500,scrollbars=yes');</script>";
            //    else
            //        script = "window.open('VistaContratoNecesidadMercado.aspx','Impresion','width=700,height=500,scrollbars=yes');</script>";
            //}

            //else if (dt.Rows[0]["Tipo_Contrato_Id"].ToString() == "01" )
            //{script = "window.open('VistaContratoPlazoIndeterminado.aspx','Impresion','width=700,height=500,scrollbars=yes');</script>";}
            // else if (dt.Rows[0]["Tipo_Contrato_Id"].ToString() == "03")
            //{   script = "window.open('VistaContratoIncrementoActividad.aspx','Impresion','width=700,height=500,scrollbars=yes');</script>";}
            // else if (dt.Rows[0]["Tipo_Contrato_Id"].ToString() == "14")
            //{  script = "window.open('VistaContratoServiciosIntermitentes.aspx','Impresion','width=700,height=500,scrollbars=yes');</script>";}
            // else if (dt.Rows[0]["Tipo_Contrato_Id"].ToString() =="15")
            //{  script = "window.open('VistaContratoServicioEspecifico.aspx','Impresion','width=700,height=500,scrollbars=yes');</script>";}


            //else
            //    {   if (dt2.Rows[0]["Categoria2_Id"].ToString() == "02"){//'Sujeto a Fiscalizacion
            //        script = "window.open('VistaContrato.aspx','Impresion','width=700,height=500,scrollbars=yes');</script>"}
            //    else //No Sujeto a Fiscalizacion
            //        script = "window.open('VistaContratoNoFiscalizado.aspx','Impresion','width=700,height=500,scrollbars=yes');</script>"
            //    }


        }



        private string enLetras(string num)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string res = "";
            string dec = "";
            Int64 entero;
            int decimales;
            double nro;
            try
            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }
            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
                dec = " y " + decimales.ToString() + "/100";
            else
                dec = " y 00/100";
            res = toText(Convert.ToDouble(entero)) + dec;
            return res;

        }

        public string toText(double value)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string Num2Text = "";
            value = Math.Truncate(value);

            if (value == 0)
            { Num2Text = "CERO"; }
            else if (value == 1)
            { Num2Text = "UNO"; }
            else if (value == 2)
            { Num2Text = "DOS"; }
            else if (value == 3)
            { Num2Text = "TRES"; }
            else if (value == 4)
            { Num2Text = "CUATRO"; }
            else if (value == 5)
            { Num2Text = "CINCO"; }
            else if (value == 6)
            { Num2Text = "SEIS"; }
            else if (value == 7)
            { Num2Text = "SIETE"; }
            else if (value == 8)
            { Num2Text = "OCHO"; }
            else if (value == 9)
            { Num2Text = "NUEVE"; }
            else if (value == 10)
            { Num2Text = "DIEZ"; }
            else if (value == 11)
            { Num2Text = "ONCE"; }
            else if (value == 12)
            { Num2Text = "DOCE"; }
            else if (value == 13)
            { Num2Text = "TRECE"; }
            else if (value == 14)
            { Num2Text = "CATORCE"; }
            else if (value == 15)
            { Num2Text = "QUINCE"; }
            else if (value < 20)
            { Num2Text = "DIECI" + toText(value - 10); }
            else if (value == 20)
            { Num2Text = "VEINTE"; }
            else if (value < 30)
            { Num2Text = "VEINTI" + toText(value - 20); }
            else if (value == 30)
            { Num2Text = "TREINTA"; }
            else if (value == 40)
            { Num2Text = "CUARENTA"; }
            else if (value == 50)
            { Num2Text = "CINCUENTA"; }
            else if (value == 60)
            { Num2Text = "SESENTA"; }
            else if (value == 70)
            { Num2Text = "SETENTA"; }
            else if (value == 80)
            { Num2Text = "OCHENTA"; }
            else if (value == 90)
            { Num2Text = "NOVENTA"; }
            else if (value < 100)
            { Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10); }
            else if (value == 100)
            { Num2Text = "CIEN"; }
            else if (value < 200)
            { Num2Text = "CIENTO " + toText(value - 100); }
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800))
            { Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS"; }
            else if (value == 500)
            { Num2Text = "QUINIENTOS"; }
            else if (value == 700)
            { Num2Text = "SETECIENTOS"; }
            else if (value == 900)
            { Num2Text = "NOVECIENTOS"; }
            else if (value < 1000)
            { Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100); }
            else if (value == 1000)
            { Num2Text = "MIL"; }
            else if (value < 2000)
            { Num2Text = "MIL " + toText(value % 1000); }
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0)
                { Num2Text = Num2Text + " " + toText(value % 1000); }
                else if (value == 1000000)
                    Num2Text = "UN MILLON";
            }
            else if (value < 2000000)
            { Num2Text = "UN MILLON " + toText(value % 1000000); }
            else if (value < 1000000000000L)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0)
                    Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }
            else if (value == 1000000000000L)
                Num2Text = "UN BILLON";

            else if (value < 2000000000000L)
                Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000L) * 1000000000000L);
            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000L)) + " BILLONES";
                {
                    if ((value - Math.Truncate(value / 1000000000000L) * 1000000000000L) > 0)
                        Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000L) * 1000000000000L);
                }
            }
            return Num2Text;
        }


       
        protected void btnExportarWord_Click(object sender, System.EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            GridViewRow row = (GridViewRow)(((Button)sender).NamingContainer);
            Button button = (Button)row.FindControl("btnExportarWord");
            string Personal_Id = button.CommandName.ToString();
            string Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
            string Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);

            ExportContrato_WORD(Personal_Id, Periodo_Id, Planilla_Id);
        }

        private void ExportContrato_WORD(String Personal_Id, String Periodo_Id, String Planilla_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            DataTable dt = new DataTable();
            dt = objNegPersonal.ListaDataxPersonalId(Personal_Id);
            DataTable dt2 = new DataTable();
            dt2 = objNegPersonal.ListaDataxPersonalIdAct(Personal_Id, Periodo_Id);

            String Nro_Doc = dt.Rows[0]["Nro_Doc"].ToString();
            String Nombres = dt.Rows[0]["Nombres"].ToString();
            String Apellidos = dt.Rows[0]["Apellido_Paterno"].ToString().ToUpper() + " " + dt.Rows[0]["Apellido_Materno"].ToString().ToUpper();
            String Direccion = dt.Rows[0]["Direccion"].ToString();

            String Tipo_Contrato_Id = dt2.Rows[0]["Tipo_Contrato_Id"].ToString();
            String Cargo_Id = dt2.Rows[0]["Cargo_Id"].ToString();

            String Fecha_Ingreso = (Convert.ToDateTime(dt2.Rows[0]["Fecha_ingreso"].ToString())).ToString("dd/MM/yyyy");
            String Fecha_Ini_Contrato = (Convert.ToDateTime(dt2.Rows[0]["Fecha_ini_contrato"].ToString())).ToString("dd/MM/yyyy");
            String Fecha_Fin_Contrato = (Convert.ToDateTime(dt2.Rows[0]["Fecha_fin_contrato"].ToString())).ToString("dd/MM/yyyy");

            string NomCargo = dt2.Rows[0]["NomCargo"].ToString();

            //-------------------
            Ent_D_Fijos entFijos = new Ent_D_Fijos();
            entFijos.Periodo_Id = Periodo_Id;
            entFijos.Personal_Id = Personal_Id;
            DataTable dtDFijos = CAPA_LOGICO.Log_D_Fijos.Lista_D_Fijos(entFijos, "");
            List<Ent_D_Fijos> lstDFijos = new List<Ent_D_Fijos>();
            lstDFijos = (from DataRow dr in dtDFijos.Rows
                         select new Ent_D_Fijos
                         {
                             Periodo_Id = dr["Periodo_Id"].ToString(),
                             Personal_Id = dr["Personal_Id"].ToString(),
                             Concepto_Id = dr["Concepto_Id"].ToString(),
                             Valor = Convert.ToDecimal(dr["Valor"])
                         }).ToList();

            String SueldoBruto = string.Format("{0:N2}", lstDFijos.Find(fijo => fijo.Concepto_Id == Concepto_Id_D_BASICO).Valor); //D_BASICO
                                                                                                                                  //-----------------

            String txtFiscalizado = "";
            if (dt2.Rows[0]["Categoria2_Id"].ToString() == "01")
            { txtFiscalizado = "No Sujeto a Fiscalización"; }
            else if (dt2.Rows[0]["Categoria2_Id"].ToString() == "02")
            { txtFiscalizado = "Sujeto a Fiscalización"; }


            // Obtiene las funciones
            DataTable dtFunciones = Log_Cargo_Funciones.List_Cargo(dt.Rows[0]["Personal_Id"].ToString(), dt2.Rows[0]["Cargo_Id"].ToString());
            List<String> lstFunciones = new List<String>();
            foreach (DataRow rowFc in dtFunciones.Rows)
            {
                if (rowFc["Personal_Id"].ToString() != "0")
                {
                    lstFunciones.Add(rowFc["Funcion"].ToString());
                }
            }
            //////Funciones(dt.Rows[0]["Personal_Id"].ToString(), dt2.Rows[0]["Cargo_Id"].ToString()); //carga chkFunciones y chklstFunc
            //////ListItemCollection lst = new ListItemCollection();
            //////for (int index = 0; index < chklstFunc.Items.Count; index++)
            //////{
            //////    if (chklstFunc.Items[index].Selected)
            //////    {
            //////        lst.Add(chklstFunc.Items[index]);
            //////    }

            //////}
            //////Session["lsbFunciones"] = lst;

            //IMPRIME CONTRATO DESDE PLANTILLA
            CAPA_DATOS.oRRHH.controllerContratosPlantilla oControllerPlantillaContratos = new CAPA_DATOS.oRRHH.controllerContratosPlantilla();
            String tx_plantilla_contrato = oControllerPlantillaContratos.getPlantillaContrato_HTML(Tipo_Contrato_Id, Cargo_Id);
            if (String.IsNullOrEmpty(tx_plantilla_contrato))
            {
                //Mensaje1.Text = "No se encontró una plantilla para el siguiente Tipo de Contrato y Cargo.";
                //Mensaje1.ForeColor = System.Drawing.Color.DarkOrange;
                string msg = "No se encontró una plantilla para el siguiente Tipo de Contrato y Cargo.";
                string scriptMSG;
                scriptMSG = "<script language='javascript' type='text/javascript'>alert('" + msg + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "JSAlert", scriptMSG, false);

                return;
            }

            // Reemplazando palabras clave de plantilla de contrato
            string TIPO_RENOVACION = "";
            if ((Fecha_Ingreso != Fecha_Ini_Contrato))
                TIPO_RENOVACION = "RENOVACIÓN DE ";
            string NOMBRE_TRABAJADOR = Nombres.ToUpper() + " " + Apellidos.Trim().ToUpper();
            string DNI_TRABAJADOR = Nro_Doc.Trim();
            string DIRECCION_TRABAJADOR = Direccion.ToUpper();
            string CARGO_TRABAJADOR = NomCargo;
            string FISCALIZACION = txtFiscalizado;
            string FUNCIONES_CARGO = "";
            if (lstFunciones.Count > 0)
            {
                for (int index = 0; index <= lstFunciones.Count - 1; index++)
                {
                    if ((index == 0))
                    {
                        FUNCIONES_CARGO = "<b>EL TRABAJADOR</b>, consiente  de la responsabilidad del cargo asignado, se obliga a:<br>";
                        FUNCIONES_CARGO += lstFunciones[index].ToString();
                    }
                    else
                        FUNCIONES_CARGO += "<br>" + lstFunciones[index].ToString();
                }
            }
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-PE");
            DateTime feinicontrato = Convert.ToDateTime(Fecha_Ini_Contrato);
            string FE_INICIO_CONTRATO = feinicontrato.Day.ToString() + " de " + ci.DateTimeFormat.GetMonthName(feinicontrato.Month) + " del " + feinicontrato.Year.ToString();
            DateTime fefincontrato = Convert.ToDateTime(Fecha_Fin_Contrato);
            string FE_FINAL_CONTRATO = fefincontrato.Day.ToString() + " de " + ci.DateTimeFormat.GetMonthName(fefincontrato.Month) + " del " + fefincontrato.Year.ToString();
            string PERIODO_PRUEBA = "";
            //No Aplica
            //if ((Request.QueryString["Personal_Id"] == null))
            //{
            //    if ((Convert.ToInt32(Request.QueryString["Id"].ToString().Trim()) != 0))
            //        PERIODO_PRUEBA = "El presente periodo incluye el periodo de prueba de 3 meses.";
            //}
            string SUELDO_TRABAJADOR_NUMERO = string.Format("{0:N2}", Convert.ToDecimal(SueldoBruto));
            string SUELDO_TRABAJADOR_LETRA = enLetras(SueldoBruto) + " Nuevos Soles";
            string FECHA_FIRMA_CONTRATO = string.Format("{0:dd 'de' MMMM 'del' yyyy}", Convert.ToDateTime(Fecha_Ini_Contrato).AddDays(-1));

            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[TIPO_RENOVACION]", TIPO_RENOVACION);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[NOMBRE_TRABAJADOR]", NOMBRE_TRABAJADOR);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[DNI_TRABAJADOR]", DNI_TRABAJADOR);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[DIRECCION_TRABAJADOR]", DIRECCION_TRABAJADOR);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[CARGO_TRABAJADOR]", CARGO_TRABAJADOR);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[FISCALIZACION]", FISCALIZACION);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[FUNCIONES_CARGO]", FUNCIONES_CARGO);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[FE_INICIO_CONTRATO]", FE_INICIO_CONTRATO);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[FE_FINAL_CONTRATO]", FE_FINAL_CONTRATO);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[PERIODO_PRUEBA]", PERIODO_PRUEBA);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[SUELDO_TRABAJADOR_NUMERO]", SUELDO_TRABAJADOR_NUMERO);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[SUELDO_TRABAJADOR_LETRA]", SUELDO_TRABAJADOR_LETRA);
            tx_plantilla_contrato = tx_plantilla_contrato.Replace("[FECHA_FIRMA_CONTRATO]", FECHA_FIRMA_CONTRATO);

            // Descarga WORD
            string NombreArchivo = Apellidos + " " + Nombres + " - " + Utils.fc_obtiene_Mes_Id_Nombre(this);

            System.Text.StringBuilder strBody = new System.Text.StringBuilder("");
            strBody.Append("<html " + "xmlns:o='urn:schemas-microsoft-com:office:office' " + "xmlns:w='urn:schemas-microsoft-com:office:word'" + "xmlns='http://www.w3.org/TR/REC-html40'>" + "<head><meta http-equiv='Content-Type' content='text-html;charset=utf-8'/><title>Time</title>");
            strBody.Append("<!--[if gte mso 9]>" + "<xml>" + "<w:WordDocument>" + "<w:View>Print</w:View>" + "<w:Zoom>90</w:Zoom>" + "<w:DoNotOptimizeForBrowser/>" + "</w:WordDocument>" + "</xml>" + "<![endif]-->");
            strBody.Append("<style>" + "<!-- /* Style Definitions */" + "@page Section1" + "   {size:8.5in 11.0in; " + "   margin:1.0in 1.25in 1.0in 1.25in ; " + "   mso-header-margin:.5in; " + "   mso-footer-margin:.5in; mso-paper-source:0;}" + " div.Section1" + "   {page:Section1;}" + "-->" + "</style></head>");
            strBody.Append("<body lang=ES-PE style='tab-interval:.5in'>" + tx_plantilla_contrato + "</body></html>");
            Response.Clear();
            Response.AppendHeader("Content-Type", "application/msword");
            Response.AppendHeader("Content-disposition", "attachment; filename=" + NombreArchivo + ".doc");
            Response.Write(strBody);
            Response.End();
        }

        string Fiscalizado = "";
        string CaracFiscalizado = "";
        string Contrato = "";

 
    }
}