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
    public partial class ucComboArea : System.Web.UI.UserControl
    {
        public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
        public event SelectedIndexChangedDelegate SelectedIndexChanged;

        public String CssClass
        {
            get { return this.cboArea.CssClass; }
            set { this.cboArea.CssClass = value; }
        }
        public ListItemCollection Items
        {
            get { return this.cboArea.Items; }
        }
        public Boolean Enabled
        {
            set
            {
                if (this.cboArea != null)
                {
                    this.cboArea.Enabled = value;
                }
            }
        }
        public Unit Width
        {
            set { ViewState["_Width"] = value; }
        }

        public String SelectedValue
        {
            get { return this.cboArea.SelectedValue; }
            set { this.cboArea.SelectedValue = value; }
        }
        public String SelectedText
        {
            get { return this.cboArea.SelectedItem.Text; }
        }
        public Int32 SelectedIndex
        {
            get { return this.cboArea.SelectedIndex; }
            set { this.cboArea.SelectedIndex = value; }
        }
        public Boolean AutoPostBack
        {
            get { return this.cboArea.AutoPostBack; }
            set { this.cboArea.AutoPostBack = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["_Width"] != null) this.cboArea.Width = (Unit)ViewState["_Width"];
            //if (!Page.IsPostBack)
            //{
            //    cargarCombo("");
            //}
        }

        public void cargarCombo(String Area_Id, String condicion)
        {
            DataTable dtArea = new DataTable();
            Ent_RH_Area objEArea = new Ent_RH_Area();
            if (Area_Id.Trim() != string.Empty)
            {
                objEArea.Area_Id = Area_Id;
            }

            dtArea = Log_RH_Area.Lista_RH_Area(objEArea);
            cboArea.DataSource = dtArea;
            cboArea.DataTextField = "Descripcion";
            cboArea.DataValueField = "Area_Id";
            cboArea.DataBind();

            //Setea el primer valor, si es uno.
            if (dtArea != null)
            {
                if (dtArea.Rows.Count == 1)
                {
                    this.cboArea.SelectedValue = dtArea.Rows[0]["Area_Id"].ToString();
                }
            }

            if (!condicion.Equals(String.Empty))
            {
                if (condicion.Equals("Todos"))
                {
                    this.cboArea.Items.Insert(0, new ListItem("--Todos--", String.Empty));
                }
                else
                {
                    if (condicion.Equals("Seleccione"))
                    {
                        this.cboArea.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    }
                }
            }
        }

        protected void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }
    }
}