using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Capas.Portal.Entidad;
using System.Transactions;
using System.Data.SqlClient;

namespace Capas.Portal.Datos
{
    public class DAOEncuesta:ClsConexion
    {
        public DataTable ListaEncuestaActivas()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_ListaEncuestaActivas");
        }

        public DataTable ListaEncuestaCerradas()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_ListaEncuestaCerradas");
        }

        public List<Encuesta> GetEncuestasVigentesyCerradas()
        {
            List<Encuesta> lista = new List<Encuesta>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_IListaEncuestaVigentesyCerradas";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Encuesta ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Encuesta();
                    indice = reader.GetOrdinal("Encuesta_Id");
                    ent.Encuesta_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Titulo");
                    ent.Titulo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Descripcion");
                    ent.Descripcion = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("SoloUnaOpcion");
                    ent.SoloUnaOpcion = reader.IsDBNull(indice) ? false : reader.GetBoolean(indice);
                    indice = reader.GetOrdinal("Fecha_Inicio");
                    ent.Fecha_Inicio = reader.IsDBNull(indice) ? DateTime.MinValue : reader.GetDateTime(indice);
                    ent.sFecha_Inicio = reader.IsDBNull(indice) ? String.Empty : reader.GetDateTime(indice).ToShortDateString() + " " + reader.GetDateTime(indice).ToShortTimeString();
                    indice = reader.GetOrdinal("Fecha_Cierre");
                    ent.Fecha_Cierre = reader.IsDBNull(indice) ? DateTime.MinValue : reader.GetDateTime(indice);
                    ent.sFecha_Cierre = reader.IsDBNull(indice) ? String.Empty : reader.GetDateTime(indice).ToShortDateString() + " " + reader.GetDateTime(indice).ToShortTimeString();
                    indice = reader.GetOrdinal("User_Name");
                    ent.User_Name = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("no_estado");
                    ent.no_estado = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);

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
        public List<Encuesta> GetEncuestasAll()
        {
            List<Encuesta> lista = new List<Encuesta>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_IListaEncuestaAll";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Encuesta ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Encuesta();
                    indice = reader.GetOrdinal("Encuesta_Id");
                    ent.Encuesta_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Titulo");
                    ent.Titulo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Descripcion");
                    ent.Descripcion = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("SoloUnaOpcion");
                    ent.SoloUnaOpcion = reader.IsDBNull(indice) ? false : reader.GetBoolean(indice);
                    indice = reader.GetOrdinal("Fecha_Inicio");
                    ent.Fecha_Inicio = reader.IsDBNull(indice) ? DateTime.MinValue : reader.GetDateTime(indice);
                    ent.sFecha_Inicio = reader.IsDBNull(indice) ? String.Empty : reader.GetDateTime(indice).ToShortDateString() + " " + reader.GetDateTime(indice).ToShortTimeString();
                    indice = reader.GetOrdinal("Fecha_Cierre");
                    ent.Fecha_Cierre = reader.IsDBNull(indice) ? DateTime.MinValue : reader.GetDateTime(indice);
                    ent.sFecha_Cierre = reader.IsDBNull(indice) ? String.Empty : reader.GetDateTime(indice).ToShortDateString() + " " + reader.GetDateTime(indice).ToShortTimeString();
                    indice = reader.GetOrdinal("User_Name");
                    ent.User_Name = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);

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
        public DataTable ListaEncuestaAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListaEncuestaAll");
        }

        public DataTable ListaEncuestaxEncuestaId(Encuesta objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListaEncuestaxEncuestaId", objE.Encuesta_Id);
        }

        public Int32 InsertEncuesta(Encuesta objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertEncuesta", objE.Titulo, objE.Descripcion, objE.SoloUnaOpcion, objE.Fecha_Inicio, objE.Fecha_Cierre, objE.User_Name);
        }

        public Int32 InsertEncuesta(Encuesta objE, DataTable dtOpciones)
        {
            TransactionScope trans = new TransactionScope();
            try
            {                
                Int32 rpta;
                rpta = SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertEncuesta", objE.Titulo, objE.Descripcion, objE.SoloUnaOpcion, objE.Fecha_Inicio, objE.Fecha_Cierre, objE.User_Name);
                if (rpta == 1)
                {
                    String Encuesta_Id;
                    Encuesta_Id = SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, "select max(Encuesta_Id) from I_Encuesta").Rows[0][0].ToString();

                    String Nombre_Opcion;
                    if (dtOpciones.Rows.Count > 0)
                    {
                        DAOEncuestaOpciones objDatosEncOpc = new DAOEncuestaOpciones();
                        foreach (DataRow dr in dtOpciones.Rows)
                        {
                            Nombre_Opcion = dr["Nombre_Opcion"].ToString();
                            EncuestaOpciones objEOpc = new EncuestaOpciones(Nombre_Opcion, Encuesta_Id);
                            rpta = objDatosEncOpc.InsertEncuestaOpciones(objEOpc);
                            if (rpta != 1)
                            {
                                break;
                            }
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
                        throw new Exception("Error al Grabar las Opciones de la Encuesta.");
                    }
                }
                else
                {
                    trans.Dispose();
                    throw new Exception("Error al Grabar Encuesta.");
                }
            }
            catch (Exception ex)
            {
                trans.Dispose();
                throw ex;
            }

        }

        public Int32 UpdateEncuesta(Encuesta objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateEncuesta", objE.Encuesta_Id, objE.Titulo, objE.Descripcion, objE.SoloUnaOpcion, objE.Fecha_Inicio, objE.Fecha_Cierre, objE.User_Name);
        }

        public Int32 DeleteEncuesta(Encuesta objE)
        {
            //Falta eliminar sus relaciones (Opciones y Votos)
            SqlHelper.ExecuteNonQuery(Conexion(), CommandType.Text, "delete from I_EncuestaRespuestas where Encuesta_Id = '" + objE.Encuesta_Id + "'");
            SqlHelper.ExecuteNonQuery(Conexion(), CommandType.Text, "delete from I_EncuestaOpciones where Encuesta_Id = '" + objE.Encuesta_Id + "'");
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteEncuesta", objE.Encuesta_Id);
        }


    }
}
