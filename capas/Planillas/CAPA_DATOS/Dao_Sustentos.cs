using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public class Dao_Sustentos
    {
        public static DataTable TipoPlanilla(string periodo)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "SP_TipoPlanilla" , periodo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Lista_Campos_Personal()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_capos_personal");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private static DataTable dt = new DataTable();
        public static void Estructura() {
            if(dt.Rows.Count==0){
                dt.Columns.Clear();
                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("conceptos", typeof(string));
                dt.Columns.Add("conceptosID", typeof(string));
                dt.Columns.Add("personald", typeof(string));
                dt.Columns.Add("contC", typeof(int));
                dt.Columns.Add("contP", typeof(int));
            }

        }
        public static void CargaDT(string id, 
                                    string conceptos, 
                                    string personald, 
                                    string conceptosID,
                                    int contC,
                                    int contP)
        {
            try {
                
                if (dt.Rows.Count != 0) {
                    for (Int32 i = 0; i <= dt.Rows.Count - 1;i++ ) {
                        if(dt.Rows[i][0].ToString()==id){
                            dt.Rows[i].Delete();
                        }
                    }
                }
                        DataRow dr = dt.NewRow();
                        dr["Id"] = id;
                        dr["conceptos"] = conceptos;
                        dr["conceptosID"] = conceptosID;
                        dr["personald"] = personald;
                        dr["contC"] = contC;
                        dr["contP"] = contP;
                        dt.Rows.Add(dr);
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ListDT()
        {
            try
            {
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void ClearDT()
        {
            try
            {
                dt.Rows.Clear();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SET_COMPATIBILITY_LEVEL(int level)
        {
            try {
                SqlHelper.ExecuteNonQuery(Conex.CadCon(), "fps_alter_BDCompatibilityLevel", level);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GenerarCalculo(Ent_Sustentos objEN)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String())) {
                    using (SqlCommand cmd = new SqlCommand("sp_Calculos", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@planillaID", objEN.Planilla);
                        cmd.Parameters.AddWithValue("@periodoID", objEN.PeriodoId);
                        cmd.Parameters.AddWithValue("@conceptoID", objEN.ConceptoID);
                        cmd.Parameters.AddWithValue("@procesoID", objEN.ProcesoID);
                        cmd.Parameters.AddWithValue("@CamposPerso", objEN.CamposPerso);
                        cmd.Parameters.AddWithValue("@camposConcepto", objEN.CamposConcep);
                        cmd.Parameters.AddWithValue("@DescripcionConceptos", objEN.DetalleConceptos);
                        cmd.Parameters.AddWithValue("@CANTC", objEN.CantC);
                        cmd.Parameters.AddWithValue("@CANTP", objEN.CantP);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;                    
                    }
                }

                /*return SqlHelper.ExecuteDataTable(Conex.CadCon(), "sp_Calculos",
                    objEN.Planilla,
                    objEN.PeriodoId,
                    objEN.ConceptoID,
                    objEN.ProcesoID,
                    objEN.CamposPerso,
                    objEN.CamposConcep,
                    objEN.DetalleConceptos,
                    objEN.CantC,
                    objEN.CantP);*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /* MATENIMIENTO DE PLANTILLAS PARA LOS SUSTENTOS */
        public static DataTable ListPlantillas()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "sp_ListPlantillasSustentos");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable BuscarPlantillaSustento(Ent_Sustentos objEN)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "sp_DatosPlantillasSustentos", objEN.PlantillaID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable BuscarConcepto(Ent_Sustentos objEN)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "sp_BuscarConcepto", objEN.ConceptoID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetProcesoConcepto(Ent_Sustentos objEN)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "GET_Procesos_Concepto", objEN.ConceptoID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable AllConceptos()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_RSGetConceptos");
               
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable NuevaPlantilla(Ent_Sustentos objEN)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), 
                    "sp_Insert_Plantilla_Sustento", 
                    objEN.Nombre,
                    objEN.ConceptoID,
                    objEN.ProcesoID,
                    objEN.CamposPerso,
                    objEN.CamposConcep,
                    objEN.DetalleConceptos,
                    objEN.CantC,
                    objEN.CantP);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ActualizaPlantilla(Ent_Sustentos objEN)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(),
                    "sp_Update_Plantilla_Sustento",
                    objEN.PlantillaID,
                    objEN.Nombre,
                    objEN.ConceptoID,
                    objEN.ProcesoID,
                    objEN.CamposPerso,
                    objEN.CamposConcep,
                    objEN.DetalleConceptos,
                    objEN.CantC,
                    objEN.CantP);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable EliminaPlantilla(Ent_Sustentos objEN)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(),
                    "sp_Delete_Plantilla_Sustento",
                    objEN.PlantillaID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetDetalleConcepto(string Codigo)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(),
                    "sp_getDetalle_Concepto",
                    Codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetConceptosByTipoDatoProcesoList(string Tipo,string Proceso) {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(),
                    "SP_ConceptosTipoDatoProcesoList", Tipo, Proceso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
