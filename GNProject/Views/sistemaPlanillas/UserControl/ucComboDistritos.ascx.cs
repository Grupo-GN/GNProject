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
    public partial class ucComboDistritos : System.Web.UI.UserControl
    {
        public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
        public event SelectedIndexChangedDelegate SelectedIndexChanged;

        public String CssClass
        {
            get { return this.cboDistritos.CssClass; }
            set { this.cboDistritos.CssClass = value; }
        }
        public ListItemCollection Items
        {
            get { return this.cboDistritos.Items; }
        }
        public Boolean Enabled
        {
            set
            {
                if (this.cboDistritos != null)
                {
                    this.cboDistritos.Enabled = value;
                }
            }
        }
        public Unit Width
        {
            set { ViewState["_Width"] = value; }
        }

        public String SelectedValue
        {
            get { return this.cboDistritos.SelectedValue; }
            set { this.cboDistritos.SelectedValue = value; }
        }
        public String SelectedText
        {
            get { return this.cboDistritos.SelectedItem.Text; }
        }
        public Int32 SelectedIndex
        {
            get { return this.cboDistritos.SelectedIndex; }
            set { this.cboDistritos.SelectedIndex = value; }
        }
        public Boolean AutoPostBack
        {
            get { return this.cboDistritos.AutoPostBack; }
            set { this.cboDistritos.AutoPostBack = value; }
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["_Width"] != null) this.cboDistritos.Width = (Unit)ViewState["_Width"];
            //if (!Page.IsPostBack)
            //{
            //    cargarCombo("");
            //}
        }



        public void cargarCombo(String departamento_Id, String provincia_Id, String condicion)
        {
            Ent_Distritos objEDistritos = new Ent_Distritos();
            objEDistritos.Sub_Filtro = departamento_Id + provincia_Id;
            DataTable dtDistritos = new DataTable();
            dtDistritos = Log_Distritos.Lista_Distritos(objEDistritos);
            cboDistritos.DataSource = dtDistritos;
            cboDistritos.DataTextField = "Descripcion";
            cboDistritos.DataValueField = "Codigo";
            cboDistritos.DataBind();

            //Setea el primer valor, si es uno.
            if (dtDistritos != null)
            {
                if (dtDistritos.Rows.Count == 1)
                {
                    this.cboDistritos.SelectedValue = dtDistritos.Rows[0]["Codigo"].ToString();
                }
            }

            if (!condicion.Equals(String.Empty))
            {
                if (condicion.Equals("Todos"))
                {
                    this.cboDistritos.Items.Insert(0, new ListItem("--Todos--", String.Empty));
                }
                else
                {
                    if (condicion.Equals("Seleccione"))
                    {
                        this.cboDistritos.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    }
                }
            }

        }

        protected void cboDistritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }
    }
}