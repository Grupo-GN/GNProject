//funcion listar Feriados

function Get_Feriados_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MFeriados.aspx/Get_Feriados_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#tbodyFeriados').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var html = '<tr>';
                html += '<td class="tbodyLink"><input id="btnEdit' + Data[i].Feriado_Id + '" type="button"  value=""  class="buttonEdit" title="Editar Feriado" /></td>';
                html += '<td>' + Data[i].Nombre + '</td>';
                html += '<td>' + Data[i].Descripcion + '</td>';
                html += '<td>' + Data[i].Fecha.toDateShort() + '</td>';
                html += '</tr>';

                $(html).appendTo('#tbodyFeriados');
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}

//funcion buscar y cargar Feriados por codigo
function Get_Feriados_Find(codigo) {
    var params = {
        codigo: codigo
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MFeriados.aspx/Get_Feriados_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                $('#txtCodigo').val(Data.Feriado_Id);
                $('#txtNombre').val(Data.Nombre);
                $('#txtDescripcion').val(Data.Descripcion);
                $('#txtFecha').val(Data.Fecha.toDateShort());
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







//Get_Carac_Update(Carac_Id,Carac_Nombre,Carac_Opcion,Estado)
//actualizar Feriados
function Get_Feriados_Update(codigo, nombre, descripcion, fecha) {
    var params = {
        codigo: codigo,
        nombre: nombre,
        descripcion: descripcion,
        fecha: fecha
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MFeriados.aspx/Get_Feriados_Update",
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
function Get_Feriados_MaxRegistro() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "MFeriados.aspx/Get_Feriados_MaxRegistro",
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
function Get_Feriados_Add(nombre, descripcion, fecha) {
    param =
         {
             nombre: nombre,
             descripcion: descripcion,
             fecha: fecha
         };
    $.ajax({
        type: "POST",
        data: JSON.stringify(param),
        dataType: "json",
        url: "MFeriados.aspx/Get_Feriados_Add",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert('Inserto Correctamenta')
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });
}