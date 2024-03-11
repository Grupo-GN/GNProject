<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewReporte.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.ViewGerencia.ViewReporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<table style="width:100%;border-collapse:collapse;" id="tblOtro">
    <tbody>
        <tr>
            <td colspan="9" rowspan="2" 
                style="text-align: center; vertical-align: middle; font-family: arial, Helvetica, sans-serif; font-size: 20px;">REPORTE DE INCIDENTE</td>
            <td>Codigo:</td>
            <td>REG/MC/PS-02C</td>
        </tr>
    
        <tr>
            <td>Versión:</td>
            <td>01</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td><label style="color:Red;" id="lblReporte_Id"></label></td>
        </tr>
    
        <tr>
            <td colspan="11" 
                
                style="background-color: #366092; font-family: arial, Helvetica, sans-serif; font-size: 14px; color: #FFFFFF; font-weight: bold;">
                DATOS DE LA PERSONA QUE REALIZA EL REPORTE</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold;">Apellidos y Nombres:</td>
            <td colspan="7"><label style="font-size:16px" id="lblUsuarioReg" ></label></td>
            <td colspan="2"><label style="font-size:16px;" id="lblLocalidadUs"></label></td>
        </tr>
    
        <tr>
            <td colspan="11" 
                
                style="background-color: #366092; font-family: arial, Helvetica, sans-serif; font-size: 16px; color: #FFFFFF; font-weight: bold;">INCIDENTE</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Localidad:</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><label  id="lblLocalidad"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Área:</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><label  id="lblArea"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Sección:</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><label  id="lblSeccion"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Fecha y Hora del Incidente:</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><label  id="lblFechaHoraInci"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Fecha y Hora del Reporte:</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><label  id="lblFechaHoraRep"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Tipo de Incidente:</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><label id="lblTipoI"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                Tipo de Personal :</td>
            <td colspan="7" 
                style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                <label id="lblAfectado"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Intensidad del Daño:</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><label  id="lblIntensidad"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Actividad Propia del Tabajo:</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                <label  id="lblActividadProp"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Actividad Rutinaria:</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                <label  id="lblActividadRut"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Lugar del Incidente (Lugar exacto de ocurrencia)</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                <label id="txtLugarInc"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold">
                Descripcion del Incidente:</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td colspan="10" rowspan="4" style="vertical-align:top;"><textarea id="txtDescripcionInc" rows="4" class="txt" style="width:100%;" maxlength="500"></textarea></td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td colspan="11" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold; color: #FFFFFF; background-color: #0D97FF">
                ANALISIS DEL INCIDENTE (Para ser llenado por el área de seguridad y medio 
                ambiente)</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                Incidente de Tipo:</td>
            <td colspan="7" 
                style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><label  id="lblTipo"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                Origen :&nbsp;&nbsp;</td>
            <td colspan="7" 
                style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><label  id="lblOrigen"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                Severidad:</td>
            <td colspan="7"  id="tdSeveridad"
                style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><label  id="lblSeveridad"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                Informar a Gerencia :</td>
            <td colspan="7" 
                style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><label id="lblIformarGe"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                Informar a Osigermin :</td>
            <td colspan="7" 
                style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><label id="lblInformarOs"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    

    
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td colspan="5" 
                
                style="border: 1px solid #000000; font-family: arial, Helvetica, sans-serif; font-size: 14px; font-weight: normal; color: #FFFFFF; background-color: #00B853; text-align: center;">
                LESIONES PERSONALES</td>
            <td colspan="5" 
                
                style="border: 1px solid #000000; font-family: arial, Helvetica, sans-serif; font-size: 14px; font-weight: normal; color: #FFFFFF; background-color: #00B853; text-align: center;">
                DAÑOS MATERIALES</td>

        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td colspan="5" rowspan="4" style="vertical-align: top;"><textarea rows="5" id="txtLesiones" style="width:100%;height:100%;" class="txt"></textarea></td>
            <td colspan="5" rowspan="4" style="vertical-align: top;"><textarea id="txtPosCausas" rows="5" style="width:100%;" class="txt" maxlength="500"></textarea></td>

        </tr>
    
        <tr>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="5" 
                
                style="border: 1px solid #000000; font-family: arial, Helvetica, sans-serif; font-size: 14px; font-weight: normal; color: #FFFFFF; background-color: #00B853; text-align: center;">
                CAUSAS BÁSICAS</td>
            <td colspan="5" 
                
                style="border: 1px solid #000000; font-family: arial, Helvetica, sans-serif; font-size: 14px; font-weight: normal; color: #FFFFFF; background-color: #00B853; text-align: center;">
                CAUSAS INMEDIATAS</td>

        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td colspan="5" rowspan="4"  style="vertical-align: top;"><div style="width:100%;min-height:200px;overflow-x:hidden;overflow-y:auto;">
            <table class="table" id="tbl15">
                            <thead>
                                <tr>
                                    <th colspan="3">CAUSA</th>
                                    <th colspan="4">DESCRIPCIÓN</th>
                                    
                                </tr>
                            </thead>
                             <tbody id="tbodyCB" class="TableRe">

                            </tbody>
              </table>
            </div></td>
            <td colspan="5" rowspan="4"  style="vertical-align: top;"><div style="width:100%;min-height:200px;overflow-x:hidden;overflow-y:auto;">
            <table class="table" id="tbl16">
                            <thead>
                                <tr>
                                    <th colspan="3">CAUSA</th>
                                    <th colspan="4">DESCRIPCIÓN</th>
                                    
                                </tr>
                            </thead>
                             <tbody id="tbodyCI" class="TableRe">

                            </tbody>
              </table>
            </div></td>

        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>

        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td colspan="10" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 14px; font-weight: normal; color: #FFFFFF; background-color: #00B853; text-align: left;">
                Acción Inmediata:</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td colspan="10" rowspan="4" style="vertical-align: top;"><textarea id="txtAccionInmediata" rows="3" style="width:100%;" class="txt" maxlength="500" ></textarea></td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td colspan="10" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 14px; font-weight: normal; color: #FFFFFF; background-color: #00B853; text-align: left;">
                Acción Inmediata:</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td colspan="10">
            
<div id="divAcciones" style="width:100%;min-height:200px;overflow-x:hidden;overflow-y:auto;">
            <table style="width: 100%;border-collapse:collapse;border:1px solid #2C6B8D;" id="tbl1">
                <thead>
                    <tr>
                        <th colspan="4">ACCIÓN</th>
                        <th colspan="3">RESPONSABLE</th>
                        <th>INICO</th>
                        <th>FIN</th>
                        <th>ESTADO</th>

                    </tr>
                </thead>
                 <tbody id="tbodyAcciones" class="TableRe">

                </tbody>
            </table>

            </div>
            </td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td colspan="10">
        <div  style="width:100%;min-height:200px;overflow-x:hidden;overflow-y:auto;">
            <table id="tbl2" style="width:100%;">
                <thead>
                    <tr>
                        <th colspan="4">ARCHIVO</th>
                        <th>VER</th>
                     </tr>
                </thead>
                 <tbody id="tbodyFiles" class="TableRe">

                </tbody>
            </table>

            </div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="10">
        <div  style="width:100%;min-height:200px;overflow-x:hidden;overflow-y:auto;">
            <table id="tblaccion" style="width:100%;">
                <thead>
                    <tr>
                        <th colspan="5">EVIDENCIA DE CIERRE</th>
                        <th colspan="4">VER</th>
                     </tr>
                </thead>
                 <tbody id="tbodyaccion" class="TableRe">

                </tbody>
            </table>

            </div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
    </tbody>
</table>
<input id="btnDOCX" type="button"  style="background-color:#2C5295;color:White;margin:1px auto 1px auto;font:12px/1.5 'Droid Sans', 'Trebuchet MS', Helvetica, Arial, sans-serif;text-transform:uppercase;font-weight:bold;width:120px;height:36px;border:none;text-align:center;cursor:pointer;" value="EXPORTAR" />



    <script src="../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Script_ViewReporte.js" type="text/javascript"></script>
    <script src="../jsExportExcel/ScriptExportarExcel.js" type="text/javascript"></script>

<script type="text/javascript">


    var Incidente_Cod = getParameterByName('inccod');


    $(document).ready(function () {
        Change_Estilos();

        Get_Find_ReporteIncidente(Incidente_Cod);
        Get_AccionCorrectiva_List(Incidente_Cod);
        Get_Files_Incidencia_List(Incidente_Cod);


        $('#tbodyAcciones').on('click', '.buttonEdit', function () {
            $('#txtFechaIni').datepicker('option', 'minDate', null);
            Get_DataList_Responsable($('#txtResponsableFind').val(), '', Area_Id);
            Get_Find_AccionCorrectiva(Incidente_Cod, this.id);
            open_Modal();

        });

        $('#btnDOCX').click(function () {
            /* var g = document.getElementById('serTableRe').innerHTML;

            Ret_DelTextArea(g);*/
            tableToExcel('tblOtro', 'expor');
        });



    });


    function Ret_DelTextArea(html) {
        var re = /(<textarea ([^>]+)>)/gi;
        html = html.replace(re, '');
        html = html.replace('</textarea>', '');
        return html;
    }

</script>

</asp:Content>
