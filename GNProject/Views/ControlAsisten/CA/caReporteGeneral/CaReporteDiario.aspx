<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CaReporteDiario.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.caReporteGeneral.CaReporteDiario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
<fieldset>
    <legend class="miTituloField">FILTROS</legend>
    <table class="tableDialog">
        <tr>
            <td style="width:150px;text-align:right;"><label class="miLabel">Planilla : </label></td>
            <td><select class="cbo" id="cboPlanilla"></select></td>
            <td style="text-align:right;"><label class="miLabel">Periodo : </label></td>
            <td><select class="cbo" id="cboPeriodo"></select></td>
            <td style="text-align:right;"><label class="miLabel">Localidad : </label></td>
            <td><select class="cbo" id="cboLocalidad"></select></td>
        </tr>
        <tr style="display:none;">
            <td style="text-align:right;"><label class="miLabel">Area : </label></td>
            <td><select class="cbo" id="cboCategoriaAux"></select></td>
            <td style="text-align:right;"><label class="miLabel">Sección : </label></td>
            <td><select class="cbo" id="cboCategoriaAux2"></select></td>
            <td style="text-align:right;"><label class="miLabel">Categoria : </label></td>
            <td><select class="cbo" id="cboCategoria"></select></td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Personal : </label></td>
            <td><select class="cbo" id="cboPersonal"></select></td>
            <td style="text-align:right;"><label class="miLabel">Tipo Reporte : </label></td>
            <td>
                <select id="cbosemana" class="cbo"  >
                    </select>

            </td>
            <td></td>
        </tr>
        <tr style="display:none;">
            <td style="text-align:right;"><label class="miLabel">Fecha Inicio : </label></td>
            <td><input type="text" class="txt" id="txtFechaInicio" /></td>
            <td style="text-align:right;"><label class="miLabel">Fecha Final : </label></td>
            <td><input type="text" class="txt"  id="txtFechaFinal"/></td>
            <td></td>
            <td></td>
        </tr>
    </table>

</fieldset>


    <%--style="display:none;"--%>
<br />
    <div style="display:none;" class="loader-page"></div>
<section id="tabContainer" style="font-size: small; ">
    <ul>
        <li><a href="#Tab1">LISTA DE HORAS EXTRA</a></li>
        <%--<li><a href="#Tab2">BOLSA DE HORAS A COMPENSAR</a></li>--%>
    </ul>
<section id="Tab1">
<fieldset>
    <table class="tableDialog">
        <tr>
            <td style="width:130px;"><input type="button" class="buttonHer" value="GENERAR" id="btnGenerar" /></td>
                <td style="width:130px;"><input type="button" class="buttonHer" id="btnExportar" value="EXPORTAR" /></td>
            <%--<td style="width:130px;"><input type="button" class="buttonHer" id="btnAplicar" value="Aplicar" /></td>--%>
           <%-- <td style="width:130px;"><input style="display:none;" type="button" class="buttonHer" id="btnPDF" value="PDF" /></td>--%>
             <%--<td><label class="miLabel">Cantidad de Horas : </label>
                            <label id="lbl0HET" class="miLabel"></label></td>--%>
            <td></td>
        </tr>
    </table>
</fieldset>
<br />   
       

 
  

<table id="tablReporte"   cellpadding="0" cellspacing="0" width="100%" class="table tableFixHead"  style="height: 550px;" >
    <thead   >
        <tr  >
            <%--<th><input type="checkbox" id="chkAll" /></th>--%>
             <th style="display:none;width:0px;">ASISTENCIA_ID</th>
             <th style="display:none;width:0px;">PERSONAL_ID</th>
             <th style="display:none; width:0px;">Periodo</th>
            <th   >DNI</th>
            <th style="cursor:help;  " title="NOMBRES Y APELLIDOS">PERSONAL</th>
            <th  style="cursor:help;  " title="AREA">AREA</th>
            <th   >CARGO</th>
            <th  >EMPRESA</th>
            <th style="cursor:help; " title="CONDICION">COND.</th>
            <th style="cursor:help; " title="SUELDO BASICO">SUEL.</th>
            <th  >1</th>
             <th  >2</th>
             <th  >3</th>
             <th  >4</th>
             <th  >5</th>
             <th  >6</th>
             <th  >7</th>
             <th  >8</th>
             <th  >9</th> 
             <th  >10</th>
             <th  >11</th>
             <th  >12</th>
             <th  >13</th>
             <th  >14</th>
             <th  >15</th>
             <th  >16</th>
             <th  >17</th>
             <th  >18</th>
            <th  >19</th>
            <th  >20</th>
            <th  >21</th>
            <th  >22</th>
            <th  >23</th>
            <th  >24</th>
            <th  >25</th>
            <th  >26</th>
            <th  >27</th>
            <th  >28</th>
            <th  >29</th>
            <th  >30</th>
            <th  >31</th>
            <th style="cursor:help; " title="Total de Horas Laboradas">HET</th>
            <th style="cursor:help; " title="Horas Extras Simples">HES</th>
            <th style="cursor:help;" title="Horas Extras Adicionales">HEA</th>
            <th style="cursor:help;" title="Horas Extras Dobles">HED</th>
            <th style="cursor:help;" title="DIAS DE PERMISO">DP</th>
            <th style="cursor:help;" title="HORAS DE PERMISO">HP</th>
            <th style="cursor:help;" title="SEGUNDA QUINCENA">2°QNA</th>
            <th style="cursor:help;" title="DESCANSO MEDICO">DMED</th>
            <th style="cursor:help;" title="TOTAL DOMINICAL">TD</th>
             <th style="cursor:help;" title="# DE ASISTENCIA">ASIS</th>
             <th style="cursor:help;" title="# DE VACACIONES">VAC</th>
             <th style="cursor:help;" title="TOTAL FALTAS">TF</th>
             <th style="cursor:help;" title="TOTAL TARDANZAS">TT</th>
            <th style="cursor:help;" title="TOTAL ASISTENCIA">TA</th>
            <th style="cursor:help;" title="TOTAL DIAS TRABAJADOS">TDT</th>
          
        </tr>
    </thead>
    <tbody id="tbodyNovedades"    >

    </tbody>
</table>



    </section>
  
</section>

     <fieldset>

    <legend>Legenda</legend>

 <table class="auto-style1">
  <tr>
    <th class="auto-style5">Faltas</th>
    <td style="background: #FAA491; text-align:center;" class="auto-style4">F</td>
  </tr>
  <tr>
    <th class="auto-style5" >Tardanza:</th>
    <td style="background: #FAF891; text-align:center;" class="auto-style4">T</td>
  </tr>
  <tr>
       <th class="auto-style5" >Asistencia:</th>
    <td style="background:rgb(255, 255, 255); text-align:center; width:20px" >1</td>
  </tr>
  <tr>
       <th class="auto-style5" >Dominical:</th>
    <td style="background:orange; text-align:center; width:20px" >D</td>
  </tr>
  <tr>
   <th class="auto-style5" >Dif. Mes:</th>
    <td style="background:#CDFAFC; text-align:center; width:20px" >0</td>
  </tr>
</table>

  </fieldset>

    <%--style="display:none;"--%>
 


    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <%--<script src="Script_ReporteGeneral.js" type="text/javascript"></script>--%>
    <%--<script src="Scripts/Script_CrearMenu.js" type="text/javascript"></script>--%>
    <script src="../../jsExportExcel/ScriptExportarExcel.js" type="text/javascript"></script>
<%--    <link href="../Justificacion/Scripts/sweetalert2.min.css" rel="stylesheet" />
    <script src="../Justificacion/Scripts/sweetalert2.min.js" type="text/javascript"></script>--%>
    <script src="ScriptReporteDiario.js" type="text/javascript"></script>
    <%--<script src="Script_HE.js" type="text/javascript"></script>--%>
  
    <script src="jquery.fixedtableheader.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var Personal_Proc = '<%= Session["Usuario_Id"] %>';
        var NivelAcceso_Proc = '<%= Session["Usuario_NivelAcceso"] %>';
        var Planilla_Id_Proc = '<%= Session["Usuario_Planilla_Id"] %>';
        var Area_Id_Proc = '<%= Session["Usuario_Area_Id"] %>';
        var CatAuxiliar_Id_Proc = '<%= Session["Usuario_CatAuxiliar_Id"] %>';
        var CatAuxiliar2_Id_Proc = '<%= Session["Usuario_CatAuxiliar2_Id"] %>';
        var PersonalSelec = [];
        var PersonalSelecbk = [];

        $(document).ready(function () {
            //$('#tablReporte').fixedtableheader();
            //$('#tablReporte').fixedtableheader({
            //    highlightclass: 'rowhlite',
            //    headerrowsize:2
            //});

            $('#tabContainer').tabs();
            Get_semana_List();
            CrearCuadroFechas();
            //if (NivelAcceso_Proc == "04") {
            //    $('#cboPlanilla').prop("disabled", true);
            //    $('#cboLocalidad').prop("disabled", true);
            //    $('#cboCategoriaAux').prop("disabled", true);
            //    $('#cboCategoriaAux2').prop("disabled", true);
            //    $('#cboCategoria').prop("disabled", true);
            //    $('#cboPersonal').prop("disabled", true);

            //    $('#btnPDF').hide();
            //    $('#tablReporte').hide();
            //    $('#tblReportePersonal').show();
            //}
            //else {
            //    $('#btnPDF').show();
            //    $('#tablReporte').show();
            //    $('#tblReportePersonal').hide();
            //}
            Get_Planilla_List();
            Get_Periodo_Activo_By_CA(Get_Planilla_Find());
            Get_Localidad_List();
            Get_Categoria_Auxiliar_List();
            Get_Categoria_Auxiliar2_List(Get_CategoriaAux_Find());
            Get_Categoria_List();
           
            Get_PeriodoCA_By_Planilla(Get_Periodo_Find());

            $('#cboPlanilla').change(function () {
                Get_Periodo_Activo_By_CA(Get_Planilla_Find());
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());
            });
            $('#cboPeriodo').change(function () {
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());
                Get_PeriodoCA_By_Planilla($(this).val());
            });
            $('#cboLocalidad').change(function () {
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());
            });
            $('#cboCategoriaAux').change(function () {
                Get_Categoria_Auxiliar2_List(Get_CategoriaAux_Find());
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());
            });
            $('#cboCategoriaAux2').change(function () {
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());
            });
            $('#cboCategoria').change(function () {
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());
            });


            Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());

           $('#cboPersonal').change(function () {
                
                PersonalSelec = [];
                PersonalSelec.push($(this).val());
            });

            $('#btnGenerar').click(function () {
                var FechaInicio = $('#txtFechaInicio').val();
                var FechaFinal = $('#txtFechaFinal').val();
                var treport = $('#cbosemana').val();
                if (treport=='') {
                    alert('SELECCIONAR TIPO REPORTE');
                    return false;
                }
                if (FechaFinal=='' || FechaInicio=='') {
                    alert('SELECCIONAR FECHA VALIDA');
                    return false;
                }
                if ($('#cboPersonal').val() == '') {
                    Get_LISTARREPORTEDIARIO(Get_Planilla_Find(), Get_Periodo_Find(), Get_Localidad_Find(), PersonalSelecbk, treport);
                } else {
                    Get_LISTARREPORTEDIARIO(Get_Planilla_Find(), Get_Periodo_Find(), Get_Localidad_Find(), PersonalSelec,treport);
                }

                //if ($('#cboPersonal').val()=='') {
                //    Get_LISTARREPORTEDIARIO2(Get_Planilla_Find(), Get_Periodo_Find(), Get_Localidad_Find(), PersonalSelecbk,FechaInicio,FechaFinal);
                //} else {
                //    Get_LISTARREPORTEDIARIO2(Get_Planilla_Find(), Get_Periodo_Find(), Get_Localidad_Find(), PersonalSelec, FechaInicio, FechaFinal);
                //}
                //Get_LISTARREPORTEDIARIO(Get_Planilla_Find(), Get_Periodo_Find(), Get_Localidad_Find(), PersonalSelec);

               
                //getListHE(Get_Planilla_Find(), Get_Periodo_Find(), Get_Localidad_Find(), $('#cboPersonal').val());
               
            });

            $('#btnExportar').click(function () {
                if (NivelAcceso_Proc == "04") {
                    exportExcel('tblReportePersonal', 'Reporte_Diario');
                }
                else {
                    exportExcel('tablReporte', 'Reporte_Diario');
                }

            });
 
            /// incio nueva clase


            function removeClassName(elem, className) {
                elem.className = elem.className.replace(className, "").trim();
            }

            function addCSSClass(elem, className) {
                removeClassName(elem, className);
                elem.className = (elem.className + " " + className).trim();
            }

            String.prototype.trim = function () {
                return this.replace(/^\s+|\s+$/, "");
            }

            function stripedTable() {
                if (document.getElementById && document.getElementsByTagName) {
                    var allTables = document.getElementsByTagName('table');
                    if (!allTables) { return; }

                    for (var i = 0; i < allTables.length; i++) {
                        if (allTables[i].className.match(/[\w\s ]*scrollTable[\w\s ]*/)) {
                            var trs = allTables[i].getElementsByTagName("tr");
                            for (var j = 0; j < trs.length; j++) {
                                removeClassName(trs[j], 'alternateRow');
                                addCSSClass(trs[j], 'normalRow');
                            }
                            for (var k = 0; k < trs.length; k += 2) {
                                removeClassName(trs[k], 'normalRow');
                                addCSSClass(trs[k], 'alternateRow');
                            }
                        }
                    }
                }
            }

         

            stripedTable();




           
        });
        //window.onload = function () { stripedTable(); }
    </script>

<style type="text/css">
      .loader-page {
    position: fixed;
    z-index: 25000;
    background: rgb(255, 255, 255);
    left: 0px;
    top: 0px;
    height: 100%;
    width: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
    transition:all .3s ease;
  }
  .loader-page::before {
    content: "";
    position: absolute;
    border: 2px solid rgb(50, 150, 176);
    width: 60px;
    height: 60px;
    border-radius: 50%;
    box-sizing: border-box;
    border-left: 2px solid rgba(50, 150, 176,0);
    border-top: 2px solid rgba(50, 150, 176,0);
    animation: rotarload 1s linear infinite;
    transform: rotate(0deg);
  }
 
  .table {
  display: block;
  font-family: sans-serif;
  -webkit-font-smoothing: antialiased;
  font-size: 90%;
  overflow: auto;
  width: auto;
 
  
  th{
            
    color: white;
    font-weight: normal;
    padding: 20px 30px;
    text-align: center;
    /*display: block;*/
    overflow: auto;
     /*display: table;*/
     
  }
  td{

    background-color: rgb(238, 238, 238);
    color: rgb(111, 111, 111);
    padding: 20px 30px;
    /*display: block;*/
    overflow: auto;
  }
}


 .tableFixHead {
  overflow: auto;
  height: 100px;
}

.tableFixHead thead th {
  position: sticky;
  top: 0;
}


   

    .auto-style1 {
        width: 10%;
    }
    .auto-style4 {
        width: 20px;
    }
    .auto-style5 {
        width: 20px;
    }

 

 
   

</style>

</asp:Content>
