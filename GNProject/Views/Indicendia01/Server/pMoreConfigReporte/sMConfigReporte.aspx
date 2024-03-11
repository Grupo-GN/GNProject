<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sMConfigReporte.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pMoreConfigReporte.sMConfigReporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

        <div id="tabContainer"  style="width:98%;min-height:400px;">
            <ul>
                <li><a href="#Tab1">CAUSAS</a></li>
                <li><a href="#Tab2">TIPO</a></li>
                <li><a href="#Tab3">TIPO DE PERSONA</a></li>
            </ul>
        <div id="Tab1">
            <input type="button" class="buttonHer" value="NUEVO" id="btnNewCausas" />
            <fieldset style="vertical-align:top;">
                <legend><label class="miTituloField">BUSCAR</label></legend>
                <label class="miLabel">Causa : </label><input type="text" class="txt" style="font-size:12px;width:250px;" id="txtCausasFind" />&nbsp;&nbsp;&nbsp;&nbsp;
                <label class="miLabel">Tipo : </label><select id="cboTipoCFind" class="cbo" style="font-size:12px;"><option value="">TODAS</option><option value="01">CAUSAS BÁSICAS</option><option value="02">CAUSAS INMEDIATAS</option></select>&nbsp;&nbsp;&nbsp;&nbsp;
                <label class="miLabel">Estado : </label><select id="cboEstadoCFind" class="cbo" style="font-size:12px;"><option value="01">ACTIVO</option><option value="02">INACTIVO</option></select>
            </fieldset>
            
                  <div  style="overflow: hidden; width: 100%; border: solid 1px #505050;height: 340px;">
                    <table class="table">
                        <thead>
                                <tr>
                                    <th></th>            
                                    <th></th>  
                                    <th>CAUSA</th>
                                    <th>TIPO</th>
                                    <th>DESCRIPCION</th>
                                    <th>ESTADO</th>
                                </tr>
                        </thead>

                        <tbody id="tbodyCausas">

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
        <div id="Tab2" style="font-size:12px;">
            <fieldset style="width:95%;">
                <legend><label class="miTituloField">TIPO DE INCIDENTE</label></legend>
                <table style="width:100%;">
                    <tr>
                        <td rowspan="6" style="width:30%;">
                            <select id="lbTipoI" size="10" style="width:100%;">

                            </select>
                        </td>
                        <td><label class="miLabel">Configuracion:</label> </td>
                    </tr>
                    <tr>
                        <td><label class="miLabel">Tipo:</label></td>
                    </tr>
                    <tr>
                        <td><input id="txtDescipcionTI" type="text" class="txt" style="width:100%;" /></td>
                    </tr>
                    <tr>
                        <td><label class="labelError" id="lblErrorTI">&nbsp;</label></td>
                    </tr>
                    <tr>
                        <td><input id="btnGrabarTipoI" type="button" class="submit" value="Grabar"/>&nbsp;&nbsp;
                        <input id="btnCancelTipoI" type="button" class="submit" value="Cancelar" />&nbsp;&nbsp;
                        <input id="btnDeleteTipoI" type="button" class="submit" value="Eliminar" /></td>
                    </tr>
                    <tr>
                        <td>                        
                            </td>
                    </tr>
                </table>

            </fieldset>
        </div>
        <div id="Tab3" style="font-size:12px;">
<fieldset style="width:95%;">
                <legend><label class="miTituloField">TIPO DE PERSONA EN EL INCIDENTE</label></legend>
                <table style="width:100%;">
                    <tr>
                        <td rowspan="6" style="width:30%;">
                            <select id="lbAfectado" size="10" style="width:100%;">

                            </select>
                        </td>
                        <td><label class="miLabel">Configuracion:</label> </td>
                    </tr>
                    <tr>
                        <td><label class="miLabel">Afectado:</label></td>
                    </tr>
                    <tr>
                        <td><input id="txtDescripcionA" type="text" class="txt" style="width:100%;" /></td>
                    </tr>
                    <tr>
                        <td><label class="labelError" id="lblErrorA">&nbsp;</label></td>
                    </tr>
                    <tr>
                        <td><input id="btnGrabarAfec" type="button" class="submit" value="Grabar"/>&nbsp;&nbsp;
                        <input id="btnCancelAfec" type="button" class="submit" value="Cancelar" />&nbsp;&nbsp;
                        <input id="btnDeleteAfec" type="button" class="submit" value="Eliminar" /></td>
                    </tr>
                    <tr>
                        <td>                        
                            </td>
                    </tr>
                </table>

            </fieldset>
        </div>
        </div>

        <div id="dialog-Causa" title="CAUSAS DEL INCIDENTE">
            <table class="tableDialog">
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td style="width:90px;text-align:right;"><label class="miLabel">Codigo : </label></td>
                    <td><input type="text" class="txtCodigo" value="????" id="txtCodigoC" readonly/></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Tipo : </label></td>
                    <td><select id="cboTipoC" class="cbo"><option value="01">CAUSAS BÁSICAS</option><option value="02">CAUSAS INMEDIATAS</option></select></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Causa : </label></td>
                    <td><input type="text" class="txt" style="width:100%;" id="txtCausaNombre"/></td>
                </tr>
                <tr>
                    <td style="text-align:right;vertical-align:text-top;"><label class="miLabel">Descripcion : </label></td>
                    <td><textarea rows="2" cols="10" style="width:100%;" id="txtDescripcionC"></textarea></td>
                </tr>

                <tr>
                    <td style="text-align:right;"><label class="miLabel">Estado : </label></td>
                    <td><select id="cboEstadoC" class="cbo"><option value="01">ACTIVO</option><option value="02">INACTIVO</option></select></td>
                </tr>
                <tr>
                    <td colspan="2"><label class="labelError" id="lblErrorC">&nbsp;</label></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center"><input type="button" class="submit" value="GRABAR" id="btnGrabarC"/>&nbsp;&nbsp;<input type="button" class="submit" value="CANCELAR" id="btnCancelC"/></td>
                </tr>
            </table>
        </div>

        <br /><br /><br />


    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Script_MoreConfigReporte.js" type="text/javascript"></script>
    <script src="Script_TipoIncidente.js" type="text/javascript"></script>
    <script src="Script_AfectadoInc.js" type="text/javascript"></script>
    <script type="text/javascript">
        var TotalPaginador = 12;
        var TOTALREGISTROS;
        var inicio = 0;
        var PAGINAACTUAL = 1;
        var TIPOPROCESO = '';
        var CausaProc_Id = '';

        var PROCESOTIPO = '01';
        var TipoIProc_Id = '';

        var PROCESOAFEC = '01';
        var AfecIProc_Id = '';

        $(document).ready(function () {
            $('#dialog-Causa').hide();
            $('#tabContainer').tabs();

            Get_Causas_Incidentes_List(get_CausaFind(), get_TipoCFind(), get_EstadoCFind(), inicio);
            Get_TipoIncidente_List();
            Get_AfectadoInc_List();

            $('#btnNewCausas').click(function () {
                TIPOPROCESO = '01';
                CausaProc_Id = '';
                clear_ModalCausa();
                open_Modal_Causa();
            });

            $('#txtCausasFind').keyup(function () {
                inicio = 0;
                Get_Causas_Incidentes_List(get_CausaFind(), get_TipoCFind(), get_EstadoCFind(), inicio);
            });

            $('#cboTipoCFind').change(function () {
                inicio = 0;
                Get_Causas_Incidentes_List(get_CausaFind(), get_TipoCFind(), get_EstadoCFind(), inicio);
            });

            $('#cboEstadoCFind').change(function () {
                inicio = 0;
                Get_Causas_Incidentes_List(get_CausaFind(), get_TipoCFind(), get_EstadoCFind(), inicio);
            });


            $('#btnCancelC').click(function () {
                $('#dialog-Causa').dialog('close');
            });

            $('#tbodyCausas').on('click', '.buttonEdit', function () {
                var codigo = this.id;
                codigo = codigo.substring(1);
                Get_Causa_Find(codigo);

            });



            $('#tbodyCausas').on('click', '.buttonDesactiva', function () {
                if (confirm('¿Esta seguro de desactivar la causa?')) {
                    var codigo = this.id.substring(1);
                    Get_Causas_Delete(codigo, '02')
                }
            });

            $('#tbodyCausas').on('click', '.buttonActiva', function () {
                if (confirm('¿Esta seguro de activar el causa?')) {
                    var codigo = this.id.substring(1);
                    Get_Causas_Delete(codigo, '01')
                }
            });



            $('#btnGrabarC').click(function () {
                $('#lblErrorC').html('&nbsp;');

                var nombre = $('#txtCausaNombre').val();
                var descripcion = $('#txtDescripcionC').val();
                var tipo = $('#cboTipoC').val();
                var estado = $('#cboEstadoC').val();

                if (!nombre) {
                    $('#lblErrorC').html('.::Error > Causa no definida.');
                    $('#txtCausaNombre').focus();
                    return false;
                }
                if (!tipo) {
                    $('#lblErrorC').html('.::Error > Tipo no definido.');
                    $('#cboTipoC').focus();
                    return false;
                }
                if (!estado) {
                    $('#lblErrorC').html('.::Error > Estado no definido.');
                    $('#cboEstadoC').focus();
                    return false;
                }


                if (!TIPOPROCESO) {
                    alert('.::Error > Proceso no identificado.');
                    return false;
                } else {
                    if (TIPOPROCESO == '01') {
                        Get_Causas_Add(nombre.toUpperCase(), descripcion, tipo, estado);
                    } else if (TIPOPROCESO == '02') {
                        Get_Causas_Update(CausaProc_Id, nombre.toUpperCase(), descripcion, tipo, estado);
                    }
                }
            });


            //TIPO DE INCIDENTE

            $('#lbTipoI').change(function () {
                var optionVal = $('#lbTipoI option:selected').val();
                var optionText = $('#lbTipoI option:selected').text();
                $('#txtDescipcionTI').val(optionText);
                TipoIProc_Id = optionVal;
                PROCESOTIPO = '02';
            });


            $('#btnGrabarTipoI').click(function () {

                $('#lblErrorTI').html('&nbsp;');
                if (!PROCESOTIPO) {
                    $('#lblErrorTI').html('.::Error, Proceso no identificado.');
                    return false;
                }
                var Descripcion = $('#txtDescipcionTI').val();
                if (!Descripcion) {
                    $('#lblErrorTI').html('.::Error, Descripcion no definida.');
                    $('#txtDescipcionTI').focus();
                    return false;
                }
                if (PROCESOTIPO == '01') {
                    Get_Add_TipoIncidente(Descripcion.toUpperCase());
                } else if (PROCESOTIPO == '02') {
                    if (!TipoIProc_Id) {
                        $('#lblErrorTI').html('.::Error > Tipo de incidente no identificada.');
                        return false;
                    }
                    Get_Update_TipoIncidente(TipoIProc_Id, Descripcion.toUpperCase());
                }
            });
            $('#btnCancelTipoI').click(function () {
                PROCESOTIPO = '01';
                TipoIProc_Id = '';
                $('#txtDescipcionTI').val('');
                $('#lblErrorTI').html('&nbsp;');
                $('#lbTipoI').children().removeAttr('selected');

            });
            $('#btnDeleteTipoI').click(function () {

                $('#lblErrorTI').html('&nbsp;');
                if (!TipoIProc_Id) {
                    $('#lblErrorTI').html('.::Error > Tipo de incidente no identificada.');
                    return false;
                }
                if (confirm('¿Esta seguro de continuar?')) {
                    Get_Delete_TipoIncidente(TipoIProc_Id);
                }
            });


            //END TIPO DE INCIDENTE

            //AFECTADO EN EL INCIDENTE

            $('#lbAfectado').change(function () {
                var optionVal = $('#lbAfectado option:selected').val();
                var optionText = $('#lbAfectado option:selected').text();
                $('#txtDescripcionA').val(optionText);
                AfecIProc_Id = optionVal;
                PROCESOAFEC = '02';
            });


            $('#btnGrabarAfec').click(function () {

                $('#lblErrorA').html('&nbsp;');
                if (!PROCESOAFEC) {
                    $('#lblErrorA').html('.::Error, Proceso no identificado.');
                    return false;
                }
                var Descripcion = $('#txtDescripcionA').val();
                if (!Descripcion) {
                    $('#lblErrorA').html('.::Error, Descripcion no definida.');
                    $('#txtDescripcionA').focus();
                    return false;
                }
                if (PROCESOAFEC == '01') {
                    Get_Add_AfectadoInc(Descripcion.toUpperCase());
                } else if (PROCESOAFEC == '02') {
                    if (!AfecIProc_Id) {
                        $('#lblErrorA').html('.::Error > Tipo de afectado no identificado.');
                        return false;
                    }
                    Get_Update_AfectadoInc(AfecIProc_Id, Descripcion.toUpperCase());
                }
            });
            $('#btnCancelAfec').click(function () {
                PROCESOAFEC = '01';
                AfecIProc_Id = '';
                $('#txtDescripcionA').val('');
                $('#lblErrorA').html('&nbsp;');
                $('#lbAfectado').children().removeAttr('selected');

            });
            $('#btnDeleteAfec').click(function () {

                $('#lblErrorA').html('&nbsp;');
                if (!AfecIProc_Id) {
                    $('#lblErrorA').html('.::Error > Tipo de afectado no identificado.');
                    return false;
                }
                if (confirm('¿Esta seguro de continuar?')) {
                    Get_Delete_AfectadoInc(AfecIProc_Id);
                }
            });


            //END AFECTADO EN EL INCIDENTE
















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

                        Get_Causas_Incidentes_List(get_CausaFind(), get_TipoCFind(), get_EstadoCFind(), inicio);

                        setPaginaActual(PAGINAACTUAL);
                    } else if (guardaPagina != TotalPaginador) {
                        PAGINAACTUAL = Math.ceil(laPaginaActual);

                        Get_Causas_Incidentes_List(get_CausaFind(), get_TipoCFind(), get_EstadoCFind(), inicio);

                        setPaginaActual(PAGINAACTUAL);
                    } else {
                        inicio = 0;
                    }
                }
            });

            $('#btnPrimero').click(function () {  //metodos para actualizar
                inicio = 0;         //Primer Registro
                PAGINAACTUAL = 1;   //Primera Pagina

                Get_Causas_Incidentes_List(get_CausaFind(), get_TipoCFind(), get_EstadoCFind(), inicio);

                setPaginaActual(PAGINAACTUAL);
            });

            $('#btnAnterior').click(function () {  //metodos para actualizar
                if (inicio > 0) {
                    inicio = parseInt(inicio) - TotalPaginador;
                    if (inicio < 0) {
                        inicio = 0;
                    }
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;

                    Get_Causas_Incidentes_List(get_CausaFind(), get_TipoCFind(), get_EstadoCFind(), inicio);

                    setPaginaActual(PAGINAACTUAL);
                }

            });
            $('#btnSiguiente').click(function () {  //metodos para actualizar

                if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
                    inicio = parseInt(inicio) + parseInt(TotalPaginador);
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;

                    Get_Causas_Incidentes_List(get_CausaFind(), get_TipoCFind(), get_EstadoCFind(), inicio);

                    setPaginaActual(PAGINAACTUAL);
                }

            });

            function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
                $('#txtPaginaActual').val(nPagina);
            }


        });
    </script>
</asp:Content>
