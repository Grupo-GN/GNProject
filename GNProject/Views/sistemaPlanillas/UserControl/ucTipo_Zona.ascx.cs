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
    public partial class ucTipo_Zona : System.Web.UI.UserControl
    {
        public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
        public event SelectedIndexChangedDelegate SelectedIndexChanged;

        public String CssClass
        {
            get { return this.cboTipo_Zona.CssClass; }
            set { this.cboTipo_Zona.CssClass = value; }
        }
        public ListItemCollection Items
        {
            get { return this.cboTipo_Zona.Items; }
        }
        public Boolean Enabled
        {
            set
            {
                if (this.cboTipo_Zona != null)
                {
                    this.cboTipo_Zona.Enabled = value;
                }
            }
        }
        public Unit Width
        {
            set { ViewState["_Width"] = value; }
        }

        public String SelectedValue
        {
            get { return this.cboTipo_Zona.SelectedValue; }
            set { this.cboTipo_Zona.SelectedValue = value; }
        }
        public String SelectedText
        {
            get { return this.cboTipo_Zona.SelectedItem.Text; }
        }
        public Int32 SelectedIndex
        {
            get { return this.cboTipo_Zona.SelectedIndex; }
            set { this.cboTipo_Zona.SelectedIndex = value; }
        }
        public Boolean AutoPostBack
        {
            get { return this.cboTipo_Zona.AutoPostBack; }
            set { this.cboTipo_Zona.AutoPostBack = value; }
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["_Width"] != null) this.cboTipo_Zona.Width = (Unit)ViewState["_Width"];
            //if (!Page.IsPostBack)
            //{
            //    cargarCombo("");
            //}
        }



        public void cargarCombo(String condicion)
        {
            Ent_Tipo_Zona objETipoVia = new Ent_Tipo_Zona();
            DataTable dtTipo_Zona = new DataTable();
            dtTipo_Zona = Log_Tipo_Zona.Lista_Tipo_Zona(objETipoVia);
            cboTipo_Zona.DataSource = dtTipo_Zona;
            cboTipo_Zona.DataTextField = "Descripcion";
            cboTipo_Zona.DataValueField = "Tipo_Zona_Id";
            cboTipo_Zona.DataBind();

            //Setea el primer valor, si es uno.
            if (dtTipo_Zona != null)
            {
                if (dtTipo_Zona.Rows.Count == 1)
                {
                    this.cboTipo_Zona.SelectedValue = dtTipo_Zona.Rows[0]["Tipo_Zona_Id"].ToString();
                }
            }

            if (!condicion.Equals(String.Empty))
            {
                if (condicion.Equals("Todos"))
                {
                    this.cboTipo_Zona.Items.Insert(0, new ListItem("--Todos--", String.Empty));
                }
                else
                {
                    if (condicion.Equals("Seleccione"))
                    {
                        this.cboTipo_Zona.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    }
                }
            }

        }

        protected void cboTipo_Zona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }
    }
}