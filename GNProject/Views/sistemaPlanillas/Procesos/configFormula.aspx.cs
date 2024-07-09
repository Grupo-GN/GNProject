using CAPA_DATOS.oFormulas;
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

namespace GNProject.Views.sistemaPlanillas.Procesos
{
    public partial class configFormula : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList ConfigFormulaGetProcesosSelect()
        {
            return controller_ConfigFormula.Get_Instance().ConfigFormulaGetProcesosSelect();
        }
        [WebMethod]
        public static ArrayList ConfigFormulaGetFormulasPlanillaList(string Planilla, string Proceso, string FormulaFind)
        {
            return controller_ConfigFormula.Get_Instance().ConfigFormulaGetFormulasPlanillaList(Planilla, Proceso, FormulaFind);
        }
        #region CONFIGURAR FORMULA
        [WebMethod]
        public static ArrayList ConfigFormulaGetConceptosList()
        {
            return controller_ConfigFormula.Get_Instance().ConfigFormulaGetConceptosList();
        }
        [WebMethod]
        public static ArrayList ConfigFormulaGetProcesoFuenteList()
        {
            return controller_ConfigFormula.Get_Instance().ConfigFormulaGetProcesoFuenteList();
        }
        [WebMethod]
        public static int ConfigFormulaGetMaxPosicionFormula(string PlanillaCod)
        {
            return controller_ConfigFormula.Get_Instance().ConfigFormulaGetMaxPosicionFormula(PlanillaCod);
        }

        [WebMethod]
        public static bool ConfigFormulaGetValidarFormula(string expression)
        {
            return clsValidarFormulas.Get_Instance().ValidarFormulas(expression);
        }


        [WebMethod]
        public static ArrayList ConfigFormulaGetTipoConceptosList()
        {
            return controller_ConfigFormula.Get_Instance().ConfigFormulaGetTipoConceptosList();
        }

        [WebMethod]
        public static ArrayList ConfigFormulaGetConceptosByTipoList(string Tipo)
        {
            return controller_ConfigFormula.Get_Instance().ConfigFormulaGetConceptosByTipoList(Tipo);
        }

        [WebMethod]
        public static string ConfigFormulaProcInsertFormula(string Concepto_Id, string Planilla_Id, int Nro, string Formula_texto, string Formula_condicion
                , string Fuente_Proceso_Id, bool ChangeLastNro, string Proceso_Id)
        {
            return controller_ConfigFormula.Get_Instance().ConfigFormulaProcInsertFormula(Concepto_Id, Planilla_Id, Nro, Formula_texto, Formula_condicion
                , Fuente_Proceso_Id, ChangeLastNro, Proceso_Id);
        }
        [WebMethod]
        public static object ConfigFormulaGetFormulaFind(string FormulaID)
        {
            return controller_ConfigFormula.Get_Instance().ConfigFormulaGetFormulaFind(FormulaID);
        }
        [WebMethod]
        public static string ConfigFormulaProcUpdateFormula(string Formula_Id, string Concepto_Id, string Planilla_Id, int Nro, string Formula_texto, string Formula_condicion
                , string Fuente_Proceso_Id, bool ChangeLastNro, string Proceso_Id)
        {
            return controller_ConfigFormula.Get_Instance().ConfigFormulaProcUpdateFormula(Formula_Id, Concepto_Id, Planilla_Id, Nro, Formula_texto, Formula_condicion
                , Fuente_Proceso_Id, ChangeLastNro, Proceso_Id);
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                clsValidarFormulas.Get_Instance().SetVariables();
            }
            catch (Exception ex)
            {
            }

        }
    }
    public class clsValidarFormulas
    {

        private static clsValidarFormulas instance = null;
        public static clsValidarFormulas Get_Instance()
        {
            return instance == null ? instance = new clsValidarFormulas() : instance;
        }
        FormulaEngine _formula = default(FormulaEngine);
        private FormulaEngine Engine
        {
            get
            {
                //Return MyServices.GetService(GetType(FormulaEngine))
                if (_formula == null)
                {
                    _formula = new FormulaEngine();
                    return _formula;
                }
                else
                {
                    return _formula;
                }
            }
        }
        private Formula CreateFormula(string expression)
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
        public void SetVariables()
        {
            ConceptosBL conceptosBL = new ConceptosBL();
            DataTable dtConceptos = new DataTable();
            dtConceptos = conceptosBL.GetConceptos();
            DataTable dtConceptosAcumulados = conceptosBL.GetConceptosPorTipo("04");//Acumulados
            foreach (DataRow row in dtConceptos.Rows)
            {
                try
                {
                    this.Engine.DefineVariable(row["Descripcion"].ToString().Trim());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            foreach (DataRow row in dtConceptosAcumulados.Rows)
            {
                try
                {
                    this.Engine.DefineVariable("A" + row["Descripcion"].ToString().Trim());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            this.Engine.DefineVariable("T_DIAS_VACA");
            this.Engine.DefineVariable("T_DSALDO_VAC"); //20211117
            this.Engine.DefineVariable("T_DINDEMNIZACION_VAC"); //20211117
            this.Engine.DefineVariable("T_SALDO_VAC_PERIODOS_ANTERIORES"); //20220504
            this.Engine.DefineVariable("T_SALDO_VAC_TRUNCA"); //20220504
            this.Engine.DefineVariable("IF_DESCUENTO_CTACTE");
            this.Engine.DefineVariable("IF_DESCUENTO_TELEFONIA");
            this.Engine.DefineVariable("IF_PRESTAMO_BANCARIO");
            this.Engine.DefineVariable("IF_PRESTAMO_CTACTE");
            this.Engine.DefineVariable("IF_TOTAL_CTACTES");
            this.Engine.DefineVariable("T_PERFECHA_INGRESO");
            this.Engine.DefineVariable("T_PERFECHA_CESE");

            this.Engine.DefineVariable("T_PERFDIA_INGRESO");
            this.Engine.DefineVariable("T_PERFANO_INGRESO");
            this.Engine.DefineVariable("T_PERFMES_INGRESO");
            this.Engine.DefineVariable("T_PERFDIA_CESE");
            this.Engine.DefineVariable("T_PERFMES_CESE");
            this.Engine.DefineVariable("T_PERFANO_CESE");
            this.Engine.DefineVariable("T_PDIAS_CALENDARIOS");

            //20180707
            this.Engine.DefineVariable("T_TOTAL_ADELANTO_SEMANAS");
            this.Engine.DefineVariable("T_FECHA_INI_PERIODO");
            this.Engine.DefineVariable("T_FECHA_FIN_PERIODO");
            this.Engine.DefineVariable("T_CANT_DIAS_PERIODO");
            this.Engine.DefineVariable("T_TOTAL_DIAS_PERIODO");
            //20180804
            this.Engine.DefineVariable("T_CATEGORIA_PERSONAL");
            //20190118
            this.Engine.DefineVariable("T_DOMICILIADO");
            this.Engine.DefineVariable("T_REGIMEN_LABORAL");
            this.Engine.DefineVariable("T_REGIMEN_PENSIONARIO"); //@001 I/F
            this.Engine.DefineVariable("T_PAGAR_BENEF_SOCIALES_PERIODO");
            //20200123
            this.Engine.DefineVariable("T_FECHA_INI_PERIODO_DIA");
            this.Engine.DefineVariable("T_FECHA_INI_PERIODO_MES");
            this.Engine.DefineVariable("T_FECHA_INI_PERIODO_ANIO");
            this.Engine.DefineVariable("T_FECHA_FIN_PERIODO_DIA");
            this.Engine.DefineVariable("T_FECHA_FIN_PERIODO_MES");
            this.Engine.DefineVariable("T_FECHA_FIN_PERIODO_ANIO");
            this.Engine.DefineVariable("T_LBS_CTS_ACUMULADO");
            this.Engine.DefineVariable("T_LBS_VAC_ACUMULADO");
            this.Engine.DefineVariable("T_LBS_VAC_GOZADA_ACUMULADO");
            this.Engine.DefineVariable("T_LBS_GRAT_ACUMULADO");
            this.Engine.DefineVariable("T_LBS_ESSALUD_GRAT_ACUMULADO");
            //20210421
            this.Engine.DefineVariable("T_LBS_CTS_PAGADO");
            this.Engine.DefineVariable("T_LBS_VAC_PAGADO");
            this.Engine.DefineVariable("T_LBS_GRAT_PAGADO");
            this.Engine.DefineVariable("T_LBS_ESSALUD_GRAT_PAGADO");
            //@002 I
            this.Engine.DefineVariable("T_PERFECHA_NACIMIENTO");
            this.Engine.DefineVariable("T_PERFDIA_NACIMIENTO");
            this.Engine.DefineVariable("T_PERFMES_NACIMIENTO");
            this.Engine.DefineVariable("T_PERFANO_NACIMIENTO");
            this.Engine.DefineVariable("T_TOTAL_DIAS_NACIMIENTO");
            this.Engine.DefineVariable("T_PEREDAD");
            //@002 F
            /*NUEVAS VARIABLES A AGREGAR*/
            this.Engine.DefineVariable("T_REMU_ACUM_5TACATEGORIA");
            this.Engine.DefineVariable("T_RETENCION_ACUM_5TACATEGORIA");

            this.Engine.DefineVariable("T_PROMEDIO_HEXTRA_IMPORTE");
            this.Engine.DefineVariable("T_PROMEDIO_HEXTRA_CANTIDAD");
            this.Engine.DefineVariable("T_PROMEDIO_COMISIONES_IMPORTES");
            this.Engine.DefineVariable("T_PROMEDIO_COMISIONES_CANTIDAD");
            this.Engine.DefineVariable("T_PROMEDIO_BONIFICACIONES_IMPORTES");
            this.Engine.DefineVariable("T_PROMEDIO_BONIFICACIONES_CONTAR");
            this.Engine.DefineVariable("T_RETENCION_ACUM_ONP");
            this.Engine.DefineVariable("T_RETENCION_ACUM_ESSALUD");
            this.Engine.DefineVariable("T_RETENCION_ACUM_SSP");
            this.Engine.DefineVariable("T_REMU_ACUM_ESSALUD_SPP");

            this.Engine.DefineVariable("T_REMUN_MENSUAL_5TACATEGORIA");
            this.Engine.DefineVariable("T_RETENCION_MENSUAL_5TACATEGORIA");
            this.Engine.DefineVariable("T_REMUN_MENSUAL_ESSALUD_SPP");
            this.Engine.DefineVariable("T_REMUN_MENSUAL_FONDO");
            this.Engine.DefineVariable("T_REMUN_MENSUAL_SEGURO");
            this.Engine.DefineVariable("T_REMUN_MENSUAL_COMISION");
            this.Engine.DefineVariable("T_REMUN_MENSUAL_ONP");
            this.Engine.DefineVariable("T_REMUN_MENSUAL_ESSALUD");

            this.Engine.DefineVariable("T_REMUN_SUBSIDIO");

            this.Engine.DefineVariable("T_REMU_MES_ESSALUD_SEMANAL");
            this.Engine.DefineVariable("T_RETENCION_ESSALUD_SEMANAL");
            //FIN NUEVAS FORMULAS
        }
    }
}