<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cAsignarHVariable.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.caAsignarHVariable.cAsignarHVariable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />

<fieldset>
    <legend class="miTituloField">FILTROS</legend>
    <table class="tableDialog">
        <tr>
            <td style="width:150px;text-align:right;"><label class="miLabel">Planilla : </label></td>
            <td><select class="cbo" id="cboPlanilla"></select></td>
            <td style="text-align:right;"><label class="miLabel">Periodo : </label></td>
            <td><select class="cbo" id="cboPeriodo"></select></td>
            <td style="text-align:right;"><label class="miLabel">Localidad : </label></td>
            <td><select class="cbo" id="cboLocal">
                </select></td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Area : </label></td>
            <td><select class="cbo" id="cboCategoriaAux"></select></td>
            <td style="text-align:right;"><label class="miLabel">Sección : </label></td>
            <td><select class="cbo" id="cboCategoriaAux2"></select></td>
            <td style="text-align:right;"><label class="miLabel">Categoria : </label></td>
            <td><select class="cbo" id="cboCategoria"></select></td>
        </tr>

    </table>
</fieldset>
<fieldset>
    <input type="button" class="buttonHer" value="ASIGNAR" id="btnAsignar" /> <input type="button" class="buttonHer" value="QUITAR" id="btnQuitar" />
</fieldset>
<table class="table">
    <thead>
        <tr>
            <th><input type="checkbox" id="chkAll"/></th>
            <th>PERIODO</th>
            <th>AREA</th>
            <th>PERSONAL</th>
            <th>HORARIO VARIABLE</th>
        </tr>
    </thead>
    <tbody id="tbodyHVariable"></tbody>
</table>


<script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
  <%--  <script src="Script_AsignarHVariable.js" type="text/javascript"></script>--%>
 
    <script type="text/javascript">
        var Personal_Proc = '<%= Session["Usuario_Id"] %>';
        var PersonalSelec = [];
        $(document).ready(function () {
            Get_Planilla_List();
            Get_Periodo_Activo_By_CA(Get_Planilla_Find());
            Get_Localidad_List_New();//nuevo

            //Get_Localidad_List();
           
            Get_Categoria_Auxiliar_List();
            Get_Categoria_Auxiliar2_List(Get_CategoriaAux_Find());
            Get_Categoria_List();

            Get_Personal_HorarioVariable(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());


            $('#cboPlanilla').change(function () {
                Get_Periodo_Activo_By_CA(Get_Planilla_Find());
                Get_Personal_HorarioVariable(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());
            });
            $('#cboPeriodo').change(function () {
                Get_Personal_HorarioVariable(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());

            });
            //nuevo 30.09.2020
            $('#cboLocal').change(function () {
                Get_Personal_HorarioVariable(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());
            });


            $('#cboLocalidad').change(function () {
                //Get_Personal_HorarioVariable(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());
            });
           
            $('#cboCategoriaAux').change(function () {
                Get_Categoria_Auxiliar2_List(Get_CategoriaAux_Find());
                Get_Personal_HorarioVariable(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());
            });
            $('#cboCategoriaAux2').change(function () {
                Get_Personal_HorarioVariable(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());
            });
            $('#cboCategoria').change(function () {
                Get_Personal_HorarioVariable(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find());
            });

            $('#chkAll').click(function () {
                var c = this.checked;
                $(':checkbox').prop('checked', c);
            });
            $('#btnAsignar').click(function () {
                var cantidad = $('.chkHVariable:checked').length;
                if (cantidad == 0) {
                    alert('No a seleccionado a ningun personal');
                    return false;
                }
                var PersonalVariable = [];
                var codigos = '';
                $('.chkHVariable:checked').each(function () {
                    PersonalVariable.push({ Personal_Id: this.id, Variable:'01'});
                });
  
                var Periodo_Id = Get_Periodo_Find();
                Get_AsignarHorarioVariable(PersonalVariable, Periodo_Id);
            });
            $('#btnQuitar').click(function () {
                var cantidad = $('.chkHVariable:checked').length;
                if (cantidad == 0) {
                    alert('No a seleccionado a ningun personal');
                    return false;
                }
                var PersonalVariable = [];
                var codigos = '';
                $('.chkHVariable:checked').each(function () {
                    PersonalVariable.push({ Personal_Id: this.id, Variable: '02' });
                });

                var Periodo_Id = Get_Periodo_Find();
                Get_AsignarHorarioVariable(PersonalVariable, Periodo_Id);
            });
        });
    </script>
   <script src="Script_AsignarHVariable.js"></script>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            background: white repeat-x left bottom /*url(../img/input_text.gif)*/;
            min-height: 18px;
            border: #B1B1B1 1px solid;
/**color: #000000;*/text-transform: uppercase;
            font-size: 14px;
            text-align: left;
            font-weight: normal;
            line-height: 10px;
            color: #444;
            -webkit-font-smoothing: antialiased; /* Fix for webkit rendering */;
            -moz-font-smoothing: antialiased;/* Mozilla */;
            -webkit-text-size-adjust: 100%;
            -moz-text-size-adjust: 100%;
            font-size: 12px;
            font-weight: normal;
            line-height: 21px;
            font-style: normal;
            font-variant: normal;
            font-family: HelveticaNeue, "Helvetica Neue", Helvetica, Arial, sans-serif;
            width: 26px;
        }
    </style>
    <select class="auto-style1" id="cboLocalidad" disabled="disabled" name="D1" size="1"></select>

</asp:Content>
