<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlAsistencia.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.caReporteGeneral.ControlAsistencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
   <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"   type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <%--<script src="Scripts/jquery.min.js"></script>--%>
   

      <label class="miTitulo">CONTROL DE ASISTENCIAS</label>
    <br />
    <br />
 <fieldset>
        <%--<legend ></legend>--%>
        <label class="miLabel">Planilla: </label>
        &nbsp;&nbsp;
    <select id="cboPlanilla" class="cbo" style="width: 150px;">
    </select>&nbsp;&nbsp;
    <label class="miLabel">Periodo: </label>
        &nbsp;&nbsp;
    <select id="cboPeriodo" class="cbo"></select>&nbsp;&nbsp;
    <label class="miLabel">Localidad: </label>
        &nbsp;&nbsp;
    <select id="cboLocal" class="cbo"></select>
      &nbsp;&nbsp;
         <label class="miLabel">Personal: </label>
        &nbsp;&nbsp;
    <select id="cboPersonal" class="cbo"></select>
        <br />
        <br />
        <label class="miLabel">Generar las Faltas Para: </label>
        <br />
        <label class="miLabel">Fecha Inicio: </label>
        &nbsp;&nbsp; 
      <input id="dtpfi" type="text" class="txt" />&nbsp;&nbsp;
      <label class="miLabel">Fecha Final: </label>
        &nbsp;&nbsp;
      <input id="dtpff" type="text" class="txt" />&nbsp;&nbsp;
      <input id="btnGenerar" type="button" value="GENERAR REPORTE" class="submit" style="width: 250px;" />&nbsp;&nbsp;
      <input id="btnExportar" type="button" value="exportar excel" class="submit" style="width: 150px;" />
        <br />
        <label id="lblMsj" class="miLabelError"></label>
    </fieldset>

  <div id="HeaderDiv" style="overflow: hidden; width: 100%; border: solid 1px #505050;min-height: 500px;">   
<table id="tablReporte"   cellpadding="0" cellspacing="0" width="100%" class="table tableFixHead"  style="height: 500px;" >
    <thead   >
        <tr  >
            <%--<th><input type="checkbox" id="chkAll" /></th>--%>
             <th >Situacion Laboral del Trabajador</th>
             <th >Nombres y apellidos del Trabajador</th>
             <th >Fecha Dia,Mes y Año</th>
            <th   >DNI u Otro Doc. de Identidad</th>
            <th class="auto-style1" >Hora y Minuto de Ingreso al Centro Laboral</th>
            <th class="auto-style1" >Hora y Minuto de Salida de Refrigerio</th>
           <th class="auto-style1" >Hora y Minuto de Ingreso de Refrigerio</th>
            <th class="auto-style1" >Hora y Minuto de Salida del Centro Laboral</th>
          <th class="auto-style1" >Identificacion de Horas Extraordinarias ó Sobretiempos</th>
            <th >Firma del Trabajador</th>
              
        </tr>
    </thead>
    <tbody id="tbodyNovedades"    >

    </tbody>
</table>
</div>



     <%--<script src="Scripts/jquery-3.3.1.min.js"></script>--%>
    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="controlasistencia.js" type="text/javascript"></script>
     <script src="../../jsExportExcel/ScriptExportarExcel.js" type="text/javascript"></script>
    <script src="Script_ReporteGeneral.js" type="text/javascript"></script>
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
            Get_Localidades_List();
            Get_Planillas_List();
            List_Periodo($('#cboPlanilla').val());
           
           
            $('#cboPlanilla').change(function () {
                List_Periodo($(this).val());
                Get_Personal_By_Filtros($('#cboPeriodo').val(), $('#cboLocal').val(), '', '', '');
            });

            $('#cboPeriodo').change(function () {
                Get_PeriodoCA_By_Planillas($(this).val());
                Get_Personal_By_Filtros($('#cboPeriodo').val(), $('#cboLocal').val(), '', '', '');
            });
          
            $('#cboLocal').change(function () {
                Get_Personal_By_Filtros($('#cboPeriodo').val(), $('#cboLocal').val(), '', '', '');
            });

            Get_Personal_By_Filtros($('#cboPeriodo').val(), '', '', '', '');
            Get_PeriodoCA_By_Planillas($('#cboPeriodo').val());

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

        $('#btnGenerar').click(function () {
  
            GetListaControlAsistencia(getPlanilla(), getPeriodo(), getLocal(), $("#cboPersonal").val(), get_fechai(), get_fechaf());
           
        });

        $('#btnExportar').click(function () {
           
            exportExcel('tablReporte', 'Control_Asistencia');
             
            

        });

    </script>



      <style type="text/css">
        .auto-style1 {
            width: 86px;
        }

        
    .table {
  display: block;
  font-family: sans-serif;
  -webkit-font-smoothing: antialiased;
  font-size: 100%;
  overflow: auto;
  width: 100%;
 
  
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


    </style>


</asp:Content>

