<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MJG.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.MJG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"  type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />


    <table class="tableDialog">
        <tr>
            <td style="width:100px;text-align:right;"><label>Área : </label></td>
            <td><select id="cboArea" class="cbo"></select></td>
            <td style="width:100px;text-align:right;"><label>Sección : </label></td>
            <td><select id="cboSeccion" class="cbo"></select></td>
        </tr>
    </table>
    
    <br />
    <input type="button" class="buttonHer" value="Agregar" id="btnAddGer" />&nbsp; <%--<input type="button" id="btnAddJef" class="buttonHer" value="Agregar Jefe" />--%>
    <table class="table">
        <thead>
            <tr>
                <th>Localidad</th>
                <th>Gerente</th>
                <th>Jefe</th>
                <th></th>
                <th></th>
            </tr>
        </thead>
        <tbody id="tbodydata"></tbody>
    </table>
    <div id="dialogadd" style="display:none">
        <table class="tableDialog">
            <tr>
                <td style="width:80px;text-align:right;"><label>Localidad:</label></td>
                <td><select id="cboLocalidad2" class="cbo"></select></td>
                <td style="width:80px;text-align:right;"><label>Área:</label></td>
                <td><select id="cboArea2" class="cbo"></select></td>
                <td style="width:80px;text-align:right;"><label>Sección:</label></td>
                <td><select id="cboSeccion2" class="cbo"></select></td>
                <td style="width:80px;text-align:right;"><label>Personal:</label></td>
                <td><input type="text" id="txtFind" class="txt" /></td>
            </tr>
        </table>
        <fieldset>
            <legend>A Asignar</legend>
            <select id="cboloc2" class="cbo"></select>
            <label id="lblLog"></label>
            <input type="button" value="Guardar" class="submit" id="btnSave" />
        </fieldset>
        <table class="table">
            <thead>
                <tr>
                    <th>Localidad</th>
                    <th>Área</th>
                    <th>Sección</th>
                    <th>Cargo</th>
                    <th>Personal</th>
                    <th>Localidad</th>
                    <th></th>
                </tr>
            </thead>
            <tbody id="tbodydata2"></tbody>
        </table>
    </div>
    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/ScriptMJG.js?v1.4" type="text/javascript"></script>
     <%--<script src="Scripts/ScriptMJG.js?v2" type="text/javascript"></script>--%>
        <%--<script src="Scripts/ScriptMJG.js" type="text/javascript"></script>--%>

</asp:Content>
