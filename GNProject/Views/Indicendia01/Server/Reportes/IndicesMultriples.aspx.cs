using BusinessLogic.oIndicesMultiples;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.Reportes
{
    public partial class IndicesMultriples : System.Web.UI.Page
    {
        [WebMethod]
        public static List<string> Get_Datos_Ejes(string Display, string tableFrom)
        {
            return controller_IndicesMultiples.Get_Instance().Get_Datos_Ejes(Display, tableFrom);
        }

        [WebMethod]
        public static ArrayList GENERAR_REPORTE_INCICE_MULTRIPLE(string select, string sqlSelect, string sjoin, string pin, string pFor, string pOrder)
        {
            return controller_IndicesMultiples.Get_Instance().GENERAR_REPORTE_INCICE_MULTRIPLE(select, sqlSelect, sjoin, pin, pFor, pOrder);
        }
    }
}