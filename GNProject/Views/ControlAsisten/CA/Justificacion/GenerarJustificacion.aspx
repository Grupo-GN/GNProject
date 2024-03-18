<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerarJustificacion.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Justificacion.GenerarJustificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <fieldset>
        <legend>
            <label class="miTitulo" style="font-size: 16px;">Datos Personales</label></legend>
        <table id="tblDato1" class="tableDialog">
            <tr>
                <td style="width: 100px; text-align: right;">
                    <label class="miLabel">Personal : </label>
                </td>
                <td>
                    <label id="lblNomPersonal" class="miLabel"></label>
                </td>
                <td style="width: 100px; text-align: right;">
                    <label class="miLabel">Localidad : </label>
                </td>
                <td>
                    <label id="lblNomLocalidad" class="miLabel"></label>
                </td>
                <td style="width: 70px; text-align: right;">
                    <label class="miLabel">Cargo : </label>
                </td>
                <td>
                    <label id="lblNomCargo" class="miLabel"></label>
                </td>
                <td style="width: 70px; text-align: right;">
                    <label class="miLabel">Periodo : </label>
                </td>
                <td>
                    <label id="lblPeriodo" class="miLabel"></label>
                </td>
            </tr>
        </table>
        <table id="tblDato2" class="tableDialog">
        <tr>
            <td style="width: 100px; text-align: right;"><label class="miLabel">Planilla : </label></td>
            <td><select class="cbo" id="cboPlanilla"></select></td>
            <td style="width: 100px; text-align: right;"><label class="miLabel">Localidad : </label></td>
            <td><select class="cbo" id="cboLocalidad"></select></td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right;"><label class="miLabel">Categoria : </label></td>
            <td><select class="cbo" id="cboCategoria"></select></td>
            <td style="width: 100px; text-align: right;"><label class="miLabel">Personal : </label></td>
            <td><select class="cbo" id="cboPersonal"></select></td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right;"><label class="miLabel">Jefe : </label></td>
            <td><label class="miLabel" id="lblJefe"></label></td>
            <td style="width: 100px; text-align: right;"><label class="miLabel">Periodo : </label></td>
            <td><label class="miLabel" id="lblPeriodo2"></label></td>
        </tr>
    </table>
    </fieldset>

<section id="tabContainer" style="font-size: small;">
    <ul>
        <li><a href="#Tab1">MARCACIONES MALAS</a></li>
        <li><a href="#Tab2">MARCACIONES BUENAS</a></li>
    </ul>
    <section id="Tab1">
    <input type="button" value="Mis Permisos" class="submit" style="width:150px;" id="btnPersmisos"/> 
         <input type="button" value="Compensaciones" class="submit" style="width:150px;" id="btnCompensacion"/>
       
        <table class="table">
            <thead>
                <tr>
                    <th></th>
                    <th>SOLICITUD</th>
                    <th>ESTADO</th>
                    <th>REALIZADO POR</th>
                    <th>TIPO</th>
                    <th>DIA</th>
                    <th>FECHA</th>
                    <th style="cursor:help;" title="Hora Inicio del Horario">HIH</th>
                    <th style="cursor:help;" title="Hora Final del Horario">HFH</th>
                    <th style="cursor:help;" title="Hora de Ingreso Marcada">HIM</th>
                    <th style="cursor:help;" title="Hora de Salida Marcada">HSM</th>
                    <th>TOT HORA</th>
                    <th style="cursor:help;" title="Minutos de Tardanza">MinTard</th>
                    <th style="cursor:help;" title="Fata">Falta</th>
                    <th>OBSERVACIÓN</th>
                </tr>
            </thead>
            <tbody id="tbodyMMPersonal"></tbody>
        </table>
    </section>
    <section id="Tab2">
        <table class="table">
                    <thead>
                        <tr>   
                            <th></th>                         
                            <th>SOLICITUD</th>
                            <th>ESTADO</th>
                            <th>REALIZADO POR</th>
                            <th>DIA</th>
                            <th>FECHA</th>
                            <th style="cursor:help;" title="Hora Inicio del Horario">HIH</th>
                            <th style="cursor:help;" title="Hora Final del Horario">HFH</th>
                            <th style="cursor:help;" title="Hora de Ingreso Marcada">HIM</th>
                            <th style="cursor:help;" title="Hora de Salida Marcada">HSM</th>
                            <th>TOT HORA</th>
                            <th style="cursor:help;" title="Minutos de Tardanza">MinTard</th>
                            <th style="cursor:help;" title="Fata">Falta</th>
                            <th>OBSERVACIÓN</th>
                        </tr>
                    </thead>
                    <tbody id="tbodyMCorr"></tbody>
                </table>
    </section>
</section>

   <%--incio de  permisos--%>

    <section id="dialog-Justificacion" title="JUSTIFICACION">

      <table class="tableDialog">
                    <tr>
                        <td style="width:120px;text-align:right;"><label class="miLabel">Fecha : </label></td>
                        <td><label class="miLabel" id="lblFechaJusti"></label></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><label class="miLabel">Tipo : </label></td>
                        <td><select class="cbo" id="cboTipoJust">
                            <option value="01" selected>INGRESO</option>
                            <option value="02">SALIDA</option>
                            <option value="00">INGRESO Y SALIDA</option>
                            </select></td>
                        <td></td>
                    </tr>
                    <tr id="tdInfIng2" >
                        <td style="text-align:right;"><label class="miLabel">Hora de Ingreso : </label></td>
                        <td><select class="cbo" id="cboHoraIng"><option>01</option></select> : <select class="cbo" id="cboMinIng"><option>00</option></select> </td>
                        <td><label id="lblInfoIngreso"  style="color:#026F2B;" ></label></td>
                    </tr>
                    <tr id="tdInfSal2">
                        <td style="text-align:right;"><label class="miLabel">Hora de Salida : </label></td>
                        <td><select class="cbo" id="cboHoraSal"><option>01</option></select> : <select class="cbo" id="cboMinSal"><option>00</option></select> </td>
                        <td><label id="lblInfoSalida"  style="color:#026F2B;" ></label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Motivo : </label></td>
                        <td colspan="2"><textarea rows="2" cols="30" class="txt" id="txtMotivos"></textarea></td>
                        
                    </tr>
                    <tr>
                        <td style="text-align:right;"><label class="miLabel">Archivo : </label></td>
                        <td colspan="2"> <input id="fileToUpload" type="file" name="archivos[]"  />&nbsp;&nbsp;
                            <input type="button" onclick="uploadFile()" value="SUBIR" class="submit" />&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" target="_blank" id="aVerAchivo">Ver Archivo</a></td>

                    </tr>
                    <tr>
                        <td colspan="3"></td>
                    </tr>
                    <tr>
                        <td style="text-align:center;" colspan="3"><input type="button" value="GRABAR" class="submit" id="btnGrabarJust" />&nbsp; <input type="button" value="CANCELAR" class="submit" id="btnCancelJustif" /></td>            
                    </tr>
                </table>

</section>


    <section id="dialog-Permisos" title="PERMISOS">
          <label class="miLabel" id="lblNombre"></label> 
    <section id="TabContainerPerm">
        <ul>
            <li><a href="#PTab1">DIAS</a></li>
            <li><a href="#PTab2">DETALLE - DIAS</a></li>
            <li><a href="#PTab3">HORAS</a></li>
            <li><a href="#PTab4">DETALLE - HORAS</a></li>
        </ul>
        <section id="PTab1">
            <input type="button" class="buttonHer" value="NUEVO" id="btnNewPermiso" />
            <table class="table">
                <thead>
                    <tr>
                        <th></th>
                        <th></th>
                        <th>PERMISO</th>
                        <th>R. POR</th>
                        <th>ESTADO</th>
                        <th>F. INICIO</th>
                        <th>F. FINAL</th>
                        <th>DESCUENTO</th>
                        <th>NRO DOC</th>
                        <th>A. JEFE</th>
                        <th>A. RRHH</th>
                        <th>MODIF.</th>
                    </tr>
                </thead>
                <tbody id="tbodyPermisos">
                
                </tbody>
            </table>
            
        </section>
        <section id="PTab2">
            <table class="tableDialog">
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
                <tr>
                    <td colspan="3" style="text-align:center;"><input type="button" class="submit" value="GRABAR" id="btnGrabarPermiso" />&nbsp; <input type="button" class="submit" value="CANCELAR" id="btnCancelPer" /></td>
                </tr>
            </table>
            <fieldset>
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
        </section>
        <section id="PTab3">
            <input type="button" class="buttonHer" value="NUEVO" id="btnNewPermisoHora" />
            <table class="table">
                <thead>
                    <tr>
                        <th></th>
                        <th></th>
                        <th>PERMISO</th>
                        <th>R. POR</th>
                        <th>ESTADO</th>
                        <th>FECHA</th>
                        <th>H. INICIO</th>
                        <th>H. FINAL</th>
                        <th>DESCUENTO</th>
                        <th>A. JEFE</th>
                        <th>A. RRHH</th>
                        <th>MODIF.</th>
                    </tr>
                </thead>
                <tbody id="tbodyPermisoHora">
                
                </tbody>
            </table>
        </section>
        <section id="PTab4">
            <table class="tableDialog">
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Motivo : </label></td>
                    <td><select class="cbo" id="cboPermisoH"></select></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Aplica Descuento : </label></td>
                    <td>SI<input type="radio" id="rdSiH" value="01" name="aplidescuentoH" />&nbsp;&nbsp; NO<input type="radio" id="rsNoH" value="02" name="aplidescuentoH" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Fecha : </label></td>
                    <td><input type="text" id="txtFechaPH" class="txt" style="width:100px;" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Aplicar a : </label></td>
                    <td><select id="cboAplicarA_PH" class="cbo">
                        <option value="1">Ingreso</option>
                        <option value="2">Salida</option>
                        <option value="3">Intermedio</option>
                        </select></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;width:130px;"><label class="miLabel">Hora Inicio : </label></td>
                    <td><select class="cbo" id="cboHIP"></select> : <select class="cbo" id="cboMIP"></select></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Hora Final : </label></td>
                    <td><select class="cbo" id="cboHFP"></select> : <select class="cbo" id="cboMFP"></select></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Archivo : </label></td>
                    <td><input id="filePHora" type="file" name="archivosF[]"  /> <input type="button" id="btnSubirPH" value="Subir" class="submit" /> <a href="#" id="aFilePH" target="_blank">Ver Archivo</a></td>
                    <td></td>
                </tr>
                <tr>
                    <td  style="text-align:right;vertical-align:top;"><label class="miLabel">Motivo : </label></td>
                    <td><textarea rows="2" cols="30" class="txt" id="txtMotivoPHora"></textarea></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align:center;"><input type="button" class="submit" value="GRABAR" id="btnGrabarPH" />&nbsp; <input type="button" class="submit" value="CANCELAR" id="btnCancelarPH" /></td>
                </tr>
            </table>
            <fieldset>
                <legend><label class="miTituloField">ESTADO DE LA SOLICITUD</label></legend>
                <table class="tableDialog">
                    <tr>
                        <td style="text-align:right;width:130px;"><label class="miLabel">Aprobación Jefe : </label></td>
                        <td><label class="miLabel" id="lblJefePH"></label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Comentarios Jefe : </label></td>
                        <td><textarea rows="2" cols="30" class="txt" id="txtComentJefeH" maxlength="300"></textarea></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><label class="miLabel">Aprobación RRHH : </label></td>
                        <td><label class="miLabel" id="lblRRHHo"></label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Comentarios RRHH : </label></td>
                        <td><textarea rows="2" cols="30"  class="txt" id="txtComentRRHHHo" maxlength="300"></textarea></td>
                    </tr>
                </table>
            </fieldset>
        </section>
    </section>
</section>

    <%--fin de permisos--%>

    <%--inicio de compensaciones--%>

     


<section id="dialog-Compensaciones" title="COMPENSACIONES">
        <section id="dialog-detallecomp" style="font-size:x-small; font-family:AENOR Fontana ND;" title="Detalle de Compensacion">
 <fieldset >
    <label class="miLabel">ID: </label>  <label class="miLabel" id="lblidcomp" ></label>
 </fieldset>
 
 <br />    
<table class="table" id="tblDetComp" >
<thead>
    <tr>
        <th>Fecha Marcacion</th>
        <th>Cant. Horas</th>
        <th>Asis. ID</th>
       
    </tr>
</thead>
 <tbody id="tbodydetcomp">

 </tbody>
 </table>
 </section>
          <label class="miLabel" id="lblNombrecomp"></label> 
    <section id="TabContainerComp">
        <ul>
            <li><a href="#PTab00">LISTA COMPENSACIONES</a></li>
            <li><a href="#PTab01">TARDANZAS</a></li>
            <li><a href="#PTab02">DETALLE - TARDANZA</a></li>
            <li><a href="#PTab03">FALTAS</a></li>
            <li><a href="#PTab04">DETALLE - FALTA</a></li>
        </ul>

         <section id="PTab00">
            <input type="button" style="width:180px;" class="buttonHer" value="Compensa Tard." id="btNListCompT" />
             <input type="button" style="width:180px;" class="buttonHer" value="Compensa Faltas" id="btNListCompF" />
            <table class="table">
                <thead>
                    <tr>
                      
                        <th></th>
                        <th></th>
                         <th></th>
                        <th>ID</th>
                        <th>FECHA</th>
                        <th>M.COMPENSADO</th>
                        <th>HORA.COMP</th>
                        <th>ESTADO</th>
                        <th>MOTIVO</th>
                         <th>DETALLE</th>
                   
                    </tr>
                </thead>
                <tbody id="tbodyCompGeneral">
                
                </tbody>
            </table>
            
        </section>
        <section id="PTab01">
            <input type="button" class="buttonHer" value="Seleccionar" id="btnNewComp" />
              <table id="TblNota00" class="tableDialog">
            
            <tr>
                    <td style="width: 30%; text-align: left;">
                    <label class="miLabel">Cantidad de Horas Extras : </label>
                            <label id="lblcanHE" class="miLabel"></label>
                              <label class="miLabel">==> </label>
                          <label id="lblcanHES1" class="miLabel"></label>
                          
                </td>
                <td style="width: 30%; text-align: left;">
                    <label class="miLabel">Cantidad de Horas Seleccionado : </label>
                            <label id="lblcanHEac" class="miLabel"></label>
                       
                          
                </td>
                 <td style="width: 30%; text-align: left;">
                    <label class="miLabel">Cantidad de Horas Total : </label>
                            <label id="lblcanHET" class="miLabel"></label>
                       <label class="miLabel">==> </label>
                          <label id="lblcanHET1" class="miLabel"></label>
                          
                </td>
               
            </tr>
        </table>
            <table id="tbltarde" class="table">
                <thead>
                    <tr>
                        <th><input type="checkbox" id="chkAll" /></th>
                        <th style="display:none;">Marcacion_Id</th>
                        <th style="display:none;">Personal_Id</th>
                        <th>Nombres</th>
                        <th>Fecha</th>
                        <th># Tardanza</th>
                        
                    </tr>
                </thead>
                <tbody id="tbodyCompT">
                
                </tbody>
            </table>
               <fieldset>
        <legend>
            <label class="miTitulo" style="font-size: 16px;">Notas:</label></legend>
        <table id="TblNota01" class="tableDialog">
            <tr>
                <td style="width: 100%; text-align: left;">
                    <label class="miLabel" style="color:red;">** Las tardanzas en la tabla se expresan en minutos  </label>
                </td>
                 
            </tr>
            <tr>
                    <td style="width: 100%; text-align: left;">
                    <label class="miLabel">Cantidad de minutos : </label>
                            <label id="lblcantminutosT" class="miLabel"></label>
                          <label class="miLabel">   Cantidad de horas convertidas : </label>
                          <label id="lblcanthorasT" class="miLabel"></label>
                </td>
               
            </tr>
        </table>
       
    </fieldset>
        </section>
        <section id="PTab02">
              <table class="tableDialog">
                    <tr>
                        <td style="width:120px;text-align:right;"><label class="miLabel">Fecha : </label></td>
                        <td><label class="miLabel" id="lblFechaCompT"></label></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><label class="miLabel">Tipo : </label></td>
                        <td><select class="auto-style1" id="cboModoCompT">
                            <option value="01" selected>Tardanza</option>
                             
                            </select></td>
                        <td></td>
                    </tr>
                    <tr id="tdInfIng3" >
                        <td style="text-align:right;"><label class="miLabel"> Horas Tarde: </label></td>
                        <td><input type="text" id="txthoratarde" class="txt" style="width:200px;" readonly="readonly" />
                            <label class="miLabel">==> </label>
                          <label id="txthoratarde1" class="miLabel"></label>

                        </td>
                          
                        <td><label id="lblInfohoratar"  style="color:#026F2B;" ></label></td>
                    </tr>
                    <tr id="tdInfSal4">
                        <td style="text-align:right;"><label class="miLabel">Hora Compensada : </label></td>
                        <td><input  id="txthoracompensadaT" class="txt" style="width:200px;" readonly="readonly"  />
                            <label class="miLabel">==> </label>
                          <label id="txthoratarde11" class="miLabel"></label>
                        </td>
                        <td><label id="lblInfocompensadaT"  style="color:#026F2B;" ></label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Motivo : </label></td>
                        <td colspan="2"><textarea rows="2" cols="30" class="txt" id="txtMotcompT"></textarea></td>
                        
                    </tr>

                    <tr>
                        <td colspan="3"></td>
                    </tr>
                    <tr>
                        <td style="text-align:center;" colspan="3"><input type="button" value="GRABAR" class="submit" id="btnGrabarCompT" />&nbsp; <input type="button" value="CANCELAR" class="submit" id="btnCancelCompT" /></td>            
                    </tr>
                </table>
            <fieldset>
                <legend><label class="miTituloField">ESTADO DE LA SOLICITUD</label></legend>
                <table class="tableDialog">
                    <tr>
                        <td style="text-align:right;width:130px;"><label class="miLabel">Aprobación Jefe : </label></td>
                        <td><label class="miLabel" id="lblEJefeCompT"></label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Comentarios Jefe : </label></td>
                        <td><textarea rows="2" cols="30" class="txt" id="txtComentJefecompT" maxlength="300"></textarea></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><label class="miLabel">Aprobación RRHH : </label></td>
                        <td><label class="miLabel" id="lblERRHHCompT"></label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Comentarios RRHH : </label></td>
                        <td><textarea rows="2" cols="30"  class="txt" id="txtComentRRHHCompT" maxlength="300"></textarea></td>
                    </tr>
                </table>
            </fieldset>

          

        </section>
        <section id="PTab03">
            <input type="button" class="buttonHer" value="seleccionar" id="btnNewCompF" />
                 <table id="TblNota000" class="tableDialog">
            
            <tr>
                    <td style="width: 30%; text-align: left;">
                    <label class="miLabel">Cantidad de min. Extras : </label>
                            <label id="lblcanHE2" class="miLabel"></label>
                        <label class="miLabel">==> </label>
                          <label id="lblcanHES2" class="miLabel"></label>
                          
                </td>
                <td style="width: 30%; text-align: left;">
                    <label class="miLabel">Cantidad de min. Seleccionado : </label>
                            <label id="lblcanHEac2" class="miLabel"></label>
                          
                </td>
                 <td style="width: 30%; text-align: left;">
                    <label class="miLabel">Cantidad de min. Total : </label>
                    <label id="lblcanHET2" class="miLabel"></label>
                       
                </td>
               
            </tr>
        </table>
            <table id="tblfalta" class="table">
                <thead>
                    <tr>
                      <th><input type="checkbox" id="chkAll1" /></th>
                        <th style="display:none;">Marcacion_Id</th>
                        <th style="display:none;">Personal_Id</th>
                        <th>Nombres</th>
                        <th>Fecha</th>
                        <th># Tardanza</th>
                    </tr>
                </thead>
                <tbody id="tbodyCompF">
                
                </tbody>
            </table>
               <fieldset>
        <legend>
            <label class="miTitulo" style="font-size: 16px;">Notas:</label></legend>
        <table id="TblNota02" class="tableDialog">
            <tr>
                <td style="width: 100%; text-align: left;">
                    <label class="miLabel" style="color:red;">** Las faltas en la tabla se expresan en dias  </label>
                </td>
                 
            </tr>
            <tr>
                    <td style="width: 100%; text-align: left;">
                    <label class="miLabel">Cantidad de Dias : </label>
                         <label id="lblcantdiasF" class="miLabel"></label>
                        <label class="miLabel">     Cantidad de horas convertidas : </label>
                          <label id="lblcanthorasF" class="miLabel"></label>
                </td>
               
            </tr>
        </table>
       
    </fieldset>
        </section>

        <section id="PTab04">
              <table class="tableDialog">
                    <tr>
                        <td style="width:120px;text-align:right;"><label class="miLabel">Fecha : </label></td>
                        <td><label class="miLabel" id="lblFechaCompF"></label></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><label class="miLabel">Tipo : </label></td>
                        <td><select class="cbo" id="cboModoCompF">
                            <option value="02" selected>Falta</option>
                             
                            </select></td>
                        <td></td>
                    </tr>
                    <tr id="tdInfIng03" >
                        <td style="text-align:right;"><label class="miLabel"> Cant. falta: </label></td>
                        <td><input type="text" id="txtFalta" class="txt" style="width:100px;" readonly="readonly" /></td>
                        <td><label id="lblInfoFalta"  style="color:#026F2B;" ></label></td>
                    </tr>
                    <tr id="tdInfSal04">
                        <td style="text-align:right;"><label class="miLabel">Hora Compensada : </label></td>
                        <td><input   id="txthoracompF" class="txt" style="width:100px;"  readonly="readonly" />
                          <label class="miLabel">==> </label>
                                <label id="txthoracompF1"  style="color:#026F2B;" >
                        </td>
                        <td><label id="lblInfocompF"  style="color:#026F2B;" ></label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Motivo : </label></td>
                        <td colspan="2"><textarea rows="2" cols="30" class="txt" id="txtMotcompF"></textarea></td>
                        
                    </tr>

                    <tr>
                        <td colspan="3"></td>
                    </tr>
                    <tr>
                        <td style="text-align:center;" colspan="3"><input type="button" value="GRABAR" class="submit" id="btnGrabarCompF" />&nbsp; <input type="button" value="CANCELAR" class="submit" id="btnCancelCompF" /></td>            
                    </tr>
                </table>
            <fieldset>
                <legend><label class="miTituloField">ESTADO DE LA SOLICITUD</label></legend>
                <table class="tableDialog">
                    <tr>
                        <td style="text-align:right;width:130px;"><label class="miLabel">Aprobación Jefe : </label></td>
                        <td><label class="miLabel" id="lblJefePF"></label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Comentarios Jefe : </label></td>
                        <td><textarea rows="2" cols="30" class="txt" id="txtComentJefeF" maxlength="300"></textarea></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><label class="miLabel">Aprobación RRHH : </label></td>
                        <td><label class="miLabel" id="lblRRHHoF"></label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Comentarios RRHH : </label></td>
                        <td><textarea rows="2" cols="30"  class="txt" id="txtComentRRHHHoF" maxlength="300"></textarea></td>
                    </tr>
                </table>
            </fieldset>
            
        </section>
    </section>
</section>



    <%--fin de compensaciones--%>




 <section title="Detalle de Vacaciones" id="dialog-vaciones">
<label class="labelError" id="lblError">&nbsp;&nbsp;</label>
<br />
    <table class="table">
        <thead>
            <tr>
                <th>Fecha Inicio</th>
                <th>Fecha Final</th>
                <th>Dias</th>
                <th>Dias Pagados</th>
                <th>Dias Saldo</th>
                <th>F. Ini. Permiso</th>
                <th>F. Fin. Permiso</th>
                <th>Dias</th>
                <th>Saldo</th>
                <th>Observación</th>
            </tr>
        </thead>
        <tbody id="tbodyVacaciones"></tbody>
    </table>
</section>

<div id="tvesModal" class="modalContainer">
		<div class="modal-content">
			<span class="close">×</span>
			<h2>Modal</h2>
			<p>Se Inserto los datos con éxito!</p>
		</div>
	</div>

    
 



    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>

    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_GenerarJustificacion.js" type="text/javascript"></script>
    <script src="Scripts/Script_GenerarPermisos.js" type="text/javascript"></script>
    <script src="Scripts/Script_CrearMenu.js" type="text/javascript"></script>
    <script src="Scripts/Compensaciones.js" type="text/javascript"></script>
    <script src="Scripts/ListArray.js" type="text/javascript"></script>

  
    <link href="Scripts/sweetalert2.min.css" rel="stylesheet" rel="stylesheet"/>
    <script src="Scripts/sweetalert2.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        var Personal_IdG = '<%= Session["Usuario_Id"] %>';
        var Nombre_IdG = '';
        var Periodo_IdG = '';
        var FechaIniPer = '';
        var FechaFinPer = '';
        var FechaProc = '';
        var Mostivos = [];
        var PermisoD_Proc = 0;
        var PermisoH_Proc = 0;
        var FileArr = [];
        var Asistencia_Proc = '';
        var Jefe_Proc = '<%= Session["Usuario_Id"] %>';
        var Periodo_Des = '';
        $(document).ready(function () {

            //if (!Personal_IdG) {
            //    setTimeout('window.location="Acceso.aspx"', 50);
            //}
            var usuarioSes = Session.get('UsuarioSistema');
            var Rol = usuarioSes.NivelAcc;
            $('#dialog-detallecomp').css('display', 'none');
            if (Rol == "01" || Rol == "03") {
                $('#tblDato1').hide(); //muestro mediante id
                $('#tblDato2').show(); //muestro mediante clase
              
                Get_Periodo_Activo_AsistenciaN();
                Get_Planilla_ListN();  
                Get_Localidad_ListN(); 
                Get_Categoria_ListN();  
                Get_DatosPersonalN(Jefe_Proc);
                Get_Personal_ListN(Get_Planilla_FindN(), Periodo_Des, Get_Localidad_FindN(), Get_Categoria_FindN(), Jefe_Proc);
                $('#cboPlanilla').change(function () {
                    Get_Personal_ListN(Get_Planilla_FindN(), Periodo_Des, Get_Localidad_FindN(), Get_Categoria_FindN(), Jefe_Proc);
                    //Get_Marcaciones_Malas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                    //Get_Marcaciones_Correctas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                    //Get_Permisos_Fecha_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                    //Get_Permisos_Horas_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                });
                $('#cboLocalidad').change(function () {
                    Get_Personal_ListN(Get_Planilla_FindN(), Periodo_Des, Get_Localidad_FindN(), Get_Categoria_FindN(), Jefe_Proc);
                    //Get_Marcaciones_Malas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                    //Get_Marcaciones_Correctas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                    //Get_Permisos_Fecha_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                    //Get_Permisos_Horas_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                });

                $('#cboCategoria').change(function () {
                    Get_Personal_ListN(Get_Planilla_FindN(), Periodo_Des, Get_Localidad_FindN(), Get_Categoria_FindN(), Jefe_Proc);
                    //Get_Marcaciones_Correctas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                    //Get_Marcaciones_Malas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                    //Get_Permisos_Fecha_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                    //Get_Permisos_Horas_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                });
                //Personal_IdG = $('#cboPersonal').val();
                $('#cboPersonal').change(function () {
                    Personal_IdG = $('#cboPersonal').val();
                    Get_Marcaciones_Malas_Personal(Personal_IdG, FechaIniPer, FechaFinPer);
                    Get_Marcaciones_Correctas_Personal(Personal_IdG, FechaIniPer, FechaFinPer);
                    //Get_Marcaciones_Malas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                    //Get_Marcaciones_Correctas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                    //Get_Permisos_Fecha_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                    //Get_Permisos_Horas_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                });
               
            }
            if (Rol=="04") {
                $('#tblDato2').hide(); //muestro mediante id
                $('#tblDato1').show(); //muestro mediante clase
                   Personal_IdG = '<%= Session["Usuario_Id"] %>';
            }

            $('#dialog-Justificacion').hide();
            $('#dialog-vaciones').hide();
            $('#dialog-Permisos').hide();
            $('#tabContainer').tabs();

            $('#dialog-Compensaciones').hide();
            $('#TabContainerComp').tabs();

            CargarHorasMin();
            Get_Periodo_Activo_Asistencia();
            Get_DatosPersonal(Personal_IdG, Periodo_IdG);
            Get_Marcaciones_Malas_Personal(Personal_IdG, FechaIniPer, FechaFinPer);
            Get_Marcaciones_Correctas_Personal(Personal_IdG, FechaIniPer, FechaFinPer);
            $('#TabContainerPerm').tabs();
            document.getElementById('rdSI').disabled = true;
            document.getElementById('rdNo').disabled = true;
            document.getElementById('rdSiH').disabled = true;
            document.getElementById('rsNoH').disabled = true;
            CrearFechas();
            $('#tbodyMMPersonal').on('click', '.buttonEditMarc', function () {
                Get_Justificacion_Find(this.id);
                Get_Files_Jusitificacion(this.id);
                Asistencia_Proc = this.id;
            });

            $('#tbodyMCorr').on('click', '.buttonEditMarc', function () {
                Get_Justificacion_Find(this.id);
                Asistencia_Proc = this.id;
            });

            $('#btnGrabarJust').click(function () {
                var tipo = $('#cboTipoJust').val();
                var motivo = $('#txtMotivos').val();

                if (!motivo) {
                    alert('.::Error > Motivo no definido.');
                    $('#txtMotivos').focus();
                    return false;
                }

                if (motivo.length < 10) {
                    alert('.::Error > Sea mas especifico.');
                    $('#txtMotivos').focus();
                    return false;
                }

                if (tipo == '01' || tipo == '00') {
                    var hi = $('#cboHoraIng').val();
                    var mi = $('#cboMinIng').val();
                    if (!hi) {
                        alert('.::Error > Nueva hora de ingreso no definida.');
                        $('#cboHoraIng').focus();
                        return false;
                    }

                    if (!mi) {
                        alert('.::Error > Defina el minuto de ingreso.');
                        $('#cboMinIng').focus();
                        return false;
                    }
                    var newhoraIng = hi + ':' + mi;
                    var tipo_ingreso = '01';
                    Get_AM_Justificacion(FechaProc, tipo_ingreso, Personal_IdG, newhoraIng, '01', motivo.toUpperCase(), Personal_IdG);
                }

                if (tipo == '02' || tipo == '00') {
                    var hs = $('#cboHoraSal').val();
                    var ms = $('#cboMinSal').val();
                    if (!hs) {
                        alert('.::Error > Nueva hora de salida no definida.');
                        $('#cboHoraSal').focus();
                        return false;
                    }

                    if (!ms) {
                        alert('.::Error > Defina el minuto de salida.');
                        $('#cboMinSal').focus();
                        return false;
                    }
                    var newhoraSal = hs + ':' + ms;
                    var tipo_ingreso = '02';
                    Get_AM_Justificacion(FechaProc, tipo_ingreso, Personal_IdG, newhoraSal, '01', motivo.toUpperCase(), Personal_IdG);
                }
            });

            $('#cboTipoJust').change(function () {
                if ($(this).val() == '01') {
                    $('#txtMotivos').val(Mostivos[0]);
                    $('#aVerAchivo').attr('href', FileArr[0]);
                } else {
                    $('#txtMotivos').val(Mostivos[1]);
                    $('#aVerAchivo').attr('href', FileArr[1]);
                }

            });
            $('#btnCancelJustif').click(function () {
                $('#dialog-Justificacion').dialog('close');
            });

            ///-------PERMISOS
            $('#btnPersmisos').click(function () {
                Get_Tipo_Permisos();
                var nn = $("#cboPersonal option:selected").text();
                if (Rol=='01') {
                    $('#lblNombre').html($('#cboPersonal').val() + " / " + nn);
                   
                } else {
                    $('#lblNombre').html(Personal_IdG + " / " + $('#lblNomPersonal').text());

                }
               
             
                Get_Permisos_Fecha_By_Personal(Personal_IdG, FechaIniPer, FechaFinPer);
                Get_Permisos_Horas_By_Personal(Personal_IdG, FechaIniPer, FechaFinPer);
                open_DialogPermiso();
                clear_NewPermiso();
                clear_NewPermisoHoras();
            });
            $('#btnNewPermiso').click(function () {
                PermisoD_Proc = 0;
                clear_NewPermiso();
                $('#cboTPermiso').val('');
                $('#btnSubirPF').hide();
                $('#aFilePF').hide();
                $('#TabContainerPerm').tabs('option', 'active', 1);
            });
            $('#btnNewPermisoHora').click(function () {
                PermisoD_Proc = 0;
                clear_NewPermisoHoras();
                $('#cboPermisoH').val('');
                $('#btnSubirPH').hide();
                $('#aFilePH').hide();
                $('#TabContainerPerm').tabs('option', 'active', 3);
            });



            /*----GRABAR PERMISO----*/


            $('#btnGrabarPermiso').click(function () {
                var Permiso_Id = $('#cboTPermiso').val();
                var Descuento = $("input[type='radio'][name='aplidescuento']:checked").val();
                var FechaIni = $('#txtFechaIni').val();
                var FechaFin = $('#txtFechaFin').val();
                var TipoReg = '01';
                var Motivo = $('#txtMotivo').val();
                var NroDoc = $('#txtNroDoc').val();

                if (!Permiso_Id) {
                    alert('.::Error > Tipo de permiso no definido.');
                    $('#cboTPermiso').focus();
                    return false;
                }

                if (!Descuento) {
                    alert('.::Error > Aplica descuento [Si ó NO].');
                    return false;
                }
                if (!FechaIni) {
                    alert('.::Error > Fecha de inicio no definido.');
                    $('#txtFechaIni').focus();
                    return false;
                }
                if (!FechaFin) {
                    alert('.::Error > Fecha final no definida.');
                    $('#txtFechaFin').focus();
                    return false;
                }
                if (!Motivo) {
                    alert('.::Error > Motivo no definido.');
                    $('#txtMotivo').focus();
                    return false;
                }

                Get_AM_Permisos_Fechas(PermisoD_Proc, Permiso_Id, Personal_IdG, formatFecha.ymd(FechaIni), formatFecha.ymd(FechaFin), Descuento, TipoReg, Motivo.toUpperCase(), NroDoc, Personal_IdG);


            });

            $('#tbodyPermisos').on('click', '.buttonEdit', function () {
                Get_Permiso_Fechas_Find(this.id);
                $('#btnSubirPF').show();
                $('#aFilePF').show();
            });
            $('#tbodyPermisos').on('click', '.buttonDesactiva', function () {
                if (confirm('¿Esta seguro de cancelar la solicitud ?')) {
                    Get_Cancelar_SolicitudPermisoDias(this.id, Personal_IdG);
                }
            });
            $('#btnCancelPer').click(function () {
                clear_NewPermiso();
                PermisoD_Proc = 0;
                $('#btnSubirPF').hide();
                $('#aFilePF').hide();
                $('#TabContainerPerm').tabs('option', 'active', 0);
            });

            $('#cboTPermiso').change(function () {
                Get_Aplica_Descuento_By_TPermiso($(this).val());
                if ($(this).val() == '6') {
                    $('#tdDetalleVac').html('<label>Ver Detalle Vacaciones : </label><input type="button" class="buttonDetalle" id="btnDetalleVac" />');
                } else {
                    $('#tdDetalleVac').html('');
                }
            });

            $('#cboPermisoH').change(function () {
                Get_Aplica_Descuento_By_TPermisoHoras($(this).val());
            });

            /* PERMISOS POR HORAS  */

            $('#btnGrabarPH').click(function () {
                var Permiso_Id = $('#cboPermisoH').val();
                var Descuento = $("input[type='radio'][name='aplidescuentoH']:checked").val();
                var Fecha = $('#txtFechaPH').val();
                var AplicarA = $('#cboAplicarA_PH').val();
                var HIni = $('#cboHIP').val();
                var MIni = $('#cboMIP').val();

                var HFin = $('#cboHFP').val();
                var MFin = $('#cboMFP').val();

                var TipoReg = '01';
                var Motivo = $('#txtMotivoPHora').val();

                if (!Permiso_Id) {
                    alert('.::Error > Tipo de permiso no definido.');
                    $('#cboPermisoH').focus();
                    return false;
                }

                if (!Descuento) {
                    alert('.::Error > Aplica descuento [Si ó NO].');
                    return false;
                }
                if (!Fecha) {
                    alert('.::Error > Fecha no definida.');
                    $('#txtFechaPH').focus();
                    return false;
                }
                if (!AplicarA) {
                    alert('.::Error > Aplicar A (ingreso, salida, intermedio) no definido.');
                    $('#cboAplicarA_PH').focus();
                    return false;
                }
                if (!HIni && !MIni) {
                    alert('.::Error > Hora de inicio no definida.');
                    return false;
                }
                if (!HFin && !MFin) {
                    alert('.::Error > Hora final no definida.');
                    return false;
                }

                var minutosini = ((HIni * 1) * 60) + (MIni * 1);
                var minutosfin = ((HFin * 1) * 60) + (MFin * 1);

                if (minutosfin <= minutosini) {
                    alert('.::Error > Hora final no debe ser menor a la hora de inicio.');
                    return false;
                }

                if (!Motivo) {
                    alert('.::Error > Motivo no definido.');
                    $('#txtMotivoPHora').focus();
                    return false;
                }

                var fechaHINI = formatFecha.ymd(Fecha) + ' ' + HIni + ':' + MIni;
                var fechaHFIN = formatFecha.ymd(Fecha) + ' ' + HFin + ':' + MFin;

                Get_AM_Permisos_Horas(PermisoH_Proc, Permiso_Id, Personal_IdG, formatFecha.ymd(Fecha), fechaHINI, fechaHFIN, Descuento, TipoReg, Motivo.toUpperCase(), Personal_IdG, AplicarA);
            });

            $('#tbodyPermisoHora').on('click', '.buttonEdit', function () {
                Get_Permiso_Horas_Find(this.id);
                $('#btnSubirPH').show();
                $('#aFilePH').show();
            });
            $('#tbodyPermisoHora').on('click', '.buttonDesactiva', function () {
                if (confirm('¿Esta seguro de cancelar la solicitud ?')) {
                    Get_Cancelar_SolicitudPermisoHoras(this.id, Personal_IdG);
                }
            });
            $('#btnCancelarPH').click(function () {
                clear_NewPermisoHoras();
                PermisoH_Proc = 0;
                $('#btnSubirPH').hide();
                $('#aFilePH').hide();
                $('#TabContainerPerm').tabs('option', 'active', 2);
            });


            $('#PTab2').on('click', '#btnDetalleVac', function () {
                var FechaIni = $('#txtFechaIni').val();
                var FechaFin = $('#txtFechaFin').val();

                if (!FechaIni) {
                    alert('.::Error > Fecha de inicio no definido.');
                    $('#txtFechaIni').focus();
                    return false;
                }
                if (!FechaFin) {
                    alert('.::Error > Fecha final no definida.');
                    $('#txtFechaFin').focus();
                    return false;
                }
                var pers_id;
                if (Rol == '01'  || Rol == '03') {
                    pers_id = $('#cboPersonal').val();
                } else {
                    pers_id = Personal_IdG
                }
                Get_DetalleVacaciones(pers_id, formatFecha.ymdEN(FechaIni), formatFecha.ymdEN(FechaFin));
            });





          


          



            /* SUBIR ARCHIVOS */

            $('#btnSubirPF').click(function () {
                uploadFile_Permiso(PermisoD_Proc, Personal_IdG, '01');
            });

            btnSubirPH

            $('#btnSubirPH').click(function () {
                uploadFile_Permiso(PermisoH_Proc, Personal_IdG, '02');
            });

          

          
            



        });
    </script>

    


<style type="text/css">
        .modalContainer {
			display: none; 
			position: fixed; 
			z-index: 1;
			padding-top: 100px;
			left: 0;
			top: 0;
			width: 100%;
			height: 100%; 
			overflow: auto; 
			background-color: rgb(0,0,0);
			background-color: rgba(0,0,0,0.4);
		}

		.modalContainer .modal-content {
			background-color: #fefefe;
			margin: auto;
			padding: 20px;
			border: 1px solid lightgray;
			border-top: 10px solid #58abb7;
			width: 60%;
		}

		.modalContainer .close {
			color: #aaaaaa;
			float: right;
			font-size: 28px;
			font-weight: bold;
		}

		.modalContainer .close:hover,
		.modalContainer .close:focus {
			color: #000;
			text-decoration: none;
			cursor: pointer;
		}

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
            width: 102px;
        }
    </style>


</asp:Content>

  
