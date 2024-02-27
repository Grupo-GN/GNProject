<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sPersonal.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pPersonal.sPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <%@ Import Namespace="GNProject.Acceso" %>

    


    <input type="button" value="NUEVO" class="buttonHer" id="btnNew" />
    <input type="button" value="GRABAR" class="buttonHer" id="btnGrabar" />

    <div id="tabContainer" style="width:98%;min-height:400px;">
        <ul>
            <li><a href="#Tab1">FICHERO</a></li>
            <li><a href="#Tab2">DATOS</a></li>
        </ul>
        <div id="Tab1">
<fieldset>
    <legend>BUSQUEDA</legend>   
    <label>Localidad : </label><select id="cboLocalidadFind" style="font-size:12px;" class="cbo"></select>
    <label>Apellidos y Nombres : </label><input type="text" class="txt"  id="txtNombresFind" style="width:300px;font-size:14px;"/>
    <label>Estado : </label><select id="cboEstadoFind" class="cbo" style="font-size:12px;"><option value="">TODOS</option><option value="01">ACTIVO</option><option value="02">INACTIVO</option></select>
</fieldset>

<div  style="overflow: hidden; width: 100%; border: solid 1px #505050;height: 340px;">
<table class="table">
<thead>
        <tr>
            <th></th>            
            <th></th>  
            <th>PERSONAL</th>
            <th>LOCALIDAD</th>
            <th>CARGO</th>
            <th>CATEGORIA AUXILIAR</th>
            <th>CATEGORIA AUXILIAR 2</th>
            <th>ESTADO</th>
        </tr>
</thead>

<tbody id="tbodyPersonal">

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
        
        </div>
        <div id="Tab2">
        <table class="tableDialog">
           <tr>
                <td colspan="2"><label class="labelError" id="lblError"></label></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="width:140px;"></td>
                <td></td>
                <td colspan="2" rowspan="7" style="vertical-align:top;">
                    <img id="imgPersonal" 
                        style="width:173px; height:154px; border:solid 1px black;" /></td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="miLabel"> Cogido : </label></td>
                <td><input type="text" class="txtCodigo" /></td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="miLabel"> Apellido Paterno : </label></td>
                <td><input id="txtApePat" type="text" class="txt" style="width:250px;" /></td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="miLabel"> Apellido Materno : </label></td>
                <td><input id="txtApeMat" type="text" class="txt" style="width:250px;" /></td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="miLabel"> Nombres : </label></td>
                <td><input id="txtNombres" type="text" class="txt" style="width:250px;" /></td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="miLabel"> Nro Documento : </label></td>
                <td><input id="txtNroDoc" type="text" class="txt" style="width:250px;" /></td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="miLabel"> Email : </label></td>
                <td><input id="txtemail" type="email" class="txt" style="width:250px;text-transform:none;" /></td>
            </tr>
            
           <tr>
                <td style="text-align:right;"><label class="miLabel"> Fecha de Nacimiento : </label></td>
                <td><input id="txtFechaNaci" type="text" class="txt" style="width:150px;" /></td>
                <td colspan="2">
                    <input id="fileToUpload" type="file" name="archivos[]"  accept="image/*"  />
                    <input type="button" onclick="uploadFile()" value="SUBIR" class="submit" />
                </td>
            </tr>
            
            <tr>
                <td style="text-align:right;"><label class="miLabel"> Planilla : </label></td>
                <td><select  id="cboPlanilla" class="cbo" style="width:200px;"></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="miLabel"> Cargo : </label></td>
                <td><select id="cboCargo" class="cbo" ></select></td>
                <td style="text-align:right;"><label class="miLabel"> Área : </label></td>
                <td><select id="cboCategoriaAuxiliar" class="cbo" style="width:200px;"></select></td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="miLabel"> Localidad : </label></td>
                <td><select id="cboLocalidad" class="cbo" style="width:200px;"></select></td>
                <td style="text-align:right;"><label class="miLabel"> Sección : </label></td>
                <td><select id="cboCategoriaAuxiliar2" class="cbo" style="width:200px;"></select></td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="miLabel"> Estado : </label></td>
                <td><select id="cboEstado" class="cbo" style="width:200px;"><option value="01">ACTIVO</option><option value="02">INACTIVO</option></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <fieldset>
            <legend><label class="miTituloField">SISTEMA</label></legend>
            <table class="tableDialog">

            <tr>
                <td style="text-align:right;width:130px;"><label class="miLabel"> Rol : </label></td>
                <td><select id="cboRolSistema" class="cbo" style="width:200px;">
                        <option value="01">Administrador</option>
                        <option value="02">Jefe</option>
                        <option value="03">Normal</option>
                        </select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="miLabel"> Codigo Lima Gas : </label></td>
                <td><input id="txtCodigoLG" type="text" class="txt" style="width:250px;" /></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="miLabel"> Usuario : </label></td>
                <td><input id="txtUsuario" type="text" class="txt" style="width:250px;text-transform:none;" /></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="miLabel"> Contraseña : </label></td>
                <td><input id="txtContraseñaU" type="password" class="txt" style="width:250px;text-transform:none;" /> <input type="checkbox" id="chkMostrarPass" /><label class="miLabel">Mostrar</label></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:right;"><label class="miLabel"> Acceso al sistema : </label></td>
                <td><input type="radio" id="rdAcceso" name="acceso" value="01" title="Si" /> <label class="miLabel">Si</label>
                &nbsp; &nbsp; <input type="radio" id="rdNoAcceso" name="acceso" value="02" title="Si" /> <label class="miLabel">No</label></td>
                <td></td>
                <td></td>
            </tr>
            </table>
        </fieldset>
        </div>
    </div>


    <br /><br /><br /><br /><br />
    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Script_HelpDatos.js" type="text/javascript"></script>
    <script src="Script_Personal.js" type="text/javascript"></script>
    <script type="text/javascript">
        var TotalPaginador = 12;
        var TOTALREGISTROS;
        var inicio = 0;
        var PAGINAACTUAL = 1;
        var TIPOPROCESO = '';
        var Personal_Proc = '';
        $(document).ready(function () {
            $('#tabContainer').tabs();
            $('#txtFechaNaci').datepicker({ changeYear: true,
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
                dateFormat: 'dd/mm/yy',
                isRTL: false
            }
        );
            $.datepicker.setDefaults($.datepicker.regional['es']);

            $('#tabContainer').tabs('option', 'disabled', [1]);


            Get_Localidad_Combo();
            Get_Planilla_Combo();
            Get_Cargo_Combo();
            Get_Categoria_Auxiliar_Combo();
            Get_Categoria_Auxiliar2_Combo();

            Get_Personal_List(Get_Nombres_Find(), Get_Localidad_Find(), Get_Estado_Find(), inicio);

            $('#cboCategoriaAuxiliar').change(function () {
                Get_Categoria_Auxiliar2_Combo();
            });

            $('#cboLocalidadFind').change(function () {
                inicio = 0;
                Get_Personal_List(Get_Nombres_Find(), Get_Localidad_Find(), Get_Estado_Find(), inicio);
            });


            $('#cboEstadoFind').change(function () {
                inicio = 0;
                Get_Personal_List(Get_Nombres_Find(), Get_Localidad_Find(), Get_Estado_Find(), inicio);
            });
            $('#txtNombresFind').keyup(function () {
                inicio = 0;
                Get_Personal_List(Get_Nombres_Find(), Get_Localidad_Find(), Get_Estado_Find(), inicio);
            });


            $('#tbodyPersonal').on('click', '.buttonEdit', function () {
                var codigo = this.id.substring(1);
                Get_Personal_Find(codigo);
            });





            $('#tbodyPersonal').on('click', '.buttonDesactiva', function () {
                if (confirm('¿Esta seguro de desactivar el personal?')) {
                    var codigo = this.id.substring(1);
                    Get_DeleteEstado_Personal(codigo, '02')
                }
            });

            $('#tbodyPersonal').on('click', '.buttonActiva', function () {
                if (confirm('¿Esta seguro de activar el personal?')) {
                    var codigo = this.id.substring(1);
                    Get_DeleteEstado_Personal(codigo, '01')
                }
            });

            $('#chkMostrarPass').click(function () {
                var mos = $('#chkMostrarPass').is(':checked');
                if (mos) {
                    $('#txtContraseñaU').attr('type', 'text');
                } else {
                    $('#txtContraseñaU').attr('type', 'password');
                }
            });
            $('#tabContainer').on("tabsactivate", function (event, ui) {
                var $tabs = $('#tabContainer').tabs();
                var selected = $tabs.tabs('option', 'active');
                if (TIPOPROCESO != '') {
                    if (parseInt(selected) != 1) {
                        $('#btnGrabar').attr('disabled', 'disabled');
                    } else {
                        $('#btnGrabar').removeAttr('disabled');
                    }
                }
            });

            $('#btnNew').click(function () {
                clear_Tab();
                $('#tabContainer').tabs('enable');
                $('#tabContainer').tabs('option', 'active', 1);
                $('#btnGrabar').removeAttr('disabled');
                TIPOPROCESO = '01';
                Personal_Proc = '';
            });

            $('#btnGrabar').click(function () {
                $('#lblError').html('&nbsp;');
                if (!TIPOPROCESO) {
                    return false;
                }

                var ApePat = $('#txtApePat').val();
                var ApeMat = $('#txtApeMat').val();
                var Nombres = $('#txtNombres').val();
                var NroDoc = $('#txtNroDoc').val();
                var email = $('#txtemail').val();

                var FecNac = $('#txtFechaNaci').val();
                var Planilla_Id = $('#cboPlanilla').val();
                var Cargo_Id = $('#cboCargo').val();
                var Loc_Id = $('#cboLocalidad').val();
                var Aux = $('#cboCategoriaAuxiliar').val();
                var Aux2 = $('#cboCategoriaAuxiliar2').val();
                var Estado_Id = $('#cboEstado').val();
                var Cod_LG = $('#txtCodigoLG').val();
                var RolSis = $('#cboRolSistema').val();
                var Acceso = $('input[type=radio][name=acceso]:checked').val();


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
                if (!NroDoc) {
                    $('#lblError').html('.::Error, Nro de documento no definido.');
                    $('#txtNroDoc').focus();
                    return false;
                }
                if (!email) {
                    $('#lblError').html('.::Error, Email no definido.');
                    $('#txtemail').focus();
                    return false;
                }
                if (!FecNac) {
                    $('#lblError').html('.::Error, Fecha nacimiento no definida.');
                    $('#txtFechaNaci').focus();
                    return false;
                }
                FecNac = formatFecha.format1(FecNac);
                if (FecNac.length != 10) {
                    $('#lblError').html('.::Error, Fecha invalida.');
                    $('#txtFechaNaci').focus();
                    return false;
                }
                if (!Planilla_Id) {
                    $('#lblError').html('.::Error,Planilla no definida.');
                    $('#cboPlanilla').focus();
                    return false;
                }
                if (!Cargo_Id) {
                    $('#lblError').html('.::Error,Cargo no definido.');
                    $('#cboCargo').focus();
                    return false;
                }
                if (!Loc_Id) {
                    $('#lblError').html('.::Error,Localidad no definida.');
                    $('#cboLocalidad').focus();
                    return false;
                }
                if (!Aux) {
                    $('#lblError').html('.::Error,Categoria Auxiliar no definida.');
                    $('#cboCategoriaAuxiliar').focus();
                    return false;
                }
                if (!Aux2) {
                    $('#lblError').html('.::Error,Categoria Auxiliar 2 no definida.');
                    $('#cboCategoriaAuxiliar2').focus();
                    return false;
                }

                if (!Estado_Id) {
                    $('#lblError').html('.::Error,Estado no definido.');
                    $('#cboEstado').focus();
                    return false;
                }

                if (!RolSis) {
                    $('#lblError').html('.::Error,Rol en el sistema no definido.');
                    $('#cboRolSistema').focus();
                    return false;
                }

                if (TIPOPROCESO == '01') {
                    Get_Add_Personal(Planilla_Id, ApePat.toUpperCase(),
                     ApeMat.toUpperCase(), Nombres.toUpperCase(), FecNac, NroDoc, email, Cargo_Id
                     , Loc_Id, Aux, Aux2, Cod_LG, Estado_Id, RolSis);

                } else if (TIPOPROCESO == '02') {
                    var Usuario = $('#txtUsuario').val();
                    var PassSis = $('#txtContraseñaU').val();
                    if (RolSis != '03') {
                        /*if (!Usuario) {
                            $('#lblError').html('.::Error,Usuario no definido.');
                            return false;
                        }
                        if (!PassSis) {
                            $('#lblError').html('.::Error,Contraseña no definida.');
                            return false;
                        }*/
                        if (!Acceso) {
                            $('#lblError').html('.::Error,Acceso no definido.');
                            return false;
                        }
                    } else {
                        Usuario = '-';
                        PassSis = '-';
                        Acceso = '02';
                    }
                    Get_Update_Personal(Personal_Proc, Planilla_Id, ApePat.toUpperCase(), ApeMat.toUpperCase()
                    , Nombres.toUpperCase(), FecNac, NroDoc, email, Cargo_Id, Loc_Id, Aux, Aux2, Cod_LG, Estado_Id, RolSis, Usuario, PassSis, Acceso);

                }
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

                        Get_Personal_List(Get_Nombres_Find(), Get_Localidad_Find(), Get_Estado_Find(), inicio);

                        setPaginaActual(PAGINAACTUAL);
                    } else if (guardaPagina != TotalPaginador) {
                        PAGINAACTUAL = Math.ceil(laPaginaActual);

                        Get_Personal_List(Get_Nombres_Find(), Get_Localidad_Find(), Get_Estado_Find(), inicio);

                        setPaginaActual(PAGINAACTUAL);
                    } else {
                        inicio = 0;
                    }
                }
            });

            $('#btnPrimero').click(function () {  //metodos para actualizar
                inicio = 0;         //Primer Registro
                PAGINAACTUAL = 1;   //Primera Pagina

                Get_Personal_List(Get_Nombres_Find(), Get_Localidad_Find(), Get_Estado_Find(), inicio);

                setPaginaActual(PAGINAACTUAL);
            });

            $('#btnAnterior').click(function () {  //metodos para actualizar
                if (inicio > 0) {
                    inicio = parseInt(inicio) - TotalPaginador;
                    if (inicio < 0) {
                        inicio = 0;
                    }
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;

                    Get_Personal_List(Get_Nombres_Find(), Get_Localidad_Find(), Get_Estado_Find(), inicio);

                    setPaginaActual(PAGINAACTUAL);
                }

            });
            $('#btnSiguiente').click(function () {  //metodos para actualizar

                if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
                    inicio = parseInt(inicio) + parseInt(TotalPaginador);
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;

                    Get_Personal_List(Get_Nombres_Find(), Get_Localidad_Find(), Get_Estado_Find(), inicio);

                    setPaginaActual(PAGINAACTUAL);
                }

            });

            function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
                $('#txtPaginaActual').val(nPagina);
            }

        });
    </script>
</asp:Content>
