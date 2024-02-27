<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sListReportesPlanta.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pListReportesPlanta.sListReportesPlanta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
<fieldset>
    <legend><label class="miTituloField">BUSQUEDA</label></legend>
    <label class="miLabel">FECHA DE REPORTE :&nbsp;&nbsp; </label> <input type="text" class="txt" id="txtFechaIni" /><label class="miLabel">   a   </label><input type="text" class="txt" id="txtFechaFin" />
</fieldset>

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
    <script src="Script_ListReportesPlanta.js" type="text/javascript"></script>

    <script type="text/javascript">
        var UsuarioFind = Session.get('Usuario');
        $(document).ready(function () {
            $('#txtFechaIni').datepicker({
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
                dateFormat: 'dd/mm/yy',
                isRTL: false,
                onClose: function (selectedDate) {
                    $("#txtFechaFin").datepicker("option", "minDate", selectedDate);
                    Get_Reportes_List_PLANT(UsuarioFind.Area_Id, UsuarioFind.Personal_Id, get_FechaIniFind(), get_FechaFinFind());
                }
            });
            $('#txtFechaFin').datepicker({
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		        'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
                dateFormat: 'dd/mm/yy',
                isRTL: false,
                onClose: function (selectedDate) {
                    Get_Reportes_List_PLANT(UsuarioFind.Area_Id, UsuarioFind.Personal_Id, get_FechaIniFind(), get_FechaFinFind());
                }
            });

            var fechaAc = new Date();
            $('#txtFechaIni').datepicker("setDate", fechaAc);
            $('#txtFechaFin').datepicker("setDate", fechaAc);
          /*  Get_Localidad_Combo();*/
            Get_Reportes_List_PLANT(UsuarioFind.Area_Id, UsuarioFind.Personal_Id, get_FechaIniFind(), get_FechaFinFind());


            $('#tbodyReportes').on('click', '.buttonDetalle', function () {
                var codigo = this.id;                
                var url = "'../pViewReporte/sViewReporte.aspx?inccod=" + codigo + "'";
                setTimeout("location.href=" + url, 5);
            });

            $('#tbodyReportes').on('click', '.buttonEdit', function () {
                var codigo = this.id;
                var url = "'../pEditRepPlanta/sEditRepPlanta.aspx?inccod=" + codigo + "'";
                setTimeout("location.href=" + url, 5);
            });

        });
    </script>
</asp:Content>
