using CAPA_ENTIDAD;
using CAPA_LOGICO;
using GNProject.Views.sistemaPlanillas.code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class FrmMntConceptosShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargardfijos();
                cargardvariable();
            }
        }


        void cargardfijos()
        {
            cbodfijos.DataSource = null;
            cbodfijos.DataTextField = "Descripcion";
            cbodfijos.DataValueField = "Concepto_Id";
            cbodfijos.DataSource = CAPA_DATOS.controllerConcepto.getInstance().ListarConceptosTipoMostrar("01", "0");
            cbodfijos.DataBind();

            chklistFijos.DataSource = null;
            chklistFijos.DataTextField = "Descripcion";
            chklistFijos.DataValueField = "Concepto_Id";
            chklistFijos.DataSource = CAPA_DATOS.controllerConcepto.getInstance().ListarConceptosTipoMostrar("01", "1");
            chklistFijos.DataBind();
            if (chklistFijos.Items.Count > 21)
            {
                decimal total = chklistFijos.Items.Count - 21;
                total = Math.Round((total * (decimal)19.05), 0);
                chklistFijos.Height = (400 + (int)total);
            }
        }
        void cargardvariable()
        {
            cbodvariable.DataSource = null;
            cbodvariable.DataTextField = "Descripcion";
            cbodvariable.DataValueField = "Concepto_Id";
            cbodvariable.DataSource = CAPA_DATOS.controllerConcepto.getInstance().ListarConceptosTipoMostrar("02", "0");
            cbodvariable.DataBind();

            chklistVariable.DataSource = null;
            chklistVariable.DataTextField = "Descripcion";
            chklistVariable.DataValueField = "Concepto_Id";
            chklistVariable.DataSource = CAPA_DATOS.controllerConcepto.getInstance().ListarConceptosTipoMostrar("02", "1");
            chklistVariable.DataBind();
            if (chklistVariable.Items.Count > 21)
            {
                decimal total = chklistVariable.Items.Count - 21;
                total = Math.Round((total * (decimal)19.05), 0);
                chklistVariable.Height = (400 + (int)total);
            }
        }
        protected void btnAgregarF_Click(object sender, EventArgs e)
        {
            string conceptoid = cbodfijos.SelectedValue.ToString();
            string res = CAPA_DATOS.controllerConcepto.getInstance().ModificarEstadoMostrarMant(conceptoid, "1");
            if (res.Split('#')[0] == "false")
            {
                Utils.fc_DisplayAlert(this.Page, "Error: " + res.Split('#')[1] + " Contacte con el área de sistemas.");
            }
            else
            {
                Utils.fc_DisplayAlert(this.Page, "Concepto agregado correctamente.");
                cargardfijos();

                //20200226
                string periodo_Id;
                string Personal_Id;

                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                Personal_Id = ""; //Para todo el personal

                //Datos Fijos
                Ent_D_Fijos objED_Fijos;
                objED_Fijos = new Ent_D_Fijos();
                objED_Fijos.Periodo_Id = periodo_Id;
                objED_Fijos.Personal_Id = Personal_Id;
                objED_Fijos.Concepto_Id = conceptoid;
                Log_D_Fijos.Inserta_D_Fijos_Genera_x_Concepto(objED_Fijos);
            }
        }
        protected void btnAgregarV_Click(object sender, EventArgs e)
        {
            string conceptoid = cbodvariable.SelectedValue.ToString();
            string res = CAPA_DATOS.controllerConcepto.getInstance().ModificarEstadoMostrarMant(conceptoid, "1");
            if (res.Split('#')[0] == "false")
            {
                Utils.fc_DisplayAlert(this.Page, "Error: " + res.Split('#')[1] + " Contacte con el área de sistemas.");
            }
            else
            {
                Utils.fc_DisplayAlert(this.Page, "Concepto agregado correctamente.");
                cargardvariable();

                //20200226
                string periodo_Id;
                string Personal_Id;

                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                Personal_Id = ""; //Para todo el personal

                //Datos Fijos
                Ent_D_Variables objED_Fijos;
                objED_Fijos = new Ent_D_Variables();
                objED_Fijos.Periodo_Id = periodo_Id;
                objED_Fijos.Personal_Id = Personal_Id;
                objED_Fijos.Concepto_Id = conceptoid;
                Log_D_Variables.Inserta_D_Variables_Genera_x_Concepto(objED_Fijos);
            }
        }
        protected void btnEliminarF_Click(object sender, EventArgs e)
        {
            int ok = 0, er = 0;
            for (int x = 0; x <= chklistFijos.Items.Count - 1; x++)
            {
                if (chklistFijos.Items[x].Selected)
                {
                    string res = CAPA_DATOS.controllerConcepto.getInstance().ModificarEstadoMostrarMant(chklistFijos.Items[x].Value, "0");
                    if (res.Split('#')[0] == "false")
                    {
                        er++;
                    }
                    else
                    {
                        ok++;
                    }
                }
            }
            Utils.fc_DisplayAlert(this.Page, "Proceso completado: " + ok.ToString() + " concepto(s) actualizado(s). " + er.ToString() + " Error(es)");
            cargardfijos();
        }
        protected void btnEliminarV_Click(object sender, EventArgs e)
        {
            int ok = 0, er = 0;
            for (int x = 0; x <= chklistVariable.Items.Count - 1; x++)
            {
                if (chklistVariable.Items[x].Selected)
                {
                    string res = CAPA_DATOS.controllerConcepto.getInstance().ModificarEstadoMostrarMant(chklistVariable.Items[x].Value, "0");
                    if (res.Split('#')[0] == "false")
                    {
                        er++;
                    }
                    else
                    {
                        ok++;
                    }
                }
            }
            Utils.fc_DisplayAlert(this.Page, "Proceso completado: " + ok.ToString() + " concepto(s) actualizado(s). " + er.ToString() + " Error(es)");
            cargardvariable();
        }
    }
}