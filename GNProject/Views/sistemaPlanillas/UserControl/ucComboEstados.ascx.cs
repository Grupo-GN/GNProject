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
    public partial class ucComboEstados : System.Web.UI.UserControl
    {
        public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
        public event SelectedIndexChangedDelegate SelectedIndexChanged;

        public String CssClass
        {
            get { return this.cboEstados.CssClass; }
            set { this.cboEstados.CssClass = value; }
        }
        public ListItemCollection Items
        {
            get { return this.cboEstados.Items; }
        }
        public Boolean Enabled
        {
            set
            {
                if (this.cboEstados != null)
                {
                    this.cboEstados.Enabled = value;
                }
            }
        }
        public Unit Width
        {
            set { ViewState["_Width"] = value; }
        }

        public String SelectedValue
        {
            get { return this.cboEstados.SelectedValue; }
            set { this.cboEstados.SelectedValue = value; }
        }
        public String SelectedText
        {
            get { return this.cboEstados.SelectedItem.Text; }
        }
        public Int32 SelectedIndex
        {
            get { return this.cboEstados.SelectedIndex; }
            set { this.cboEstados.SelectedIndex = value; }
        }
        public Boolean AutoPostBack
        {
            get { return this.cboEstados.AutoPostBack; }
            set { this.cboEstados.AutoPostBack = value; }
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["_Width"] != null) this.cboEstados.Width = (Unit)ViewState["_Width"];
            //if (!Page.IsPostBack)
            //{
            //    cargarCombo("");
            //}
        }



        public void cargarCombo(String condicion)
        {
            DataTable dtEstados = new DataTable();
            dtEstados = Log_General.Lista_Estados();
            cboEstados.DataSource = dtEstados;
            cboEstados.DataTextField = "Descripcion";
            cboEstados.DataValueField = "Codigo";
            cboEstados.DataBind();

            //Setea el primer valor, si es uno.
            if (dtEstados != null)
            {
                if (dtEstados.Rows.Count == 1)
                {
                    this.cboEstados.SelectedValue = dtEstados.Rows[0]["Codigo"].ToString();
                }
            }

            if (!condicion.Equals(String.Empty))
            {
                if (condicion.Equals("Todos"))
                {
                    this.cboEstados.Items.Insert(0, new ListItem("--Todos--", String.Empty));
                }
                else
                {
                    if (condicion.Equals("Seleccione"))
                    {
                        this.cboEstados.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    }
                }
            }

        }

        protected void cboEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }
    }
}