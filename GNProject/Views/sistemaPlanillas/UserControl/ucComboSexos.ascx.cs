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
    public partial class ucComboSexos : System.Web.UI.UserControl
    {
        public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
        public event SelectedIndexChangedDelegate SelectedIndexChanged;

        public String CssClass
        {
            get { return this.cboSexos.CssClass; }
            set { this.cboSexos.CssClass = value; }
        }
        public ListItemCollection Items
        {
            get { return this.cboSexos.Items; }
        }
        public Boolean Enabled
        {
            set
            {
                if (this.cboSexos != null)
                {
                    this.cboSexos.Enabled = value;
                }
            }
        }
        public Unit Width
        {
            set { ViewState["_Width"] = value; }
        }

        public String SelectedValue
        {
            get { return this.cboSexos.SelectedValue; }
            set { this.cboSexos.SelectedValue = value; }
        }
        public String SelectedText
        {
            get { return this.cboSexos.SelectedItem.Text; }
        }
        public Int32 SelectedIndex
        {
            get { return this.cboSexos.SelectedIndex; }
            set { this.cboSexos.SelectedIndex = value; }
        }
        public Boolean AutoPostBack
        {
            get { return this.cboSexos.AutoPostBack; }
            set { this.cboSexos.AutoPostBack = value; }
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["_Width"] != null) this.cboSexos.Width = (Unit)ViewState["_Width"];
            //if (!Page.IsPostBack)
            //{
            //    cargarCombo("");
            //}
        }



        public void cargarCombo(String condicion)
        {
            DataTable dtSexos = new DataTable();
            dtSexos = Log_Sexos.ListaSexos();
            cboSexos.DataSource = dtSexos;
            cboSexos.DataTextField = "Descripcion";
            cboSexos.DataValueField = "Sexo_Id";
            cboSexos.DataBind();

            //Setea el primer valor, si es uno.
            if (dtSexos != null)
            {
                if (dtSexos.Rows.Count == 1)
                {
                    this.cboSexos.SelectedValue = dtSexos.Rows[0]["Sexo_Id"].ToString();
                }
            }

            if (!condicion.Equals(String.Empty))
            {
                if (condicion.Equals("Todos"))
                {
                    this.cboSexos.Items.Insert(0, new ListItem("--Todos--", String.Empty));
                }
                else
                {
                    if (condicion.Equals("Seleccione"))
                    {
                        this.cboSexos.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    }
                }
            }

        }

        protected void cboSexos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }
    }
}