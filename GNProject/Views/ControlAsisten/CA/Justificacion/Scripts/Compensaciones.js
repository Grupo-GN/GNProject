//comp tardanza
var lengthDatosTarde
var DataTarde
function getTardanza(  Personal_ID) {
    var acutardanzas=0;
    var params = {
        Personal_ID: Personal_ID
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_Lista_Tardanza",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            DataTarde = response.d;
            $('#tbodyCompT').html('');
            lengthDatosTarde = DataTarde.length - 1;
         
            for (var i = 0; i <= lengthDatosTarde; i++) {
                var html = '<tr>';
                html += '<td style="text-align:center;"><input class="boton" id="chktd" type="checkbox" value="' + DataTarde[i].Marcacion_Id + '" /></td>';
                html += '<td style="display:none;">' + DataTarde[i].Marcacion_Id + '</td>';
                html += '<td style="display:none;">' + DataTarde[i].Personal_Id + '</td>';
                html += '<td>' + DataTarde[i].Nombres + '</td>';
                html += '<td>' + DataTarde[i].fecha + '</td>';
                html += '<td id="cnt">' + DataTarde[i].cantida + '</td>';
                acutardanzas = acutardanzas + DataTarde[i].cantida;
                html += '</tr>';
                $(html).appendTo('#tbodyCompT');
            }
            document.getElementById("lblcantminutosT").value = acutardanzas;
            $('#lblcantminutosT').html(acutardanzas);
            document.getElementById("lblcanthorasT").value = acutardanzas / 60;
            $('#lblcanthorasT').html(Math.round(acutardanzas / 60));
            

        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}
// comp falta
var lengthDatosfalta
var Datafalta
function getFalta(Personal_ID) {
    var acutardanzas = 0;
    var params = {
        Personal_ID: Personal_ID
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Get_Lista_Falta",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            Datafalta = response.d;
            $('#tbodyCompF').html('');
            lengthDatosfalta = Datafalta.length - 1;

            for (var i = 0; i <= lengthDatosfalta; i++) {
                var html = '<tr>';
                html += '<td style="text-align:center;"><input class="boton" id="chktd" type="checkbox" value="' + Datafalta[i].Marcacion_Id + '" /></td>';
                html += '<td style="display:none;">' + Datafalta[i].Marcacion_Id + '</td>';
                html += '<td style="display:none;">' + Datafalta[i].Personal_Id + '</td>';
                html += '<td>' + Datafalta[i].Nombres + '</td>';
                html += '<td>' + Datafalta[i].fecha + '</td>';
                html += '<td id="cnt">' + Datafalta[i].cantida + '</td>';
                acutardanzas = acutardanzas + Datafalta[i].cantida;
                html += '</tr>';
                $(html).appendTo('#tbodyCompF');
            }
          
            $('#lblcantdiasF').html(acutardanzas);
          
            $('#lblcanthorasF').html(Math.round((acutardanzas * 8) ));


        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}

//lista comp cab

var lengthDatosCab
var DataCab
function getCompCab(Personal_ID,rol) {
    var acutardanzas = 0;
    var params = {
        Personal_ID: Personal_ID
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/ListaCompCab",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            DataCab = response.d;
            $('#tbodyCompGeneral').html('');
            lengthDatosCab = DataCab.length - 1;

            for (var i = 0; i <= lengthDatosCab; i++) {
                var html = '<tr>';
                if ((DataCab[i].ESTADO == "PENDIENTE")) {
                     
                    var variableFlat = Get_Variables('1');
                    switch (rol) {
                        case '01':
                            var btnCancel = '<input type="button" class="buttonDesactiva" id="' + DataCab[i].ID + '" title="Cancelar Comp" />';
                            var btnAprob = '<input type="button" class="buttonAprobar" id="' + DataCab[i].ID + '" title="Aprobar Comp." />';
                            break;
                        case '02':
                            if (variableFlat == '1') {
                                var btnCancel = '<input type="button" class="buttonDesactiva" id="' + DataCab[i].ID + '" title="Cancelar Comp" />';
                                var btnAprob = '<input type="button" class="buttonAprobar" id="' + DataCab[i].ID + '" title="Aprobar Comp." />';
                            }  
                            break;
                        case '03':
                            if (variableFlat == '0') {
                                var btnCancel = '<input type="button" class="buttonDesactiva" id="' + DataCab[i].ID + '" title="Cancelar Comp" />';
                                var btnAprob = '<input type="button" class="buttonAprobar" id="' + DataCab[i].ID + '" title="Aprobar Comp." />';
                            } 
                            break;
                     
                    }


                var btnEdit = '<input type="button" class="buttonEdit" id="' + DataCab[i].ID + '" title="Editar Permiso" />';
                }
           
             
                var btnDetalle = '<input type="button" class="buttonDetalle" id="' + DataCab[i].ID + '" title="Ver Detalle" />';

                //html += '<td style="text-align:center;"><input class="boton" id="chktd" type="checkbox" value="' + DataTarde[i].Marcacion_Id + '" /></td>';
                //html += '<td style="display:none;">' + DataTarde[i].Marcacion_Id + '</td>';
                //html += '<td style="display:none;">' + DataTarde[i].Personal_Id + '</td>';
                html += '<td style="text-align:center;">' + btnEdit + '</td>';
                html += '<td style="text-align:center;">' + btnAprob + '</td>';
                html += '<td style="text-align:center;">' + btnCancel + '</td>';
                html += '<td>' + DataCab[i].ID + '</td>';
                html += '<td>' + DataCab[i].FECHA + '</td>';
                html += '<td>' + DataCab[i].M_COMPENSADO + '</td>';
                html += '<td>' + DataCab[i].HORA_COMP + '</td>';
                html += '<td>' + DataCab[i].ESTADO + '</td>';
                html += '<td>' + DataCab[i].MOTIVO + '</td>';
                html += '<td style="text-align:center;">' + btnDetalle + '</td>';
                //acutardanzas = acutardanzas + DataCab[i].cantida;
                html += '</tr>';
                $(html).appendTo('#tbodyCompGeneral');
            }
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

var lengthDatosDet
var DataDet
function getCompDet(id_comp) {
    var acutardanzas = 0;
    var params = {
        id_comp: id_comp
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/ListaCompdet",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            DataDet = response.d;
            $('#tbodydetcomp').html('');
            lengthDatosDet = DataDet.length - 1;

            for (var i = 0; i <= lengthDatosDet; i++) {
                var html = '<tr>';
                            
                html += '<td>' + DataDet[i].FECHA + '</td>';
                html += '<td>' + DataDet[i].HORA_COMP + '</td>';
                html += '<td>' + DataDet[i].ID + '</td>';
 
                html += '</tr>';
                $(html).appendTo('#tbodydetcomp');
            }
      
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}



function Get_UpdateEstado(id_comp,estado) {
    var params = {
        id_comp: id_comp,
        estado: estado

    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/UpdateEstado",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data != '') {
                llamamodalSus('ALERTA', 'SE REALIZARON LOS CAMBIOS CON ÉXITO', 'ACEPTAR');
            } else {
                llamamodalInfo('ALERTA', 'NO SE REALIZARON LOS CAMBIOS', 'ACEPTAR')
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

};


function getListHL(Personal_ID,flat) {
    var lengthDatosHL
    var DataHL
    var acuHL = 0;
    var params = {
        Personal_Id: Personal_ID
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        //url: "GenerarJustificacion.aspx/Get_Lista_HorasLab",
        url: "GenerarJustificacion.aspx/ListHETotal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            DataHL = response.d;
          
            lengthDatosHL = DataHL.length - 1;

            for (var i = 0; i <= lengthDatosHL; i++) {
                 
                //acuHL = DataHL[i].cantida;
                var hora = DataHL[i].HETotal;

                // Dividir en partes
                var parts = hora.split(':');

                // Calcular minutos (horas * 60 + minutos)
                var total = parseInt(parts[0]) * 60 + parseInt(parts[1]);
                acuHL = acuHL + total;
               
            }
      
            if (acuHL <= 0) {
                
              
                document.getElementById('btnNewComp').disabled = true;
                document.getElementById('btnGrabarCompT').disabled = true;
                document.getElementById('btnCancelCompT').disabled = true;

                document.getElementById('btnNewCompF').disabled = true;
                document.getElementById('btnGrabarCompF').disabled = true;
                document.getElementById('btnCancelCompF').disabled = true;

            } else {
                if (flat=="T") {
                    document.getElementById('btnNewComp').disabled = false;
                    document.getElementById('btnGrabarCompT').disabled = false;
                    document.getElementById('btnCancelCompT').disabled = false;

                    document.getElementById('btnNewCompF').disabled = true;
                    document.getElementById('btnGrabarCompF').disabled = true;
                    document.getElementById('btnCancelCompF').disabled = true;
                }
                if (flat=="F") {
                    document.getElementById('btnNewComp').disabled = true;
                    document.getElementById('btnGrabarCompT').disabled = true;
                    document.getElementById('btnCancelCompT').disabled = true;

                    document.getElementById('btnNewCompF').disabled = false;
                    document.getElementById('btnGrabarCompF').disabled = false;
                    document.getElementById('btnCancelCompF').disabled = false;
                }
               
            }
          var  tempHE = displayHE(acuHL);

          $('#lblcanHES1').html(tempHE);
          $('#lblcanHES2').html(tempHE);
          $('#lblcanHE2').html(acuHL);
          $('#lblcanHE').html(acuHL);
         

            //lblcanHES1  lblcanHE2    lblcanHE
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}


function clear_NewCompT() {
   
    perso = [];
    $('#lblFechaCompT').val('');
    $('#txthoratarde').val('');
    $('#txthoracompensadaT').val('');
    $('#lblInfocompensadaT').html('');


    $('#txtMotcompT').val('');
    $('#lblEJefeCompT').html('');
    $('#txtComentJefecompT').val('');
    $('#lblERRHHCompT').html('');
    $('#txtComentRRHHCompT').val('');
    $('#tbodyCompT').html('');

     $('#lblcanHE').html('');
     $('#lblcanHEac').html('');
      $('#lblcanHET').html('');

};

function clear_NewCompF() {


    $('#lblFechaCompF').val('');
    $('#txtFalta').val('');
    $('#txthoracompF').val('');
    $('#lblInfocompF').html('');
    $('#lblInfoFalta').html('');

    $('#txthoracompF').val('');
    $('#txtMotcompF').val('');
    $('#lblJefePF').html('');
    $('#txtComentJefeF').val('');
    $('#txtComentRRHHHoF').val('');
    $('#lblRRHHoF').html('');
    $('#tbodyCompF').html('');
};




function selectTardanza() {
    var perso = [];
    var valores = 0;
    var he = 0;
    var heac = 0;
    var het = 0;
    $('#tbodyCompT input[type="checkbox"]').each(function () {
        if ($(this).prop('checked') == true) {
            perso.push($(this).val());
        }
    });
    if (perso.length == 0) {
        //alert('Seleccione algun personal.');
        //return false;
    }

    $('#tbodyCompT input[type="checkbox"]').each(function () {
        if ($(this).prop('checked') == true) {
            //valores.push($(this).find("#cnt").html());
            for (var i = 0; i <= lengthDatosTarde; i++) {
                if (DataTarde[i].Marcacion_Id == $(this).val()) {
                    //valores.push(DataTarde[i].cantida)
                    valores = valores + DataTarde[i].cantida
                    //var hora = DataTarde[i].cantida;

                    //// Dividir en partes
                    //var parts = hora.split(':');

                    //// Calcular minutos (horas * 60 + minutos)
                    //var total = parseInt(parts[0]) * 60 + parseInt(parts[1]);
                    //valores = valores + total;
                }
            }

        }
    });

    he = $('#lblcanHE').html(); //Math.round(acutardanzas / 60)
    //heac =Math.round( Math.round(valores / 60));
    heac = Math.round(Math.round(valores  ));
    het = parseInt(he) + parseInt(heac);
    $('#lblcanHEac').html(heac);
    $('#lblcanHET').html(het);
    var a1 = displayHE(heac);
    var a2 = displayHE(het)
    //$('#lblcanHEac1').html(a1);
    $('#lblcanHET1').html(a2);
    if (het <= '0') {
      
        $("#btnNewComp").hide(1500);
    } else {
         
        $("#btnNewComp").show("slow");
    }
   


}

function selectFalta() {
    var perso = [];
    var valores = 0;
    var he = 0;
    var heac = 0;
    var het = 0;
    $('#tbodyCompF input[type="checkbox"]').each(function () {
        if ($(this).prop('checked') == true) {
            perso.push($(this).val());
        }
    });
    if (perso.length == 0) {
        //alert('Seleccione algun personal.');
        //return false;
    }

    $('#tbodyCompF input[type="checkbox"]').each(function () {
        if ($(this).prop('checked') == true) {
            //valores.push($(this).find("#cnt").html());
            for (var i = 0; i <= lengthDatosfalta; i++) {
                if (Datafalta[i].fecha == $(this).parents("tr").find("td").eq(4).html()) {
                    //valores.push(DataTarde[i].cantida)
                    valores = valores + Datafalta[i].cantida

                   

                }
                //id = $(this).parents("tr").find("td").eq(4).html();
                //alert(id);
                //var value = $(this).html();
                //alert(value);
            }

        }
    });
   
    he = $('#lblcanHE2').html(); //Math.round(acutardanzas / 60)
    heac = (Math.round(Math.round(valores))*8)*60;
    het = parseInt(he) - parseInt(heac);
    $('#lblcanHEac2').html(heac );
    $('#lblcanHET2').html(het);
 
    if (het <= '0') {

        $("#btnNewCompF").hide(1000);
    } else {

        $("#btnNewCompF").show("slow");
    }
}
 





// funcion que regresa lista a actualizar
function HorasMin(horaT) {
    var hora = horaT;
    var parts = hora.split(':');
    var total = parseInt(parts[0]) * 60 + parseInt(parts[1]);
    return total;
}

var lengthDatosActualizarBolsa
var DataActualizarBolsa

function creardatosbolsa(personal_id,hconv) {
    var acum = 0;
    var ht = 0;
    var tempht = 0;
    var tempHnuevo;
    var STempH = [];
    var params = {
        Personal_Id: personal_id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/getListBolDetHE",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            DataActualizarBolsa = response.d;
            tempHnuevo = hconv;
            lengthDatosActualizarBolsa = DataActualizarBolsa.length - 1;

            for (var i = 0; i <= lengthDatosActualizarBolsa; i++) {
                var horaNue = HorasMin(DataActualizarBolsa[i].HETotal);
                if (tempHnuevo <=0) {
                    break;
                }
                if (tempHnuevo == horaNue) {
                    tempHnuevo = tempHnuevo - horaNue
                    STempH.push(DataActualizarBolsa[i].ID + "," + DataActualizarBolsa[i].Personal_Id + "," + DataActualizarBolsa[i].fecha_asistencia + "," + '00:00', '02')
                }
                if (tempHnuevo>horaNue) {
                    tempHnuevo = tempHnuevo - horaNue
                    STempH.push(DataActualizarBolsa[i].ID + "," + DataActualizarBolsa[i].Personal_Id + "," + DataActualizarBolsa[i].fecha_asistencia + "," + '00:00', '02')
                }
                if (tempHnuevo < horaNue) {
                    tempHnuevo = horaNue - tempHnuevo
                    STempH.push(DataActualizarBolsa[i].ID + "," + DataActualizarBolsa[i].Personal_Id + "," + DataActualizarBolsa[i].fecha_asistencia + "," + displayHE(tempHnuevo), '02')
                    break;
                }                       
            }
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
    var params = {
       
        Rlist: STempH
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Update_Bolsa_HE",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var data = response.d;
            var mens = data[0];
       },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });

}






function PasarTardanza(rol) {
    
    var he = $('#lblcanHE').html();
    var heas = $('#lblcanHEac').html();
    var het = $('#lblcanHET').html();
   
    var estado = "";

    var hoy = hoyFecha();
    $('#tbodyCompT input[type="checkbox"]').each(function () {
        if ($(this).prop('checked') == true) {
            //valores.push($(this).find("#cnt").html());
            for (var i = 0; i <= lengthDatosTarde; i++) {
                if (DataTarde[i].Marcacion_Id == $(this).val()) {
                    //let element = {
                    //    cantida: (Math.round((DataTarde[i].cantida) / 60)), Marcacion_Id: DataTarde[i].Marcacion_Id, fecha: Date.parse(DataTarde[i].fecha).toString(),

                    //};
                    perso.push(DataTarde[i].cantida + "," + DataTarde[i].Marcacion_Id + "," + DataTarde[i].fecha)
                    //valores.push(element)
                    personal_id = DataTarde[i].Personal_Id
                }
            }
           

        }
    });
    var variableFlat = Get_Variables('1');
    //if (rol == "01" || rol == "03") {
        
    //    estado="03"
    //} else { estado = "01" }
     
    switch (rol) {
        case '01':
            estado = '03'
            break;
        case '02': // foo es 0, por lo tanto se cumple la condición y se ejecutara el siguiente bloque
            if (variableFlat == '1') {
                estado = '03'
            } else {
                estado = '01'
            }
            break;
            // NOTA: el "break" olvidado debería estar aquí
        case '03': // No hay sentencia "break" en el 'case 0:', por lo tanto este caso también será ejecutado
            if (variableFlat == '0') {
                estado = "03"
            } else {
                estado = '01'
            }

            break; // Al encontrar un "break", no será ejecutado el 'case 2:'
        case '04':
            estado = '01'
            break;
      
    }


    
    $('#lblFechaCompT').html(hoy);

    $('#txthoratarde').val(heas);

    var hora1 = (heas * -1);
    var hora2 = ($('#txthoracompensadaT').val());

    if ((hora2 != hora1)) {
        llamamodalInfo('ALERTA.!', 'EL NUMERO DE HORAS COMPENSADAS DEBE SER IGUAL ALNUMERO DE HORAS SELECCIONADA.!', 'Aceptar');
        return false;
    }

    var a = personal_id, b = hoy, d = $('#cboModoCompT').val(), e = $('#txthoracompensadaT').val(), f = $('#txtMotcompT').val(), g = estado;

    var params = {
        // gereid: a,
        id_personal:a,
        fecha_compensacion:b,
        mod_conpensacion:d,
        can_compensadas:e,
        motivo:f,
        estado:g,
        Rlist: perso
    };
        $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Insert_Compensacion",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var data = response.d;
            //var tru = data.split('#')[0];
            var mens = data[0];
            //if (mens != '') {
            //    alert(mens);
               
            //} else {
            //    alert(mens);
            //}
            llamamodalSus('Mensaje', 'Se registraron los datos con éxito.!', 'Aceptar');
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });

    //console.log(valores.array)
    $('#TabContainerComp').tabs('option', 'active', 0);
    document.getElementById('PTab01').disabled = false;//id="tbltarde"
   
}

var perso = [];
var personal_id = "";
function PasarTard(rol) { //pasar datos de tardanza
    //var valores = [];
    perso = [];
    var he = $('#lblcanHE').html();
    var heas = $('#lblcanHEac').html();
    var het = $('#lblcanHET').html();
    personal_id = "";
    var estado = "";

    var hoy = hoyFecha();
    $('#tbodyCompT input[type="checkbox"]').each(function () {
        if ($(this).prop('checked') == true) {
            //valores.push($(this).find("#cnt").html());
            for (var i = 0; i <= lengthDatosTarde; i++) {
                if (DataTarde[i].Marcacion_Id == $(this).val()) {
                    //let element = {
                    //    cantida: (Math.round((DataTarde[i].cantida) / 60)), Marcacion_Id: DataTarde[i].Marcacion_Id, fecha: Date.parse(DataTarde[i].fecha).toString(),

                    //};
                    perso.push(DataTarde[i].cantida + "," + DataTarde[i].Marcacion_Id + "," + DataTarde[i].fecha)
                    //valores.push(element)
                    personal_id = DataTarde[i].Personal_Id
                }
            }


        }
    });
    //if (rol == "01" || rol == "03") {
    //    estado = "02"
    //} else { estado = "01" }

    var variableFlat = Get_Variables('1');
 

    switch (rol) {
        case '01':
            estado = '03'
            break;
        case '02':  
            if (variableFlat == '1') {
                estado = '03'
            } else {
                estado = '01'
            }
            break;
             
        case '03':  
            if (variableFlat == '0') {
                estado = "03"
            } else {
                estado = '01'
            }

            break;  
        case '04':
            estado = '01'
            break;

    }

    $('#lblFechaCompT').html(hoy);

    $('#txthoratarde').val(heas);
    var a1 = displayHE(heas * -1);
    $('#txthoratarde1').html(a1);

    var a2 = displayHE(heas * -1);
    $('#txthoracompensadaT').val(heas * -1);
    $('#txthoratarde11').html(a2);

    if (het < 0) {
        llamamodalInfo('ALERTA..!', 'LA CANTIDAD DE HORAS EXTRAS, ES MENOR A LA CANTIDAD DE HORAS SELECCIONADAS', 'ACEPTAR')
        clear_NewCompT();
        getCompCab(personal_id);
        $('#TabContainerComp').tabs('option', 'active', 0);
        return;
    }
   

    //console.log(valores.array)
    $('#TabContainerComp').tabs('option', 'active', 2);
    document.getElementById('PTab01').disabled = false;//id="tbltarde"

}


var perso2 = [];
var personal_id2 = "";
function PasarFalta(rol) {//pasar datos de faltas
    //var valores = [];
    perso2 = [];
    var he = $('#lblcanHE2').html();
    var heas = $('#lblcanHEac2').html();
    var het = $('#lblcanHET2').html();
    personal_id2 = "";
    var estado = "";

    var hoy = hoyFecha();
    $('#tbodyCompF input[type="checkbox"]').each(function () {
        if ($(this).prop('checked') == true) {
            //valores.push($(this).find("#cnt").html());
            for (var i = 0; i <= lengthDatosfalta; i++) {
                if (Datafalta[i].fecha == $(this).parents("tr").find("td").eq(4).html()) {
                   
                    perso2.push(Datafalta[i].cantida + "," + Datafalta[i].Marcacion_Id + "," + Datafalta[i].fecha)
                    
                    personal_id2 = Datafalta[i].Personal_Id
                }
            }


        }
    });
    //if (rol == "01" || rol == "03") {
    //    estado = "02"
    //} else { estado = "01" }

    var variableFlat = Get_Variables('1');


    switch (rol) {
        case '01':
            estado = '03'
            break;
        case '02':
            if (variableFlat == '1') {
                estado = '03'
            } else {
                estado = '01'
            }
            break;

        case '03':
            if (variableFlat == '0') {
                estado = "03"
            } else {
                estado = '01'
            }

            break;
        case '04':
            estado = '01'
            break;

    }
    $('#lblFechaCompF').html(hoy);

    $('#txtFalta').val((heas / 8)/60);
    $('#txthoracompF').val((heas / 8)/60);
    var temphes = (($('#txthoracompF').val() * 8) * 60);
    $('#txthoracompF1').html(temphes);

    if (het < 0) {
        llamamodalInfo('ALERTA', 'LA CANTIDAD DE HORAS EXTRAS, ES MENOR A LA CANTIDAD DE DIAS SELECCIONADOS', 'ACEPTAR')
        clear_NewCompF();
        getCompCab(personal_id);
        $('#TabContainerComp').tabs('option', 'active', 0);
        return;
    }

    $('#TabContainerComp').tabs('option', 'active', 4);
    

}


function iNSERTARFALTA(rol) {

   

    var estado = "";

    var hoy = hoyFecha();
 
    //if (rol == "01" || rol == "03") {
    //    estado = "02"
    //} else { estado = "01" }

    var variableFlat = Get_Variables('1');


    switch (rol) {
        case '01':
            estado = '03'
            break;
        case '02':
            if (variableFlat == '1') {
                estado = '03'
            } else {
                estado = '01'
            }
            break;

        case '03':
            if (variableFlat == '0') {
                estado = "03"
            } else {
                estado = '01'
            }

            break;
        case '04':
            estado = '01'
            break;

    }
    
    var hora1 = ($('#txtFalta').val());
    var hora2 = ($('#txthoracompF').val());

    if ((hora2 != hora1)) {
        llamamodalInfo('ALERTA.!', 'EL NUMERO DE HORAS COMPENSADAS DEBE SER IGUAL ALNUMERO DE HORAS SELECCIONADA.!', 'Aceptar');
        return false;
        $('#TabContainerComp').tabs('option', 'active', 0);
     
    }

    
    var a = personal_id, b = hoy, d = $('#cboModoCompF').val(), e = $('#txthoracompF').val(), f = $('#txtMotcompF').val(), g = estado;

    var params = {
        // gereid: a,
        id_personal: a,
        fecha_compensacion: b,
        mod_conpensacion: d,
        can_compensadas: e,
        motivo: f,
        estado: g,
        Rlist: perso2
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "GenerarJustificacion.aspx/Insert_Compensacion",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var data = response.d;
          
            var mens = data[0];
          
            llamamodalSus('Mensaje', 'Se registraron los datos con éxito.!', 'Aceptar');
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });

    //console.log(valores.array)
    $('#TabContainerComp').tabs('option', 'active', 0);
    document.getElementById('PTab01').disabled = false;//id="tbltarde"

}


function pasaModalDet() {
    $('#dialog-detallecomp').dialog({
        autoOpen: true,
        modal: true,
        width: 1000,
        height: 560,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });


}

 

function hoyFecha() {
    var hoy = new Date();
    var dd = hoy.getDate();
    var mm = hoy.getMonth() + 1;
    var yyyy = hoy.getFullYear();

    dd = addZero(dd);
    mm = addZero(mm);

    return dd + '/' + mm + '/' + yyyy;
}

 
function addZero(i) {
    if (i < 10) {
        i = '0' + i;
    }
    return i;
}
$(document).ready(function () {
    var usuarioSes = Session.get('UsuarioSistema');
    var Rol = "01";
    var rol = "01";
   
  

    //----------------------Compensaciones----------------------------------
    $('#btnCompensacion').click(function () {
 
        var nn = $("#cboPersonal option:selected").text();
        $('#lblNombre').html($('#lblNomPersonal').text() + " / " + $('#lblNomPersonal').text());
        $('#TabContainerComp').tabs('option', 'active', 0);
        open_DialogComp();
        clear_NewCompT();
        var pers_id;
        if (rol == "01" || rol == "03") {
            pers_id = $('#cboPersonal').val();
        } else {
            pers_id = Personal_IdG
        }
        getCompCab(pers_id, Rol);
      
    });
    var Per_Id;
    $('#btNListCompT').click(function () {
        
        clear_NewCompT();
       
        $('#TabContainerComp').tabs('option', 'active', 1);
        if (rol == "01" || rol == "02" || rol == "03") {
            Per_Id = $('#cboPersonal').val();
        } else {
            Per_Id = Personal_IdG
        }

     
        getTardanza(Per_Id);
        getListHL(Per_Id, 'T');
        document.getElementById('btnNewCompF').disabled = true;
        document.getElementById('btnGrabarCompF').disabled = true;
        document.getElementById('btnCancelCompF').disabled = true;

    });

    $('#btNListCompF').click(function () {
      
        clear_NewCompF();
    
        $('#TabContainerComp').tabs('option', 'active', 3);
        if (rol == "01" || rol == "02" || rol == "03") {
            Per_Id = $('#cboPersonal').val();
        } else {
            Per_Id = Personal_IdG
        }
        getFalta(Per_Id);
        getListHL(Per_Id, 'F');
        document.getElementById('btnNewComp').disabled = true;
        document.getElementById('btnGrabarCompT').disabled = true;
        document.getElementById('btnCancelCompT').disabled = true;

    });

    document.getElementById('btnNewComp').disabled = true;
    document.getElementById('btnGrabarCompT').disabled = true;
    document.getElementById('btnCancelCompT').disabled = true;

    document.getElementById('btnNewCompF').disabled = true;
    document.getElementById('btnGrabarCompF').disabled = true;
    document.getElementById('btnCancelCompF').disabled = true;



    $("#tbodyCompT").click(function () {
          selectTardanza();
    });
    

    //tbodyCompF
    $("#tbodyCompF").click(function () {
        selectFalta();
    });


    $('#chkAll').change(function () {
        $('#tbodyCompT input[type="checkbox"]').prop('checked', $(this).prop('checked'));
        selectTardanza();
    });

    $('#chkAll1').change(function () {
        $('#tbodyCompF input[type="checkbox"]').prop('checked', $(this).prop('checked'));
        selectFalta();
    });


    if (rol == "01" || rol == "03") {
        personal_id = $('#cboPersonal').val();
    } else {
        personal_id = usuarioSes.Usuario_Id
    }



    $("#btnNewComp").click(function () {
        PasarTard(Rol);
        
    });
    $("#btnNewCompF").click(function () {
        PasarFalta(Rol);
        Get_Variables('1');

    });

    $("#btnCancelCompT").click(function () {
        
        clear_NewCompT();
        document.getElementById('PTab01').disabled = false;
        $('#TabContainerComp').tabs('option', 'active', 0);
        getCompCab(personal_id, Rol);

    });


    $("#btnCancelCompF").click(function () {

        clear_NewCompF();
        document.getElementById('PTab01').disabled = false;
        $('#TabContainerComp').tabs('option', 'active', 0);
        getCompCab(personal_id, Rol);

    });

    $("#btnGrabarCompT").click(function () {
        PasarTardanza(Rol);
        creardatosbolsa(personal_id, $('#txthoracompensadaT').val())
        clear_NewCompT();
        getCompCab(personal_id);
    });


    $("#btnGrabarCompF").click(function () {
        iNSERTARFALTA(Rol);

        var variableFlat = Get_Variables('1');
        switch (Rol) {
            case '01':
                creardatosbolsa(personal_id, $('#txthoracompF1').html());
                break;
            case '02':
                if (variableFlat == '1') {
                    creardatosbolsa(personal_id, $('#txthoracompF1').html());
                }  
                break;
            case '03':
                if (variableFlat == '0') {
                    creardatosbolsa(personal_id, $('#txthoracompF1').html());
                }  
                break;
            case '04':
                
                break;
        }

       
        clear_NewCompF();
        getCompCab(personal_id);
    });



    $('#tbodyCompGeneral').on('click', '.buttonEdit', function () {
        var codigo = this.id;
        Get_UpdateEstado(codigo, '04');
        $('#TabContainerComp').tabs('option', 'active', 0);
        getCompCab(personal_id, Rol);
    });
    $('#tbodyCompGeneral').on('click', '.buttonDesactiva', function () {
        //if (confirm('¿Esta seguro de cancelar la solicitud ?')) {
        //    Get_Cancelar_SolicitudPermisoDias(this.id, Personal_IdG);
        //}
        var codigo = this.id;
        Get_UpdateEstado(codigo, '03');
    });//pasaModalDet

    $('#tbodyCompGeneral').on('click', '.buttonAprobar', function () {
        //if (confirm('¿Esta seguro de cancelar la solicitud ?')) {
        //    Get_Cancelar_SolicitudPermisoDias(this.id, Personal_IdG);
        //}
        var codigo = this.id;
        Get_UpdateEstado(codigo, '03');
    });//pasaModalDet

    $('#tbodyCompGeneral').on('click', '.buttonDetalle', function () {
      
        var codigo = this.id;
        //codigo = codigo.substring(7);
        $('#lblidcomp').html(codigo);
        getCompDet(codigo);
        pasaModalDet();
    });


});

function llamamodalSus(titulo,mensaje,btn1) {
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

function displayHE(a) {
    var hours = Math.trunc(a / 60);
    var minutes = a % 60;
    return (hours + ":" + minutes);
}


function Get_Variables(flat) {

    var acuHL = '';
    var params = {
        flat: flat
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",

        url: "sPasarPlanilla.aspx/Get_Variables",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;

            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado != '') {
                        //alert(mensaje);
                        acuHL = mensaje;

                    } else {
                        //alert(mensaje);
                    }
                }
            }
            return acuHL;
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
    return acuHL;
}


