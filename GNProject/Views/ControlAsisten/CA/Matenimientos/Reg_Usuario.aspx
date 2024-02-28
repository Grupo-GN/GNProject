<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reg_Usuario.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Matenimientos.Reg_Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"   type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
       <link href="../../css/EstiloBarraHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleWilder.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/Registro_Usuario.js"></script>
         <label class="miTitulo">REGISTRO DE USUARIO</label>
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


      <input id="btnGenerar" type="button" value="GENERAR REPORTE" class="submit" style="width: 250px;" />&nbsp;&nbsp;
      <input id="btnprocesar" type="button" value="GRABAR USUARIOS" class="submit" style="width: 150px;" />
        <br />
        <label id="lblMsj" class="miLabelError"></label>

    </fieldset>

   <%--   <div id="HeaderDiv" style="overflow: hidden; width: 100%; border: solid 1px #505050;min-height: 500px;">   
<table id="tablReporte"   cellpadding="0" cellspacing="0" width="100%" class="table"  style="height: 500px;" >--%>
    <div id="HeaderDiv" style="overflow: scroll; width: 100%; border: solid 1px #505050;height: 500px;">
       
            <table id="tablReporte"   cellpadding="0" cellspacing="0" width="100%" height="500px" class="table" style="overflow:scroll;height: 500px;width:100%;" >

    <thead   >
        <tr  >
            <th><input type="checkbox" id="chkAll" /></th>
             <th style="display:none;">Personal_Id</th>
             <th >Nombres y apellidos</th>
             <th >Usuario</th>
            <th   >Clave</th>
            <th   >Nivel Acceso</th>
            <th   >Editar</th> 
        </tr>
    </thead>
    <tbody id="tbodyNovedades"    >

    </tbody>
</table>
</div>

    <div id="dialog-form"
        style="font-size: x-small; font-family: AENOR Fontana ND;">
        <table class="borde">
            <tr>
                <td align="center" class="titulo" colspan="2">
                    <label class="tituloModal">Edicion de Usuarios</label>
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
                    <input id="txtnombre" type="text" readonly="true"
                        class="estiloCajaCodigo" style="width: 185px;"  />
                </td>
            </tr>

              <tr>
                <td class="style23">
                    <label class="miLabel" style="width: 50%;">usuario : </label>
                </td>
                   <td style="text-align: left;">
                    <input id="txtusuario" type="text" readonly="true"
                        class="estiloCajaCodigo" style="width: 185px;"  />
                </td>
            </tr>

            <tr>
                <td class="style23">
                    <label class="miLabel" style="width: 50%;">Clave : </label>
                </td>
                    </td>
                   <td style="text-align: left;">
                    <input id="txtclave" type="text"  
                        class="estiloCajaCodigo" style="width: 185px;"  />
                </td>
            </tr>
   

            <tr>
                <td class="style23">
                    <label class="miLabel" style="width: 50%;">Permiso : </label>
                </td>
                <td style="text-align: left; width: 50%;">
                    <select id="cboestado" class="cbo" style="width: 185px;">
                        <option value='01'>ADMINISTRADOR</option>
                         <option value='02'>RECURS HUMANOS</option>
                         <option value='03'>JEFATURA</option>
                        <option value='04' selected='selected'>EMPLEADO</option>
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
  
            ListaUsuarios(getPlanilla(), getPeriodo(), getLocal(), $("#cboPersonal").val() );
           
        });

        $('#btnCancelar').click(function () {
            closeModalDiv();
            ListaUsuarios(getPlanilla(), getPeriodo(), getLocal(), $("#cboPersonal").val());
        });

        $("#tbodyNovedades").on("click", '.ElLinkEditar', function () {

            var codigo = this.id;
            codigo = codigo.substring(7);

            Get_Usuarios_Find(codigo);
            
            

        });

        $('#chkAll').change(function () {
            $('#tbodyNovedades input[type="checkbox"]').prop('checked', $(this).prop('checked'));
           
        });
     

        $('#btnprocesar').click(function () {
           
            pasarUsuarios();
            ListaUsuarios(getPlanilla(), getPeriodo(), getLocal(), $("#cboPersonal").val());
            

        });


        $('#btnGrabar').click(function () {

            ActualizaUsuarios();
            closeModalDiv();
            ListaUsuarios(getPlanilla(), getPeriodo(), getLocal(), $("#cboPersonal").val());

        });


    </script>

 <style type="text/css">

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
