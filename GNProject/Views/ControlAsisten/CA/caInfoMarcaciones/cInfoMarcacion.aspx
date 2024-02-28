<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cInfoMarcacion.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.caInfoMarcaciones.cInfoMarcacion" %>
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
        <tr>
            <td style="text-align:right;"><label class="miLabel">Area : </label></td>
            <td><select class="cbo" id="cboCategoriaAux"></select></td>
            <td style="text-align:right;"><label class="miLabel">Sección : </label></td>
            <td><select class="cbo" id="cboCategoriaAux2"></select></td>
            <td style="text-align:right;"><label class="miLabel">Categoria : </label></td>
            <td><select class="cbo" id="cboCategoria"></select></td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Personal : </label></td>
            <td colspan="3"><input type="text" class="txt" id="txtPersonalFind" style="width:350px;" /></td>          
            <td></td>
            <td></td>
        </tr>
        
    </table>
</fieldset>
<input type="button" class="buttonHer" value="Informar" id="btnInformar" />

<table class="table">
    <thead>
        <tr>
            <th><input type="checkbox" id="chkAll" /></th>
            <th>Personal</th>

        </tr>
    </thead>
    <tbody id="tbodyPersonal">
    
    </tbody>
</table>

    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Script_InfoPersonal.js" type="text/javascript"></script>
    <script type="text/javascript">
        var Personal_Proc = '<%= Session["Usuario_Id"] %>';
        $(document).ready(function () {
            Get_Planilla_List();
            Get_Periodos_Planilla(Get_Planilla_Find());
            Get_Localidad_List();
            Get_Categoria_Auxiliar_List();
            Get_Categoria_Auxiliar2_List(Get_CategoriaAux_Find());
            Get_Categoria_List();

            Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            $('#cboPlanilla').change(function () {
                Get_Periodos_Planilla(Get_Planilla_Find());
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            });
            $('#cboPeriodo').change(function () {
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            });
            $('#cboLocalidad').change(function () {
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            });
            $('#cboCategoriaAux').change(function () {
                Get_Categoria_Auxiliar2_List(Get_CategoriaAux_Find());
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            });
            $('#cboCategoriaAux2').change(function () {
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            });
            $('#cboCategoria').change(function () {
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            });

            $('#txtPersonalFind').keyup(function () {
                Get_Personal_By_Filtros(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            });


            $('#chkAll').click(function () {
                var c = this.checked;
                $(':checkbox').prop('checked', c);
            });

            $('#btnInformar').click(function () {
                if (confirm('¿Está seguro de continuar?')) {                
                    var cantidad = $('.chkSendInfo:checked').length;
                    if (cantidad == 0) {
                        alert('No a seleccionado a ningun personal');
                        return false;
                    }
                    var Personal_Codigo = [];
                    $('.chkSendInfo:checked').each(function () {
                        Personal_Codigo.push(this.id);
                    });
                    Get_SendMarcaciones_Informacion(Personal_Codigo);
                }
            });


        });
    </script>

</asp:Content>
