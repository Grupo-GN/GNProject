/*function Get_Find_ReporteIncidente(Incidente_Id) {
    var params = {
        Incidente_Id: Incidente_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_Find_ReporteIncidente",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            for (var i = 0; i <= Datos.length - 1; i++) {

                $('#lblReporte_Id').html(Incidente_Id);
                var estadoReporte = Datos[i].Estado;
                Incidente_Cod = Incidente_Id;
                Area_Id = Datos[i].Area_Id;
                $('#lblUsuarioReg').html(Datos[i].PersonalReg);
                //$('#lblLocalidad').html('Localidad : ' + Datos[i].Localidad + ' , Área : ' + Datos[i].Cat1 + ' , Sección : ' + Datos[i].Cat2);
                $('#lblLocalidad').html(Datos[i].Localidad);
                $('#lblArea').html(Datos[i].Cat1);
                $('#lblSeccion').html(Datos[i].Cat2);
                var actPropia = Datos[i].ActProp;
                if (actPropia == '01') {
                    $('#lblActividadProp').html('SI');
                } else if (actPropia == '02') {
                    $('#lblActividadProp').html('NO');
                }

                var actRutin = Datos[i].ActRut;
                if (actRutin == '01') {
                    $('#lblActividadRut').html('SI');
                } else if (actRutin == '02') {
                    $('#lblActividadRut').html('NO');
                }

                $('#lblIntensidad').html(Datos[i].Intensidad);
                $('#txtDescripcionInc').val(Datos[i].Descripcion);
                $('#lblFechaHoraInci').html(Datos[i].FHInc.toDateFormat());
                $('#lblFechaHoraRep').html(Datos[i].FHRep.toDateFormat());
                $('#txtLugarInc').html(Datos[i].Lugar);


                $('#lblTipo').html(Datos[i].Tipo);

                $('#lblOrigen').html(Datos[i].Origen);


                $('#lblSeveridad').html(Datos[i].Severidad);
                $('#txtLesiones').val(Datos[i].LesionesPer);
                $('#txtPosCausas').val(Datos[i].PosCausas);
                $('#txtAccionInmediata').val(Datos[i].AccInmediata);

                var infoG = Datos[i].InfoGenrencia;
                if (infoG == '01') {
                    $('#lblIformarGe').html('SI');
                } else if (infoG == '02') {
                    $('#lblIformarGe').html('NO');
                }
                var infoOs = Datos[i].InfoOsigermin;

                if (infoOs == '01') {
                    $('#lblInformarOs').html('SI');
                } else if (infoOs == '02') {
                    $('#lblInformarOs').html('NO');
                }

                if (estadoReporte != '04') {
                    window.setInterval("document.getElementById('btnActualizarReporte').disabled = true", 100);
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

*/

function Get_LocalidadyArea(Area_Id, Area_Id2) {
    var params = {
        Area_Id: Area_Id,
        Area_Id2: Area_Id2
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_LocalidadyArea",
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


function Get_AccionCorrectiva_List(Incidente_Id) {
    var params = {
        Incidente_Id: Incidente_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_AccionCorrectiva_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            CantAcciones = 0;
            var Datos = response.d;
            var lengthd = Datos.length - 1;
            $('#tbodyAcciones').html('');
            for (var i = 0; i <= lengthd; i++) {
                CantAcciones += 1;
                var sttd = '';
                var esta = Datos[i].Estado_Id;

                switch (esta) {
                    case '01': sttd = 'color:#1A4600;'; break;
                    case '02': sttd = 'color:Red;'; break;
                    case '03': sttd = ''; break;
                    case '04': sttd = 'color: #FF7300'; break;
                    case '05': sttd = 'color: #1A4600'; break;
                    case '06': sttd = 'color: #007CFF'; break;
                }

                var titleD = 'Rechazar Acci&oacute;n';

                var btnAp = '<input id="' + Datos[i].Accion_Id + '" type="button" class="buttonValida" title="Validar Acci&oacute;n"/>';
                var btnDe = '<input id="' + Datos[i].Accion_Id + '" type="button" class="buttonDelete" title="' + titleD + '"/>';
                var btnEdi = '<input id="' + Datos[i].Accion_Id + '" type="button" class="buttonEdit" title="Editar Acci&oacute;n" />';
                switch (esta) {
                    case '01': btnAp = ''; break;
                    case '02': btnDe = ''; break;
                    case '04': btnAp = ''; btnDe = ''; break;
                    case '05': btnAp = ''; btnDe = ''; break;
                    case '06': btnAp = ''; btnDe = ''; break;
                }
                var estadoDes = '';
                switch (esta) {
                    case '01': estadoDes = 'APROBADO'; break;
                    case '02': estadoDes = 'DESAPROBADO'; break;
                    case '03': estadoDes = 'PENDIENTE DE REVISION'; break;
                    case '04': estadoDes = 'REVISADO Y DESAPROBADO'; break;
                    case '05': estadoDes = 'REVISADO Y APROBADO'; break;
                    case '06': estadoDes = 'PENDIENTE REVISION'; break;
                }

                var html = '<tr>';
                html += '<td class="tdTableRe" style="' + sttd + '">' + Datos[i].Descripcion + '</td>';
                html += '<td class="tdTableRe" style="' + sttd + '">' + Datos[i].ResponsableName + '</td>';
                html += '<td class="tdTableRe" style="text-align:center;width:100px;' + sttd + '">' + Datos[i].FechaIni.toDateFormat() + '</td>';
                html += '<td class="tdTableRe" style="text-align:center;width:100px;' + sttd + '">' + Datos[i].FechaFin.toDateFormat() + '</td>';
                html += '<td class="tdTableRe" style="text-align:center;width:170px;' + sttd + '">' + estadoDes + '</td>';
                html += '<td class="tdTableRe" style="text-align:center;width:25px;">' + btnAp + '</td>';
                html += '<td class="tdTableRe" style="text-align:center;width:25px;">' + btnDe + '</td>';
                html += '<td class="tdTableRe" style="text-align:center;width:25px;">' + btnEdi + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyAcciones');

            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};
function descarFile(file) {
    window.location = file;
};





//Get DataList

function Get_DataList_Responsable(Nombres, Usuario, Area_Id) {
    var params = {
        Nombres: Nombres,
        Usuario: Usuario,
        Area_Id: Area_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_DataList_Responsable",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboResponsable').html('');
            $('<option value="">-SELECCIONE-</option>').appendTo('#cboResponsable');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Personal_Id + '">' + Datos[i].Apellido_Paterno + ' ' + Datos[i].Apellido_Materno + ',' + Datos[i].Nombres + '</option>').appendTo('#cboResponsable');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};



function Get_Find_AccionCorrectiva(Incidente_Id, Accion_Id) {
    var params = {
        Incidente_Id: Incidente_Id,
        Accion_Id: Accion_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_Find_AccionCorrectiva",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            if (Datos) {
                TIPOPROCESOA = '02';
                Accion_Cod=Accion_Id;
                $('#txtResponsableFind').val('');
                $('#cboResponsable').val(Datos.Responsable_Id);
                $('#txtAccionDescrip').val(Datos.Descripcion);
                $('#txtFechaIni').datepicker("setDate", formatFecha.dmyE(Datos.FechaIni.toDateFormat()));
                $('#txtFechaFin').datepicker("setDate", formatFecha.dmyE(Datos.FechaFin.toDateFormat()));
                
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};


//APROBAR O DESAPROBAR ACCION CORRECTIVA

function Get_Aprobrar_Accion(Incidente_Id, Accion_Id) {
    var params = {
        Incidente_Id: Incidente_Id,
        Accion_Id: Accion_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_Aprobrar_Accion",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];                  
                    if (Resultado=='true') {
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





function Get_Desaprobrar_Accion(Incidente_Id, Accion_Id) {
    var params = {
        Incidente_Id: Incidente_Id,
        Accion_Id: Accion_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_Desaprobrar_Accion",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado=='true') {
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
        url: "sEditReporteIncidente.aspx/Add_Accion_Correctiva",
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
        Descripcion:Descripcion.toUpperCase(),
        Tipo_Responsable:Tipo_Responsable,
        Responsable_Id:Responsable_Id,
        FechaIni: formatFecha.ymd(FechaIni),
        FechaFin: formatFecha.ymd(FechaFin)
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_Update_AccionCorrectiva",
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



function Get_AprobarReporte(Incidente_Id) {
    var params = {
        Incidente_Id: Incidente_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_AprobarReporte",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        var url2 = "'../pListReportes/ListReportes.aspx'";
                        setTimeout("location.href=" + url2, 5);
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
        url: "sEditReporteIncidente.aspx/Get_Add_CausaReporte_Detalle",
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
        url: "sEditReporteIncidente.aspx/Get_Delete_CausaReporte_Detalle",
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
        url: "sEditReporteIncidente.aspx/Get_Reg_CausaReporte_Detalle_List",
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
