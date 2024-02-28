//funcion listar Feriados

function Get_Planillas_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarTurnoPersona.aspx/Get_Planillas_List", 
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
        async: false
    });

}

//funcion listar localidades

function Get_Localidades_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarTurnoPersona.aspx/Get_Localidades_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboLocalidad').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboLocalidad');

            }

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
        url: "MAsignarTurnoPersona.aspx/Get_Periodos_List",
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
        url: "MAsignarTurnoPersona.aspx/Get_Areas_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboArea').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Categoria_Auxiliar_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboArea');

            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


//funcion listar tabla filtros

function Get_AsignarTurnoPersonas_List(Periodo_id, seccion, area_id, inicio) {
    var params = {
        Periodo_id: Periodo_id,
        seccion: seccion,
        area_id: area_id,
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarTurnoPersona.aspx/Get_AsignarTurnoPersonas_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#tbodyAsignarTurnoPersona').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var html = '<tr>';
                html += '<td class="tbodyLink"><input id="btnEdit' + Data[i].Personal_Id + '" type="button"  value=""  class="ElLinkEditar" title="Editar AsignarHorarioPersonas" /></td>';
                html += '<td>' + Data[i].Localidad + '</td>';
                html += '<td>' + Data[i].Seccion + '</td>';
                html += '<td>' + Data[i].Nombres + '</td>';
                html += '<td>' + Data[i].Horario + '</td>';
                html += '</tr>';

                $(html).appendTo('#tbodyAsignarTurnoPersona');
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
function Get_AsignarTurnoPersonas_Find(codigo) {
    var params = {
        codigo: codigo
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarTurnoPersona.aspx/Get_AsignarTurnoPersonas_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                $('#txtLocalidad').val(Data.Localidad);
                $('#txtSeccion').val(Data.Seccion);
                $('#txtNombres').val(Data.Nombres);
                $('#txtHorarios').val(Data.Horario);
            }

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
function Get_AsignarTurnoPersonas_Update(codigo, localidad, seccion, nombres, horario) {
    var params = {
        codigo: codigo,
        localidad: localidad,
        seccion: seccion,
        nombres: nombres,
        horario: horario
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarTurnoPersona.aspx/Get_AsignarTurnoPersonas_Update",
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
function Get_AsignarTurnoPersonas_MaxRegistro() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "MAsignarTurnoPersona.aspx/Get_AsignarTurnoPersonas_MaxRegistro",
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



//funcion listar Feriados

function Get_Personal_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarTurnoPersona.aspx/Get_Personal_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboPersonal').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Personal_Id + '">' + Data[i].Nombres + '</option>';
                $(html).appendTo('#cboPersonal');

            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


function Get_Periodos2_List(Planilla) {
    var params = {
        Planilla: Planilla
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarTurnoPersona.aspx/Get_Periodos2_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboPeriodo2').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Periodo_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboPeriodo2');

            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


function Get_Planilla_Find() {
    return $('#cboPlanilla').val();
}