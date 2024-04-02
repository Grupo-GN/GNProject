using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CAPA_ENTIDAD.EntMs;

/// <summary>
/// @001 FPS 30/03/2020 - Se agrega filtro Proyecto
/// @002 FPS 10/01/2022 - Ajustes régimen por planilla para "Interface AFP - 2015"
/// </summary>

namespace CAPA_DATOS
{
    public class ControllerInterfacesExp
    {
        public List<Moneda> Monedas_GetMostrar()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spu_Monedas_GetSelectAll", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Moneda> oLista = new List<Moneda>();
                    while (dr.Read())
                    {
                        Moneda m = new Moneda();
                        m.idmoneda = dr.GetValue(0).ToString();
                        m.moneda = dr.GetValue(1).ToString();
                        oLista.Add(m);
                    }
                    cn.Close();
                    cn.Dispose();
                    return oLista;
                }
            }
        }

        /// <summary>
        /// lista de string para exportar a txt
        /// </summary>
        /// <param name="periodo"></param>
        /// <returns></returns>
        public List<string> GetListaAfp_Exportacion(string periodo)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_EstructuraAfp_Texto_ms", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> oLista = new List<string>();
                    while (dr.Read())
                    {
                        oLista.Add(dr.GetString(0).ToString());
                    }
                    cn.Close();
                    cn.Dispose();
                    return oLista;
                }
            }
        }

        /// <summary>
        /// lista de Exportacion Para Exportar a excel
        /// </summary>
        /// <param name="periodo"></param>
        /// <returns></returns>
        public List<Exportacion> GetListaAfp_ExportacionExcel(string periodo)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_EstructuraAfp_Excel_ms", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Exportacion> oLista = new List<Exportacion>();
                    while (dr.Read())
                    {
                        Exportacion exp = new Exportacion();
                        exp.NSecuencia = dr.GetValue(0).ToString();
                        exp.CUSPP = dr.GetValue(1).ToString();
                        exp.nDocumento = dr.GetValue(2).ToString();
                        exp.apePar = dr.GetValue(3).ToString();
                        exp.apeMar = dr.GetValue(4).ToString();
                        exp.Nombre = dr.GetValue(5).ToString();
                        exp.tipoMov = dr.GetValue(6).ToString();
                        exp.fechMov = dr.GetValue(7).ToString();
                        exp.valor = double.Parse(dr.GetValue(8).ToString());
                        exp.M_APOVOL = double.Parse(dr.GetValue(9).ToString());
                        exp.M_APOLVOLS = double.Parse(dr.GetValue(10).ToString());
                        exp.M_APOEMPL = double.Parse(dr.GetValue(11).ToString());
                        exp.Rubro = dr.GetValue(12).ToString();
                        exp.Datos_afp = dr.GetValue(13).ToString();
                        oLista.Add(exp);
                    }
                    cn.Close();
                    cn.Dispose();
                    return oLista;
                }
            }
        }
        public List<Exportacion2015> GetListaAfp_ExportacionExcel2015(string periodo, String Area_Ids, String Proyecto_Ids, String CCosto_Ids) //@001 I/F
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_EstructuraAfp_Excel_2015", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    //@001 I
                    cmd.Parameters.AddWithValue("@Area_Ids", Area_Ids);
                    cmd.Parameters.AddWithValue("@Proyecto_Ids", Proyecto_Ids);
                    cmd.Parameters.AddWithValue("@CCosto_Ids", CCosto_Ids);
                    //@001 F
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Exportacion2015> oLista = new List<Exportacion2015>();
                    while (dr.Read())
                    {
                        Exportacion2015 exp = new Exportacion2015();
                        exp.NSecuencia = dr.GetValue(0).ToString();
                        exp.CUSPP = dr.GetValue(1).ToString();
                        exp.nDocumento = dr.GetValue(2).ToString();
                        exp.apePar = dr.GetValue(3).ToString();
                        exp.apeMar = dr.GetValue(4).ToString();
                        exp.Nombre = dr.GetValue(5).ToString();
                        //exp.tipoMov = dr.GetValue(6).ToString();
                        //exp.fechMov = dr.GetValue(7).ToString();
                        exp.rl = dr.GetValue(6).ToString();
                        exp.irl = dr.GetValue(7).ToString();
                        exp.crl = dr.GetValue(8).ToString();
                        exp.eap = dr.GetValue(9).ToString();
                        exp.valor = double.Parse(dr.GetValue(10).ToString());
                        exp.M_APOVOL = double.Parse(dr.GetValue(11).ToString());
                        exp.M_APOLVOLS = double.Parse(dr.GetValue(12).ToString());
                        exp.M_APOEMPL = double.Parse(dr.GetValue(13).ToString());
                        exp.Rubro = dr.GetValue(14).ToString();
                        exp.Datos_afp = dr.GetValue(15).ToString();
                        exp.TDoc = dr.GetValue(16).ToString();
                        exp.CodRegimenAFP = dr.GetValue(17).ToString(); //@002 I/F
                        oLista.Add(exp);
                    }
                    cn.Close();
                    cn.Dispose();
                    return oLista;
                }
            }
        }
        #region Metodos Plame

        //Clase Estructura
        public class EstructuraPlame
        {
            public int ms_ms_EstructuraPlame_Estructura { get; set; }
            public string ms_ms_EstructuraPlame_Descripcion { get; set; }
            public int ms_EstructuraPlame_Id { get; set; }
            public EstructuraPlame(int estructura, string descripcion, int id)
            {
                this.ms_ms_EstructuraPlame_Estructura = estructura;
                this.ms_ms_EstructuraPlame_Descripcion = descripcion; this.ms_EstructuraPlame_Id = id;
            }
        }

        //Metodo Para Listar Todas las Estructuras del Plame
        public List<EstructuraPlame> GetListaPlame_Listar()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spu_EstructuraPlame_Mostrar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<EstructuraPlame> oLista = new List<EstructuraPlame>();
                    while (dr.Read())
                    {
                        EstructuraPlame es = new EstructuraPlame(int.Parse(dr.GetValue(0).ToString()), dr.GetValue(1).ToString(), int.Parse(dr.GetValue(2).ToString()));
                        oLista.Add(es);
                    }
                    cn.Close();
                    cn.Dispose();
                    return oLista;
                }
            }
        }

        //Metodo Para Buscar la Extension de una de las Estructuras del Plame
        public string GetListaPlame_BuscarExtension(string idPlame)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spu_EstructuraPlame_BuscarExtension", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@ms_EstructuraPlame_Id", idPlame);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        tabla.Clear();
                        da.Fill(tabla);
                        cn.Close();
                        cn.Dispose();
                        return tabla.Rows[0][0].ToString();
                    }

                }
            }
        }

        //Metodo para Exportar el plame Estructura 14 
        public List<string> GetListaPlame_Exportacion_DatosJornada(string periodo)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spu_ms_Plame_Estructura14_2", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.CommandTimeout = 60; /*1 minuto*/
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> oLista = new List<string>();
                    while (dr.Read())
                    {
                        oLista.Add(dr.GetString(0).ToString());
                    }
                    cn.Close();
                    cn.Dispose();
                    return oLista;
                }
            }
        }

        //Metodo Para Exportar el Plame Estructura 18
        public List<string> GetListaPlame_Exportacion_DetalleIngreso(string periodo)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spu_ms_Plame_Estructura18", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@periodo", periodo);
                    cmd.CommandTimeout = 60; /*1 minuto*/
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> oLista = new List<string>();
                    while (dr.Read())
                    {
                        oLista.Add(dr.GetString(0).ToString());
                    }
                    cn.Close();
                    cn.Dispose();
                    return oLista;
                }
            }
        }



        //Metodo Para Exportar el Plame Estructura 25
        public List<string> GetListaPlame_Exportacion_DetalleDescanso(string periodo)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spu_ms_Plame_Estructura15", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@periodo", periodo);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> oLista = new List<string>();
                    while (dr.Read())
                    {
                        oLista.Add(dr.GetString(0).ToString());
                    }
                    cn.Close();
                    cn.Dispose();
                    return oLista;
                }
            }
        }
        /// <summary>
        /// Suma los totales del gridview
        /// </summary>
        /// <param name="periodo"></param>
        /// <returns></returns>
        public string GetSumaAsientos_PorProceso_MS(string periodo,string proceso, int columna)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spu_AsientosContablesAgrupadosGlosa_Contable_MS_Suma", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@periodo", periodo);
                    cmd.Parameters.AddWithValue("@proceso_id", proceso);
                    cmd.Parameters.AddWithValue("@columna", columna);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                        DataTable tabla = new DataTable();
                        tabla.Clear();
                        da.Fill(tabla);
                        cn.Close();
                        cn.Dispose();
                        if(tabla.Rows.Count>0)
                        return tabla.Rows[0][0].ToString();
                        return "0";
                    }

                }
            }
        }

        /// <summary>
        /// Lista de ExportaAsientos MICHAEL
        /// </summary>
        /// <param name="periodo"></param>
        /// <param name="proceso"></param>
        /// <returns></returns>
        public List<asientoExporta>GetExportaAsientos_PorProceso_MS(string periodo, string proceso){
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String())) {
                using (SqlCommand cmd = new SqlCommand("spu_AsientosContablesAgrupadosGlosa_Contable_MS", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@periodo", periodo);
                    cmd.Parameters.AddWithValue("@proceso_id", proceso);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<asientoExporta> oLista = new List<asientoExporta>();
                    while (dr.Read()) {
                        asientoExporta objAsiento = new asientoExporta();
                        objAsiento.Periodo_Id = dr.GetValue(0).ToString();
                        objAsiento.Planilla = dr.GetValue(1).ToString();
                        objAsiento.Proceso = dr.GetValue(2).ToString();
                        objAsiento.Personal_Id = dr.GetValue(3).ToString();
                        objAsiento.Trabajador = dr.GetValue(4).ToString();
                        objAsiento.CuentaContable = dr.GetValue(5).ToString();
                        objAsiento.CentroCosto = dr.GetValue(6).ToString();
                        objAsiento.Dni = dr.GetValue(7).ToString();
                        objAsiento.Glosa = dr.GetValue(8).ToString();
                        objAsiento.Cargo = double.Parse(dr.GetValue(9).ToString());
                        objAsiento.Abono = double.Parse(dr.GetValue(10).ToString());
                        //20180731
                        objAsiento.EJERCICIO = dr.GetValue(11).ToString();
                        objAsiento.SUBDIARIO = dr.GetValue(12).ToString();
                        objAsiento.COMPROBANTE = dr.GetValue(13).ToString();
                        objAsiento.FECHADOC = dr.GetValue(14).ToString();
                        objAsiento.TIPO_ANEXO = dr.GetValue(15).ToString();
                        objAsiento.CODIGO_ANEXO = dr.GetValue(16).ToString();
                        objAsiento.TIPO_DOC = dr.GetValue(17).ToString();
                        objAsiento.NRO_DOC = dr.GetValue(18).ToString();
                        objAsiento.FECHA_VENC = dr.GetValue(19).ToString();
                        objAsiento.MONEDA = dr.GetValue(20).ToString();
                        objAsiento.CONV = dr.GetValue(21).ToString();
                        objAsiento.FECHA_REG = dr.GetValue(22).ToString();
                        objAsiento.TC = dr.GetValue(23).ToString();
                        objAsiento.GLOSA2 = dr.GetValue(24).ToString();
                        objAsiento.DOC_ANULADO = dr.GetValue(25).ToString();
                        objAsiento.DH = dr.GetValue(26).ToString();
                        objAsiento.MED_PAGO = dr.GetValue(27).ToString();
                        objAsiento.NRO_FILE = dr.GetValue(28).ToString();
                        objAsiento.FLUJO_EFEC = dr.GetValue(29).ToString();
                        objAsiento.MONTO = double.Parse(dr.GetValue(30).ToString());
                        oLista.Add(objAsiento);
                    }
                    cn.Close();
                    cn.Dispose();
                    return oLista;
                }
            }
        }


        public DataTable GetExportaProviciones_MS(string periodo, string proceso,string provicion)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_AsientosContablesResumenGlosa_Contable_MS2", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@periodo", periodo);
                    cmd.Parameters.AddWithValue("@proceso_id", proceso);
                    cmd.Parameters.AddWithValue("@elProcesoProvicion", provicion);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                        DataTable tabla = new DataTable();
                        tabla.Clear();
                        da.Fill(tabla);
                        cn.Close();
                        cn.Dispose();
                        return tabla;
                    }
                }
            }
        }
        //20180617
        public string GetNroRucEmpresa(string compania)
        {
            string ruc = "";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT RUC FROM COMPANIA WHERE COMPANIA_ID=@COMPANIA_ID", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@COMPANIA_ID", compania);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        ruc = dr.GetValue(0).ToString();
                    }
                    return ruc;
                }
            }
        }
        public string GetMesPorPeriodo(string periodo)
        {
            string valor = "";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT MONTH(FECHA_INI) [A] FROM PERIODO WHERE PERIODO_ID=@PERIODO_ID", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO_ID", periodo);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        valor = dr.GetValue(0).ToString();
                    }
                    return valor;
                }
            }
        }

        #endregion

    }


    #region misClases
    [Serializable]
    public class asientoExporta
    {
        public string Periodo_Id { get; set; }
        public string Planilla { get; set; }
        public string Proceso { get; set; }
        public string Personal_Id { get; set; }
        public string Trabajador { get; set; }
        public string CuentaContable { get; set; }
        public string CentroCosto { get; set; }
        public string Dni { get; set; }
        public string Glosa { get; set; }
        public double Cargo { get; set; }
        public double Abono { get; set; }
        /* 20180731 */
        public string EJERCICIO { get; set; }
        public string SUBDIARIO { get; set; }
        public string COMPROBANTE { get; set; }
        public string FECHADOC { get; set; }
        public string TIPO_ANEXO { get; set; }
        public string CODIGO_ANEXO { get; set; }
        public string TIPO_DOC { get; set; }
        public string NRO_DOC { get; set; }
        public string FECHA_VENC { get; set; }
        public string MONEDA { get; set; }
        public string CONV { get; set; }
        public string FECHA_REG { get; set; }
        public string TC { get; set; }
        public string GLOSA2 { get; set; }
        public string DOC_ANULADO { get; set; }
        public string DH { get; set; }
        public string MED_PAGO { get; set; }
        public string NRO_FILE { get; set; }
        public string FLUJO_EFEC { get; set; }
        public double MONTO { get; set; }
    }
    #endregion

}

    
 


