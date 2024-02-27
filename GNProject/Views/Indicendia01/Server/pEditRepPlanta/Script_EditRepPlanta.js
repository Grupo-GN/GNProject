





function Get_LocalidadyArea(Area_Id, Area_Id2) {
    var params = {
        Area_Id: Area_Id,
        Area_Id2: Area_Id2
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditRepPlanta.aspx/Get_LocalidadyArea",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var dato = response.d;
            $('#lblLocalidad').html(dato);
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};





function Actualizar_Reporte_de_Incidencia() {


    var ActividadPropia = $('input[name=rdActPT]:checked').val();
    var ActividadRutinaria = $('input[name=rdActRU]:checked').val();
    var Intensidad_Id = $('#cboIntensidad').val();
    var Descripcion = $('#txtDescripcionInc').val();
    var FechaIncidente = $('#txtFechaInc').val();
    var Lugar = $('#txtLugarInc').val();
    var Tipo = $('#cboTipo').val();
    var Origen = $('#cboOrigen').val();
    var Severidad_Id = $('#cboSeveridad').val();
    var infOsig = $('input[name=rbosiger]:checked').val();
    var Lesiones = $('#txtLesiones').val();
    var DañosMat = $('#txtDañosMat').val();
    var AccInmediata = $('#txtAccionInmediata').val();

    var TipoInc = $('#cboTipoInc').val();
    var AfecInc = $('#cboAfectadoInc').val();

    if (!ActividadPropia) {
        alert('.::Error, Actividad Propia del Tabajo [Si o No]');

        $('#tdErrorAct').css('border', '4px solid #FF7A7A');
        var targetOffset = $('#tdErrorAct').offset().top;
        $('html,body').animate({ scrollTop: targetOffset }, 1000);
        return false;
    }

    if (!ActividadRutinaria) {
        alert('.::Error, Actividad Rutinaria [Si o No]');
        $('#tdErrorActRut').css('border', '4px solid #FF7A7A');
        var targetOffset = $('#tdErrorActRut').offset().top;
        $('html,body').animate({ scrollTop: targetOffset }, 1000);

        return false;
    }



    if (!Intensidad_Id) {
        alert('.::Error, Intensidad del Daño no definida.');
        $('#cboIntensidad').focus();
        return false;
    }

    if (!Descripcion) {
        alert('.::Error, Redacté una breve descripcion del Incidente.');
        $('#txtDescripcionInc').focus();
        return false;
    }

    if (!FechaIncidente) {
        alert('.::Error, Fecha del Incidente no definido.');
        $('#txtFechaInc').focus();
        return false;
    }

    if (!TipoInc) {
        alert('.::Error, Tipo de Incidencia no definido.');
        $('#cboTipoInc').focus();
        return false;
    }

    if (!Lugar) {
        alert('.::Error, Especifique el lugar exacto de ocurrencia.');
        $('#txtLugarInc').focus();
        return false;
    }

    if (!Tipo) {
        alert('.::Error, Tipo no definido.');
        $('#cboTipo').focus();
        return false;
    }
    if (!Origen) {
        alert('.::Error, Origen no definido.');
        $('#cboOrigen').focus();
        return false;
    }
    if (!Severidad_Id) {
        alert('.::Error, Severidad no definida.');
        $('#cboSeveridad').focus();
        return false;
    }

    if (!infOsig) {
        alert('.::Error, Informar a Osigermin [SI ó NO].');
        $('#tdErrorOsig').css('border', '4px solid #FF7A7A');
        var targetOffset = $('#tdErrorOsig').offset().top;
        $('html,body').animate({ scrollTop: targetOffset }, 1000);
        return false;
    };

    if (!AfecInc) {
        alert('.::Error, Tipo de afectado en el reporte no definido.');
        $('#cboAfectadoInc').focus();
        return false;
    }

    if (!Lesiones) {
        alert('.::Error, Redacté las lesiones y perdidas.');
        $('#txtLesiones').focus();
        return false;
    };
    if (!DañosMat) {
        alert('.::Error, Redacté los daños materiales.');
        $('#txtDañosMat').focus();
        return false;
    };

    if (!AccInmediata) {
        alert('.::Error, Redacté la acción inmediata.');
        $('#txtAccionInmediata').focus();
        return false;
    };

    if (Acciones<= 0) {
        alert('.::Error, No se encontro alguna Acción Correctiva - Preventiva.');
        return false;
    };

    if (CausasBa <= 0) {
        alert('.::Error, No se encontro alguna causa básica definida.');
        return false;
    }
    if (CausasIn <= 0) {
        alert('.::Error, No se encontro alguna causa inmediata definida.');
        return false;
    }


    var informarGerencia = Get_Informar_Gerencia(Intensidad_Id);

    var FechayHora = formatFecha.ymd(FechaIncidente) + ' ' + $('#cboHoraInc').val() + ':' + $('#cboMinInc').val();

    var cat1 = $('#cboCategoriaAuxiliar').val();
    var cat2 = $('#cboCategoriaAuxiliar2').val();

    Actualizar_ReporteIncidencia(
     Incidente_Cod
    , cat1
    , cat2
    , ActividadPropia
    , ActividadRutinaria
    , Intensidad_Id
    , Descripcion.toUpperCase()
    , informarGerencia
    , infOsig
    , FechaIncidente = FechayHora
    , Lugar.toUpperCase()
    , Tipo
    , Origen
    , Severidad_Id
    , Lesiones.toUpperCase()
    , DañosMat.toUpperCase()
    , AccInmediata.toUpperCase()
    , TipoInc
    , AfecInc
    );
    
};


function Actualizar_ReporteIncidencia(
              Incidente_Id
            , Categoria_Auxiliar_Id
            , Categoria_Auxiliar2_Id
            , Actividad_Propia
            , Actividad_Rutinaria
            , Intensidad_Id
            , Descripcion
            , Informar_Gerencia
            , Informar_Osigermin
            , FechaHora_Incidente
            , Lugar_Incidente
            , Tipo
            , Origen
            , Severidad_Id
            , LesionesPerdidas
            , PosiblesCausas
            , AccionInmediata
            , TipoInc
            , AfecInc) {
    var params = {
        Incidente_Id: Incidente_Id,
        Categoria_Auxiliar_Id: Categoria_Auxiliar_Id,
        Categoria_Auxiliar2_Id: Categoria_Auxiliar2_Id,
        Actividad_Propia: Actividad_Propia,
        Actividad_Rutinaria: Actividad_Rutinaria,
        Intensidad_Id: Intensidad_Id,
        Descripcion: Descripcion,
        Informar_Gerencia: Informar_Gerencia,
        Informar_Osigermin: Informar_Osigermin,
        FechaHora_Incidente: FechaHora_Incidente,
        Lugar_Incidente: Lugar_Incidente,
        Tipo: Tipo,
        Origen: Origen,
        Severidad_Id: Severidad_Id,
        LesionesPerdidas: LesionesPerdidas,
        PosiblesCausas: PosiblesCausas,
        AccionInmediata: AccionInmediata,
        TipoInc: TipoInc,
        AfecInc: AfecInc
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditRepPlanta.aspx/Actualizar_ReporteIncidencia",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        window.setTimeout("location.href='../pListReportesPlanta/sListReportesPlanta.aspx'", 5);                        
                    } else {
                        alert(mensaje);
                    }
                }
            }



        },
        error:
        function (XmlHttpError, error, description) {
            $("#divError").html(XmlHttpError.responseText);
        },
        async: false
    });
};







function Get_Informar_Gerencia(Intensidad_Id) {
    var Infor = '';

    var params = {
        Intensidad_Id: Intensidad_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditRepPlanta.aspx/Get_Informar_Gerencia",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                Infor = '01';
            } else {
                Infor = '02';
            }
        },
        error:
        function (XmlHttpError, error, description) {
            $("#divError").html(XmlHttpError.responseText);
        },
        async: false
    });
    return Infor;
};







//ADD ACCION CORRECTIVA

function Add_Accion_Correctiva(Incidente_Id, Descripcion, Tipo_Responsable, Responsable_Id, FechaIni, FechaFin) {


    var params = {
        Incidente_Id: Incidente_Id,
        Descripcion: Descripcion.toUpperCase(),
        Tipo_Responsable: Tipo_Responsable,
        Responsable_Id: Responsable_Id,
        FechaIni: formatFecha.ymd(FechaIni),
        FechaFin: formatFecha.ymd(FechaFin)
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditRepPlanta.aspx/Add_Accion_Correctiva",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Boolean(Proceso.split('#')[0]);
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado) {
                        alert(mensaje);
                        TIPOPROCESOA = '';
                        Accion_Cod = '';
                        Get_AccionCorrectiva_List(Incidente_Id);
                        $('#dialog-Accion').dialog('close');
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
        function (XmlHttpError, error, description) {
            $("#divError").html(XmlHttpError.responseText);
        },
        async: false
    });

};

//ACTUALIZAR ACCION CORRECTIVA

function Get_Update_AccionCorrectiva(
                 Incidente_Id
               , Accion_Id
               , Descripcion
               , Tipo_Responsable
               , Responsable_Id
               , FechaIni
               , FechaFin) {
    var params = {
        Incidente_Id: Incidente_Id,
        Accion_Id: Accion_Id,
        Descripcion: Descripcion.toUpperCase(),
        Tipo_Responsable: Tipo_Responsable,
        Responsable_Id: Responsable_Id,
        FechaIni: formatFecha.ymd(FechaIni),
        FechaFin: formatFecha.ymd(FechaFin)
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditRepPlanta.aspx/Get_Update_AccionCorrectiva",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Boolean(Proceso.split('#')[0]);
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado) {
                        alert(mensaje);
                        TIPOPROCESOA = '';
                        Accion_Cod = '';
                        Get_AccionCorrectiva_List(Incidente_Id);
                        $('#dialog-Accion').dialog('close');
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};


function Get_Desechar_Accion(Incidente_Id, Accion_Id) {
    var params = {
        Incidente_Id: Incidente_Id,
        Accion_Id: Accion_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditRepPlanta.aspx/Get_Desechar_Accion",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_AccionCorrectiva_List(Incidente_Id);
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};


//CAUSAS


function Get_Add_CausaReporte_Detalle(Incidente_Id, Causa_Id, Tipo) {
    var params = {
        Incidente_Id: Incidente_Id,
        Causa_Id: Causa_Id,
        Tipo: Tipo
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditRepPlanta.aspx/Get_Add_CausaReporte_Detalle",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_Reg_CausaReporte_Detalle_List(Incidente_Id, Tipo);
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};

function Get_Delete_CausaReporte_Detalle(Incidente_Id, Causa_Id, Tipo) {
    var params = {
        Incidente_Id: Incidente_Id,
        Causa_Id: Causa_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditRepPlanta.aspx/Get_Delete_CausaReporte_Detalle",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_Reg_CausaReporte_Detalle_List(Incidente_Id, Tipo);
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Get_Reg_CausaReporte_Detalle_List(Incidente_Id, Tipo) {
    var params = {
        Incidente_Id: Incidente_Id,
        Tipo: Tipo
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditRepPlanta.aspx/Get_Reg_CausaReporte_Detalle_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            if (Tipo == '01') {
                CausasBa = 0;
                $('#tbodyCB').html('');
                for (var i = 0; i <= lengthD; i++) {
                    CausasBa += 1;
                    var html = '<tr>';
                    html += '<td style="width:40%;">' + Datos[i].Causa_Name + '</td>';
                    html += '<td style="width:60%;">' + Datos[i].Descripcion + '</td>';
                    html += '<td style="text-align:center;" class="tdTableRe"><input id="' + Datos[i].Causa_Id + '" type="button" class="deleteAcc" /></td>';
                    html += '</tr>';
                    $(html).appendTo('#tbodyCB');
                }
            } else if (Tipo = '02') {
                CausasIn = 0;
                $('#tbodyCI').html('');
                for (var i = 0; i <= lengthD; i++) {
                    CausasIn += 1;
                    var html = '<tr>';
                    html += '<td style="width:40%;">' + Datos[i].Causa_Name + '</td>';
                    html += '<td style="width:60%;">' + Datos[i].Descripcion + '</td>';
                    html += '<td style="text-align:center;" class="tdTableRe"><input id="' + Datos[i].Causa_Id + '" type="button" class="deleteAcc" /></td>';
                    html += '</tr>';
                    $(html).appendTo('#tbodyCI');
                }

            }

        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });


};


function open_Modal() {

    $('#dialog-Accion').dialog({
        autoOpen: true,
        modal: true,
        width: 700,
        height: 370,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });

};


function clearModal() {
    $('#txtResponsableFind').val('');
    $('#cboResponsable').val('');
    $('#txtAccionDescrip').val('');
    $('#txtFechaIni').val('');
    $('#txtFechaFin').val('');
};


//FECHAS

Date.prototype.addDays = function (days) {
    this.setDate(this.getDate() + days);
    return this;
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
            var arr = arr1[0].split('/');
            return arr[2] + '-' + arr[1] + '-' + arr[0];
        } else {
            var arr = fecha.split('/');
            return arr[2] + '-' + arr[1] + '-' + arr[0];
        }

    },
    dmy: function (fecha) {
        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = arr1[0].split('/');
            return arr[0] + '-' + arr[1] + '-' + arr[2];
        } else {
            var arr = fecha.split('/');
            return arr[0] + '-' + arr[1] + '-' + arr[2];
        }
    },
    dmyE: function (fecha) {

        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = arr1[0].split('/');
            return arr[0] + '/' + arr[1] + '/' + arr[2];
        } else {
            var arr = fecha.split('/');
            return arr[0] + '/' + arr[1] + '/' + arr[2];
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


function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null)
        return "";
    else
        return decodeURIComponent(results[1].replace(/\+/g, " "));
};
