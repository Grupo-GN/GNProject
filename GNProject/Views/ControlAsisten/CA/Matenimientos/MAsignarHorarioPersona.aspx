<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MAsignarHorarioPersona.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.MAsignarHorarioPersona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <link href="../../css/index.css" rel="stylesheet" />
 <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />

    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
<%--    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />--%>
    <link href="/Assets/Css/tables.css" rel="stylesheet" type="text/css" />
  
<br />
<div class="container">
    <table class="tableDialog" style="max-width: 800px">
	<tr>
		<td><label class="miLabel"> Planilla : </label></td>
        <td>
        <select name="Planilla" id="cboPlanilla" class="cbo">
        
        </select> 
        </td>

        <td><label class="miLabel"> Periodo : </label></td>
		<td>
        <select name="Periodo" id="cboPeriodo" class="cbo">
        </select>
        </td>
        <td rowspan="2"'><input id="btnVer" type="button" value="Ver" class="button-81" /></td>
	</tr>
	<tr>
		<td><label class="miLabel">  Localidad : </label></td>
		<td>
         <select name="Localidad" id="cboLocalidad" class="cbo">
        </select> 
        </td>
        <td><label class="miLabel"> Área : </label></td>
		<td>
        <select name="Area" id="cboArea" class="cbo">
        </select> 
        </td>
	</tr>
</table>
</div>


<br />


    <fieldset>
   <%-- modidga height: 380px--%>
<%--     <div id="HeaderDiv" style="overflow: auto; width: 100%; border: solid 1px #505050;height: 380px;">

     <table id="tblCarac" class="table" style="overflow: scroll;">

        <thead><tr>
        <th></th>
        <th>Localidad</th>
        <th>Seccion</th>
        <th>Nombres</th>
        <th>Horarios</th>
        </tr></thead>

       <tbody class="tbody" id="tbodyAsignarHorarioPersona">

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
               
                        <input id="cargar_primera_pagina" type="button" value="|<" class="submitPager" />
                        <input id="cargar_anterior_pagina" type="button" value="<<" class="submitPager" />
                        <input id="cargar_siguiente_pagina" type="button" value=">>" class="submitPager" />
                        <input id="cargar_ultima_pagina" type="button" value=">|" class="submitPager" />
                    </td>

                </tr>
            </tfoot>
        </table>
 
    </div>--%>
  <section class="ftco-section">
        <div class="container">
            <div class="table-wrap">
                <table class="table">
                    <thead class="thead-primary" id="thead-primary">
                        <tr>
                            <th>Localidad</th>
                            <th>Seccion</th>
                            <th>Nombres</th>
                            <th>Horarios</th>
                            <th>Editar</th>
                        </tr>
                    </thead>
                 
                     <tbody class="tbody" id="tbodyAsignarHorarioPersona" >
                      
                    </tbody>
                </table>
                
            </div>
        </div>
    </section>
    </fieldset>



    <div id="dialog-form" style="border-radius:20px">
        <table class="tableDialog">
            <tr>
                <td style="width: 80px;">
                    <label class="miLabel">Codigo : </label>
                </td>
                <td style="width:190px">
                    <input id="txtCodigo" type="text" readonly="readonly"
                        class="txtCodigo" value="???" />
                </td>
            </tr>
            <tr>
                <td>
                    <label class="miLabel">Horarios : </label>
                </td>
                <td>
                    <select id="cboHorarios" class="cbo">
                    </select>
                </td>
            </tr>

            <tr>
                <td colspan="2">

                    <table style="width: 100%">
                        <tr>
                            <td style="height: 3px;" colspan="2">
                                <label id="lblError" class="miLabelError"></label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" style="width: 100%;">
                                <input id="btnGrabar" type="button" value="Grabar" class="submit" />
                                <input id="btnCancelar" type="button" value="Salir" class="submit" />
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>

        </table>

<label id="lblCodigSeleccionao"></label>

 </div>

 <div id="divError"></div>



    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_MantAsignarHorarioPersona.js" type="text/javascript"></script>
    <script src="Scripts/index.js"></script>
    <script type="text/javascript">
        var inicio = 0;
        var TotalPaginador = 12;
        var TOTALREGISTROS;
        var PAGINAACTUAL = 1;

        var resultados_por_pagina = 13;
        var pagina_actual = 1;
        var pagina_ultima = 0;
        var totalreg = 0;

        $(document).ready(function () {
            var inicio = 0;
   
            
            $('#dialog-form').css('display', 'none');

            function mensajeError(msg) {
                $('#lblError').html(msg);
            }

            function closeModalDiv() {
                $('#dialog-form').dialog('close');
            }

            $('#btnCancelar').click(function () {
                closeModalDiv();

            });

            function getPlanilla() {
                return $('#cboPlanilla').val();
            }


            inicilizaObjetos();
            Get_Planillas_List(inicio);
            Get_Localidades_List(inicio);
           
            Get_Periodos_List('01');
            Get_Areas_List(inicio);
            Get_Horarios_List(inicio);

            $('#cboPlanilla').click(function () {

                Get_Periodos_List(getPlanilla());

            });

            function pasaModal() {

                $("#dialog-form").dialog({
                    height: 373, width: 560, modal: true, autoOpen: true,
                    appendTo: "form", title: "ASIGNACIÓN DE HORARIOS POR PERSONA",
                    show: { effect: "fade", duration: 800 },
                    hide: { effect: "fold", duration: 800 }
                });
            }



            $('#tbodyAsignarHorarioPersona').on('click', '.buttonEdit', function () {
                var codigo = this.id;
                codigo = codigo.substring(7);
                $('#txtCodigo').val(codigo);
                pasaModal();
            });

            $('#btnVer').click(function () {  //
                var Periodo_id = $('#cboPeriodo').val();
                var seccion = $('#cboArea').val();
                var area_id = $('#cboLocalidad').val();

                seccion = seccion.trim();
                Get_AsignarHorarioPersonas_List(Periodo_id, seccion, area_id, inicio);
                cargarpag();
           
            });


            //Get_Categoria_List(inicio, "", "01");

            $('#btnGrabar').click(function () {
                var Personal_Id = $('#txtCodigo').val();
                var Horario_Id = $('#cboHorarios').val();

                var Periodo_id = $('#cboPeriodo').val();
                var seccion = $('#cboArea').val();
                var area_id = $('#cboLocalidad').val();

                Get_AsignarHorarioPersonas_Update(Personal_Id, Horario_Id);
                Get_AsignarHorarioPersonas_List(Periodo_id, seccion, area_id, inicio);
                cargarpag();
               
                closeModalDiv();
           });

           function inicilizaObjetos() {
                $('#txtCodigo').val('???');
                $('#cboPlanilla').val('');
                $('#cboLocalidad').val('');
                $('#cboPeriodo').val('');
                $('#cboArea').val('');
                $('#cboHorarios').val('');
            }

           function cargarpag() {
               var total_registros = parseInt(totalReg);
               //saber cuantas paginas vamos a mostrar
               pagina_ultima = Math.round(total_registros / resultados_por_pagina) + 1;
               cargarPaginaNueva(pagina_actual, pagina_ultima, 'tblCarac', resultados_por_pagina);
           }



            function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
                $('#txtPaginaActual').val(nPagina);
            }

            //contar todos los registros que tenemos
            var total_registros = parseInt($('#txtnRegistros').val());
            //saber cuantas paginas vamos a mostrar
            pagina_ultima = Math.round(total_registros / resultados_por_pagina) + 1;
            //cargar la primera pagina


        });

    </script>

</asp:Content>
