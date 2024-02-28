<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cVerBoletas.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.caVerBoletas.cVerBoletas" %>

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
<fieldset>
    <table class="tableDialog">
        <tr>
            <td style="width:130px;"><input type="button" class="buttonHer" value="ENVIAR POR EMAIL" id="btnOpenSend" /></td>
            <td style="width:130px;"><input type="button" class="buttonHer" value="VER TODOS" id="btnViewAll" /></td>
            <td><input type="button" class="buttonHer" value="DESCARGAR TODOS" id="btnDownloadAll" /></td>
            <td></td>
        </tr>
    </table>
</fieldset>
<br />

<table class="table">
    <thead>
        <tr>
            <th><input type="checkbox" id="chkAll" /></th>
            <th>Personal</th>
            <th>Ver</th>
            <th>Descargar</th>
        </tr>
    </thead>
    <tbody id="tbodyPersonal"></tbody>
</table>
<seccion id="dialog-SendEmail" title="Enviar Email">
    <table class="tableDialog">
        <tr>
            <td style="width:100px;text-align:right;"><label class="miLabel">Asunto : </label></td>
            <td colspan="2"><input type="text" class="txt" style="width:100%;" id="txtAsusto" /></td>            
        </tr>
        <tr>
            <td style="text-align:right;vertical-align:top;"><label class="miLabel">Comentarios : </label></td>
            <td colspan="2"><textarea rows="2" cols="20" style="width:100%;" id="txtComentarios"></textarea></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td style="text-align:center;" colspan="3"><input type="button" class="submit" value="ENVIAR" id="btnSendEmail" /> <input type="button" class="submit" value="CANCELAR" id="btnCancel" /></td>
            
        </tr>
    </table>
</seccion>

    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Script_VerBoletas.js?v1.0" type="text/javascript"></script>
    
    <script type="text/javascript">
        var Personal_Proc = '<%= Session["Usuario_Id"] %>'; 
        $(document).ready(function () {
            $('#dialog-SendEmail').hide();
            Get_Planilla_List();
            Get_Periodos_Planilla(Get_Planilla_Find());
            Get_Localidad_List();
            Get_Categoria_Auxiliar_List();
            Get_Categoria_Auxiliar2_List(Get_CategoriaAux_Find());
            Get_Categoria_List();

            Get_Personal_All_By_Periodo(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            $('#cboPlanilla').change(function () {
                Get_Periodos_Planilla(Get_Planilla_Find());
                Get_Personal_All_By_Periodo(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            });
            $('#cboPeriodo').change(function () {
                Get_Personal_All_By_Periodo(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            });
            $('#cboLocalidad').change(function () {
                Get_Personal_All_By_Periodo(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            });
            $('#cboCategoriaAux').change(function () {
                Get_Categoria_Auxiliar2_List(Get_CategoriaAux_Find());
                Get_Personal_All_By_Periodo(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            });
            $('#cboCategoriaAux2').change(function () {
                Get_Personal_All_By_Periodo(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            });
            $('#cboCategoria').change(function () {
                Get_Personal_All_By_Periodo(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            });

            $('#txtPersonalFind').keyup(function () {
                Get_Personal_All_By_Periodo(Get_Periodo_Find(), Get_Localidad_Find(), Get_CategoriaAux_Find(), Get_CategoriaAux2_Find(), Get_Categoria_Find(), Get_Personal_Find());
            });

            $('#btnViewAll').click(function () {
                var cantidad = $('.chkProBoleta:checked').length;
                if (cantidad == 0) {
                    alert('No a seleccionado a ninguna personal');
                    return false;
                }
                var codigos = '';
                $('.chkProBoleta:checked').each(function () {
                    codigos += this.id + '|';
                });
                if (codigos != '') {
                    codigos = codigos.substring(0, codigos.length - 1);
                }
                var Periodo_Id = Get_Periodo_Find();
                var a = document.createElement('a');
                a.href = '../../ConsultaPersonal/cpViewBoleta/pViewBoleta.aspx?per=' + Periodo_Id + '&pro=01&perso=' + codigos + '&cant=' + cantidad;

                a.target = '_blank';
                document.body.appendChild(a);
                a.click();
                document.body.removeChild(a);
            });

            $('#btnDownloadAll').click(function () {
                var cantidad = $('.chkProBoleta:checked').length;
                if (cantidad == 0) {
                    alert('No a seleccionado a ninguna personal');
                    return false;
                }
                var codigos = '';
                $('.chkProBoleta:checked').each(function () {
                    codigos += this.id + '|';
                });
                if (codigos != '') {
                    codigos = codigos.substring(0, codigos.length - 1);
                }
                var Periodo_Id = Get_Periodo_Find();
                var a = document.createElement('a');
                a.href = '../../ConsultaPersonal/cpDownloadBoleta/pDownloadBoleta.aspx?per=' + Periodo_Id + '&pro=01&perso=' + codigos + '&cant=' + cantidad;

                a.target = '_blank';
                document.body.appendChild(a);
                a.click();
                document.body.removeChild(a);
            });

            $('#chkAll').click(function () {
                var c = this.checked;
                $(':checkbox').prop('checked', c);
            });


            $('#btnOpenSend').click(function () {
                var c = this.checked;
                var cantidad = $('.chkProBoleta:checked').length;
                if (cantidad == 0) {
                    alert('No a seleccionado a ninguna personal');
                    return false;
                }
                opend_DialogSendMail();
            });

            $('#btnSendEmail').click(function () {
                var asunto = $('#txtAsusto').val();
                var comentarios = $('#txtComentarios').val();

                if (!asunto) {
                    alert('.::Error > Asunto no definido.');
                    return false;
                }

                var codigos = '';
                $('.chkProBoleta:checked').each(function () {
                    codigos += this.id + ';';
                });
                if (codigos != '') {
                    codigos = codigos.substring(0, codigos.length - 1);
                }
                var Periodo_Id = Get_Periodo_Find();
                Get_Informar_PersonalBoleta_Masivo(codigos, Periodo_Id, asunto, comentarios);

            });
            $('#btnCancel').click(function () {
                $('#dialog-SendEmail').dialog('close');
            });
        });
    </script>

</asp:Content>
