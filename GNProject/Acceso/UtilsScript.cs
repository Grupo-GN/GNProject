using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
namespace GNProject.Acceso
{
    public class UtilsScript
    {
        public UtilsScript()
        {
            //
            // TODO: Add constructor logic here
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