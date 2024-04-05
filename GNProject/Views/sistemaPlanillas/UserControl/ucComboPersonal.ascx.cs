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
    public partial class ucComboPersonal : System.Web.UI.UserControl
    {
        public delegate void SelectedIndexChangedDelegate(object sender, EventArgs e);
        public event SelectedIndexChangedDelegate SelectedIndexChanged;

        public String CssClass
        {
            get { return this.cboPersonal.CssClass; }
            set { this.cboPersonal.CssClass = value; }
        }
        public ListItemCollection Items
        {
            get { return this.cboPersonal.Items; }
        }
        public Boolean Enabled
        {
            set
            {
                if (this.cboPersonal != null)
                {
                    this.cboPersonal.Enabled = value;
                }
            }
        }
        public Unit Width
        {
            set { ViewState["_Width"] = value; }
        }

        public String SelectedValue
        {
            get { return this.cboPersonal.SelectedValue; }
            set { this.cboPersonal.SelectedValue = value; }
        }
        public String SelectedText
        {
            get { return this.cboPersonal.SelectedItem.Text; }
        }
        public Int32 SelectedIndex
        {
            get { return this.cboPersonal.SelectedIndex; }
            set { this.cboPersonal.SelectedIndex = value; }
        }
        public Boolean AutoPostBack
        {
            get { return this.cboPersonal.AutoPostBack; }
            set { this.cboPersonal.AutoPostBack = value; }
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["_Width"] != null) this.cboPersonal.Width = (Unit)ViewState["_Width"];
            //if (!Page.IsPostBack)
            //{
            //    cargarCombo("");
            //}
        }



        public void cargarCombo(String Periodo_Id, String condicion)
        {
            Ent_Personal objEPersonal = new Ent_Personal();
            if (!String.IsNullOrEmpty(Periodo_Id.Trim()))
                objEPersonal._Periodo_Id = Periodo_Id;

            DataTable dtPersonal = new DataTable();
            dtPersonal = Log_Personal.Lista_Personal(objEPersonal);
            cboPersonal.DataSource = dtPersonal;
            cboPersonal.DataTextField = "Nombre_Completo";
            cboPersonal.DataValueField = "Personal_Id";
            cboPersonal.DataBind();

            //Setea el primer valor, si es uno.
            if (dtPersonal != null)
            {
                if (dtPersonal.Rows.Count == 1)
                {
                    this.cboPersonal.SelectedValue = dtPersonal.Rows[0]["Personal_Id"].ToString();
                }
            }

            if (!condicion.Equals(String.Empty))
            {
                if (condicion.Equals("Todos"))
                {
                    this.cboPersonal.Items.Insert(0, new ListItem("--Todos--", String.Empty));
                }
                else
                {
                    if (condicion.Equals("Seleccione"))
                    {
                        this.cboPersonal.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    }
                }
            }

        }

        protected void cboPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }
    }
}