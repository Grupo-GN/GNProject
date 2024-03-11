<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sRepPendientesADM.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pRepPendientesADM.sRepPendientesADM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
<fieldset>
    <legend><label class="miTituloField">BUSQUEDA</label></legend>
    <table style="border-collapse:collapse;width:100%;">
        <tr>
            <td style="width:100px;"><label class="miLabel">Localidad : </label></td>
            <td style="width:250px;"><select class="cbo" id="cboLocalidadFind"></select></td>
            <td style="width:120px;"><label class="miLabel">FECHA DE REPORTE : </label></td>
            <td style="width:110px;"><input type="text" class="txt" id="txtFechaIni" /></td>
            <td><input type="text" class="txt" id="txtFechaFin" /></td>
            <td></td>
        </tr>
    </table>
      
</fieldset>

<fieldset>
<table class="table">
<thead>
        <tr style="font-size:14px;">
            <th></th>            
            <th></th>
            <th></th>  
            <th>COD</th>
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
    <a target="_blank"></a>
<br /><br /><br /><br /><br />
    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Script_RepPendientesADM.js" type="text/javascript"></script>

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
                    Get_Reportes_List_PEND_ADM(get_LocalidadFind(), get_FechaIniFind(), get_FechaFinFind());
                    cargarcookies();
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
                    Get_Reportes_List_PEND_ADM(get_LocalidadFind(), get_FechaIniFind(), get_FechaFinFind());
                    cargarcookies();
                }
            });
            var fechaAc = new Date();        
            fechaAc.addDays(-30);
            $('#txtFechaIni').datepicker("setDate", fechaAc);
            fechaAc = new Date();              
            $('#txtFechaFin').datepicker("setDate", fechaAc);

            Get_Localidad_Combo();
            leercookies();
            Get_Reportes_List_PEND_ADM(get_LocalidadFind(), get_FechaIniFind(), get_FechaFinFind());

            $('#cboLocalidadFind').change(function () {
                Get_Reportes_List_PEND_ADM(get_LocalidadFind(), get_FechaIniFind(), get_FechaFinFind());
                cargarcookies();
            });


            $('#tbodyReportes').on('click', '.buttonDetalle', function () {
                var codigo = this.id;
                var url = "'../pViewReporte/sViewReporte.aspx?inccod=" + codigo + "'";
                //setTimeout("location.href=" + url, 5);
                setTimeout("window.open(" + url + ",'_blank')", 5);
            });

            $('#tbodyReportes').on('click', '.buttonProcess', function () {
                var codigo = this.id;
                var url = "'../pRealizarAccionADM/sRealizarAccionADM.aspx?inccod=" + codigo + "'";
                //setTimeout("location.href=" + url, 5);
                setTimeout("window.open(" + url + ",'_blank')", 5);
            });



            $('#tbodyReportes').on('click', '.buttonAprobar', function () {
                if (confirm('¿Esta seguro de continuar?')) {
                    var codigo = this.id;
                    Aprobar_Reporte_ADM(codigo);
                }
            });
        });
        Date.prototype.addDays = function (days) {
            this.setDate(this.getDate() + days);
            return this;
        };
    </script>
</asp:Content>
