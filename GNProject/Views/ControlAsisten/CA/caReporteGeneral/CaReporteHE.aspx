<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CaReporteHE.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.caReporteGeneral.CaReporteHE" %>

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
            <td colspan="2"><select class="cbo" id="cboPersonal"></select></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
      <%--      <td style="text-align:right;"><label class="miLabel">Fecha Inicio : </label></td>
            <td><input type="text" class="txt" id="txtFechaInicio" /></td>
            <td style="text-align:right;"><label class="miLabel">Fecha Final : </label></td>
            <td><input type="text" class="txt"  id="txtFechaFinal"/></td>
            <td></td>--%>
            <td></td>
        </tr>
    </table>

</fieldset>


    <%--style="display:none;"--%>
<br />
    <div style="display:none;" class="loader-page"></div>
<section id="tabContainer" style="font-size: small;">
    <ul>
        <li><a href="#Tab1">LISTA DE HORAS EXTRA</a></li>
        <li><a href="#Tab2">BOLSA DE HORAS A COMPENSAR</a></li>
    </ul>
<section id="Tab1">
<fieldset>
    <table class="tableDialog">
        <tr>
            <td style="width:130px;"><input type="button" class="buttonHer" value="GENERAR" id="btnGenerar" /></td>
            <td style="width:130px;"><input type="button" class="buttonHer" id="btnAplicar" value="Aplicar" /></td>
           <%-- <td style="width:130px;"><input style="display:none;" type="button" class="buttonHer" id="btnPDF" value="PDF" /></td>--%>
             <td><label class="miLabel">Cantidad de Horas : </label>
                            <label id="lbl0HET" class="miLabel"></label></td>
            <td></td>
        </tr>
    </table>
</fieldset>
<br />   
       
<table  class="table tableFixHead"  style="height: 550px;" id="tablReporte" >
    <thead>
        <tr>
            <th><input type="checkbox" id="chkAll" /></th>
             <th style="display:none;">ASISTENCIA_ID</th>
             <th style="display:none;">PERSONAL_ID</th>
            <th>PERSONAL</th>
            <th>FECHA</th>
            <th style="cursor:help;" title="Hora de Inicio del Horario">HIH</th>
            <th style="cursor:help;" title="Hora de Fin del Horario">HFH</th>
            <th style="cursor:help;" title="Hora de Ingreso Marcada">HIM</th>
            <th style="cursor:help;" title="Hora de Salida Marcada">HSM</th>
            <th style="cursor:help;" title="Total de Horas Laboradas">HET</th>
            <th style="cursor:help;" title="Horas Extras Simples">HES</th>
            <th style="cursor:help;" title="Horas Extras Adicionales">HEA</th>
            <th style="cursor:help;" title="Horas Extras Dobles">HED</th>
            <th>PLANILLA</th>
            <th style="display:none;">PERIODO</th>
            <th>LOCALIDAD</th>
            <th>AREA</th>
            <th style="display:none;">SECCION</th>
            <th>Tipo</th>
          
        </tr>
    </thead>
    <tbody id="tbodyReporte" >

    </tbody>
</table>
    </section>
    <section id="Tab2">
        <fieldset>
    <table class="tableDialog">
        <tr>
         
            <td style="width:130px;"><input type="button" class="buttonHer" id="btnGenera" value="GENERAR" /></td>
           <%-- <td style="width:130px;"><input style="display:none;" type="button" class="buttonHer" id="btnPDF" value="PDF" /></td>--%>
            <td><label class="miLabel">Cantidad de Horas : </label>
                            <label id="lblHET" class="miLabel"></label></td>
        </tr>
    </table>
</fieldset>
<br /> 
      <table  cellpadding="0" cellspacing="0" width="100%" class="table tableFixHead"  style="height: 550px;" id="tablReporte2" >
    <thead>
        <tr>
           
            <th>PERSONAL</th>
            <th>FECHA</th>
            <th style="cursor:help;" title="Hora de Inicio del Horario">HIH</th>
            <th style="cursor:help;" title="Hora de Fin del Horario">HFH</th>
            <th style="cursor:help;" title="Hora de Ingreso Marcada">HIM</th>
            <th style="cursor:help;" title="Hora de Salida Marcada">HSM</th>
            <th style="cursor:help;" title="Total de Horas Laboradas">HET</th>
            <th style="cursor:help;" title="Horas Extras Simples">HES</th>
            <th style="cursor:help;" title="Horas Extras Adicionales">HEA</th>
            <th style="cursor:help;" title="Horas Extras Dobles">HED</th>
            <th style="display:none;">PLANILLA</th>
            <th style="display:none;">PERIODO</th>
            <th>LOCALIDAD</th>
            <th>AREA</th>
            <th style="display:none;">CAT.AUX</th>
            <th style="display:none;">SECCION</th>
            <th>F.REGISTRO</th>
            <th>ESTADO</th>
            <th>TIPO</th>
 
        </tr>
    </thead>
    <tbody id="tbodyReporte2" >

    </tbody>
</table>
    </section>
</section>

    <%--style="display:none;"--%>
 


    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <%--<script src="Script_ReporteGeneral.js" type="text/javascript"></script>--%>
    <script src="Script_HE.js" type="text/javascript"></script>
    <script src="Script_HE.js"></script>
    <%--<script src="Scripts/Script_CrearMenu.js" type="text/javascript"></script>--%>
    <script src="../../jsExportExcel/ScriptExportarExcel.js" type="text/javascript"></script>
    <link href="../Justificacion/Scripts/sweetalert2.min.css" rel="stylesheet" />
    <script src="../Justificacion/Scripts/sweetalert2.min.js" type="text/javascript"></script>


    <script type="text/javascript">
        var  Personal_Proc = '<%= Session["Usuario_Id"] %>';
        var NivelAcceso_Proc = '<%= Session["Usuario_NivelAcceso"] %>';
        var Planilla_Id_Proc = '<%= Session["Usuario_Planilla_Id"] %>';
        var Area_Id_Proc = '<%= Session["Usuario_Area_Id"] %>';
        var CatAuxiliar_Id_Proc = '<%= Session["Usuario_CatAuxiliar_Id"] %>';
        var CatAuxiliar2_Id_Proc = '<%= Session["Usuario_CatAuxiliar2_Id"] %>';
        var PersonalSelec = [];

        $(document).ready(function () {
            if (NivelAcceso_Proc == "04") {
                $('#cboPlanilla').prop("disabled", true);
                $('#cboLocalidad').prop("disabled", true);
                $('#cboCategoriaAux').prop("disabled", true);
                $('#cboCategoriaAux2').prop("disabled", true);
                $('#cboCategoria').prop("disabled", true);
                $('#cboPersonal').prop("disabled", true);

                $('#btnPDF').hide();
                $('#tablReporte').hide();
                $('#tblReportePersonal').show();
            }
            else {
                $('#btnPDF').show();
                $('#tablReporte').show();
                $('#tblReportePersonal').hide();
            }
            Get_Planilla_List();
            Get_Periodo_Activo_By_CA(Get_Planilla_Find());
            Get_Localidad_List();
            Get_Categoria_Auxiliar_List();
            Get_Categoria_Auxiliar2_List(Get_CategoriaAux_Find());
            Get_Categoria_List();
            //CrearCuadroFechas();
            Get_PeriodoCA_By_Planilla(Get_Periodo_Find());

            Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());

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

            $('#btnGenerar').click(function () {
                //var FechaInicio = $('#txtFechaInicio').val();
                //var FechaFinal = $('#txtFechaFinal').val();

                //if ($('#cboPersonal').val() == '') {
                    //Get_ReporteGeneral_By_Personal(Get_Planilla_Find(), Get_Periodo_Find(), Get_Localidad_Find(), PersonalSelec, FechaInicio, FechaFinal);
                //} else {
                //    var PersoUno = [];
                    //PersoUno.push($('#cboPersonal').val());
                getListHE(Get_Planilla_Find(), Get_Periodo_Find(), Get_Localidad_Find(), $('#cboPersonal').val());
                //}
            });

            ///boton exportar
            //$('#btnExportar').click(function () {
            //    if (NivelAcceso_Proc == "04") {
            //        exportExcel('tblReportePersonal', 'Reporte General');
            //    }
            //    else {
            //        exportExcel('tablReporte', 'Reporte General');
            //    }

            //});

            //$('#btnPDF').click(function () {
            //    var FechaInicio = $('#txtFechaInicio').val();
            //    var FechaFinal = $('#txtFechaFinal').val();
            //    var url = '';
            //    if ($('#cboPersonal').val() == '') {
            //        //setTimeout("location.href='../caReportes/cReporteGeneralPDF.aspx?pla=" + Get_Planilla_Find() + "&per=" + Get_Periodo_Find() + "&loc=" + Get_Localidad_Find() + "&fini=" + FechaInicio + "&ffin=" + FechaFinal + "&perso=" + PersonalSelec + "'", 5);
            //        url = '../caReportes/cReporteGeneralPDF.aspx?pla=' + Get_Planilla_Find() + '&per=' + Get_Periodo_Find() + '&loc=' + Get_Localidad_Find() + '&fini=' + FechaInicio + '&ffin=' + FechaFinal + '&perso=' + PersonalSelec;
            //    } else {
            //        var PersoUno = [];
            //        PersoUno.push($('#cboPersonal').val());
            //        //setTimeout("location.href='../caReportes/cReporteGeneralPDF.aspx?pla=" + Get_Planilla_Find() + "&per=" + Get_Periodo_Find() + "&loc=" + Get_Localidad_Find() + "&fini=" + FechaInicio + "&ffin=" + FechaFinal + "&perso=" + PersoUno + "'", 5);
            //        url = '../caReportes/cReporteGeneralPDF.aspx?pla=' + Get_Planilla_Find() + '&per=' + Get_Periodo_Find() + '&loc=' + Get_Localidad_Find() + '&fini=' + FechaInicio + '&ffin=' + FechaFinal + '&perso=' + PersoUno;
            //    }

            //    if (window.showModalDialog) {
            //        window.showModalDialog(url, 'Archivos Reporte', "dialogWidth:700px;dialogHeight:250px");
            //    } else {
            //        window.open(url, 'Archivos Reporte','height=700,width=250,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no ,modal=yes');
            //    }
            //});
        });
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
  @keyframes rotarload {
      0%   {transform: rotate(0deg)}
      100% {transform: rotate(360deg)}
  }
  .loader-page::after {
    content: "";
    position: absolute;
    border: 2px solid rgba(50, 150, 176,.5);
    width: 60px;
    height: 60px;
    border-radius: 50%;
    box-sizing: border-box;
    border-left: 2px solid rgba(50, 150, 176, 0);
    border-top: 2px solid rgba(50, 150, 176, 0);
    animation: rotarload 1s ease-out infinite;
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
     display: table;
     
  }
  td{

    background-color: rgb(238, 238, 238);
    color: rgb(111, 111, 111);
    padding: 20px 30px;
    display: block;
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



</style>

</asp:Content>
