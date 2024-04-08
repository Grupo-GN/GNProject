using CAPA_DATOS;
using CAPA_DATOS.oRRHH;
using CAPA_ENTIDAD;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class AsigBancoPagoCia_Personal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                String Compania_Id = Utils.fc_obtiene_Compania_Id(this);

                List<eCta_Compania> oLista_CtaCia = controllerCtaCompania.getinstance().ListarCtasCompania(Compania_Id);
                ArrayList oComboBanco_Cia = new ArrayList();
                foreach (eCta_Compania ent in oLista_CtaCia)
                {
                    if (ent.Moneda_Id == "MN") /*soles*/
                    {
                        var xitem = new
                        {
                            value = ent.Banco_Id,
                            nombre = ent.Banco
                        };
                        oComboBanco_Cia.Add(xitem);
                    }
                }

                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                String js = "";
                js += String.Format("fc_FillCombo('cboBancoPago_Cia', {0}, '--Seleccione--');", serializer.Serialize(oComboBanco_Cia));
                this.fc_JavaScript(this.Page, js);
            }
        }
        public void fc_JavaScript(Page c, String script, String strKey = "__Script__")
        {
            /*Dentro de un ScriptManager*/
            //script = script.Replace("\'", "\\'");
            //script = script.Replace("\r", "\\r");
            //script = script.Replace("\n", "\\n");
            String Script = "<script languaje='javascript' type='text/javascript'>" + script + "</script>";
            ScriptManager.RegisterStartupScript(c, typeof(Page), strKey, Script, false);
        }

        [WebMethod]
        public static object Get_Combos()
        {
            return controllerDocumentoElectronico.getinstance().Get_Combos();
        }

        [WebMethod]
        public static object Get_CatAuxiliar2(object strParametros)
        {
            return controllerDocumentoElectronico.getinstance().Get_CatAuxiliar2(strParametros);
        }

        [WebMethod]
        public static object Get_Personal(object strParametros)
        {
            return controllerDocumentoElectronico.getinstance().Get_Personal(strParametros);
        }

        [WebMethod]
        public static object Get_Bandeja(object strParametros)
        {
            Dictionary<string, object> prm = (Dictionary<string, object>)strParametros;

            Ent_Personal_Activo oEnt = new Ent_Personal_Activo();
            oEnt.Periodo_Id = prm["co_periodo"].ToString();
            oEnt.Area_Id = prm["id_localidad"].ToString();
            oEnt.Categoria_Auxiliar_Id = prm["id_cat_aux"].ToString();
            oEnt.Categoria_Auxiliar2_Id = prm["id_cat_aux2"].ToString();
            oEnt.Proyecto_Id = prm["id_proyecto"].ToString();
            oEnt.Personal_Id = prm["id_persona"].ToString();
            List<Ent_Personal_Activo> oLista = ControllerMaestroPersonal.GetInstance().getPersonalxPeriodo_Bandeja(oEnt);

            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(oLista);
            return serializedResult;
        }

        [WebMethod]
        public static object setAsigBancoPago_Cia(object strParametros)
        {
            Dictionary<string, object> prm = (Dictionary<string, object>)strParametros;

            String Periodo_Id = prm["co_periodo"].ToString();
            String Personal_Ids = prm["ids_personal"].ToString();
            String Banco_Pago_Cia_Id = prm["co_banco_pago_cia"].ToString();
            Boolean fl_CTS = prm["fl_CTS"].ToString() == "1" ? true : false;
            Int32 retorno; String msg_retorno;

            ControllerMaestroPersonal.GetInstance().setAsigBancoPago_Cia(Periodo_Id, Personal_Ids, Banco_Pago_Cia_Id, fl_CTS, out retorno, out msg_retorno);

            object res = new { retorno = retorno, msg_retorno = msg_retorno };

            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(res);
            return serializedResult;
        }
    }
}