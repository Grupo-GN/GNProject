using CAPA_ENTIDAD;
using CAPA_LOGICO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.UserControl
{
    public partial class ucComboTipoDocumento : System.Web.UI.UserControl
    {
        public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
        public event SelectedIndexChangedDelegate SelectedIndexChanged;

        public String CssClass
        {
            get { return this.cboTipoDocumento.CssClass; }
            set { this.cboTipoDocumento.CssClass = value; }
        }
        public ListItemCollection Items
        {
            get { return this.cboTipoDocumento.Items; }
        }
        public Boolean Enabled
        {
            set
            {
                if (this.cboTipoDocumento != null)
                {
                    this.cboTipoDocumento.Enabled = value;
                }
            }
        }
        public Unit Width
        {
            set { ViewState["_Width"] = value; }
        }

        public String SelectedValue
        {
            get { return this.cboTipoDocumento.SelectedValue; }
            set { this.cboTipoDocumento.SelectedValue = value; }
        }
        public String SelectedText
        {
            get { return this.cboTipoDocumento.SelectedItem.Text; }
        }
        public Int32 SelectedIndex
        {
            get { return this.cboTipoDocumento.SelectedIndex; }
            set { this.cboTipoDocumento.SelectedIndex = value; }
        }
        public Boolean AutoPostBack
        {
            get { return this.cboTipoDocumento.AutoPostBack; }
            set { this.cboTipoDocumento.AutoPostBack = value; }
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["_Width"] != null) this.cboTipoDocumento.Width = (Unit)ViewState["_Width"];
            //if (!Page.IsPostBack)
            //{
            //    cargarCombo("");
            //}
        }



        public void cargarCombo(String condicion)
        {
            Ent_TDoc_Identidad objETDoc_Identidad = new Ent_TDoc_Identidad();
            //////objETDoc_Identidad.Tipo_Doc_Id =
            DataTable dtTipoDoc = new DataTable();
            dtTipoDoc = Log_TDoc_Identidad.Lista_TDoc_Identidad(objETDoc_Identidad);
            cboTipoDocumento.DataSource = dtTipoDoc;
            cboTipoDocumento.DataTextField = "Descripcion";
            cboTipoDocumento.DataValueField = "Tipo_Doc_Id";
            cboTipoDocumento.DataBind();

            //Setea el primer valor, si es uno.
            if (dtTipoDoc != null)
            {
                if (dtTipoDoc.Rows.Count == 1)
                {
                    this.cboTipoDocumento.SelectedValue = dtTipoDoc.Rows[0]["Tipo_Doc_Id"].ToString();
                }
            }

            if (!condicion.Equals(String.Empty))
            {
                if (condicion.Equals("Todos"))
                {
                    this.cboTipoDocumento.Items.Insert(0, new ListItem("--Todos--", String.Empty));
                }
                else
                {
                    if (condicion.Equals("Seleccione"))
                    {
                        this.cboTipoDocumento.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    }
                }
            }

        }

        protected void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }
    }
}