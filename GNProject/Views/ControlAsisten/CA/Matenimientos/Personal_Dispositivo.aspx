<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personal_Dispositivo.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.Personal_Dispositivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
     <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"   type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
       <link href="../../css/EstiloBarraHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleWilder.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/Registro_Usuario.js"></script>
         <label class="miTitulo">REGISTRO DE PERSONAL - DISPOSITIVO</label>
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
    <select id="cboPersonal" name="cbopersonal" class="cbo"></select>
        <br />
        <br />


      <input id="btnGenerar" type="button" value="GENERAR REPORTE" class="submit" style="width: 200px;" />&nbsp;&nbsp;
      <input id="btnprocesar" type="button" value="SELECCIONAR PERSONAL" class="submit" style="width: 150px;" />
        <br />
        <label id="lblMsj" class="miLabelError"></label>

    </fieldset>

   <%--   <div id="HeaderDiv" style="overflow: hidden; width: 100%; border: solid 1px #505050;min-height: 500px;">   
<table id="tablReporte"   cellpadding="0" cellspacing="0" width="100%" class="table"  style="height: 500px;" >--%>
    <div id="HeaderDiv" style="overflow: scroll; width: 100%; border: solid 1px #505050;height: 500px;">
       
<%--         <table id="tablReporte"   cellpadding="0" cellspacing="0" width="100%" height="500px" class="table" style="overflow:scroll;height: 500px;width:100%;" >--%>

            <table id="tablReporte"  width="100%" height="500px" class="table" style="overflow:scroll; height:20px;" >

    <thead   >
        <tr  >
            <th style="display:none;">id</th>
             <th >Nombres y apellidos</th>
             <th >conexion</th>
            <th   >dispositivo</th>
            <th   >Tipo Conexion</th>
            <th   >Editar</th> 
             <th   >eliminar</th> 

        </tr>
    </thead>
    <tbody id="tbodyNovedades"    >

    </tbody>
</table>
</div>

    <div id="dialog-form"
        style="font-size:x-small; font-family: AENOR Fontana ND;">
        <table class="borde">
            <tr>
                <td align="center" class="titulo" colspan="2">
                    <label id="lblident" ></label>
                </td>
            </tr>

            <tr>
                <td class="style23">&nbsp
                </td>
            </tr>
            <tr>
                <td class="style23">
                    <label class="miLabel" style="width: 50%;">Codigo : </label>
                </td>
                <td style="text-align: left; width: 50%;">
                    <input id="txtCodigo" type="text" readonly="true"
                        class="estiloCajaCodigo" value="???" style="width: 185px;"/>
                </td>
            </tr>
            <tr>
                <td class="style23">
                    <label class="miLabel" style="width: 50%;">Empleado : </label>
                </td>
                   <td style="text-align: left;">
                   <label id="id_personal" class="miLabel"></label> <input id="txtnombre" type="text" readonly="true"
                        class="estiloCajaCodigo" style="width: 185px;"  />
                </td>
            </tr>

              <tr>
                <td class="style23">
                    <label class="miLabel" style="width: 50%;">Conexion : </label>
                </td>
                   <td style="text-align: left;">
                    <input id="txtconexion" type="text"
                        class="estiloCajaCodigo" style="width: 185px;"  />
                </td>
            </tr>

            <tr>
                <td class="style23">
                    <label class="miLabel" style="width: 50%;">dispositivo : </label>
                </td>
                    </td>
                   <td style="text-align: left;">
                   <select id="cbodispositivo" class="cbo" style="width: 185px;">
                     </select>
                </td>
            </tr>
   

            <tr>
                <td class="style23">
                    <label class="miLabel" style="width: 50%;">tipo conexion : </label>
                </td>
                <td style="text-align: left; width: 50%;">
                    <select id="cboTipoconexion" class="cbo" style="width: 185px;">
                     </select>
                </td>
            </tr>

            <td colspan="2">

                <table style="width: 100%">
                    <tr>
                        <td style="height: 3px;" colspan="2">
                            <label id="lblError" class="miLabelError"></label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right" style="width: 100%;">
                            <input id="btnGrabar" type="button" value="Grabar" class="submit" />
                            <input id="btnCancelar" type="button" value="Salir" class="submit" />
                        </td>
                    </tr>
                </table>

            </td>

        </table>

        <label id="lblCodigSeleccionao"></label>

    </div>

       <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
 
    <script src="Scripts/Registro_Usuario.js" type="text/javascript"></script>
    <script src="Scripts/Empleado_Dispositivo.js" type="text/javascript"></script>
   
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
              
                Get_Personal_By_Filtros($('#cboPeriodo').val(), $('#cboLocal').val(), '', '', '');
            });
          
            $('#cboLocal').change(function () {
                Get_Personal_By_Filtros($('#cboPeriodo').val(), $('#cboLocal').val(), '', '', '');
            });

            Get_Personal_By_Filtros($('#cboPeriodo').val(), '', '', '', '');
            $('#dialog-form').css('display', 'none');

            ListaEmpledoDispositivo('');

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

     

        $('#btnGenerar').click(function () {
  
          
            ListaEmpledoDispositivo($("#cboPersonal").val());
           
        });

        $('#btnCancelar').click(function () {
            closeModalDiv();
            ListaEmpledoDispositivo('');
        });

        $("#tbodyNovedades").on("click", '.ElLinkEditar', function () {

            var codigo = this.id;
            codigo = codigo.substring(7);

            getdispositivos(codigo);
          
            

        });

        $("#tbodyNovedades").on("click", '.ElLinkEliminar', function () {

            var codigo = this.id;
            codigo = codigo.substring(7);

            EliminarDispositivos(codigo);
            ListaEmpledoDispositivo('');


        });
  
     

        $('#btnprocesar').click(function () {
           
            //pasarUsuarios();
            //ListaUsuarios(getPlanilla(), getPeriodo(), getLocal(), $("#cboPersonal").val());
            var id = $("#cboPersonal").val();
            var nombre = $('select[name="cbopersonal"] option:selected').text();
            if (id=='') {
                alert('Seleccionar un personal');
                return false;
            }
            $("#lblident").html('Insertando');
            $("#id_personal").html(id);
            $("#txtnombre").val(nombre);
            $("#txtCodigo").val('???');
            $("#txtconexion").val('');
           $("#cbodispositivo").val('');
             $("#cboTipoconexion").val('');
            pasaModal();
        });

        ListaDispositivo();
        Listatipoconexion();
        $('#btnGrabar').click(function () {
            var dispositivo = $("#cbodispositivo").val();
            var conexion = $("#cboTipoconexion").val();
            if (dispositivo=='' || conexion=='') {
                alert('Seleccione Conexion o distpistivo')
            }
            var valida = $("#lblident").html()
            var id, Personal_id, Conexion, Tipodisp, Tipoconexion
            if (valida == 'Insertando') {
                id = '', Personal_id = '', Conexion = '', Tipodisp = '', Tipoconexion = '';
                id = $('#txtCodigo').val();
                Personal_id = $('#id_personal').html();
                Conexion = $('#txtconexion').val();
                Tipodisp = $('#cbodispositivo').val();
                Tipoconexion = $('#cboTipoconexion').val();
                InsertDispositivo(Personal_id, Conexion, Tipodisp, Tipoconexion);

            } else {
                id = '', Personal_id = '', Conexion = '', Tipodisp = '', Tipoconexion = '';
                id = $('#txtCodigo').val();
                Personal_id = $('#id_personal').html();
                Conexion = $('#txtconexion').val();
                Tipodisp = $('#cbodispositivo').val();
                Tipoconexion = $('#cboTipoconexion').val();
                Actualizadispositivo(id, Personal_id, Conexion, Tipodisp, Tipoconexion);

            }
            ListaEmpledoDispositivo('');
            closeModalDiv();
        });

        function pasaModal() {

            $("#dialog-form").dialog({
                height: 300, width: 360, modal: true, autoOpen: true,
                appendTo: "form", title: "Mant. Usuario Dispositivo",
                show: { effect: "fade", duration: 800 },
                hide: { effect: "fold", duration: 800 }
            });
        }

    </script>

      <style type="text/css">

  thead tr th { 
            position: sticky;
            /*top: 0;
            z-index: 10;*/
            background-color: #ffffff;
        }
    
        /*.table-responsive { 
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
}*/

    </style>

</asp:Content>
