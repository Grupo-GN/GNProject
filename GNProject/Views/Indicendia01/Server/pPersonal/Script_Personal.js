function Get_Personal_List(Nombres, Area_Id, Estado_Id, inicio) {    
    var params = {
        Nombres: Nombres,
        Area_Id: Area_Id,
        Estado_Id: Estado_Id,
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sPersonal.aspx/Get_Personal_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#tbodyPersonal').html('');


            for (var i = 0; i <= lengthD; i++) {
                var Estado_Id = Datos[i].Estado_Id;
                var estado = Estado_Id == '01' ? 'ACTIVO' : 'INACTIVO';

                var btitle = Estado_Id == '01' ? 'Desactivar Personal' : 'Activar Personal';
                var bclass = Estado_Id == '01' ? 'buttonDesactiva' : 'buttonActiva';
                var styleTr = Estado_Id == '01' ? '' : 'style="color:Red;"';
                var html = '<tr >';
                html += '<td style="width:10px;"><input type="button" class="buttonEdit" id="e' + Datos[i].Personal_Id + '" title="Editar Personal"  /></td>';
                html += '<td style="width:10px;"><input type="button" class="' + bclass + '"  id="d' + Datos[i].Personal_Id + '" title="' + btitle + '" /></td>';
                html += '<td ' + styleTr + '>' + Datos[i].Nombres + '</td>';
                html += '<td ' + styleTr + '>' + Datos[i].RH_Area + '</td>';
                html += '<td ' + styleTr + '>' + Datos[i].Cargo + '</td>';
                html += '<td ' + styleTr + '>' + Datos[i].CatAux + '</td>';
                html += '<td ' + styleTr + '>' + Datos[i].CatAux2 + '</td>';
                html += '<td ' + styleTr + '>' + estado + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyPersonal');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: true
    });

    var params2 = {
        Nombres: Nombres,
        Area_Id: Area_Id,
        Estado_Id: Estado_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params2),
        dataType: "json",
        url: "sPersonal.aspx/Get_Personal_List_MaxRows",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var MaxRows = response.d;
            $('#txtnRegistros').val(MaxRows);
        },
        error:
        function (XmlHttpError, error, description) {
            $("#divError").html(XmlHttpError.responseText);
        },
        async: true
    });


};


function Get_Personal_Find(Personal_id) {
    var params = {
        Personal_id: Personal_id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sPersonal.aspx/Get_Personal_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var PersonalO = response.d;
            if (PersonalO) {
                TIPOPROCESO = '02';
                Personal_Proc = Personal_id;
                $('#txtCodigo').val(PersonalO.Personal_Id);
                $('#txtApePat').val(PersonalO.Apellido_Paterno);
                $('#txtApeMat').val(PersonalO.Apellido_Materno);
                $('#txtNombres').val(PersonalO.Nombres);
                $('#txtNroDoc').val(PersonalO.Nro_Doc);
                $('#txtemail').val(PersonalO.email);
                
                $('#txtFechaNaci').val(PersonalO.Fecha_Nacimiento.toDateformat());
                $('#cboPlanilla').val(PersonalO.Planilla_Id);
                $('#cboCargo').val(PersonalO.Cargo_Id);

                $('#cboLocalidad').val(PersonalO.Area_Id);

                $('#cboCategoriaAuxiliar').val(PersonalO.Categoria_Auxiliar_Id.trim());
                Get_Categoria_Auxiliar2_Combo();
                $('#cboCategoriaAuxiliar2').val(PersonalO.Categoria_Auxiliar2_Id.trim());

                $('#cboEstado').val(PersonalO.Estado_Id);

                $('#txtCodigoLG').val(PersonalO.CodigoLG);

                $('#cboRolSistema').val(PersonalO.RolSistema);
                $('#tabContainer').tabs('enable');
                $('#tabContainer').tabs('option', 'active', 1);

            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });


    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sPersonal.aspx/Get_Usuario_Personal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var PersonalU = response.d;
            if (PersonalU) {
                $('#txtUsuario').val(PersonalU.Name);
                $('#txtContraseñaU').val(PersonalU.Password);


                if (PersonalU.Estado == '01') {
                    $('#rdAcceso').prop('checked', true);
                } else {
                    $('#rdNoAcceso').prop('checked', true);

                }
            } else {
                $('#txtUsuario').val('');
                $('#txtContraseñaU').val('');
                $('#rdAcceso').prop('checked', false);
                $('#rdNoAcceso').prop('checked', false);
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

    /* CARGAR FOTO */
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sPersonal.aspx/Get_Foto_By_Personal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var FotoName = response.d;
            if (FotoName) {
                $('#imgPersonal').attr('src', '../../FotosPersonal/' + FotoName);
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });


};



function Get_Add_Personal(Planilla_Id, Apellido_Paterno, Apellido_Materno, Nombres, Fecha_Nacimiento, Nro_Doc, email, Cargo_Id
                , Area_Id, Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id, CodigoLG, Estado_Id, RolSistema) {
    var params = {
        Planilla_Id: Planilla_Id,
        Apellido_Paterno: Apellido_Paterno,
        Apellido_Materno: Apellido_Materno,
        Nombres: Nombres,
        Fecha_Nacimiento: Fecha_Nacimiento,
        Nro_Doc: Nro_Doc,
        email: email,
        Cargo_Id:Cargo_Id,
        Area_Id:Area_Id,
        Categoria_Auxiliar_Id:Categoria_Auxiliar_Id,
        Categoria_Auxiliar2_Id:Categoria_Auxiliar2_Id,
        CodigoLG:CodigoLG,
        Estado_Id:Estado_Id,
        RolSistema:RolSistema
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sPersonal.aspx/Get_Add_Personal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if(Proceso.indexOf('#')!=-1){
                var Resultado=Proceso.split('#')[0];
                var mensaje=Proceso.split('#')[1];
                    if(Resultado=='true'){
                        alert(mensaje);
                        $('#tabContainer').tabs('option','disabled',[1]);
                        $('#tabContainer').tabs('option', 'active', 0);
                        Get_Personal_List(Get_Nombres_Find(), Get_Localidad_Find(), Get_Estado_Find(), inicio);
                    }else{
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Get_Update_Personal(Personal_Id, Planilla_Id, Apellido_Paterno, Apellido_Materno, Nombres, Fecha_Nacimiento, Nro_Doc, email, Cargo_Id
                , Area_Id, Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id, CodigoLG, Estado_Id, RolSistema,Name,Password,Estado_Usuario) {
    var params = {
        Personal_Id: Personal_Id,
        Planilla_Id: Planilla_Id,
        Apellido_Paterno: Apellido_Paterno,
        Apellido_Materno: Apellido_Materno,
        Nombres: Nombres,
        Fecha_Nacimiento: Fecha_Nacimiento,
        Nro_Doc: Nro_Doc,
        email: email,
        Cargo_Id: Cargo_Id,
        Area_Id: Area_Id,
        Categoria_Auxiliar_Id: Categoria_Auxiliar_Id,
        Categoria_Auxiliar2_Id: Categoria_Auxiliar2_Id,
        CodigoLG: CodigoLG,
        Estado_Id: Estado_Id,
        RolSistema: RolSistema,
        Name: Name,
        Password: Password, 
        Estado_Usuario: Estado_Usuario
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sPersonal.aspx/Get_Update_Personal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado='true') {
                        alert(mensaje);
                        $('#tabContainer').tabs('option', 'disabled', [1]);
                        $('#tabContainer').tabs('option', 'active', 0);
                        Get_Personal_List(Get_Nombres_Find(), Get_Localidad_Find(), Get_Estado_Find(), inicio);
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Get_DeleteEstado_Personal(Personal_Id, Estado_Id) {
    var params = {
        Personal_Id: Personal_Id,
        Estado_Id: Estado_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sPersonal.aspx/Get_DeleteEstado_Personal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                alert('Actualizado Correctamente.');
                Get_Personal_List(Get_Nombres_Find(), Get_Localidad_Find(), Get_Estado_Find(), inicio);
            } else {
                alert('.::Error, Intentelo luego.');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};























function Get_Localidad_Find() {
    return $('#cboLocalidadFind').val() == null ? '' : $('#cboLocalidadFind').val();
};

function Get_Nombres_Find() {
    var nombres = $('#txtNombresFind').val();
    var newnombres = '';
    if (nombres.indexOf(' ') != -1) {
        var ar = nombres.split(' ');
        for (var i = 0; i <= ar.length - 1; i++) {
            newnombres += ar[i].toString().trim();
        }
        nombres = newnombres;
    }
    return nombres;
};

function Get_Estado_Find() {
    return $('#cboEstadoFind').val();
};


function clear_Tab() {
    $('#txtCodigo').val('');
    $('#txtApePat').val('');
    $('#txtApeMat').val('');
    $('#txtNombres').val('');
    $('#txtNroDoc').val('');
    $('#txtFechaNaci').val('');
    $('#txtemail').val('');
    
    $('#cboPlanilla').val('01');
    $('#cboCargo').val('000');

    $('#cboLocalidad').val('03');

    $('#cboCategoriaAuxiliar').val('00');
    Get_Categoria_Auxiliar2_Combo();
    $('#cboEstado').val('01');
    $('#txtCodigoLG').val('');
    $('#cboRolSistema').val('02');

    $('#txtUsuario').val('');
    $('#txtContraseñaU').val('');

    $('#rdAcceso').prop('checked', true);
    $('#rdNoAcceso').prop('checked', false);
    $('#imgPersonal').attr('src', '../../FotosPersonal/UserNoPhoto.png');

};



function uploadFile() {
    if (Personal_Proc) {
        var archivos = document.getElementById("fileToUpload");
        var archivo = archivos.files;
        var idFile = 1;

        for (var i = 0; i < archivo.length; i++) {

            var xhr = new XMLHttpRequest();
            var fd = new FormData();

            fd.append('file', archivo[i]);
            fd.append('name', Personal_Proc);

            xhr.open('POST', 'AjaxUploadFile.ashx/ProcessRequest', false);
            xhr.onload = function (e) {
                if (this.status == 200) {
                    var rsc = this.responseText;
                    if (rsc != '0') {
                        alert('Foto Guardada correctamente.');
                        $('#imgPersonal').attr('src', '../../FotosPersonal/' + rsc);
                    }
                }
            };

            xhr.send(fd);
            idFile += 1;
        }

        document.getElementById("fileToUpload").value = null;
    } else {
    alert('El Personal debe esta registrado.');
    }
}




//FECHAS

var formatFecha = {
    format1: function (fecha) {

        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = arr1[0].split('/');
            return arr[2] + '-' + arr[1] + '-' + arr[0];
        } else {
            var arr = fecha.split('/');
            return arr[2] + '-' + arr[1] + '-' + arr[0];
        }

    },
    format2: function (fecha) {
        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = arr1[0].split('/');
            return arr[0] + '-' + arr[1] + '-' + arr[2];
        } else {
            var arr = fecha.split('/');
            return arr[0] + '-' + arr[1] + '-' + arr[2];
        }
    },
    format3: function (fecha) {

        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = arr1[0].split('/');
            return arr[0] + '/' + arr[1] + '/' + arr[2];
        } else {
            var arr = fecha.split('/');
            return arr[0] + '/' + arr[1] + '/' + arr[2];
        }
    }
};





String.prototype.toDateformat = function () {

    if (this) {
        var dte = eval("new " + this.replace(/\//g, '') + ";");

        dte.setMinutes(dte.getMinutes() - dte.getTimezoneOffset());
        //  dateFormat(dte, "yyyy-MM-dd HH:mm:ss");
        var ret = dateDemo(dte);
        //return dte;
        return ret;
    } else {
        return '';
    }
};

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


    var fechaWPP = Dia + "/" + Mes + "/" + Anio ;


    return fechaWPP;
};



String.prototype.padLeft = function (paddingChar, length) {

    var s = new String(this);

    if ((this.length < length) && (paddingChar.toString().length > 0)) {
        for (var i = 0; i < (length - this.length); i++)
            s = paddingChar.toString().charAt(0).concat(s);
    }

    return s;
};

