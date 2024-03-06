//funcion listar turnos

function Get_Turnos_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MTurnos.aspx/Get_Turnos_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#tbodyTurnos').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {                
                var html = '<tr>';
                html += '<td class="tbodyLink"><input id="btnEdit' + Data[i].Turno_Id + '" type="button"  value=""  class="buttonEdit" title="Editar Turno" /></td>';
                html += '<td>' + Data[i].Nombre + '</td>';
                html += '<td>' + Data[i].Descripcion + '</td>';
                html += '<td>' + Data[i].HoraInicio.substring(11, 16) + '</td>';
                html += '<td>' + Data[i].HoraInicioRefrigerio.substring(11, 16) + '</td>';
                html += '<td>' + Data[i].HoraFinRefrigerio.substring(11, 16) + '</td>';
                html += '<td>' + Data[i].HoraFin.substring(11, 16) + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyTurnos');
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}

//funcion buscar y cargar turnos por codigo
function Get_Turnos_Find(codigo) {
    var params = {
        codigo: codigo
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MTurnos.aspx/Get_Turnos_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                $('#txtCodigo').val(Data.Turno_Id);
                $('#txtNombre').val(Data.Nombre);
                $('#txtDescripcion').val(Data.Descripcion);
                $('#txtHoraIni').val(Data.HoraInicio.substring(11, 16));
                $('#txtHoraIniRefri').val(Data.HoraInicioRefrigerio.substring(11, 16));
                $('#txtHoraFinRefri').val(Data.HoraFinRefrigerio.substring(11, 16));
                $('#txtHoraFin').val(Data.HoraFin.substring(11, 16));
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


/////////////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////////////////////////////////////////////////////////









//Get_Carac_Update(Carac_Id,Carac_Nombre,Carac_Opcion,Estado)
//actualizar turno
function Get_Turnos_Update(codigo, nombre, descripcion, horaini, horainirefri, horafinrefri, horafin) {
    var params = {
        codigo: codigo,
        nombre: nombre,
        descripcion: descripcion,
        horaini: horaini,
        horainirefri: horainirefri,
        horafinrefri: horafinrefri,
        horafin: horafin
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MTurnos.aspx/Get_Turnos_Update",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert('Modificado Correctamente')
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });
}






//Get_Carac_MaxRegistro(Carac_Nombre,Carac_Opcion,Estado)
function Get_Turnos_MaxRegistro() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "MTurnos.aspx/Get_Turnos_MaxRegistro",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            setTotalRegistros(Data);
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });
}



function setTotalRegistros(TotalRegistros) {
    $('#txtnRegistros').val(TotalRegistros);
}






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
function Get_Turnos_Add(nombre, descripcion, horaini, horainirefri, horafinrefri, horafin) {
    param =
         {
             nombre: nombre,
             descripcion: descripcion,
             horaini: horaini,
             horainirefri: horainirefri,
             horafinrefri: horafinrefri,
             horafin: horafin
         };
    $.ajax({
        type: "POST",
        data: JSON.stringify(param),
        dataType: "json",
        url: "MTurnos.aspx/Get_Turnos_Add",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert('Inserto Correctamente')
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });
}