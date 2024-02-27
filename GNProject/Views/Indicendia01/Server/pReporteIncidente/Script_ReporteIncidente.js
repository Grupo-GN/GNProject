function Get_Codigo_Generado() {

    $.ajax({
        type: "POST",

        dataType: "json",
        url: "sReporteIncidente.aspx/Get_Codigo_Generado",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            codigoGenerado = response.d;
            //$('#lblCodigoGen').html('CODSIS ' + codigoGenerado);
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};


function DatosDelUsuario() {
    var UsLog = Session.get('Usuario');
    if (UsLog) {
        $('#txtResponsable').val(UsLog.Nombres + ', ' + UsLog.Apellido_Paterno + ' ' + UsLog.Apellido_Materno);

        Get_LocalidadyArea(UsLog.Area_Id,'');
        $('#cboCategoriaAuxiliar').val(UsLog.Categoria_Auxiliar_Id);
        Get_Categoria_Auxiliar2_Combo();
        $('#cboCategoriaAuxiliar2').val(UsLog.Categoria_Auxiliar2_Id);
        $('#cboLocalidad').val(UsLog.Area_Id);
        $('#lblLocalidadUs').html($("#cboLocalidad option:selected").text());
    }
};



function Get_LocalidadyArea(Area_Id, Area_Id2) {
    var params = {
        Area_Id: Area_Id,
        Area_Id2: Area_Id2
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sReporteIncidente.aspx/Get_LocalidadyArea",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var dato=response.d;
            $('#lblLocalidad').html(dato);
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};



function Get_Acciones_List() {
    var lengthD=Acciones.length -1;
    $('#tbodyAcciones').html('');
    for (var i = 0; i <= lengthD; i++) {
        var html = '<tr>';

        html += '<td style="width:35%;" class="tdTableRe">' + Acciones[i].Descripcion + '</td>';
        html += '<td style="width:35%;" class="tdTableRe">' + Acciones[i].Responsable_Name + '</td>';
        html += '<td style="width:13%;text-align:center;" class="tdTableRe">' + Acciones[i].FechaIni + '</td>';
        html += '<td style="width:13%;text-align:center;" class="tdTableRe">' + Acciones[i].FechaFin + '</td>';
        html += '<td style="text-align:center;" class="tdTableRe"><input id="' + Acciones[i].id + '" type="button" class="deleteAcc" /></td>';
           
            html += '</tr>';
            $(html).appendTo('#tbodyAcciones');
        }
};



function Grabar_Reporte_de_Incidencia() {

   

    if (!UsuarioLogin) {
        alert('.::Error, El usuario no reconocido.');
        return false;
    }

    var Area_Id = $('#cboLocalidad').val();
    var ActividadPropia=$('input[name=rdActPT]:checked').val();
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


    if (!Area_Id) {
        alert('.::Error, Localidad no definida');
        $('#cboLocalidad').focus();
        return false;
    }


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
    }


    if (!AfecInc) {
        alert('.::Error, Tipo de afectado en el reporte no definido.');
        $('#cboAfectadoInc').focus();
        return false;
    }

    if (!Lesiones) {
        alert('.::Error, Redacté las lesiones personales.');
        $('#txtLesiones').focus();   
        return false;
    }
     if (!DañosMat) {
        alert('.::Error, Redacté los daños materiales.');
        $('#txtDañosMat').focus();  
        return false;
    }
    
    if (!AccInmediata) {
        alert('.::Error, Redacté la acción inmediata.');
        $('#txtAccionInmediata').focus();  
        return false;
    }

    if (Acciones.length <= 0) {
        alert('.::Error, No se encontro alguna Acción Correctiva - Preventiva.');        
        return false;
    }
    if (CausasBa <= 0) {
        alert('.::Error, No se encontro alguna causa básica definida.');
        return false;
    }
    if (CausasIn <= 0) {
        alert('.::Error, No se encontro alguna causa inmediata definida.');
        return false;
    }



    var informarGerencia = Get_Informar_Gerencia(Intensidad_Id);
    var existegerencia = true;
    if (informarGerencia == '01') {
        existegerencia = Get_Correos_Gerencia(UsuarioLogin.Area_Id);
    }
    if (!existegerencia) {
        alert('.::Error, No se encontro a ningun Gerente.');
        return false;
    }
    var FechayHora = formatFecha.ymd(FechaIncidente) + ' ' + $('#cboHoraInc').val() + ':' + $('#cboMinInc').val();

    var cat1=$('#cboCategoriaAuxiliar').val();
    var cat2 = $('#cboCategoriaAuxiliar2').val();

    Registrar_ReporteIncidencia(
       UsuarioLogin.Personal_Id
    , Area_Id
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
    , codigoGenerado
    , TipoInc
    , AfecInc);




};


function Registrar_ReporteIncidencia(
              Personal_Registro
            , Area_Id
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
            , Generado_Id
            , TipoI_Id
            , Afec_Id) {
    var params = {
        Personal_Registro: Personal_Registro,
        Area_Id: Area_Id,
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
        Generado_Id: Generado_Id,
        TipoI_Id: TipoI_Id,
        Afec_Id: Afec_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sReporteIncidente.aspx/Registrar_ReporteIncidencia",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {

                        var Incidencia_Id = Proceso.split('#')[2];
                        if (Incidencia_Id) {
                            window.onbeforeunload = null;
                            window.onunload = null;
                            var lengthD = Acciones.length - 1;
                            for (var i = 0; i <= lengthD; i++) {
                                Add_Accion_Correctiva(Incidencia_Id, Acciones[i].Descripcion, '01'
                                , Acciones[i].Responsable_Id, formatFecha.ymd(Acciones[i].FechaIni), formatFecha.ymd(Acciones[i].FechaFin))
                            }
                           
                            var mensajeAdmi = EnviarCorreo_Administradores(Incidencia_Id);
                            alert(mensaje + '. ' + mensajeAdmi);
                            window.setTimeout("location.href='../Inicio/InicioSis.aspx'", 50);

                        }
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



function EnviarCorreoGerencia_RegistroReporte(Intensidad_Id) {
/*
    var mensaje = 'Informar a Gerencia : ';
    var params = {
        Intensidad_Id: Intensidad_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sReporteIncidente.aspx/EnviarCorreoGerencia_RegistroReporte",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            mensaje += response.d;
        },
        error:
        function (XmlHttpError, error, description) {
            $("#divError").html(XmlHttpError.responseText);
        },
        async: false
    });
    return mensaje;*/

};

function EnviarCorreo_Administradores(Intensidad_Id) {

    var mensaje = 'Informar a Administracion : ';
    var params = {
        Intensidad_Id: Intensidad_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sReporteIncidente.aspx/Get_SendCorreo_Administradores",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            mensaje += response.d;
        },
        error:
        function (XmlHttpError, error, description) {
            $("#divError").html(XmlHttpError.responseText);
        },
        async: false
    });
    return mensaje;

};


function Add_Accion_Correctiva(Incidente_Id, Descripcion, Tipo_Responsable, Responsable_Id, FechaIni, FechaFin) {

    var params = {
        Incidente_Id: Incidente_Id,
        Descripcion: Descripcion,
        Tipo_Responsable: Tipo_Responsable,
        Responsable_Id: Responsable_Id,
        FechaIni: FechaIni,
        FechaFin: FechaFin
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sReporteIncidente.aspx/Add_Accion_Correctiva",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
           
        },
        error:
        function (XmlHttpError, error, description) {
            $("#divError").html(XmlHttpError.responseText);
        },
        async: false
    });

};




function Get_Informar_Gerencia(Intensidad_Id) {
    var Infor='';
    
    var params = {
        Intensidad_Id: Intensidad_Id
    };
    
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sReporteIncidente.aspx/Get_Informar_Gerencia",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;            
            if(Proceso){
                Infor='01';
            }else{
                Infor='02';
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



function Get_Correos_Gerencia(Area_Id) {
    var Infor = '';

    var params = {
        Area_Id: Area_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sReporteIncidente.aspx/Get_Correos_Gerencia",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            Infor = response.d;
           
        },
        error:
        function (XmlHttpError, error, description) {
            $("#divError").html(XmlHttpError.responseText);
        },
        async: false
    });
    return Infor;
};



function Cancelar_Reportes(Generado_Id) {
    var params = {
        Generado_Id: Generado_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sReporteIncidente.aspx/Eliminar_Datos_Generados_Cancel",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            window.onbeforeunload = null;

            window.onunload = null;
            setTimeout("location.href='../Inicio/InicioSis.aspx'", 5);
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
        url: "sReporteIncidente.aspx/Get_Add_CausaReporte_Detalle",
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
        url: "sReporteIncidente.aspx/Get_Delete_CausaReporte_Detalle",
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
        url: "sReporteIncidente.aspx/Get_Reg_CausaReporte_Detalle_List",
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
                    html += '<td style="width:48%;">' + Datos[i].Descripcion + '</td>';
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
                    html += '<td style="width:48%;">' + Datos[i].Descripcion + '</td>';
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