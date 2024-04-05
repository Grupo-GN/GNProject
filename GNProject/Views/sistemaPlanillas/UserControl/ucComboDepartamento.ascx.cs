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
    public partial class ucComboDepartamento : System.Web.UI.UserControl
    {
        public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
        public event SelectedIndexChangedDelegate SelectedIndexChanged;

        public String CssClass
        {
            get { return this.cboDepartamentos.CssClass; }
            set { this.cboDepartamentos.CssClass = value; }
        }
        public ListItemCollection Items
        {
            get { return this.cboDepartamentos.Items; }
        }
        public Boolean Enabled
        {
            set
            {
                if (this.cboDepartamentos != null)
                {
                    this.cboDepartamentos.Enabled = value;
                }
            }
        }
        public Unit Width
        {
            set { ViewState["_Width"] = value; }
        }

        public String SelectedValue
        {
            get { return this.cboDepartamentos.SelectedValue; }
            set { this.cboDepartamentos.SelectedValue = value; }
        }
        public String SelectedText
        {
            get { return this.cboDepartamentos.SelectedItem.Text; }
        }
        public Int32 SelectedIndex
        {
            get { return this.cboDepartamentos.SelectedIndex; }
            set { this.cboDepartamentos.SelectedIndex = value; }
        }
        public Boolean AutoPostBack
        {
            get { return this.cboDepartamentos.AutoPostBack; }
            set { this.cboDepartamentos.AutoPostBack = value; }
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["_Width"] != null) this.cboDepartamentos.Width = (Unit)ViewState["_Width"];
            //if (!Page.IsPostBack)
            //{
            //    cargarCombo("");
            //}
        }



        public void cargarCombo(String condicion)
        {
            DataTable dtDepartamentos = new DataTable();
            dtDepartamentos = Log_Departamentos.Lista_Departamentos();
            cboDepartamentos.DataSource = dtDepartamentos;
            cboDepartamentos.DataTextField = "Descripcion";
            cboDepartamentos.DataValueField = "Codigo";
            cboDepartamentos.DataBind();

            //Setea el primer valor, si es uno.
            if (dtDepartamentos != null)
            {
                if (dtDepartamentos.Rows.Count == 1)
                {
                    this.cboDepartamentos.SelectedValue = dtDepartamentos.Rows[0]["Codigo"].ToString();
                }
            }

            if (!condicion.Equals(String.Empty))
            {
                if (condicion.Equals("Todos"))
                {
                    this.cboDepartamentos.Items.Insert(0, new ListItem("--Todos--", String.Empty));
                }
                else
                {
                    if (condicion.Equals("Seleccione"))
                    {
                        this.cboDepartamentos.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    }
                }
            }

        }

        protected void cboDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }
    }
}