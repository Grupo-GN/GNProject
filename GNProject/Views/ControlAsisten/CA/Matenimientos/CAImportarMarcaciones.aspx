<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CAImportarMarcaciones.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.CAImportarMarcaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

    <label class="miTitulo">SINCRONIZAR MARCACIONES</label>
    <br />
    <fieldset>
    <legend class="miTituloField">Datos</legend>
    <label class="miLabel">Periodo Vigente: </label>&nbsp;
    <input id="txtcodigo" class="estiloCajaCodigo" readonly="readonly" type="text" style="font-size:12;"/>
    &nbsp;&nbsp;&nbsp;
    <label class="miLabel">Fecha Inicio: </label>&nbsp;
    <input id="txtfi" style="background-color: #FFFFCC; color: #2B60DE;
       font-family:AENOR Fontana ND Demibold;
       font-weight:bold;
       text-align:center;
	    min-height: 16px;
	    border: #B1B1B1 1px solid;
	    text-transform:uppercase;
	    font-size:12px;
	    width:135px;"  type="text" />&nbsp;
    <label class="miLabel">Fecha Fin : </label>&nbsp;
    <input id="txtft" style="background-color: #FFFFCC; color: #2B60DE;
       font-family:AENOR Fontana ND Demibold;
       font-weight:bold;
       text-align:center;
	    min-height: 16px;
	    border: #B1B1B1 1px solid;
	    text-transform:uppercase;
	    font-size:12px;
	    width:135px;"  type="text" />&nbsp;
    </fieldset>
    <fieldset>
    <table style="border-collapse:collapse;width:100%">
        <tr>
            <td style="text-align:right;"><label class="miLabel">Planilla : </label></td>
            <td><select class="cbo" id="cboPlanilla"></select></td>
            <td style="text-align:right;"><label class="miLabel">Periodo : </label></td>
            <td><select class="cbo" id="cboPeriodo"></select></td>
            <td style="text-align:right;"><label class="miLabel">Localidad : </label></td>
            <td><select  class="cbo"  id="cboLocalidad" ></select></td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Area : </label></td>
            <td><select class="cbo" id="cboCatAux"></select></td>
            <td style="text-align:right;"><label class="miLabel">Categoria : </label></td>
            <td><select class="cbo" id="cboCategoria"></select></td>
            <td style="text-align:right;"><label class="miLabel">Personal : </label></td>
            <td><select class="cbo" id="cboPersonal"></select></td>
        </tr>
    </table>
    <input id="btnVer" type="button" value="Ver Marcaciones" class="submit" style="width:150px;"/>
        &nbsp; &nbsp;<label id="lblMsjVer"  class="labelError"></label> 
    </fieldset>
    <hr />
    <input id="btnGuardar" type="button" value="Guardar Marcaciones" class="submit" style="width:150px;"/>
    &nbsp; &nbsp;<label id="lblMsjGuardar"  class="labelError"></label> 
    <hr />
    <label id="lblMsj"  class="labelError"></label> 
    <div id="HeaderDiv" style="overflow: scroll; width: 100%; border: solid 1px #505050;height: 500px;">
        <%--<table id="tblMarc"  class="table tableFixHead"  style="height: 500px;width: 100%;">--%>
            <table id="tblMarc"   cellpadding="0" cellspacing="0" width="100%" height="500px" class="table" style="overflow:scroll;height: 500px;width:100%;" >
   
            <thead>
                <tr>
                    <th>DNI</th>        
                    <th>FECHA</th>
                    <th>HORA INGRESO</th>
                    <th>HORA SALIDA</th>
                    <th>RESULTADO</th>
                </tr>
            </thead>    
            <tbody id="tbodyMarc">
                <tr>
                    <td style="text-align:center;"></td>
                </tr>
            </tbody>        
        </table>
    </div>
    <div id="divError"></div>
    
    <input type="hidden" id="fecha" />
 
     <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/moment.js"  type="text/javascript"></script>
    <script src="Scripts/moment-timezone-with-data-10-year-range.min.js" type="text/javascript"></script>
    <script src="Scripts/moment-timezone-with-data.min.js" type="text/javascript"></script>
    <script src="Scripts/moment-timezone.js" type="text/javascript"></script>
    <script src="Scripts/Script_CAImportMarcaciones.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            setInterval(function () {

                var widget = $('#txtfi').datepicker('getDate');
                if (widget == null) {

                    $('#txtfi').datepicker({
                        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
                            'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
                            'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                        dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
                        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
                        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
                        dateFormat: 'dd/mm/yy',
                        isRTL: false
                    });

                    $('#txtft').datepicker({
                        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
                            'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
                            'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                        dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
                        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
                        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
                        dateFormat: 'dd/mm/yy',
                        isRTL: false
                    });
                }

            });

            Get_Periodo_Asistencia_List();
            Get_Planilla_List();
            Get_Periodo_List(Get_Planilla_Find());
            Get_Localidad_List_New();
            Get_Categoria_List();
            Get_CategoriaAux_List();
            Get_Personal_List(Get_Periodo_Find(), Get_Localidad_Find(), Get_CateAux_Find(), Get_Categoria_Find());

            $('#cboPlanilla').change(function () {
                Get_Periodo_List(Get_Planilla_Find());
                Get_Personal_List(Get_Periodo_Find(), Get_Localidad_Find(), Get_CateAux_Find(), Get_Categoria_Find());
            });
            $('#cboLocalidad').change(function () {
                Get_Periodo_List(Get_Planilla_Find());
                Get_Personal_List(Get_Periodo_Find(), Get_Localidad_Find(), Get_CateAux_Find(), Get_Categoria_Find());
            });

            $('#cboCatAux').change(function () {
                Get_Periodo_List(Get_Planilla_Find());
                Get_Personal_List(Get_Periodo_Find(), Get_Localidad_Find(), Get_CateAux_Find(), Get_Categoria_Find());
            });

            $('#cboCategoria').change(function () {
                Get_Periodo_List(Get_Planilla_Find());
                Get_Personal_List(Get_Periodo_Find(), Get_Localidad_Find(), Get_CateAux_Find(), Get_Categoria_Find());
            });

        });


        $('#btnVer').click(function () {
            Get_Marcaciones_List($('#txtfi').val(), $('#txtft').val(), Get_Personal_Find());
        });
        $('#btnGuardar').click(function () {
            Registrar_Marcaciones_List();
        });
    </script>
    <style type="text/css">

  /*.table {*/
  /*display: block;*/
  /*font-family: sans-serif;
  -webkit-font-smoothing: antialiased;*/
  /*font-size: 100%;*/
  /*overflow: auto;*/
  /*width: 100%;*/

  /*th{         
    color: white;
    font-weight: normal;
    padding: 20px 30px;
    text-align: center;*/
    /*display: block;
    overflow: auto;
     display: table;*/  
  /*}*/
  /*td{
    background-color: rgb(238, 238, 238);
    color: rgb(111, 111, 111);
    padding: 20px 30px;
    display: block;
    overflow: auto;
  }*/
/*}*/

  thead tr th { 
            position: sticky;
            top: 0;
            z-index: 10;
            background-color: #ffffff;
        }
    
        .table-responsive { 
            height:500px;
            overflow:scroll;
        }

 .tableFixHead {
  overflow: scroll;
  height: 100px;
  display: block;
}

.tableFixHead thead th {
  position: sticky;
  top: 0;
}

    </style>

</asp:Content>
