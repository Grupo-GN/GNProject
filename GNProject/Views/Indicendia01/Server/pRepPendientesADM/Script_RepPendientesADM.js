

function Get_Reportes_List_PEND_ADM(Area_Id, FechaIni, FechaFin) {
    var params = {

        Area_Id: Area_Id,
        FechaIni: formatFecha.ymd(FechaIni),
        FechaFin: formatFecha.ymd(FechaFin) + ' 23:59'
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sRepPendientesADM.aspx/Get_Reportes_List_PEND_ADM",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#tbodyReportes').html('');
            for (var i = 0; i <= lengthD; i++) {
                var estado = Datos[i].Estado_Id;
                var infGern = Datos[i].Informar_Gerencia === '01' ? 'SI' : 'NO';

                var btnEdit = '<input type="button" class="buttonProcess" title="Realizar Reporte" id="' + Datos[i].Incidente_Id + '" />';
                switch (estado) {
                    case '01': estado = 'FINALIZADO'; break;
                    case '02': estado = ''; break;
                    case '03': estado = 'EN CURSO'; break;
                    case '04': estado = 'REPORTADO'; break;
                }

                var cant = Datos[i].CantA;
                if (cant > 0) {
                    estado = 'EN CURSO';
                }
                //var btnView = '<input type="button" class="buttonDetalle" title="Ver Reporte" id="' + Datos[i].Estado_Id + '-' + Datos[i].Incidente_Id + '" />';


                var html = '<tr>';
                html += '<td><input type="button" class="buttonAprobar" title="Aprobar Reporte" id="' + Datos[i].Incidente_Id + '" /></td>';
                html += '<td>' + btnEdit + '</td>';
                html += '<td><input type="button" class="buttonDetalle" title="Ver Reporte" id="' + Datos[i].Incidente_Id + '" /></td>';
                html += '<td>' + Datos[i].Incidente_Id + '</td>';
                html += '<td>' + estado + '</td>';
                html += '<td  style="text-align:center;">' + Datos[i].FechaHora_Reporte.toDateFormat() + '</td>';
                html += '<td>' + Datos[i].UsuReporte + '</td>';
                html += '<td>' + Datos[i].RH_Area + '</td>';
                html += '<td>' + Datos[i].Intensidad + '</td>';
                html += '<td  style="text-align:center;">' + Datos[i].Severidad + '</td>';
                html += '<td style="text-align:center;">' + infGern + '</td>';
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

function Get_Localidad_Combo() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sRepPendientesADM.aspx/Get_Localidad_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboLocalidadFind').html('');
            $('<option value="">TODOS</option>').appendTo('#cboLocalidadFind');
            for (var i = 0; i <= lengthD; i++) {
        
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




function Aprobar_Reporte_ADM(Incidencia_Id) {
    var params = {

        Incidencia_Id: Incidencia_Id

    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sRepPendientesADM.aspx/Aprobar_Reporte_ADM",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                var pc = Proceso.split('#')[0];
                var mensaje = Proceso.split('#')[1];
                if (pc == 'true') {
                    alert(mensaje);
                    Get_Reportes_List_PEND_ADM(get_LocalidadFind());
                } else {
                    alert(mensaje);
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


function get_LocalidadFind() {
    return $('#cboLocalidadFind').val() == null ? '' : $('#cboLocalidadFind').val();
};

function get_FechaIniFind() {
    return $('#txtFechaIni').val();
};

function get_FechaFinFind() {
    return $('#txtFechaFin').val();
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