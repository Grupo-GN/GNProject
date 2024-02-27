using BusinessLogic.oComentGerencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.pComentGerencia
{
    public partial class sComentGerencia : System.Web.UI.Page
    {
        [WebMethod]
        public static string Get_Add_Comentario(string Incidente_Id, string Gerente_Id, string EventoComentario, string Comentario)
        {
            return controller_ComentGerencia.Get_Instance().Get_Add_Comentario(Incidente_Id, Gerente_Id, EventoComentario, Comentario);
        }

        [WebMethod]
        public static string Get_Comentario_Historico(string Incidente_Id, string Gerente_Id, string EventoComentario)
        {
            return controller_ComentGerencia.Get_Instance().Get_Comentario_Historico(Incidente_Id, Gerente_Id, EventoComentario);
        }
    }
}