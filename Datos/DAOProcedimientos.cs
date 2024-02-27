using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Capas.Portal.Entidad;
using System.Data.SqlClient;

namespace Capas.Portal.Datos
{
    public class DAOProcedimientos:ClsConexion
    {
        public List<Procedimientos> GetProcedimientosAll()
        {
            List<Procedimientos> lista = new List<Procedimientos>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_IListProcedimientoAll";            

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Procedimientos ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Procedimientos();
                    indice = reader.GetOrdinal("Procedimiento_Id");
                    ent.Procedimiento_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Titulo");
                    ent.Titulo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Descripcion");
                    ent.Descripcion = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Categoria_Auxiliar_Id");
                    ent.Categoria_Auxiliar_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Area");
                    ent.Area = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Nombre_Doc");
                    ent.Nombre_Doc = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("User_Name");
                    ent.User_Name = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Fecha");
                    ent.sFecha = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Tipo");
                    ent.Tipo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);

                    lista.Add(ent);
                }
                reader.Close();
            }
            catch (Exception)
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                throw;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return lista;
        }

        public DataTable ListaProcedimientoAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListProcedimientoAll");
        }

        public DataTable ListaProcedimientoxId(Procedimientos objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListProcedimientoxId", objE.Procedimiento_Id);
        }

        public DataTable ListaProcedimientoxArea(Procedimientos objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListProcedimientoxArea", objE.Categoria_Auxiliar_Id);
        }

        public Int32 InsertProcedimiento(Procedimientos objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertProcedimiento", objE.Titulo, objE.Descripcion, objE.Categoria_Auxiliar_Id, objE.Nombre_Doc, objE.User_Name, objE.Fecha);
        }

        public Int32 UpdateProcedimiento(Procedimientos objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateProcedimiento", objE.Procedimiento_Id, objE.Titulo, objE.Descripcion, objE.Categoria_Auxiliar_Id, objE.Nombre_Doc, objE.User_Name, objE.Fecha);
        }

        public Int32 DeleteProcedimiento(Procedimientos objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteProcedimiento", objE.Procedimiento_Id);
        }

        #region cargaDocumentos_Michael()

        /// <summary>
        /// Mostrar Los Documentos de acuerdo al Flag
        /// </summary>
        /// <param name="objE"></param>
        /// <returns></returns>
        public DataTable MS_SGCO_DProcedimientos_Listar(int procedimientoId)
        {
            using(SqlConnection cn = new SqlConnection(Conexion())){
                using (SqlCommand cmd = new SqlCommand("spu_SGCO_DProcedimientos_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@ProcedimientoId", procedimientoId);
                    using(SqlDataAdapter da= new SqlDataAdapter(cmd)){
                        DataTable tabla= new DataTable();
                        tabla.Clear();
                        da.Fill(tabla);
                        return tabla;
                    }
                }
            }

        }

        /// <summary>
        /// Procedimiento para (INSERTAR,ELIMINAR,ACTUALIZAR)
        /// </summary>
        /// <param name="objE"></param>
        /// <returns></returns>
        public int MS_SGCO_DProcedimientos_IAE(int tipoProceso, SGCO_DProcedimientos objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "spu_SGCO_DProcedimiento_Insertar",
              tipoProceso, objE.SGCO_Procedimiento_Detalle_Id , objE.SGCO_Procedimiento_Id, 
              objE.Titulo, objE.Descripcion, objE.Categoria_Auxiliar_Id, objE.Nombre_Doc, 
              objE.User_Name, objE.Fecha);
        }

        public DataTable MS_SGCO_ListaDProcedimientoxId(SGCO_DProcedimientos objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_MS_SGCO_BuscarDProcedimiento_xId", objE.SGCO_Procedimiento_Detalle_Id);
        }

        #endregion

    }

    public class SGCO_DProcedimientos {
        public int SGCO_Procedimiento_Detalle_Id { get; set; }
        public int SGCO_Procedimiento_Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Categoria_Auxiliar_Id { get; set; }
        public string Nombre_Doc { get; set; }
        public string User_Name { get; set; }
        public DateTime Fecha { get; set; }

        public SGCO_DProcedimientos() { }

        public SGCO_DProcedimientos(int SGCO_Procedimiento_Id, string Titulo, string Descripcion,
            string Categoria_Auxiliar_Id, string Nombre_Doc, string User_Name, DateTime Fecha) { }

    }


}
