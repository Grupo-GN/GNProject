<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sInformeGerencia.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pInformeGerencia.sInformeGerencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />

<input type="button" value="NUEVO" class="buttonHer" id="btnNew" />
<fieldset>
    <legend><label class="miTituloField">BUSQUEDA</label></legend>
    <label class="miLabel">Apellidos y Nombres : </label><input type="text" id="txtNombresFind" class="txt" style="width:350px;"/>
    <label class="miLabel"> Estado : </label><select id="cboEstadoFind" class="cbo"><option value="">TODOS</option><option value="01">ACTIVO</option><option value="02">INACTIVO</option></select>
</fieldset>

<div  style="overflow: hidden; width: 100%; border: solid 1px #505050;height: 340px;">
<table class="table">
<thead>
        <tr>
            <th></th>
            <th></th>
            <th>GERENTE</th>
            <th>GERENCIA</th>
            <th>LOCALIDAD</th>
            <th>INFORMA?</th>
            <th>ESTADO</th>
        </tr>
</thead>

<tbody id="tbodyGerencia">

</tbody>
</table>
</div>
 <div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
    <table class="table">
         <tfoot>
        <tr>
        <td  colspan="3">

            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;" >TOTAL REGISTROS: </label> &nbsp
            <input id="txtnRegistros" type="text" value="0" class="TextPage" readonly="true" /> &nbsp &nbsp
            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;" >PAGE: </label> &nbsp
            <input id="txtPaginaActual" type="text" value="1" class="TextPage" readonly="true" />
             <input id="btnPrimero" type="button" value="|<" class="submitPager" />
             <input id="btnAnterior" type="button" value="<<" class="submitPager" />
             <input id="btnSiguiente" type="button" value=">>" class="submitPager" />
             <input id="btnUltimo" type="button" value=">|" class="submitPager"/>
        </td>
        </tr>
        </tfoot>
    </table>
    </div>

    <div id="dialog-Gerencia" title="MATENIMIENTO GERENCIA">
    <table class="tableDialog">
        <tr>
            <td style="text-align:right;font-weight:bold;width:150px;">Codigo :</td>
            <td><input style="width:100%;" type="text" class="txtCodigo" value="??????" id="txtcodigo" readonly /></td>
        </tr>
        <tr>
            <td style="text-align:right;font-weight:bold;">Apellido Paterno :</td>
            <td><input type="text" class="txt" style="width:100%;" id="txtApePat" /></td>
        </tr>
        <tr>
            <td style="text-align:right;font-weight:bold;">Apellido Materno :</td>
            <td><input type="text" class="txt" style="width:100%;" id="txtApeMat" /></td>
        </tr>
        <tr>
            <td style="text-align:right;font-weight:bold;">Nombres :</td>
            <td><input type="text" class="txt" style="width:100%;" id="txtNombres" /></td>
        </tr>
        <tr>
            <td style="text-align:right;font-weight:bold;">Gerencia :</td>
            <td><input type="text" class="txt" style="width:100%;" id="txtGerencia" /></td>
        </tr>
        <tr>
            <td style="text-align:right;font-weight:bold;">Correo :</td>
            <td><input type="email" class="txt" style="width:100%;text-transform:none;" id="txtCorreo" /></td>
        </tr>
        <tr>
            <td style="text-align:right;font-weight:bold;">Localidad :</td>
            <td><select class="cbo" id="cboLocalidad"></select></td>
        </tr>
        <tr>
            <td style="text-align:right;font-weight:bold;">Informar :</td>
            <td><input type="checkbox" id="chkInformar" /></td>
        </tr>
        <tr>
            <td style="text-align:right;font-weight:bold;">Codigo LG :</td>
            <td><input type="text" class="txt" style="width:100%;" id="txtCodigoLG" /></td>
        </tr>
        <tr>
            <td style="text-align:right;font-weight:bold;">Estado :</td>
            <td><select id="cboEstado" class="cbo"><option value="01">ACTIVO</option><option value="02">INACTIVO</option></select></td>
        </tr>
        <tr>
            <td colspan="2"><label id="lblError" class="labelError"></label></td>
        </tr>
        <tr>
            <td colspan="2"><input type="button" id="btnGrabar" class="submit" value="GRABAR" />&nbsp; <input type="button" id="btnCalcelar" class="submit" value="CANCELAR" /></td>
        
        </tr>
    </table>
    
    </div>
    <br /><br /><br /><br /><br />
    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Script_InformeGerencia.js" type="text/javascript"></script>
    <script type="text/javascript">
        var TotalPaginador = 12;
        var TOTALREGISTROS;
        var inicio = 0;
        var PAGINAACTUAL = 1;
        var TIPOPROCESO = '';
        var Gerencia_Proc = '';
        $(document).ready(function () {
            $('#dialog-Gerencia').hide();
            Get_Localidad_Combo();
            Get_Gerentes_List(Get_Nombres_Find(), Get_Estado_Find(), inicio);

            $('#btnNew').click(function () {
                clearModal();
                open_Modal();
                TIPOPROCESO = '01';
                Gerencia_Proc = '';
            });

            $('#btnCalcelar').click(function () {
                TIPOPROCESO = '';
                Gerencia_Proc = '';
                close_Modal();
            });

            $('#txtNombresFind').keyup(function () {
                inicio = 0;
                Get_Gerentes_List(Get_Nombres_Find(), Get_Estado_Find(), inicio);
            });
            $('#cboEstadoFind').change(function () {
                inicio = 0;
                Get_Gerentes_List(Get_Nombres_Find(), Get_Estado_Find(), inicio);
            });

            $('#tbodyGerencia').on('click', '.buttonEdit', function () {
                var selcod = this.id.substring(1);
                Get_Find_Gerente(selcod);


            });

            $('#tbodyGerencia').on('click', '.buttonDesactiva', function () {
                if (confirm('¿Esta seguro de desactivar al Gerente?')) {
                    var codigo = this.id.substring(1);
                    Get_Delete_Estado_Gerente(codigo, '02')
                }
            });

            $('#tbodyGerencia').on('click', '.buttonActiva', function () {
                if (confirm('¿Esta seguro de activar al Gerente?')) {
                    var codigo = this.id.substring(1);
                    Get_Delete_Estado_Gerente(codigo, '01')
                }
            });

            $('#btnGrabar').click(function () {
                $('#lblError').html('&nbsp;');
                if (!TIPOPROCESO) {
                    alert('.::Error, Proceso no identificado.')
                    return false;
                }
                var ApePat = $('#txtApePat').val();
                var ApeMat = $('#txtApeMat').val();
                var Nombres = $('#txtNombres').val();
                var Gerencia = $('#txtGerencia').val();
                var Correo = $('#txtCorreo').val();
                var localidad_id = $('#cboLocalidad').val();
                var Informar = $('#chkInformar').is(':checked');
                var codigoLG = $('#txtCodigoLG').val();
                var estado = $('#cboEstado').val();
                var infor = '';
                if (!ApePat) {
                    $('#lblError').html('.::Error, Apellido Paterno no definido.');
                    $('#txtApePat').focus();
                    return false;
                }
                if (!ApeMat) {
                    $('#lblError').html('.::Error, Apellido Materno no definido.');
                    $('#txtApeMat').focus();
                    return false;
                }
                if (!Nombres) {
                    $('#lblError').html('.::Error, Nombre no definido.');
                    $('#txtNombres').focus();
                    return false;
                }
                if (!Gerencia) {
                    $('#lblError').html('.::Error, Gerencia no definido.');
                    $('#txtGerencia').focus();
                    return false;
                }
                if (!Correo) {
                    $('#lblError').html('.::Error, Correo no definido.');
                    $('#txtCorreo').focus();
                    return false;
                }
                if (!localidad_id) {
                    $('#lblError').html('.::Error, Localidad no definida.');
                    $('#cboLocalidad').focus();
                    return false;
                }

                if (!Informar) {
                    infor = '02';
                } else {
                    infor = '01';
                }


                if (!estado) {
                    $('#lblError').html('.::Error, Estado no definido.');
                    $('#cboEstado').focus();
                    return false;
                }
                if (TIPOPROCESO == '01') {
                    Get_Add_Gerente(ApePat.toUpperCase(), ApeMat.toUpperCase(), Nombres.toUpperCase(), Gerencia.toUpperCase(), Correo, localidad_id, infor, codigoLG, estado);
                } else if (TIPOPROCESO == '02') {
                    Get_Update_Gerente(Gerencia_Proc, ApePat.toUpperCase(), ApeMat.toUpperCase(), Nombres.toUpperCase()
                    , Gerencia.toUpperCase(), Correo, localidad_id, infor, codigoLG, estado);
                }
            });
        });
    </script>

</asp:Content>
