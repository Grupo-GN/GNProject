using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_ENTIDAD.EntMs;
using System.Data;

/// <summary>
/// @001 FPS 30/03/2020 - Se agrega filtro Proyecto
/// </summary>

namespace CAPA_LOGICO
{
    public class InterfacesExportacion
    {

        #region elPlame

        //Metodo Para Listar Todas las Estructuras del Plame
        public List<CAPA_DATOS.ControllerInterfacesExp.EstructuraPlame> GetListaPlame_Listar() {
            CAPA_DATOS.ControllerInterfacesExp u = new CAPA_DATOS.ControllerInterfacesExp();
            return u.GetListaPlame_Listar();
        }
        //Metodo Para Buscar la Extension de una de las Estructuras del Plame
        public string GetListaPlame_BuscarExtension(string idPlame) {
            CAPA_DATOS.ControllerInterfacesExp u = new CAPA_DATOS.ControllerInterfacesExp();
            return u.GetListaPlame_BuscarExtension(idPlame);
        }
        //Metodo para Exportar el plame Estructura 14
        public List<string> GetListaPlame_Exportacion_DatosJornada(string periodo) { 
            CAPA_DATOS.ControllerInterfacesExp u = new CAPA_DATOS.ControllerInterfacesExp();
            return u.GetListaPlame_Exportacion_DatosJornada(periodo);
        }
        //Metodo Para Exportar el Plame Estructura 18
        public List<string> GetListaPlame_Exportacion_DetalleIngreso(string periodo)
        {
            CAPA_DATOS.ControllerInterfacesExp u = new CAPA_DATOS.ControllerInterfacesExp();
            return u.GetListaPlame_Exportacion_DetalleIngreso(periodo);
        }

        public List<string> GetListaPlame_Exportacion_Descanso(string periodo)
        {
            CAPA_DATOS.ControllerInterfacesExp u = new CAPA_DATOS.ControllerInterfacesExp();
            return u.GetListaPlame_Exportacion_DetalleDescanso(periodo);
        }
        #endregion

        public List<string> GetListaAfp_Exportacion(string periodo)
        {
            CAPA_DATOS.ControllerInterfacesExp u = new CAPA_DATOS.ControllerInterfacesExp();
            return u.GetListaAfp_Exportacion(periodo);
        }

        public List<Exportacion> GetListaAfp_ExportacionExcel(string periodo) {
            CAPA_DATOS.ControllerInterfacesExp u = new CAPA_DATOS.ControllerInterfacesExp();
            return u.GetListaAfp_ExportacionExcel(periodo);
        }
        public List<Exportacion2015> GetListaAfp_ExportacionExcel2015(string periodo, String Area_Ids, String Proyecto_Ids, String CCosto_Ids) //@001 I/F
        {
            CAPA_DATOS.ControllerInterfacesExp u = new CAPA_DATOS.ControllerInterfacesExp();
            return u.GetListaAfp_ExportacionExcel2015(periodo, Area_Ids, Proyecto_Ids, CCosto_Ids); //@001 I/F
        }

        public List<Moneda> GetMonedas_Exportacion()
        {
            CAPA_DATOS.ControllerInterfacesExp u = new CAPA_DATOS.ControllerInterfacesExp();
            return u.Monedas_GetMostrar();
        }

        //20180617
        public string GetNroRucEmpresa(string compania)
        {
            CAPA_DATOS.ControllerInterfacesExp u = new CAPA_DATOS.ControllerInterfacesExp();
            return u.GetNroRucEmpresa(compania);
        }
        public string GetMesPorPeriodo(string periodo)
        {
            CAPA_DATOS.ControllerInterfacesExp u = new CAPA_DATOS.ControllerInterfacesExp();
            return u.GetMesPorPeriodo(periodo);
        }

        #region exportarAsientos

        public string GetSumaAsientos_PorProceso_MS(string periodo, string proceso, int columna) {
            CAPA_DATOS.ControllerInterfacesExp u = new CAPA_DATOS.ControllerInterfacesExp();
            return u.GetSumaAsientos_PorProceso_MS(periodo, proceso, columna);
        }

        public List<CAPA_DATOS.asientoExporta> GetExportaAsientos_PorProceso_MS(string periodo, string proceso)
        {
            CAPA_DATOS.ControllerInterfacesExp u = new CAPA_DATOS.ControllerInterfacesExp();
            return u.GetExportaAsientos_PorProceso_MS(periodo, proceso);
        }

        public DataTable GetExportaProviciones_PorProceso_MS(string periodo, string proceso, string provicion) {
            CAPA_DATOS.ControllerInterfacesExp u = new CAPA_DATOS.ControllerInterfacesExp();
            return u.GetExportaProviciones_MS(periodo, proceso, provicion);
        }

        #endregion


    }
}
