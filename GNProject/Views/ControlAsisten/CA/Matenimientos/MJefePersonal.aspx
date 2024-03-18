<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MJefePersonal.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.MJefePersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
        <link href="../../css/index.css" rel="stylesheet" />


    <label class="miTitulo">Jefe - Personal</label><br /><br />
    <%--pruebas--%>
    <fieldset>
        <legend class="miTituloField">Filtrar</legend>
        <table class="tableDialog">
            <tr>
                <td style="width:80px;text-align:right;"><label>Localidad : </label></td>
                <td><select id="cboLocalidad" class="cbo"></select></td>
                <td style="width:80px;text-align:right;"><label>Área : </label></td>
                <td><select id="cboArea" class="cbo"></select></td>
                <td style="width:80px;text-align:right;"><label>Sección : </label></td>
                <td><select id="cboSeccion" class="cbo"></select></td>
                <%--<td style="width:80px;text-align:right;"><label>Personal :</label></td>--%>
                <%--<td><input type="text" id="txtFind" class="txt" /></td>--%>
                 <td><input type="button" class="submit" value="Ver" onclick='getPersonal()' style="width:100px;" id="BtnListar" /></td>
            </tr>
        </table>
    </fieldset>
        <table class="tableDialog">
            <tr>
                <td style="width:100px;text-align:right;"><label>Gerente : </label></td>
                <td><select id="cbogerente" class="cbo" style="width: 120px;"></select></td>
                <td style="width: 120px;"><label>Jefe : </label></td>
                <td><select id="cbojefe" class="cbo" style:"width:100px !important;"><option value="">-SELECCIONE-</option></select></td>
                <td style="width:80px;text-align:right;"><label>Personal :</label></td>
                <td><input type="text" id="txtFind" class="txt" /></td>
                <%--pruebas    &nbsp;<input type="button" class="submit" value="Asignar Gerente" style="width:120px;" id="btnAply1" />--%>
                <td colspan="2"><input type="button" class="submit" value="Asignar Personal" style="width:120px;" id="btnAply2" /></td>
            </tr>
        </table>
        <hr />
        <table id="tblAH" class="table">
            <thead>
                <tr>
                    <th><input type="checkbox" id="chkAll" /></th>
                    <th>Planilla</th>
                    <th>Localidad</th>
                    <th>Personal</th>
                    <th>Area</th>
                    <th>Seccion</th>
                    <th>Gerente</th>
                    <th>Jefe</th>
                </tr>
            </thead>
            <tbody id="tbodydata"></tbody>
        </table>
       
    <br />
 <div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
        <table class="table">
            <tfoot style:"background:#0c4d7e;">
                <tr>
                    <td class="tfoottd" colspan="3">
                        <div id="indicador_paginas"></div>
                        <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;">TOTAL REGISTROS: </label>
                        &nbsp
            <input id="txtnRegistros" type="text" value="0" class="TextPage" readonly="readonly" />
                        &nbsp &nbsp
            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;">PAGE: </label>
                        &nbsp
                <input id="txtPaginaActual" type="text" value="1" class="TextPage" readonly="readonly" />
                        <input id="cargar_primera_pagina" type="button" value="|<" class="submitPager" />
                        <input id="cargar_anterior_pagina" type="button" value="<<" class="submitPager" />
                        <input id="cargar_siguiente_pagina" type="button" value=">>" class="submitPager" />
                        <input id="cargar_ultima_pagina" type="button" value=">|" class="submitPager" />
                    </td>

                </tr>
            </tfoot>
        </table>
    </div>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/ScriptMJefePersonal.js?v2" type="text/javascript"></script>
       <style type="text/css">
        .style1 {
            background-color: #2C6B8D;
            height: 28px;
            font-family: AENOR Fontana ND;
            text-transform: uppercase;
            color: #FFFFFF;
            font-size: 1em;
            font-weight: bold;
            padding: 0px 7px;
            margin: 20px 0px 0px;
            text-align: left;
            width: 307px;
        }
    </style>

</asp:Content>
