<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sAlertOsigermin.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pAlertas.sAlertOsigermin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
           <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

<label class="miTitulo">Enviar a Osigermin</label>
<br />
<br />
<table class="table">
<thead>
        <tr style="font-size:14px;">
            <th></th>            
            <th></th>   
            <th></th>
            <th></th>
            <th>ESTADO</th>
            <th>F. REPORTE</th>
            <th>F. DEL INCIDENTE</th> 
            <th>USUARIO QUE REPORTO</th>
            <th>LOCALIDAD</th>
            <th>INF. A GERENCIA</th>
            <th>INF. A OSIGERMIN</th>
            <th>ENVIO PRELIMINAR</th>
            <th>ENVIO FINAL</th>
                       
        </tr>
</thead>
<tbody id="tbodyReportes" style="max-height:500px;overflow:auto;">

</tbody>
</table>


    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Script_ReportesOsigermin.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            Get_Reportes_Osigermin_ADM();
            $('#tbodyReportes').on('click', '.buttonOsiger', function () {
                var codigo = this.id;


                var url = "'../pSendOsigermin/sSendOsigermin.aspx'";
                Session.set('Incidencia_IdOsiger', codigo);
                setTimeout("location.href=" + url, 5);

            });
        });
    </script>
    
</asp:Content>
