//funcion listar Feriados

function Get_Planillas_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarTurnoMasivos.aspx/Get_Planillas_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboPlanilla').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboPlanilla');

            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}

//funcion listar localidades

function Get_Localidades_List() {
    var Personal_Id = Personal_Proc;
    var params = {
        Personal_Id: Personal_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarTurnoMasivos.aspx/Get_Localidades_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboLocalidad').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboLocalidad');

            }
            $('<option value="">-TODOS-</option>').appendTo('#cboLocalidad');
            $("#cboLocalidad > option[value='']").attr("selected", true);

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}

//funcion listar periodos

function Get_Periodos_List(Planilla) {
    var params = {
        Planilla: Planilla
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarTurnoMasivos.aspx/Get_Periodos_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboPeriodo').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Periodo_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboPeriodo');

            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}

//funcion listar areas

function Get_Areas_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarTurnoMasivos.aspx/Get_Areas_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboArea').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var html = '<option value="' + Data[i].Categoria_Auxiliar_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboArea');

            }
            $('<option value="">-TODOS-</option>').appendTo('#cboArea');
            $("#cboArea > option[value='']").attr("selected", true);
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


//funcion listar tabla filtros

function Get_AsignarTurnoMasivos_List(Periodo_id, seccion, area_id, inicio) {
    var Personal_Id = Personal_Proc;
    var params = {
        Periodo_id: Periodo_id,
        seccion: seccion,
        area_id: area_id,
        inicio: inicio,
        Personal_Id: Personal_Id,
        Jefe_Id: Personal_Proc
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarTurnoMasivos.aspx/Get_AsignarTurnoMasivos_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#tbodyAsignarTurnoMasivos').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var html = '<tr>';
                html += '<td class="tbodyLink" style="text-align:center;width:20px;"><input id="' + Data[i].Personal_Id + '" class="chkseleccionado" type="checkbox"  value=""  title="Editar AsignarTurnoMasivos" /></td>';
                html += '<td>' + Data[i].Localidad + '</td>';
                html += '<td>' + Data[i].Seccion + '</td>';
                html += '<td>' + Data[i].Area + '</td>';
                html += '<td>' + Data[i].Nombres + '</td>';
                html += '</tr>';

                $(html).appendTo('#tbodyAsignarTurnoMasivos');
            }
            document.getElementById("txtnRegistros").value = lengtDatos;

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}



function Get_TurnoAsignar_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarTurnoMasivos.aspx/Get_TurnoAsignar_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cboTurnoAsignar').html('');
            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var html = '<option value="' + Data[i].Turno_Id + '">' + Data[i].Nombre + '</option>';
                $(html).appendTo('#cboTurnoAsignar');
            }
            var Turno_id = $('#cboTurnoAsignar').val();
            Get_TurnoAsignarLabel_List(Turno_id);
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}



function Get_TurnoAsignarLabel_List(Turno_id) {
    
    var params = {
        Turno_id: Turno_id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarTurnoMasivos.aspx/Get_TurnoAsignarLabel_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#txtinput1').val(Data[0].HoraInicio.toDatelong().split(' ')[1]);
            $('#txtinput2').val(Data[0].HoraInicioRefrigerio.toDatelong().split(' ')[1]);
            $('#txtinput3').val(Data[0].HoraFinRefrigerio.toDatelong().split(' ')[1]);
            $('#txtinput4').val(Data[0].HoraFin.toDatelong().split(' ')[1]);

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

}









//////////////////////////////////////////////


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



function Get_TurnoAsignar_Proceso() {
    var Personal = '', turno = $('#cboTurnoAsignar').val(), cant = 0, fechaini, fechafin, alter, dias;

    fechaini = $('#datepicker').val();
    fechafin = $('#datepicker2').val();

    alter = $('#ckSeleccion').prop('checked');
    dias = parseInt($('#txtBox').val());
    if (!turno) {
        alert('.::Error > Tuno de especificado.')
        return false;
    } else {
        turno = parseInt(turno);
    }
    if (fechaini == null || fechaini == '') {
        alert('.::Error > Fecha de inicio no definida.')
        return false;
    }
    if (fechafin == null || fechafin == '') {
        alert('.::Error > Fecha final no definida.')
        return false;
    }

    $('.chkseleccionado').each(function () {
        if ($(this).prop('checked') == true) {
            Personal += this.id + '|';
            cant += 1;
        }
    });

    if (Personal == null || Personal == '') {
        alert('.::Error > Seleccione por lo menos un personal.')
        return false;
    }

    if (cant == null || cant == 0 ) {
        alert('.::Error > Seleccione por lo menos un personal.')
        return false;
    }
    var alterDis = 0;
    if (alter) {
        alterDis = 1;
    }
    var params = {
        Personal: Personal,
        turno: turno,
        cant: cant,
        fechaini: fechaini,
        fechafin: fechafin,
        alter: alterDis,
        dias: dias
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarTurnoMasivos.aspx/Get_TurnoAsignar_Proceso",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proc = response.d;
            if (Proc) {
                var resu = Proc.split('#')[0];
                var mensa = Proc.split('#')[1];
                if (resu == 'true') {
                    var Periodo_id = $('#cboPeriodo').val();
                    var seccion = $('#cboArea').val();
                    var area_id = $('#cboLocalidad').val();
                    seccion = seccion.trim();
                    Get_AsignarTurnoMasivos_List(Periodo_id, seccion, area_id, 0);
                    alert(mensa);
                } else {
                    alert(mensa);
                }
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}