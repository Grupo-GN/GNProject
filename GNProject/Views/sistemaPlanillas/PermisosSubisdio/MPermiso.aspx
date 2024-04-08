<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MPermiso.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.PermisosSubisdio.MPermiso" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleWilder.css" rel="stylesheet" type="text/css" />
        
    <fieldset style="width:100%; background-color: White; margin: 0px 0px 0px 0px; border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black;min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">
    <fieldset>
        <table width="100%">
            <tr>
                <td style="width:90%;">
                    <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE PERMISOS" CssClass="miTitulo" Width="300px"></asp:Label>
                </td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonNew" id="btnNew" value="Nuevo" title="Para Agregar un Nuevo Registro" /></td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonAdd" id="btnAdd" value="Grabar" title="Para Grabar un Nuevo Registro" /></td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonCancel" id="btnCancel" value="Cancelar" title="Para Cancelar la Informacion" /></td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonUpdate" id="btnUpdate" value="Actualizar" title="Para Modificar el Registro" /></td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonDelete" id="btnDelete" value="Eliminar" title="" /></td>
            </tr>
            
        </table>
    </fieldset>
        <label id="lblError" class="lblError"></label>
        <div id="TabContainer" style="height:415px;width:100%;">
            <ul>
                <li><a href="#Tab1">Lista</a></li>
                <li><a href="#Tab2">Permiso</a></li>           
            </ul>
            <div id="Tab1">
            <fieldset>
                <legend>BUSQUEDA</legend>
                <input type="text" class="miTextBox" id="txtBuscar" />
            </fieldset>
                <table class="gridSmall" style="width:100%;">
                    <thead>
                        <tr>
                            <th></th>
                            <th></th>
                            <th>ID</th>
                            <th>DESCRIPCIÓN</th>
                            <th>CONCEPTO</th>
                            <th>TIEMPO ACUMULADO</th>
                            <th>EJECUTAR ACCION</th>
                        </tr>
                    </thead>
                    <tbody id="tbodydatos" class="tbodyPer">
            
            
                    </tbody>
                </table>
                <table class="table">
                     <tfoot>
                    <tr>
                    <td class="tfoottd"  colspan="3">

                        <label style="font-family: 'Droid Sans', 'Trebuchet MS', Helvetica, Arial, sans-serif; font-weight: bold; font-size: 1.1em;" >TOTAL REGISTROS: </label> &nbsp
                        <input id="txtnRegistros" type="text" value="0" class="TextPage" readonly="true" /> &nbsp &nbsp
                        <label style="font-family: 'Droid Sans', 'Trebuchet MS', Helvetica, Arial, sans-serif; font-weight: bold; font-size: 1.1em;" >PAGE: </label> &nbsp
                        <input id="txtPaginaActual" type="text" value="1" class="TextPage" readonly="true" />
                         <input id="btnPrimero" type="button" value="|<" class="submitPager" />
                         <input id="btnAnterior" type="button" value="<<" class="submitPager" />
                         <input id="btnSiguiente" type="button" value=">>" class="submitPager" />
                         <input id="btnUltimo" type="button" value=">|" class="submitPager"/>
                    </td>
                    </tr>
                    </tfoot>
                </table>
            </div>
            <div id="Tab2">
                <input type="hidden" id="hcodigo" />
                <table style="width:100%;border-collapse:collapse;">
                    <tr>
                        <td style="width:100px;">Descripcion: </td>
                        <td><input type="text" id="tDescripcion" class="ddl" style="min-width:250px;" /></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Concepto: </td>
                        <td><select id="cboConcepto" class="ddl"></select></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Tiempo Acumulado: </td>
                        <td><input type="text" id="tMeses" class="ddl" /></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Ejecutar Accion: </td>
                        <td><input type="number" id="tDias" class="ddl" min="0" max="360" /></td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>

            </div>
        </div>
    </fieldset>
    
    <div id="divError"></div>
    
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="../jqueriUI/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="../Mantenimientos/Scripts/ScriptMantPermiso.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(initilize);
                //@001 I
        function fc_FillComboArray(idCombo, Datos, textInicial) {
            var lengthD = Datos.length - 1;
            $("#" + idCombo).html("");
            if (textInicial != "") {
                $('<option value="">' + textInicial + '</option>').appendTo("#" + idCombo);
            }
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo("#" + idCombo);
            }
        }
        //@001 F
    </script>
</asp:Content>

