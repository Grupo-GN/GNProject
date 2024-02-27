using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Capas.Portal.Entidad;
using Capas.Portal.Negocio;

/// <summary>
/// Summary description for wsGenerales
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class wsGenerales : System.Web.Services.WebService {

    public wsGenerales () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    public object Get_ListaCombo(String codigo)
    {
        ComboBL oComboBL = new ComboBL();
        ComboBE ComboBE = new ComboBE();
        ComboBEList oComboBEList = new ComboBEList();

        oComboBEList = oComboBL.Get_ListaCombo(codigo, "", "");

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(oComboBEList);
    }
    public object Get_ListaComboxPadre(String codigo, String co_padre)
    {
        ComboBL oComboBL = new ComboBL();
        ComboBE ComboBE = new ComboBE();
        ComboBEList oComboBEList = new ComboBEList();

        oComboBEList = oComboBL.Get_ListaCombo(codigo, co_padre, "");

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(oComboBEList);
    }
    
}
