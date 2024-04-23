<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master"  CodeBehind="GenerarDatosPersonal.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Procesos.GenerarDatosPersonal" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleWilder.css" rel="stylesheet" type="text/css" />
    <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;/*border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;*/min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; /*border-top: solid 1px black;*/">
    <br />   
          <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
        <input type="hidden" id="anioSession" value="<%= Session["anioPlanilla"] %>" />
    <div id="Tab1">
        <fieldset>
            <legend>BUSQUEDA</legend>
            <table style="border-collapse:collapse;width:100%;">
                <tr>
                    <td><label class="miLabel">Filtrar Por:</label></td>
                    <td><label class="miLabel">Digite la Persona a Buscar:</label></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td><select id="cboBusquedaEn" class="ddl" style="width:150px;"> </select></td>
                    <td><input type="text" class="miTextBox" id="txtBuscar" /></td>
                    <td></td>
                    <td>&nbsp;&nbsp;
                    </td>
                    <td></td>
                </tr>
                <tr>                    
                    <td>Datos a considerar para la generación:</td>
                    <td colspan="3">
                        <input type="checkbox" id="chkGDFijos" checked="checked" />D. Fijos&nbsp;
                        <input type="checkbox" id="chkGDVariables" checked="checked"/>D. Variables&nbsp;
                        <input type="checkbox" id="chkGDDirectos" checked="checked"/>D. Directos&nbsp;
                        <input type="checkbox" id="chkGAcumulativos" checked="checked"/>D. Acumulativos&nbsp;
                        <input type="checkbox" id="chkTodos"/><label>Generar para todo el Personal</label>
                    </td>
                    <td><input type="button" id="btnProcesar" class="submit EstiloGeneralBoton btn-nuevo" value="Generar Datos" />
                        <%--<input type="button" id="btnVer" class="submit" value="Ver Resultados" />--%>
                    </td>
                </tr>
            </table>
        </fieldset>
        <div  style="overflow: hidden; width: 100%; border: solid 1px #505050;height: 290px;">
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
                    <th>F. INGRESO</th>
                    <th>F. INI. CONTRATO</th>
                    <th>F. FIN</th>
                    <th>F. CESE</th>
                    <th>PROYECTO</th>       
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

                    <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; /*font-size: 1.1em;*/" >TOTAL REGISTROS: </label> &nbsp
                    <input id="txtnRegistros" type="text" value="0" class="TextPage" readonly="true" /> &nbsp &nbsp
                    <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; /*font-size: 1.1em;*/" >PAGE: </label> &nbsp
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
</fieldset>
        <div id="divresultado"  style="display:none;overflow:scroll;">
        <table class="gridSmall" style="width:100%;">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>APELLIDOS Y NOMBRES</th>
                    <th>TIPO DOC</th>
                    <th>NRO. DOC</th>
                    <th>RESULTADO DATOS FIJOS</th>
                    <th>RESULTADO DATOS VARIABLES</th>
                    <th>RESULTADO DATOS DIRECTOS</th>
                </tr>
            </thead>
            <tbody id="tbodyproceso" class="tbodyPer">
            
            
            </tbody>
        </table>
    </div>
    <div id="divError"></div>
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="../jqueriUI/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_GenerarDatosPersonal.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(initilize);
    </script>
</asp:Content>

