function ListaEmpledoDispositivo(Personal_Id) {


    var params = {
        Personal_Id: Personal_Id

    };


    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "Personal_Dispositivo.aspx/ListaEmpDispsitivo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            DataL = response.d;
            lengtL = DataL.length - 1;
            $('#tbodyNovedades').html('');

            for (var i = 0; i <= lengtL; i++) {
                var html = '<tr>';
               
                html += '<td style="display:none;">' + DataL[i].id + '</td>';
                html += '<td >' + DataL[i].Nombre + '</td>';
                html += '<td >' + DataL[i].Conexion + '</td>';
                html += '<td >' + DataL[i].Dispositivo + '</td>';
                html += '<td >' + DataL[i].TipoConexion + '</td>';
               
                html += '<td class="tbodyLink"><input id="btnEdit' + DataL[i].id + '" type="button"  value=""  class="ElLinkEditar" title="Editar Usuario" /></td>';
                html += '<td class="tbodyLink"><input id="btnElim' + DataL[i].id + '" type="button"  value=""  class="ElLinkEliminar" title="Eliminar Usuario" /></td>';


                html += '</tr>';

                $(html).appendTo('#tbodyNovedades');
            }
        },
        error:
           function (XmlHttpError, error, description) {
               $('#dialog-form').html(XmlHttpError.responseText);
           },
        async: false
    });
};

function ListaDispositivo() {

    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "Personal_Dispositivo.aspx/ListaDispositivo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cbodispositivo').html('');
            $('<option value="">-Seleccionar-</option>').appendTo('#cbodispositivo');
            $('#cbodispositivo').val('');
            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].id + '">' + Data[i].descripcion + '</option>';
                $(html).appendTo('#cbodispositivo');

            }
          

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


function Listatipoconexion() {

    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "Personal_Dispositivo.aspx/ListaTipoConexion",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboTipoconexion').html('');
            $('<option value="">-Seleccionar-</option>').appendTo('#cboTipoconexion');
            $('#cboTipoconexion').val('');
            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].id + '">' + Data[i].descripcion + '</option>';
                $(html).appendTo('#cboTipoconexion');

            }


        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


function getdispositivos(id) {
    var params = {
        id: id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "Personal_Dispositivo.aspx/ListaEmpDispsitivoFind",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            var lengtDatos = Data.length - 1;
 
            for (var i = 0; i <= lengtDatos; i++) {
                $('#txtCodigo').val(Data[i].id);
                $('#id_personal').html(Data[i].Personal_id);
                $('#txtnombre').val(Data[i].Nombre);
                $('#txtconexion').val(Data[i].Conexion);
                $('#cbodispositivo').val(Data[i].Dispositivo);
                $('#cboTipoconexion').val(Data[i].TipoConexion);
            }
            pasaModal();
            $("#lblident").html('actualizando');
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}



function InsertDispositivo(  Personal_id,   Conexion,   Tipodisp,   Tipoconexion) {
    var params = {
        Personal_id: Personal_id,
        Conexion: Conexion,
        Tipodisp: Tipodisp,
        Tipoconexion: Tipoconexion
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "Personal_Dispositivo.aspx/InsertEmpleadoDisp",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            var lengtDatos = Data.length - 1;
            var datos = '';
            for (var i = 0; i <= lengtDatos; i++) {
               
                datos = Data[i].id + ' ' + Data[i].descripcion;
            }
            if (datos == '') {
                datos == 'No se Insertaron los datos'
            }
            alert(datos);
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}



function Actualizadispositivo(  id,  Personal_id,   Conexion,   Tipodisp,   Tipoconexion) {
    var params = {
        id: id,
        Personal_id: Personal_id,
        Conexion: Conexion,
        Tipodisp: Tipodisp,
        Tipoconexion: Tipoconexion
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "Personal_Dispositivo.aspx/UpdateEmpleadoDisp",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            var lengtDatos = Data.length - 1;
            var datos = '';
            for (var i = 0; i <= lengtDatos; i++) {

                datos = Data[i].id + ' ' + Data[i].descripcion;
            }
            if (datos=='') {
                datos == 'No se Insertaron los datos'
            }
            alert(datos);
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


function EliminarDispositivos(id) {
    var params = {
        id: id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "Personal_Dispositivo.aspx/DeleteEmpleadoDisp",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            var lengtDatos = Data.length - 1;
            var datos = '';
            for (var i = 0; i <= lengtDatos; i++) {

                datos = Data[i].id + ' ' + Data[i].descripcion;
            }
            if (datos == '') {
                datos == 'No se Insertaron los datos'
            }
            alert(datos);
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}

