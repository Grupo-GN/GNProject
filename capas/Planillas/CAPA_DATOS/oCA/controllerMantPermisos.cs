using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CAPA_DATOS.oCA
{
    public class controllerMantPermisos
    {
        private static controllerMantPermisos instance = null;
        public static controllerMantPermisos getInstance()
        {
            return instance == null ? instance = new controllerMantPermisos() : instance;
        }
        private static int FINALROWS = 12;
        public List<CAPA_ENTIDAD.EntMs.Permisos> Get_Permiso_MS_Listar(string descripcion, int inicio, out Int32 qt_registros)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_Permisos_MS_Listar", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    List<CAPA_ENTIDAD.EntMs.Permisos> oLista = new List<CAPA_ENTIDAD.EntMs.Permisos>();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        CAPA_ENTIDAD.EntMs.Permisos objPermi = new CAPA_ENTIDAD.EntMs.Permisos();
                        objPermi.Permiso_Id = dr.GetValue(0).ToString();
                        objPermi.descripcion = dr.GetValue(1).ToString();
                        objPermi.fechaAcumulado = dr.GetValue(2).ToString();
                        objPermi.ejecutaAcumuladoDias = dr.GetValue(3).ToString();
                        objPermi.NConcepto= dr.GetValue(4).ToString();
                        oLista.Add(objPermi);
                    }
                    qt_registros = oLista.Count();
                    return oLista.Skip(inicio).Take(FINALROWS).ToList();
                }
            }
        }

        public ArrayList ListarDatosVariables()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string comando = "SELECT CONCEPTO_ID,CASE  WHEN LEN(DETALLE)>0 THEN DETALLE ELSE Descripcion END [Descripcion]  FROM CONCEPTOS WHERE Tipo_Dato='02' AND Estado_Id='01' ";
                comando += "ORDER BY 2";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;

                }
            }
        }
        public ArrayList Get_Permiso_MS_Buscar(int Permiso_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string comando = "spu_Permisos_MS_Buscar";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PermisoId", Permiso_Id);
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;

                }
            }
        }
        public string Get_Permiso_MS_Mantenimiento(int tipoProceso, int Permiso_Id, string descripcion, string fechaAcumulado, int ejecutaAcumulado, string ConceptoId)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("spu_Permisos_MS_Mantenimiento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@tipoProceso", tipoProceso);
                        cmd.Parameters.AddWithValue("@codigo", Permiso_Id);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@fechaAcumulado", fechaAcumulado);
                        cmd.Parameters.AddWithValue("@ejecutaAcumuladoDias", ejecutaAcumulado);
                        cmd.Parameters.AddWithValue("@ConceptoId", ConceptoId);
                        int irows= cmd.ExecuteNonQuery();
                        if (irows > 0)
                        {
                            if (tipoProceso == 1)
                            {
                                return "true#Permiso registrado correctamente.";
                            }
                            else { return "true#Permiso actualizado correctamente."; }
                        }
                        else
                        {
                            return "true#Permiso no identificado.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "false#Error: " + ex.Message;
            }
        }



    }
}
