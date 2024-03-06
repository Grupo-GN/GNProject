using BusienssLogic.CA.oGenerarPermisos;
using System;
using System.Web.Services;

namespace Servicios.CA
{
    /// <summary>
    /// Descripción breve de RegistrarPermiso
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class RegistrarPermiso : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        //Permisos por Fechas
        [WebMethod]
        public string Get_AM_Permisos_Fechas(int PermisoD_Id, int TPermiso_Id, string Personal_ID, DateTime FechaIni, DateTime FechaFin, string Descuento, string TipoReg, string Motivo, string NroDoc, string PersoModif)
        {
            return controller_GenerarPermisos.Get_Instance().Get_AM_Permisos_Fechas(PermisoD_Id, TPermiso_Id, Personal_ID, FechaIni, FechaFin, Descuento, TipoReg, Motivo, NroDoc, PersoModif);
        }
        //Permisos por Horas
        [WebMethod]
        public string Get_AM_Permisos_Horas(int PermisoH_Id, int TPermiso_Id, string Personal_ID, DateTime Fecha, DateTime HoraIni, DateTime HoraFin, string Descuento, string TipoReg, string Motivo, string PersoModif, int AplicarIngSal)
        {
            return controller_GenerarPermisos.Get_Instance().Get_AM_Permisos_Horas(PermisoH_Id, TPermiso_Id, Personal_ID, Fecha, HoraIni, HoraFin, Descuento, TipoReg, Motivo, PersoModif, AplicarIngSal);
        }
    }
}
