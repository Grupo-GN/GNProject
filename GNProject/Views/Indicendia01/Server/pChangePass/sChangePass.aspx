<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sChangePass.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pChangePass.sChangePass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />

    <fieldset>
        <legend><label class="miTituloField">BUSQUEDA</label></legend>
        <label class="miLabel">Personal : </label><input type="text" class="txt" id="txtPersonalFind" style="width:350px;" />
    </fieldset>
    <div  style="overflow: hidden; width: 100%; border: solid 1px #505050;height: 340px;">
    <table class="table">
    <thead>
            <tr>
                <th></th>
                <th>PERSONAL</th>
                <th>ESTADO</th>
                <th>USUARIO</th>
                <th>CONTRASEÑA</th>
                <th>ESTADO USUARIO</th>
            </tr>
    </thead>
    <tbody id="tbodyUsuario">
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

    <br />
    <br />
<div id="dialog-Change" title="Cambiar mi Contraseña">
<label class="miTitulo">CAMBIAR MI CONTRASEÑA</label><br /><br />
    <table>
        <tr>
            <td><label class="miLabel">Personal: </label></td>
            <td><label class="miLabel" id="lblUsuario"></label></td>
        </tr>

        <tr>
            <td><label class="miLabel">Nueva Contraseña: </label></td>
            <td><input type="password" class="txt" style="text-transform:none;" id="txtpas1"/></td>
        </tr>
        <tr>
            <td><label class="miLabel">Repita la nueva Contraseña: </label></td>
            <td><input type="password" class="txt" style="text-transform:none;" id="txtpas2"/></td>
        </tr>       
    </table>
    <br />
    <input type="button" class="submit" value="GRABAR" id="btnGrabar" /> <input type="button" class="submit" value="CANCELAR" id="btnCancel" />
</div>


    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Script_ChangePass.js" type="text/javascript"></script>
    <script src="../../jsSession/session.js" type="text/javascript"></script>
    <script type="text/javascript"">
        var TotalPaginador = 12;
        var TOTALREGISTROS;
        var inicio = 0;
        var PAGINAACTUAL = 1;
        var PersonalProc = '';
        $(document).ready(function () {
            $('#dialog-Change').hide();
            var UsuarioLogin = Session.get('Usuario');
            Get_UsuarioPersonal(UsuarioLogin.Personal_Id, Get_PersonalFind(), inicio);
            


            $('#tbodyUsuario').on('click', '.buttonEdit', function () {
                open_Modal();
                PersonalProc = this.id;
                Get_Personal_Find(PersonalProc);
            });



            $('#btnGrabar').click(function () {

                var newcontr = $('#txtpas1').val();
                var newcontra = $('#txtpas2').val();

                if (!newcontr) {
                    alert('.::Error > Ingrese la nueva contraseña.');
                    $('#txtpas1').focus();
                    return false;
                }

                if (!newcontra) {
                    alert('.::Error > Ingrese la nueva contraseña.');
                    $('#txtpas2').focus();
                    return false;
                }

                if (newcontr != newcontra) {
                    alert('.::Error > La contraseña ingresada no coincide intentelo nuevamente.');
                    $('#txtpas2').val('');
                    $('#txtpas2').focus();
                    return false;
                }
                Get_Change_Pass(PersonalProc, newcontra);
            });

            $('#btnCancel').click(function () {
                $('#dialog-Change').dialog('close');
                $('#txtpas1').val('');
                $('#txtpas2').val('');
            });


            //NAVEGACION

            $('#btnUltimo').click(function () {  //metodos para actualizar

                var guardaPagina = parseInt($('#txtnRegistros').val());
                var laPaginaActual = guardaPagina / TotalPaginador;

                if (guardaPagina >= 0) {
                    if (guardaPagina > 0 && guardaPagina < 10) {        //Hago un if para saber la ultima pagina
                        inicio = 0;
                        laPaginaActual = 1;                             //comparando el numero de pagina
                    } else if (guardaPagina > 9 && guardaPagina < 100) {    //a division con el total de pagina
                        inicio = (parseInt(guardaPagina.toString().substring(0, 1))) + "2";
                    } else if (guardaPagina > 99 && guardaPagina < 1000) {
                        inicio = guardaPagina.toString().substring(0, 2) + "2";
                    } else if (guardaPagina > 999 && guardaPagina < 10000) {
                        inicio = guardaPagina.toString().substring(0, 3) + "2";
                    } else if (guardaPagina > 9999 && guardaPagina < 100000) {
                        inicio = guardaPagina.toString().substring(0, 4) + "2";
                    }

                    if (inicio > guardaPagina)
                        inicio = guardaPagina;

                    if (guardaPagina == inicio) {
                        inicio = inicio - TotalPaginador;
                        PAGINAACTUAL = Math.ceil(laPaginaActual);

                        Get_UsuarioPersonal(UsuarioLogin.Personal_Id, Get_PersonalFind(), inicio);

                        setPaginaActual(PAGINAACTUAL);
                    } else if (guardaPagina != TotalPaginador) {
                        PAGINAACTUAL = Math.ceil(laPaginaActual);

                        Get_UsuarioPersonal(UsuarioLogin.Personal_Id, Get_PersonalFind(), inicio);

                        setPaginaActual(PAGINAACTUAL);
                    } else {
                        inicio = 0;
                    }
                }
            });

            $('#btnPrimero').click(function () {  //metodos para actualizar
                inicio = 0;         //Primer Registro
                PAGINAACTUAL = 1;   //Primera Pagina

                Get_UsuarioPersonal(UsuarioLogin.Personal_Id, Get_PersonalFind(), inicio);

                setPaginaActual(PAGINAACTUAL);
            });

            $('#btnAnterior').click(function () {  //metodos para actualizar
                if (inicio > 0) {
                    inicio = parseInt(inicio) - TotalPaginador;
                    if (inicio < 0) {
                        inicio = 0;
                    }
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;

                    Get_UsuarioPersonal(UsuarioLogin.Personal_Id, Get_PersonalFind(), inicio);

                    setPaginaActual(PAGINAACTUAL);
                }

            });
            $('#btnSiguiente').click(function () {  //metodos para actualizar

                if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
                    inicio = parseInt(inicio) + parseInt(TotalPaginador);
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;

                    Get_UsuarioPersonal(UsuarioLogin.Personal_Id, Get_PersonalFind(), inicio);

                    setPaginaActual(PAGINAACTUAL);
                }

            });

            function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
                $('#txtPaginaActual').val(nPagina);
            }

        });
    </script>
</asp:Content>
