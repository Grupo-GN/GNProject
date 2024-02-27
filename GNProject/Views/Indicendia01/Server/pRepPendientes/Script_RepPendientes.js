

function Get_Reportes_List_PEND(Per_Registro) {
    var params = {

        Per_Registro:Per_Registro

    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sRepPendientes.aspx/Get_Reportes_List_PEND",
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
                    case '02': estado = '';  break;
                    case '03': estado = 'APROBADO';  break;
                    case '04': estado = 'REPORTADO'; break;
                }


                //var btnView = '<input type="button" class="buttonDetalle" title="Ver Reporte" id="' + Datos[i].Estado_Id + '-' + Datos[i].Incidente_Id + '" />';


                var html = '<tr>';
                html += '<td>' + btnEdit + '</td>';
                html += '<td><input type="button" class="buttonDetalle" title="Ver Reporte" id="'+ Datos[i].Incidente_Id + '" /></td>';
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