using CAPA_ENTIDAD;
using CAPA_LOGICO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class FrmMntPlantillaSustento : System.Web.UI.Page
    {
        Ent_Conceptos objEConceptos;
        Ent_Sustentos objESustentos;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                LlengaGrilla();

                Carga_combo_ColumnasBoleta();
                Carga_combo_Procesos();
                Lista_Ordenamiento_Conceptos(cboColumnaBoleta.SelectedValue, cboProceso.SelectedValue);
                CargarCamposPersonal();
                TabContainer1.ActiveTabIndex = 0;
                TabPanel1.Visible = false;
                //cboColumnaBoleta.Enabled = false;
                //cboDistribución.Enabled = false;
                cboProceso.Enabled = true;

            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnNew.Enabled = false;
            btnAdd.Enabled = true;
            btnCancel.Enabled = true;
            btnDelete.Enabled = false;
            Clear();
            TabContainer1.ActiveTabIndex = 1;
            TabPanel1.Visible = true;

        }
        void Clear()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            CargarCamposPersonal();
            lbConceptosIN.Items.Clear();
            lbpersonalIN.Items.Clear();
            txtnombre.Text = "";
            cboColumnaBoleta.SelectedIndex = 0;
            cboDistribución.SelectedIndex = 0;
            cboProceso.SelectedIndex = 0;
            lbConceptos.Items.Clear();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objESustentos = new Ent_Sustentos();
            string ConceptosID = "";
            string ConceptosCamp = "";
            string PersonalCamp = "";
            string DetalleConcepto = "";
            //string[] Procesos={};
            List<string> Procesos = new List<string>();

            string Proceso = "";
            int cantC = 0;
            int cantP = 0;
            for (Int32 i = 0; i <= lbConceptosIN.Items.Count - 1; i++)
            {
                objESustentos.ConceptoID = lbConceptosIN.Items[i].Value;
                string detaGetServer = Log_Sustentos.GetDetalleConcepto(lbConceptosIN.Items[i].Value).Rows[0][0].ToString();
                if (detaGetServer.Trim() == "")
                {
                    detaGetServer = "n" + lbConceptosIN.Items[i].Text;
                }
                DetalleConcepto += detaGetServer + ",";
                Proceso = Log_Sustentos.GetProcesoConcepto(objESustentos).Rows[0][0].ToString();
                if (Procesos.Count == 0)
                {
                    Procesos.Add(Proceso);
                }
                if (Procesos.Exists(element => element == Proceso).Equals(false))
                {
                    Procesos.Add(Proceso);
                }
                ConceptosID += lbConceptosIN.Items[i].Value + ",";
                ConceptosCamp += lbConceptosIN.Items[i].Text + ",";
                cantC += 1;

            }
            for (Int32 i = 0; i <= lbpersonalIN.Items.Count - 1; i++)
            {
                PersonalCamp += lbpersonalIN.Items[i].Value + ",";
                cantP += 1;
            }
            ConceptosID = ConceptosID.Remove(ConceptosID.Length - 1);
            ConceptosCamp = ConceptosCamp.Remove(ConceptosCamp.Length - 1);
            PersonalCamp = PersonalCamp.Remove(PersonalCamp.Length - 1);
            DetalleConcepto = DetalleConcepto.Remove(DetalleConcepto.Length - 1);
            Proceso = "";
            for (Int32 y = 0; y <= Procesos.Count - 1; y++)
            {
                Proceso += Procesos[y] + ",";
            }
            Proceso = Proceso.Remove(Proceso.Length - 1);

            objESustentos.ProcesoID = Proceso;
            objESustentos.ConceptoID = ConceptosID;
            objESustentos.CamposPerso = PersonalCamp;
            objESustentos.CamposConcep = ConceptosCamp;
            objESustentos.DetalleConceptos = DetalleConcepto;
            objESustentos.Nombre = txtnombre.Text;
            objESustentos.CantC = cantC;
            objESustentos.CantP = cantP;

            string Respuesta = Log_Sustentos.NuevaPlantilla(objESustentos).Rows[0][0].ToString();
            Utils.fc_DisplayAlert(this, Respuesta);
            btnAdd.Enabled = false;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;
            btnNew.Enabled = true;
            TabContainer1.ActiveTabIndex = 0;
            TabPanel1.Visible = false;
            LlengaGrilla();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnAdd.Enabled = false;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;
            btnNew.Enabled = true;
            Clear();
            TabContainer1.ActiveTabIndex = 0;
            TabPanel1.Visible = false;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            objESustentos = new Ent_Sustentos();
            string ConceptosID = "";
            string ConceptosCamp = "";
            string PersonalCamp = "";
            string DetalleConcepto = "";
            //string[] Procesos={};
            List<string> Procesos = new List<string>();

            string Proceso = "";
            int cantC = 0;
            int cantP = 0;
            for (Int32 i = 0; i <= lbConceptosIN.Items.Count - 1; i++)
            {
                objESustentos.ConceptoID = lbConceptosIN.Items[i].Value;
                string detaGetServer = Log_Sustentos.GetDetalleConcepto(lbConceptosIN.Items[i].Value).Rows[0][0].ToString();
                if (detaGetServer.Trim() == "")
                {
                    detaGetServer = "n" + lbConceptosIN.Items[i].Text;
                }
                DetalleConcepto += detaGetServer + ",";
                Proceso = Log_Sustentos.GetProcesoConcepto(objESustentos).Rows[0][0].ToString();
                if (Procesos.Count == 0)
                {
                    Procesos.Add(Proceso);
                }
                if (Procesos.Exists(element => element == Proceso).Equals(false))
                {
                    Procesos.Add(Proceso);
                }
                ConceptosID += lbConceptosIN.Items[i].Value + ",";
                ConceptosCamp += lbConceptosIN.Items[i].Text + ",";
                cantC += 1;

            }
            for (Int32 i = 0; i <= lbpersonalIN.Items.Count - 1; i++)
            {
                PersonalCamp += lbpersonalIN.Items[i].Value + ",";
                cantP += 1;
            }
            ConceptosID = ConceptosID.Remove(ConceptosID.Length - 1);
            ConceptosCamp = ConceptosCamp.Remove(ConceptosCamp.Length - 1);
            PersonalCamp = PersonalCamp.Remove(PersonalCamp.Length - 1);
            DetalleConcepto = DetalleConcepto.Remove(DetalleConcepto.Length - 1);
            Proceso = "";
            for (Int32 y = 0; y <= Procesos.Count - 1; y++)
            {
                Proceso += Procesos[y] + ",";
            }
            Proceso = Proceso.Remove(Proceso.Length - 1);
            objESustentos.PlantillaID = hdnPlantilla_Id.Value;
            objESustentos.ProcesoID = Proceso;
            objESustentos.ConceptoID = ConceptosID;
            objESustentos.CamposPerso = PersonalCamp;
            objESustentos.CamposConcep = ConceptosCamp;
            objESustentos.DetalleConceptos = DetalleConcepto;
            objESustentos.Nombre = txtnombre.Text;
            objESustentos.CantC = cantC;
            objESustentos.CantP = cantP;

            string Respuesta = Log_Sustentos.ActualizaPlantilla(objESustentos).Rows[0][0].ToString();
            Utils.fc_DisplayAlert(this, Respuesta);
            btnAdd.Enabled = false;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;
            btnNew.Enabled = true;
            TabContainer1.ActiveTabIndex = 0;
            TabPanel1.Visible = false;
            LlengaGrilla();

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
        protected void lbConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            List<string> ListIN = new List<string> { };
            for (Int32 i = 0; i <= lbConceptosIN.Items.Count - 1; i++)
            {
                ListIN.Add(lbConceptosIN.Items[i].Value);
            }
            if (ListIN.Exists(element => element == lbConceptos.SelectedValue).Equals(false))
            {
                lbConceptosIN.Items.Add(lbConceptos.SelectedItem);
                lbConceptos.Items.Remove(lbConceptos.SelectedItem);
                lbConceptosIN.SelectedIndex = -1;
                lblError.Text = "";
            }
            else
            {
                lblError.Text = "El concepto ya se esta mostrando";
                return;
            }

        }
        protected void lbConceptosIN_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lbConceptos.Items.Add(lbConceptosIN.SelectedItem);
            lbConceptosIN.Items.Remove(lbConceptosIN.SelectedItem);
            lbConceptos.SelectedIndex = -1;
        }
        protected void lbPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lbpersonalIN.Items.Add(lbPersonal.SelectedItem);
            lbPersonal.Items.Remove(lbPersonal.SelectedItem);
            lbpersonalIN.SelectedIndex = -1;
        }
        protected void lbpersonalIN_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lbPersonal.Items.Add(lbpersonalIN.SelectedItem);
            lbpersonalIN.Items.Remove(lbpersonalIN.SelectedItem);
            lbPersonal.SelectedIndex = -1;
        }
        protected void IbtnSelect_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnAdd.Enabled = false;
            btnCancel.Enabled = true;
            btnUpdate.Enabled = true;
            btnNew.Enabled = false;

            string Plantilla_ID;
            ImageButton ibtn = new ImageButton();
            ibtn = (ImageButton)sender;
            Plantilla_ID = ibtn.CommandArgument.ToString();
            hdnPlantilla_Id.Value = Plantilla_ID;
            txtnombre.Text = ibtn.CommandName.ToString();
            TabPanel1.Visible = true;
            TabContainer1.ActiveTabIndex = 1;

            CargaPlatilla(Plantilla_ID);
        }
        void CargaPlatilla(string PlantillaID)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objESustentos = new Ent_Sustentos();
            objESustentos.PlantillaID = PlantillaID;
            DataTable dt = Log_Sustentos.BuscarPlantillas(objESustentos);
            string[] Conceptos = dt.Rows[0][2].ToString().Split(',');
            string[] CamposPersonal = dt.Rows[0][4].ToString().Split(',');
            ListItem item = new ListItem();
            DataTable dtC = new DataTable();
            dtC.Columns.Add("Concepto_Id", typeof(string));
            dtC.Columns.Add("Descripcion", typeof(string));
            for (Int32 i = 0; i <= Conceptos.Length - 1; i++)
            {
                objESustentos.ConceptoID = Conceptos[i].ToString();
                DataTable conDT = Log_Sustentos.BuscarConcepto(objESustentos);
                DataRow dr = dtC.NewRow();
                dr["Concepto_Id"] = conDT.Rows[0][0];
                dr["Descripcion"] = conDT.Rows[0][1];
                dtC.Rows.Add(dr);
            }
            lbConceptosIN.DataTextField = "Descripcion";
            lbConceptosIN.DataValueField = "Concepto_Id";
            lbConceptosIN.DataSource = dtC;
            lbConceptosIN.DataBind();
            lbpersonalIN.Items.Clear();
            for (Int32 i = 0; i <= CamposPersonal.Length - 1; i++)
            {
                lbpersonalIN.Items.Add(CamposPersonal[i].ToString());
                for (Int32 y = 0; y <= lbPersonal.Items.Count - 1; y++)
                {
                    if (lbPersonal.Items[y].Text == CamposPersonal[i].ToString())
                    {
                        lbPersonal.Items.Remove(lbPersonal.Items[y]);
                    }
                }
            }

        }
        protected void cboDistribución_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Ordenamiento_Conceptos(cboColumnaBoleta.SelectedValue, cboProceso.SelectedValue);
        }
        protected void cboColumnaBoleta_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Ordenamiento_Conceptos(cboColumnaBoleta.SelectedValue, cboProceso.SelectedValue);
        }
        protected void cboProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Ordenamiento_Conceptos(cboColumnaBoleta.SelectedValue, cboProceso.SelectedValue);
        }
        void LlengaGrilla()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvPlantillas.DataSource = Log_Sustentos.ListPlantillas();
            grvPlantillas.DataBind();
        }
        private void Lista_Ordenamiento_Conceptos(String columna_Id, String proceso_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string tipo = cboTipoDato.SelectedValue.ToString();
                if (tipo == "05")
                {

                    objEConceptos = new Ent_Conceptos();
                    if (cboDistribución.SelectedValue == "1")
                    { /*Distribucion por Boleta*/
                        objEConceptos.Boleta_Columna = cboColumnaBoleta.SelectedValue;
                    }
                    else
                    { /*Distribucion por Cubo*/
                        objEConceptos.Cubo_Columna = cboColumnaBoleta.SelectedValue;
                    }

                    objEConceptos.Boleta_Proceso = cboProceso.SelectedValue; /*Para guardar el Proceso_Id*/
                    DataTable dtConceptos = new DataTable();
                    dtConceptos = Log_Conceptos.Lista_Ordenamiento_Conceptos(objEConceptos);
                    lbConceptos.DataTextField = "Descripcion";
                    lbConceptos.DataValueField = "Concepto_Id";
                    lbConceptos.DataSource = dtConceptos;
                    lbConceptos.DataBind();
                    dtConceptos.Dispose();
                }
                else
                {
                    DataTable dtConceptos = new DataTable();
                    dtConceptos = Log_Sustentos.GetConceptosByTipoDatoProcesoList(cboTipoDato.SelectedValue, cboProceso.SelectedValue);
                    lbConceptos.DataTextField = "Descripcion";
                    lbConceptos.DataValueField = "Concepto_Id";
                    lbConceptos.DataSource = dtConceptos;
                    lbConceptos.DataBind();
                    dtConceptos.Dispose();
                }
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        private void Conceptos_Mostrar(String columna_Id, String proceso_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEConceptos = new Ent_Conceptos();
                if (cboDistribución.SelectedValue == "1") /*Distribucion por Boleta*/
                    objEConceptos.Boleta_Columna = cboColumnaBoleta.SelectedValue;
                else /*Distribucion por Cubo*/
                    objEConceptos.Cubo_Columna = cboColumnaBoleta.SelectedValue;
                objEConceptos.Boleta_Proceso = cboProceso.SelectedValue; /*Para guardar el Proceso_Id*/
                DataTable dtConceptos = new DataTable();
                dtConceptos = Log_Conceptos.Lista_Ordenamiento_Conceptos(objEConceptos);
                if (dtConceptos.Rows.Count != 0)
                {
                    lbConceptos.AutoPostBack = true;
                }
                else { lbConceptos.AutoPostBack = false; }
                lbConceptosIN.DataTextField = "Descripcion";
                lbConceptosIN.DataValueField = "Concepto_Id";
                lbConceptosIN.DataSource = dtConceptos;
                lbConceptosIN.DataBind();
                dtConceptos.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        void Carga_combo_ColumnasBoleta()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboColumnaBoleta.DataSource = Log_Conceptos.Lista_Columnas_Boleta();
            cboColumnaBoleta.DataTextField = "Descripcion";
            cboColumnaBoleta.DataValueField = "Columna_Id";
            cboColumnaBoleta.DataBind();
        }

        void Carga_combo_Procesos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Procesos objEProcesos = new Ent_Procesos();
            //objEProcesos.Estado_Id = "01"; /*Solo activos*/
            DataTable dtProcesos = Log_Procesos.Lista_Procesos(objEProcesos);
            cboProceso.DataSource = dtProcesos;
            cboProceso.DataTextField = "Proceso";
            cboProceso.DataValueField = "Proceso_Id";
            cboProceso.DataBind();
        }
        void CargarCamposPersonal()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lbPersonal.DataTextField = "name";
            lbPersonal.DataValueField = "name";
            lbPersonal.DataSource = Log_Sustentos.Lista_Campos_Personal();
            lbPersonal.DataBind();

        }


        protected void ibtnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objESustentos = new Ent_Sustentos();
            string Plantilla_ID;
            ImageButton ibtn = new ImageButton();
            ibtn = (ImageButton)sender;
            Plantilla_ID = ibtn.CommandArgument.ToString();
            objESustentos.PlantillaID = Plantilla_ID;
            string Respuesta = Log_Sustentos.EliminaPlantilla(objESustentos).Rows[0][0].ToString();
            Utils.fc_DisplayAlert(this, Respuesta);
            LlengaGrilla();
        }
        protected void lbConceptos_PreRender(object sender, EventArgs e)
        {
            /*lbConceptos.DataTextField = "Descripcion";
            lbConceptos.DataValueField = "Concepto_Id";
            lbConceptos.DataSource = Log_Sustentos.AllConceptos();
            lbConceptos.DataBind();*/
        }
        protected void cboTipoDato_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lista_Ordenamiento_Conceptos(cboColumnaBoleta.SelectedValue, cboProceso.SelectedValue);
        }
    }
}