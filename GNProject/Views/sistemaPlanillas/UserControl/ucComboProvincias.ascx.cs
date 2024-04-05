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
    public partial class ucComboProvincias : System.Web.UI.UserControl
    {
        public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
        public event SelectedIndexChangedDelegate SelectedIndexChanged;

        public String CssClass
        {
            get { return this.cboProvincias.CssClass; }
            set { this.cboProvincias.CssClass = value; }
        }
        public ListItemCollection Items
        {
            get { return this.cboProvincias.Items; }
        }
        public Boolean Enabled
        {
            set
            {
                if (this.cboProvincias != null)
                {
                    this.cboProvincias.Enabled = value;
                }
            }
        }
        public Unit Width
        {
            set { ViewState["_Width"] = value; }
        }

        public String SelectedValue
        {
            get { return this.cboProvincias.SelectedValue; }
            set { this.cboProvincias.SelectedValue = value; }
        }
        public String SelectedText
        {
            get { return this.cboProvincias.SelectedItem.Text; }
        }
        public Int32 SelectedIndex
        {
            get { return this.cboProvincias.SelectedIndex; }
            set { this.cboProvincias.SelectedIndex = value; }
        }
        public Boolean AutoPostBack
        {
            get { return this.cboProvincias.AutoPostBack; }
            set { this.cboProvincias.AutoPostBack = value; }
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["_Width"] != null) this.cboProvincias.Width = (Unit)ViewState["_Width"];
            //if (!Page.IsPostBack)
            //{
            //    cargarCombo("");
            //}
        }



        public void cargarCombo(String departamento_Id, String condicion)
        {
            Ent_Provincias objEProvincias = new Ent_Provincias();
            objEProvincias.Sub_Filtro = departamento_Id;
            DataTable dtProvincias = new DataTable();
            dtProvincias = Log_Provincias.Lista_Provincias(objEProvincias);
            cboProvincias.DataSource = dtProvincias;
            cboProvincias.DataTextField = "Descripcion";
            cboProvincias.DataValueField = "Codigo";
            cboProvincias.DataBind();

            //Setea el primer valor, si es uno.
            if (dtProvincias != null)
            {
                if (dtProvincias.Rows.Count == 1)
                {
                    this.cboProvincias.SelectedValue = dtProvincias.Rows[0]["Codigo"].ToString();
                }
            }

            if (!condicion.Equals(String.Empty))
            {
                if (condicion.Equals("Todos"))
                {
                    this.cboProvincias.Items.Insert(0, new ListItem("--Todos--", String.Empty));
                }
                else
                {
                    if (condicion.Equals("Seleccione"))
                    {
                        this.cboProvincias.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    }
                }
            }

        }

        protected void cboProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }
    }
}