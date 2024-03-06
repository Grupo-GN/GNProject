var lengthDatosCab
var DataCab
function getListHE(  Planilla_Id,   Periodo_Id,   Localidad_Id,   id_personal) {
    var acutardanzas = 0;
    var params = {
        Planilla_Id: Planilla_Id,
        Periodo_Id: Periodo_Id,
        Localidad_Id: Localidad_Id,
        id_personal: id_personal
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CaReporteHE.aspx/Lista_HoraExtra",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            Cargando();
            DataCab = response.d;
            $('#tbodyReporte').html('');
            lengthDatosCab = DataCab.length - 1;
            var acum = 0;
            var tempHE = 0;
            for (var i = 0; i <= lengthDatosCab; i++) {
                var html = '<tr>';
               
                html += '<td style="text-align:center;"><input  id="chktd" type="checkbox" value="' + DataCab[i].Asistencia_Id + '" /></td>';
                html += '<td style="display:none;">' + DataCab[i].Asistencia_Id + '</td>';
                html += '<td style="display:none;">' + DataCab[i].Personal_Id + '</td>';
                html += '<td>' + DataCab[i].Personal + '</td>';
                html += '<td>' + DataCab[i].fecha_asistencia  + '</td>';
                html += '<td>' + DataCab[i].HoraInicioHorario + '</td>';
                html += '<td>' + DataCab[i].HoraFinalHorario + '</td>';
                html += '<td>' + DataCab[i].Hora_Ingreso + '</td>';
                html += '<td>' + DataCab[i].Hora_Salida + '</td>';
                html += '<td>' + DataCab[i].HETotal + '</td>';
                html += '<td>' + DataCab[i].HESimples + '</td>';
                html += '<td>' + DataCab[i].HEAdicionales + '</td>';
                html += '<td>' + DataCab[i].HEDobles + '</td>';
                html += '<td>' + DataCab[i].Planilla + '</td>';
                html += '<td style="display:none;">' + DataCab[i].Periodo + '</td>';
                html += '<td>' + DataCab[i].Localidad + '</td>';
                html += '<td>' + DataCab[i].Area + '</td>';
                html += '<td style="display:none;">' + DataCab[i].CatAuxiliar2 + '</td>';
                
                html += '<td><select id="cboTipo" class="cbo"><option value="01">HE.Pagadas</option><option value="02">Compensadas</option></select></td>';
                //html += "<td width='20px;'>" + "<select id='cbotipo' class='cbo' onchange='pasar_valor(this.value)'>" + "<option selected value='1'>0</option>" + "<select/>"
                //$('<option value="">-TODOS-</option>').appendTo('#cboLocalidad');
                //acutardanzas = acutardanzas + DataCab[i].cantida;
                html += '</tr>';
                var hora = DataCab[i].HETotal;
                // Dividir en partes
                var parts = hora.split(':');
                // Calcular minutos (horas * 60 + minutos)
                var total = parseInt(parts[0]) * 60 + parseInt(parts[1]);
                acum = acum + total;
                $(html).appendTo('#tbodyReporte');
            }
            tempHE = displayHE(acum);
            $('#lbl0HET').html(tempHE);
            //document.getElementById("lblcantminutosT").value = acutardanzas;
            //$('#lblcantminutosT').html(acutardanzas);
            //document.getElementById("lblcanthorasT").value = acutardanzas / 60;
            //$('#lblcanthorasT').html(Math.round(acutardanzas / 60));  


        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}

var perso2 = [];
 
function SelectData() {
    //var valores = [];
    perso2 = [];
 
    $('#tbodyReporte input[type="checkbox"]').each(function () {
        if ($(this).prop('checked') == true) {
            //valores.push($(this).find("#cnt").html());
            for (var i = 0; i <= lengthDatosCab; i++) {
                if (DataCab[i].fecha_asistencia == $(this).parents("tr").find("td").eq(4).html() && DataCab[i].Personal_Id == $(this).parents("tr").find("td").eq(2).html()) {

                    perso2.push(
                          DataCab[i].Asistencia_Id + ","
                         +DataCab[i].Personal_Id + ","
                         +DataCab[i].Personal + ","
                         +DataCab[i].fecha_asistencia + "," 
                         +DataCab[i].HoraInicioHorario + ","
                         +DataCab[i].HoraFinalHorario + ","
                         +DataCab[i].Hora_Ingreso + ","
                         +DataCab[i].Hora_Salida + ","
                         +DataCab[i].HETotal + ","
                         +DataCab[i].HESimples + ","
                         +DataCab[i].HEAdicionales + ","
                         +DataCab[i].HEDobles + ","
                         +DataCab[i].Planilla + ","
                         +DataCab[i].Periodo + ","
                         +DataCab[i].Localidad + ","
                         +DataCab[i].Area + ","
                         + DataCab[i].CatAuxiliar2 + ","
                         + $(this).parents("tr").find("#cboTipo").val())
                }
            }
        }// fin de recorrido de filas seleccionadas        
    });
   
    //alert(perso2);
    var params = {

        Rlist: perso2
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CaReporteHE.aspx/Insert_Bolsa_HE",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var data = response.d;

            var mens = data[0];
            if (mens == '0') {
                llamamodalInfo('Alerta', 'No se registraron los datos.!', 'Aceptar');
            } else {
                llamamodalSus('Mensaje', 'Se registraron los datos con éxito.!', 'Aceptar');
            }

        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
 
}
 

$(document).ready(function () {
    $('#chkAll').change(function () {
        $('#tbodyReporte input[type="checkbox"]').prop('checked', $(this).prop('checked'));
        
    });

    //$("#tbodyCompT").click(function () {
    //    selectTardanza();
    //});
    $('#btnAplicar').click(function () {
        SelectData();
        getListHE($('#cboPlanilla').val(), $('#cboPeriodo').val(), $('#cboLocalidad').val(), $('#cboPersonal').val());
    });

    //$('#dialog-Justificacion').hide();
    //$('#dialog-vaciones').hide();
    //$('#dialog-Permisos').hide();
    $('#tabContainer').tabs();

    $('#btnGenera').click(function () {
      
        GetListaBolsaHorasComp($('#cboPersonal').val());
        
    });


});


function llamamodalSus(titulo, mensaje, btn1) {
    swal({
        title: titulo,
        text: mensaje,
        type: "success",
        showCancelButton: false,
        confirmButtonColor: '#3085d6',
        confirmButtonText: 'Aceptar',

    });
}
function llamamodalInfo(titulo, mensaje, btn1) {
    swal({
        title: titulo,
        text: mensaje,
        type: "info",
        showCancelButton: false,
        confirmButtonColor: '#3085d6',
        confirmButtonText: 'Aceptar',

    });
}

function llamamodal_2(titulo, mensaje, btn1) {
    swal({
        title: titulo,
        text: mensaje,
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: btn1,

        cancelButtonText: "Cancelar"
    });
}


var lengthDatosHE
var DataHE
function GetListaBolsaHorasComp(id_personal) {
    var acutardanzas = 0;
    var params = {
        
        id_personal: id_personal
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CaReporteHE.aspx/ListaBolsaHorasComp",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            Cargando();
            DataHE = response.d;
            $('#tbodyReporte2').html('');
            lengthDatosHE = DataHE.length - 1;
            var acum = 0;
            var tempHE = 0;
            for (var i = 0; i <= lengthDatosHE; i++) {
                var html = '<tr>';

               
                html += '<td>' + DataHE[i].Personal + '</td>';
                html += '<td>' + DataHE[i].fecha_asistencia + '</td>';
                html += '<td>' + DataHE[i].HoraInicioHorario + '</td>';
                html += '<td>' + DataHE[i].HoraFinalHorario + '</td>';
                html += '<td>' + DataHE[i].Hora_Ingreso + '</td>';
                html += '<td>' + DataHE[i].Hora_Salida + '</td>';
                html += '<td>' + DataHE[i].HETotal + '</td>';
                html += '<td>' + DataHE[i].HESimples + '</td>';
                html += '<td>' + DataHE[i].HEAdicionales + '</td>';
                html += '<td>' + DataHE[i].HEDobles + '</td>';
                html += '<td style="display:none;">' + DataHE[i].Planilla + '</td>';
                html += '<td style="display:none;">' + DataHE[i].Periodo + '</td>';
                html += '<td>' + DataHE[i].Localidad + '</td>';
                html += '<td>' + DataHE[i].Area + '</td>';
                html += '<td style="display:none;">' + DataHE[i].CatAuxiliar2 + '</td>';
                html += '<td>' + DataHE[i].fecha_registro + '</td>';
                html += '<td>' + DataHE[i].Estado + '</td>';
                html += '<td>' + DataHE[i].Tipo + '</td>';
                html += '</tr>';
                var hora = DataHE[i].HETotal;

                // Dividir en partes
                var parts = hora.split(':');

                // Calcular minutos (horas * 60 + minutos)
                var total = parseInt(parts[0]) * 60 + parseInt(parts[1]);
                acum = acum + total;
                $(html).appendTo('#tbodyReporte2');

            }
            tempHE = displayHE(acum);
            $('#lblHET').html(tempHE);
            //document.getElementById("lblcantminutosT").value = acutardanzas;  
            //$('#lblcantminutosT').html(acutardanzas);
            //document.getElementById("lblcanthorasT").value = acutardanzas / 60;
            //$('#lblcanthorasT').html(Math.round(acutardanzas / 60));

            //dato a convertir
           

        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}
function Cargando() {
    $(".loader-page").show("slow");

    setTimeout(function () {
        $(".loader-page").css({ visibility: "hidden", opacity: "0" })
    }, 2000);
}


function restarHoras(inicio, fin) {
 
    inicioMinutos = parseInt(inicio.substr(3, 2));
    inicioHoras = parseInt(inicio.substr(0, 2));

    finMinutos = parseInt(fin.substr(3, 2));
    finHoras = parseInt(fin.substr(0, 2));

    transcurridoMinutos = finMinutos - inicioMinutos;
    transcurridoHoras = finHoras - inicioHoras;

    if (transcurridoMinutos < 0) {
        transcurridoHoras--;
        transcurridoMinutos = 60 + transcurridoMinutos;
    }

    horas = transcurridoHoras.toString();
    minutos = transcurridoMinutos.toString();

    if (horas.length < 2) {
        horas = "0" + horas;
    }

    if (horas.length < 2) {
        horas = "0" + horas;
    }

    //document.getElementById("resta").value = horas + ":" + minutos;

}
function displayHE(a) {
    var hours = Math.trunc(a / 60);
    var minutes = a % 60;
    return(hours + ":" + minutes);
}



// data nueva



function Get_Planilla_List() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Planilla_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPlanilla').html('');
            for (var i = 0; i <= lengthd; i++) {
                if (NivelAcceso_Proc != "04") {
                    $('<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPlanilla');
                }
                else {
                    if (Data[i].Planilla_Id == Planilla_Id_Proc) {
                        $('<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPlanilla');
                        break;
                    }
                }
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function Get_Periodo_Activo_By_CA(Planilla_Id) {
    var params = {
        Planilla_Id: Planilla_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Periodo_Activo_By_CA",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPeriodo').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Periodo_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPeriodo');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function Get_Localidad_List() {
    var Personal_Id = Personal_Proc;
    var params = {
        Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Localidad_List_New",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboLocalidad').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Area_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboLocalidad');
            }
            if (NivelAcceso_Proc != "04") {
                $('<option value="">-TODOS-</option>').appendTo('#cboLocalidad');
                $('#cboLocalidad').val('');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });
};

function Get_Categoria_Auxiliar_List() {
    var Personal_Id = Personal_Proc;
    var params = {
        Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Categoria_Auxiliar_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoriaAux').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria_Auxiliar_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoriaAux');
            }
            if (NivelAcceso_Proc != "04") {
                $('<option value="">-TODOS-</option>').appendTo('#cboCategoriaAux');
                $('#cboCategoriaAux').val('');
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });
};

function Get_Categoria_Auxiliar2_List(Cat_Aux) {
    var Personal_Id = Personal_Proc;
    var params = {
        Cat_Aux: Cat_Aux
        , Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Categoria_Auxiliar2_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoriaAux2').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria_Auxiliar2_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoriaAux2');
            }
            if (NivelAcceso_Proc != "04") {
                $('<option value="">-TODOS-</option>').appendTo('#cboCategoriaAux2');
                $('#cboCategoriaAux2').val('');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};

function Get_Categoria_List() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_Categoria_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboCategoria').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Categoria2_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboCategoria');
            }
            $('<option value="" selected>-TODOS-</option>').appendTo('#cboCategoria');
            if (NivelAcceso_Proc != "04") {
                $('#cboCategoria').val('');
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });
};

function Get_PeriodoCA_By_Planilla(Periodo_Id) {
    var params = {
        Periodo_Id: Periodo_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "cReporteGeneral.aspx/Get_PeriodoCA_By_Planilla",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            for (var i = 0; i <= lengthd; i++) {

                //$("#txtFechaInicio").datepicker("setDate", formatFecha.dmy(Data[0].Date_Inicio.toDateFormat()));
                //$("#txtFechaFinal").datepicker("setDate", formatFecha.dmy(Data[0].Date_Fin.toDateFormat()));


            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#divError').html(XmlHttpError.responseText);
   },
        async: false
    });

};

var PersonalSelec = [];

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
        url: "cReporteGeneral.aspx/Get_Personal_By_Filtros",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPersonal').html('');
            PersonalSelec = [];
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Personal_Id + '">' + Data[i].PersonalName + '</option>').appendTo('#cboPersonal');
                PersonalSelec.push(Data[i].Personal_Id);
                 
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

function Get_Planilla_Find() {
    return $('#cboPlanilla').val();
};
function Get_Periodo_Find() {
    return $('#cboPeriodo').val();
};
function Get_Localidad_Find() {
    return $('#cboLocalidad').val();
};
function Get_CategoriaAux_Find() {
    return $('#cboCategoriaAux').val();
};

function Get_CategoriaAux2_Find() {
    return $('#cboCategoriaAux2').val();
};
function Get_Categoria_Find() {
    return $('#cboCategoria').val();
};


