function Get_Localidad_Combo() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "ListReportes.aspx/Get_Localidad_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboLocalidad').html('');
            $('#cboLocalidadFind').html('');
            $('<option value="">TODOS</option>').appendTo('#cboLocalidadFind');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Area_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboLocalidad');
                $('<option value="' + Datos[i].Area_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboLocalidadFind');
            }
            leercookies();
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};


function Get_Reportes_List_ADM(Area_Id, FechaIni, FechaFin) {
    var params = {
        Area_Id: Area_Id,
        FechaIni: formatFecha.ymd(FechaIni),
        FechaFin: formatFecha.ymd(FechaFin) + ' 23:59'
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "ListReportes.aspx/Get_Reportes_List_ADM",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#tbodyReportes').html('');
            for (var i = 0; i <= lengthD; i++) {
                var estado = Datos[i].Estado_Id;

                var infGern = Datos[i].Informar_Gerencia == '01' ? 'SI' : 'NO';
                var infOsig = Datos[i].Informar_Osigermin;

                var infosigedes = infOsig == '01' ? 'SI' : 'NO';

                var btnEdit = '<input type="button" class="buttonEdit" title="Editar Reporte" id="' + Datos[i].Incidente_Id + '" />';

                var btnOsigermin = '<input type="button" class="buttonOsiger" title="Correo a Osigermin" id="' + Datos[i].Incidente_Id + '" />';

                switch (estado) {
                    case '01': estado = 'FINALIZADO'; btnEdit = ''; break;
                    case '02': estado = ''; break;
                    case '03': estado = 'EN CURSO'; break;
                    case '04': estado = 'REPORTADO'; break;
                }

                if (infOsig == '02') {
                    btnOsigermin = '';
                } 

                var html = '<tr>';
                html += '<td>' + btnEdit + '</td>';
                html += '<td><input type="button" class="buttonDetalle" title="Ver Reporte" id="' + Datos[i].Incidente_Id + '" /></td>';
                html += '<td><input type="button" class="buttonAccionVal" title="Valida Acciones" id="' + Datos[i].Incidente_Id + '" /></td>';
                html += '<td>' + btnOsigermin + '</td>';
                html += '<td>' + Datos[i].Incidente_Id + '</td>';
                html += '<td>' + estado + '</td>';
                html += '<td  style="text-align:center;">' + Datos[i].FechaHora_Reporte.toDateFormat() + '</td>';
                html += '<td>' + Datos[i].UsuReporte + '</td>';
                html += '<td>' + Datos[i].RH_Area + '</td>';
                html += '<td>' + Datos[i].Intensidad + '</td>';
                html += '<td  style="text-align:center;">' + Datos[i].Severidad + '</td>';
                html += '<td style="text-align:center;">' + infGern + '</td>';
                html += '<td style="text-align:center;">' + infosigedes + '</td>';
                html += '<td  style="text-align:center;">' + Datos[i].FechaHora_Incidente.toDateFormat() + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyReportes');
            }
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
        url: "ListReportes.aspx/Get_AccionCorrectiva_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthd = Datos.length - 1;
            $('#tbodyAcciones').html('');
            for (var i = 0; i <= lengthd; i++) {
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
        url: "ListReportes.aspx/Get_Aprobrar_Accion",
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





function Get_Desaprobrar_Accion(Incidente_Id, Accion_Id) {
    var params = {
        Incidente_Id: Incidente_Id,
        Accion_Id: Accion_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "ListReportes.aspx/Get_Desaprobrar_Accion",
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




function Get_Estado_Reporte(Incidencia_Id) {
    var Estado = '';
    var params = {
        Incidencia_Id: Incidencia_Id
        
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "ListReportes.aspx/Get_Estado_Reporte",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            Estado = response.d;            
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
    return Estado;
};





function get_LocalidadFind() {
    return $('#cboLocalidadFind').val() == null ? '' : $('#cboLocalidadFind').val();
};

function get_FechaIniFind() {
    return $('#txtFechaIni').val();
};

function get_FechaFinFind() {
    return $('#txtFechaFin').val();
};

function open_Modal() {

    $('#dialog-Acciones').dialog({
        autoOpen: true,
        modal: true,
        width: 900,
        height: 400,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });

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

function cargarcookies() {
    var expiresdate = new Date();
    expiresdate.setHours(expiresdate.getHours() + 2);
    var cookievalue = $('#cboLocalidadFind').val();
    document.cookie = "localidad=" + cookievalue + "; expires=" + expiresdate.toUTCString() + "; path=/";
    //encodeURIComponent
    expiresdate = new Date();
    expiresdate.setHours(expiresdate.getHours() + 2);
    cookievalue = formatFecha.dmyE($('#txtFechaIni').val().toString());
    document.cookie = "fini=" + cookievalue + "; expires=" + expiresdate.toUTCString() + "; path=/";

    expiresdate = new Date();
    expiresdate.setHours(expiresdate.getHours() + 2);
    cookievalue = formatFecha.dmyE($('#txtFechaFin').val().toString());
    document.cookie = "ffin=" + cookievalue + "; expires=" + expiresdate.toUTCString() + "; path=/";
    
}
function leercookies() {

    var localidad = '', fini = '', ffin = '';
    var cdatos = document.cookie.split(';');
    for (var i = 0; i < cdatos.length; i++) {
        var nombre = cdatos[i].split('=')[0];
        switch (nombre.trim()) {
            case 'localidad': localidad = cdatos[i].split('=')[1]; break;
            case 'fini': fini = cdatos[i].split('=')[1]; break;
            case 'ffin': ffin = cdatos[i].split('=')[1]; break;
        }
    }
    if (localidad != '') $('#cboLocalidadFind').val(localidad);
    if (fini != '') $('#txtFechaIni').datepicker("setDate", fini);
    if (ffin != '') $('#txtFechaFin').datepicker("setDate", ffin);    
}