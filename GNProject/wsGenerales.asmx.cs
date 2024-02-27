using GNProject.Acceso;
using GNProject.Entity;
using GNProject.Entity.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace GNProject
{
    /// <summary>
    /// Descripción breve de wsGenerales
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsGenerales : System.Web.Services.WebService
    {

        public wsGenerales()
        {

            //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
            //InitializeComponent(); 
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public object getCombo(String codigo, String co_padre = "")
        {
            return getComboxUsuario(codigo, co_padre, 0);
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public object getComboxUsuario(String codigo, String co_padre = "", Int32 id_usuario = 0)
        {
            ComboBL oComboBL = new ComboBL();
            ComboBE oComboBE = new ComboBE();
            ComboBEList oComboBEList = oComboBL.Get_Combo(codigo, co_padre, id_usuario);

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(oComboBEList);
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public object genCod(String[] cadena)
        {
            List<object> lstCadena = new List<object>();
            foreach (string cad in cadena)
            {
                String cod = Encryptar.Encripta(cad);
                lstCadena.Add(cod);
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(lstCadena);
        }
        /// <summary>
        /// //PORTAL
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        //Los siguientes servicios son para portal
        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public object Get_ListaCombo(String codigo)
        {
            Capas.Portal.Negocio.ComboBL oComboBL = new Capas.Portal.Negocio.ComboBL();
            Capas.Portal.Entidad.ComboBE ComboBE = new Capas.Portal.Entidad.ComboBE();
            Capas.Portal.Entidad.ComboBEList oComboBEList = new Capas.Portal.Entidad.ComboBEList();

            oComboBEList = oComboBL.Get_ListaCombo(codigo, "", "");

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(oComboBEList);
        }
        public object Get_ListaComboxPadre(String codigo, String co_padre)
        {
            Capas.Portal.Negocio.ComboBL oComboBL = new Capas.Portal.Negocio.ComboBL();
            Capas.Portal.Entidad.ComboBE ComboBE = new Capas.Portal.Entidad.ComboBE();
            Capas.Portal.Entidad.ComboBEList oComboBEList = new Capas.Portal.Entidad.ComboBEList();

            oComboBEList = oComboBL.Get_ListaCombo(codigo, co_padre, "");

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(oComboBEList);
        }

        //END PORTAL
    }
}
