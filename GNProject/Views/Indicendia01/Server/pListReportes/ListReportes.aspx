<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListReportes.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pListReportes.ListReportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
<fieldset>
    <legend><label class="miTituloField">BUSQUEDA</label></legend>
    <label class="miLabel">LOCALIDAD : </label><select class="cbo" id="cboLocalidadFind"></select><br /><br />
    <label class="miLabel">FECHA DE REPORTE :&nbsp;&nbsp; </label> <input type="text" class="txt" id="txtFechaIni" /><label class="miLabel">   a   </label><input type="text" class="txt" id="txtFechaFin" />
</fieldset>

<fieldset>
<table class="table">
<thead>
        <tr style="font-size:14px;">
            <th></th>            
            <th></th>  
            <th></th>  
            <th></th>
            <th>COD.</th>
            <th>ESTADO</th>
            <th>FECHA REPORTE</th>
            <th>USUARIO QUE REPORTO</th>
            <th>LOCALIDAD</th>
            <th>INTENSIDAD</th>
            <th>SEVERIDAD</th>
            <th>INF. A GERENCIA</th>
            <th>INF. A OSIGERMIN</th>
            <th>FECHA DEL INCIDENTE</th>            
        </tr>
</thead>
<tbody id="tbodyReportes" style="max-height:500px;overflow:auto;">

</tbody>
</table>
</fieldset>

<div id="dialog-Acciones" title="Validar Acciones">
            <table class="table">
                <thead>
                    <tr>
                        <th>ACCIÓN</th>
                        <th>RESPONSABLE</th>
                        <th>INICIO</th>
                        <th>FIN</th>
                        <th>ESTADO</th>
                        <th></th>
                        <th></th>

                    </tr>
                </thead>
                 <tbody id="tbodyAcciones" class="TableRe">

                </tbody>
            </table>

</div>

<br /><br /><br /><br /><br />
    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Script_ListReportes.js" type="text/javascript"></script>

    <script type="text/javascript">
        var Incidencia_Id = '';
        $(document).ready(function () {
            $('#dialog-Acciones').hide();
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
                    Get_Reportes_List_ADM(get_LocalidadFind(), get_FechaIniFind(), get_FechaFinFind());
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
                    Get_Reportes_List_ADM(get_LocalidadFind(), get_FechaIniFind(), get_FechaFinFind());
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
            Get_Reportes_List_ADM(get_LocalidadFind(), get_FechaIniFind(), get_FechaFinFind());


            $('#cboLocalidadFind').change(function () {
                Get_Reportes_List_ADM(get_LocalidadFind(), get_FechaIniFind(), get_FechaFinFind());
                cargarcookies();
            });

            $('#tbodyReportes').on('click', '.buttonDetalle', function () {
                var codigo = this.id;
                var url = "'../pViewReporte/sViewReporte.aspx?inccod=" + codigo + "'";
                //setTimeout("location.href=" + url, 5);
                setTimeout("window.open(" + url + ",'_blank')", 5);
            });
            $('#tbodyReportes').on('click', '.buttonEdit', function () {
                var codigo = this.id;
                var url2 = "'../pEditReporteIncidente/sEditReporteIncidente.aspx?inccod=" + codigo + "'";
                setTimeout("location.href=" + url2, 5);
            });

            $('#tbodyReportes').on('click', '.buttonAccionVal', function () {
                Incidencia_Id = this.id;
                Get_AccionCorrectiva_List(Incidencia_Id);
                open_Modal();
            });

            $('#tbodyAcciones').on('click', '.buttonValida', function () {
                if (confirm('¿Esta seguro de Aporbar la acción?')) {
                    Get_Aprobrar_Accion(Incidencia_Id, this.id);
                }
            });

            $('#tbodyAcciones').on('click', '.buttonDelete', function () {
                if (confirm('¿Esta seguro de Desaprobrar la acción?')) {
                    Get_Desaprobrar_Accion(Incidencia_Id, this.id);
                }
            });

            $('#tbodyReportes').on('click', '.buttonOsiger', function () {
                var codigo = this.id;
                var estado = Get_Estado_Reporte(codigo);
                if (!estado) {
                    return false;
                }
                if (estado == '03' || estado == '01') {
                    var url = "'../pSendOsigermin/sSendOsigermin.aspx'";
                    Session.set('Incidencia_IdOsiger', codigo);
                    setTimeout("location.href=" + url, 5);
                } else {
                    alert('El Reporte tiene que estar en curso o finalizado.');
                }
            });
        });
        Date.prototype.addDays = function (days) {
            this.setDate(this.getDate() + days);
            return this;
        };
    </script>

</asp:Content>
