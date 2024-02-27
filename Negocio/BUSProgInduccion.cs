using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSProgInduccion
    {
        Datos.DAOProgInduccion objDatos = new DAOProgInduccion();

        //public Int32 GeneraProgInduccionxTrab(ProgInduccion objE)
        //{
        //    return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IGeneraProgInduccioxTrab", objE.Personal_Id);
        //}

        public Int32 InsertProgInduccion(DataTable dt)
        {
            return objDatos.InsertProgInduccion(dt);
        }

        public Int32 InsertProgInduccion(ProgInduccion objE)
        {
            return objDatos.InsertProgInduccion(objE);
        }

        public Int32 UpdateProgInduccion(ProgInduccion objE)
        {
            return objDatos.UpdateProgInduccion(objE);
        }

        public Int32 DeleteProgInduccion(ProgInduccion objE)
        {
            return objDatos.DeleteProgInduccion(objE);
        }

        public DataTable ListaProgInduccionAll()
        {
            return objDatos.ListaProgInduccionAll();
        }

        public DataTable ListaProgInduccionxPersonal_Id(ProgInduccion ObjE)
        {
            return objDatos.ListaProgInduccionxPersonal_Id(ObjE);
        }

        public DataTable ListaInduccionAreasxUserName(String User_Name)
        {
            return objDatos.ListaInduccionAreasxUserName(User_Name);
        }

        public DataTable ListaInduccionAprobado()
        {
            return objDatos.ListaInduccionAprobado();
        }
        public DataTable ListaInduccionSinAprobar()
        {
            return objDatos.ListaInduccionSinAprobar();
        }

        public String CorreosInduccionxPersonalId(String Personal_Id)
        {
            return objDatos.CorreosInduccionxPersonalId(Personal_Id);
        }

    }

}
