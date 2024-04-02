using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
   public static class Dao_Correo_Usuario
    {

       public static DataTable Lista_Correo_Usuario(Ent_Correo_Usuario objE)
       {
           try
           {
               return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaCorreo_Usuario", objE.Compania_Id);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
       }



       public static int Insertar_Correo_Usuario(Ent_Correo_Usuario objE)
       {
           return SqlHelper.ExecuteNonQuery(Conex.CadCon(), "usp_InsertCorreo_Usuario", objE.Compania_Id, objE.Personal_Id, objE.Cargo, objE.Area, objE.Email, objE.Permiso,objE.Adm_Contratos,objE.Adm_Vacaciones,objE.H_Extras);
       }

       public static int Actualizar_Correo_Usuario(Ent_Correo_Usuario objE)
       {
           return SqlHelper.ExecuteNonQuery(Conex.CadCon(), "usp_ActualizarCorreo_Usuario", objE.Compania_Id, objE.Personal_Id, objE.Email,objE.Adm_Contratos,objE.Adm_Vacaciones,objE.H_Extras);
       }

       public static int Eliminar_Correo_Usuario(Ent_Correo_Usuario objE)
       {
           return SqlHelper.ExecuteNonQuery(Conex.CadCon(), "usp_EliminarCorreo_Usuario", objE.Compania_Id, objE.Personal_Id);
       }
    }
}
