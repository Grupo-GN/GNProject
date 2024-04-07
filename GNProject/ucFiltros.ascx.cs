using CAPA_ENTIDAD;
using CAPA_LOGICO;
using GNProject.Views.sistemaPlanillas.code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject
{
    public partial class ucFiltros : System.Web.UI.UserControl
    {
        public event EventHandler PostBackPeriodoChangedEventHandler; //@001 I/F

        public void fc_carga_Filtros()
        {
            if (cboEmpresa.Items.Count <= 0)
                LlenarEmpresa();
            if (cboPlanilla.Items.Count <= 0)
                llenarPlanillas(cboEmpresa.SelectedValue);
            if (cboEjercicio.Items.Count <= 0)
                LlenarAnio();

            //Para los Meses
            if (Session["Planilla_Id"] != null && cboPlanilla.Items.Count > 0)
            {
                string Planilla_Id;
                Planilla_Id = Session["Planilla_Id"].ToString();
                cboPlanilla.SelectedValue = Planilla_Id;
                if (Session["Ejercicio_Id"] != null && cboEjercicio.Items.Count > 0)
                {
                    string Ejercicio_Id;
                    Ejercicio_Id = Session["Ejercicio_Id"].ToString();
                    cboEjercicio.SelectedValue = Ejercicio_Id;
                    LlenarMes(cboEmpresa.SelectedValue, cboEjercicio.SelectedValue, cboPlanilla.SelectedValue);
                    if (Session["Mes_Id"] != null && cboMes.Items.Count > 0)
                    {
                        string Mes_Id;
                        Mes_Id = Session["Mes_Id"].ToString();
                        Boolean rpta = false;
                        foreach (ListItem list in cboMes.Items)
                        {
                            if (Mes_Id == list.Value.ToString())
                            {
                                rpta = true;
                                break; //salir del for
                            }
                        }
                        if (rpta == true)
                        {
                            cboMes.SelectedValue = Mes_Id;
                        }
                        else
                        {
                            //////cboMes.SelectedIndex = 0;
                        }
                    }
                }
            }
            else
            {
                if (cboPeriodo.Items.Count <= 0 && cboEmpresa.Items.Count > 0 && cboPlanilla.Items.Count > 0 && cboEjercicio.Items.Count > 0)
                    LlenarMes(cboEmpresa.SelectedValue, cboEjercicio.SelectedValue, cboPlanilla.SelectedValue);
            }

            //Para los Periodos
            if (Session["Planilla_Id"] != null && cboPlanilla.Items.Count > 0)
            {
                string Planilla_Id;
                Planilla_Id = Session["Planilla_Id"].ToString();
                cboPlanilla.SelectedValue = Planilla_Id;
                if (Session["Ejercicio_Id"] != null && cboEjercicio.Items.Count > 0)
                {
                    string Ejercicio_Id;
                    Ejercicio_Id = Session["Ejercicio_Id"].ToString();
                    cboEjercicio.SelectedValue = Ejercicio_Id;
                    if (Session["Mes_Id"] != null && cboMes.Items.Count > 0)
                    {
                        string Mes_Id;
                        Mes_Id = Session["Mes_Id"].ToString();
                        cboMes.SelectedValue = Mes_Id;

                        LlenarPeriodo(cboEmpresa.SelectedValue, cboEjercicio.SelectedValue, cboPlanilla.SelectedValue, cboMes.SelectedValue);
                        if (Session["Periodo_Id"] != null && cboPeriodo.Items.Count > 0)
                        {
                            string Periodo_Id;
                            Periodo_Id = Session["Periodo_Id"].ToString();
                            Boolean rpta = false;
                            foreach (ListItem list in cboPeriodo.Items)
                            {
                                if (Periodo_Id == list.Value.ToString())
                                {
                                    rpta = true;
                                    break; //salir del for
                                }
                            }
                            if (rpta == true)
                            {
                                cboPeriodo.SelectedValue = Periodo_Id;
                            }
                            else
                            {
                                //////cboPeriodo.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
            else
            {
                if (cboPeriodo.Items.Count <= 0 && cboEmpresa.Items.Count > 0 && cboPlanilla.Items.Count > 0 && cboEjercicio.Items.Count > 0
                    && cboMes.Items.Count > 0)
                    LlenarPeriodo(cboEmpresa.SelectedValue, cboEjercicio.SelectedValue, cboPlanilla.SelectedValue, cboMes.SelectedValue);
            }
            Session["EmpresaPlanilla"] = cboEmpresa.SelectedValue;
            Session["PeriodoPlanilla"] = cboPeriodo.SelectedValue;
            Session["planillaPlanilla"] = cboPlanilla.SelectedValue;
            Session["anioPlanilla"] = cboEjercicio.SelectedValue;
            Session["mesPlanilla"] = cboMes.SelectedValue;
            var a = (string)Session["EmpresaPlanilla"];
            var b = (string)Session["PeriodoPlanilla"];
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //  fc_carga_Filtros();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (cboEmpresa.Items.Count > 0 && cboPlanilla.Items.Count > 0 && cboEjercicio.Items.Count > 0
                    && cboMes.Items.Count > 0 && cboPeriodo.Items.Count > 0)
                    return;

                if (cboEmpresa.Items.Count <= 0)
                    LlenarEmpresa();
                if (cboPlanilla.Items.Count <= 0)
                    llenarPlanillas(cboEmpresa.SelectedValue);
                if (cboEjercicio.Items.Count <= 0)
                    LlenarAnio();

                
                //Para los Meses
                if (Session["Planilla_Id"] != null && cboPlanilla.Items.Count > 0)
                {
                    string Planilla_Id;
                    Planilla_Id = Session["Planilla_Id"].ToString();
                    cboPlanilla.SelectedValue = Planilla_Id;
                    if (Session["Ejercicio_Id"] != null && cboEjercicio.Items.Count > 0)
                    {
                        string Ejercicio_Id;
                        Ejercicio_Id = Session["Ejercicio_Id"].ToString();
                        cboEjercicio.SelectedValue = Ejercicio_Id;
                        LlenarMes(cboEmpresa.SelectedValue, cboEjercicio.SelectedValue, cboPlanilla.SelectedValue);
                        if (Session["Mes_Id"] != null && cboMes.Items.Count > 0)
                        {
                            string Mes_Id;
                            Mes_Id = Session["Mes_Id"].ToString();
                            Boolean rpta = false;
                            foreach (ListItem list in cboMes.Items)
                            {
                                if (Mes_Id == list.Value.ToString())
                                {
                                    rpta = true;
                                    break; //salir del for
                                }
                            }
                            if (rpta == true)
                            {
                                cboMes.SelectedValue = Mes_Id;
                            }
                            else
                            {
                                //////cboMes.SelectedIndex = 0;
                            }
                        }
                    }
                    
                }
                else
                {
                    if (cboPeriodo.Items.Count <= 0 && cboEmpresa.Items.Count > 0 && cboPlanilla.Items.Count > 0 && cboEjercicio.Items.Count > 0)
                        LlenarMes(cboEmpresa.SelectedValue, cboEjercicio.SelectedValue, cboPlanilla.SelectedValue);
                }

                //Para los Periodos
                if (Session["Planilla_Id"] != null && cboPlanilla.Items.Count > 0)
                {
                    string Planilla_Id;
                    Planilla_Id = Session["Planilla_Id"].ToString();
                    cboPlanilla.SelectedValue = Planilla_Id;
                    if (Session["Ejercicio_Id"] != null && cboEjercicio.Items.Count > 0)
                    {
                        string Ejercicio_Id;
                        Ejercicio_Id = Session["Ejercicio_Id"].ToString();
                        cboEjercicio.SelectedValue = Ejercicio_Id;
                        if (Session["Mes_Id"] != null && cboMes.Items.Count > 0)
                        {
                            string Mes_Id;
                            Mes_Id = Session["Mes_Id"].ToString();
                            cboMes.SelectedValue = Mes_Id;

                            LlenarPeriodo(cboEmpresa.SelectedValue, cboEjercicio.SelectedValue, cboPlanilla.SelectedValue, cboMes.SelectedValue);
                            if (Session["Periodo_Id"] != null && cboPeriodo.Items.Count > 0)
                            {
                                string Periodo_Id;
                                Periodo_Id = Session["Periodo_Id"].ToString();
                                Boolean rpta = false;
                                foreach (ListItem list in cboPeriodo.Items)
                                {
                                    if (Periodo_Id == list.Value.ToString())
                                    {
                                        rpta = true;
                                        break; //salir del for
                                    }
                                }
                                if (rpta == true)
                                {
                                    cboPeriodo.SelectedValue = Periodo_Id;
                                }
                                else
                                {
                                    //////cboPeriodo.SelectedIndex = 0;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (cboPeriodo.Items.Count <= 0 && cboEmpresa.Items.Count > 0 && cboPlanilla.Items.Count > 0 && cboEjercicio.Items.Count > 0
                        && cboMes.Items.Count > 0)
                        LlenarPeriodo(cboEmpresa.SelectedValue, cboEjercicio.SelectedValue, cboPlanilla.SelectedValue, cboMes.SelectedValue);
                }
                
            }
        }

        protected void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarPlanillas(cboEmpresa.SelectedValue);
            Session["Compania_Id"] = cboEmpresa.SelectedValue;
            Session["Planilla_Id"] = cboPlanilla.SelectedValue;
            Session["Ejercicio_Id"] = cboEjercicio.SelectedValue;
            Session["Mes_Id"] = cboMes.SelectedValue;
            if (cboPlanilla.SelectedValue != "-Seleccione-")
                Session["Periodo_Id"] = cboPeriodo.SelectedValue;
            else
                Session["Periodo_Id"] = null;

            callEvent_ChangedPeriodo(); //@001 I/F
        }

        protected void cboPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlMantenimientos.nPosback = 0;
            LlenarMes(cboEmpresa.SelectedValue, cboEjercicio.SelectedValue, cboPlanilla.SelectedValue);
            LlenarPeriodo(cboEmpresa.SelectedValue, cboEjercicio.SelectedValue, cboPlanilla.SelectedValue, cboMes.SelectedValue);
            Session["Compania_Id"] = cboEmpresa.SelectedValue;
            Session["Planilla_Id"] = cboPlanilla.SelectedValue;
            Session["Ejercicio_Id"] = cboEjercicio.SelectedValue;
            Session["Mes_Id"] = cboMes.SelectedValue;
            if (cboPlanilla.SelectedValue != "-Seleccione-")
                Session["Periodo_Id"] = cboPeriodo.SelectedValue;
            else
                Session["Periodo_Id"] = null;

            callEvent_ChangedPeriodo(); //@001 I/F
        }

        protected void cboEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlMantenimientos.nPosback = 0;
            LlenarMes(cboEmpresa.SelectedValue, cboEjercicio.SelectedValue, cboPlanilla.SelectedValue);
            LlenarPeriodo(cboEmpresa.SelectedValue, cboEjercicio.SelectedValue, cboPlanilla.SelectedValue, cboMes.SelectedValue);
            Session["Compania_Id"] = cboEmpresa.SelectedValue;
            Session["Planilla_Id"] = cboPlanilla.SelectedValue;
            Session["Ejercicio_Id"] = cboEjercicio.SelectedValue;
            Session["Mes_Id"] = cboMes.SelectedValue;
            if (cboPlanilla.SelectedValue != "-Seleccione-")
                Session["Periodo_Id"] = cboPeriodo.SelectedValue;
            else
                Session["Periodo_Id"] = null;

            callEvent_ChangedPeriodo(); //@001 I/F
        }

        private void LlenarEmpresa()
        {
            Ent_Compania objCompania = new Ent_Compania();
            cboEmpresa.DataSource = Log_Compania.Lista_Compania(objCompania);
            cboEmpresa.DataTextField = "Descripcion";
            cboEmpresa.DataValueField = "Compania_Id";
            cboEmpresa.DataBind();
            /*Se recorre los Items del combo en forma descendente para que no afecte los Index*/
            for (int i = cboEmpresa.Items.Count - 1; i >= 0; i--)
            {
                if (cboEmpresa.Items[i].Value.ToString() == "02") /*Se quita el registro Sin Empresa (Nombre Vacío)*/
                    cboEmpresa.Items.RemoveAt(i);
            }
        }

        private void llenarPlanillas(String Compania_Id)
        {
            Ent_Planilla objEPlanilla = new Ent_Planilla();
            objEPlanilla.Compania_Id = Compania_Id;
            objEPlanilla.Estado_Id = "01"; /*Planillas Activas*/
            cboPlanilla.DataSource = Log_Planilla.Lista_Planilla(objEPlanilla);
            cboPlanilla.DataTextField = "Descripcion";
            cboPlanilla.DataValueField = "Planilla_Id";
            cboPlanilla.DataBind();
            //////cboPlanilla.Items.Insert(0, "-Seleccione-");
        }

        private void LlenarAnio()
        {
            Ent_Ejercicio objEEjercicio = new Ent_Ejercicio();
            cboEjercicio.DataSource = Log_Ejercicio.Lista_Ejercicio(objEEjercicio);
            cboEjercicio.DataTextField = "Descripcion";
            cboEjercicio.DataValueField = "Ejercicio_Id";
            cboEjercicio.DataBind();
            cboEjercicio.SelectedIndex = cboEjercicio.Items.Count - 1;
        }

        private void LlenarMes(String Compania_Id, String Ejercicio_Id, String Planilla_Id)
        {
            Ent_Periodo objEPeriodo = new Ent_Periodo();
            objEPeriodo.Compania_Id = Compania_Id;
            objEPeriodo.Ejercicio_Id = Ejercicio_Id;
            objEPeriodo.Planilla_Id = Planilla_Id;
            objEPeriodo.Mes_Id = ""; //para que filtre todos
            objEPeriodo.Estado_Id = "02";
            DataTable dtPeriodos = Log_Periodo.Lista_Periodo(objEPeriodo);

            Ent_Mes objEMes = new Ent_Mes();
            objEMes.Ejercicio_Id = Ejercicio_Id;
            cboMes.DataSource = Log_Mes.Lista_Mes(objEMes);
            cboMes.DataTextField = "Descripcion";
            cboMes.DataValueField = "Mes_Id";
            cboMes.DataBind();

            for (int i = cboMes.Items.Count - 1; i >= 0; i--)
            {
                Boolean fl_existe = false;
                foreach (DataRow drPer in dtPeriodos.Rows)
                {
                    if (drPer["Mes_Id"].ToString() == cboMes.Items[i].Value.ToString())
                    {
                        fl_existe = true;
                        break;
                    }
                }
                if (fl_existe == false)
                    cboMes.Items.RemoveAt(i);
            }

            cboMes.SelectedIndex = cboMes.Items.Count - 1;
        }

        private void LlenarPeriodo(String Compania_Id, String Ejercicio_Id, String Planilla_Id, String Mes_Id)
        {
            Ent_Periodo objEPeriodo = new Ent_Periodo();
            objEPeriodo.Compania_Id = Compania_Id;
            objEPeriodo.Ejercicio_Id = Ejercicio_Id;
            objEPeriodo.Planilla_Id = Planilla_Id;
            objEPeriodo.Mes_Id = Mes_Id;
            objEPeriodo.Estado_Id = "02";

            cboPeriodo.DataSource = Log_Periodo.Lista_Periodo(objEPeriodo);
            cboPeriodo.DataTextField = "Descripcion";
            cboPeriodo.DataValueField = "Periodo_Id";
            cboPeriodo.DataBind();
            cboPeriodo.SelectedIndex = cboPeriodo.Items.Count - 1;
            //////if (cboPeriodo.Items.Count < 1)
            //////{
            //////    string msj = "No Se Encontraron Periodos Activos";
            //////    Utils.fc_DisplayAlert(this.Page, msj);
            //////}
        }

        protected void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlMantenimientos.nPosback = 0;
            LlenarPeriodo(cboEmpresa.SelectedValue, cboEjercicio.SelectedValue, cboPlanilla.SelectedValue, cboMes.SelectedValue);
            Session["Compania_Id"] = cboEmpresa.SelectedValue;
            Session["Planilla_Id"] = cboPlanilla.SelectedValue;
            Session["Ejercicio_Id"] = cboEjercicio.SelectedValue;
            Session["Mes_Id"] = cboMes.SelectedValue;
            if (cboPlanilla.SelectedValue != "-Seleccione-")
                Session["Periodo_Id"] = cboPeriodo.SelectedValue;
            else
                Session["Periodo_Id"] = null;

            callEvent_ChangedPeriodo(); //@001 I/F
        }

        protected void cboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlMantenimientos.nPosback = 0;
            Session["Compania_Id"] = cboEmpresa.SelectedValue;
            Session["Planilla_Id"] = cboPlanilla.SelectedValue;
            Session["Ejercicio_Id"] = cboEjercicio.SelectedValue;
            Session["Mes_Id"] = cboMes.SelectedValue;
            if (cboPlanilla.SelectedValue != "-Seleccione-")
                Session["Periodo_Id"] = cboPeriodo.SelectedValue;
            else
                Session["Periodo_Id"] = null;

            callEvent_ChangedPeriodo(); //@001 I/F
        }

        //@001 I
        private void callEvent_ChangedPeriodo()
        {
            //Sólo si hay un controlador de eventos
            if (PostBackPeriodoChangedEventHandler != null) { PostBackPeriodoChangedEventHandler(this, EventArgs.Empty); } //@001 I/F
        }
        //@001 F
    }
}