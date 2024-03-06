//funcion listar turnos

function Get_Horarios_List(inicio) {
    var params = {
        inicio: inicio
    };
   
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MHorarios.aspx/Get_Horarios_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;

            $('#tbodyHorarios').html('');


            var lengtDatos = Data.length - 1;
            for (var i = 0; i <= lengtDatos; i++) {
                var html = '<tr>';
                var fechamod=Data[i].Fecha_Modificacion==null?'':Data[i].Fecha_Modificacion.toDateShort();

                html += '<td><input id="btnEdit' + Data[i].Horario_Id + '" type="button"  value=""  class="buttonEdit" title="Editar Horario" /></td>';
                html += '<td><input id="btnSelect' + Data[i].Horario_Id + '" type="button"  value=""  class="buttonDetalle" title="Seleccionar Horario" /></td>';
                html += '<td>' + Data[i].Nombre + '</td>';
                html += '<td>' + Data[i].Fecha_Creacion.toDateShort() + '</td>';
                html += '<td>' + fechamod + '</td>';
                html += '</tr>';

                $(html).appendTo('#tbodyHorarios');
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

}

//funcion listar detalle horarios

function Get_DetalleHorarios_List(Horario_Id) {
    var params = {
        Horario_Id: Horario_Id
    };
   
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MHorarios.aspx/Get_DetalleHorarios_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;       
                 
            $('#tbodyHDetalle').html('');

           var lengtDatos = Data.length - 1;
           for (var i = 0; i <= lengtDatos; i++) {
           var diaNom=Set_NombreDias(Data[i].Dia);
         
                var html = '<tr>';
                //modidga//aumentar id="'+diaNom+'">' 
                html += '<td style="text-align:left"><label class="miLabel" style="width:50%;" id="'+diaNom+'">'+ diaNom +'</label></td>';
                html += '<td style="text-align:left;"><input type="text" class="txt" style="width:180px;" value="' + Data[i].HoraInicio.substring(11, 16) + '" /></td></td>';
                html += '<td style="text-align:left;"><input type="text" class="txt" style="width:180px;" value="' + Data[i].HoraInicioRefrigerio.substring(11, 16) + '" /></td></td>';
                html += '<td style="text-align:left;"><input type="text" class="txt" style="width:180px;" value="' + Data[i].HoraFinRefrigerio.substring(11, 16) + '" /></td></td>';
                html += '<td style="text-align:left;"><input type="text" class="txt" style="width:180px;" value="' + Data[i].HoraFin.substring(11, 16) + '" /></td></td>';
                
                html += '</tr>';
                $(html).appendTo('#tbodyHDetalle');
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form2').html(XmlHttpError.responseText);
   },
        async: false
    });

}

function Set_NombreDias(NroDias){
    var Nomnre='';
    var nr=parseInt(NroDias);
    switch(nr){
        case 1: Nomnre='Lunes' ; break;
        case 2: Nomnre='Martes' ;break;
        case 3: Nomnre='Miercoles' ;break;
        case 4: Nomnre='Jueves' ;break;
        case 5: Nomnre='Viernes' ;break;
        case 6: Nomnre='Sabado' ;break;
        case 7: Nomnre='Domingo' ;break;

    }
    return Nomnre;

}

//funcion buscar y cargar turnos por codigo
function Get_Horarios_Find(codigo) {
    var params = {
        codigo: codigo
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MHorarios.aspx/Get_Horarios_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                $('#txtCodigo').val(Data.Horario_Id);
                $('#txtNombre').val(Data.Nombre);
                //$('#txtFCreacion').val(Data.Fecha_Creacion.toString());
                //$('#txtFModificacion').val(Data.Fecha_Modificacion.toString());
            }

        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: true
    });

}


////////////////////////////////////////////////////////////////////////////////////////



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

    var fechaWPP = Dia + "/" + Mes + "/" + Anio ;

    return fechaWPP;
}





//actualizar turno
function Get_Horarios_Update(codigo, nombre) {
    var params = {
        codigo: codigo,
        nombre: nombre,
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "MHorarios.aspx/Get_Horarios_Update",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert('Horario modificado correctamente.')
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });
}



    //Get_Carac_MaxRegistro(Carac_Nombre,Carac_Opcion,Estado)
function Get_Horarios_MaxRegistro() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "MHorarios.aspx/Get_Horarios_MaximoRegistros",
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

//obtener fecha del sistema

var f = new Date();
var fechasistema=f.getDate() + "/" + (f.getMonth() +1) + "/" + f.getFullYear();







//funciones de fechas
String.prototype.toDatelong = function () {
    var dte = eval("new " + this.replace(/\//g, '') + ";");

    dte.setMinutes(dte.getMinutes() - dte.getTimezoneOffset());
   
    var ret = dateDemo(dte);
   
    return ret;
}

String.prototype.toHoMin = function () {
    var dte = eval("new " + this.replace(/\//g, '') + ";");

    //dte.setMinutes(dte.getMinutes() - dte.getTimezoneOffset());
    dte.setMinutes(dte.getUTCMinutes() - dte.getTimezoneOffset());
    

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

function Get_Horarios_Add(nombre) {
    param =
         { 
             nombre: nombre
         };
    $.ajax({
        type: "POST",
        data: JSON.stringify(param),
        dataType: "json",
        url: "MHorarios.aspx/Get_Horarios_Add",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert('Horario grabado correctamente.')
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });
}


//modidga//
function Get_Horarios_Deta_Update(Horario_Id, Dia, hi, hir, hfr, hf){
param={Horario_Id:Horario_Id,
    Dia:Dia,
    hi:hi,
    hir:hir,
    hfr:hfr,
    hf:hf};
    $.ajax({
        type: "POST",
        data: JSON.stringify(param),
        dataType: "json",
        url: "MHorarios.aspx/Get_Horarios_Deta_Update",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
           
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form2').html(XmlHttpError.responseText);
   },
        async: true
    });
}


function Get_DetalleHorarios_Add(HoraInicio,HoraInicioRefrigerio,HoraFinRefrigerio,HoraFin) {
    param =
         { 
             HoraInicio: HoraInicio,
             HoraInicioRefrigerio: HoraInicioRefrigerio,
             HoraFinRefrigerio: HoraFinRefrigerio,
             HoraFin: HoraFin
         };
    $.ajax({
        type: "POST",
        data: JSON.stringify(param),
        dataType: "json",
        url: "MHorarios.aspx/Get_DetalleHorarios_Add",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            alert('Detalle de horario grabado correctamente.')
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form2').html(XmlHttpError.responseText);
   },
        async: true
    });
}