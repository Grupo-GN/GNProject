using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public class PanelControlDA
    {
        public List<PanelControlBE.GraficoPieBE> getGraficoPie(PanelControlBE.FiltrosBE oFiltrosBE)
        {
            List<PanelControlBE.GraficoPieBE> lista = new List<PanelControlBE.GraficoPieBE>();

            SqlConnection cn = new SqlConnection(Conex.CadCon_String());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "pla_sps_dashboard_grafico_pie";
            cmd.Parameters.AddWithValue("@vi_TipoGrafico", oFiltrosBE.TipoGrafico);
            cmd.Parameters.AddWithValue("@vi_Planilla_Id", oFiltrosBE.Planilla_Id);
            cmd.Parameters.AddWithValue("@vi_Ejercicio_Id", oFiltrosBE.Ejercicio_Id);
            cmd.Parameters.AddWithValue("@vi_nMes_Ids", oFiltrosBE.nMes_Ids);
            cmd.Parameters.AddWithValue("@vi_Area_Ids", oFiltrosBE.Area_Ids);
            cmd.Parameters.AddWithValue("@vi_CatAuxiliar_Ids", oFiltrosBE.CatAuxiliar_Ids);
            cmd.Parameters.AddWithValue("@vi_Tipo_Agrupacion", oFiltrosBE.Tipo_Agrupacion);
            cmd.Parameters.AddWithValue("@vi_Personal_Ids", oFiltrosBE.Personal_Ids);
            cmd.Parameters.AddWithValue("@vi_Boleta_Columna", oFiltrosBE.Boleta_Columna);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                PanelControlBE.GraficoPieBE oBE = null;
                Int32 indice = 0;
                while (reader.Read())
                {
                    oBE = new PanelControlBE.GraficoPieBE();
                    indice = 0;

                    indice = reader.GetOrdinal("CodTipoCategoria");
                    oBE.CodTipoCategoria = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("TipoCategoria");
                    oBE.TipoCategoria = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("Valor");
                    oBE.Valor = reader.IsDBNull(indice) ? 0 : reader.GetDecimal(indice);

                    lista.Add(oBE);
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
        public List<PanelControlBE.GraficoXYBE> getGraficoXY(PanelControlBE.FiltrosBE oFiltrosBE)
        {
            List<PanelControlBE.GraficoXYBE> lista = new List<PanelControlBE.GraficoXYBE>();

            SqlConnection cn = new SqlConnection(Conex.CadCon_String());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "pla_sps_dashboard_grafico_XY";
            cmd.Parameters.AddWithValue("@vi_TipoGrafico", oFiltrosBE.TipoGrafico);
            cmd.Parameters.AddWithValue("@vi_Planilla_Id", oFiltrosBE.Planilla_Id);
            cmd.Parameters.AddWithValue("@vi_Ejercicio_Id", oFiltrosBE.Ejercicio_Id);
            cmd.Parameters.AddWithValue("@vi_nMes_Ids", oFiltrosBE.nMes_Ids);
            cmd.Parameters.AddWithValue("@vi_Area_Ids", oFiltrosBE.Area_Ids);
            cmd.Parameters.AddWithValue("@vi_CatAuxiliar_Ids", oFiltrosBE.CatAuxiliar_Ids); 
            cmd.Parameters.AddWithValue("@vi_Personal_Ids", oFiltrosBE.Personal_Ids);
            cmd.Parameters.AddWithValue("@vi_Proceso_Ids", oFiltrosBE.Proceso_Ids);
            cmd.Parameters.AddWithValue("@vi_Boleta_Columna", oFiltrosBE.Boleta_Columna);
            cmd.Parameters.AddWithValue("@vi_Concepto_Ids", oFiltrosBE.Concepto_Ids);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                PanelControlBE.GraficoXYBE oBE = null;
                Int32 indice = 0;
                while (reader.Read())
                {
                    oBE = new PanelControlBE.GraficoXYBE();
                    indice = 0;

                    indice = reader.GetOrdinal("Serie");
                    oBE.Serie = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("Cod_Eje_X");
                    oBE.Cod_Eje_X = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("Eje_X");
                    oBE.Eje_X = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("Eje_Y_Valor");
                    oBE.Eje_Y_Valor = reader.IsDBNull(indice) ? 0 : reader.GetDecimal(indice);

                    lista.Add(oBE);
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
    }
}
