using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public class Log_Correo_Usuario 
    {

        public DataTable Lista_Correo_Usuario(Ent_Correo_Usuario objE)
        {
            try
            {
                return Dao_Correo_Usuario.Lista_Correo_Usuario(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Insertar_Correo_Usuario(Ent_Correo_Usuario objE)
        {
            return Dao_Correo_Usuario.Insertar_Correo_Usuario(objE);
        }

        public int Actualizar_Correo_Usuario(Ent_Correo_Usuario objE)
        {
            return Dao_Correo_Usuario.Actualizar_Correo_Usuario(objE);
        }

        public int Eliminar_Correo_Usuario(Ent_Correo_Usuario objE)
        {
            return Dao_Correo_Usuario.Eliminar_Correo_Usuario(objE);
        }


    }
}
