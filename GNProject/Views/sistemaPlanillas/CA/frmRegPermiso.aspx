<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmRegPermiso.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.CA.frmRegPermiso" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleWilder.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/nuevoEstiloPlanilla.css" rel="stylesheet" type="text/css" />
    <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px; /*border-right: solid 1px black;border-left: solid 1px black; border-bottom: solid 1px black;*/ min-height: 500px;overflow: hidden; border-radius: 8px 8px 0px 0px; /*border-top: solid 1px black;*/">
        <fieldset>
        <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
        <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
        <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
        <input type="hidden" id="anioSession" value="<%= Session["anioPlanilla"] %>" />
            <legend class="miTitulo">Filtar</legend>
            <table style="border-collapse:collapse;width:100%;">
                <tr>
                    <td style="width:120px;">Localidad:</td>
                    <td><select class="ddl" id="cboLocalidad1"></select></td>
                    <td style="width:120px;">Área:</td>
                    <td><select class="ddl" id="cboArea1"></select></td>
                    <td>Proyecto:</td>
                    <td><select class="ddl" id="cboProyecto1"></select></td>
                </tr>
                <tr>
                    <td style="width:120px;">Personal:</td>
                    <td colspan="3"><select class="ddl" id="cboPersonal1"></select></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width:120px;">Fecha Inicio:</td>
                    <td><input type="text" class="ddl" id="txtfini" /></td>
                    <td style="width:120px;">Fecha Inicio:</td>
                    <td><input type="text" class="ddl" id="txtffin" /></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </fieldset>
    <fieldset>
        <table width="100%">
            <tr>
                <td style="width:90%;">                    
                    <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE LOS PERMISOS" CssClass="miTitulo" Width="300px"></asp:Label>
                </td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonNew" id="btnNew" value="Nuevo" title="Para Agregar un Nuevo Registro" /></td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonAdd" id="btnAdd" value="Grabar" title="Para Grabar un Nuevo Registro" /></td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonCancel" id="btnCancel" value="Cancelar" title="Para Cancelar la Informacion" /></td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonUpdate" id="btnUpdate" value="Actualizar" title="Para Modificar el Registro" /></td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonDelete" id="btnDelete" value="Eliminar" title="" /></td>
            </tr>
            
        </table>
    </fieldset>
    <div id="TabContainer" style="height:415px;width:100%;">
        <ul>
            <li><a href="#Tab1">Permisos por Días</a></li>
            <li><a href="#Tab2">Reg. Perm. Por Día</a></li>
        </ul>
        <div id="Tab1">
            <fieldset>
            <table class="gridSmall" style="width:100%;">
                <thead>
                    <tr>
                        <th></th>
                        <th></th>
                        <th>PERSONAL ID</th>
                        <th>PERSONAL</th>
                        <th>PERMISO</th>
                        <th>R. POR</th>
                        <th>ESTADO</th>
                        <th>F. INICIO</th>
                        <th>F. FINAL</th>
                        <th>DESCUENTO</th>
                        <th>NRO DOC</th>
                        <th>CANT.DÍAS</th>
                        <th>CONCEPTO</th>
                        <th>VALOR PLANILLA</th>
                        <th>MODIF.</th>
                        <th>ARCHIVO</th>
                    </tr>
                </thead>
                <tbody id="tbodyPermisos">
                
                </tbody>
            </table>


            </fieldset>
        </div>
        <div id="Tab2">
            <table style="width:100%;border-collapse:collapse;">
                <tr  style="visibility:hidden;">
                    <td style="text-align:right;"><label>Área :</label></td>
                    <td><select id="cbolocalidad"></select></td>

                </tr>
                <tr style="visibility:hidden;">
                    <td style="text-align:right;"><label>Cat. Auxiliar :</label></td>
                    <td><select id="cbocataux"></select></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Personal : </label></td>
                    <td colspan="2"><select id="cbopersonal"></select></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Motivo : </label></td>
                    <td><select class="cbo" id="cboTPermiso"></select></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Aplica Descuento : </label></td>
                    <td>SI<input type="radio" id="rdSI" value="01" name="aplidescuento" />&nbsp;&nbsp; NO<input type="radio" id="rdNo" value="02" name="aplidescuento" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;width:130px;"><label class="miLabel">Fecha Inicio : </label></td>
                    <td><input type="text" id="txtFechaIni" class="txt" style="width:100px;" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Fecha Final : </label></td>
                    <td><input type="text" id="txtFechaFin" class="txt" style="width:100px;" /></td>
                    <td id="tdDetalleVac"></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Nro. Documento : </label></td>
                    <td><input type="text" id="txtNroDoc" class="txt" maxlength="100"/></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Archivo : </label></td>
                    <td><input id="filePFecha" type="file" name="archivosF[]"  /> <input type="button" id="btnSubirPF" value="Subir" class="submit" /> <a href="#" id="aFilePF" target="_blank">Ver Archivo</a></td>
                    <td></td>
                </tr>
                <tr>
                    <td  style="text-align:right;vertical-align:top;"><label class="miLabel">Motivo : </label></td>
                    <td colspan="2"><textarea rows="2" cols="30" class="txt" id="txtMotivo"></textarea></td>
                </tr>
            </table>
            <fieldset style="visibility:hidden;">
                <legend><label class="miTituloField">ESTADO DE LA SOLICITUD</label></legend>
                <table class="tableDialog">
                    <tr>
                        <td style="text-align:right;width:130px;"><label class="miLabel">Aprobación Jefe : </label></td>
                        <td><label class="miLabel" id="lblEJefe"></label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Comentarios Jefe : </label></td>
                        <td><textarea rows="2" cols="30" class="txt" id="txtComentJefe" maxlength="300"></textarea></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><label class="miLabel">Aprobación RRHH : </label></td>
                        <td><label class="miLabel" id="lblERRHH"></label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Comentarios RRHH : </label></td>
                        <td><textarea rows="2" cols="30"  class="txt" id="txtComentRRHH" maxlength="300"></textarea></td>
                    </tr>
                </table>
            </fieldset>
        </div>

    </div>
    </fieldset>
    <input id="hPerimisocod" type="hidden" />
    <div id="divError"></div>
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="../jqueriUI/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/ScriptRegPermisos.js" type="text/javascript"></script>
    <script type="text/javascript">
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
    </script>
</asp:Content>

