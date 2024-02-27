using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;

/// <summary>
/// Descripción breve de UtilsScript
/// </summary>
namespace GNProject.Acceso.App_code_portal
{
    public class UtilsScript
    {
        public UtilsScript()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public static void fc_DisplayAlert(Page c, String Msj, String strKey = "__AlertRpta__")
        {
            /*Dentro de un ScriptManager*/
            Msj = Msj.Replace("\'", "\\'");
            Msj = Msj.Replace("\r", "\\r");
            Msj = Msj.Replace("\n", "\\n");
            String ScriptAlertRpta = "<script languaje='javascript' type='text/javascript'>alert('" + Msj + "');</script>";
            ScriptManager.RegisterStartupScript(c, typeof(Page), strKey, ScriptAlertRpta, false);
        }

        public static void fc_JavaScript(Page c, String script, String strKey = "__Script__")
        {
            /*Dentro de un ScriptManager*/
            //script = script.Replace("\'", "\\'");
            //script = script.Replace("\r", "\\r");
            //script = script.Replace("\n", "\\n");
            String Script = "<script languaje='javascript' type='text/javascript'>" + script + "</script>";
            ScriptManager.RegisterStartupScript(c, typeof(Page), strKey, Script, false);
        }


    }
}
