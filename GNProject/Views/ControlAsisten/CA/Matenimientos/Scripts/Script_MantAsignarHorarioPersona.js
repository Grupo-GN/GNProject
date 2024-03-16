//funcion listar Feriados

function Get_Planillas_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioPersona.aspx/Get_Planillas_List",
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
       $('#divError').html(XmlHttpError.responseText);
   },
        async: true
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
        url: "MAsignarHorarioPersona.aspx/Get_Localidades_List",
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
       $('#divError').html(XmlHttpError.responseText);
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
        url: "MAsignarHorarioPersona.aspx/Get_Periodos_List",
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
       $('#divError').html(XmlHttpError.responseText);
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
        url: "MAsignarHorarioPersona.aspx/Get_Areas_List",
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
       $('#divError').html(XmlHttpError.responseText);
   },
        async: true
    });

}


//funcion listar tabla filtros

function Get_AsignarHorarioPersonas_List(Periodo_id, seccion, area_id, inicio) {
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
        url: "MAsignarHorarioPersona.aspx/Get_AsignarHorarioPersonas_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            cont = 0;
            $('#tbodyAsignarHorarioPersona').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var html = '<tr>';
                html += '<td>' + Data[i].Localidad + '</td>';
                html += '<td>' + Data[i].Seccion + '</td>';
                html += '<td>' + Data[i].Nombres + '</td>';
                html += '<td>' + Data[i].Horario + '</td>';
                html += '<td class="tbodyLink"><input id="btnEdit' + Data[i].Personal_Id + '" type="button"  value=""  class="buttonEdit" title="Editar AsignarHorarioPersonas" /></td>';
                html += '</tr>';

                $(html).appendTo('#tbodyAsignarHorarioPersona');
                cont = cont + 1;
            }
            $('#txtnRegistros').val(cont);
            totalReg = cont;
           
           // Get_AsignarHorarioPersonas_MaxRegistro(Periodo_id, seccion, area_id);
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: true
    });

}
var totalReg = 0;
var cont =0;
//funcion buscar y cargar turnos por codigo
function Get_AsignarHorarioPersonas_Find(codigo) {
    var params = {
        codigo: codigo
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioPersona.aspx/Get_AsignarHorarioPersonas_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                $('#txtCodigo').val(Data.Personal_Id);
                //                $('#txtHorarios').val(Data.Nombre);
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: true
    });

}


//Get_Carac_Update(Carac_Id,Carac_Nombre,Carac_Opcion,Estado)
//actualizar turno
function Get_AsignarHorarioPersonas_Update(Personal_Id, Horario_Id) {
    var params = {
        Personal_Id: Personal_Id,
        Horario_Id: Horario_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioPersona.aspx/Get_AsignarHorarioPersonas_Update",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert('Modificado Correctamente')
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: true
    });
}



//Get_Carac_MaxRegistro(Carac_Nombre,Carac_Opcion,Estado)
function Get_AsignarHorarioPersonas_MaxRegistro(Periodo_id, seccion, area_id) {
    var params = {
        Periodo_id: Periodo_id,
        seccion: seccion,
        area_id: area_id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioPersona.aspx/Get_AsignarHorarioPersonas_MaxRegistro",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            
            setTotalRegistros(Data);
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: true
    });
}

function setTotalRegistros(TotalRegistros) {
   // $('#txtnRegistros').val(TotalRegistros);
}



function Get_AsignarHorarioPersonas_Add(localidad, seccion, nombres, horarios) {
    param =
         {
             localidad: localidad,
             seccion: seccion,
             nombres: nombres,
             horarios: horarios
         };
    $.ajax({
        type: "POST",
        data: JSON.stringify(param),
        dataType: "json",
        url: "MAsignarHorarioPersona.aspx/Get_AsignarHorarioPersonas_Add",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert('Inserto Correctamenta')
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: true
    });
}


//Get_Carac_Update(Carac_Id,Carac_Nombre,Carac_Opcion,Estado)


//funcion listar Feriados

function Get_Horarios_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MAsignarHorarioPersona.aspx/Get_Horarios_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboHorarios').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Horario_Id + '">' + Data[i].Nombre + '</option>';
                $(html).appendTo('#cboHorarios');

            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: true
    });

}