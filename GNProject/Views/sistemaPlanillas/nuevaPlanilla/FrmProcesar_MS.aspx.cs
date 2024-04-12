using CAPA_ENTIDAD;
using CAPA_LOGICO;
using ciloci.FormulaEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.nuevaPlanilla
{
    public partial class FrmProcesar_MS : System.Web.UI.Page
    {
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

       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                //ucFiltros1.fc_carga_Filtros();

                FillDDL();
            }
        }

        private void FillDDL()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            PlanillasBL planillasBL = new PlanillasBL();
            //ddlPlanilla.DataTextField = "Descripcion";
            //ddlPlanilla.DataValueField = "Planilla_Id";
            //ddlPlanilla.DataSource = planillasBL.GetPlanillas();
            //ddlPlanilla.DataBind();

            ProcesosBL procesosBL = new ProcesosBL();
            ddlProceso.DataTextField = "Proceso";
            ddlProceso.DataValueField = "Proceso_Id";
            ddlProceso.DataSource = procesosBL.GetProcesos();
            ddlProceso.DataBind();

            PeriodoBL periodoBL = new PeriodoBL();
            //ddlPeriodo.DataTextField = "Descripcion";
            //ddlPeriodo.DataValueField = "Periodo_Id";
            //ddlPeriodo.DataSource = periodoBL.GetPeriodoPorPlanilla(ddlPlanilla.SelectedValue);
            //ddlPeriodo.DataBind();

            Ent_RH_Area objEArea = new Ent_RH_Area();
            cboArea.DataSource = Log_RH_Area.Lista_RH_Area(objEArea);
            cboArea.DataTextField = "Descripcion";
            cboArea.DataValueField = "Area_Id";
            cboArea.DataBind();
            cboArea.Items.Insert(0, new ListItem("-TODOS-", ""));

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
            cboProyecto.Items.Insert(0, new ListItem("-TODOS-", ""));
        }

        protected void ddlPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvPersonal.DataBind();
            PeriodoBL periodoBL = new PeriodoBL();
            //ddlPeriodo.DataTextField = "Descripcion";
            //ddlPeriodo.DataValueField = "Periodo_Id";
            //ddlPeriodo.DataSource = periodoBL.GetPeriodoPorPlanilla(ddlPlanilla.SelectedValue);
            //ddlPeriodo.DataBind();
            lblmsj.Text = "";
        }

        private void cargaGrilla()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            PersonalBL personalBL = new PersonalBL();
            String Area_Id = cboArea.SelectedValue;
            String Cat_Aux_Id = cboCatAuxiliar.SelectedValue;
            String Proceso_Id = ddlProceso.SelectedValue;
            string Proyecto_Id = cboProyecto.SelectedValue;
            string Personal_Ids = "";

            grvPersonal.DataSource = personalBL.GetPersonalActivoxProceso(Utils.fc_obtiene_Periodo_Id(this), Area_Id, Cat_Aux_Id, Proceso_Id, Proyecto_Id, Personal_Ids);
            grvPersonal.DataBind();
            if (grvPersonal.Rows.Count > 0)
            {
                btnProcesar.Enabled = true;
            }
            lblmsj.Text = "";
            lblInvalidFormula.Text = "";

            if (Proceso_Id == "03")
            {
                grvPersonal.Columns[9].Visible = true;
                grvPersonal.Columns[10].Visible = true;
            }
            else
            {
                grvPersonal.Columns[9].Visible = false;
                grvPersonal.Columns[10].Visible = false;
            }
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cargaGrilla();
            //PersonalBL personalBL = new PersonalBL();
            //grvPersonal.DataSource = personalBL.GetPersonalActivo(Utils.fc_obtiene_Periodo_Id(this)); //personalBL.GetPersonalActivo(ddlPeriodo.SelectedValue);
            //grvPersonal.DataBind();
            //if (grvPersonal.Rows.Count > 0)
            //{
            //    btnProcesar.Enabled = true;
            //}
            //lblmsj.Text = "";
            //lblInvalidFormula.Text = "";
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                lblInvalidFormula.Text = "";
                string Proceso_Id = ddlProceso.SelectedValue.ToString();
                string Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);//obtiene_Planilla_Id();//ddlPlanilla.SelectedValue.ToString();

                FormulasBL formulasBL = new FormulasBL();
                DataTable dtFormulas = formulasBL.GetFormulasPorProceso(Proceso_Id, Planilla_Id);

                int ROS = dtFormulas.Rows.Count;
                Int32 cont_personal_chk = 0;
                for (int i = 0; i < grvPersonal.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)grvPersonal.Rows[i].FindControl("chk");
                    GridViewRow row = (GridViewRow)chk.NamingContainer;
                    if (chk.Checked)
                    {
                        string Personal_Id = grvPersonal.DataKeys[row.RowIndex].Value.ToString();
                        string Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);//obtiene_Periodo_Id();//ddlPeriodo.SelectedValue.ToString();
                        CargarConceptosPorPersona(Personal_Id, Periodo_Id, Proceso_Id);
                        //, Planilla_Id, Proceso_Id
                        Procesar(dtFormulas, Personal_Id, Periodo_Id, Planilla_Id, Proceso_Id);
                        cont_personal_chk++;
                    }
                }
                if (cont_personal_chk > 0)
                {
                    lblmsj.Text = "Se realizó el proceso";
                    fc_DisplayAlert(this, "Proceso concluido.");
                }
                else
                {
                    lblmsj.Text = "";
                    fc_DisplayAlert(this, "Debe seleccionar al menos un personal.");
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message.ToString();
                fc_DisplayAlert(this, ".::Error; Detalle del error : " + mensaje);
            }
        }

        private void CargarConceptosPorPersona(string Personal_Id, string Periodo_Id, string Proceso_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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
        private void Procesar(DataTable dtFormulas, string Personal_Id, string Periodo_Id, string Planilla_Id, string Proceso_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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
                    lblmsj.Text = ".:: Error en la Fórmula : " + Descripcion + ".\n" + Formula;
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
            if (invalidformula.Length > 0)
            {
                lblInvalidFormula.Text = "Formulas invalidas<br/>" + invalidformula;
            }
            dtFormulas.Dispose();
            // lblmsg.Text = "Se realizo el proceso";
        }

        private void Change(string Name, string Formula)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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

        // Define a name and associated formula
        private bool DoAdd(string Name, string Formula)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
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

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvPersonal.DataBind();
            lblmsj.Text = "";
        }

        protected void ddlProceso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void grvPersonal_PreRender(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cargaGrilla();
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
    }
}