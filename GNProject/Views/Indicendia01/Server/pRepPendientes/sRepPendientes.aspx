<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sRepPendientes.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pRepPendientes.sRepPendientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />


<fieldset>
<table class="table">
<thead>
        <tr style="font-size:14px;">
            <th></th>            
            <th></th>  
            <th>COD.</th>
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
</fieldset>
<br /><br /><br /><br /><br />

    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Script_RepPendientes.js" type="text/javascript"></script>

    <script type="text/javascript">
        var UsuarioFind = Session.get('Usuario');
        //var UsuarioFind = '<%= Session["loginId"] %>';
         
        $(document).ready(function () {

            Get_Reportes_List_PEND(UsuarioFind.Personal_Id);


            $('#tbodyReportes').on('click', '.buttonDetalle', function () {
                var codigo = this.id;
                var url = "'../pViewReporte/sViewReporte.aspx?inccod=" + codigo + "'";
                setTimeout("location.href=" + url, 5);
            });

            $('#tbodyReportes').on('click', '.buttonProcess', function () {
                var codigo = this.id;
                var url = "'../pRealizarAccion/sRealizarAccion.aspx?inccod=" + codigo + "'";
                setTimeout("location.href=" + url, 5);
            });

        });
    </script>
</asp:Content>
