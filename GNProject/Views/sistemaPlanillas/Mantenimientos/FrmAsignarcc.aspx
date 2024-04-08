<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmAsignarcc.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmAsignarcc" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleWilder.css" rel="stylesheet" type="text/css" />
    <fieldset style="width:100%; background-color: White; margin: 0px 0px 0px 0px;border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">
        <fieldset>
        <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
            <table width="100%">
                <tr>
                    <td style="width:90%;">
                        <asp:Label ID="Label9" runat="server" Text="ASIGNACIÓN DE CENTROS DE COSTO" CssClass="miTitulo" Width="300px"></asp:Label>
                    </td>                  
                    <td style="text-align:right;width:28px;"><input type="button" class="elBotonCancel" id="btnCancel" value="Cancelar" title="Para Cancelar la Informacion" /></td>
                    <td style="text-align:right;width:28px;"><input type="button" class="elBotonUpdate" id="btnUpdate" value="Actualizar" title="Para Modificar el Registro" /></td>
                </tr>
            
            </table>
        </fieldset>
    <div id="TabContainer" style="min-height:415px;width:100%;">
        <ul>
            <li><a href="#Tab1">Lista</a></li>
            <li><a href="#Tab2">Asignar</a></li>
            <li><a href="#Tab3">Importar</a></li>
        </ul>
        <div id="Tab1">
        <fieldset>
            <legend>BUSQUEDA</legend>
            <label class="miLabel">Localidad</label>
            <select id="cboLocalidad" class="ddl"></select>
            <label class="miLabel">Proyecto</label>
            <select id="cboProyecto" class="ddl"></select>
            <label class="miLabel">Área:</label>
            <select id="cboArea" class="ddl"></select>
            <label class="miLabel">Buscar:</label>
            <input type="text" class="ddl" id="txtBuscar" />
        </fieldset>
        <div  style="overflow: hidden; width: 100%; border: solid 1px #505050;min-height: 260px;">
            <table class="gridSmall" style="width:100%;">
                <thead>
                    <tr>
                        <th></th>
                        <th>ID</th>
                        <th>AP. PATERNO</th>
                        <th>AP. MATERNO</th>
                        <th>NOMBRES</th>
                        <th>TIPO DOC</th>
                        <th>NRO. DOC</th>
                        <th>LOCALIDAD</th>
                        <th>PROYECTO</th>
                        <th>ÁREA</th>
                        <th>CC. ID</th>
                        <th>CCOSTO</th>
                        <th>%</th>
                    </tr>
                </thead>
                <tbody id="tbodyPersonal" class="tbodyPer">            

                </tbody>
            </table>
        </div>
        <div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
            <table class="table">
                <tfoot>
                    <tr>
                        <td class="tfoottd"  colspan="3">
                            <label style="font-family: 'Droid Sans', 'Trebuchet MS', Helvetica, Arial, sans-serif; font-weight: bold; font-size: 1.1em;" >TOTAL REGISTROS: </label> &nbsp
                            <input id="txtnRegistros" type="text" value="0" class="TextPage" readonly="true" /> &nbsp &nbsp
                            <label style="font-family: 'Droid Sans', 'Trebuchet MS', Helvetica, Arial, sans-serif; font-weight: bold; font-size: 1.1em;" >PAGE: </label> &nbsp
                            <input id="txtPaginaActual" type="text" value="1" class="TextPage" readonly="true" />
                            <input id="btnPrimero" type="button" value="|<" class="submitPager" />
                            <input id="btnAnterior" type="button" value="<<" class="submitPager" />
                            <input id="btnSiguiente" type="button" value=">>" class="submitPager" />
                            <input id="btnUltimo" type="button" value=">|" class="submitPager"/>
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
        </div>
        <div id="Tab2">
            <input type="hidden" id="idPlanilla" />
            <input type="hidden" id="idPersonal" />
            <input type="hidden" id="idPeriodo" />
            <fieldset>
                <table style="border-collapse:collapse;width:100%;">
                    <tr>
                        <td>Personal:</td>
                        <td><label id="lblpersonal"></label></td>
                        <td>&nbsp;</td>
                        <td>Centro de Costo:</td>
                        <td><select id="cboCCosto" class="ddl"></select></td>
                        <td><img id="btnAgregar" src="../Icon/add.gif" style="cursor:pointer;" /> </td>
                    </tr>
                </table>
            </fieldset>
            <table class="gridSmall" style="width:100%;">
                <thead>
                    <tr>
                        <th></th>
                        <th>CCOSTOID</th>
                        <th>CCOSTO</th>
                        <th>PORCENTAJE <label id="lblTPor"></label></th>
                    </tr>
                </thead>
                <tbody id="tbodyDetalle" class="tbodyPer">            
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div id="Tab3">
        <table style="border-collapse:collapse;">
            <tr>
                <td><input type="file" id="file-input" /></td>
                <td><input type="button" class="submit" id="btnGuardarImport" value="Guardar CCosto" /></td>
                <td><a href="Files/ImportCCosto.xlsm" class="lbl" target="_blank" style="color:Blue;">Descargar Generador</a></td>
                <td></td>
            </tr>
        </table>
            <table class="gridSmall" style="width:100%;">
                <thead>
                    <tr>
                        <th>PERSONAL</th>
                        <th>NRO. DOC</th>
                        <th>PLANILLA</th>
                        <th>EJERCICIO</th>
                        <th>MES</th>
                        <th>PERIODO</th>
                        <th>CCOSTO ID</th>
                        <th>CCOSTO</th>
                        <th>TIPO</th>
                        <th>%</th>
                        <th>RESULTADO</th>
                    </tr>
                </thead>
                <tbody id="tbodyImport" class="tbodyPer">            

                </tbody>
            </table>
        </div>
    </div>
    </fieldset>
    <div id="divError"></div>
    
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="../jqueriUI/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/ScriptAsignarcc.js"></script>
    <script type="text/javascript">
       $(document).ready(initilize);
    </script>
</asp:Content>

