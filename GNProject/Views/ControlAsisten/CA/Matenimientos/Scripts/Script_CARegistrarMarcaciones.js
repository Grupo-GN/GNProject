
//Periodo_Asistencia Get_Periodo_Asistencia_List()
function Get_Periodo_Asistencia_List() {

    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "CARegistrarMarcaciones.aspx/Get_Periodo_Asistencia_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                $('#txtcodigo').val(Data.Periodo);
                $('#txtfi').val(Data.Date_Inicio.toDateShort());
                $('#txtft').val(Data.Date_Fin.toDateShort());
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}






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