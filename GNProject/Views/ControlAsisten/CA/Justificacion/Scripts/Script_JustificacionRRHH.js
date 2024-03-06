function Get_Planilla_List() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "JustificacionRRHH.aspx/Get_Planilla_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPlanilla').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPlanilla');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function Get_Localidad_List() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "JustificacionRRHH.aspx/Get_Localidad_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboLocalidad').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboLocalidad');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboLocalidad');
            }
            $('#cboLocalidad').val('');
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });
};


function Get_Categoria_List() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "JustificacionRRHH.aspx/Get_Categoria_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoria').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboCategoria');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria2_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoria');
            }
            $('#cboCategoria').val('');
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });
};


function Get_Personal_List(Planilla_Id, Periodo, Localidad_Id, Categoria_Id) {
    var params = {
        Planilla_Id: Planilla_Id,
        Periodo: Periodo,
        Localidad_Id: Localidad_Id,
        Categoria_Id: Categoria_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionRRHH.aspx/Get_Personal_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPersonal').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Personal_Id + '">' + Data[i].Personal + '</option>').appendTo('#cboPersonal');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};

function Get_Planilla_Find() {
    return $('#cboPlanilla').val() == null ? '' : $('#cboPlanilla').val();
};

function Get_Localidad_Find() {
    return $('#cboLocalidad').val() == null ? '' : $('#cboLocalidad').val();
};
function Get_Categoria_Find() {
    return $('#cboCategoria').val() == null ? '' : $('#cboCategoria').val();
};
function Get_Personal_Find() {
    return $('#cboPersonal').val() == null ? '' : $('#cboPersonal').val();
};


/*
OTROS DATOS
*/

function Get_Periodo_Activo_Asistencia() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "JustificacionRRHH.aspx/Get_Periodo_Activo_Asistencia",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                FechaIniPer = formatFecha.ymd(Data.Date_Inicio.toDateFormat());
                FechaFinPer = formatFecha.ymd(Data.Date_Fin.toDateFormat());
                Periodo_Des = Data.Periodo;
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

};





/*     JUSTIFICACIONES      */

function Get_Justificaciones_Pendientes_Jefe(Personal_Id, FechaIni, FechaFin) {
    var params = {
        Personal_Id: Personal_Id,
        FechaIni: FechaIni,
        FechaFin: FechaFin
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionRRHH.aspx/Get_Justificaciones_Pendientes_Jefe",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthD = Data.length - 1;
            $('#tbodyJusfPend').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<tr>';
                html += '<td style="text-align:center;"><input type="button" class="buttonProcess" id="' + Data[i].Asistencia_Id + '" title="Procesar Justificación" /></td>';
                html += '<td>' + Data[i].Solicitado + '</td>';
                html += '<td>' + Data[i].Estado + '</td>';
                html += '<td>' + Data[i].Personal + '</td>';
                html += '<td>' + Data[i].Dia + '</td>';
                html += '<td style="text-align:center;">' + formatFecha.dmy(Data[i].FechaMarc) + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HIH + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HFH + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HIM + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HSM + '</td>';
                html += '<td style="text-align:center;border-bottom-style: groove; border-bottom-width: 1px; border-bottom-color: #FF0000; color: #FF0000;">' + Data[i].HIP + '</td>';
                html += '<td style="text-align:center;border-bottom-style: groove; border-bottom-width: 1px; border-bottom-color: #FF0000; color: #FF0000;">' + Data[i].HSP + '</td>';
                html += '<td style="text-align:center;">' + Data[i].THO + '</td>';
                html += '<td>' + Data[i].OBS + '</td>';
                html += '<td style="text-align:center;"><input type="checkbox" id="' + Data[i].Asistencia_Id + '" class="chkAprobarJust" /></td>';
                html += '</tr>';
                $(html).appendTo('#tbodyJusfPend');
            }
        },
        error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
        async: true
    });
};




function Get_Justiticacion_Find(Asistencia_Id) {
    var params = {
        Asistencia_Id: Asistencia_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionJefes.aspx/Get_Justiticacion_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthD = Data.length - 1;
            if (lengthD < 0) {
                alert('.::Error > No se encontro la justificación.');
            } else {
                clear_Jusfiticacion();
                window.clearInterval(hideBAING);
                window.clearInterval(hideBDING);
                window.clearInterval(hideBASAL);

                window.clearInterval(hideBDSAL);
                window.clearInterval(hideBAAING);
                window.clearInterval(hideBAASAL);


                document.getElementById('btnAproIng').disabled = false;
                document.getElementById('btnDesaproIng').disabled = false;
                document.getElementById('btnAproSal').disabled = false;
                document.getElementById('btnDesaproSal').disabled = false;

                document.getElementById('btnAAJustIng').disabled = false;
                document.getElementById('btnAAJustSal').disabled = false;

                $('#cboHoraIng').val('');
                $('#cboMinIng').val('');

                $('#cboHoraSal').val('');
                $('#cboMinSal').val('');

                for (var i = 0; i <= lengthD; i++) {
                    $('#lblPersonalJusti').html(Data[0].PersonalName);
                    $('#lblFechaJusti').html(Data[0].Fecha.toDateFormat().substring(0, 10));
                    var tipo = Data[i].Tipo;
                    if (tipo == '01') {
                        var hir = Data[i].hora_ingreso_modificado;
                        if (hir) {
                            //hir = hir.toDateFormat().substring(11, 16)
                            hir = hir.substring(11, 16)
                        }
                        $('#lblHIR').html(hir);

                        if (Data[i].NewHora) {
                            $('#cboHoraIng').val(Data[i].NewHora.substring(0, 2));
                            $('#cboMinIng').val(Data[i].NewHora.substring(3, 5));
                        } else {
                            $('#cboHoraIng').val('');
                            $('#cboMinIng').val('');
                        }
                        $('#txtMotivos').val('Ingreso : ' + Data[i].Motivo);

                        $('#btnAAJustIng').attr('name', Data[i].Justificacion_Id);
                        $('#btnAproIng').attr('name', Data[i].Justificacion_Id);
                        $('#btnDesaproIng').attr('name', Data[i].Justificacion_Id);
                        var estado = Data[i].Estado;
                        
                        if (estado == '01') {
                            hideBAING = window.setInterval("document.getElementById('btnAproIng').disabled = true; ", 1000);
                            hideBAAING = window.setInterval("document.getElementById('btnAAJustIng').disabled = true; ", 1000);
                            hideBDING = window.setInterval("document.getElementById('btnDesaproIng').disabled = true; ", 1000);
                        }
                        if (estado == '02') {
                            hideBDING = window.setInterval("document.getElementById('btnDesaproIng').disabled = true; ", 1000);
                        }

                    } else if (tipo == '02') {
                        var hsr = Data[i].hora_salida_modificado;
                        if (hsr) {
                            //hsr = hsr.toDateFormat().substring(11, 16)
                            hsr = hsr.substring(11, 16)
                        }
                        $('#lblHSR').html(hsr);
                        if (Data[i].NewHora) {
                            $('#cboHoraSal').val(Data[i].NewHora.substring(0, 2));
                            $('#cboMinSal').val(Data[i].NewHora.substring(3, 5));
                        } else {
                            $('#cboHoraSal').val('');
                            $('#cboMinSal').val('');
                        }
                        var mot = $('#txtMotivos').val();
                        $('#txtMotivos').val(mot + '\n  Salida : ' + Data[i].Motivo);

                        $('#btnAAJustSal').attr('name', Data[i].Justificacion_Id);
                        $('#btnAproSal').attr('name', Data[i].Justificacion_Id);
                        $('#btnDesaproSal').attr('name', Data[i].Justificacion_Id);
                        var estadoSal = Data[i].Estado;
                        if (estadoSal == '01') {
                            hideBASAL = window.setInterval("document.getElementById('btnAproSal').disabled = true; ", 1000);
                            hideBDSAL = window.setInterval("document.getElementById('btnDesaproSal').disabled = true; ", 1000);
                            hideBAASAL = window.setInterval("document.getElementById('btnAAJustSal').disabled = true; ", 1000);
                        }
                        if (estadoSal == '02') {
                            hideBDSAL = window.setInterval("document.getElementById('btnDesaproSal').disabled = true; ", 1000);
                        }
                    }

                    open_DialogJustificacion();
                }
            }
        },
        error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
        async: false
    });
};

function Get_AA_Justificacion(Justificacion_Id, NewHora, PersoModif) {
    var params = {
        Justificacion_Id: Justificacion_Id,
        NewHora: NewHora,
        PersoModif: PersoModif
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionRRHH.aspx/Get_AA_Justificacion",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        $('#dialog-JustPropuesta').dialog('close');
                        Get_Justificaciones_Pendientes_Jefe(Personal_Fin, FechaIniPer, FechaFinPer);
                        clear_Jusfiticacion();
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Get_AprobarDesaprobar_Justificacion(Justificacion_Id, Estado, PersoModif) {
    var params = {
        Justificacion_Id: Justificacion_Id,
        Estado: Estado,
        PersoModif: PersoModif
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionRRHH.aspx/Get_AprobarDesaprobar_Justificacion",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        $('#dialog-JustPropuesta').dialog('close');
                        Get_Justificaciones_Pendientes_Jefe(Personal_Fin, FechaIniPer, FechaFinPer);
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

};



function clear_Jusfiticacion() {
    $('#lblFechaJusti').html('');
    $('#lblHIR').html('');
    $('#lblHIP').html('');
    $('#txtMotivos').val('');
    $('#chkAHIP').prop('checked', false);
    $('#chkAHSP').prop('checked', false);
};


function open_DialogJustificacion() {
    $('#dialog-JustPropuesta').dialog({
        autoOpen: true,
        modal: true,
        width: 750,
        height: 300,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });
};




/*-----PERMISOS FECHAS----- */


function Get_Permisos_Pendientes_Personal(Personal_Id, FechaIni, FechaFin) {
    var params = {
        Personal_Id: Personal_Id,
        FechaIni: FechaIni,
        FechaFin: FechaFin
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionRRHH.aspx/Get_Permisos_Pendientes_Personal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthD = Data.length - 1;
            $('#tbodyPermisosFechas').html('');
            for (var i = 0; i <= lengthD; i++) {
                if (Data[i].Estado != '06') {



                    var estado = '';
                    switch (Data[i].Estado) {
                        case '06': estado = 'CANCELADO'; break;
                        case '05': estado = 'PENDIENTE'; break;
                        case '04': estado = 'DESAPROBADO JEFE'; break;
                        case '03': estado = 'APROBADO JEFE - PENDIENTE RRHH'; break;
                        case '02': estado = 'DESAPROBADO RRHH'; break;
                        case '01': estado = 'APROBADO RRHH'; break;
                    }

                    var fechin = Data[i].FechaIni.toDateFormat();
                    var fechfin = Data[i].FechaFin.toDateFormat();
                    var fecupda = Data[i].FechaModif;
                    if (fecupda) {
                        fecupda = formatFecha.ymd(fecupda.toDateFormat());
                    } else {
                        fecupda = '';
                    }
                    var Realiza = '';
                    switch (Data[i].TipoReg) {
                        case '01': Realiza = 'PERSONAL'; break;
                        case '02': Realiza = 'JEFE'; break;
                        case '03': Realiza = 'RRHH'; break;
                    }

                    var Descuento = '';
                    switch (Data[i].Descuento) {
                        case '01': Descuento = 'SI'; break;
                        case '02': Descuento = 'NO'; break;
                    }


                    var btnEdit = '<input type="button" class="buttonProcess" id="' + Data[i].PermisoD_Id + '" title="Editar Permiso" />';


                    switch (Data[i].Estado) {
                        case '06': btnCancel = ''; break;
                            //case '05': estado = 'PENDIENTE'; break;  
                            //case '04': estado = 'DESAPROBADO JEFE'; break;  
                            //case '03': estado = 'APROBADO JEFE - PENDIENTE RRHH'; break;  
                            //case '02': estado = 'DESAPROBADO RRHH'; break;  
                        case '01': btnEdit = ''; btnCancel = ''; break;
                    }

                    var html = '<tr>';
                    html += '<td style="text-align:center;">' + btnEdit + '</td>';
                    html += '<td>' + Data[i].Permiso + '</td>';
                    html += '<td>' + Data[i].Personal + '</td>';
                    html += '<td>' + estado + '</td>';
                    html += '<td style="text-align:center;">' + formatFecha.ymd(fechin) + '</td>';
                    html += '<td style="text-align:center;">' + formatFecha.ymd(fechfin) + '</td>';
                    html += '<td style="text-align:center;">' + Descuento + '</td>';
                    html += '<td style="text-align:center;">' + Data[i].NroDoc + '</td>';
                    html += '<td style="text-align:center;">' + fecupda + '</td>';
                    html += '</tr>';
                    $(html).appendTo('#tbodyPermisosFechas');
                }
            }
        },
        error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
        async: true
    });
};

function Get_Tipo_Permisos() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_Tipo_Permisos",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthD = Data.length - 1;
            $('#cboTPermiso').html('');
            $('#cboPermisoH').html('');

            $('#cboTPermisoJEF').html('');
            $('#cboPermisoHJEF').html('');

            $('<option value="">-SELECCIONAR-</option>').appendTo('#cboTPermiso');
            $('<option value="">-SELECCIONAR-</option>').appendTo('#cboPermisoH');
            $('<option value="">-SELECCIONAR-</option>').appendTo('#cboTPermisoJEF');
            $('<option value="">-SELECCIONAR-</option>').appendTo('#cboPermisoHJEF');

            for (var i = 0; i <= lengthD; i++) {
                if (Data[i].estado=="0") {
                    $('<option value="' + Data[i].Permiso_Id + '">' + Data[i].descripcion + '</option>').appendTo('#cboTPermiso');
                    $('<option value="' + Data[i].Permiso_Id + '">' + Data[i].descripcion + '</option>').appendTo('#cboTPermisoJEF');
                }
                if (Data[i].estado == "1") {
                    $('<option value="' + Data[i].Permiso_Id + '">' + Data[i].descripcion + '</option>').appendTo('#cboPermisoH');
                    $('<option value="' + Data[i].Permiso_Id + '">' + Data[i].descripcion + '</option>').appendTo('#cboPermisoHJEF');
                }

               
               
            }

            $('#cboTPermiso').val('');
            $('#cboPermisoH').val('');
            $('#cboTPermisoJEF').val('');
            $('#cboPermisoHJEF').val('');
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function Get_Aplica_Descuento_By_TPermiso(TPermiso_Id) {
    var apli = '';
    var params = {
        TPermiso_Id: TPermiso_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_Aplica_Descuento_By_TPermiso",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            apli = response.d;
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });
    return apli;
};

function Get_Permiso_Fechas_Find(PermisoD_Id) {
    var params = {
        PermisoD_Id: PermisoD_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_Permiso_Fechas_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso.length == 1) {
                clear_NewPermiso();
                PermisoD_Proc = PermisoD_Id;
                $('#lblPersonalJF').html(Proceso[0].PersonalName);
                $('#cboTPermiso').val(Proceso[0].TPermiso_Id);
                if (Proceso[0].Descuento == '01') {
                    $('#rdSI').prop('checked', true);
                    $('#rdNo').prop('checked', false);
                } else {
                    $('#rdSI').prop('checked', false);
                    $('#rdNo').prop('checked', true);
                }
                $('#txtFechaIni').val(formatFecha.dmy(Proceso[0].FechaIni.toDateFormat()));
                $('#txtFechaFin').val(formatFecha.dmy(Proceso[0].FechaFin.toDateFormat()));
                $('#txtNroDoc').val(Proceso[0].NroDoc);
                $('#txtMotivo').val(Proceso[0].Motivo);

                $('#txtComentJefe').val(Proceso[0].ComentariosJefe);
                $('#aFilePF').prop('href', Proceso[0].Archivo);
                open_DialogPermisosFechas();
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Get_AprobarDesaprobar_Permiso_Fechas(PermisoD_Id, Comentarios, Estado, PersoModif) {
    var params = {
        PermisoD_Id: PermisoD_Id,
        Comentarios: Comentarios,
        Estado: Estado,
        PersoModif: PersoModif
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionRRHH.aspx/Get_AprobarDesaprobar_Permiso_Fechas",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_Permisos_Pendientes_Personal(Personal_Fin, FechaIniPer, FechaFinPer);
                        clear_NewPermiso();
                        PermisoD_Proc = 0;
                        $('#dialog-PerFechas').dialog('close');
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Get_AA_Permiso_Fechas(PermisoD_Id, TPermiso_Id, FechaIni, FechaFin, Descuento, NroDoc, Comentarios, PersoModif) {
    var params = {
        PermisoD_Id: PermisoD_Id,
        TPermiso_Id: TPermiso_Id,
        FechaIni: FechaIni,
        FechaFin: FechaFin,
        Descuento: Descuento,
        NroDoc: NroDoc,
        Comentarios: Comentarios,
        PersoModif: PersoModif
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionRRHH.aspx/Get_AA_Permiso_Fechas",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_Permisos_Pendientes_Personal(Personal_Fin, FechaIniPer, FechaFinPer);
                        $('#dialog-PerFechas').dialog('close');
                        clear_NewPermiso();
                        PermisoD_Proc = 0;
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function clear_NewPermiso() {
    $('#cboTPermiso').val('');
    /*  $('#rdSI').prop('checked', false);
    $('#rdNo').prop('checked', false);*/
    $("input[type='radio'][name='aplidescuento']").prop('checked', false);
    $('#txtFechaIni').val('');
    $('#txtFechaFin').val('');
    $('#txtNroDoc').val('');
    $('#txtMotivo').val('');


    $('#lblEJefe').html('');
    $('#txtComentJefe').val('');
    $('#lblERRHH').html('');
    $('#txtComentRRHH').val('');
};

function open_DialogPermisosFechas() {
    $('#dialog-PerFechas').dialog({
        autoOpen: true,
        modal: true,
        width: 630,
        height: 410,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });
};




/*------PERMISOS HORAS-----------*/

function Get_Permisos_Horas_Pendientes_Personal(Personal_Id, FechaIni, FechaFin) {
    var params = {
        Personal_Id: Personal_Id,
        FechaIni: FechaIni,
        FechaFin: FechaFin
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionRRHH.aspx/Get_Permisos_Horas_Pendientes_Personal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthD = Data.length - 1;
            $('#tbodyPermisoHora').html('');
            for (var i = 0; i <= lengthD; i++) {
                if (Data[i].Estado != '06') {


                    var estado = '';
                    switch (Data[i].Estado) {
                        case '06': estado = 'CANCELADO'; break;
                        case '05': estado = 'PENDIENTE'; break;
                        case '04': estado = 'DESAPROBADO JEFE'; break;
                        case '03': estado = 'APROBADO JEFE - PENDIENTE RRHH'; break;
                        case '02': estado = 'DESAPROBADO RRHH'; break;
                        case '01': estado = 'APROBADO RRHH'; break;
                    }

                    var fecha = Data[i].Fecha.toDateFormat();
                    var horain = Data[i].HoraIni.toDateFormat();
                    var horafin = Data[i].HoraFin.toDateFormat();

                    var fecupda = Data[i].FechaModif;
                    if (fecupda) {
                        fecupda = formatFecha.ymd(fecupda.toDateFormat());
                    } else {
                        fecupda = '';
                    }
                    var Realiza = '';
                    switch (Data[i].TipoReg) {
                        case '01': Realiza = 'PERSONAL'; break;
                        case '02': Realiza = 'JEFE'; break;
                        case '03': Realiza = 'RRHH'; break;
                    }

                    var AproJefe = '';
                    switch (Data[i].AproJefe) {
                        case '00': AproJefe = 'PENDIENTE'; break;
                        case '01': AproJefe = 'APROBADO'; break;
                        case '02': AproJefe = 'DESAPROBADO'; break;
                    }
                    var AproRRHH = '';
                    switch (Data[i].AproRRHH) {
                        case '00': AproRRHH = 'PENDIENTE'; break;
                        case '01': AproRRHH = 'APROBADO'; break;
                        case '02': AproRRHH = 'DESAPROBADO'; break;
                    }

                    var Descuento = '';
                    switch (Data[i].Descuento) {
                        case '01': Descuento = 'SI'; break;
                        case '02': Descuento = 'NO'; break;
                    }


                    var btnEdit = '<input type="button" class="buttonProcess" id="' + Data[i].PermisoH_Id + '" title="Editar Permiso" />';

                    switch (Data[i].Estado) {
                        case '06': btnCancel = ''; break;
                            //case '05': estado = 'PENDIENTE'; break;   
                            //case '04': estado = 'DESAPROBADO JEFE'; break;   
                            //case '03': estado = 'APROBADO JEFE - PENDIENTE RRHH'; break;   
                            //case '02': estado = 'DESAPROBADO RRHH'; break;   
                        case '01': btnEdit = ''; btnCancel = ''; break;
                    }

                    var html = '<tr>';
                    html += '<td style="text-align:center;">' + btnEdit + '</td>';
                    html += '<td>' + Data[i].Permiso + '</td>';
                    html += '<td>' + Data[i].Personal + '</td>';
                    html += '<td>' + estado + '</td>';
                    html += '<td style="text-align:center;">' + formatFecha.ymd(fecha) + '</td>';
                    html += '<td style="text-align:center;">' + horain.substring(11, 16) + '</td>';
                    html += '<td style="text-align:center;">' + horafin.substring(11, 16) + '</td>';
                    html += '<td style="text-align:center;">' + Descuento + '</td>';
                    html += '</tr>';
                    $(html).appendTo('#tbodyPermisoHora');
                }
            }
        },
        error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
        async: true
    });
};




function Get_Permiso_Horas_Find(PermisoH_Id) {
    var params = {
        PermisoH_Id: PermisoH_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_Permiso_Horas_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso.length == 1) {
                //clear_NewPermisoHoras();
                PermisoH_Proc = PermisoH_Id;
                $('#lblPersonaJH').html(Proceso[0].PersonalName);
                $('#cboPermisoH').val(Proceso[0].TPermiso_Id);
                if (Proceso[0].Descuento == '01') {
                    $('#rdSiH').prop('checked', true);
                    $('#rsNoH').prop('checked', false);
                } else {
                    $('#rdSiH').prop('checked', false);
                    $('#rsNoH').prop('checked', true);
                }

                $('#txtFechaPH').val(formatFecha.dmy(Proceso[0].Fecha.toDateFormat()));
                var horaini = Proceso[0].HoraIni.toDateFormat().substring(11, 13);
                var minini = Proceso[0].HoraIni.toDateFormat().substring(14, 16);

                var horafin = Proceso[0].HoraFin.toDateFormat().substring(11, 13);
                var minfin = Proceso[0].HoraFin.toDateFormat().substring(14, 16);

                $('#cboAplicarA_PH').val(Proceso[0].fl_aplica_ingsal);

                $('#cboHIP').val(horaini);
                $('#cboMIP').val(minini);

                $('#cboHFP').val(horafin);
                $('#cboMFP').val(minfin);
                $('#txtMotivoPHora').val(Proceso[0].Motivo);

                if (Proceso[0].AproJefe == '01') {
                    $('#lblJefePH').html('SI');
                } else if (Proceso[0].AproJefe == '02') {
                    $('#lblJefePH').html('NO');
                } else {
                    $('#lblJefePH').html('PENDIENTE');
                }
                $('#txtComentJefeH').val(Proceso[0].ComentariosJefe);

                if (Proceso[0].AproRRHH == '01') {
                    $('#lblRRHHo').html('SI');
                } else if (Proceso[0].AproRRHH == '02') {
                    $('#lblRRHHo').html('NO');
                } else {
                    $('#lblRRHHo').html('PENDIENTE');
                }
                $('#txtComentRRHHHo').val(Proceso[0].ComentariosRRHH);
                $('#aFilePH').prop('href', Proceso[0].Archivo);
                open_DialogPermisosHoras();
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Get_AprobarDesaprobar_Permiso_Horas(PermisoH_Id, Comentarios, Estado, PersoModif) {
    var params = {
        PermisoH_Id: PermisoH_Id,
        Comentarios: Comentarios,
        Estado: Estado,
        PersoModif: PersoModif
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionRRHH.aspx/Get_AprobarDesaprobar_Permiso_Horas",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_Permisos_Horas_Pendientes_Personal(Personal_Fin, FechaIniPer, FechaFinPer);
                        clear_NewPermisoHoras();
                        PermisoH_Proc = 0;
                        $('#dialog-PerHoras').dialog('close');
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Get_AA_Permisos_Horas(PermisoH_Id, TPermiso_Id, Fecha, HoraIni, HoraFin, Descuento, Comentario, PersoModif, AplicarIngSal) {
    var params = {
        PermisoH_Id: PermisoH_Id,
        TPermiso_Id: TPermiso_Id,
        Fecha: Fecha,
        HoraIni: HoraIni,
        HoraFin: HoraFin,
        Descuento: Descuento,
        Comentario: Comentario,
        PersoModif: PersoModif,
        AplicarIngSal: AplicarIngSal
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionRRHH.aspx/Get_AA_Permisos_Horas",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_Permisos_Horas_Pendientes_Personal(Personal_Fin, FechaIniPer, FechaFinPer);
                        clear_NewPermisoHoras();
                        PermisoH_Proc = 0;
                        $('#dialog-PerHoras').dialog('close');
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};



function clear_NewPermisoHoras() {
    $('#cboPermisoH').val('');
    /*  $('#rdSI').prop('checked', false);
    $('#rdNo').prop('checked', false);*/
    $("input[type='radio'][name='aplidescuentoH']").prop('checked', false);
    $('#txtFechaPH').val('');

    $('#cboHIP').val('01');
    $('#cboMIP').val('00');

    $('#cboHFP').val('01');
    $('#cboMFP').val('00');

    $('#txtMotivoPHora').val('');


    $('#lblJefePH').html('');
    $('#txtComentJefeH').val('');

    $('#lblRRHHo').html('');
    $('#txtComentRRHHHo').val('');

}



function open_DialogPermisosHoras() {
    $('#dialog-PerHoras').dialog({
        autoOpen: true,
        modal: true,
        width: 600,
        height: 390,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });
};


function CrearFechas() {

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
        onClose: function (selectedDate) {
            $("#txtFechaIni").datepicker("option", "maxDate", selectedDate);
        }
    });


    $('#txtFechaIniJEF').datepicker({
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
            $("#txtFechaFinJEF").datepicker("option", "minDate", selectedDate);
        }
    });

    $('#txtFechaFinJEF').datepicker({
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
            $("#txtFechaIniJEF").datepicker("option", "maxDate", selectedDate);
        }
    });

    $('#txtFechaPH').datepicker({
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
        dateFormat: 'dd/mm/yy',
        isRTL: false

    });


    $('#txtFechaPHJEF').datepicker({
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
        dateFormat: 'dd/mm/yy',
        isRTL: false

    });
};



//--hora y min

function CargarHorasMin() {
    var htmlH = '<option value="01">01</option>';
    htmlH += '<option value="02">02</option>';
    htmlH += '<option value="03">03</option>';
    htmlH += '<option value="04">04</option>';
    htmlH += '<option value="05">05</option>';
    htmlH += '<option value="06">06</option>';
    htmlH += '<option value="07">07</option>';
    htmlH += '<option value="08">08</option>';
    htmlH += '<option value="09">09</option>';
    htmlH += '<option value="10">10</option>';
    htmlH += '<option value="11">11</option>';
    htmlH += '<option value="12">12</option>';
    htmlH += '<option value="13">13</option>';
    htmlH += '<option value="14">14</option>';
    htmlH += '<option value="15">15</option>';
    htmlH += '<option value="16">16</option>';
    htmlH += '<option value="17">17</option>';
    htmlH += '<option value="18">18</option>';
    htmlH += '<option value="19">19</option>';
    htmlH += '<option value="20">20</option>';
    htmlH += '<option value="21">21</option>';
    htmlH += '<option value="22">22</option>';
    htmlH += '<option value="23">23</option>';
    htmlH += '<option value="00">00</option>';

    $('#cboHoraIng').html('');
    $('#cboHoraSal').html('');

    $('#cboHoraIngJEF').html('');
    $('#cboHoraSalJEF').html('');


    $('#cboHIP').html('');
    $('#cboHFP').html('');

    $('#cboHIPJEF').html('');
    $('#cboHFPJEF').html('');


    $(htmlH).appendTo('#cboHoraIng');
    $(htmlH).appendTo('#cboHoraSal');

    $(htmlH).appendTo('#cboHoraIngJEF');
    $(htmlH).appendTo('#cboHoraSalJEF');

    $(htmlH).appendTo('#cboHIP');
    $(htmlH).appendTo('#cboHFP');

    $(htmlH).appendTo('#cboHIPJEF');
    $(htmlH).appendTo('#cboHFPJEF');

    var htmlM = '<option value="00">00</option>';
    htmlM += '<option value="01">01</option>';
    htmlM += '<option value="02">02</option>';
    htmlM += '<option value="03">03</option>';
    htmlM += '<option value="04">04</option>';
    htmlM += '<option value="05">05</option>';
    htmlM += '<option value="06">06</option>';
    htmlM += '<option value="07">07</option>';
    htmlM += '<option value="08">08</option>';
    htmlM += '<option value="09">09</option>';
    htmlM += '<option value="10">10</option>';
    htmlM += '<option value="11">11</option>';
    htmlM += '<option value="12">12</option>';
    htmlM += '<option value="13">13</option>';
    htmlM += '<option value="14">14</option>';
    htmlM += '<option value="15">15</option>';
    htmlM += '<option value="16">16</option>';
    htmlM += '<option value="17">17</option>';
    htmlM += '<option value="18">18</option>';
    htmlM += '<option value="19">19</option>';
    htmlM += '<option value="20">20</option>';
    htmlM += '<option value="21">21</option>';
    htmlM += '<option value="22">22</option>';
    htmlM += '<option value="23">23</option>';
    htmlM += '<option value="24">24</option>';
    htmlM += '<option value="25">25</option>';
    htmlM += '<option value="26">26</option>';
    htmlM += '<option value="27">27</option>';
    htmlM += '<option value="28">28</option>';
    htmlM += '<option value="29">29</option>';
    htmlM += '<option value="30">30</option>';
    htmlM += '<option value="31">31</option>';
    htmlM += '<option value="32">32</option>';
    htmlM += '<option value="33">33</option>';
    htmlM += '<option value="34">34</option>';
    htmlM += '<option value="35">35</option>';
    htmlM += '<option value="36">36</option>';
    htmlM += '<option value="37">37</option>';
    htmlM += '<option value="38">38</option>';
    htmlM += '<option value="39">39</option>';
    htmlM += '<option value="40">40</option>';
    htmlM += '<option value="41">41</option>';
    htmlM += '<option value="42">42</option>';
    htmlM += '<option value="43">43</option>';
    htmlM += '<option value="44">44</option>';
    htmlM += '<option value="45">45</option>';
    htmlM += '<option value="46">46</option>';
    htmlM += '<option value="47">47</option>';
    htmlM += '<option value="48">48</option>';
    htmlM += '<option value="49">49</option>';
    htmlM += '<option value="50">50</option>';
    htmlM += '<option value="51">51</option>';
    htmlM += '<option value="52">52</option>';
    htmlM += '<option value="53">53</option>';
    htmlM += '<option value="54">54</option>';
    htmlM += '<option value="55">55</option>';
    htmlM += '<option value="56">56</option>';
    htmlM += '<option value="57">57</option>';
    htmlM += '<option value="58">58</option>';
    htmlM += '<option value="59">59</option>';

    $('#cboMinIng').html('');
    $('#cboMinSal').html('');

    $('#cboMinIngJEF').html('');
    $('#cboMinSalJEF').html('');

    $('#cboMIP').html('');
    $('#cboMFP').html('');

    $('#cboMIPJEF').html('');
    $('#cboMFPJEF').html('');

    $(htmlM).appendTo('#cboMinIng');
    $(htmlM).appendTo('#cboMinSal');

    $(htmlM).appendTo('#cboMinIngJEF');
    $(htmlM).appendTo('#cboMinSalJEF');

    $(htmlM).appendTo('#cboMIP');
    $(htmlM).appendTo('#cboMFP');

    $(htmlM).appendTo('#cboMIPJEF');
    $(htmlM).appendTo('#cboMFPJEF');
};



String.prototype.toDateFormat = function () {
    if (this) {
        var dte = eval("new " + this.replace(/\//g, '') + ";");

        dte.setMinutes(dte.getMinutes() - dte.getTimezoneOffset());
        //  dateFormat(dte, "yyyy-MM-dd HH:mm:ss");
        var ret = dateDemo(dte);
        //return dte;
        return ret;
    } else {
        return '';
    }
};

function dateDemo(fecha) {
    var Dia = fecha.getUTCDate();
    var Mes = (fecha.getUTCMonth() + 1);
    var Anio = fecha.getUTCFullYear();

    Dia = Dia.toString().padLeft("0", 2);
    Mes = Mes.toString().padLeft("0", 2);

    var Hora = fecha.getUTCHours();
    Hora = Hora.toString().padLeft("0", 2);

    var Min = fecha.getUTCMinutes();
    Min = Min.toString().padLeft("0", 2);
    var fechaWPP = Dia + "/" + Mes + "/" + Anio + " " + Hora + ":" + Min;
    return fechaWPP;
};



String.prototype.padLeft = function (paddingChar, length) {

    var s = new String(this);

    if ((this.length < length) && (paddingChar.toString().length > 0)) {
        for (var i = 0; i < (length - this.length); i++)
            s = paddingChar.toString().charAt(0).concat(s);
    }

    return s;
};

var formatFecha = {
    ymd: function (fecha) {
        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = arr1[0].split('/');
                return arr[2] + '/' + arr[1] + '/' + arr[0];
            } else if (fecha.indexOf('-') != -1) {
                arr = arr1[0].split('-');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            }

        } else {
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = fecha.split('/');
                return arr[2] + '/' + arr[1] + '/' + arr[0];
            } else if (fecha.indexOf('-') != -1) {
                arr = fecha.split('-');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            }
        }

    },
    dmy: function (fecha) {
        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = arr1[0].split('/');
                return arr[0] + '/' + arr[1] + '/' + arr[2];
            } else if (fecha.indexOf('-') != -1) {
                arr = arr1[0].split('-');
                return arr[0] + '-' + arr[1] + '-' + arr[2];
            }

        } else {
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = arr1.split('/');
                return arr[0] + '/' + arr[1] + '/' + arr[2];
            } else if (fecha.indexOf('-') != -1) {
                arr = arr1.split('-');
                return arr[0] + '-' + arr[1] + '-' + arr[2];
            }
        }
    },
    ymdEN: function (fecha) {
        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = arr1[0].split('/');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            } else if (fecha.indexOf('-') != -1) {
                arr = arr1[0].split('-');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            }

        } else {
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = fecha.split('/');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            } else if (fecha.indexOf('-') != -1) {
                arr = fecha.split('-');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            }
        }

    }

};
var DateDiff = {

    inDays: function (d1, d2) {
        var t2 = d2; //.getTime();
        var t1 = d1; //.getTime();

        return parseInt(((t2 - t1) / (24 * 3600 * 1000)) + 1);
    },

    inWeeks: function (d1, d2) {
        var t2 = d2.getTime();
        var t1 = d1.getTime();
        return parseInt((t2 - t1) / (24 * 3600 * 1000 * 7));
    },

    inMonths: function (d1, d2) {
        var d1Y = d1.getFullYear();
        var d2Y = d2.getFullYear();
        var d1M = d1.getMonth();
        var d2M = d2.getMonth();

        return (d2M + 12 * d2Y) - (d1M + 12 * d1Y);
    },

    inYears: function (d1, d2) {
        return d2.getFullYear() - d1.getFullYear();
    }
};


/*-----------------GENERAR PERMISOS PARA EL PERSONAL REALIZADO POR SU JEFE-----------------------*/

function Get_Marcaciones_Malas_Personal(Personal_Id, FechaIni, FechaFin) {
    var params = {
        Personal_Id: Personal_Id,
        FechaIni: FechaIni,
        FechaFin: FechaFin
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionJefes.aspx/Get_Marcaciones_Malas_Personal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthD = Data.length - 1;
            $('#tbodyMMPersonal').html('');
            for (var i = 0; i <= lengthD; i++) {
                var FaltaDes = Data[i].Falta == 'True' ? 'Falta' : '';               
                var MinTardanza = parseInt(Data[i].MinTard) > 0 ? Data[i].MinTard + ' Min.' : '';
                var html = '<tr>';
                html += '<td style="text-align:center;"><input type="button" class="buttonEditMarc" id="' + Data[i].Asistencia_Id + '" title="Justificar Marcación" /></td>';
                html += '<td>' + Data[i].Solicitado + '</td>';
                html += '<td>' + Data[i].Estado + '</td>';
                html += '<td>' + Data[i].Realizado + '</td>';
                html += '<td>' + Data[i].Tipo + '</td>';
                html += '<td>' + Data[i].Dia + '</td>';
                html += '<td style="text-align:center;">' + formatFecha.dmy(Data[i].FechaMarc) + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HIH + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HFH + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HIM + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HSM + '</td>';
                html += '<td style="text-align:center;">' + Data[i].THO + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HES + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HEA + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HED + '</td>';
                html += '<td style="text-align:center;">' + MinTardanza + '</td>';
                html += '<td style="text-align:center;">' + FaltaDes + '</td>';
                html += '<td>' + Data[i].OBS + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyMMPersonal');
            }
        },
        error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
        async: true
    });
};


function Get_Marcaciones_Correctas_Personal(Personal_Id, FechaIni, FechaFin) {
    var params = {
        Personal_Id: Personal_Id,
        FechaIni: FechaIni,
        FechaFin: FechaFin
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionJefes.aspx/Get_Marcaciones_Correctas_Personal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthD = Data.length - 1;
            $('#tbodyMCorr').html('');
            for (var i = 0; i <= lengthD; i++) {
                var FaltaDes = Data[i].Falta == 'True' ? 'Falta' : '';
                var MinTardanza = parseInt(Data[i].MinTard) > 0 ? Data[i].MinTard + ' Min.' : '';
                var html = '<tr>';
                html += '<td style="text-align:center;"><input type="button" class="buttonEditMarc" id="' + Data[i].Asistencia_Id + '" title="Justificar Marcación" /></td>';
                html += '<td>' + Data[i].Solicitado + '</td>';
                html += '<td>' + Data[i].Estado + '</td>';
                html += '<td>' + Data[i].Realizado + '</td>';
                html += '<td>' + Data[i].Dia + '</td>';
                html += '<td style="text-align:center;">' + formatFecha.dmy(Data[i].FechaMarc) + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HIH + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HFH + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HIM + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HSM + '</td>';
                html += '<td style="text-align:center;">' + Data[i].THO + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HES + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HEA + '</td>';
                html += '<td style="text-align:center;">' + Data[i].HED + '</td>';
                html += '<td style="text-align:center;">' + MinTardanza + '</td>';
                html += '<td style="text-align:center;">' + FaltaDes + '</td>';
                html += '<td>' + Data[i].OBS + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyMCorr');
            }
        },
        error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
        async: true
    });
};





function Get_Justificacion_Find(Asistencia_Id) {
    var params = {
        Asistencia_Id: Asistencia_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_Justificacion_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {

                $('#lblInfoIngreso').html('');
                $('#tdInfIng2').css('background-color', 'transparent');

                $('#lblInfoSalida').html('');
                $('#tdInfSal2').css('background-color', 'transparent');


                $('#lblFechaJustiJEF').html(formatFecha.ymd(Data.Fecha.toDateFormat()));
                FechaProc = formatFecha.ymd(Data.Fecha.toDateFormat());
                
                if (Data.HIP) {
                    var b = Data.HIP.substring(0, 2);
                    var c = Data.HIP.substring(3, 5);
                    alert(b);
                    $('#cboHoraIngJEF').val(b);
                    $('#cboMinIngJEF').val(c);

                    var horaReal = Data.HIR;
                    if (horaReal != '') {
                        horaReal = Data.HIR.split(' ')[1].substring(0, 5);
                    }

                    switch (Data.HIE) {
                        case '06': $('#lblInfoIngreso').html('CANCELADO > H. Real: ' + horaReal); $('#tdInfIng2').css('background-color', '#FF8181'); break;
                        case '05': $('#lblInfoIngreso').html('PENDIENTE > H. Real: ' + horaReal); $('#tdInfIng2').css('background-color', '#93E4B2'); break;
                        case '04': $('#lblInfoIngreso').html('DESAPROBADO JEFE > H. Real: ' + horaReal); $('#tdInfIng2').css('background-color', '#FF8181'); break;
                        case '03': $('#lblInfoIngreso').html('APROBADO JEFE - PENDIENTE RRHH > H. Real: ' + horaReal); $('#tdInfIng2').css('background-color', '#93E4B2'); break;
                        case '02': $('#lblInfoIngreso').html('DESAPROBADO RRHH > H. Real: ' + horaReal); $('#tdInfIng2').css('background-color', '#FF8181'); break;
                        case '01': $('#lblInfoIngreso').html('APROBADO RRHH > H. Real: ' + horaReal); $('#tdInfIng2').css('background-color', '#93E4B2'); break;
                    }


                } else if (Data.HIR) {
                 
                    var a = Data.HIR.split(' ')[1];
                    var b = a.substring(0, 2);
                    var c = a.substring(3, 5);
              

                    $('#cboHoraIngJEF').val(b);
                    $('#cboMinIngJEF').val(c);
                } else {
                    $('#cboHoraIngJEF').val('');
                    $('#cboMinIngJEF').val('');
                }

                if (Data.HSP) {
                    var b = Data.HSP.substring(0, 2);
                    var c = Data.HSP.substring(3, 5);
                    $('#cboHoraSalJEF').val(b);
                    $('#cboMinSalJEF').val(c);


                    var horaRealSa = Data.HSR;
                    if (horaRealSa != '') {
                        horaRealSa = Data.HSR.split(' ')[1].substring(0, 5);
                    }

                    switch (Data.HSE) {
                        case '06': $('#lblInfoSalida').html('CANCELADO > H. Real: ' + horaRealSa); $('#tdInfSal2').css('background-color', '#FF8181'); break;
                        case '05': $('#lblInfoSalida').html('PENDIENTE > H. Real: ' + horaRealSa); $('#tdInfSal2').css('background-color', '#93E4B2'); break;
                        case '04': $('#lblInfoSalida').html('DESAPROBADO JEFE > H. Real: ' + horaRealSa); $('#tdInfSal2').css('background-color', '#FF8181'); break;
                        case '03': $('#lblInfoSalida').html('APROBADO JEFE - PENDIENTE RRHH > H. Real: ' + horaRealSa); $('#tdInfSal2').css('background-color', '#93E4B2'); break;
                        case '02': $('#lblInfoSalida').html('DESAPROBADO RRHH > H. Real: ' + horaRealSa); $('#tdInfSal2').css('background-color', '#FF8181'); break;
                        case '01': $('#lblInfoSalida').html('APROBADO RRHH > H. Real: ' + horaRealSa); $('#tdInfSal2').css('background-color', '#93E4B2'); break;
                    }


                } else if (Data.HSR) {
                    var a = Data.HSR.split(' ')[1];
                    var b = a.substring(0, 2);
                    var c = a.substring(3, 5);
                    $('#cboHoraSalJEF').val(b);
                    $('#cboMinSalJEF').val(c);
                } else {
                    $('#cboHoraSalJEF').val('');
                    $('#cboMinSalJEF').val('');
                }

                Mostivos = [];

                Mostivos.push(Data.MI);
                Mostivos.push(Data.MS);

                $('#txtMotivosJEF').val(Data.MI);

                opend_DialogJustificacion();
            }
        },
        error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
        async: false
    });
};



function Get_AM_Justificacion_Otros(Fecha, Tipo, Personal_Id, NewHora, TipoRegistro, Motivo, TipoModif, PersoModif, Estado) {
    var params = {
        Fecha: Fecha,
        Tipo: Tipo,
        Personal_Id: Personal_Id,
        NewHora: NewHora,
        TipoRegistro: TipoRegistro,
        Motivo: Motivo,
        TipoModif: TipoModif,
        PersoModif: PersoModif,
        Estado: Estado
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionJefes.aspx/Get_AM_Justificacion_Otros",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        $('#dialog-Justificacion').dialog('close');
                        Get_Marcaciones_Malas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                        Get_Marcaciones_Correctas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};



function opend_DialogJustificacion() {
    $('#dialog-Justificacion').dialog({
        autoOpen: true,
        modal: true,
        width: 600,
        height: 260,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });
};







/*============PERMISOS==========*/

function Get_Permisos_Fecha_By_Personal(Personal_Id, FechaIni, FechaFin) {
    var params = {
        Personal_Id: Personal_Id,
        FechaIni: FechaIni,
        FechaFin: FechaFin
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_Permisos_Fecha_By_Personal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthD = Data.length - 1;
            $('#tbodyPermisosJEF').html('');
            for (var i = 0; i <= lengthD; i++) {
                if (Data[i].Estado != '06') {

                    var estado = '';
                    switch (Data[i].Estado) {
                        case '06': estado = 'CANCELADO'; break;
                        case '05': estado = 'PENDIENTE'; break;
                        case '04': estado = 'DESAPROBADO JEFE'; break;
                        case '03': estado = 'APROBADO JEFE - PENDIENTE RRHH'; break;
                        case '02': estado = 'DESAPROBADO RRHH'; break;
                        case '01': estado = 'APROBADO RRHH'; break;
                    }

                    var fechin = Data[i].FechaIni.toDateFormat();
                    var fechfin = Data[i].FechaFin.toDateFormat();
                    var fecupda = Data[i].FechaModif;
                    if (fecupda) {
                        fecupda = formatFecha.ymd(fecupda.toDateFormat());
                    } else {
                        fecupda = '';
                    }
                    var Realiza = '';
                    switch (Data[i].TipoReg) {
                        case '01': Realiza = 'PERSONAL'; break;
                        case '02': Realiza = 'JEFE'; break;
                        case '03': Realiza = 'RRHH'; break;
                    }

                    var AproJefe = '';
                    switch (Data[i].AproJefe) {
                        case '00': AproJefe = 'PENDIENTE'; break;
                        case '01': AproJefe = 'APROBADO'; break;
                        case '02': AproJefe = 'DESAPROBADO'; break;
                    }
                    var AproRRHH = '';
                    switch (Data[i].AproRRHH) {
                        case '00': AproRRHH = 'PENDIENTE'; break;
                        case '01': AproRRHH = 'APROBADO'; break;
                        case '02': AproRRHH = 'DESAPROBADO'; break;
                    }

                    var Descuento = '';
                    switch (Data[i].Descuento) {
                        case '01': Descuento = 'SI'; break;
                        case '02': Realiza = 'NO'; break;
                    }


                    var btnEdit = '<input type="button" class="buttonEdit" id="' + Data[i].PermisoD_Id + '" title="Editar Permiso" />';
                    var btnCancel = '<input type="button" class="buttonDesactiva" id="' + Data[i].PermisoD_Id + '" title="Cancelar Permiso" />';

                    //switch (Data[i].Estado) {
                    //    case '06': btnCancel = ''; break;
                    //    //case '05': estado = 'PENDIENTE'; break;  
                    //    //case '04': estado = 'DESAPROBADO JEFE'; break;  
                    //    //case '03': estado = 'APROBADO JEFE - PENDIENTE RRHH'; break;  
                    //    //case '02': estado = 'DESAPROBADO RRHH'; break;  
                    //    case '01': /*btnEdit = ''; */btnCancel = ''; break;
                    //}

                    var html = '<tr>';
                    html += '<td style="text-align:center;">' + btnEdit + '</td>';
                    html += '<td style="text-align:center;">' + btnCancel + '</td>';
                    html += '<td>' + Data[i].Permiso + '</td>';
                    html += '<td>' + Realiza + '</td>';
                    html += '<td>' + estado + '</td>';
                    html += '<td style="text-align:center;">' + formatFecha.ymd(fechin) + '</td>';
                    html += '<td style="text-align:center;">' + formatFecha.ymd(fechfin) + '</td>';
                    html += '<td style="text-align:center;">' + Descuento + '</td>';
                    html += '<td style="text-align:center;">' + Data[i].NroDoc + '</td>';
                    html += '<td style="text-align:center;">' + AproJefe + '</td>';
                    html += '<td style="text-align:center;">' + AproRRHH + '</td>';
                    html += '<td style="text-align:center;">' + fecupda + '</td>';
                    html += '</tr>';
                    $(html).appendTo('#tbodyPermisosJEF');
                }
            }
        },
        error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
        async: true
    });
};



function Get_AM_Permisos_Fechas_Otros(PermisoD_Id, TPermiso_Id, Personal_ID, FechaIni, FechaFin, Descuento, TipoReg, Motivo, NroDoc,
            AproJefe, ComentariosJefe, AproRRHH, ComentariosRRHH, TipoModif, PersoModif, Estado) {
    var params = {
        PermisoD_Id: PermisoD_Id,
        TPermiso_Id: TPermiso_Id,
        Personal_ID: Personal_ID,
        FechaIni: FechaIni,
        FechaFin: FechaFin,
        Descuento: Descuento,
        TipoReg: TipoReg,
        Motivo: Motivo,
        NroDoc: NroDoc,
        AproJefe: AproJefe,
        ComentariosJefe: ComentariosJefe,
        AproRRHH: AproRRHH,
        ComentariosRRHH: ComentariosRRHH,
        TipoModif: TipoModif,
        PersoModif: PersoModif,
        Estado: Estado
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionJefes.aspx/Get_AM_Permisos_Fechas_Otros",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_Permisos_Fecha_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                        Get_Marcaciones_Malas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                        Get_Marcaciones_Correctas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                        clear_NewPermiso_JEF();
                        PermisoD_Proc = 0;
                        $('#TabContainerPerm').tabs('option', 'active', 0);
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Get_Permiso_Fechas_Find_Jef(PermisoD_Id) {
    var params = {
        PermisoD_Id: PermisoD_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_Permiso_Fechas_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso.length == 1) {
                PermisoD_Proc = PermisoD_Id;
                $('#cboTPermisoJEF').val(Proceso[0].TPermiso_Id);
                if (Proceso[0].Descuento == '01') {
                    $('#rdSIJEF').prop('checked', true);
                    $('#rdNoJEF').prop('checked', false);
                } else {
                    $('#rdSIJEF').prop('checked', false);
                    $('#rdNoJEF').prop('checked', true);
                }
                $('#txtFechaIniJEF').val(formatFecha.dmy(Proceso[0].FechaIni.toDateFormat()));
                $('#txtFechaFinJEF').val(formatFecha.dmy(Proceso[0].FechaFin.toDateFormat()));
                $('#txtNroDocJEF').val(Proceso[0].NroDoc);
                $('#txtMotivoJEF').val(Proceso[0].Motivo);

                if (Proceso[0].AproJefe == '01') {
                    $('#lblEJefe').html('SI');
                } else {
                    $('#lblEJefe').html('NO');
                }
                $('#txtComentJefeJEF').val(Proceso[0].ComentariosJefe);

                if (Proceso[0].AproRRHH == '01') {
                    $('#lblERRHH').html('SI');
                } else {
                    $('#lblERRHH').html('NO');
                }
                $('#txtComentRRHHJEF').val(Proceso[0].ComentariosRRHH);
                $('#TabContainerPerm').tabs('option', 'active', 1);

                if (Proceso[0].TPermiso_Id == '6') {
                    $('#tdDetalleVac').html('<label>Ver Detalle Vacaciones : </label><input type="button" class="buttonDetalle" id="btnDetalleVac" />');
                } else {
                    $('#tdDetalleVac').html('');
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};





function Get_Cancelar_SolicitudPermisoDias(PermisoD_Id, PersoModif) {
    var params = {
        PermisoD_Id: PermisoD_Id,
        PersoModif: PersoModif
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_Cancelar_SolicitudPermisoDias",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_Permisos_Fecha_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                        Get_Marcaciones_Malas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                        Get_Marcaciones_Correctas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                        if (PermisoD_Proc == PermisoD_Id) {
                            clear_NewPermiso_JEF();
                            PermisoD_Proc = 0;
                            $('#TabContainerPerm').tabs('option', 'active', 0);
                        }
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};





/*    PERMISOS POR HORAS */



function Get_Permisos_Horas_By_Personal(Personal_Id, FechaIni, FechaFin) {
    var params = {
        Personal_Id: Personal_Id,
        FechaIni: FechaIni,
        FechaFin: FechaFin
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_Permisos_Horas_By_Personal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthD = Data.length - 1;
            $('#tbodyPermisoHoraJEF').html('');
            for (var i = 0; i <= lengthD; i++) {

                if (Data[i].Estado !='06') {

                
                var estado = '';
                switch (Data[i].Estado) {
                    case '06': estado = 'CANCELADO'; break;
                    case '05': estado = 'PENDIENTE'; break;
                    case '04': estado = 'DESAPROBADO JEFE'; break;
                    case '03': estado = 'APROBADO JEFE - PENDIENTE RRHH'; break;
                    case '02': estado = 'DESAPROBADO RRHH'; break;
                    case '01': estado = 'APROBADO RRHH'; break;
                }

                var fecha = Data[i].Fecha;
                var horain = Data[i].HoraIni;
                var horafin = Data[i].HoraFin;

                var fecupda = Data[i].FechaModif;
                if (fecupda) {
                    fecupda = formatFecha.ymd(fecupda.toDateFormat());
                } else {
                    fecupda = '';
                }
                var Realiza = '';
                switch (Data[i].TipoReg) {
                    case '01': Realiza = 'PERSONAL'; break;
                    case '02': Realiza = 'JEFE'; break;
                    case '03': Realiza = 'RRHH'; break;
                }

                var AproJefe = '';
                switch (Data[i].AproJefe) {
                    case '00': AproJefe = 'PENDIENTE'; break;
                    case '01': AproJefe = 'APROBADO'; break;
                    case '02': AproJefe = 'DESAPROBADO'; break;
                }
                var AproRRHH = '';
                switch (Data[i].AproRRHH) {
                    case '00': AproRRHH = 'PENDIENTE'; break;
                    case '01': AproRRHH = 'APROBADO'; break;
                    case '02': AproRRHH = 'DESAPROBADO'; break;
                }

                var Descuento = '';
                switch (Data[i].Descuento) {
                    case '01': Descuento = 'SI'; break;
                    case '02': Realiza = 'NO'; break;
                }


                var btnEdit = '<input type="button" class="buttonEdit" id="' + Data[i].PermisoH_Id + '" title="Editar Permiso" />';
                var btnCancel = '<input type="button" class="buttonDesactiva" id="' + Data[i].PermisoH_Id + '" title="Cancelar Permiso" />';

                //switch (Data[i].Estado) {
                //    case '06': btnCancel = ''; break;
                //    //case '05': estado = 'PENDIENTE'; break;   
                //    //case '04': estado = 'DESAPROBADO JEFE'; break;   
                //    //case '03': estado = 'APROBADO JEFE - PENDIENTE RRHH'; break;   
                //    //case '02': estado = 'DESAPROBADO RRHH'; break;   
                //    case '01': /*btnEdit = '';*/ btnCancel = ''; break;
                //}

                var html = '<tr>';
                html += '<td style="text-align:center;">' + btnEdit + '</td>';
                html += '<td style="text-align:center;">' + btnCancel + '</td>';
                html += '<td>' + Data[i].Permiso + '</td>';
                html += '<td>' + Realiza + '</td>';
                html += '<td>' + estado + '</td>';
                html += '<td style="text-align:center;">' + formatFecha.ymd(fecha) + '</td>';
                html += '<td style="text-align:center;">' + horain.substring(11, 16) + '</td>';
                html += '<td style="text-align:center;">' + horafin.substring(11, 16) + '</td>';
                html += '<td style="text-align:center;">' + Descuento + '</td>';
                html += '<td style="text-align:center;">' + AproJefe + '</td>';
                html += '<td style="text-align:center;">' + AproRRHH + '</td>';
                html += '<td style="text-align:center;">' + fecupda + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyPermisoHoraJEF');
                }
            }
        },
        error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
        async: true
    });
};



function Get_AM_Permisos_Horas_Otros(PermisoH_Id, TPermiso_Id, Personal_ID, Fecha, HoraIni, HoraFin, Descuento, TipoReg
                , AproJefe, ComentariosJefe, AproRRHH, ComentariosRRHH, Motivo, PersoModif, TipoModif, Estado, AplicarIngSal) {
    var params = {
        PermisoH_Id: PermisoH_Id,
        TPermiso_Id: TPermiso_Id,
        Personal_ID: Personal_ID,
        Fecha: Fecha,
        HoraIni: HoraIni,
        HoraFin: HoraFin,
        Descuento: Descuento,
        TipoReg: TipoReg,
        AproJefe: AproJefe,
        ComentariosJefe: ComentariosJefe,
        AproRRHH: AproRRHH,
        ComentariosRRHH: ComentariosRRHH,
        Motivo: Motivo,
        PersoModif: PersoModif,
        TipoModif: TipoModif,
        Estado: Estado,
        AplicarIngSal: AplicarIngSal
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionJefes.aspx/Get_AM_Permisos_Horas_Otros",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_Permisos_Horas_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                        Get_Marcaciones_Malas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                        Get_Marcaciones_Correctas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                        clear_NewPermisoHoras_JEF();
                        PermisoH_Proc = 0;
                        $('#TabContainerPerm').tabs('option', 'active', 2);
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Get_Permiso_Horas_Find_Jef(PermisoH_Id) {
    var params = {
        PermisoH_Id: PermisoH_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_Permiso_Horas_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso.length == 1) {
                PermisoH_Proc = PermisoH_Id;
                $('#cboPermisoHJEF').val(Proceso[0].TPermiso_Id);
                if (Proceso[0].Descuento == '01') {
                    $('#rdSiHJEF').prop('checked', true);
                    $('#rsNoHJEF').prop('checked', false);
                } else {
                    $('#rdSiHJEF').prop('checked', false);
                    $('#rsNoHJEF').prop('checked', true);
                }
                $('#txtFechaPHJEF').val(formatFecha.dmy(Proceso[0].Fecha.toDateFormat()));

                $('#cboAplicarA_PHJEF').val(Proceso[0].fl_aplica_ingsal);

                var horaini = Proceso[0].HoraIni.toDateFormat().substring(11, 13);
                var minini = Proceso[0].HoraIni.toDateFormat().substring(14, 16);

                var horafin = Proceso[0].HoraFin.toDateFormat().substring(11, 13);
                var minfin = Proceso[0].HoraFin.toDateFormat().substring(14, 16);

                $('#cboHIPJEF').val(horaini);
                $('#cboMIPJEF').val(minini);

                $('#cboHFPJEF').val(horafin);
                $('#cboMFPJEF').val(minfin);
                $('#txtMotivoPHoraJEF').val(Proceso[0].Motivo);

                if (Proceso[0].AproJefe == '01') {
                    $('#lblJefePH').html('SI');
                } else if (Proceso[0].AproJefe == '02') {
                    $('#lblJefePH').html('NO');
                } else {
                    $('#lblJefePH').html('PENDIENTE');
                }
                $('#txtComentJefeHJEF').val(Proceso[0].ComentariosJefe);

                if (Proceso[0].AproRRHH == '01') {
                    $('#lblRRHHo').html('SI');
                } else if (Proceso[0].AproRRHH == '02') {
                    $('#lblRRHHo').html('NO');
                } else {
                    $('#lblRRHHo').html('PENDIENTE');
                }
                $('#txtComentRRHHHoJEF').val(Proceso[0].ComentariosRRHH);
                $('#TabContainerPerm').tabs('option', 'active', 3);
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Get_Cancelar_SolicitudPermisoHoras(PermisoH_Id, PersoModif) {
    var params = {
        PermisoH_Id: PermisoH_Id,
        PersoModif: PersoModif
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_Cancelar_SolicitudPermisoHoras",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_Permisos_Horas_By_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                        Get_Marcaciones_Malas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                        Get_Marcaciones_Correctas_Personal(Get_Personal_Find(), FechaIniPer, FechaFinPer);
                        if (PermisoH_Proc == PermisoH_Id) {
                            clear_NewPermisoHoras_JEF();
                            PermisoH_Proc = 0;
                            $('#TabContainerPerm').tabs('option', 'active', 2);
                        }
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};



function clear_NewPermiso_JEF() {
    $('#cboTPermisoJEF').val('');
    /*  $('#rdSI').prop('checked', false);
    $('#rdNo').prop('checked', false);*/
    $("input[type='radio'][name='aplidescuentoJEF']").prop('checked', false);
    $('#txtFechaIniJEF').val('');
    $('#txtFechaFinJEF').val('');
    $('#txtNroDocJEF').val('');
    $('#txtMotivoJEF').val('');


    $('#lblEJefe').html('');
    $('#txtComentJefeJEF').val('');
    $('#lblERRHH').html('');
    $('#txtComentRRHHJEF').val('');
};

function clear_NewPermisoHoras_JEF() {
    $('#cboPermisoHJEF').val('');
    /*  $('#rdSI').prop('checked', false);
    $('#rdNo').prop('checked', false);*/
    $("input[type='radio'][name='aplidescuentoHJEF']").prop('checked', false);
    $('#txtFechaPHJEF').val('');
    $('#cboAplicarA_PHJEF').val('');
    $('#cboHIPJEF').val('01');
    $('#cboMIPJEF').val('00');

    $('#cboHFPJEF').val('01');
    $('#cboMFPJEF').val('00');

    $('#txtMotivoPHoraJEF').val('');


    $('#lblJefePH').html('');
    $('#txtComentJefeHJEF').val('');

    $('#lblRRHHo').html('');
    $('#txtComentRRHHHoJEF').val('');

}



function open_DialogPermiso() {
    $('#dialog-Permisos').dialog({
        autoOpen: true,
        modal: true,
        width: 1000,
        height: 560,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });
};




function Get_DetalleVacaciones(Personal_Id, FechaIni, FechaFin) {
    var params = {
        Personal_Id: Personal_Id,
        FechaIni: FechaIni,
        FechaFin: FechaFin
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_DetalleVacaciones",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthD = Data.length - 1;
            $('#lblError').html('&nbsp;');
            $('#tbodyVacaciones').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<tr>';
                html += '<td>' + formatFecha.ymd(Data[i].Fecha_Ini.toDateFormat()) + '</td>';
                html += '<td>' + formatFecha.ymd(Data[i].Fecha_Fin.toDateFormat()) + '</td>';
                html += '<td>' + Data[i].Dias + '</td>';
                html += '<td>' + Data[i].Dias_Pagados + '</td>';
                html += '<td>' + Data[i].Dias_Pagados_Saldo + '</td>';
                html += '<td>' + Data[i].FechaPerIni + '</td>';
                html += '<td>' + Data[i].FechaPerFin + '</td>';
                html += '<td>' + Data[i].CantDias + '</td>';
                html += '<td>' + Data[i].DiasSaldoPermi + '</td>';
                html += '<td>' + Data[i].Mensaje + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyVacaciones')
            }
            if (lengthD < 0) {
                $('#lblError').html('.::Error > El Personal no tiene saldo suficiente.');
            }
            open_DialogVacaciones();
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function open_DialogVacaciones() {
    $('#dialog-vaciones').dialog({
        autoOpen: true,
        modal: true,
        width: 900,
        height: 400,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });
};



function Proc_AprobarJustificacion(Asistencia_Id, PersoModif) {
    var params = {
        Asistencia_Id: Asistencia_Id,
        PersoModif: PersoModif
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "JustificacionRRHH.aspx/Proc_AprobarJustificacion",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_Justificaciones_Pendientes_Jefe(Personal_Fin, FechaIniPer, FechaFinPer);
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

};
