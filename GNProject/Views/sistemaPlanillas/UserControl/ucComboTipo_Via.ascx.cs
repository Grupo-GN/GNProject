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
    public partial class ucComboTipo_Via : System.Web.UI.UserControl
    {
        public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
        public event SelectedIndexChangedDelegate SelectedIndexChanged;

        public String CssClass
        {
            get { return this.cboTipo_Via.CssClass; }
            set { this.cboTipo_Via.CssClass = value; }
        }
        public ListItemCollection Items
        {
            get { return this.cboTipo_Via.Items; }
        }
        public Boolean Enabled
        {
            set
            {
                if (this.cboTipo_Via != null)
                {
                    this.cboTipo_Via.Enabled = value;
                }
            }
        }
        public Unit Width
        {
            set { ViewState["_Width"] = value; }
        }

        public String SelectedValue
        {
            get { return this.cboTipo_Via.SelectedValue; }
            set { this.cboTipo_Via.SelectedValue = value; }
        }
        public String SelectedText
        {
            get { return this.cboTipo_Via.SelectedItem.Text; }
        }
        public Int32 SelectedIndex
        {
            get { return this.cboTipo_Via.SelectedIndex; }
            set { this.cboTipo_Via.SelectedIndex = value; }
        }
        public Boolean AutoPostBack
        {
            get { return this.cboTipo_Via.AutoPostBack; }
            set { this.cboTipo_Via.AutoPostBack = value; }
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["_Width"] != null) this.cboTipo_Via.Width = (Unit)ViewState["_Width"];
            //if (!Page.IsPostBack)
            //{
            //    cargarCombo("");
            //}
        }



        public void cargarCombo(String condicion)
        {
            Ent_Tipo_Via objETipoVia = new Ent_Tipo_Via();
            DataTable dtTipo_Via = new DataTable();
            dtTipo_Via = Log_Tipo_Via.Lista_Tipo_Via(objETipoVia);
            cboTipo_Via.DataSource = dtTipo_Via;
            cboTipo_Via.DataTextField = "Descripcion";
            cboTipo_Via.DataValueField = "Tipo_Via_Id";
            cboTipo_Via.DataBind();

            //Setea el primer valor, si es uno.
            if (dtTipo_Via != null)
            {
                if (dtTipo_Via.Rows.Count == 1)
                {
                    this.cboTipo_Via.SelectedValue = dtTipo_Via.Rows[0]["Tipo_Via_Id"].ToString();
                }
            }

            if (!condicion.Equals(String.Empty))
            {
                if (condicion.Equals("Todos"))
                {
                    this.cboTipo_Via.Items.Insert(0, new ListItem("--Todos--", String.Empty));
                }
                else
                {
                    if (condicion.Equals("Seleccione"))
                    {
                        this.cboTipo_Via.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    }
                }
            }

        }

        protected void cboTipo_Via_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }
    }
}