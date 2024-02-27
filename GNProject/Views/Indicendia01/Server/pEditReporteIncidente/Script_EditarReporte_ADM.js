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

    if (CantAcciones <= 0) {
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
        url: "sEditReporteIncidente.aspx/Actualizar_ReporteIncidencia",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        
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
        url: "sEditReporteIncidente.aspx/Get_Informar_Gerencia",
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
