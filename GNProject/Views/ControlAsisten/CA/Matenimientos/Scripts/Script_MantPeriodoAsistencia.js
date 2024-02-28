//funcion listar periodos

function Get_Periodos_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MPeriodoAsistencia.aspx/Get_Periodos_List", 
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




//funcion listar turnos

function Get_PeriodoAsistencia_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MPeriodoAsistencia.aspx/Get_PeriodoAsistencia_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#tbodyPeriodoAsistencia').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var html = '<tr>';
                html += '<td class="tbodyLink"><input id="btnEdit' + Data[i].Periodo_Asistencia_Id + '" type="button"  value=""  class="ElLinkEditar" title="Editar Periodo Asistencia" /></td>';
                html += '<td class="tbodyLink"><input id="btnDelete' + Data[i].Periodo_Asistencia_Id + '" type="button"  value=""  class="ElLinkEliminar" title="Eliminar Periodo Asistencia" /></td>';
                html += '<td>' + Data[i].Periodo_Asistencia_Id + '</td>';
                html += '<td>' + Data[i].Date_Inicio.toDateShort() + '</td>';
                html += '<td>' + Data[i].Date_Fin.toDateShort() + '</td>';
                html += '<td>' + Data[i].Periodo + '</td>';
                html += '<td>' + Data[i].Estado + '</td>';
                html += '</tr>';

                $(html).appendTo('#tbodyPeriodoAsistencia');
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


//////////////////////////////////////////////////////////////
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


    var fechaWPP = Dia + "/" + Mes + "/" + Anio + " " + Hora + ":" + Min;

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

//////////////////////////////////////////////////////////////

//funcion listar Feriados

function Get_Activos_PorId_Update(Periodo_Asistencia_Id, Estado) {
    var params = {
        Periodo_Asistencia_Id: Periodo_Asistencia_Id,
        Estado: Estado
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MPeriodoAsistencia.aspx/Get_Activos_PorId_Update",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


//Get_Carac_Update(Carac_Id,Carac_Nombre,Carac_Opcion,Estado)
//actualizar turno
function Get_PeriodoAsistencia_Update(codigo, activo) {
    var params = {
        codigo: codigo,
        activo: activo
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MPeriodoAsistencia.aspx/Get_PeriodoAsistencia_Update",
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
function Get_PeriodoAsistencia_MaxRegistro() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "MPeriodoAsistencia.aspx/Get_PeriodoAsistencia_MaxRegistro",
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




function Get_PeriodoAsistencia_Delete(Periodo_Asistencia_Id) {
    var params = {
        Periodo_Asistencia_Id: Periodo_Asistencia_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MPeriodoAsistencia.aspx/Get_PeriodoAsistencia_Delete",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert('Eliminado Correctamente')
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });
}


function Get_PeriodoAsistencia_Add(fechainicio2, periodo, fechafin2, estado) {
    param =
         {
             fechainicio2: fechainicio2,
             periodo: periodo,
             fechafin2: fechafin2,
             estado: estado
         };
    $.ajax({
        type: "POST",
        data: JSON.stringify(param),
        dataType: "json",
        url: "MPeriodoAsistencia.aspx/Get_PeriodoAsistencia_Add",
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