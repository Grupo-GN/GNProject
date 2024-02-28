function Get_Planilla_List() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "CAImportarMarcaciones.aspx/Get_Planilla_List",
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

//function Get_Localidad_List() {
//    var Personal_Id = '';
//    var params = {
//        Personal_Id: Personal_Id
//    };
//    $.ajax({
//        type: "POST",
//        data: JSON.stringify(params),
//        dataType: "json",
//        url: "CAImportarMarcaciones.aspx/Get_Localidad_List",
//        contentType: "application/json; chartseft:utf-8",
//        success: function (response) {
//            var Data = response.d;
//            var lengthd = Data.length - 1;
//            $('#cboLocalidad').html('');
//            $('<option value="">-TODOS-</option>').appendTo('#cboLocalidad');
//            for (var i = 0; i <= lengthd; i++) {
//                $('<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboLocalidad');
//            }
//        },
//        error:
//            function (XmlHttpError, error, description) {
//                $('#dialog-form').html(XmlHttpError.responseText);
//            },
//        async: false
//    });
//};



function Get_Localidad_List_New() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "CAImportarMarcaciones.aspx/Get_Localidad_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboLocalidad').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboLocalidad');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboLocalidad');
            }
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
        url: "CAImportarMarcaciones.aspx/Get_Categoria_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoria').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboCategoria');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria2_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoria');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $('#dialog-form').html(XmlHttpError.responseText);
            },
        async: false
    });
};


function Get_Periodo_List(Planilla_Id) {

    var params = {
        Planilla_Id: Planilla_Id,
        Fecha: $('#fecha').val()
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CAImportarMarcaciones.aspx/Get_Periodo_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPeriodo').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Periodo_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPeriodo');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $('#dialog-form').html(XmlHttpError.responseText);
            },
        async: false
    });
};


function Get_CategoriaAux_List() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "CAImportarMarcaciones.aspx/Get_CategoriaAux_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCatAux').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboCatAux');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria_Auxiliar_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCatAux');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $('#dialog-form').html(XmlHttpError.responseText);
            },
        async: false
    });
};

var a_personal = [];
function Get_Personal_List(Periodo_Id, Localidad_Id, CateAux, Categoria) {
    a_personal = [];
    var params = {
        Periodo_Id: Periodo_Id,
        Localidad_Id: Localidad_Id,
        CateAux: CateAux,
        Categoria: Categoria
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CAImportarMarcaciones.aspx/Get_Personal_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            a_personal = [];
            $('#cboPersonal').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboPersonal');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Nro_Doc + '">' + Data[i].Nro_Doc + ' | ' + Data[i].Personal + '</option>').appendTo('#cboPersonal');
                a_personal.push(Data[i].Nro_Doc);
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $('#dialog-form').html(XmlHttpError.responseText);
            },
        async: false
    });
};

function Get_Periodo_Asistencia_List() {
    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "CAImportarMarcaciones.aspx/Get_Periodo_Asistencia_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                $('#txtcodigo').val(Data.Periodo); //.add(1, 'days').format("DD/MM/YYYY")
                $('#txtfi').val(Data.Date_Inicio.toDateShort());
                $('#txtft').val(Data.Date_Fin.toDateShort());
                $('#fecha').val(Data.Date_Inicio.toDateShort());
                //$('#txtfi').val(moment(Data.Date_Inicio).add(1, 'days').format("DD/MM/YYYY"));
                //$('#txtft').val(moment(Data.Date_Fin).add(1, 'days').format("DD/MM/YYYY"));
                //$('#fecha').val(moment(Data.Date_Inicio).add(1, 'days').format("DD/MM/YYYY"));

            }

        },
        error:
            function (XmlHttpError, error, description) {
                $('#dialog-form').html(XmlHttpError.responseText);
            },
        async: false
    });

}


function timesstamp(unix_timestamp0) {
    let unix_timestamp = unix_timestamp0
    // Create a new JavaScript Date object based on the timestamp
    // multiplied by 1000 so that the argument is in milliseconds, not seconds.
    var date = new Date(unix_timestamp * 1000);
    // Hours part from the timestamp
    var hours = date.getHours();
    // Minutes part from the timestamp
    var minutes = "0" + date.getMinutes();
    // Seconds part from the timestamp
    var seconds = "0" + date.getSeconds();

    // Will display time in 10:30:23 format
    var formattedTime = hours + ':' + minutes.substr(-2) + ':' + seconds.substr(-2);
    return formattedTime;
}


//Periodo_Asistencia Get_Periodo_Asistencia_List()
var tbl_marc = [];
function Get_Marcaciones_List(v1, v2, v3) {
    $('#lblMsjVer').html('');
    var params = {
        i_FechaIni: v1,
        i_FechaFin: v2,
        i_Personal: v3
    };
    $('#tbodyMarc').html('');
    tbl_marc = [];
    $('#btnVer').prop('disabled', true)
    $('#lblMsjVer').html('.:: Espere, cargando..');

    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        data: JSON.stringify(params),
        url: "CAImportarMarcaciones.aspx/ImportarMarcaciones",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;


            //$('#divError').html(Data);
            $('#tbodyMarc').html('');

            tbl_marc = [];
            var lengtDatos = Data.length - 1;
          
            const locale = 'es-EC';
            
            const timeZone = 'America/Quito';
           
            for (var i = 0; i <= lengtDatos; i++) {
              
                //var newing = Data[i].HORAINGRESO.toLocaleString(locale, { timeZone: timeZone });
                //var newsal = Data[i].HORASALIDA.toLocaleString(locale, { timeZone: timeZone });
                var newing = Data[i].HORAINGRESO;
                var newsal = Data[i].HORASALIDA;

                var timeString =  moment(newing).add(-8,'hours').format();
                var timeString2 = moment(newsal).add(-8, 'hours').format();
                var tim = moment.tz(timeString, "America/Lima").format('HH:mm');
                //var tim = moment.utc(timeString).tz("America/Lima").format('HH:mm');
                

                var tim2 = moment.tz(timeString2, "America/Lima").format('HH:mm');
                //alert(timeString);
                //alert(tim);
                //var ing = tim.toHoMin().toLocaleString(locale, { timeZone: timeZone }), sal = tim2.toHoMin().toLocaleString(locale, { timeZone: timeZone });
                var ing = tim, sal =  tim2 ;

                //var ing = Data[i].HORAINGRESO.toHoMin(), sal = Data[i].HORASALIDA.toHoMin();

                var Anio = Data[i].HORAINGRESO.toDateShort().toString();
  
                if (Anio.substr(6) == '1900') ing = '';
                Anio = Data[i].HORASALIDA.toDateShort().toString();
                if (Anio.substr(6) == '1900') sal = '';

                tbl_marc.push({
                    CODPER: Data[i].CODPER,
                   // FECHA: moment(moment.tz(Data[i].FECHA, "America/Lima").format()).add(1, 'days').format("DD/MM/YYYY"), //Data[i].FECHA.toDateShort(),
                    FECHA:  moment.tz(Data[i].FECHA, "America/Lima").format("DD/MM/YYYY"), //Data[i].FECHA.toDateShort(),

                    HORAINGRESO: ing,
                    HORASALIDA: sal
                });
            }

            for (var i = 0; i <= tbl_marc.length - 1; i++) {
                var html = '<tr>';
                html += '<td>' + tbl_marc[i].CODPER + '</td>';
                html += '<td style="text-align:center;">' + tbl_marc[i].FECHA + '</td>';
                html += '<td style="text-align:center;">' + tbl_marc[i].HORAINGRESO + '</td>';
                html += '<td style="text-align:center;">' + tbl_marc[i].HORASALIDA + '</td>';
                html += '<td id="td' + tbl_marc[i].CODPER + tbl_marc[i].FECHA.replace('/', '').replace('/', '') + '"></td>';
                html += '</tr>';
                $(html).appendTo('#tbodyMarc');
            }
            $('#btnVer').prop('disabled', false);
            $('#lblMsjVer').html('.:: Terminado.');
        },
        error:
            function (XmlHttpError, error, description) {
                $('#btnVer').prop('disabled', false);
                $('#lblMsjVer').html('.:: Error, ver detalles en la parte inferior.');
                $('#divError').html(XmlHttpError.responseText);
            },
        async: true
    });

}




function Get_Marcaciones_List2(v1, v2, v3) {
    $('#lblMsjVer').html('');
    var params = {
        i_FechaIni: v1,
        i_FechaFin: v2,
        i_Personal: v3
    };
    $('#tbodyMarc').html('');
    tbl_marc = [];
    $('#btnVer').prop('disabled', true)
    $('#lblMsjVer').html('.:: Espere, cargando..');

    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        data: JSON.stringify(params),
        url: "CAImportarMarcaciones.aspx/ImportarMarcaciones2",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;


            //$('#divError').html(Data);
            $('#tbodyMarc').html('');

            tbl_marc = [];
            var lengtDatos = Data.length - 1;

            const locale = 'es-EC';

            const timeZone = 'America/Quito';

            for (var i = 0; i <= lengtDatos; i++) {

                var newing = Data[i].HORAINGRESO;
                var newsal = Data[i].HORASALIDA;

                var timeString = moment(newing).add(-8, 'hours').format();
                var timeString2 = moment(newsal).add(-8, 'hours').format();
                var tim = moment.tz(timeString, "America/Lima").format('HH:mm');
            
                var tim2 = moment.tz(timeString2, "America/Lima").format('HH:mm');
              var ing = tim, sal = tim2;
   var Anio = Data[i].HORAINGRESO.toDateShort().toString();

                if (Anio.substr(6) == '1900') ing = '';
                Anio = Data[i].HORASALIDA.toDateShort().toString();
                if (Anio.substr(6) == '1900') sal = '';

                tbl_marc.push({
                    CODPER: Data[i].CODPER,
                    Nombres: Data[i].Nombres,
                    // FECHA: moment(moment.tz(Data[i].FECHA, "America/Lima").format()).add(1, 'days').format("DD/MM/YYYY"), //Data[i].FECHA.toDateShort(),
                    FECHA: moment.tz(Data[i].FECHA, "America/Lima").format("DD/MM/YYYY"), //Data[i].FECHA.toDateShort(),

                    HORAINGRESO: ing,
                    HORASALIDA: sal
                });
            }

            for (var i = 0; i <= tbl_marc.length - 1; i++) {
                var html = '<tr>';
                html += '<td>' + tbl_marc[i].CODPER + '</td>';
                html += '<td>' + tbl_marc[i].Nombres + '</td>';
                html += '<td style="text-align:center;">' + tbl_marc[i].FECHA + '</td>';
                html += '<td style="text-align:center;">' + tbl_marc[i].HORAINGRESO + '</td>';
                html += '<td style="text-align:center;">' + tbl_marc[i].HORASALIDA + '</td>';
                html += '<td id="td' + tbl_marc[i].CODPER + tbl_marc[i].FECHA.replace('/', '').replace('/', '') + '"></td>';
                html += '</tr>';
                $(html).appendTo('#tbodyMarc');
            }
            $('#btnVer').prop('disabled', false);
            $('#lblMsjVer').html('.:: Terminado.');
        },
        error:
            function (XmlHttpError, error, description) {
                $('#btnVer').prop('disabled', false);
                $('#lblMsjVer').html('.:: Error, ver detalles en la parte inferior.');
                $('#divError').html(XmlHttpError.responseText);
            },
        async: true
    });

}




//Registrar Marcaciones
var tbl_marc = [];
function Registrar_Marcaciones_List() {

    var d_personal = [];
    for (var i = 0; i < tbl_marc.length - 1; i++) {
        if (d_personal.indexOf(tbl_marc[i].CODPER) == -1) {
            d_personal.push(tbl_marc[i].CODPER);
        }
    }


    for (var i = 0; i <= d_personal.length - 1; i++) {
        var d_marcaciones = [];
        d_marcaciones = tbl_marc.filter(function (x) { return x.CODPER == d_personal[i]; });
        var d_insert = [];
        for (var v = 0; v <= d_marcaciones.length - 1; v++) {
            d_insert.push(d_marcaciones[v].CODPER + '|' + d_marcaciones[v].FECHA + '|' + d_marcaciones[v].HORAINGRESO + '|' + d_marcaciones[v].HORASALIDA);
        }
        var params = {
            i_list: d_insert
        };


        $.ajax({
            type: "POST",
            data: JSON.stringify(),
            dataType: "json",
            data: JSON.stringify(params),
            url: "CAImportarMarcaciones.aspx/RegistrarMarcaciones",
            contentType: "application/json; chartseft:utf-8",
            success: function (response) {
                var Data = response.d;
                var lengtDatos = Data.length - 1;
                for (var i = 0; i <= lengtDatos; i++) {
                    var d_val = Data[i].split('|');
                    if (d_val.length > 5) {
                        $('#td' + d_val[0] + d_val[1]).html(d_val[2] + d_val[4] + "<br/>" + d_val[5] + d_val[7]);
                    } else {
                        $('#td' + d_val[0] + d_val[1]).html(d_val[2] + d_val[4]);
                    }
                }
            },
            error:
                function (XmlHttpError, error, description) {
                    $('#dialog-form').html(XmlHttpError.responseText);
                },
            //async: true
            async: false
        });
    }
    alert('SE REGISTRO CON EXITO LAS MARCACIONES');
}

function Get_Planilla_Find() {
    return $('#cboPlanilla').val();
};

function Get_Periodo_Find() {
    return $('#cboPeriodo').val();
};

function Get_Localidad_Find() {
    return $('#cboLocalidad').val();
};

function Get_CateAux_Find() {
    return $('#cboCatAux').val();
};

function Get_Categoria_Find() {
    return $('#cboCategoria').val();
};
function Get_Personal_Find() {
    var cadena = '';
    if ($('#cboPersonal').val() == '') {
        for (var i = 0; i <= a_personal.length - 1; i++) {
            if (a_personal[i] != '') {
                cadena += a_personal[i] + ',';
            }
        }
        if (cadena != '') {
            cadena = cadena.substr(0, cadena.length - 1);
        }
    } else {
        cadena = $('#cboPersonal').val();
    }
    return cadena;
};

String.prototype.toDateShort = function () {
    var dte = eval("new " + this.replace(/\//g, '') + ";");

    dte.setMinutes(dte.getMinutes() - dte.getTimezoneOffset());
    var ret = dateShort(dte);

    return ret;
}

function dateShort(fecha) {

    var Dia = fecha.getUTCDate();
    var Mes = (fecha.getUTCMonth() + 1);
    var Anio = fecha.getUTCFullYear();

    Dia = Dia.toString().padLeft("0", 2);
    Mes = Mes.toString().padLeft("0", 2);

    var Hora = fecha.getUTCHours();
    Hora = Hora.toString().padLeft("0", 2);

    var Min = fecha.getUTCMinutes();
    Min = Min.toString().padLeft("0", 2);

    var fechaWPP = Dia + "/" + Mes + "/" + Anio;

    return fechaWPP;
}

function dateSave(fecha) {//dateSave

    var Dia = fecha.getUTCDate();
    var Mes = (fecha.getUTCMonth() + 1);
    var Anio = fecha.getUTCFullYear();

    Dia = Dia.toString().padLeft("0", 2);
    Mes = Mes.toString().padLeft("0", 2);

    var Hora = fecha.getUTCHours();
    Hora = Hora.toString().padLeft("0", 2);

    var Min = fecha.getUTCMinutes();
    Min = Min.toString().padLeft("0", 2);

    var fechaWPP = Anio + "/" + Mes + "/" + Dia;

    return fechaWPP;
}


///////////////////////////////////////////////////////////////////////////////////////


//funciones de fechas


String.prototype.toDatelong = function () {
    var dte = eval("new " + this.replace(/\//g, '') + ";");

    dte.setMinutes(dte.getMinutes() - dte.getTimezoneOffset());

    var ret = dateDemo(dte);

    return ret;
}

String.prototype.toHoMin = function () {
    var dte = eval("new " + this.replace(/\//g, '') + ";");

    dte.setMinutes(dte.getMinutes() - dte.getTimezoneOffset());

    var ret = get_HorMin(dte);

    return ret;
}


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
}

function get_HorMin(fecha) {

    var Dia = fecha.getUTCDate();
    var Mes = (fecha.getUTCMonth() + 1);
    var Anio = fecha.getUTCFullYear();

    Dia = Dia.toString().padLeft("0", 2);
    Mes = Mes.toString().padLeft("0", 2);

    var Hora = fecha.getUTCHours();
    Hora = Hora.toString().padLeft("0", 2);

    var Min = fecha.getUTCMinutes();
    Min = Min.toString().padLeft("0", 2);

    var fechaWPP = Hora + ":" + Min;

    return fechaWPP;
}




String.prototype.padLeft = function (paddingChar, length) {

    var s = new String(this);

    if ((this.length < length) && (paddingChar.toString().length > 0)) {
        for (var i = 0; i < (length - this.length); i++)
            s = paddingChar.toString().charAt(0).concat(s);
    }

    return s;
}

///////////////////////////////////////////////////////////////////////////////////////