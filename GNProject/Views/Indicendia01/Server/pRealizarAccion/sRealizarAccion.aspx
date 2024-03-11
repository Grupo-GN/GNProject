<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sRealizarAccion.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pRealizarAccion.sRealizarAccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

    <table class="table">
<thead>
        <tr style="font-size:14px;">
            <th></th>            
            <th></th>  
            <th>ESTADO</th>
            <th>DESCRIPCION</th>
            <th>RESPONSABLE</th>
            <th>FECHA DE REPORTE</th>
            <th>FECHA VENCIMIENTO</th>
            <th>ARCHIVOS</th>            
        </tr>
</thead>
<tbody id="tbodyAccion" style="max-height:500px;overflow:auto;">

</tbody>
</table>
<br /><br /><br /><br /><br />
    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Script_RealizarAccion.js" type="text/javascript"></script>

    <script type="text/javascript">
        var Incidente_Cod = getParameterByName('inccod');

        $(document).ready(function () {
            Get_Acciones_Reporte(Incidente_Cod);

            $('#tbodyAccion').on('click', '.buttonAprobar', function () {
                if (confirm('¿Esta seguro de dar por realizado la acción?')) {
                    var codigo = this.id;
                    Get_RealizarAccion(Incidente_Cod, codigo);
                }
            });

            window.setInterval(function () { Get_Acciones_Reporte(Incidente_Cod); }, 5000);

            $('#tbodyAccion').on('click', '.buttonSubirFile', function () {
                var codigo = this.id;
                if (window.showModalDialog) {
                    window.showModalDialog('../pSubirFileAccion/sSubirFileAccion.aspx?iccod=' + Incidente_Cod + '&accod=' + codigo, 'Archivos Acción', "dialogWidth:700px;dialogHeight:250px");
                } else {
                    window.open('../pSubirFileAccion/sSubirFileAccion.aspx?iccod=' + Incidente_Cod + '&accod=' + codigo, 'Archivos Acción',
            'height=500,width=550,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no ,modal=yes');
                }
            });

        });
    
    </script>

</asp:Content>
