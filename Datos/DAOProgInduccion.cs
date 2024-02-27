using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Capas.Portal.Entidad;
using System.Transactions;

namespace Capas.Portal.Datos
{
    public class DAOProgInduccion : ClsConexion
    {

        //public Int32 GeneraProgInduccionxTrab(ProgInduccion objE)
        //{
        //    return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IGeneraProgInduccioxTrab", objE.Personal_Id);
        //}

        public Int32 InsertProgInduccion(DataTable dt)
        {
            TransactionScope trans = new TransactionScope();
            try
            {
                Int32 rpta = 0;
                String Personal_Id, Categoria_Auxiliar_Id, Descripcion, User_Name;
                Int32 CatInduccion_Id;
                Boolean Aprobado;
                foreach (DataRow dr in dt.Rows)
                {
                    Personal_Id = dr["Personal_Id"].ToString();
                    Categoria_Auxiliar_Id = dr["Categoria_Auxiliar_Id"].ToString();
                    CatInduccion_Id = Convert.ToInt32(dr["CatInduccion_Id"].ToString());
                    Descripcion = dr["Descripcion"].ToString();
                    User_Name = dr["User_Name"].ToString();
                    Aprobado = Convert.ToBoolean(dr["Aprobado"]);
                    Entidad.ProgInduccion objE = new ProgInduccion(Personal_Id, Categoria_Auxiliar_Id, CatInduccion_Id, Descripcion, Aprobado, User_Name);
                    rpta = InsertProgInduccion(objE);
                    if (rpta != 1)
                    {
                        break;
                    }

                }
                if (rpta == 1)
                {
                    trans.Complete();
                    trans.Dispose();
                    return rpta;
                }
                else
                {
                    trans.Dispose();
                    throw new Exception("Error al generar.");
                }
            }
            catch (Exception ex)
            {
                trans.Dispose();
                throw ex;
            }

        }

        public Int32 InsertProgInduccion(ProgInduccion objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertProgInduccion", objE.Personal_Id, objE.Categoria_Auxiliar_Id, objE.CatInduccion_Id, objE.Descripcion, objE.Aprobado, objE.User_Name);
        }

        public Int32 UpdateProgInduccion(ProgInduccion objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateProgInduccion", objE.Personal_Id, objE.Categoria_Auxiliar_Id, objE.CatInduccion_Id, objE.Descripcion, objE.Aprobado, objE.User_Name);
        }

        public Int32 DeleteProgInduccion(ProgInduccion objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteProgInduccion", objE.Personal_Id, objE.Categoria_Auxiliar_Id, objE.CatInduccion_Id);
        }

        public DataTable ListaProgInduccionAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListProgInduccionALL");
        }

        public DataTable ListaProgInduccionxPersonal_Id(ProgInduccion ObjE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListProgInduccionxPersonal_Id", ObjE.Personal_Id);
        }

        public DataTable ListaInduccionAreasxUserName(String User_Name)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, "select i.Categoria_Auxiliar_Id,i.Personal_Id,u.[User_Name] from I_InducAprob as i left outer join I_Users as u on i.Personal_Id = u.Personal_Id where u.[User_Name]='" + User_Name + "'");
        }

        public DataTable ListaInduccionAprobado()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListProgInduccionAprobado");
        }
        public DataTable ListaInduccionSinAprobar()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListProgInduccionSinAprobar");
        }

        public String CorreosInduccionxPersonalId(String Personal_Id)
        {
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteDataTable(Conexion(), "usp_ICorreosInduccionxPersonalId", Personal_Id);
            return dt.Rows[0][0].ToString();
        }

    }

}
