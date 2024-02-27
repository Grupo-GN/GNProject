<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sSendOsigermin.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pSendOsigermin.sSendOsigermin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

<label class="miTitulo">enviar correo a osigermin</label><br /><br />

<table class="tableDialog">
    <tr>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td style="width:50%;"><label class="miLabel">PRELIMINAR</label>&nbsp;&nbsp;&nbsp;&nbsp;<a id="aVerFilePre" href="../../img/OsigerminLogon.png" target="_blank">  VER  </a></td>
        <td style="width:50%;"><label class="miLabel">FINAL</label>&nbsp;&nbsp;&nbsp;&nbsp;<a id="aVerFileFin" href="../../img/OsigerminLogon.png" target="_blank">  VER  </a></td>
    </tr>
    <tr>
        <td><label class="labelError" id="lblMensajePre"></label></td>
        <td><label class="labelError" id="lblMensajeFin"></label></td>
    </tr>
    <tr>
        <td><input type="button" value="SUBIR" class="submit" id="btnSubirPre" /></td>
        <td><input type="button" value="SUBIR" class="submit" id="btnSubirFin" /></td>
    </tr>
    <tr>
        <td style="vertical-align:top;"><fieldset style="height:250px;">
            <legend ><label class="miTituloField">Enviar Preliminar</label></legend>
            <table style="width:100%;">
                <tr>
                    <td><label class="miLabel">Asunto : </label></td>
                </tr>
                <tr>
                    <td><input type="text" class="txt" style="width:100%;text-transform:none;" id="txtAsustoPre" /></td>
                </tr>
                <tr>
                    <td><label class="miLabel">Incluir Comentarios : </label></td>
                </tr>
                <tr>
                    <td><textarea rows="3" cols="30" style="width:100%;" id="txtcomentariosPre"></textarea></td>
                </tr>
                <tr>
                    <td><input type="button" value="ENVIAR PRELIMINAR" style="width:150px;" class="submit" id="btnSendPre" /></td>
                </tr>
            </table>            
            
            </fieldset></td>
        <td style="vertical-align:top;"><fieldset style="height:250px;">
            <legend ><label class="miTituloField">Enviar Final</label></legend>
            <table style="width:100%;">
                <tr>
                    <td><label class="miLabel">Asunto : </label></td>
                </tr>
                <tr>
                    <td><input type="text" class="txt" style="width:100%;text-transform:none;" id="txtAsuntoFinal" /></td>
                </tr>
                <tr>
                    <td><label class="miLabel">Incluir Comentarios</label></td>
                </tr>
                <tr>
                    <td><textarea rows="3" cols="30" style="width:100%;" id="txtcomentariosFinal"></textarea></td>
                </tr>
                <tr>
                    <td><input type="button" value="ENVIAR FINAL" style="width:150px;" class="submit" id="btnSendFin" /></td>
                </tr>
            </table>
            
            
            </fieldset></td>
    </tr>

</table>

<br />
<br />
<br />
    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Script_SendFileOsigermin.js" type="text/javascript"></script>
    <script type="text/javascript">
        var Incidencia_Id = Session.get('Incidencia_IdOsiger');
        $(document).ready(function () {

            CargarDatosOsigermin_Incidencia();

            window.setInterval('CargarDatosOsigermin_Incidencia()', 3000);
            $('#btnSubirPre').click(function () {
                if (!Incidencia_Id) {
                    alert('.::Error,Incidencia no definida.');
                    return false;
                }
                if (window.showModalDialog) {
                    window.showModalDialog('sFileOsigermin.aspx?iccod=' + Incidencia_Id + '&tcod=01', 'Archivos Acción', "dialogWidth:700px;dialogHeight:250px");
                } else {
                    window.open('sFileOsigermin.aspx?iccod=' + Incidencia_Id + '&tcod=01', 'Archivos Acción',
                                    'height=500,width=550,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no ,modal=yes');
                }
            });



            $('#btnSubirFin').click(function () {
                if (!Incidencia_Id) {
                    alert('.::Error,Incidencia no definida.');
                    return false;
                }
                if (window.showModalDialog) {
                    window.showModalDialog('sFileOsigermin.aspx?iccod=' + Incidencia_Id + '&tcod=02', 'Archivos Acción', "dialogWidth:700px;dialogHeight:250px");
                } else {
                    window.open('sFileOsigermin.aspx?iccod=' + Incidencia_Id + '&tcod=02', 'Archivos Acción',
                                    'height=500,width=550,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no ,modal=yes');
                }
            });


            $('#btnSendPre').click(function () {

                var asunto = $('#txtAsustoPre').val();
                var comentarios = $('#txtcomentariosPre').val();
                if (!asunto) {
                    alert('.::Error, Asunto no definido.');
                    $('#txtAsustoPre').focus();
                    return false;
                }
                Get_Enviar_Correo_Osigermin(Incidencia_Id, '01', asunto, comentarios);
            });

            $('#btnSendFin').click(function () {

                var asunto = $('#txtAsuntoFinal').val();
                var comentarios = $('#txtcomentariosFinal').val();
                if (!asunto) {
                    alert('.::Error, Asunto no definido.');
                    $('#txtAsuntoFinal').focus();
                    return false;
                }
                Get_Enviar_Correo_Osigermin(Incidencia_Id, '02', asunto, comentarios);
            });

        });

        function CargarDatosOsigermin_Incidencia() {
            Get_Datos_Osigermin(Incidencia_Id);
        }


    </script>

</asp:Content>
