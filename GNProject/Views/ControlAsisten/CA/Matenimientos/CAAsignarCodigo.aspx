<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CAAsignarCodigo.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.CAAsignarCodigo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

    <label class="miTitulo">ASIGNAR CODIGO</label>
 <br />
    <table class="tableDialog">
	<tr>
		<td><label class="miLabel" style="width:50%;"> Planilla : </label></td>
        <td>
        <select id="cboPlanilla" class="cbo" ></select> 
        </td>
        <td><label class="miLabel" style="width:50%;"> Seccion : </label></td>
		<td>
        <select id="cboSeccion" class="cbo" ></select>
        </td>
        <td rowspan="2"'><input id="btnVer" type="button"  value="Ver" class="buttonHer" /></td>
	</tr>
	<tr>
		<td><label class="miLabel" style="width:50%;">  Localidad : </label></td>
		<td>
         <select id="cboLocal"  class="cbo"></select> 
        </td>
        <td><label class="miLabel" style="width:50%;"> Periodo : </label></td>
		<td>
        <select id="cboPeriodo"  class="cbo" disabled="disabled"></select> 
        </td>
	</tr>
 </table>


    <br />
   <%-- <fieldset>
    <legend class="miTitulo">Datos</legend>
    <label class="miLabel">Planilla: </label>&nbsp;&nbsp;
    <select id="" class="ddl">
    
    </select>&nbsp;&nbsp;&nbsp;&nbsp;
    <label class="miLabel">Seccion: </label>&nbsp;&nbsp;
    <select id="" class="ddl">
    <option>---------</option>
    </select>&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <label class="miLabel">Localidad: </label>&nbsp;&nbsp;
    <select id="" class="ddl">
    <option>---------</option>
    </select>&nbsp;&nbsp;&nbsp;&nbsp;
    <label class="miLabel">Periodo: </label>&nbsp;&nbsp;
    <select id="cboPeriodo" class="ddl">
    <option>---------</option>
    </select>&nbsp;&nbsp;&nbsp;&nbsp;
    <input id="btnVer" class="submitListo" value="Ver"/>
    <br />
    <label id="lblError" class="miLabelError" ></label>
        
    </fieldset>--%>

    <div id="HeaderDiv" style="overflow:auto; width: 100%; border: solid 1px #505050;max-height:980px;min-height:400px;">
    <table id="tblAH" class="table">
    <thead class="theadth">
    <tr>
    <th  class="theadth" scope="col"></th>
    <th  class="theadth" scope="col"></th>
    <th  class="theadth" scope="col">Localidad</th>
    <th  class="theadth" scope="col">Seccion</th>
    <th  class="theadth" scope="col">Apellidos-Nombres</th>
    <th  class="theadth" scope="col">Codigo</th>
    </tr>
    </thead>
    
    <tbody id="tbodyAH" class="tbody">
   <%-- sfdsf--%>
    </tbody>
        
    </table>
    
    </div>

     <%--<div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
    <table class="table">
         <tfoot>
        <tr>
        <td class="tfoottd"  colspan="3">

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
    </div>--%>
    <div id="dialog-form"></div>

    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_CAAsignarCodigo.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var inicio = 0;
            var TotalPaginador = 12;
            var TOTALREGISTROS;
            var PAGINAACTUAL = 1;

            function getPlanilla() {
                return $('#cboPlanilla').val();
            }
            function getSeccion() {
                return $('#cboSeccion').val();
            }
            function getLocal() {
                return $('#cboLocal').val();
            }
            function getPeriodo() {
                return $('#cboPeriodo').val();
            }
            Get_Localidades_List();
            Get_Planillas_List();
            Get_Areas_List();
            List_Periodo('01');
            CargarPersonal(getSeccion(), getLocal(), getPeriodo());
            function mensajeError(msg) {
                $('#lblError').html(msg);
            }
            var CodigoOrigen = "";

            $('#tbodyAH').on('click', '.buttonEdit', function () {
                TIPOPROCESO = '02';
                var codigo = this.id;
                codigo = codigo.substring(7);
                CodigoOrigen = codigo;
                var a = "#txtC" + codigo;
                $(a).attr('disabled', false);

            });


            $('#tbodyAH').on('click', '.buttonGrabar', function () {
                var codigo = this.id;
                var codigo2 = this.id;
                var cant = CodigoOrigen.length;
                codigoActual = codigo.substring(7, 7 + cant);
                codigoPersona = codigo2.substring(7 + cant, 13 + cant);
                alert(codigoActual);
                alert(codigoPersona);
                var a = "#txtC" + codigoActual;
                codigoNuevo = $(a).val();

                //                codigo = $(codigo).attr('id');

                //                if (codigoNuevo == "" || codigoNuevo == null) {
                //                    mensajeError('ERROR... Debe digitar codigo');
                //                    $(a).val().focus();
                //                    return false;
                //                }
                //                if (codigoNuevo.length != 8) {
                //                    mensajeError('ERROR... el codigo es incorrecto');
                //                    $(a).val().focus();
                //                    return false;
                //                }
                if (codigoNuevo == "" || codigoNuevo == null) {
                    codigoNuevo = "0";
                }

                mensajeError('&nbsp');
                AsignarCodigo_Save(codigoPersona, CodigoOrigen, codigoNuevo);
                CargarPersonal(getSeccion(), getLocal(), getPeriodo());
                $(a).attr('disabled', true);
            });


            $('#cboPlanilla').change(function () {
                List_Periodo(getPlanilla());
            });

            $('#btnVer').click(function () {
                CargarPersonal(getSeccion(), getLocal(), getPeriodo());
            });
            $('#btnUltimo').click(function () {  //metodos para actualizar

                var guardaPagina = parseInt($('#txtnRegistros').val());
                var laPaginaActual = guardaPagina / TotalPaginador;

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
                    // var descripcion = $('#txtBuscar').val();
                    Get_Horarios_List(inicio);
                    Get_Horarios_MaxRegistro();

                    setPaginaActual(PAGINAACTUAL);

                }
                ///////////modidga///////////////
                if (guardaPagina > inicio) {
                    inicio = (TotalPaginador * Math.floor(laPaginaActual));
                    PAGINAACTUAL = Math.ceil(laPaginaActual);
                    Get_Horarios_List(inicio);
                    Get_Horarios_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                }
                ////////////////////////////////////////////////////

                else if (guardaPagina != TotalPaginador) {
                    PAGINAACTUAL = Math.ceil(laPaginaActual);
                    //var descripcion = $('#txtBuscar').val();
                    Get_Horarios_List(inicio);
                    Get_Horarios_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                } else {
                    inicio = 0;
                }

            });

            $('#btnPrimero').click(function () {  //metodos para actualizar
                inicio = 0;         //Primer Registro
                PAGINAACTUAL = 1;   //Primera Pagina
                //var descripcion = $('#txtBuscar').val();
                Get_Horarios_List(inicio);
                Get_Horarios_MaxRegistro();
                setPaginaActual(PAGINAACTUAL);
            });

            $('#btnAnterior').click(function () {  //metodos para actualizar
                if (inicio > 0) {
                    inicio = parseInt(inicio) - TotalPaginador;
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;

                    //var descripcion = $('#txtBuscar').val();
                    Get_Horarios_List(inicio);
                    Get_Horarios_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                }

            });

            $('#btnSiguiente').click(function () {  //metodos para actualizar

                if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
                    inicio = parseInt(inicio) + parseInt(TotalPaginador);
                    PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;

                    // var descripcion = $('#txtBuscar').val();
                    Get_Horarios_List(inicio);
                    Get_Horarios_MaxRegistro();
                    setPaginaActual(PAGINAACTUAL);
                }

            });

            function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
                $('#txtPaginaActual').val(nPagina);
            }

        });

    </script>
    
</asp:Content>
