using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presistence;

namespace BusienssLogic.CA.oAccesoJustificaciones
{
    public class controller_AccesoJustificaciones
    {
        private static controller_AccesoJustificaciones Instace = null;
        public static controller_AccesoJustificaciones Get_Instace() {
            return Instace == null ? Instace = new controller_AccesoJustificaciones() : Instace;
        }
        public Usuario_Asistencia Acceder_Justificacion(string Usuario,string Contraseña) { 
            using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())){
                int existe = obj.Usuario_Asistencia.Where(x => x.Usuario_dni == Usuario && x.Password == Contraseña).Count();
                if (existe == 1) {
                    return obj.Usuario_Asistencia.Where(x => x.Usuario_dni == Usuario && x.Password == Contraseña).First();
                }
                return null;
            }
        }
    }
}
