<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sNuevos.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pAlertas.sNuevos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

<label class="miTitulo">Nuevo Reportes</label>
<br />
<br />
<table class="table">
<thead>
        <tr style="font-size:14px;">
            <th></th>            
            <th></th>  
            <th>ESTADO</th>
            <th>FECHA REPORTE</th>
            <th>USUARIO QUE REPORTO</th>
            <th>LOCALIDAD</th>
            <th>INTENSIDAD</th>
            <th>SEVERIDAD</th>
            <th>INFORMAR A GERENCIA</th>
            <th>FECHA DEL INCIDENTE</th>
            
        </tr>
</thead>
<tbody id="tbodyReportes" style="max-height:500px;overflow:auto;">

</tbody>
</table>

<br /><br /><br /><br /><br />

    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Script_Nuevos.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            Listar_NuevosReportes_By_Rol();
        });
    </script>

</asp:Content>
