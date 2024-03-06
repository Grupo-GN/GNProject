//funcion listar Feriados

function Get_Planillas_List() {
    var params = {

    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MParametrosPersona.aspx/Get_Planillas_List",
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

function Get_Localidades_List() {
    var params = {

    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MParametrosPersona.aspx/Get_Localidades_List",
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

//funcion listar areas

function Get_Secciones_List() {
    var params = {

    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MParametrosPersona.aspx/Get_Secciones_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboSeccion').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Categoria_Auxiliar_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboSeccion');

            }
            $('<option value="">-TODOS-</option>').appendTo('#cboSeccion');
            $("#cboSeccion > option[value='']").attr("selected", true);
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
        url: "MParametrosPersona.aspx/Get_Periodos_List",
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


//funcion listar Feriados

function Get_Personal_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MParametrosPersona.aspx/Get_Personal_List",
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


//funcion listar localidades

function Get_Variables_List(Personal_Id) {
    var params = {
        Personal_Id: Personal_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MParametrosPersona.aspx/Get_Variables_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboVariable').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Parametro_Id + '">' + Data[i].Variable + '</option>';
                $(html).appendTo('#cboVariable');

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

function Get_ParametrosPersona_List(Personal_Id,  inicio) {
    var params = {
        Personal_Id: Personal_Id,
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MParametrosPersona.aspx/Get_ParametrosPersona_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#tbodyParametrosPersona').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var html = '<tr>';
                html += '<td>' + Data[i].Variable + '</td>';
                html += '<td>' + Data[i].Valor + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyParametrosPersona');
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}

function Get_ParametrosPersona_Add(Parametro_Id, Personal_Id, Valor) {
    param =
         {
             Parametro_Id: Parametro_Id,
             Personal_Id: Personal_Id,
             Valor: Valor
         };
    $.ajax({
        type: "POST",
        data: JSON.stringify(param),
        dataType: "json",
        url: "MParametrosPersona.aspx/Get_ParametrosPersona_Add",
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


//funcion buscar y cargar turnos por codigo
function Get_ParametrosPersona_Find(codigo) {
    var params = {
        codigo: codigo
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MParametrosPersona.aspx/Get_ParametrosPersona_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                $('#cboVariable').val(Data.Variable);
                $('#txtValor').val(Data.Valor);
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}




///Script Para ELIMINAR VEHICULO
function Get_ParametrosPersona_UpdateValor(Parametro_Id, Personal_Id, newValor) {
    var params = {
        Parametro_Id: Parametro_Id,
        Personal_Id: Personal_Id,
        newValor: newValor
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MParametrosPersona.aspx/Get_ParametrosPersona_UpdateValor",
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


//funcion listar Feriados

function Get_Parametros_List() {
    var params = {

};

$.ajax({
    type: "POST",
    data: JSON.stringify(params),
    dataType: "json",
    url: "MParametrosPersona.aspx/Get_Parametros_List",
    contentType: "application/json; chartseft:utf-8",
    success: function (response) {
        var Data = response.d;

        $('#cboParametro').html('');

        var lengtDatos = Data.length - 1;
        for (var i = 0; i <= lengtDatos; i++) {

            var html = '<option value="' + Data[i].Personal_Id + '">' + Data[i].Parametro_Id + '</option>';
            $(html).appendTo('#cboParametro');

        }

    },
    error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
    async: true
});

}
