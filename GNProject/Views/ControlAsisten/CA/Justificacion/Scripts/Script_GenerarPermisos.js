
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
            $('<option value="">-SELECCIONAR-</option>').appendTo('#cboTPermiso');
            $('<option value="">-SELECCIONAR-</option>').appendTo('#cboPermisoH');
            for (var i = 0; i <= lengthD; i++) {
                if (Data[i].estado == "0") {
                     $('<option value="' + Data[i].Permiso_Id + '">' + Data[i].descripcion + '</option>').appendTo('#cboTPermiso');
                }
             
                if (Data[i].estado == "1") {
                    $('<option value="' + Data[i].Permiso_Id + '">' + Data[i].descripcion + '</option>').appendTo('#cboPermisoH');
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
            $('#tbodyPermisos').html('');
            for (var i = 0; i <= lengthD; i++) {

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
                $(html).appendTo('#tbodyPermisos');
            }
        },
        error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
        async: true
    });
};



function Get_AM_Permisos_Fechas(PermisoD_Id, TPermiso_Id, Personal_ID, FechaIni, FechaFin, Descuento, TipoReg, Motivo, NroDoc, PersoModif) {
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
        PersoModif: PersoModif
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_AM_Permisos_Fechas",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_Permisos_Fecha_By_Personal(Personal_IdG, FechaIniPer, FechaFinPer);
                        Get_Marcaciones_Malas_Personal(Personal_IdG, FechaIniPer, FechaFinPer);
                        clear_NewPermiso();
                        var perId = Proceso.split('#')[2];
                        uploadFile_Permiso(perId, Personal_ID, '01');
                        PermisoD_Proc = 0;
                        $('#btnSubirPF').hide();
                        $('#aFilePF').hide();
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
            if (Proceso.length==1) {
                PermisoD_Proc = PermisoD_Id;
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

                if (Proceso[0].AproJefe == '01') {
                    $('#lblEJefe').html('SI');
                } else {
                    $('#lblEJefe').html('NO');
                }
                $('#txtComentJefe').val(Proceso[0].ComentariosJefe);

                if (Proceso[0].AproRRHH == '01') {
                    $('#lblERRHH').html('SI');
                } else {
                    $('#lblERRHH').html('NO');
                }
                $('#txtComentRRHH').val(Proceso[0].ComentariosRRHH);
                $('#TabContainerPerm').tabs('option', 'active', 1);


                if (Proceso[0].TPermiso_Id == '6') {
                    $('#tdDetalleVac').html('<label>Ver Detalle Vacaciones : </label><input type="button" class="buttonDetalle" id="btnDetalleVac" />');
                } else {
                    $('#tdDetalleVac').html('');
                }
                              
                $('#aFilePF').prop('href', Proceso[0].Archivo);

            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};



function Get_Aplica_Descuento_By_TPermiso(TPermiso_Id) {
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
            var Data = response.d;
            if (Data == '01') {
                $('#rdSI').prop('checked', true);
                $('#rdNo').prop('checked', false);
            } else {               
                $('#rdSI').prop('checked', false);
                $('#rdNo').prop('checked', true);
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

};


function Get_Aplica_Descuento_By_TPermisoHoras(TPermiso_Id) {
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
            var Data = response.d;
            if (Data == '01') {
                $('#rdSiH').prop('checked', true);
                $('#rsNoH').prop('checked', false);
            } else {
                $('#rdSiH').prop('checked', false);
                $('#rsNoH').prop('checked', true);
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
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
                        Get_Permisos_Fecha_By_Personal(Personal_IdG, FechaIniPer, FechaFinPer);
                        Get_Marcaciones_Malas_Personal(Personal_IdG, FechaIniPer, FechaFinPer);                        
                        if (PermisoD_Proc == PermisoD_Id) {
                            clear_NewPermiso();
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
            $('#tbodyPermisoHora').html('');
            for (var i = 0; i <= lengthD; i++) {

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
                html += '<td style="text-align:center;">' + btnCancel + '</td>';
                html += '<td>' + Data[i].Permiso + '</td>';
                html += '<td>' + Realiza + '</td>';
                html += '<td>' + estado + '</td>';
                html += '<td style="text-align:center;">' + formatFecha.ymd(fecha) + '</td>';
                html += '<td style="text-align:center;">' + horain.substring(11,16) + '</td>';
                html += '<td style="text-align:center;">' + horafin.substring(11, 16) + '</td>';
                html += '<td style="text-align:center;">' + Descuento + '</td>';
                html += '<td style="text-align:center;">' + AproJefe + '</td>';
                html += '<td style="text-align:center;">' + AproRRHH + '</td>';
                html += '<td style="text-align:center;">' + fecupda + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyPermisoHora');
            }
        },
        error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
        async: true
    });
};



function Get_AM_Permisos_Horas(PermisoH_Id, TPermiso_Id, Personal_ID, Fecha, HoraIni, HoraFin, Descuento, TipoReg, Motivo, PersoModif, AplicarIngSal) {
    var params = {
        PermisoH_Id: PermisoH_Id,
        TPermiso_Id: TPermiso_Id,
        Personal_ID: Personal_ID,
        Fecha: Fecha,
        HoraIni: HoraIni,
        HoraFin: HoraFin,
        Descuento: Descuento,
        TipoReg: TipoReg,
        Motivo: Motivo,
        PersoModif: PersoModif,
        AplicarIngSal: AplicarIngSal
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_AM_Permisos_Horas",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_Permisos_Horas_By_Personal(Personal_IdG, FechaIniPer, FechaFinPer);
                        Get_Marcaciones_Malas_Personal(Personal_IdG, FechaIniPer, FechaFinPer);
                        clear_NewPermisoHoras();
                        var codi = Proceso.split('#')[2];
                        $('#btnSubirPH').hide();
                        $('#aFilePH').hide();
                        uploadFile_Permiso(codi, Personal_IdG, '02');
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
                PermisoH_Proc = PermisoH_Id;
                $('#cboPermisoH').val(Proceso[0].TPermiso_Id);
                if (Proceso[0].Descuento == '01') {
                    $('#rdSiH').prop('checked', true);
                    $('#rsNoH').prop('checked', false);
                } else {
                    $('#rdSiH').prop('checked', false);
                    $('#rsNoH').prop('checked', true);
                }
                //$('#txtFechaPH').val(formatFecha.dmy(Proceso[0].Fecha));
                $('#txtFechaPH').val(formatFecha.dmy(Proceso[0].Fecha.toDateFormat()));
                var horaini = Proceso[0].HoraIni.substring(11, 13);
                var minini = Proceso[0].HoraIni.substring(14, 16);

                var horafin = Proceso[0].HoraFin.substring(11, 13);
                var minfin = Proceso[0].HoraFin.substring(14, 16);

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
                $('#TabContainerPerm').tabs('option', 'active', 3);

                $('#aFilePH').prop('href', Proceso[0].Archivo);
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
                        Get_Permisos_Horas_By_Personal(Personal_IdG, FechaIniPer, FechaFinPer);
                        Get_Marcaciones_Malas_Personal(Personal_IdG, FechaIniPer, FechaFinPer);
                        if (PermisoH_Proc == PermisoH_Id) {
                            clear_NewPermisoHoras();
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
                html += '<td>' +formatFecha.ymd( Data[i].Fecha_Ini.toDateFormat()) + '</td>';
                html += '<td>' +formatFecha.ymd( Data[i].Fecha_Fin.toDateFormat()) + '</td>';
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
    $('#tdDetalleVac').html('');
};

function clear_NewPermisoHoras() {
    $('#cboPermisoH').val('');
    /*  $('#rdSI').prop('checked', false);
    $('#rdNo').prop('checked', false);*/
    $("input[type='radio'][name='aplidescuentoH']").prop('checked', false);
    $('#txtFechaPH').val('');

    $('#cboAplicarA_PH').val('');

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

function open_DialogComp() {
    $('#dialog-Compensaciones').dialog({
        autoOpen: true,
        modal: true,
        width: 1000,
        height: 560,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
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
        /*minDate: -0,*/
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
        /*minDate: -0,*/
        onClose: function (selectedDate) {
            $("#txtFechaIni").datepicker("option", "maxDate", selectedDate);
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



};




function uploadFile_Permiso(Permiso_Id,Personal_Id,Tipo) {
    if (Tipo == '01') {

        var archivosF = document.getElementById("filePFecha");
        var archivoF = archivosF.files;

        for (var i = 0; i < archivoF.length; i = i + 2) {

            var xhr = new XMLHttpRequest();
            var fd = new FormData();

            fd.append('file', archivoF[i]);
            fd.append('permi', Permiso_Id);
            fd.append('perso', Personal_Id);
            fd.append('tipo', Tipo);

            xhr.open('POST', 'AjaxUploadFilePermiso.ashx/ProcessRequest', false);
            xhr.onload = function (e) {
                if (this.status == 200) {
                    var rsc = this.responseText;
                    if (rsc != '0') {                        
                        $('#aFilePF').prop('href', rsc);
                        alert('Archivo Guardado correctamente.');
                    } else {
                        alert(this.responseText);
                    }
                } else {
                    alert(this.responseText);
                }
            };

            xhr.onreadystatechange = function (oEvent) {
                if (xhr.readyState === 4) {
                    if (xhr.status === 200) {

                    } else {
                        alert("Error : " + xhr.statusText);
                    }
                }
            };

            xhr.send(fd);

        }

        document.getElementById("filePFecha").value = null;
  
    } else if (Tipo == '02') {
        var archivosH = document.getElementById("filePHora");
        var archivoH = archivosH.files;

        for (var i = 0; i < archivoH.length; i = i + 2) {

            var xhr = new XMLHttpRequest();
            var fd = new FormData();

            fd.append('file', archivoH[i]);
            fd.append('permi', Permiso_Id);
            fd.append('perso', Personal_Id);
            fd.append('tipo', Tipo);

            xhr.open('POST', 'AjaxUploadFilePermiso.ashx/ProcessRequest', false);
            xhr.onload = function (e) {
                if (this.status == 200) {
                    var rsc = this.responseText;
                    if (rsc != '0') {
                        $('#aFilePH').prop('href', rsc);
                        alert('Archivo Guardado correctamente.');
                    } else {
                        alert(this.responseText);
                    }
                } else {
                    alert(this.responseText);
                }
            };

            xhr.onreadystatechange = function (oEvent) {
                if (xhr.readyState === 4) {
                    if (xhr.status === 200) {

                    } else {
                        alert("Error : " + xhr.statusText);
                    }
                }
            };

            xhr.send(fd);

        }

        document.getElementById("filePHora").value = null;
    
    
    }
}
