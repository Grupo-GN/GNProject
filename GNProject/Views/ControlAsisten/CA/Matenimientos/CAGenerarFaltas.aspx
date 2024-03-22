<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CAGenerarFaltas.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.CAGenerarFaltas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
    <link href="../../css/index.css" rel="stylesheet" />
  
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"   type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.min.js"></script>

    <label class="miTitulo">GENERACIÓN DE FALTAS</label>
    <br />
    <fieldset>
        <%--<legend ></legend>--%>
         
        <div style="display: flex;flex-wrap:wrap;">
            <div style="display: flex; align-items: center;">       
                <label class="miLabel" style="margin: 0px;">Planilla: </label>   
                <div style:"width:200px; border: 3px solid gold"><select id="cboPlanilla" class=""></select></div>
            </div>
            <div style="display: flex; align-items: center;">
                <label class="miLabel" style="margin: 0px;">Localidad: </label>  
                <div style:"width:200px;"><select id="cboLocal" class="" ></select></div>

            </div>
            <div style="display: flex; align-items: center;">
                <label class="miLabel" style="margin: 0px;">Periodo: </label>  
                <div style:"width:100px;"><select id="cboPeriodo" class="" ></select></div>

            </div>
        </div>
   
          
        <label class="miLabel">Generar las Faltas Para: </label>
        <br />
        <label class="miLabel">Fecha Inicio: </label>
        &nbsp;&nbsp; 
      <input id="dtpfi" type="text" class="txt" />&nbsp;&nbsp;
      <label class="miLabel">Fecha Final: </label>
        &nbsp;&nbsp;
      <input id="dtpff" type="text" class="txt" />&nbsp;&nbsp;
      <input id="btnVer" type="button" value="trabajadores que faltan Marcar" class="submit" style="width: 250px;" />&nbsp;&nbsp;
      <input id="btnGenerar" type="button" value="Generar Faltas" class="submit" style="width: 150px;" />
        <br />
        <label id="lblMsj" class="miLabelError"></label>
    </fieldset>
    <div id="HeaderDiv" style="border: solid 1px #505050; " class="auto-style1">
        <table id="tblAH" class="table">
            <thead>
                <tr>
                    <th>Personal_Id</th>
                    <th>Localidad</th>
                    <th>Area</th>
                    <th>Nombres</th>
                </tr>
            </thead>

            <tbody id="tbodyAH" class="tbody">
                <%-- sfdsf--%>
            </tbody>

        </table>
    </div>
    <div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
        <table class="table">
            <tfoot>
                <tr>
                    <td class="tfoottd" colspan="3">
                        <div id="indicador_paginas"></div>
                        <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;">TOTAL REGISTROS: </label>
                        &nbsp
            <input id="txtnRegistros" type="text" value="0" class="TextPage" readonly="readonly" />
                        &nbsp &nbsp
            <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;">PAGE: </label>
                        &nbsp
                <input id="txtPaginaActual" type="text" value="1" class="TextPage" readonly="readonly" />
                         <%--<input id="indicador_paginas" type="text" value="1" class="TextPage" readonly="readonly" />--%>
                     <%--   <input id="btnPrimero" type="button" value="|<" class="submitPager" />
                        <input id="btnAnterior" type="button" value="<<" class="submitPager" />
                        <input id="btnSiguiente" type="button" value=">>" class="submitPager" />
                        <input id="btnUltimo" type="button" value=">|" class="submitPager" />--%>
                        <input id="cargar_primera_pagina" type="button" value="|<" class="submitPager" />
                        <input id="cargar_anterior_pagina" type="button" value="<<" class="submitPager" />
                        <input id="cargar_siguiente_pagina" type="button" value=">>" class="submitPager" />
                        <input id="cargar_ultima_pagina" type="button" value=">|" class="submitPager" />
                    </td>

                </tr>
            </tfoot>
        </table>
        <div>
           <%--  <input type="button" id="cargar_primera_pagina2" value="<< Primero"/> 
             <input id="cargar_primera_pagina" type="button" value="|<" class="submitPager" />
				 <input type="button" id="cargar_anterior_pagina" value="< Anterior"/> 
				<div id="indicador_paginas"></div>
				 <input type="button" id="cargar_siguiente_pagina" value="Siguiente >"/> 
				 <input type="button" id="cargar_ultima_pagina" value="Ultimo >>"/>--%>
        </div>
    </div>
    <div id="divError"></div>
     <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_CAGenerarFaltas.js" type="text/javascript"></script>
       <script src="Scripts/index.js"></script>
   

    <script type="text/javascript">
        $(document).ready(function () {
            Get_Localidades_List();
            Get_Planillas_List();
            List_Periodo($('#cboPlanilla').val());
            Get_PeriodoCA_By_Planilla($('#cboPeriodo').val());

            $('#cboPlanilla').change(function () {
                List_Periodo($(this).val());
            });

            $('#cboPeriodo').change(function () {
                Get_PeriodoCA_By_Planilla($(this).val());
                listaPersonalSinMarcaciones(getPeriodo(), getLocal(), get_fechai(), get_fechaf(), $('#cboPlanilla').val());
                total_registros = parseInt($('#txtnRegistros').val());
                //saber cuantas paginas vamos a mostrar
                pagina_ultima = Math.round(total_registros / resultados_por_pagina) + 1;
                cargarPagina(pagina_actual, pagina_ultima);
            });
            $('#cboLocal').change(function () {            
                listaPersonalSinMarcaciones(getPeriodo(), getLocal(), get_fechai(), get_fechaf(), $('#cboPlanilla').val());
                total_registros = parseInt($('#txtnRegistros').val());
                //saber cuantas paginas vamos a mostrar
                pagina_ultima = Math.round(total_registros / resultados_por_pagina) + 1;
                cargarPagina(pagina_actual, pagina_ultima);
            });
        });
      

    function getPlanilla() {
                return $('#cboPlanilla').val();
            }
    function getLocal() {
                return $('#cboLocal').val();
            }
    function getPeriodo() {
                return $('#cboPeriodo').val();
            }
    

      function mensajeError(msg) {
                $('#lblError').html(msg);
            }

            $("#dtpfi").datepicker({ dateFormat: "dd/mm/yy" });
            $("#dtpff").datepicker({ dateFormat: "dd/mm/yy" });

            function get_fechai() {
                return $("#dtpfi").val();
            }
            function get_fechaf() {
                return $("#dtpff").val();
            }
            $('#btnVer').click(function () {
                listaPersonalSinMarcaciones(getPeriodo(), getLocal(), get_fechai(), get_fechaf(), $('#cboPlanilla').val());

               
                total_registros = parseInt($('#txtnRegistros').val());
                //saber cuantas paginas vamos a mostrar
                pagina_ultima = Math.round(total_registros / resultados_por_pagina)+1;
                cargarPagina(pagina_actual, pagina_ultima);



            });

        $('#btnGenerar').click(function () {
            GenerarFaltas(getPlanilla(), getPeriodo(), getLocal(), get_fechai(), get_fechaf());
            listaPersonalSinMarcacionesN(getPeriodo(), getLocal(), get_fechai(), get_fechaf());
           
        });

        var guardaPagina = parseInt($('#txtnRegistros').val());
        var TotalPaginador = parseInt($('#txtPaginaActual').val());
        var laPaginaActual = guardaPagina / TotalPaginador;
        var inicio = 0;

        $('#btnUltimo').click(function () {  //metodos para actualizar

           

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

         
            var resultados_por_pagina = 12;
            var pagina_actual = 1;
            var pagina_ultima = 0;
            //$(document).ready(function () {
            //contar todos los registros que tenemos
            var total_registros = parseInt($('#txtnRegistros').val());
            //saber cuantas paginas vamos a mostrar
            pagina_ultima = Math.round(total_registros / resultados_por_pagina)+1;
            //cargar la primera pagina
            
            //eventos para los botones
            $("#cargar_primera_pagina").click(function () {
                cargarPagina(1, pagina_ultima);
            });
            $("#cargar_anterior_pagina").click(function () {
                cargarPagina(pagina_actual - 1, pagina_ultima);
            });
            $("#cargar_siguiente_pagina").click(function () {
                cargarPagina(pagina_actual + 1, pagina_ultima);
            });
            $("#cargar_ultima_pagina").click(function () {
                cargarPagina(pagina_ultima, pagina_ultima);
            });
          
            //});
               
      

  
 
    </script>



      <style type="text/css">
        .style1 {
            background-color: #2C6B8D;
            height: 28px;
            font-family: AENOR Fontana ND;
            text-transform: uppercase;
            color: #FFFFFF;
            font-size: 1em;
            font-weight: bold;
            padding: 0px 7px;
            margin: 20px 0px 0px;
            text-align: left;
            width: 307px;
        }
        .auto-style1 {
            overflow: hidden;
            width: 100%;
            height: 380px;
        }
    </style>
</asp:Content>

  

