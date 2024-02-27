<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rHistorial.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.Reportes.rHistorial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <label class="miTitulo">historial multiple</label>
     <br />
    <br />
    <img src="../../icon/cofig.ico" style="width:40px;height:40px;cursor:pointer;" id="btnConfigView" />
       <img src="../../icon/filter2.png" style="width:40px;height:40px;cursor:pointer;" id="btnConfigFilter" />
    
   

    <br />
    <br />
    <input class="buttonHer" type="button"  value="GENERAR" id="btnGenerar" /> <input type="button" class="buttonHer" value="EXPORTAR" id="btnExportar" /> <input type="button" class="buttonHer" value="ENVIAR" id="btnSend" />

    <div id="tab" style="max-width:100%;max-height:950px; overflow:scroll;">
    <table id="tblHistorial">
         <thead id="theadHistorial">
            <tr>
                <th></th>
            </tr>
         </thead>
         <tbody id="tbodyHistorial">
         
         </tbody>
    </table>
    </div>
    <div id="dialog-SendEmail">
        <table class="tableDialog">
            <tr>
                <td style="width:90px;text-align:right;"><label class="miLabel">Para : </label></td>
                <td><input type="text" id="txtCorreos" class="txt" style="width:100%;text-transform:none;"/></td>
            </tr>
            <tr>
                <td style="width:90px;text-align:right;"><label class="miLabel">Asunto : </label></td>
                <td><input type="text" id="txtAsunto" class="txt" style="width:100%;"/></td>
            </tr>
            <tr>
                <td style="text-align:right;vertical-align:text-top;"><label class="miLabel">Comentarios : </label></td>
                <td><textarea id="txtComen" rows="3" cols="30" style="width:100%;" ></textarea></td>
            </tr>
            <tr>
                <td colspan="2"><input type="button" class="submit" value="ENVIAR" id="btnEnviar" />&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" class="submit" value="CANCELAR" id="btnExit" /> </td>
               
            </tr>
        </table>
    
    </div>

    <div id="dialog-View" title="MOSTRAR EN EL REPORTE">
    <fieldset id="fielView">
        <legend><label class="miTituloField">CUERPO DEL REPORTE</label></legend>
        <div id="viewCampos" style="border:1px solid #D7D7D7;width:100%;overflow:auto;height:300px;">
<input type="checkbox"  id="chkAllView" /><label class="miLabel">TODOS</label><br />
<input type="checkbox" class="chkView" id="v1" /><label class="miLabel">Incidente Id</label><br />
<input type="checkbox" class="chkView" id="v2" /><label class="miLabel">Personal Registro</label><br />
<input type="checkbox" class="chkView" id="v3" /><label class="miLabel">Localidad</label><br />
<input type="checkbox" class="chkView" id="v4" /><label class="miLabel">Área</label><br />
<input type="checkbox" class="chkView" id="v5" /><label class="miLabel">Sección</label><br />
<input type="checkbox" class="chkView" id="v6" /><label class="miLabel">Actividad Propia</label><br />
<input type="checkbox" class="chkView" id="v7" /><label class="miLabel">Actividad Rutinaria</label><br />
<input type="checkbox" class="chkView" id="v8" /><label class="miLabel">Intensidad Id</label><br />
<input type="checkbox" class="chkView" id="v9" /><label class="miLabel">Descripcion</label><br />
<input type="checkbox" class="chkView" id="v10" /><label class="miLabel">Informar Gerencia</label><br />
<input type="checkbox" class="chkView" id="v11" /><label class="miLabel">Informar Osigermin</label><br />
<input type="checkbox" class="chkView" id="v12" /><label class="miLabel">FechaHora Incidente</label><br />
<input type="checkbox" class="chkView" id="v13" /><label class="miLabel">FechaHora Reporte</label><br />
<input type="checkbox" class="chkView" id="v14" /><label class="miLabel">Lugar Incidente</label><br />
<input type="checkbox" class="chkView" id="v15" /><label class="miLabel">Tipo</label><br />
<input type="checkbox" class="chkView" id="v24" /><label class="miLabel">Origen</label><br />
<input type="checkbox" class="chkView" id="v16" /><label class="miLabel">Severidad</label><br />
<input type="checkbox" class="chkView" id="v17" /><label class="miLabel">LesionesPerdidas</label><br />
<input type="checkbox" class="chkView" id="v18" /><label class="miLabel">PosiblesCausas</label><br />
<input type="checkbox" class="chkView" id="v19" /><label class="miLabel">AccionInmediata</label><br />
<input type="checkbox" class="chkView" id="v20" /><label class="miLabel">Estado_Id</label><br />
<input type="checkbox" class="chkView" id="v21" /><label class="miLabel">SendMailGerencia</label><br />
<input type="checkbox" class="chkView" id="v22" /><label class="miLabel">SendPreliminar</label><br />
<input type="checkbox" class="chkView" id="v23" /><label class="miLabel">SendFinal</label><br />
<input type="checkbox" class="chkView" id="v25" /><label class="miLabel">Acción</label><br />
</div>
    </fieldset>
    </div>

    <div id="dialog-Filtros" title="FILTROS PARA EL REPORTES" style="font-size:10px;">
 <fieldset id="fielFilter">
        <legend><label class="miTituloField">FILTROS</label></legend>
        <div id="viewFiltros" style="float:left;border:1px solid #D7D7D7;width:250px;overflow:auto;height:150px;">
            <input type="checkbox" class="chkFil" id="f1" /><label class="miLabel">Personal Registro</label><br />
            <input type="checkbox" class="chkFil" id="f2" /><label class="miLabel">Localidad</label><br />
            <input type="checkbox" class="chkFil" id="f3" /><label class="miLabel">Area</label><br />
            <input type="checkbox" class="chkFil" id="f4" /><label class="miLabel">Sub Area</label><br />
            <input type="checkbox" class="chkFil" id="f5" /><label class="miLabel">Actividad Propia</label><br />
            <input type="checkbox" class="chkFil" id="f6" /><label class="miLabel">Actividad Rutinaria</label><br />
            <input type="checkbox" class="chkFil" id="f7" /><label class="miLabel">Intensidad</label><br />


        </div>
        <div id="viewFiltros2" style="float:left;border:1px solid #D7D7D7;width:250px;overflow:auto;height:150px;">
            <input type="checkbox" class="chkFil" id="f8" /><label class="miLabel">Informar Gerencia</label><br />
            <input type="checkbox" class="chkFil" id="f9" /><label class="miLabel">Informar Osigermin</label><br />
            <input type="checkbox" class="chkFil" id="f10" /><label class="miLabel">Fechas Incidencia</label><br />
            <input type="checkbox" class="chkFil" id="f11" /><label class="miLabel">Fecha Reportes</label><br />
            <input type="checkbox" class="chkFil" id="f12" /><label class="miLabel">Tipo</label><br />
            <input type="checkbox" class="chkFil" id="f15" /><label class="miLabel">Origen</label><br />
            <input type="checkbox" class="chkFil" id="f13" /><label class="miLabel">Severidad</label><br />
            <input type="checkbox" class="chkFil" id="f14" /><label class="miLabel">SendMailGerencia</label><br />
        </div>
        <br />
        <div style="border:1px solid #D7D7D7;float:left;height:200px;width:100%;" id="divFiltros">
        
        
        </div>
    </fieldset>
    </div>

    <br /><br /><br /><br /><br />
    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Script_HistorialMultiple.js" type="text/javascript"></script>
    <script src="../../jsExportExcel/ScriptExportarExcel.js" type="text/javascript"></script>
    <script type="text/javascript">
        var view = '01';
        var fil = '01';
        var aView = [];
        var aWhere = [];
        $(document).ready(function () {

            $('#dialog-SendEmail').hide();
            $('#dialog-View').hide();
            $('#dialog-Filtros').hide();
            $('#btnConfigView').click(function () {
                $('#dialog-View').dialog({
                    autoOpen: true,
                    modal: true,
                    width: 320,
                    height: 400,
                    show: { effect: "fade", duration: 800 },
                    hide: { effect: "explode", duration: 800 }
                });
            });
            $('#btnConfigFilter').click(function () {
                $('#dialog-Filtros').dialog({
                    autoOpen: true,
                    modal: true,
                    width: 1100,
                    height: 450,
                    show: { effect: "fade", duration: 800 },
                    hide: { effect: "explode", duration: 800 }
                });
            });

            $('#chkAllView').click(function () {
                var ch = $('#chkAllView').is(':checked');
                $('.chkView').prop('checked', ch);
                if (ch) {
                    aView = [];
                    for (var i = 1; i <= 25; i++) {
                        aView.push('v' + i);
                    }
                } else {
                    aView = [];
                }
            });

            $('#viewCampos').on('click', '.chkView', function () {
                var ch = $(this).is(':checked');
                if (ch) {
                    aView.add(this.id);
                } else {
                    aView.remov(this.id);
                }
            });


            $('#viewFiltros').on('click', '.chkFil', function () {
                Get_MostrarFiltros(this.id);
                var cha = $(this).is(':checked');
                if (cha) {
                    aWhere.add(this.id);
                } else {
                    aWhere.remov(this.id);
                }
            });

            $('#viewFiltros2').on('click', '.chkFil', function () {
                Get_MostrarFiltros(this.id);
                var cha = $(this).is(':checked');
                if (cha) {
                    aWhere.add(this.id);
                } else {
                    aWhere.remov(this.id);
                }
            });


            $('#btnGenerar').click(function () {
                Generar_Historial_Multiple_WPP();
            });
            $('#btnExportar').click(function () {
                exportExcel('tblHistorial', 'HISTORIAL');

            });


            $('#fielFilter').on('change', '#cboCatFind', function () {
                Get_Categoria_Auxiliar2();
            });


            $('#btnSend').click(function () {
                var destino = $('#txtCorreos').val('');
                var asunto = $('#txtAsunto').val('');
                var comen = $('#txtComen').val('');

                $('#dialog-SendEmail').dialog({
                    autoOpen: true,
                    modal: true,
                    width: 400,
                    height: 230,
                    show: { effect: "fade", duration: 800 },
                    hide: { effect: "explode", duration: 800 }
                });
            });

            $('#btnEnviar').click(function () {
                var destino = $('#txtCorreos').val();
                var asunto = $('#txtAsunto').val();
                var comen = $('#txtComen').val();
                var htmlTable = $('#tab').html();
                if (!destino) {
                    alert('.::Error > Correo(s) destino no definido.');
                    $('#txtCorreos').focus();
                    return false;
                }
                if (!asunto) {
                    alert('.::Error > Asunto no definido.');
                    $('#txtAsunto').focus();
                    return false;
                }

                var html = comen + '<br/><br/>' + htmlTable;
                SendMail_SMTP(destino, asunto, html);

            });


            $('#btnExit').click(function () {
                $('#dialog-SendEmail').dialog('close');
            });


        });
    
    </script>

</asp:Content>
