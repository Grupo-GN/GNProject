<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmImportCalculo.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Datos.FrmImportCalculo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleWilder.css" rel="stylesheet" type="text/css" />
    <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px; border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">
        <br />
        <table>
            <tr>
                <td><input type="file" id="file-input" /></td>
                <td><input type="button" class="submit" id="btnGuardar" value="Guardar Calculos" /></td>
                <td><a href="Files/ImportCalculos.xlsm" class="lbl" target="_blank" style="color:Blue;">Descargar Generador</a></td>
                <td></td>
            </tr>
        </table>
        <table class="gridSmall" style="width:100%;">
            <thead>
                <tr>
                   <%--<th>PERIODO ID</th>--%>
                    <th>PLANILLA</th>
                    <th>EJERCICIO</th>
                    <th>MES</th>
                    <th>PERIODO</th>                    
                    <th>NRO. DOC</th>
                    <%--<th>PERSONAL ID</th>--%>
                    <th>PERSONAL</th>
                    <th>CONCEPTO ID</th>
                    <th>CONCEPTO</th>
                    <%--<th>PROCESO ID</th>--%>
                    <th>PROCESO</th>
                    <th>COLUMNA</th> 
                    <th>VALOR</th>
                    <th>RESULTADO</th>
                </tr>
            </thead>
            <tbody id="tbodyDatos" class="tbodyPer">
            
            
            </tbody>
        </table>
    </fieldset>
    <div id="divError"></div>
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="Script/ScriptImportCalculo.js"></script>
</asp:Content>

