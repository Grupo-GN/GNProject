using CAPA_DATOS.oRRHH;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.RRHH
{
    public partial class FrmContratoNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static ArrayList ListaTipoPlanilla()
        {
            return controllerContratoNuevo.getInstance().ListaTipoPlanilla();
        }
        [WebMethod]
        public static ArrayList ListaPeriodo(string EjercicioId, string Planilla_Id, string MesId)
        {
            return controllerContratoNuevo.getInstance().ListaPeriodo(EjercicioId, Planilla_Id, MesId);
        }
        [WebMethod]
        public static ArrayList ListaBanco()
        {
            return controllerContratoNuevo.getInstance().ListaBanco();
        }
        [WebMethod]
        public static ArrayList ListaRegPensionario()
        {
            return controllerContratoNuevo.getInstance().ListaRegPensionario();
        }
        [WebMethod]
        public static ArrayList ListaEstadoCivil()
        {
            return controllerContratoNuevo.getInstance().ListaEstadoCivil();
        }
        [WebMethod]
        public static ArrayList ListaTipoContrato()
        {
            return controllerContratoNuevo.getInstance().ListaTipoContrato();
        }
        [WebMethod]
        public static ArrayList ListaCargo()
        {
            return controllerContratoNuevo.getInstance().ListaCargo();
        }
        [WebMethod]
        public static ArrayList getFuncionesxCargo(String Cargo_Id)
        {
            String Personal_Id = "";
            return CAPA_LOGICO.Log_Cargo_Funciones.getFuncionesxCargo(Personal_Id, Cargo_Id);
        }
        [WebMethod]
        public static ArrayList ListaArea()
        {
            return controllerContratoNuevo.getInstance().ListaArea();
        }
        [WebMethod]
        public static ArrayList ListaCatAuxiliar()
        {
            return controllerContratoNuevo.getInstance().ListaCatAuxiliar();
        }
        [WebMethod]
        public static ArrayList ListaCatAuxiliar2(string xCatAuxiliar)
        {
            return controllerContratoNuevo.getInstance().ListaCatAuxiliar2(xCatAuxiliar);
        }
        [WebMethod]
        public static ArrayList ListarCombos(string xOp, string xCodigo)
        {
            return controllerContratoNuevo.getInstance().ListarCombos(xOp, xCodigo);
        }
        [WebMethod]
        public static ArrayList ListaSeguroMedico()
        {
            return controllerContratoNuevo.getInstance().ListaSeguroMedico();
        }
        [WebMethod]
        public static string GuardarPersonalNuevo(string Planilla_Id, string Periodo_Id, string Fecha_ingreso,
        string Fecha_ini_contrato, string Fecha_fin_contrato, string Cargo_Id, string Afp_Id
        , string Direccion, string Nro_cta, string Banco_cta_Id, string Nro_cta_cts, string Banco_cta_cts_Id
        , string Observaciones, string Area_Id, string Categoria2_Id, string Tipo_Contrato_Id, string Seguro_Medico_Id
        , string Categoria_Auxiliar_Id, string Categoria_Auxiliar2_Id, DateTime Fecha_Nacimiento, string ECivil
        , string Apellido_Paterno, string Apellido_Materno, string Nombres, string Telefono, string Telefono2, string Telefono3
        , string CorreoCorp, string CorreoPer, string NroDoc, string CUSP, int NroHijos
        , string Alergias, string CodigoSap, string CodigoSapDeudor, string JefeId, string GerenteId, string CoodinadorId
        , decimal Sueldo, decimal Movilidad, decimal ValeAlimento, String Cargo_Funcion_Ids)
        {
            return controllerContratoNuevo.getInstance().GuardarPersonalNuevo(Planilla_Id, Periodo_Id, Fecha_ingreso, Fecha_ini_contrato, Fecha_fin_contrato
            , Cargo_Id, Afp_Id, Direccion, Nro_cta, Banco_cta_Id, Nro_cta_cts, Banco_cta_cts_Id
            , Observaciones, Area_Id, Categoria2_Id
            , Tipo_Contrato_Id, Seguro_Medico_Id, Categoria_Auxiliar_Id
            , Categoria_Auxiliar2_Id, Fecha_Nacimiento, ECivil
            , Apellido_Paterno, Apellido_Materno, Nombres, Telefono, Telefono2, Telefono3
            , CorreoCorp, CorreoPer, NroDoc, CUSP, NroHijos
            , Alergias, CodigoSap, CodigoSapDeudor, JefeId, GerenteId, CoodinadorId
            , Sueldo, Movilidad, ValeAlimento, Cargo_Funcion_Ids);
        }

    }
}