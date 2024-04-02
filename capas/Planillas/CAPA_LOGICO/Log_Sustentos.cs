using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_DATOS;
using System.Data;
using CAPA_ENTIDAD;
namespace CAPA_LOGICO
{
    public class Log_Sustentos
    {
        public static DataTable TipoPlanilla(string periodo)
        {
            try
            {
                return Dao_Sustentos.TipoPlanilla(periodo);
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
                return Dao_Sustentos.Lista_Campos_Personal();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CargaDT(string id,
                                    string conceptos,
                                    string personald,
                                    string conceptosID,
                                    int contC,
                                    int contP)
        {
            try
            {
                Dao_Sustentos.CargaDT(id, conceptos, personald, conceptosID, contC, contP);
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
                return Dao_Sustentos.ListDT();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Estructura()
        {
            try
            {
                Dao_Sustentos.Estructura();
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
                Dao_Sustentos.ClearDT();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SET_COMPATIBILITY_LEVEL(int level)
        {
            Dao_Sustentos.SET_COMPATIBILITY_LEVEL(level);
        }
        public static DataTable GenerarCalculo(Ent_Sustentos objEN)
        {
            try
            {
                return Dao_Sustentos.GenerarCalculo(objEN);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ListPlantillas()
        {
            try
            {
                return Dao_Sustentos.ListPlantillas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable BuscarPlantillas(Ent_Sustentos objEN)
        {
            try
            {
                return Dao_Sustentos.BuscarPlantillaSustento(objEN);
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
                return Dao_Sustentos.BuscarConcepto(objEN);
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
                return Dao_Sustentos.GetProcesoConcepto(objEN);
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
                return Dao_Sustentos.AllConceptos();
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
                return Dao_Sustentos.NuevaPlantilla(objEN);
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
                return Dao_Sustentos.ActualizaPlantilla(objEN);
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
                return Dao_Sustentos.EliminaPlantilla(objEN);
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
                return Dao_Sustentos.GetDetalleConcepto(Codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetConceptosByTipoDatoProcesoList(string Tipo, string Proceso)
        {
            try
            {
                return Dao_Sustentos.GetConceptosByTipoDatoProcesoList(Tipo, Proceso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
