<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sConfigReporte.aspx.cs" Inherits="GNProject.Views.Indicendia01.Server.pConfigReporte.sConfigReporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
  <style>

  
  #listInstensidad_Out,#listMensajeGere
  {
      list-style-type: none;
      width:170px;
      border:1px solid #737373;
      float: left;
      margin: 0;
      padding: 0;
      height:180px;
      overflow-x:hidden;
      overflow-y:auto;
      }
      #listInstensidad_Out li,#listMensajeGere li
      {
           margin: 5px; padding: 5px; font-size: 12px; width: 89%; 
           cursor:move;
           border:1px solid #d3d3d3;
           background:#e6e6e6;
          }  
  </style>

<table class="tableDialog">
    <tr>
        <td style="width:50%;">
            <fieldset style="width:95%;">
                <legend><label class="miTituloField">INTESIDAD</label></legend>
                <table style="width:100%;">
                    <tr>
                        <td rowspan="6" style="width:153px;">
                            <select id="lbIntensidad" size="10" style="width:150px;">
                                <option value="01">Sin Lesion</option>
                                <option value="01">Lesion Leve</option>
                                <option value="01">Lesion Grave</option>
                                <option value="01">Lesion Fatal</option>
                            </select>
                        </td>
                        <td><label class="miLabel">Configuracion:</label> </td>
                    </tr>
                    <tr>
                        <td><label class="miLabel">Intensidad:</label></td>
                    </tr>
                    <tr>
                        <td><input id="txtInte_Descrip" type="text" class="txt" style="width:100%;" /></td>
                    </tr>
                    <tr>
                        <td><label class="labelError" id="lblErrorIntensidad">&nbsp;</label></td>
                    </tr>
                    <tr>
                        <td><input id="btnGrabarIntensidad" type="button" class="submit" value="Grabar"/>&nbsp;&nbsp;
                        <input id="btnCancelIntensidad" type="button" class="submit" value="Cancelar" />&nbsp;&nbsp;
                        <input id="btnDeleteIntensidad" type="button" class="submit" value="Eliminar" /></td>
                    </tr>
                    <tr>
                        <td>                        
                            </td>
                    </tr>
                </table>

            </fieldset>        
        </td>
        <td style="width:50%;" >
        <fieldset style="width:95%;">
                <legend><label class="miTituloField">SEVERIDAD</label></legend>
                <table style="width:100%;">
                    <tr>
                        <td rowspan="6" style="width:153px;">
                            <select id="lbSeveridad" size="10" style="width:150px;">
                                <option value="01">Alta</option>
                                <option value="01">Media</option>
                                <option value="01">Baja</option>
                            </select>
                        </td>
                        <td><label class="miLabel">Configuracion:</label> </td>
                    </tr>
                    <tr>
                        <td><label class="miLabel">Severidad:</label></td>
                    </tr>
                    <tr>
                        <td><input id="txtServ_Descrip" type="text" class="txt" style="width:100%;" /></td>
                    </tr>
                    <tr>
                        <td><label class="labelError" id="lblErrorSeveridad">&nbsp;</label></td>
                    </tr>
                    <tr>
                        <td><input id="btnGrabarSeveridad" type="button" class="submit" value="Grabar"/>&nbsp;&nbsp;
                        <input id="btnCancelSeveridad" type="button" class="submit" value="Cancelar" />&nbsp;&nbsp;
                        <input id="btnDeleteSeveridad" type="button" class="submit" value="Eliminar" /></td>
                    </tr>
                    <tr>
                        <td>                        
                            </td>
                    </tr>
                </table>

            </fieldset>
        
        </td>
    </tr>


    <tr>
        <td>
        <fieldset style="width:95%;">
                <legend><label class="miTituloField">TIPO</label></legend>
                <table style="width:100%;">
                    <tr>
                        <td rowspan="6" style="width:153px;">
                            <select id="lbTipo" size="10" style="width:150px;">
                                <option value="01">Sin Lesion</option>
  
                            </select>
                        </td>
                        <td><label class="miLabel">Configuracion:</label> </td>
                    </tr>
                    <tr>
                        <td><label class="miLabel">Tipo :</label></td>
                    </tr>
                    <tr>
                        <td><input id="txtDescripTipo" type="text" class="txt" style="width:100%;" /></td>
                    </tr>
                    <tr>
                        <td><label class="labelError" id="lblErrorTipo">&nbsp;</label></td>
                    </tr>
                    <tr>
                        <td><input id="btnAddTipo" type="button" class="submit" value="Grabar"/>&nbsp;&nbsp;
                        <input id="btnCancelTipo" type="button" class="submit" value="Cancelar" />&nbsp;&nbsp;
                        <input id="btnDeleteTipo" type="button" class="submit" value="Eliminar" /></td>
                    </tr>
                    <tr>
                        <td>                        
                            </td>
                    </tr>
                </table>

            </fieldset>       
        </td>
        <td>
<fieldset style="width:95%;">
                <legend><label class="miTituloField">ORIGEN</label></legend>
                <table style="width:100%;">
                    <tr>
                        <td rowspan="6" style="width:153px;">
                            <select id="lbOrigen" size="10" style="width:150px;">
                                <option value="01">Sin Lesion</option>
  
                            </select>
                        </td>
                        <td><label class="miLabel">Configuracion:</label> </td>
                    </tr>
                    <tr>
                        <td><label class="miLabel">Origen :</label></td>
                    </tr>
                    <tr>
                        <td><input id="txtDescripOrigen" type="text" class="txt" style="width:100%;" /></td>
                    </tr>
                    <tr>
                        <td><label class="labelError" id="lblErrorOrigen">&nbsp;</label></td>
                    </tr>
                    <tr>
                        <td><input id="btnAddOrigen" type="button" class="submit" value="Grabar"/>&nbsp;&nbsp;
                        <input id="btnCancelOrigen" type="button" class="submit" value="Cancelar" />&nbsp;&nbsp;
                        <input id="btnDeleteOrigen" type="button" class="submit" value="Eliminar" /></td>
                    </tr>
                    <tr>
                        <td>                        
                            </td>
                    </tr>
                </table>

            </fieldset> 
        </td>
    </tr>
    <tr>
        <td>
            <fieldset style="width:95%;">
                <legend><label class="miTituloField">MENSAJES ALERTA</label></legend>
                <table>
                    <tr>
                        <td><label class="miLabel">NO SE ENVIAN</label><br />
                            <ul id="listInstensidad_Out" class="droptrue">
                                <li id="">Sin Lesion</li>
                                <li>Lesion Leve</li>
                                <li>Lesion Grave</li>
                                <li>Lesion Fatal</li>
                            </ul>
                        </td>
                        <td>>></td>
                        <td><label class="miLabel">SE ENVIAN</label><br />
                            <ul id="listMensajeGere" class="droptrue">

                            </ul>
                        </td>
                        <td></td>
                        <td><input id="btnGrabarAlerta" type="button" class="submit" value="Grabar" /> <input id="btnCancelAlerta" type="button" class="submit" value="Cancelar" /></td>
                    </tr>
                </table>
                

            </fieldset>
        </td>
        <td style="vertical-align:top;">
            <fieldset style="width:95%;">
                <legend><label class="miTituloField">ENVIO DE CORREOS</label></legend>                
                <table style="width:100%;">
                    <tr>
                        <td style="width:130px;text-align:right;"><label class="miLabel">Correo Osigermin : </label></td>
                        <td><input type="email" class="txt" style="width:99%;text-transform:none;" id="txtCorreoOsigermin" /></td>
                        <td><input type="button" class="submit" value="GRABAR" id="btnGrabarOsiger" /></td>
                    </tr>
                    <tr>
                        <td style="width:130px;text-align:right;"><label class="miLabel">Mi Correo (CC) : </label></td>
                        <td><input type="email" class="txt" style="width:99%;text-transform:none;" id="txtMiCorreo" /></td>
                        <td><input type="button" class="submit" value="GRABAR" id="btnMiCorreo" /></td>
                    </tr>
                    <tr>
                        <td style="width:130px;text-align:right;"><label class="miLabel">Cuenta de Correo : </label></td>
                        <td><input type="email" class="txt" style="width:99%;text-transform:none;" id="txtCuentaEmail" /></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="width:130px;text-align:right;"><label class="miLabel">Password : </label></td>
                        <td><input type="password" class="txt" style="width:99%;text-transform:none;" id="txtCuentaPassword" /></td>
                        <td><input type="button" class="submit" value="GRABAR" id="btnSaveCuenta" /></td>
                    </tr>
                </table>
            </fieldset>        
        </td>
    </tr>
    <tr>
        <td style="vertical-align:top;">
            <fieldset style="width:95%;">
                <legend><label class="miTituloField">TEXTO ADICIONAL - CORREOS</label></legend>
                <table style="width:100%;">
                    <tr>
                        <td><label class="miLabel">Para los Gerentes:</label></td>
                        <td style="text-align:right;"><input type="button" class="submit" value="Grabar" id="btnSaveTextGerencia" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <textarea rows="3" cols="30" style="width:100%;" maxlength="2000" id="txtContenidoGerencia"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td><label class="miLabel">Para los Responsables:</label></td>
                        <td style="text-align:right;"><input type="button" class="submit" value="Grabar" id="btnSaveTextResponsable" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <textarea rows="3" cols="30" style="width:100%;" maxlength="2000" id="txtContenidoResponsable"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td><label class="miLabel">Para los Administradores:</label></td>
                        <td style="text-align:right;"><input type="button" class="submit" value="Grabar" id="btnSaveTextAdmin"/></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <textarea rows="3" cols="30" style="width:100%;" maxlength="2000" id="txtContenidoAdmin"></textarea>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </td>
        <td style="vertical-align:top;"></td>
    </tr>
</table>
<br /><br /><br /><br /><br />
    <script src="../../jquery1.10/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Script_ConfigReporte.js" type="text/javascript"></script>
    <script type="text/javascript">
        var PROCESO_INT = '01', PROCESO_SEV = '01', PROCESO_TIP = '01', PROCESO_ORI = '01';
        var Intensidad_Proc = '', Severidad_Proc = '', Tipo_Proc = '', Origen_Proc = '';
        $(document).ready(function () {

            $("ul.droptrue").sortable({
                connectWith: "ul"
            });

            $("#listInstensidad, #sortable2, #sortable3").disableSelection();
            Get_Intensidad_List();
            Get_Severidad_List();

            Get_Intensidad_Out_List();
            Get_Intensidad_In_List();

            Get_Tipo_List();
            Get_Origen_List();
            Get_Paramentros_All();
            $('#lbIntensidad').change(function () {
                var optionVal = $('#lbIntensidad option:selected').val();
                var optionText = $('#lbIntensidad option:selected').text();
                $('#txtInte_Descrip').val(optionText);
                Intensidad_Proc = optionVal;
                PROCESO_INT = '02';
            });

            $('#btnGrabarIntensidad').click(function () {
                $('#lblErrorIntensidad').html('&nbsp;');
                if (!PROCESO_INT) {
                    $('#lblErrorIntensidad').html('.::Error, Proceso no identificado.');
                    return false;
                }
                var Descripcion = $('#txtInte_Descrip').val();
                if (!Descripcion) {
                    $('#lblErrorIntensidad').html('.::Error, Descripcion no definida.');
                    $('#txtInte_Descrip').focus();
                    return false;
                }
                if (PROCESO_INT == '01') {
                    Get_Add_Intensidad(Descripcion.toUpperCase());
                } else if (PROCESO_INT == '02') {
                    if (!Intensidad_Proc) {
                        $('#lblErrorIntensidad').html('.::Error, Intensidad no identificada.');
                        return false;
                    }
                    Get_Update_Intensidad(Intensidad_Proc, Descripcion.toUpperCase());
                }
            });
            $('#btnCancelIntensidad').click(function () {
                PROCESO_INT = '01';
                Intensidad_Proc = '';
                $('#txtInte_Descrip').val('');
                $('#lblErrorIntensidad').html('&nbsp;');
                $('#lbIntensidad').children().removeAttr('selected');
            });
            $('#btnDeleteIntensidad').click(function () {
                $('#lblErrorIntensidad').html('&nbsp;');
                if (!Intensidad_Proc) {
                    $('#lblErrorIntensidad').html('.::Error, Intensidad no identificada.');
                    return false;
                }
                if (confirm('¿Esta seguro de continuar?')) {
                    Get_Delete_Intensidad(Intensidad_Proc);
                }
            });

            //SEVERIDAD-------------------------

            $('#lbSeveridad').change(function () {
                var optionVal = $('#lbSeveridad option:selected').val();
                var optionText = $('#lbSeveridad option:selected').text();
                $('#txtServ_Descrip').val(optionText);
                Severidad_Proc = optionVal;
                PROCESO_SEV = '02';
            });

            $('#btnGrabarSeveridad').click(function () {
                $('#lblErrorSeveridad').html('&nbsp;');
                if (!PROCESO_SEV) {
                    $('#lblErrorSeveridad').html('.::Error, Proceso no identificado.');
                    return false;
                }
                var Descripcion = $('#txtServ_Descrip').val();
                if (!Descripcion) {
                    $('#lblErrorSeveridad').html('.::Error, Descripcion no definida.');
                    $('#txtServ_Descrip').focus();
                    return false;
                }
                if (PROCESO_SEV == '01') {
                    Get_Add_Severidad(Descripcion.toUpperCase());
                } else if (PROCESO_SEV == '02') {
                    if (!Severidad_Proc) {
                        $('#lblErrorSeveridad').html('.::Error, Severidad no identificada.');
                        return false;
                    }
                    Get_Update_Severidad(Severidad_Proc, Descripcion.toUpperCase());
                }
            });
            $('#btnCancelSeveridad').click(function () {
                PROCESO_SEV = '01';
                Severidad_Proc = '';
                $('#txtServ_Descrip').val('');
                $('#lblErrorSeveridad').html('&nbsp;');
                $('#lbSeveridad').children().removeAttr('selected');
            });
            $('#btnDeleteSeveridad').click(function () {
                $('#lblErrorSeveridad').html('&nbsp;');
                if (!Severidad_Proc) {
                    $('#lblErrorSeveridad').html('.::Error, Intensidad no identificada.');
                    return false;
                }
                if (confirm('¿Esta seguro de continuar?')) {
                    Get_Delete_Severidad(Severidad_Proc);
                }
            });


            //ALERTA A GERENTES

            $('#btnGrabarAlerta').click(function () {

                Get_Clear_AlertGeren();
                $('#listMensajeGere li').each(function () {
                    var id = this.id;
                    Get_Intensidad_Add_Alert(id);
                });
                alert('Actualizado Correctamente.');
                Get_Intensidad_Out_List();
                Get_Intensidad_In_List();
            });
            $('#btnCancelAlerta').click(function () {
                Get_Intensidad_Out_List();
                Get_Intensidad_In_List();
            });


            //CORREO A OSIGERMIN

            $('#btnGrabarOsiger').click(function () {
                var correo = $('#txtCorreoOsigermin').val();
                if (!correo) {
                    alert('.::Error, Correo a osigermin no definido.')
                    return false;
                }
                Get_GrabarCorreo_Osigermin(correo);

            });

            //MI CORREO

            $('#btnMiCorreo').click(function () {
                var correo = $('#txtMiCorreo').val();
                /*if (!correo) {
                    alert('.::Error, Mi Correo no definido.')
                    return false;
                }*/
                Get_Grabar_MiCorreo(correo);
            });

            //TIPO -----------------------

            $('#lbTipo').change(function () {
                var optionVal = $('#lbTipo option:selected').val();
                var optionText = $('#lbTipo option:selected').text();
                $('#txtDescripTipo').val(optionText);
                Tipo_Proc = optionVal;
                PROCESO_TIP = '02';
            });

            $('#btnAddTipo').click(function () {
                $('#lblErrorTipo').html('&nbsp;');
                if (!PROCESO_TIP) {
                    $('#lblErrorTipo').html('.::Error, Proceso no identificado.');
                    return false;
                }
                var Descripcion = $('#txtDescripTipo').val();
                if (!Descripcion) {
                    $('#lblErrorTipo').html('.::Error, Descripcion no definida.');
                    $('#txtDescripTipo').focus();
                    return false;
                }
                if (PROCESO_TIP == '01') {
                    Get_Add_Tipo(Descripcion.toUpperCase());
                } else if (PROCESO_TIP == '02') {
                    if (!Tipo_Proc) {
                        $('#lblErrorTipo').html('.::Error, Tipo no identificada.');
                        return false;
                    }
                    Get_Update_Tipo(Tipo_Proc, Descripcion.toUpperCase());
                }
            });
            $('#btnCancelTipo').click(function () {
                PROCESO_TIP = '01';
                Tipo_Proc = '';
                $('#txtDescripTipo').val('');
                $('#lblErrorTipo').html('&nbsp;');
                $('#lbTipo').children().removeAttr('selected');
            });
            $('#btnDeleteTipo').click(function () {
                $('#lblErrorTipo').html('&nbsp;');
                if (!Tipo_Proc) {
                    $('#lblErrorTipo').html('.::Error, Tipo no identificado.');
                    return false;
                }
                if (confirm('¿Esta seguro de continuar?')) {
                    Get_Delete_Tipo(Tipo_Proc);
                }
            });


            //ORIGEN -----------------------

            $('#lbOrigen').change(function () {
                var optionVal = $('#lbOrigen option:selected').val();
                var optionText = $('#lbOrigen option:selected').text();
                $('#txtDescripOrigen').val(optionText);
                Origen_Proc = optionVal;
                PROCESO_ORI = '02';
            });

            $('#btnAddOrigen').click(function () {
                $('#lblErrorOrigen').html('&nbsp;');
                if (!PROCESO_ORI) {
                    $('#lblErrorOrigen').html('.::Error, Proceso no identificado.');
                    return false;
                }
                var Descripcion = $('#txtDescripOrigen').val();
                if (!Descripcion) {
                    $('#lblErrorOrigen').html('.::Error, Origen no definido.');
                    $('#txtDescripOrigen').focus();
                    return false;
                }
                if (PROCESO_ORI == '01') {
                    Get_Add_Origen(Descripcion.toUpperCase());
                } else if (PROCESO_ORI == '02') {
                    if (!Origen_Proc) {
                        $('#lblErrorOrigen').html('.::Error, Origen no identificado.');
                        return false;
                    }
                    Get_Update_Origen(Origen_Proc, Descripcion.toUpperCase());
                }
            });
            $('#btnCancelOrigen').click(function () {
                PROCESO_ORI = '01';
                Origen_Proc = '';
                $('#txtDescripOrigen').val('');
                $('#lblErrorOrigen').html('&nbsp;');
                $('#lbOrigen').children().removeAttr('selected');
            });
            $('#btnDeleteOrigen').click(function () {
                $('#lblErrorOrigen').html('&nbsp;');
                if (!Origen_Proc) {
                    $('#lblErrorOrigen').html('.::Error, Origen no identificado.');
                    return false;
                }
                if (confirm('¿Esta seguro de continuar?')) {
                    Get_Delete_Origen(Origen_Proc);
                }
            });


            //CUENTA DE CORREO

            $('#btnSaveCuenta').click(function () {
                var Cuenta = $('#txtCuentaEmail').val();
                var contras = $('#txtCuentaPassword').val();
                if (!Cuenta) {
                    alert('.::Error, Cuenta de correo no definida.')
                    return false;
                }
                if (!contras) {
                    alert('.::Error, Contraseña de la cuenta no definida.')
                    return false;
                }
                Get_Cofig_Cuenta_Correo(Cuenta, contras);
            });

            //CONTENIDO

            $('#btnSaveTextGerencia').click(function () {
                var contenido = $('#txtContenidoGerencia').val();
                Get_ParaGerentes(contenido);
            });

            $('#btnSaveTextResponsable').click(function () {
                var contenido = $('#txtContenidoResponsable').val();
                Get_ParaResponsables(contenido);
            });


            $('#btnSaveTextAdmin').click(function () {
                var contenido = $('#txtContenidoAdmin').val();
                Get_ParaAdministracion(contenido);
            });


        });
    
    </script>
</asp:Content>