using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_DATOS;
using System.Data;

namespace CAPA_LOGICO
{
    public class InterfacesBL
    {
        public DataTable GetInterfaces(int Tipo)
        {
            return InterfacesDA.Create().GetInterfaces(Tipo);
        }
        public DataTable GetInterface(int Interface_ID)
        {
            return InterfacesDA.Create().GetInterface(Interface_ID);
        }
        public DataTable GetInterface1(string Compania_ID)
        {
            return InterfacesDA.Create().GetInterface1(Compania_ID);
        }
        public DataTable GetInterface2(string Periodo_Id)
        {
            return InterfacesDA.Create().GetInterface2(Periodo_Id);
        }

        public DataTable GetInterface2_1(string Periodo_Id)
        {
            return InterfacesDA.Create().GetInterface2_1(Periodo_Id);
        }

        public DataTable GetInterface3(string Periodo_Id)
        {
            return InterfacesDA.Create().GetInterface3(Periodo_Id);
        }
        public DataTable GetInterface4(string Periodo_Id)
        {
            return InterfacesDA.Create().GetInterface4(Periodo_Id);
        }
        public DataTable GetInterface5(string Periodo_Id, string codigo)
        {
            return InterfacesDA.Create().GetInterface5(Periodo_Id, codigo);
        }
        public DataTable GetInterface6(string Periodo_Id)
        {
            return InterfacesDA.Create().GetInterface6(Periodo_Id,""); //Prametro Codigo vaciooo
        }
        public DataTable GetInterface9(string Periodo_Id)
        {
            return InterfacesDA.Create().GetInterface9(Periodo_Id);
        }
        public DataTable GetInterface10(string Periodo_Id)
        {
            return InterfacesDA.Create().GetInterface10(Periodo_Id);
        }
        public DataTable GetInterface11(string Periodo_Id)
        {
            return InterfacesDA.Create().GetInterface11(Periodo_Id);
        }

        #region mantenimientoMichael
        /// <summary>
        /// metodo LLamando ala Interface 17
        /// </summary>
        /// <param name="Periodo_Id"></param>
        /// <returns></returns>
        public DataTable GetInterface17(string Periodo_Id)
        {
            return InterfacesDA.Create().GetInterface17(Periodo_Id);
        }
 
        public DataTable GetInterfaceTelecreditos(
            string cia, string periodo, string concepto, string moneda, string planilla,
            string fechaInicial, string fechaFinal, string codigo)
        {
            return InterfacesDA.Create().GetInterfaceTelecredito(cia, periodo, concepto, moneda, 
                planilla, fechaInicial,fechaFinal, codigo);
        }

        /// <summary>
        /// Metodo Llamando ala Interace 23
        /// </summary>
        /// <param name="Periodo_Id"></param>
        /// <returns></returns>
        public DataTable GetInterface23(string Periodo_Id)
        {
            return InterfacesDA.Create().GetInterface23(Periodo_Id);
        }

        #endregion

    }
}
