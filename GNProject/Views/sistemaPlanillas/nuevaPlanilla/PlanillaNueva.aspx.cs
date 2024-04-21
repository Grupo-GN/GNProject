using CAPA_DATOS.oFormulas;
using CAPA_ENTIDAD;
using CAPA_LOGICO;
using ciloci.FormulaEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.nuevaPlanilla
{
    public partial class PlanillaNueva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //List<string> Rlist
        }
        [WebMethod]
        public static object Get_Proceso_Combo()
        {
            CAPA_LOGICO.ProcesosBL procesosBL = new CAPA_LOGICO.ProcesosBL();
            System.Data.DataTable dt = procesosBL.GetProcesos();
            ArrayList rList = new ArrayList();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                object dat = new { Proceso_Id = row["Proceso_Id"].ToString(), Descripcion = row["Proceso"].ToString() };
                rList.Add(dat);

            }
            return rList;
        }
        [WebMethod]
        public static ArrayList ListaPlanilla()
        {
            return controller_RepGeneral.Get_Instance().ListaPlanilla();
        }
        [WebMethod]
        public static ArrayList ListaEjercicio()
        {
            return controller_RepGeneral.Get_Instance().ListaEjercicio();
        }
        [WebMethod]
        public static ArrayList ListaArea()
        {
            return controller_RepGeneral.Get_Instance().ListaArea();
        }
        [WebMethod]
        public static ArrayList ListaCatAuxiliar()
        {
            return controller_RepGeneral.Get_Instance().ListaCatAuxiliar();
        }
        [WebMethod]
        public static ArrayList Get_Periodo_Combo(string Compania_Id, string Anio, string Planilla_Id)
        {
            return controller_RepGeneral.Get_Instance().Get_Periodo_Combo(Compania_Id, Anio, Planilla_Id);
        }

        //////[WebMethod]
        //////public static ArrayList ListaPersonalActivoReporteGeneral(string PlanillaId, string PeriodoIni, string PeriodoFin)
        //////{
        //////    return controller_RepGeneral.Get_Instance().ListaPersonalActivoReporteGeneral(PlanillaId, PeriodoIni, PeriodoFin);
        //////}

        [WebMethod]
        public static ArrayList getPersonalActivo(string Planilla_Id, string Periodo_Id, string Localidad_Id, string Proyecto_Id, string Area_Id)
        {
            //return controller_RepGeneral.Get_Instance().ListaPersonalActivoReporteGeneral(Planilla_Id, Periodo_Id, Periodo_Id);
            string Proceso_Id = "08";
            PersonalBL PP = new PersonalBL();

            Localidad_Id = Localidad_Id == null ? "" : Localidad_Id; //En la carga de la página se envía null
            Proyecto_Id = Proyecto_Id == null ? "" : Proyecto_Id; //En la carga de la página se envía null
            Area_Id = Area_Id == null ? "" : Area_Id; //En la carga de la página se envía null

            String Personal_Ids = "";
            string flIncluyeCesados = "1";
            DataTable dt = PP.GetPersonalActivoxProceso_PagoLiquida(Periodo_Id, Localidad_Id, Area_Id, Proceso_Id, Proyecto_Id, Personal_Ids
                , flIncluyeCesados);
            ArrayList rList = new ArrayList();
            foreach (DataRow dr in dt.Rows)
            {
                object[] values = new object[2];
                values[0] = dr["Personal_Id"].ToString();
                values[1] = dr["Nombres"].ToString();

                rList.Add(values);
            }
            return rList;
        }

        [WebMethod]
        public static ArrayList ListaProyecto()
        {
            return controller_RepGeneral.Get_Instance().ListaProyecto();
        }
        [WebMethod]
        public static ArrayList ConfigFormulaGetConceptosByTipoList(string Tipo)
        {
            return controller_ConfigFormula.Get_Instance().ConfigFormulaGetConceptosByTipoList(Tipo);
        }

        [WebMethod]
        //public static ArrayList Lista_reporte_planilla(string localidad, string proyecto, string personal, string estado,
        //    string ejercicio, string flPeriodo, string PeriodoIni, string PeriodoFin, string PlanillaId, string Area)
        public static ArrayList Lista_reporte_planilla(string Planilla_Id, string Periodo_Id, string localidad, string proyecto, string catAuxiliar_Id, string personal
            //string ejercicio, string flPeriodo
            , string PeriodoIni_Datos, string PeriodoFin_Datos, string estado)
        {

            return controller_RepGeneral.Get_Instance().Lista_reporte_planilla(Planilla_Id, Periodo_Id, localidad, proyecto, catAuxiliar_Id, personal
                //, string ejercicio, string flPeriodo
                , PeriodoIni_Datos, PeriodoFin_Datos, estado);
        }
        // formulas para proceso de liquidacion

        [WebMethod]
        public static object InsertDetLiquidacion(List<string> Rlist, string Periodo_Id_Pago)
        {
            Boolean flError = false;
            String msg = controller_RepGeneral.Get_Instance().InsertDetLiquidacion(Rlist, Periodo_Id_Pago, out flError);
            object res = new { retorno = (flError == false ? "1" : "0"), msg_retorno = msg };
            return res;
        }

        public void CargarConceptosPorPersona(string Personal_Id, string Periodo_Id, string Proceso_Id)
        {
            ConceptosBL conceptosBL = new ConceptosBL();
            DataTable dtConceptosPorPerson = conceptosBL.GetConceptosPorPersona(Personal_Id, Periodo_Id, Proceso_Id);
            Engine.Clear();
            foreach (DataRow row in dtConceptosPorPerson.Rows)
            {
                DoAdd(row[0].ToString(), row[1].ToString());
            }
        }

        private string ValidarCondicion(string Condicion)
        {
            string result = "";
            double res = 0;
            try
            {
                if (Condicion != "1")
                {
                    object f = Engine.Evaluate(Condicion);
                    if (f.ToString().Contains("#NAME?"))
                    {
                        result = "-99";
                    }
                    else if (f.ToString().Contains("null"))
                    {
                        result = "0";
                    }
                    else
                    {
                        res = 0;
                        if (f.Equals(true))
                        {
                            result = "true";
                        }
                        else
                        {
                            result = "false";
                        }
                    }
                }
                else
                {
                    return "1";
                }

            }
            catch
            {
                result = "0";
            }
            if (result == "true")
            {
                return "OK";
            }
            else
            {
                return "ER";
            }
        }

        void Procesar(DataTable dtFormulas, string Personal_Id, string Periodo_Id, string Planilla_Id, string Proceso_Id)
        {
            List<CalculosBE> lstCalculos = new List<CalculosBE>();
            List<Calculos_PermBE> lstCalculos_Perm = new List<Calculos_PermBE>();
            string invalidformula = "";
            foreach (DataRow row in dtFormulas.Rows)
            {
                //Formula_texto
                //Formula_condicion
                string Concepto_Id = row["Concepto_Id"].ToString();
                ConceptosBL conceptosBL = new ConceptosBL();
                DataTable dtConceptoDirecto = conceptosBL.GetConceptoDirecto(Personal_Id, Periodo_Id, Concepto_Id);


                string Descripcion = row["Descripcion"].ToString();
                string Formula = row["Formula_texto"].ToString();
                string Condicion = row["Formula_condicion"].ToString();

                string result = "";
                string Val = "";

                try { object fVal = Engine.Evaluate(Formula); }
                catch (Exception ex)
                {
                    fc_DisplayAlert(this, ".:: Error en la Fórmula : " + Descripcion);
                    // lblmsj.Text = ".:: Error en la Fórmula : " + Descripcion + ".\n" + Formula;
                    return;
                }
                if (dtConceptoDirecto.Rows.Count > 0)
                {
                    result = dtConceptoDirecto.Rows[0]["Valor"].ToString();
                    double res = 0;
                    double.TryParse(result, out res);
                    if (res == 0)
                    {
                        try
                        {
                            Val = ValidarCondicion(Condicion);
                            if (Val == "1" || Val == "OK")
                            {
                                object f = Engine.Evaluate(Formula);

                                if (f.ToString().Contains("#NAME?"))
                                {
                                    result = "-99";
                                }
                                else if (f.ToString().Contains("null"))
                                {
                                    result = "0";
                                }
                                else
                                {
                                    res = 0;
                                    if (double.TryParse(f.ToString(), out res))
                                    {
                                        result = res.ToString();
                                    }
                                    else
                                    {
                                        result = "0";
                                    }
                                }
                            }
                            else
                            {
                                result = "0";
                            }

                        }
                        catch (Exception ex)
                        {
                            fc_DisplayAlert(this, ".:: Error en la Fórmula : " + Descripcion + ".\n" + ex.Message);
                            result = "0";
                        }
                    }
                }
                else
                {
                    try
                    {
                        Val = ValidarCondicion(Condicion);
                        if (Val == "1" || Val == "OK")
                        {
                            object f = Engine.Evaluate(Formula);
                            if (f.ToString().Contains("#NAME?"))
                            {
                                result = "-99";
                            }
                            else if (f.ToString().Contains("null"))
                            {
                                result = "0";
                            }
                            else
                            {
                                double res = 0;
                                if (double.TryParse(f.ToString(), out res))
                                {
                                    result = res.ToString();
                                }
                                else
                                {
                                    result = "0";
                                }

                            }
                        }
                        else
                        {
                            result = "0";
                        }

                    }
                    catch (Exception)
                    {
                        result = "0";
                    }
                }

                if (result == "-99")
                {
                    invalidformula += Descripcion + "<br/>";
                }

                if (result != "-99")
                {
                    if (row["Tipo_Dato"].ToString() == "03")//Formula
                    {
                        CalculosBE calculosBE = new CalculosBE();
                        calculosBE.Concepto_Id = row["Concepto_Id"].ToString();
                        calculosBE.Periodo_Id = Periodo_Id;
                        calculosBE.Personal_Id = Personal_Id;
                        calculosBE.Planilla_id = Planilla_Id;
                        calculosBE.Proceso_Id = Proceso_Id;
                        calculosBE.Valor = Convert.ToDouble(result);
                        lstCalculos.Add(calculosBE);
                    }
                    else//Acumulable
                    {
                        Calculos_PermBE calculos_PermBE = new Calculos_PermBE();
                        calculos_PermBE.Concepto_Id = row["Concepto_Id"].ToString();
                        calculos_PermBE.Periodo_Id = Periodo_Id;
                        calculos_PermBE.Personal_Id = Personal_Id;
                        calculos_PermBE.Planilla_id = Planilla_Id;
                        calculos_PermBE.Proceso_Id = Proceso_Id;
                        calculos_PermBE.Valor = Convert.ToDouble(result);
                        lstCalculos_Perm.Add(calculos_PermBE);
                    }
                }
                Change(row["Descripcion"].ToString(), "=" + result);
            }
            CalculosBL calculosBL = new CalculosBL();
            Calculos_PermBL calculos_PermBL = new Calculos_PermBL();

            if (lstCalculos.Count > 0)
            {
                calculosBL.InsertCalculos(lstCalculos);
            }
            if (lstCalculos_Perm.Count > 0)
            {
                calculos_PermBL.InsertCalculos_Perm(lstCalculos_Perm);
            }
            //if (invalidformula.Length > 0)
            //{
            //    lblInvalidFormula.Text = "Formulas invalidas<br/>" + invalidformula;
            //}
            dtFormulas.Dispose();
            // lblmsg.Text = "Se realizo el proceso";
        }

        FormulaEngine _formula = default(FormulaEngine);
        public FormulaEngine Engine
        {
            get
            {
                //Return MyServices.GetService(GetType(FormulaEngine))
                if (Session["Formula"] == null)
                {
                    if (_formula == null)
                    {
                        _formula = new FormulaEngine();
                        Session["Formula"] = _formula;
                        return _formula;
                    }
                    else
                    {
                        return _formula;
                    }
                }
                else
                {
                    return (FormulaEngine)Session["Formula"];
                }
            }

        }

        private void Change(string Name, string Formula)
        {
            INamedReference @ref = this.CreateNamedReference(Name);

            if (@ref == null)
            {
                return;
            }

            Formula f = Engine.GetFormulaAt(@ref);

            if ((f != null))
            {
                // Formula already exists with this name
                if (Formula == f.ToString())
                {
                    // Formula hasn't changed 
                    return;
                }
                else
                {
                    // Remove existing formula
                    Engine.RemoveFormula(f);
                }
            }

            // Do an add, then close the form if it succeeded
            if (this.DoAdd(Name, Formula) == true)
            {

            }
        }

        private bool DoAdd(string Name, string Formula)
        {
            string name = Name;
            // Try to create the named reference
            INamedReference @ref = this.CreateNamedReference(name);

            if (@ref == null)
            {
                return false;
            }

            // Try to create the formula
            if (this.CreateFormula(Formula, @ref, Formula) == false)
            {
                fc_DisplayAlert(this, ".::Error en la fórmula a : " + Name);
                return false;
            }

            // Recalculate any formulas that depend on this name
            Engine.Recalculate(@ref);

            // Do UI stuff
            //this.lbNames.Items.Add(@ref);
            //this.lbNames.SelectedItem = @ref;
            return true;
        }

        // Try to create a formula
        private bool CreateFormula(string expression, INamedReference @ref, string Formula)
        {
            // Get the main form to create a formula
            Formula f = CreateFormula(Formula);
            if (ValidarFormulas(Formula) == false)
            {
                fc_DisplayAlert(this, "Error");
            }
            if (f == null)
            {
                return false;
            }


            // Users will expect to be able to define named ranges.  For this to work, we have to change
            // the formula's result type to allow it to return references since, by default, it won't.
            f.ResultType = OperandType.Self;

            try
            {
                // Try to add the formula
                Engine.AddFormula(f, @ref);
            }
            catch (Exception ex)
            {
                //this.ShowMessage(ex.Message, MessageType.Error);
                return false;
            }

            return true;
        }

        public bool ValidarFormulas(string expression)
        {
            //SetVariables();
            Formula f = CreateFormula(expression);
            object result = null;

            if ((f != null))
            {
                // If it's a valid formula then evaluate it
                result = f.Evaluate();

                string text = null;

                if (result == null)
                {
                    text = "(null)";
                }
                else
                {
                    text = result.ToString();
                }

                if (text.Contains("#NAME?"))
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                return false;
            }
        }
        // Creates a formula with error handling
        public Formula CreateFormula(string expression)
        {
            try
            {
                //Engine.DefineVariable("RAV")
                return this.Engine.CreateFormula(expression);
            }
            catch (ciloci.FormulaEngine.InvalidFormulaException ex)
            {
                // This is the only exception that the CreateFormula method should throw
                return null;
            }
        }

        private INamedReference CreateNamedReference(string name)
        {
            try
            {
                INamedReference @ref = Engine.ReferenceFactory.Named(name);
                return @ref;
            }
            catch (Exception ex)
            {
                //this.ShowMessage(ex.Message, MessageType.Error);
                return null;
            }
        }

        public static void fc_DisplayAlert(Page c, String Msj)
        {
            /*Dentro de un ScriptManager*/
            Msj = Msj.Replace("\'", "\\'");
            Msj = Msj.Replace("\r", "\\r");
            Msj = Msj.Replace("\n", "\\n");
            String ScriptAlertRpta = "<script languaje='javascript' type='text/javascript'>alert('" + Msj + "');</script>";
            ScriptManager.RegisterStartupScript(c, typeof(Page), "AlertRpta", ScriptAlertRpta, false);
        }

        // Procesar Boton
        protected void btnProcesarFormula_Click(object sender, EventArgs e)
        {
            //proceso por metodo de formula de liquidacion   Personal_Id
            DataTable dt = new DataTable();
            PersonalBL PP = new PersonalBL();
            string Proceso_Id = "08";
            string Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);//obtiene_Periodo_Id();//ddlPeriodo.SelectedValue.ToString();
            string localidad = "", Area = "", proyecto = "", personal = "", PlanillaId = "";
            localidad = txtlocalidad.Value;
            Area = txtarea.Value;
            proyecto = txtproyecto.Value;
            PlanillaId = Utils.fc_obtiene_Planilla_Id(this);
            personal = txtpersonal.Value;
            string flIncluyeCesados = "1";
            dt = PP.GetPersonalActivoxProceso_PagoLiquida(Periodo_Id.Trim(), localidad.Trim(), Area.Trim(), Proceso_Id.Trim(), proyecto.Trim(), personal.Trim()
                , flIncluyeCesados);

            FormulasBL formulasBL = new FormulasBL();
            DataTable dtFormulas = formulasBL.GetFormulasPorProceso(Proceso_Id.Trim(), PlanillaId.Trim());

            foreach (DataRow item in dt.Rows)
            {
                string Personal_Id = item["Personal_Id"].ToString();
                CargarConceptosPorPersona(Personal_Id.Trim(), Periodo_Id.Trim(), Proceso_Id.Trim());
                //, Planilla_Id, Proceso_Id
                Procesar(dtFormulas, Personal_Id.Trim(), Periodo_Id.Trim(), PlanillaId.Trim(), Proceso_Id.Trim());
            }
            string script;
            script = "alert('Se terminó de procesar las formulas.')";
            Utils.fc_JavaScript(this, script);
        }

        protected void btnreporte_Click(object sender, EventArgs e)
        {
            string reporte_Id = "0041";
            string periodo_Id = Utils.fc_obtiene_Periodo_Id(this);//obtiene_Periodo_Id();//ddlPeriodo.SelectedValue.ToString();
            string Planilla_Id = "";
            string personal = "";
            char delimitador = ',';
            Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
            personal = txtpersonal.Value;

            if (personal == "")
            {
                string personal_Id = "0";
                string parametros = "?Reporte_Id=" + reporte_Id + "&personal_Id=" + personal_Id + "&periodo_Id=" + periodo_Id + "&proceso_Id=01&Planilla_Id=" + Planilla_Id;
                string script;
                script = "window.open('../Reportes/FrmPreview.aspx" + parametros + "&fl_Imprimir_PDF=0','Reportes','width=790,height=800,scrollbars=yes');";
                Utils.fc_JavaScript(this, script);
            }
            else
            {
                string[] valoresPer = personal.Split(delimitador);

                string script;
                foreach (var item in valoresPer)
                {
                    string personal_Id = item.ToString();
                    string parametros = "?Reporte_Id=" + reporte_Id + "&personal_Id=" + personal_Id + "&periodo_Id=" + periodo_Id + "&proceso_Id=01&Planilla_Id=" + Planilla_Id;

                    script = "window.open('../Reportes/FrmPreview.aspx" + parametros + "&fl_Imprimir_PDF=1','Reportes','width=790,height=800,scrollbars=yes');";
                    Utils.fc_JavaScript(this, script);
                }
            }
        }
    }
}