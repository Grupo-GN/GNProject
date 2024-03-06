//funcion listar Feriados

function Get_Planillas_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MCorreoPersonal.aspx/Get_Planillas_List",
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

function Get_Localidades_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MCorreoPersonal.aspx/Get_Localidades_List",
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

function Get_Secciones_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MCorreoPersonal.aspx/Get_Secciones_List",
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

//funcion listar areas

function Get_Categorias_List(inicio) {
    var params = {
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MCorreoPersonal.aspx/Get_Categorias_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboCategoria').html('');

            var lengtDatos = Data.length - 1;
            $('<option value="">-TODOS-</option>').appendTo('#cboCategoria');
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Categoria2_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboCategoria');

            }
            $('#cboCategoria').val('');

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


//funcion listar tabla filtros

function Get_CorreoPersonal_List(planilla,  area_id,  seccion,  categoria2_Id,  inicio, nombre) {

    var params = {
        planilla: planilla,
        area_id: area_id,
        seccion: seccion,
        categoria2_Id: categoria2_Id,
        inicio: inicio,
        nombre:nombre
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MCorreoPersonal.aspx/Get_CorreoPersonal_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#tbodyCorreoPersonal').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var html = '<tr>';
                html += '<td class="tbodyLink"><input id="btnEdit' + Data[i].Personal_Id + '" type="button"  value=""  class="buttonEdit" title="Editar AsignarCorreoPersonal" /></td>';
                html += '<td>' + Data[i].Area + '</td>';
                html += '<td>' + Data[i].Nombres + '</td>';
                html += '<td>' + Data[i].email + '</td>';
                html += '</tr>';

                $(html).appendTo('#tbodyCorreoPersonal');
            }
            Get_CorreoPersonal_List_MaxRows(planilla,area_id,seccion,categoria2_Id);
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

};


function Get_CorreoPersonal_List_MaxRows(planilla, area_id, seccion, categoria2_Id) {

    var params = {
        planilla: planilla,
        area_id: area_id,
        seccion: seccion,
        categoria2_Id: categoria2_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MCorreoPersonal.aspx/Get_CorreoPersonal_List_MaxRows",
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

};

function setTotalRegistros(TotalRegistros) {
    $('#txtnRegistros').val(TotalRegistros);
}


//funcion buscar y cargar Feriados por codigo
function Get_CorreoPersonal_Find(codigo) {
    var params = {
        codigo: codigo
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MCorreoPersonal.aspx/Get_CorreoPersonal_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                $('#txtCodigo').val(Data[0].Personal_Id);
                $('#txtNombre').val(Data[0].Nombres);
                $('#txtCorreo').val(Data[0].email);
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

}



//actualizar turno
function Get_CorreoPersonal_Update(codigo, correo) {
    var params = {
        codigo: codigo,
        correo: correo,
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MCorreoPersonal.aspx/Get_CorreoPersonal_Update",
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