using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CAPA_LOGICO;
using GNProject.Views.sistemaPlanillas.code;

namespace GNProject.Views.sistemaPlanillas.Procesos
{
    public partial class FrmViewCalculosPorPersona : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load();
                cargarPersonal();
            }
            HighlightGridLine();
        }

        private void cargarPersonal()
        {
            string idPeriodo = "";
            if (Session["Periodo_Id"] != null)
                idPeriodo = Session["Periodo_Id"].ToString();
            else
                idPeriodo = Utils.fc_obtiene_Periodo_Id(this);
            PersonalBL PersonalBL = new PersonalBL();
            ddlPersona.DataTextField = "Nombres";
            ddlPersona.DataValueField = "Personal_Id";
            ddlPersona.DataSource = PersonalBL.GetPersonalActivo(idPeriodo);
            ddlPersona.DataBind();
        }

        private void Load()
        {
            ProcesosBL procesosBL = new ProcesosBL();
            ddlProceso.DataTextField = "Proceso";
            ddlProceso.DataValueField = "Proceso_Id";
            ddlProceso.DataSource = procesosBL.GetProcesos();
            ddlProceso.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarPersona();
        }
        protected void grvCalculos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowDetail")
            {
                FormulasBL FormulasBL = new FormulasBL();
                System.Data.DataTable dtFormula = FormulasBL.GetFormula(e.CommandArgument.ToString().Split(':')[0]);
                lblFormula.Text = e.CommandArgument.ToString().Split(':')[1];
                txtCondicion.Text = dtFormula.Rows[0]["Formula_condicion"].ToString();
                txtFormula.Text = dtFormula.Rows[0]["Formula_texto"].ToString();
                pnl.Show();
            }
        }
        protected void grvCalculos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

                ImageButton lb = e.Row.FindControl("btnShowDetail") as ImageButton;
                ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lb);
            }
        }
        protected void grvFijos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }
        protected void grvVariables_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }
        protected void grvParametros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }
        protected void grvAcumulados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }
        protected void grvCalculos_PreRender(object sender, EventArgs e)
        {
            CalculosBL CalculosBL = new CalculosBL();
            string elPeriodo = Utils.fc_obtiene_Periodo_Id(this);
            grvCalculos.DataSource = CalculosBL.GetFormulasPorPersona(ddlPersona.SelectedValue, elPeriodo, ddlProceso.SelectedValue);
            grvCalculos.DataBind();
        }
        protected void ddlPersona_PreRender(object sender, EventArgs e)
        {
            //cargarPersonal();
        }
        protected void grvFijos_PreRender(object sender, EventArgs e)
        {
            CalculosBL CalculosBL = new CalculosBL();
            grvFijos.DataSource = CalculosBL.GetFijosPorPersona(ddlPersona.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
            grvFijos.DataBind();
        }
        protected void grvVariables_PreRender(object sender, EventArgs e)
        {
            CalculosBL CalculosBL = new CalculosBL();
            grvVariables.DataSource = CalculosBL.GetVariablesPorPersona(ddlPersona.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
            grvVariables.DataBind();
        }
        protected void grvParametros_PreRender(object sender, EventArgs e)
        {
            CalculosBL CalculosBL = new CalculosBL();
            grvParametros.DataSource = CalculosBL.GetParametrosPorPersona(ddlPersona.SelectedValue, Utils.fc_obtiene_Periodo_Id(this), ddlProceso.SelectedValue);
            grvParametros.DataBind();
        }
        protected void grvAcumulados_PreRender(object sender, EventArgs e)
        {
            CalculosBL CalculosBL = new CalculosBL();
            grvAcumulados.DataSource = CalculosBL.GetAcumuladosPorPersona(ddlPersona.SelectedValue, Utils.fc_obtiene_Periodo_Id(this), ddlProceso.SelectedValue);
            grvAcumulados.DataBind();
        }
        protected void ddlPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscarPersona();
        }

        private void buscarPersona()
        {
            CalculosBL CalculosBL = new CalculosBL();
            string elPeriodo = Utils.fc_obtiene_Periodo_Id(this);
            DataTable tabla = new DataTable();
            tabla = CalculosBL.GetFormulasPorPersona(ddlPersona.SelectedValue, elPeriodo, ddlProceso.SelectedValue);
            grvCalculos.DataSource = tabla;
            grvCalculos.DataBind();

            grvFijos.DataSource = CalculosBL.GetFijosPorPersona(ddlPersona.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
            grvFijos.DataBind();

            grvVariables.DataSource = CalculosBL.GetVariablesPorPersona(ddlPersona.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
            grvVariables.DataBind();

            grvParametros.DataSource = CalculosBL.GetParametrosPorPersona(ddlPersona.SelectedValue, Utils.fc_obtiene_Periodo_Id(this), ddlProceso.SelectedValue);
            grvParametros.DataBind();

            grvAcumulados.DataSource = CalculosBL.GetAcumuladosPorPersona(ddlPersona.SelectedValue, Utils.fc_obtiene_Periodo_Id(this), ddlProceso.SelectedValue);
            grvAcumulados.DataBind();
        }

        protected void elLink_Click(object sender, EventArgs e)
        {
            cargarPersonal();
        }
    }
}