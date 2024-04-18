<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmContratoNuevo.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.RRHH.FrmContratoNuevo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
        <input type="hidden" id="anioSession" value="<%= Session["anioPlanilla"] %>" />
    <input type="hidden" id="mesSession" value="<%= Session["mesPlanilla"] %>" />
    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    <div>
        <div style="border: 1px solid #ccc;">
            <table width="100%">
                <tr>
                    <td style="width:90%;">
                        <asp:Label ID="Label9" runat="server" Text="FICHA DE CONDICIONES" CssClass="title" Width="300px"></asp:Label>
                    </td>
                    <td style="text-align:right;width:28px;"><input type="button" class="elBotonNew" id="btnNew" value="Nuevo" title="Para Agregar un Nuevo Registro" /></td>
                    <td style="text-align:right;width:28px;"><input type="button" class="elBotonAdd" id="btnAdd" value="Grabar" title="Para Grabar un Nuevo Registro" /></td>
                </tr>            
            </table>
        </div>
        <table style="border-collapse:collapse;width:100%;visibility:hidden;">
            <tr>
                <td><label class="miLabel">Planilla: </label></td>
                <td><select id="cboPlanilla"></select></td>
                <td><label class="miLabel">Periodo: </label></td>
                <td><select id="cboPeriodo"></select></td>
            </tr>
        </table>
        <label class="miLabelError" id="lblError" style="font-size:14px;" ></label>
        <table style="border-collapse:collapse;width:100%;">
            <tr>
                <td style="width:150px;text-align:right;">Nombres:</td>
                <td><input type="text" id="txtNombre" class="ddl"/></td>
                <td style="text-align:right;">Apellido Paterno:</td>
                <td><input type="text" id="txtApePaterno" class="ddl"/></td>
                <td style="text-align:right;">Apellido Materno:</td>
                <td><input type="text" id="txtApeMaterno" class="ddl"/></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;">Dirección:</td>
                <td colspan="3"><input type="text" style="width:70%;" id="txtDireccion" class="ddl"/></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;">Teléfono:</td>
                <td><input type="text" id="txtTelf" class="ddl"/></td>
                <td style="text-align:right;">Celular:</td>
                <td><input type="text" id="txtTelf2" class="ddl"/></td>
                <td style="text-align:right;">Telf. Emergencia:</td>
                <td><input type="text" id="txtTelf3" class="ddl"/></td>
                <td></td>
            </tr>

            <tr>
                <td style="text-align:right;">Contacto:</td>
                <td><input type="text" id="txtContacto" class="ddl"/></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;">Email Corporativo:</td>
                <td><input type="text" id="txtEmail" class="ddl"/></td>
                <td style="text-align:right;">Email Personal:</td>
                <td><input type="text" id="txtemailp" class="ddl"/></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;">Fecha de Nac:</td>
                <td><input type="text" id="txtFecNacim" class="ddl"/></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;">DNI:</td>
                <td><input type="text" id="txtNroDoc" class="ddl"/></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;">Banco Cta de Haberes:</td>
                <td><select id="cboBanco" class="ddl" style="width:200px;"></select></td>
                <td style="text-align:right;">Nro. Cta. S/. $:</td>
                <td><input type="text" id="txtNroCuenta" class="ddl"/></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;">Banco CTS:</td>
                <td><select id="cboBancoCTS" class="ddl" style="width:200px;"></select></td>
                <td style="text-align:right;">Nro. Cta. CTS:</td>
                <td><input type="text"id="txtNroCuentaCTS" class="ddl"/></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;">AFP (CUSP):</td>
                <td><select id="cboRegPensionario" class="ddl" style="width:200px;"></select></td>
                <td style="text-align:right;">CUSP:</td>
                <td><input type="text" id="txtCUSP" class="ddl"/></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;">Estado Civil:</td>
                <td><select id="cboECivil" class="ddl" style="width:200px;"></select></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;"># de hijos:</td>
                <td><input type="text" id="txtNumHijos" class="ddl"/></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;">Alergias:</td>
                <td><input type="text" id="txtAlergias" class="ddl"/></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;">Codigo SAP:</td>
                <td><input type="text" id="txtCodSAP" class="ddl"/></td>
                <td>Codigo SAP - Deudor:</td>
                <td><input type="text" id="txtSAPDeudor" class="ddl"/></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <br />
        <fieldset>
            &nbsp;
            <table style="border-collapse:collapse;width:100%;">
                <tr>
                    <td style="text-align:right;">FECHA DE INGRESO:</td>
                    <td><input type="text" id="txtFecIngreso" class="ddl"/></td>
                    <td style="text-align:right;">FECHA INICIO CONTRATO: </td>
                    <td><input type="text" id="txtFecIniContrato" class="ddl"/></td>
                    <td style="text-align:right;">FECHA FIN CONTRATO:</td>
                    <td><input type="text" id="txtFecFinContrato" class="ddl"/></td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            &nbsp;
            <table style="border-collapse:collapse;width:100%;">
                <tr>
                    <td style="text-align:right;">Tipo de Contrato:</td>
                    <td><select id="cboTipoContrato" class="ddl" style="width:200px;"></select></td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            &nbsp;
            <table style="border-collapse:collapse;width:100%;">
                <tr>
                    <td style="text-align:right;">Puesto</td>
                    <td><select id="cboCargo" class="ddl" style="width:200px;"></select></td>
                    <td style="text-align:right;">Departamento</td>
                    <td><select id="cboArea" class="ddl" style="width:200px;"></select></td>
                    <td style="text-align:right;">Sueldo M.N.X U$ quincenal</td>
                    <td><input type="text" id="txtBruto" class="ddl"/></td>
                </tr>
                <tr>
                    <td style="text-align:right;">Area</td>
                    <td><select id="cboCatAuxiliar" class="ddl" style="width:200px;"></select></td>
                    <td style="text-align:right;">Sección</td>
                    <td><select id="cboCatAuxiliar2" class="ddl" style="width:200px;"></select></td>
                    <td style="text-align:right;">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align:right;">Jefe</td>
                    <td><select id="cboJefe" class="ddl" style="width:200px;"></select></td>
                    <td style="text-align:right;">Coordinador</td>
                    <td><select id="cboCoodinador" class="ddl" style="width:200px;"></select></td>
                    <td style="text-align:right;">Gerente</td>
                    <td><select id="cboGerente" class="ddl" style="width:200px;"></select></td>
                </tr>
                <tr>
                    <td colspan="2">Asignar funciones <input id="chkAsigFunciones" type="checkbox" /></td>
                    <td colspan="3" id="tdFunciones" style="display:none;"><select id="cboFunciones" style="width:100%;"></select></td>
                    <td></td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            &nbsp;
            <table style="border-collapse:collapse;width:100%;">
                <tr>
                    <td colspan="2">Beneficios Adicionales <br /> De acuerdo a ley  </td>
                    <td style="text-align:right;">Seguro Médico</td>
                    <td><select id="cboSeguroMedico" class="ddl" style="width:200px;"></select></td>
                    <td style="text-align:right;">Condición</td>
                    <td><input type="radio" value="01" id="rbnsujeto" name="suj" /><label>No Sujeto a Fiscalización</label><br /> <input type="radio" id="rbsujeto" name="suj" value="02" checked="checked"/><label>Sujeto a Fiscalización</label></td>
                </tr>
                <tr>
                    <td style="text-align:right;">Movilidad:</td>
                    <td><input type="text" id="txtMovilidad" class="ddl" /></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align:right;">Vale Alimento:</td>
                    <td><input type="text" id="txtValeAlimento" class="ddl"/></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            <table style="border-collapse:collapse;width:100%;">
                <tr>
                    <td colspan="6"> Herramientas de Trabajo</td>
                </tr>
                <tr>
                    <td style="text-align:right;">Celular:</td>
                    <td><input type="checkbox" id="ckCelular" class="ddl"/><label>SI/NO</label></td>
                    <td style="text-align:right;">Laptop:</td>
                    <td><input type="checkbox" id="ckLaptop" class="ddl"/><label>SI/NO</label></td>
                    <td style="text-align:right;">Otros:</td>
                    <td><input type="text" id="txtOtros" class="ddl"/></td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            <table style="border-collapse:collapse;width:100%;">
                <tr>
                    <td>Observaciones: </td>
                </tr>
                <tr>
                    <td><input type="text" id="txtObservaciones" class="ddl" /></td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            <table style="border-collapse:collapse;width:100%;">
                <tr>
                    <td>Firma del Trabajador:</td>
                    <td>&nbsp;</td>
                    <td>Fecha: </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            <table style="border-collapse:collapse;width:100%;">
                <tr>
                    <td colspan="6">Aprobado por:</td>
                </tr>
                <tr>
                    <td>Gerente de Area</td>
                    <td>&nbsp;</td>
                    <td>Subgerente de Personas</td>
                    <td>&nbsp;</td>
                    <td>Gerencia General</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Fecha:</td>
                    <td>&nbsp;</td>
                    <td>Fecha:</td>
                    <td>&nbsp;</td>
                    <td>Fecha:</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </fieldset>
    </div> 
    <div id="divError"></div>
    <script src="Scripts/Script_ContratoNuevo.js"></script>
    <script type="text/javascript">
        $(document).ready(initilize);
    </script>
</asp:Content>
