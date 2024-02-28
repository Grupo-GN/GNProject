<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JustificacionRRHH.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.Justificacion.JustificacionRRHH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <table class="tableDialog">
        <tr>
            <td style="text-align:right;"><label class="miLabel">Planilla : </label></td>
            <td><select class="cbo" id="cboPlanilla"></select></td>
            <td style="text-align:right;"><label class="miLabel">Localidad : </label></td>
            <td><select class="cbo" id="cboLocalidad"></select></td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Categoria : </label></td>
            <td><select class="cbo" id="cboCategoria"></select></td>
            <td style="text-align:right;"><label class="miLabel">Personal : </label></td>
            <td><select class="cbo" id="cboPersonal"></select></td>
        </tr>
    </table>
    <hr />
    <section id="TabContainerMarc" style="min-height:400px;">
        <ul>
            <li><a href="#Tab1">Solicitudes Pendientes</a></li>
            <li><a href="#Tab2">Marcaciones Incorrectas</a></li>
            <li><a href="#Tab3">Marcaciones Correctas</a></li>
            <li><a href="#Tab4">Permisos</a></li>
        </ul>
        <section id="Tab1">
            <fieldset>
                <legend><label class="miTituloField">Justificaciones</label></legend>
                <input type="button" id="btnAproAllJust" value="Aprobar" class="submit" />
                    <table class="table">
                        <thead>
                            <tr>
                                <th></th>
                                <th>SOLICITUD</th>
                                <th>ESTADO</th>
                                <th>PERSONAL</th>
                                <th>DIA</th>
                                <th>FECHA</th>
                                <th>H INI HO.</th>
                                <th>H FIN HO.</th>
                                <th>H ING MAR.</th>
                                <th>H SAL MAR.</th>
                                <th>H ING PRO.</th>
                                <th>H SAL PRO.</th>
                                <th>TOT HORA</th>
                                <th>OBSERVACIÓN</th>
                                <th><input type="checkbox" id="chkAllApro" /></th>
                            </tr>
                        </thead>
                        <tbody id="tbodyJusfPend">

                        </tbody>
                    </table>
            </fieldset>
            <fieldset>
                <legend><label class="miTituloField">Permisos - Fechas</label></legend>
                    <table class="table">
                        <thead>
                            <tr>
                                <th></th>
                                <th>PERMISO</th>
                                <th>PERSONAL</th>
                                <th>ESTADO</th>
                                <th>F. INICIO</th>
                                <th>F. FINAL</th>
                                <th>DESCUENTO</th>
                                <th>NRO DOC</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody id="tbodyPermisosFechas">
                        </tbody>
                    </table>
            </fieldset>
            <fieldset>
                <legend><label class="miTituloField">Permisos - Horas</label></legend>
                    <table class="table">
                        <thead>
                            <tr>
                                <th></th>
                                <th>PERMISO</th>
                                <th>PERSONAL</th>
                                <th>ESTADO</th>
                                <th>FECHA</th>
                                <th>H. INICIO</th>
                                <th>H. FINAL</th>
                                <th>DESCUENTO</th>
                            </tr>
                        </thead>
                        <tbody id="tbodyPermisoHora"></tbody>
                    </table>
            </fieldset>
        </section>
        <section id="Tab2">        
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
                    <th style="cursor:help;" title="Total de Horas">HTOT</th>
                    <th style="cursor:help;" title="Horas Extras Simples">HES</th>
                    <th style="cursor:help;" title="Horas Extras Adcionales">HEA</th>
                    <th style="cursor:help;" title="Horas Extras Dobles">HED</th>
                    <th style="cursor:help;" title="Minutos de Tardanza">MinTard</th>
                     <th style="cursor:help;" title="Fata">Falta</th>
                    <th>OBSERVACIÓN</th>
                </tr>
            </thead>
            <tbody id="tbodyMMPersonal"></tbody>
        </table>
        </section>
        <section id="Tab3">
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
                            <th style="cursor:help;" title="Total de Horas">HTOT</th>
                            <th style="cursor:help;" title="Horas Extras Simples">HES</th>
                            <th style="cursor:help;" title="Horas Extras Adcionales">HEA</th>
                            <th style="cursor:help;" title="Horas Extras Dobles">HED</th>
                            <th style="cursor:help;" title="Minutos de Tardanza">MinTard</th>
                             <th style="cursor:help;" title="Fata">Falta</th>
                            <th>OBSERVACIÓN</th>
                        </tr>
                    </thead>
                    <tbody id="tbodyMCorr"></tbody>
                </table>
        </section>
        <section id="Tab4">
        
    <section id="TabContainerPerm">
        <ul>
            <li><a href="#PTab1">FECHAS</a></li>
            <li><a href="#PTab2">DETALLE - FECHAS</a></li>
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
                <tbody id="tbodyPermisosJEF">
                
                </tbody>
            </table>            
        </section>
        <section id="PTab2">
            <table class="tableDialog">
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Permiso : </label></td>
                    <td><select class="cbo" id="cboTPermisoJEF"></select></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Aplica Descuento : </label></td>
                    <td>SI<input type="radio" id="rdSIJEF" value="01" name="aplidescuentoJEF" />&nbsp;&nbsp; NO<input type="radio" id="rdNoJEF" value="02" name="aplidescuentoJEF" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;width:130px;"><label class="miLabel">Fecha Inicio : </label></td>
                    <td><input type="text" id="txtFechaIniJEF" class="txt" style="width:100px;" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Fecha Final : </label></td>
                    <td><input type="text" id="txtFechaFinJEF" class="txt" style="width:100px;" /></td>
                    <td id="tdDetalleVac"></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Nro. Documento : </label></td>
                    <td><input type="text" id="txtNroDocJEF" class="txt" maxlength="100"/></td>
                    <td></td>
                </tr>
                <tr>
                    <td  style="text-align:right;vertical-align:top;"><label class="miLabel">Motivo : </label></td>
                    <td><textarea rows="2" cols="30" class="txt" id="txtMotivoJEF"></textarea></td>
                    <td></td>
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
                        <td><textarea rows="2" cols="30" class="txt" id="txtComentJefeJEF" maxlength="300"></textarea></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><label class="miLabel">Aprobación RRHH : </label></td>
                        <td><label class="miLabel" id="lblERRHH"></label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Comentarios RRHH : </label></td>
                        <td><textarea rows="2" cols="30"  class="txt" id="txtComentRRHHJEF" maxlength="300"></textarea></td>
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
                <tbody id="tbodyPermisoHoraJEF">
                
                </tbody>
            </table>
        </section>
         <section id="PTab4">
            <table class="tableDialog">
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Permiso : </label></td>
                    <td><select class="cbo" id="cboPermisoHJEF"></select></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Aplica Descuento : </label></td>
                    <td>SI<input type="radio" id="rdSiHJEF" value="01" name="aplidescuentoHJEF" />&nbsp;&nbsp; NO<input type="radio" id="rsNoHJEF" value="02" name="aplidescuentoHJEF" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Fecha : </label></td>
                    <td><input type="text" id="txtFechaPHJEF" class="txt" style="width:100px;" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Aplicar a : </label></td>
                    <td><select id="cboAplicarA_PHJEF" class="cbo">
                        <option value="1">Ingreso</option>
                        <option value="2">Salida</option>
                        <option value="3">Intermedio</option>
                        </select></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;width:130px;"><label class="miLabel">Hora Inicio : </label></td>
                    <td><select class="cbo" id="cboHIPJEF"></select> : <select class="cbo" id="cboMIPJEF"></select></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Hora Final : </label></td>
                    <td><select class="cbo" id="cboHFPJEF"></select> : <select class="cbo" id="cboMFPJEF"></select></td>
                    <td></td>
                </tr>
                <tr>
                    <td  style="text-align:right;vertical-align:top;"><label class="miLabel">Motivo : </label></td>
                    <td><textarea rows="2" cols="30" class="txt" id="txtMotivoPHoraJEF"></textarea></td>
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
                        <td><textarea rows="2" cols="30" class="txt" id="txtComentJefeHJEF" maxlength="300"></textarea></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><label class="miLabel">Aprobación RRHH : </label></td>
                        <td><label class="miLabel" id="lblRRHHo"></label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Comentarios RRHH : </label></td>
                        <td><textarea rows="2" cols="30"  class="txt" id="txtComentRRHHHoJEF" maxlength="300"></textarea></td>
                    </tr>
                </table>
            </fieldset>
        </section>

     </section>


        </section>
    </section>

    <section id="dialog-JustPropuesta" title="Verificar Justificación">
        <table class="tableDialog">
                    <tr>
                        <td style="width:200px;text-align:right;"><label class="miLabel">Personal : </label></td>
                        <td colspan="2"><label class="miLabel" id="lblPersonalJusti"></label></td>
                        
                    </tr>
                    <tr>
                        <td style="width:200px;text-align:right;"><label class="miLabel">Fecha : </label></td>
                        <td><label class="miLabel" id="lblFechaJusti"></label></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><label class="miLabel">Hora de Ingreso Real : </label></td>
                        <td><label class="miLabel" id="lblHIR"></label></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><label class="miLabel">Hora de Ingreso Propuesto : </label></td>
                        <td><select class="cbo" id="cboHoraIng"></select> : <select class="cbo" id="cboMinIng"></select> </td>
                        <td><input type="button" id="btnAAJustIng" value="ACTUALIZAR Y APROBAR" class="submit" style="width:180px;font-size:12px;"/> <input type="button" id="btnAproIng" value="APROBAR" class="submit"/>&nbsp;<input type="button" id="btnDesaproIng" value="DESAPROBAR" class="submit"/></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><label class="miLabel">Hora de Salida Real : </label></td>
                        <td><label class="miLabel" id="lblHSR"></label></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><label class="miLabel">Hora de Salida Propuesta : </label></td>
                        <td><select class="cbo" id="cboHoraSal"><option>01</option></select> : <select class="cbo" id="cboMinSal"><option>00</option></select> </td>
                        <td><input type="button" id="btnAAJustSal" value="ACTUALIZAR Y APROBAR" class="submit" style="width:180px;font-size:12px;"/> <input type="button" id="btnAproSal" value="APROBAR" class="submit"/>&nbsp;<input type="button" id="btnDesaproSal" value="DESAPROBAR" class="submit"/></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Motivo : </label></td>
                        <td colspan="2"><textarea rows="2" cols="30" class="txt" id="txtMotivos"></textarea></td>
                        
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align:center;"><input type="button" value="SALIR" class="submit" id="btnSalirJust"/></td>
                    </tr>
        </table>
    </section>
    <section id="dialog-PerFechas" title="Permisos por Fechas">
            <table class="tableDialog">
                <tr>
                    <td style="width:200px;text-align:right;"><label class="miLabel">Personal : </label></td>
                    <td colspan="2"><label class="miLabel" id="lblPersonalJF"></label></td>
                        
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Permiso : </label></td>
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
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Nro. Documento : </label></td>
                    <td><input type="text" id="txtNroDoc" class="txt" maxlength="100"/></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Archivo : </label></td>
                    <td><a href="#" id="aFilePF" target="_blank">Ver Archivo</a></td>
                    <td></td>
                </tr>
                <tr>
                    <td  style="text-align:right;vertical-align:top;"><label class="miLabel">Motivo : </label></td>
                    <td><textarea rows="2" cols="30" class="txt" id="txtMotivo"></textarea></td>
                    <td></td>
                </tr>

            </table>
            <fieldset>
                <table class="tableDialog">
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Comentarios Jefe : </label></td>
                        <td><textarea rows="2" cols="30" class="txt" id="txtComentJefe" maxlength="300"></textarea></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Comentarios : </label></td>
                        <td><textarea rows="2" cols="30" class="txt" id="txtComentarioRRHHF" maxlength="300"></textarea></td>
                    </tr>
                <tr>
                    <td colspan="2" style="text-align:center;"><input type="button" class="submit" value="ACTUALIZAR Y APROBAR" id="btnGAPermisoFecha" style="width:180px;font-size:12px;"/>&nbsp;<input type="button" class="submit" value="APROBAR" id="btnAproPFecha" />&nbsp; <input type="button" class="submit" value="DESAPROBAR" id="btnDesaproPFecha" style="width:100px;font-size:12px;"/>&nbsp; <input type="button" class="submit" value="SALIR" id="btnCancelPFechas" /></td>
                </tr>
                </table>
            </fieldset>
    </section>

    <section id="dialog-PerHoras">
            <table class="tableDialog">
                <tr>
                    <td style="width:200px;text-align:right;"><label class="miLabel">Personal : </label></td>
                    <td colspan="2"><label class="miLabel" id="lblPersonaJH"></label></td>
                        
                </tr>
                <tr>
                    <td style="text-align:right;"><label class="miLabel">Permiso : </label></td>
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
                    <td><a href="#" id="aFilePH" target="_blank">Ver Archivo</a></td>
                    <td></td>
                </tr>
                <tr>
                    <td  style="text-align:right;vertical-align:top;"><label class="miLabel">Motivo : </label></td>
                    <td><textarea rows="2" cols="30" class="txt" id="txtMotivoPHora"></textarea></td>
                    <td></td>
                </tr>

            </table>
            <fieldset>
                <table class="tableDialog">
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Comentarios Jefe : </label></td>
                        <td><textarea rows="2" cols="30" class="txt" id="txtComentJefeH" maxlength="300"></textarea></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Comentarios : </label></td>
                        <td><textarea rows="2" cols="30" class="txt" id="txtComentarioRRHHH" maxlength="300"></textarea></td>
                    </tr>
                <tr>
                    <td colspan="2" style="text-align:center;"><input type="button" class="submit" value="ACTUALIZAR Y APROBAR" id="btnAAPerHoras" style="width:180px;font-size:12px;"/>&nbsp;<input type="button" class="submit" value="APROBAR" id="btnAproPHora" />&nbsp; <input type="button" class="submit" value="DESAPROBAR" id="btnDesaPHora" style="width:100px;font-size:12px;"/>&nbsp; <input type="button" class="submit" value="SALIR" id="btnCancelPHora" /></td>
                </tr>
                </table>
            </fieldset>
    </section>

  <%--GENERAR JUSTIFICACIONES Y PERMISOS --%>

  <section id="dialog-Justificacion" title="JUSTIFICACION">
      <table class="tableDialog">
                    <tr>
                        <td style="width:120px;text-align:right;"><label class="miLabel">Fecha : </label></td>
                        <td><label class="miLabel" id="lblFechaJustiJEF"></label></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><label class="miLabel">Tipo : </label></td>
                        <td><select class="cbo" id="cboTipoJust"><option value="01" selected>INGRESO</option><option value="02">SALIDA</option></select></td>
                        <td></td>
                    </tr>
                    <tr id="tdInfIng2" >
                        <td style="text-align:right;"><label class="miLabel">Hora de Ingreso : </label></td>
                        <td><select class="cbo" id="cboHoraIngJEF"><option>01</option></select> : <select class="cbo" id="cboMinIngJEF"><option>00</option></select> </td>
                        <td><label id="lblInfoIngreso"  style="color:#026F2B;" ></label></td>
                    </tr>
                    <tr id="tdInfSal2">
                        <td style="text-align:right;"><label class="miLabel">Hora de Salida : </label></td>
                        <td><select class="cbo" id="cboHoraSalJEF"><option>01</option></select> : <select class="cbo" id="cboMinSalJEF"><option>00</option></select> </td>
                        <td><label id="lblInfoSalida"  style="color:#026F2B;" ></label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;"><label class="miLabel">Motivo : </label></td>
                        <td colspan="2"><textarea rows="2" cols="30" class="txt" id="txtMotivosJEF"></textarea></td>
                        
                    </tr>
                    <tr>
                        <td style="text-align:center;" colspan="3"><input type="button" value="GRABAR" class="submit" id="btnGrabarJust" />&nbsp; <input type="button" value="CANCELAR" class="submit" id="btnCancelJustJEF" /></td>            
                    </tr>
                </table>
</section>
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
    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_JustificacionRRHH.js" type="text/javascript"></script>
    <script src="Scripts/Script_CrearMenu.js" type="text/javascript"></script>
    <script type="text/javascript">
        var Periodo_Des = '';
        var Periodo_Proc = '';
        //var Jefe_Proc = '000426';
        var Perso_RRHH_Proc = '<%= Session["Usuario_Id"] %>';
        var Personal_Fin = '';
        var FechaIniPer = '';
        var FechaFinPer = '';
        var PermisoD_Proc = 0;
        var PermisoH_Proc = 0;
        var hideBAING, hideBDING, hideBASAL, hideBDSAL, hideBAAING, hideBAASAL;

        var Mostivos = [];

        $(document).ready(function () {
            $('#TabContainerPerm').tabs();
            //if (!Perso_RRHH_Proc) {
            //    setTimeout('window.location="Acceso.aspx"', 50);
            //}
            $('#dialog-JustPropuesta').hide();
            $('#dialog-PerFechas').hide();
            $('#dialog-PerHoras').hide();
            $('#dialog-Justificacion').hide();
            $('#TabContainerMarc').tabs();
            Get_Periodo_Activo_Asistencia();
            Get_Planilla_List();
            Get_Localidad_List();
            Get_Categoria_List();
            Get_Personal_List(Get_Planilla_Find(), Periodo_Des, Get_Localidad_Find(), Get_Categoria_Find());
            Get_Justificaciones_Pendientes_Jefe(Personal_Fin, FechaIniPer, FechaFinPer);
            Get_Permisos_Pendientes_Personal(Personal_Fin, FechaIniPer, FechaFinPer);
            Get_Permisos_Horas_Pendientes_Personal(Personal_Fin, FechaIniPer, FechaFinPer);
            CrearFechas();
            CargarHorasMin();
            Get_Tipo_Permisos();
            Get_Marcaciones_Malas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
            Get_Marcaciones_Correctas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
            Get_Permisos_Fecha_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
            Get_Permisos_Horas_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);

            document.getElementById('rdSI').disabled = true;
            document.getElementById('rdNo').disabled = true;
            document.getElementById('rdSiH').disabled = true;
            document.getElementById('rsNoH').disabled = true;

            document.getElementById('rdSIJEF').disabled = true;
            document.getElementById('rdNoJEF').disabled = true;
            document.getElementById('rdSiHJEF').disabled = true;
            document.getElementById('rsNoHJEF').disabled = true;



            $('#cboPlanilla').change(function () {
                Get_Personal_List(Get_Planilla_Find(), Periodo_Des, Get_Localidad_Find(), Get_Categoria_Find());
                Get_Marcaciones_Malas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                Get_Marcaciones_Correctas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                Get_Permisos_Fecha_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                Get_Permisos_Horas_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
            });
            $('#cboLocalidad').change(function () {
                Get_Personal_List(Get_Planilla_Find(), Periodo_Des, Get_Localidad_Find(), Get_Categoria_Find());
                Get_Marcaciones_Malas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                Get_Marcaciones_Correctas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                Get_Permisos_Fecha_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                Get_Permisos_Horas_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
            });

            $('#cboCategoria').change(function () {
                Get_Personal_List(Get_Planilla_Find(), Periodo_Des, Get_Localidad_Find(), Get_Categoria_Find());
                Get_Marcaciones_Correctas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                Get_Marcaciones_Malas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                Get_Permisos_Fecha_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                Get_Permisos_Horas_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
            });
            $('#cboPersonal').change(function () {

                Get_Marcaciones_Malas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                Get_Marcaciones_Correctas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                Get_Permisos_Fecha_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                Get_Permisos_Horas_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
            });


            $('#tbodyJusfPend').on('click', '.buttonProcess', function () {
                Get_Justiticacion_Find(this.id);
            });

            $('#btnAAJustIng').click(function () {
                if ($(this).attr('name')) {
                    if (confirm('¿Esta seguro de continuar?')) {
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
                        Get_AA_Justificacion($(this).attr('name'), newhoraIng, Perso_RRHH_Proc);
                    }
                } else {
                    alert('.::Error > Justificacion no definida.');
                }

            });


            $('#btnAAJustSal').click(function () {
                if ($(this).attr('name')) {
                    if (confirm('¿Esta seguro de continuar?')) {
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
                        Get_AA_Justificacion($(this).attr('name'), newhoraSal, Perso_RRHH_Proc);
                    }
                } else {
                    alert('.::Error > Justificacion no definida.');
                }
            });


            $('#btnAproIng').click(function () {
                if ($(this).attr('name')) {
                    if (confirm('¿Esta seguro de Aprobar?')) {
                        Get_AprobarDesaprobar_Justificacion($(this).attr('name'), '01', Perso_RRHH_Proc);
                    }
                } else {
                    alert('.::Error > Justificacion no definida.');
                }
            });

            $('#btnDesaproIng').click(function () {
                if ($(this).attr('name')) {
                    if (confirm('¿Esta seguro de Desaprobar?')) {
                        Get_AprobarDesaprobar_Justificacion($(this).attr('name'), '02', Perso_RRHH_Proc);
                    }
                } else {
                    alert('.::Error > Justificacion no definida.');
                }
            });

            $('#btnAproSal').click(function () {
                if ($(this).attr('name')) {
                    if (confirm('¿Esta seguro de Aprobar?')) {
                        Get_AprobarDesaprobar_Justificacion($(this).attr('name'), '01', Perso_RRHH_Proc);
                    }
                } else {
                    alert('.::Error > Justificacion no definida.');
                }
            });

            $('#btnDesaproSal').click(function () {
                if ($(this).attr('name')) {
                    if (confirm('¿Esta seguro de Desaprobar?')) {
                        Get_AprobarDesaprobar_Justificacion($(this).attr('name'), '02', Perso_RRHH_Proc);
                    }
                } else {
                    alert('.::Error > Justificacion no definida.');
                }
            });


            $('#btnSalirJust').click(function () {
                $('#dialog-JustPropuesta').dialog('close');
            });


            /* ------PERMISIS FECHAS----- */
            $('#tbodyPermisosFechas').on('click', '.buttonProcess', function () {
                Get_Tipo_Permisos();
                Get_Permiso_Fechas_Find(this.id);

            });

            $('#cboTPermiso').change(function () {
                var aplica = Get_Aplica_Descuento_By_TPermiso($(this).val());
                if (aplica == '01') {
                    $('#rdSI').prop('checked', true);
                    $('#rdNo').prop('checked', false);
                } else {
                    $('#rdSI').prop('checked', false);
                    $('#rdNo').prop('checked', true);
                }
            });

            $('#btnGAPermisoFecha').click(function () {
                if (confirm('¿Esta seguro de continuar?')) {
                    var Permiso_Id = $('#cboTPermiso').val();
                    var Descuento = $("input[type='radio'][name='aplidescuento']:checked").val();
                    var FechaIni = $('#txtFechaIni').val();
                    var FechaFin = $('#txtFechaFin').val();
                    var NroDoc = $('#txtNroDoc').val();
                    var comentario = $('#txtComentarioRRHHF').val();

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

                    Get_AA_Permiso_Fechas(PermisoD_Proc, Permiso_Id, formatFecha.ymd(FechaIni), formatFecha.ymd(FechaFin), Descuento, NroDoc, comentario.toUpperCase(), Perso_RRHH_Proc);
                }
            });


            $('#btnAproPFecha').click(function () {
                if (confirm('¿Esta seguro de aprobar?')) {
                    var comentario = $('#txtComentarioRRHHF').val();
                    Get_AprobarDesaprobar_Permiso_Fechas(PermisoD_Proc, comentario.toUpperCase(), '01', Perso_RRHH_Proc);
                }
            });
            $('#btnDesaproPFecha').click(function () {
                if (confirm('¿Esta seguro de desaprobar?')) {
                    var comentario = $('#txtComentarioRRHHF').val();
                    Get_AprobarDesaprobar_Permiso_Fechas(PermisoD_Proc, comentario.toUpperCase(), '02', Perso_RRHH_Proc);
                }
            });
            $('#btnCancelPFechas').click(function () {
                clear_NewPermiso();
                PermisoD_Proc = 0;
                $('#dialog-PerFechas').dialog('close');
            });


            /*-----PERMISOS HORAS----*/

            $('#tbodyPermisoHora').on('click', '.buttonProcess', function () {
                Get_Tipo_Permisos();
                Get_Permiso_Horas_Find(this.id);
            });


            $('#btnAAPerHoras').click(function () {
                if (confirm('¿Esta seguro de continuar?')) {
                    var Permiso_Id = $('#cboPermisoH').val();
                    var Descuento = $("input[type='radio'][name='aplidescuentoH']:checked").val();
                    var Fecha = $('#txtFechaPH').val();
                    var AplicarA = $('#cboAplicarA_PH').val();
                    var HIni = $('#cboHIP').val();
                    var MIni = $('#cboMIP').val();

                    var HFin = $('#cboHFP').val();
                    var MFin = $('#cboMFP').val();

                    var comentario = $('#txtComentarioRRHHH').val();


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

                    var fechaHINI = formatFecha.ymd(Fecha) + ' ' + HIni + ':' + MIni;
                    var fechaHFIN = formatFecha.ymd(Fecha) + ' ' + HFin + ':' + MFin;

                    Get_AA_Permisos_Horas(PermisoH_Proc, Permiso_Id, formatFecha.ymd(Fecha), fechaHINI, fechaHFIN, Descuento, comentario.toUpperCase(), Perso_RRHH_Proc, AplicarA);
                }
            });


            $('#btnAproPHora').click(function () {
                if (confirm('¿Esta seguro de aprobar?')) {
                    var comentario = $('#txtComentarioRRHHH').val();
                    Get_AprobarDesaprobar_Permiso_Horas(PermisoH_Proc, comentario.toUpperCase(), '01', Perso_RRHH_Proc);
                }
            });
            $('#btnDesaPHora').click(function () {
                if (confirm('¿Esta seguro de desaprobar?')) {
                    var comentario = $('#txtComentarioRRHHH').val();
                    Get_AprobarDesaprobar_Permiso_Horas(PermisoH_Proc, comentario.toUpperCase(), '02', Perso_RRHH_Proc);
                }
            });
            $('#btnCancelPHora').click(function () {
                clear_NewPermisoHoras();
                PermisoH_Proc = 0;
                $('#dialog-PerHoras').dialog('close');
            });


            /*=============GENERAR PERMISOS Y JUSTIFICACIONES=============*/


            $('#tbodyMMPersonal').on('click', '.buttonEditMarc', function () {
                Get_Justificacion_Find(this.id);
            });

            $('#tbodyMCorr').on('click', '.buttonEditMarc', function () {
                Get_Justificacion_Find(this.id);
            });

            $('#btnGrabarJust').click(function () {
                var tipo = $('#cboTipoJust').val();
                var motivo = $('#txtMotivosJEF').val();

                if (!motivo) {
                    alert('.::Error > Motivo no definido.');
                    $('#txtMotivosJEF').focus();
                    return false;
                }

                if (motivo.length < 10) {
                    alert('.::Error > Sea mas especifico.');
                    $('#txtMotivosJEF').focus();
                    return false;
                }


                if (tipo == '01') {
                    var hi = $('#cboHoraIngJEF').val();
                    var mi = $('#cboMinIngJEF').val();

                    if (!hi) {
                        alert('.::Error > Nueva hora de ingreso no definida.');
                        $('#cboHoraIngJEF').focus();
                        return false;
                    }

                    if (!mi) {
                        alert('.::Error > Defina el minuto de ingreso.');
                        $('#cboMinIngJEF').focus();
                        return false;
                    }
                    var newhoraIng = hi + ':' + mi;
                    Get_AM_Justificacion_Otros(FechaProc, tipo, Get_Personal_Find(), newhoraIng, '03', motivo.toUpperCase(), '03', Perso_RRHH_Proc, '01');

                } else if (tipo == '02') {

                    var hs = $('#cboHoraSalJEF').val();
                    var ms = $('#cboMinSalJEF').val();
                    if (!hs) {
                        alert('.::Error > Nueva hora de salida no definida.');
                        $('#cboHoraSalJEF').focus();
                        return false;
                    }

                    if (!ms) {
                        alert('.::Error > Defina el minuto de salida.');
                        $('#cboMinSalJEF').focus();
                        return false;
                    }

                    var newhoraSal = hs + ':' + ms;
                    Get_AM_Justificacion_Otros(FechaProc, tipo, Get_Personal_Find(), newhoraSal, '03', motivo.toUpperCase(), '03', Perso_RRHH_Proc, '01');
                }

            });


            $('#cboTipoJust').change(function () {

                if ($(this).val() == '01') {
                    $('#txtMotivosJEF').val(Mostivos[0]);
                } else {
                    $('#txtMotivosJEF').val(Mostivos[1]);
                }

            });


            $('#btnCancelJustJEF').click(function () {
                $('#dialog-Justificacion').dialog('close');
            });

            ///-------PERMISOS

            $('#btnNewPermiso').click(function () {

                PermisoD_Proc = 0;
                clear_NewPermiso_JEF();
                $('#TabContainerPerm').tabs('option', 'active', 1);
            });
            $('#btnNewPermisoHora').click(function () {

                PermisoD_Proc = 0;
                clear_NewPermisoHoras_JEF();
                $('#TabContainerPerm').tabs('option', 'active', 3);
            });


            /*----GRABAR PERMISO----*/


            $('#btnGrabarPermiso').click(function () {
                var Permiso_Id = $('#cboTPermisoJEF').val();
                var Descuento = $("input[type='radio'][name='aplidescuentoJEF']:checked").val();
                var FechaIni = $('#txtFechaIniJEF').val();
                var FechaFin = $('#txtFechaFinJEF').val();
                var TipoReg = '03';
                var Motivo = $('#txtMotivoJEF').val();
                var NroDoc = $('#txtNroDocJEF').val();

                var ComentJefe = $('#txtComentRRHHJEF').val();


                if (!Permiso_Id) {
                    alert('.::Error > Tipo de permiso no definido.');
                    $('#cboTPermisoJEF').focus();
                    return false;
                }

                if (!Descuento) {
                    alert('.::Error > Aplica descuento [Si ó NO].');
                    return false;
                }
                if (!FechaIni) {
                    alert('.::Error > Fecha de inicio no definido.');
                    $('#txtFechaIniJEF').focus();
                    return false;
                }
                if (!FechaFin) {
                    alert('.::Error > Fecha final no definida.');
                    $('#txtFechaFinJEF').focus();
                    return false;
                }
                if (!Motivo) {
                    alert('.::Error > Motivo no definido.');
                    $('#txtMotivoJEF').focus();
                    return false;
                }

                Get_AM_Permisos_Fechas_Otros(PermisoD_Proc, Permiso_Id, Get_Personal_Find(), formatFecha.ymd(FechaIni)
                , formatFecha.ymd(FechaFin), Descuento, TipoReg, Motivo.toUpperCase(), NroDoc, '00','' , '01', ComentJefe, '03', Perso_RRHH_Proc, '01');


            });

            $('#tbodyPermisosJEF').on('click', '.buttonEdit', function () {
                Get_Permiso_Fechas_Find_Jef(this.id);
            });
            $('#tbodyPermisosJEF').on('click', '.buttonDesactiva', function () {
                if (confirm('¿Esta seguro de cancelar la solicitud ?')) {
                    Get_Cancelar_SolicitudPermisoDias(this.id, Perso_RRHH_Proc);
                }
            });
            $('#btnCancelPer').click(function () {
                clear_NewPermiso_JEF();
                PermisoD_Proc = 0;
                $('#TabContainerPerm').tabs('option', 'active', 0);
            });

            $('#cboTPermisoJEF').change(function () {
                var aplica = Get_Aplica_Descuento_By_TPermiso($(this).val());
                if (aplica == '01') {
                    $('#rdSIJEF').prop('checked', true);
                    $('#rdNoJEF').prop('checked', false);
                } else {
                    $('#rdSIJEF').prop('checked', false);
                    $('#rdNoJEF').prop('checked', true);
                }
                if ($(this).val() == '6') {
                    $('#tdDetalleVac').html('<label>Ver Detalle Vacaciones : </label><input type="button" class="buttonDetalle" id="btnDetalleVac" />');
                } else {
                    $('#tdDetalleVac').html('');
                }
            });

            $('#cboPermisoHJEF').change(function () {
                var aplica = Get_Aplica_Descuento_By_TPermiso($(this).val());
                if (aplica == '01') {
                    $('#rdSiHJEF').prop('checked', true);
                    $('#rsNoHJEF').prop('checked', false);
                } else {
                    $('#rdSiHJEF').prop('checked', false);
                    $('#rsNoHJEF').prop('checked', true);
                }
            });
            /* PERMISOS POR HORAS  */

            $('#btnGrabarPH').click(function () {
                var Permiso_Id = $('#cboPermisoHJEF').val();
                var Descuento = $("input[type='radio'][name='aplidescuentoHJEF']:checked").val();
                var Fecha = $('#txtFechaPHJEF').val();
                var AplicarA = $('#cboAplicarA_PHJEF').val();
                var HIni = $('#cboHIPJEF').val();
                var MIni = $('#cboMIPJEF').val();

                var HFin = $('#cboHFPJEF').val();
                var MFin = $('#cboMFPJEF').val();

                var ComenteJefe = $('#txtComentRRHHHoJEF').val();

                var TipoReg = '03';
                var Motivo = $('#txtMotivoPHoraJEF').val();

                if (!Permiso_Id) {
                    alert('.::Error > Tipo de permiso no definido.');
                    $('#cboPermisoHJEF').focus();
                    return false;
                }

                if (!Descuento) {
                    alert('.::Error > Aplica descuento [Si ó NO].');
                    return false;
                }
                if (!Fecha) {
                    alert('.::Error > Fecha no definida.');
                    $('#txtFechaPHJEF').focus();
                    return false;
                }
                if (!AplicarA) {
                    alert('.::Error > Aplicar A (ingreso, salida, intermedio) no definido.');
                    $('#cboAplicarA_PHJEF').focus();
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
                    $('#txtMotivoPHoraJEF').focus();
                    return false;
                }

                var fechaHINI = formatFecha.ymd(Fecha) + ' ' + HIni + ':' + MIni;
                var fechaHFIN = formatFecha.ymd(Fecha) + ' ' + HFin + ':' + MFin;

                Get_AM_Permisos_Horas_Otros(PermisoH_Proc, Permiso_Id, Get_Personal_Find(), formatFecha.ymd(Fecha), fechaHINI, fechaHFIN
                , Descuento, TipoReg, '00', '', '01', ComenteJefe, Motivo.toUpperCase(), Perso_RRHH_Proc, '03', '01', AplicarA);
            });

            $('#tbodyPermisoHoraJEF').on('click', '.buttonEdit', function () {
                Get_Permiso_Horas_Find_Jef(this.id);
            });
            $('#tbodyPermisoHoraJEF').on('click', '.buttonDesactiva', function () {
                if (confirm('¿Esta seguro de cancelar la solicitud ?')) {
                    Get_Cancelar_SolicitudPermisoHoras(this.id, Perso_RRHH_Proc);
                }
            });
            $('#btnCancelarPH').click(function () {
                clear_NewPermisoHoras_JEF();
                PermisoH_Proc = 0;
                $('#TabContainerPerm').tabs('option', 'active', 2);
            });


            $('#PTab2').on('click', '#btnDetalleVac', function () {
                var FechaIni = $('#txtFechaIniJEF').val();
                var FechaFin = $('#txtFechaFinJEF').val();

                if (!FechaIni) {
                    alert('.::Error > Fecha de inicio no definido.');
                    $('#txtFechaIniJEF').focus();
                    return false;
                }
                if (!FechaFin) {
                    alert('.::Error > Fecha final no definida.');
                    $('#txtFechaFinJEF').focus();
                    return false;
                }
                Get_DetalleVacaciones(Get_Personal_Find(), formatFecha.ymdEN(FechaIni), formatFecha.ymdEN(FechaFin));
            });

            $('#chkAllApro').change(function () {
                var ch = $(this).prop('checked');
                $('.chkAprobarJust').prop('checked', ch);
            });


            $('#btnAproAllJust').click(function () {

                var Asistencia = [];
                $('.chkAprobarJust').each(function () {
                    var check = $(this).prop('checked');
                    if (check) {
                        Asistencia.push(this.id);
                    }
                });
                if (Asistencia.length == 0) {
                    alert('Seleccione por lo menos una justificación');
                    return false;
                }
                if (confirm('¿Está seguro de aprobar lo seleccionado?')) {
                    Proc_AprobarJustificacion(Asistencia, Perso_RRHH_Proc);
                }
            });
        });
    </script>

</asp:Content>
