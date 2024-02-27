<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sAccionesRevisar.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pAlertas.sAccionesRevisar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

<label class="miTitulo">Acciones Realizadas</label>
<br />
<br />
<table class="table">
<thead>
        <tr style="font-size:14px;">
            <th></th>            
            <th>ESTADO</th>
            <th>DESCRIPCION</th>
            <th>RESPONSABLE</th>
            <th>FECHA INCIDENTE</th>
            <th>FECHA REPORTE</th>
            <th>FECHA INICIO</th>
            <th>FECHA FIN</th>            
        </tr>
</thead>
<tbody id="tbodyAccion" style="max-height:500px;overflow:auto;">

</tbody>
</table>

<br /><br /><br /><br /><br />

    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Script_AccionesRevisar.js" type="text/javascript"></script>

</asp:Content>
