<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sEditReporteIncidente.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pEditReporteIncidente.sEditReporteIncidente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../css/cssReporte.css" rel="stylesheet" type="text/css" />

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
            <td colspan="7"><label style="font-size:16px" id="lblUsuarioReg" class="miLabel"></label></td>
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
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><select id="cboLocalidad" class="cbo"></select></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Área:</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><select id="cboCategoriaAuxiliar" class="cbo"></select></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Sección:</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><select id="cboCategoriaAuxiliar2" class="cbo"></select></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Fecha y Hora del Incidente:</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><input type="text" class="txt" id="txtFechaInc" />&nbsp; <select class="cbo" style="width:70px;" id="cboHoraInc"></select>&nbsp; <select class="cbo" style="width:50px;" id="cboMinInc"></select></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Fecha y Hora del Reporte:</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><label id="lblFechaHoraRep"></label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Tipo de Incidente:</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><select id="cboTipoInc" class="cbo" style="width:100%;"></select></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                Tipo de Personal :</td>
            <td colspan="7" 
                style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                <select id="cboAfectadoInc" class="cbo" style="width:100%;"></select></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Intensidad del Daño:</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><select id="cboIntensidad" class="cbo" style="width:100%;"></select></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Actividad Propia del Tabajo:</td>
            <td colspan="7" id="tdErrorAct"
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                SI<input type="radio" value="01" name="rdActPT" id="rdAPSI"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NO<input type="radio" value="02" name="rdActPT" id="rdAPNO"/></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Actividad Rutinaria:</td>
            <td colspan="7"  id="tdErrorActRut"
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                SI<input type="radio" name="rdActRU" value="01" id="rdARSI"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NO<input type="radio" id="rdARNO" value="02" name="rdActRU" /></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;">Lugar del Incidente (Lugar exacto de ocurrencia)</td>
            <td colspan="7" 
                style="font-family: arial, Helvetica, sans-serif; font-size: 12px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                <input type="text" id="txtLugarInc" class="txt" style="width:100%;" /></td>
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
                style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><select class="cbo" id="cboTipo"></select></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                Origen :&nbsp;&nbsp;</td>
            <td colspan="7" 
                style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><select class="cbo" id="cboOrigen"></select></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td style="font-family: arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">
                Severidad:</td>
            <td colspan="7" 
                style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"><select id="cboSeveridad" class="cbo" style="width:100%;"></select></td>
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
            <td colspan="7"  id="tdErrorOsig"
                style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000">SI <input id="rbOsiSI"  name="rbosiger" type="radio" value="01" /> NO <input id="rbOsiNO"  name="rbosiger" type="radio" value="02" /></td>
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
            <td colspan="5" rowspan="3" style="vertical-align: top;"><textarea rows="2" id="txtLesiones" style="width:100%;height:100%;" class="txt"></textarea></td>
            <td colspan="5" rowspan="3"><textarea rows="2" id="txtDañosMat" style="width:100%;height:100%;" class="txt"></textarea></td>

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
            <td colspan="5" rowspan="4"  style="vertical-align: top;"><select class="cbo" style="width:90%;" id="cboCausasBasicas"></select><input type="button" class="submit" value="+" style="width:30px;" id="btnAddCB" /><br />
            <div style="width:100%;overflow-x:hidden;overflow-y:auto;">
            <table class="table">
                            <thead>
                                <tr>
                                    <th>CAUSA</th>
                                    <th>DESCRIPCIÓN</th>
                                    <th></th>
                                </tr>
                            </thead>
                             <tbody id="tbodyCB" class="TableRe">

                            </tbody>
              </table>
            </div></td>
            <td colspan="5" rowspan="4" style="vertical-align: top;"> <select class="cbo" style="width:90%;" id="cboCausasInmediatas"></select><input type="button" class="submit" value="+" style="width:30px;" id="btnAddCI" /><br />
            <div style="width:100%;overflow-x:hidden;overflow-y:auto;">
            <table class="table">
                            <thead>
                                <tr>
                                    <th>CAUSA</th>
                                    <th>DESCRIPCIÓN</th>
                                    <th></th>
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
                Acción Inmediata:<input type="button" class="submit" style="float:right;" value="Add Acción" id="btnAddAccion" /></td>
        </tr>
    
        <tr>
            <td>&nbsp;</td>
            <td colspan="10">
            
        <div id="divAcciones" style="width:100%;min-height:200px;overflow-x:hidden;overflow-y:auto;">
            <table class="table">
                <thead>
                    <tr>
                        <th>ACCIÓN</th>
                        <th>RESPONSABLE</th>
                        <th>INICIO</th>
                        <th>FIN</th>
                        <th>ESTADO</th>
                        <th></th>
                        <th></th>
                        <th></th>
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
   <div  style="width:100%;overflow-x:hidden;overflow-y:auto;">
            <table class="table">
                <thead>
                    <tr>
                        <th>Archivo</th>
                        <th>Ver</th>     
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
    
    </tbody>
</table>
<input type="button" id="btnArchivos" class="submit" value="Subir Archivos" style="width:130px;" /><br /><br />

<input id="btnGrabarReporte" type="button" class="buttonHer" value="ACTUALIZAR" />&nbsp;&nbsp;<input id="btnActualizarReporte" type="button" class="buttonHer" value="APROBAR" />&nbsp;&nbsp;<input type="button" class="buttonHer" value="CANCELAR" id="btnCancelarReporte" />&nbsp;&nbsp;


<datalist id="personalResponsable">
  
  <option value="" data-xyz = "1" >
</datalist>

<div id="dialog-Accion" title="Acción Correctiva - Preventiva">
<fieldset>
    <legend><label>BUSQUEDA</label></legend>
    <label class="miLabel">Apellidos y Nombres : </label> <input id="txtResponsableFind" type="text" class="txt" style="width:300px;" />
</fieldset>
<fieldset>
    <legend><label>Acción</label></legend>
    <table class="tableDialog">
        <tr>
            <td colspan="2"><label class="labelError" id="lblErrorAcc"></label></td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Responsable : </label></td>
            <td><select class="cbo" id="cboResponsable"></select></td>
        </tr>
        <tr>
            <td style="width:100px;vertical-align:top;text-align:right;"><label class="miLabel">Descripcion : </label></td>
            <td><textarea rows="3" style="width:100%;" class="txt" id="txtAccionDescrip"></textarea></td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Fecha Inicio : </label></td>
            <td><input type="text" class="txt" id="txtFechaIni" /></td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Fecha Fin : </label></td>
            <td><input type="text" class="txt" id="txtFechaFin" /></td>
        </tr>
        <tr>
            <td colspan="2"><input type="button" class="submit" value="Grabar" id="btnGrabarAccion" />&nbsp; <input type="button" class="submit" value="Cancelar" id="btnCancelarAccion" /> &nbsp; <input type="button" class="submit" value="Grabar y Validar" style="width:150px;" id="btnGrabValidar" /></td>           
        </tr>
    </table>
</fieldset>

</div>
<br /><br /><br /><br /><br />
    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Script_EditReporteIncidente.js" type="text/javascript"></script>   
    <script src="Script_DatosReporteFind.js" type="text/javascript"></script>
    <script src="Script_DatosCofigReporte.js" type="text/javascript"></script>
    <script src="Script_EditarReporte_ADM.js" type="text/javascript"></script>

<script type="text/javascript">

    var Acciones = [];
    var Area_Id = '';
    var Incidente_Cod = getParameterByName('inccod');
    var TIPOPROCESOA = '';
    var Accion_Cod = '';
    var CantAcciones = 0;
    var CausasBa = 0;
    var CausasIn = 0;
    $(document).ready(function () {
        $('#dialog-Accion').hide();
        Get_Tipo_List();
        Get_Origen_List();
        Get_Localidad_Combo();
        Get_Categoria_Auxiliar_Combo();
        Get_Categoria_Auxiliar2_Combo();

        Get_TipoIncidente_List();
        Get_Intensidad_List();
        Get_CausasTipo_Report('01');
        Get_CausasTipo_Report('02');

        Get_Intensidad_List();
        Get_Severidad_List();

        CargarHorasMin();
        Get_AfectadoInc_List();

        Get_Reg_CausaReporte_Detalle_List(Incidente_Cod, '01');
        Get_Reg_CausaReporte_Detalle_List(Incidente_Cod, '02');

        Get_Find_ReporteIncidente(Incidente_Cod);
        Get_AccionCorrectiva_List(Incidente_Cod);
        Get_Files_Incidencia_List(Incidente_Cod);


        $('#txtFechaIni').datepicker({
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
            dateFormat: 'dd/mm/yy',
            isRTL: false,
            onClose: function (selectedDate) {
                $("#txtFechaFin").datepicker("option", "minDate", selectedDate);
            }
        });
        $('#txtFechaFin').datepicker({
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
            dateFormat: 'dd/mm/yy',
            isRTL: false,
            minDate: -0
        });


        $('#btnAddAccion').click(function () {
            clearModal();
            Get_DataList_Responsable($('#txtResponsableFind').val(), '', Area_Id);
            $('#btnGrabValidar').hide();
            open_Modal();
            $('#txtFechaIni').datepicker('option', 'minDate', -0);
            TIPOPROCESOA = '01';
        });

        $('#txtResponsableFind').keyup(function () {
            Get_DataList_Responsable($('#txtResponsableFind').val(), '', Area_Id);
        });

        $('#btnGrabarAccion').click(function () {
            $('#lblErrorAcc').html('&nbsp;');

            if (!TIPOPROCESOA) {
                $('#lblErrorAcc').html('.::Error, Proceso no identificado.');
                return false;
            }

            var Responsable = $('#cboResponsable').val();
            var AccDescrip = $('#txtAccionDescrip').val();
            var FechaIni = $('#txtFechaIni').val();
            var FechaFin = $('#txtFechaFin').val();

            if (!Responsable) {
                $('#lblErrorAcc').html('.::Error, Responsable no definido.');
                $('#cboResponsable').focus()
                return false;
            }

            if (!AccDescrip) {
                $('#lblErrorAcc').html('.::Error, Acción no definida.');
                $('#txtAccionDescrip').focus()
                return false;
            }

            if (!FechaIni) {
                $('#lblErrorAcc').html('.::Error, Fecha Inicio no definida.');
                $('#txtFechaIni').focus()
                return false;
            }
            if (!FechaFin) {
                $('#lblErrorAcc').html('.::Error, Fecha Fin no definida.');
                $('#txtFechaFin').focus()
                return false;
            }

            if (TIPOPROCESOA == '02') {
                if (Accion_Cod) {
                    Get_Update_AccionCorrectiva(Incidente_Cod, Accion_Cod, AccDescrip, '01', Responsable, FechaIni, FechaFin);
                }
            } else if (TIPOPROCESOA == '01') {
                Add_Accion_Correctiva(Incidente_Cod, AccDescrip, '01', Responsable, FechaIni, FechaFin);
            }



        });

        $('#btnCancelarAccion').click(function () {
            TIPOPROCESOA = '';
            Accion_Cod = '';
            $('#dialog-Accion').dialog('close');
        });

        $('#tbodyAcciones').on('click', '.buttonEdit', function () {
            $('#txtFechaIni').datepicker('option', 'minDate', null);
            Get_DataList_Responsable($('#txtResponsableFind').val(), '', Area_Id);
            Get_Find_AccionCorrectiva(Incidente_Cod, this.id);
            open_Modal();

        });

        $('#tbodyAcciones').on('click', '.buttonValida', function () {
            if (confirm('¿Esta seguro de Aporbar la acción?')) {
                Get_Aprobrar_Accion(Incidente_Cod, this.id);
            }
        });


        $('#tbodyAcciones').on('click', '.buttonDelete', function () {
            if (confirm('¿Esta seguro de Desaprobrar la acción?')) {
                Get_Desaprobrar_Accion(Incidente_Cod, this.id);
            }
        });


        $('#btnActualizarReporte').click(function () {
            if (confirm('¿Esta seguro de continuar?')) {
                Get_AprobarReporte(Incidente_Cod);
            }
        });


        $('#btnCancelarReporte').click(function () {
            if (confirm('¿ Esta seguro de Salir?')) {
                var url2 = "'../pListReportes/ListReportes.aspx'";
                setTimeout("location.href=" + url2, 5);
            }
        });


        $('#btnGrabarReporte').click(function () {
            if (confirm('¿ Esta seguro de continuar?')) {
                Actualizar_Reporte_de_Incidencia()
            }
        });


        $('#btnAddCB').click(function () {
            var causaID = $('#cboCausasBasicas').val();
            if (!causaID) {
                alert('.::Error > Causa Básica no definida.');
                return false;
            }
            Get_Add_CausaReporte_Detalle(Incidente_Cod, causaID, '01');
        });

        $('#btnAddCI').click(function () {
            var causaID = $('#cboCausasInmediatas').val();
            if (!causaID) {
                alert('.::Error > Causa Básica no definida.');
                return false;
            }
            Get_Add_CausaReporte_Detalle(Incidente_Cod, causaID, '02');
        });

        $('#tbodyCB').on('click', '.deleteAcc', function () {
            Get_Delete_CausaReporte_Detalle(Incidente_Cod, this.id, '01');
        });
        $('#tbodyCI').on('click', '.deleteAcc', function () {
            Get_Delete_CausaReporte_Detalle(Incidente_Cod, this.id, '02');
        });

        $('#btnArchivos').click(function () {
            if (window.showModalDialog) {
                window.showModalDialog('../pEditFileIncidente/sEditFileIncidente.aspx?i=' + Incidente_Cod, 'Archivos Reporte', "dialogWidth:700px;dialogHeight:250px");
            } else {
                window.open('../pEditFileIncidente/sEditFileIncidente.aspx?i=' + Incidente_Cod, 'Archivos Reporte',
            'height=500,width=550,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no ,modal=yes');
            }
        });
    });

</script>
</asp:Content>
