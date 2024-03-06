/// <reference path="../../caReporteGeneral/ControlAsistencia.aspx" />

function Get_Planillas_List() {
    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "../caReporteGeneral/ControlAsistencia.aspx/Get_Planillas_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#cboPlanilla').html('');
            var lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboPlanilla');
            }
            $('#cboPlanilla').val('01');
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}


function Get_Localidades_List() {

    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "../caReporteGeneral/ControlAsistencia.aspx/Get_Localidades_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#cboLocal').html('');

            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {

                var html = '<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>';
                $(html).appendTo('#cboLocal');

            }
            $('<option value="">-TODOS-</option>').appendTo('#cboLocal');
            $('#cboLocal').val('');

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}

function List_Periodo(Plantilla) {
    var params = {
        Plantilla: Plantilla
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "../caReporteGeneral/ControlAsistencia.aspx/List_Periodo",
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
        async: false
    });

}


function Get_Personal_By_Filtros(Periodo_Id, Localidad_Id, CategoriaAux, CategoriaAux2, Categoria) {
    var Personal_Id = Personal_Proc;
    var params = {
        Periodo_Id: Periodo_Id,
        Localidad_Id: Localidad_Id,
        CategoriaAux: CategoriaAux,
        CategoriaAux2: CategoriaAux2,
        Categoria: Categoria
        , Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "../caReporteGeneral/ControlAsistencia.aspx/Get_Personal_By_Filtros",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPersonal').html('');
            PersonalSelec = [];
            PersonalSelecbk = [];
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Personal_Id + '">' + Data[i].PersonalName + '</option>').appendTo('#cboPersonal');
                PersonalSelec.push(Data[i].Personal_Id);
                PersonalSelecbk.push(Data[i].Personal_Id);
            }
            if (NivelAcceso_Proc != "04") {
                $('<option value="">-TODOS-</option>').appendTo('#cboPersonal');
                $('#cboPersonal').val('');
            } else {
                $('<option value="--">-SELECCIONAR-</option>').appendTo('#cboPersonal');
                $('#cboPersonal').val('--');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};




var DataL;
var lengtL;

function ListaUsuarios(Planilla_Id, Periodo_Id, Localidad_Id, Personal_Id) {


    var params = {
        Planilla_Id: Planilla_Id,
        Periodo_Id: Periodo_Id,
        Localidad_Id: Localidad_Id,
        Personal_Id: Personal_Id
      
    };


    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "Reg_Usuario.aspx/ListUsuariosNN",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            DataL = response.d;
            lengtL = DataL.length - 1;
            $('#tbodyNovedades').html('');

            for (var i = 0; i <= lengtL; i++) {
                var acu_falta = 0;
                var Acu_Tarde = 0;
                var Acu_Asis = 0;
                var acu_dom = 0;
                var asistencia = 0;
                var html = '<tr>';
                html += '<td style="text-align:center;"><input type="checkbox" value="' + DataL[i].Personal_Id + '/' + DataL[i].Usuario + '" /></td>';
                html += '<td >' + DataL[i].PersonalNombres + '</td>';
                html += '<td >' + DataL[i].Usuario + '</td>';
                html += '<td >' + DataL[i].Clave + '</td>';
                var dataacceso = '';
                if (DataL[i].nivelacceso == '01') {
                   dataacceso='Administrador';  
                }
                if (DataL[i].nivelacceso == '02') {
                    dataacceso = 'Recursos Humanos';
                }

                if (DataL[i].nivelacceso == '03') {
                   
                    dataacceso = 'Jefatura';
                }

                if (DataL[i].nivelacceso == '04') {
                    dataacceso = 'Empleado';
                }


               html += '<td>' + dataacceso + '</td>';
               html += '<td class="tbodyLink"><input id="btnEdit' + DataL[i].Personal_Id + '/' + DataL[i].Usuario + '" type="button"  value=""  class="ElLinkEditar" title="Editar Usuario" /></td>';


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

function closeModalDiv() {
    $('#dialog-form').dialog('close');
}

function pasaModal() {

    $("#dialog-form").dialog({
        height: 340, width: 460, modal: true, autoOpen: true,
        appendTo: "form", title: "EDICION DE USUARIOS",
        show: { effect: "fade", duration: 800 },
        hide: { effect: "fold", duration: 800 }
    });
}

function Get_Usuarios_Find(codigo) {
    var params = {
        codigo: codigo
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "Reg_Usuario.aspx/ListaUsuariosFind",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            var lengtDatos = Data.length - 1;
            if (Data.length <= 0) {
                alert('Debe Registrar El usuario para Poder Editarlo');
                return false;
            }
            for (var i = 0; i <= lengtDatos; i++) {
                $('#txtCodigo').val(Data[i].Personal_Id);
                $('#txtnombre').val(Data[i].PersonalNombres);
                $('#txtusuario').val(Data[i].Usuario);
                $('#txtclave').val(Data[i].Clave);
                $('#cboestado').val(Data[i].nivelacceso);
            }
            pasaModal();
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}




function pasarUsuarios() {
 
    $('#tbodyNovedades input[type="checkbox"]').each(function () {
        if ($(this).prop('checked') == true) {
          
            for (var i = 0; i <= lengtL; i++) {
                if (DataL[i].Personal_Id + '/' + DataL[i].Usuario == $(this).val()) {
                     
                    perso.push(DataL[i].Personal_Id + "," + DataL[i].Usuario + "," + DataL[i].Clave + "," + DataL[i].nivelacceso + "," + "01")
                   
                    personal_id = DataL[i].Personal_Id
                }
            }


        }
    });
   

    var a = personal_id;

    var params = {
        // gereid: a,
        id_personal: a,
        Rlist: perso
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "Reg_Usuario.aspx/Insert_Usuarios",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var data = response.d;
            
            var mens = data[0];
          
            alert(  'Se registraron los datos con éxito.!' );
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });


}

var perso = [];
var personal_id = "";



function ActualizaUsuarios() {
 

    var a = $('#txtCodigo').val().substring(0, 6);
    var b = $('#txtusuario').val();
    var c = $('#txtclave').val();
    var d = $('#cboestado').val();

    var params = {
        // gereid: a,
        Personal_Id:a, Usuario:b, Clave:c, Acceso:d
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "Reg_Usuario.aspx/UpdateUsuarios",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var data = response.d;

            var mens = data[0];

            alert('Se registraron los datos con éxito.!');
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });


}
