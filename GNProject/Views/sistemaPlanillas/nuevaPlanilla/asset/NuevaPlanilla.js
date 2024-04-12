/// <reference path="../PlanillaNueva.aspx" />

var Data;
var lengthDatos;

function get_ListaPlanilla() {
    //$('#barrprocess').show(3000);
     
    $(".barrprocess").css("display", "block");
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Lista_reporte_planilla';

    var ppersonal = $("#cboPersonalActivo").multipleSelect("getSelects");
    var ppersonalcount = $('#cboPersonalActivo option').length;
    var parperso;
    var estados;

    if (ppersonal.length == ppersonalcount) {
        parperso = '';
    } else {
        parperso = ppersonal;
    }
    //if ($('#chkflperiodo').prop('checked') == true) {
    //    estados="1";
    //} else {
    //    estados = "0";
    //}
    var Planilla_Id = Get_Planilla_Id_Header(); 
    var Periodo_Id = Get_Periodo_Id_Header();
    var localidad = $('#cboArea').val(), proyecto = $('#cboProyecto').val(), Area = $('#cboCatAuxiliar').val();
    var personal = parperso.toString();
    var PeriodoIni_Datos = $('#cboPeriodoIni').val(), PeriodoFin_Datos = $('#cboPeriodoFin').val();
    var estado = $('#cboEstado').val();
    //var ejercicio = $('#cboEjercicioIni').val(), flPeriodo = estados, PlanillaId = Get_Planilla_Id_Header();
   // var a = 'x0', b = 'x0', d = $('#txtFind').val(), e = $('#cboLocalidad').val(), f = $('#cboArea').val(), g = $('#cboSeccion').val();
   
    var params = {
        Planilla_Id: Planilla_Id,
        Periodo_Id: Periodo_Id,
        localidad: localidad,
        proyecto: proyecto,
        catAuxiliar_Id: Area,
        personal: personal,
        //ejercicio: ejercicio,
        //flPeriodo: flPeriodo,
        PeriodoIni_Datos: PeriodoIni_Datos,
        PeriodoFin_Datos: PeriodoFin_Datos,
        estado: estado
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
              Data = response.d;
            $('#Tbodyplanilla').html('');
              lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                var html = '<tr>';
                html += '<td style="text-align:center;"><input type="checkbox" name="chk' + Data[i].personal_id + Data[i].Periodo_Id + '" id="chk' + Data[i].personal_id + Data[i].Periodo_Id + '" value="' + Data[i].personal_id + Data[i].Periodo_Id + '" /></td>';
                html += '<td style="display:none;" >' + Data[i].Periodo_Id + '</td>';
                html += '<td>' + Data[i].Nombre_Completo + '</td>';
               
                html += '<td>' + Data[i].Mes + '</td>';
                html += '<td>' + Data[i].Periodo + '</td>';
                html += '<td>' + Data[i].FInicio + '</td>';
                html += '<td>' + Data[i].FFinal + '</td>';

                var chkChecked_V = "";
                if (Data[i].EstadoV == "C") { chkChecked_V = ' checked'; }
                var chkChecked_C = "";
                if (Data[i].EstadoC == "C") { chkChecked_C = ' checked'; }
                var chkChecked_G = "";
                if (Data[i].EstadoG == "C") { chkChecked_G = ' checked'; }
                var chkChecked_E = "";
                if (Data[i].EstadoE == "C") { chkChecked_E = ' checked'; }

                var chkDisabled_V = "";
                if (Data[i].Periodo_Id_Pago_V != "" && Data[i].Periodo_Id_Pago_V != Periodo_Id) { chkDisabled_V = ' disabled="disabled"'; }
                var chkDisabled_C = "";
                if (Data[i].Periodo_Id_Pago_C != "" && Data[i].Periodo_Id_Pago_C != Periodo_Id) { chkDisabled_C = ' disabled="disabled"'; }
                var chkDisabled_G = "";
                if (Data[i].Periodo_Id_Pago_G != "" && Data[i].Periodo_Id_Pago_G != Periodo_Id) { chkDisabled_G = ' disabled="disabled"'; }
                var chkDisabled_E = "";
                if (Data[i].Periodo_Id_Pago_E != "" && Data[i].Periodo_Id_Pago_E != Periodo_Id) { chkDisabled_E = ' disabled="disabled"'; }

                if (Data[i].vacaciones == "") { html += '<td></td>'; }
                else {
                    html += '<td style="text-align:center;"><input type="checkbox"' + chkChecked_V + chkDisabled_V + ' name="chkV' + Data[i].personal_id + Data[i].Periodo_Id + '" id="chkV' + Data[i].personal_id + Data[i].Periodo_Id + '"  value="V' + Data[i].personal_id + Data[i].Periodo_Id + '" /></td>';
                }
                if (Data[i].Cts == "") { html += '<td></td>'; }
                else {
                    html += '<td style="text-align:center;"><input type="checkbox"' + chkChecked_C + chkDisabled_C + ' name="chkC' + Data[i].personal_id + Data[i].Periodo_Id + '"  id="chkC' + Data[i].personal_id + Data[i].Periodo_Id + '" value="C' + Data[i].personal_id + Data[i].Periodo_Id + '" /></td>';
                }
                if (Data[i].Gratificacion == "") { html += '<td></td>'; }
                else {
                    html += '<td style="text-align:center;"><input type="checkbox"' + chkChecked_G + chkDisabled_G + ' name="chkG' + Data[i].personal_id + Data[i].Periodo_Id + '"  id="chkG' + Data[i].personal_id + Data[i].Periodo_Id + '" value="G' + Data[i].personal_id + Data[i].Periodo_Id + '" /></td>';
                }
                if (Data[i].Essalud == "") { html += '<td></td>'; }
                else {
                    html += '<td style="text-align:center;"><input type="checkbox"' + chkChecked_E + chkDisabled_E + ' name="chkE' + Data[i].personal_id + Data[i].Periodo_Id + '" id="chkE' + Data[i].personal_id + Data[i].Periodo_Id + '"  value="E' + Data[i].personal_id + Data[i].Periodo_Id + '" /></td>';
                }
                html += '<td>' + Data[i].vacaciones + '</td>';
                html += '<td>' + Data[i].FechaV + '</td>';
                html += '<td>' + Data[i].Cts + '</td>';
                html += '<td>' + Data[i].FechaC + '</td>';
                html += '<td>' + Data[i].Gratificacion + '</td>';
                html += '<td>' + Data[i].FechaG + '</td>';
                html += '<td>' + Data[i].Essalud + '</td>';
                html += '<td>' + Data[i].FechaE + '</td>';
                html += '<td>' + Data[i].OtrosIngresos + '</td>';
                html += '<td>' + Data[i].DsctoPenciones + '</td>';
                html += '<td>' + Data[i].OtrosDscto + '</td>';
                html += '<td>' + Data[i].Netos + '</td>';
                var Est;
                if (Data[i].Estado == 'P' || Data[i].Estado == '') {
                    Est = 'PENDIENTE';
                } else {
                    Est = 'CANCELADO';
                }
                html += '<td>' + Est + '</td>';
                var obs = "";//;Data[i].Observacion.toString();
                //html += '<td>' + Data[i].Observacion + '</td>'; //Periodo_id
                //html += '<td style="text-align:center;"><input type="text" id="txt' + Data[i].personal_id + Data[i].Periodo_Id + '" class="txt" value="' + Data[i].Observacion + '" style="width:100px;height:30px;" /></td>';
                html += '<td style="text-align:center;"><textarea rows="4" cols="40"  name="txt' + Data[i].personal_id + Data[i].Periodo_Id + '" id="txt' + Data[i].personal_id + Data[i].Periodo_Id + '">' + obs + '</textarea></td>';
                //$('#txt' + Data[i].personal_id + Data[i].Periodo_Id).val(Data[i].Observacion);
                
                //textarea   rows="4" cols="50"
                html += '</tr>';
                $(html).appendTo('#Tbodyplanilla');
            }

            SeleccionarTodoGeneral();
            SelVacaciones();
            SelCts();
            SelGrati();
            SelEssa();
           
            $("#chkAllApro").attr('checked', false);
            //$("#chkAllApro").change();

            $("#chkvac").attr('checked', false);
            //$("#chkvac").change();

            $("#chkcts").attr('checked', false);
            //$("#chkcts").change();

            $("#chkgrati").attr('checked', false);
            //$("#chkgrati").change();

            $("#chkessalud").attr('checked', false);
            //$("#chkessalud").change();
        },

        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true 
    });
    //$('#barrprocess').hide(3000);
    $(".barrprocess").css("display", "none");
}

function RegistrarDatos() {
    var perso = [];
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/InsertDetLiquidacion';

    if (confirm('¿Está seguro de continuar?')) {
        var cant = $('#Tbodyplanilla input:checkbox:checked').length;
        if (cant == 0) {
            alert('.::Error > No ha seleccionado a ningun Dato.');
            return false;
        }

        $('#Tbodyplanilla input:checkbox:checked').each(function () {
            //var personal_id = this.id.substring(3);            
            var personal = $(this).val();            
            for (var i = 0; i <= lengthDatos; i++) {
                if (Data[i].personal_id + Data[i].Periodo_Id == personal) {
                    var datos = Data[i].personal_id + Data[i].Periodo_Id;

                    var comment = $.trim($('#txt' + personal).val());

                    if ($('#chkV' + datos).prop('disabled') == false) {
                        var estadoV = 'P';
                        if ($('#chkV' + datos).prop('checked') == true) { estadoV = 'C'; }
                        perso.push(Data[i].personal_id + "," + Data[i].Periodo_Id + "," + estadoV + "," + comment + "," + '001401');
                    }

                    if ($('#chkC' + datos).prop('disabled') == false) {
                        var estadoC = 'P';
                        if ($('#chkC' + datos).prop('checked') == true) { estadoC = 'C'; }
                        perso.push(Data[i].personal_id + "," + Data[i].Periodo_Id + "," + estadoC + "," + comment + "," + '001398');
                    }

                    if ($('#chkG' + datos).prop('disabled') == false) {
                        var estadoG = 'P';
                        if ($('#chkG' + datos).prop('checked') == true) { estadoG = 'C'; }
                        perso.push(Data[i].personal_id + "," + Data[i].Periodo_Id + "," + estadoG + "," + comment + "," + '001399');
                    }

                    if ($('#chkE' + datos).prop('disabled') == false) {
                        var estadoE = 'P';
                        if ($('#chkE' + datos).prop('checked') == true) { estadoE = 'C'; }
                        perso.push(Data[i].personal_id + "," + Data[i].Periodo_Id + "," + estadoE + "," + comment + "," + '001400');
                    }
                }
            }
        });

        if (perso.length == 0) { alert("- Debe seleccionar un personal y al menos un concepto a pagar."); }
        else {
            var params = {
                Rlist: perso,
                Periodo_Id_Pago: Get_Periodo_Id_Header()
            };
            $.ajax({
                type: "POST",
                data: JSON.stringify(params),
                dataType: "json",
                url: urlajax,
                contentType: "application/json; chartseft:utf-8",
                success: function (response) {
                    var res = response.d;
                    if (res.retorno > 0) {
                        var msgConfirm = res.msg_retorno + "\n¿Desea procesar las formulas?"
                        if (confirm(msgConfirm)) {
                            document.getElementById("ctl00_ContentPlaceHolder1_btnProcesarFormula").click();
                        }
                        get_ListaPlanilla();
                    }
                    else {
                        alert(res.msg_retorno);
                    }
                },
                error:
                    function (XmlHttpError, error, description) {
                        $('#dialog-form').html(XmlHttpError.responseText);
                    },
                async: true
            });
        }
    }    
}

function RegButon() {
    $("#rbtTotal").prop('checked', true);
    $("#chkV").attr("disabled", true);
    $("#chkE").attr("disabled", true);
    $("#chkC").attr("disabled", true);
    $("#chkG").attr("disabled", true);
    $("#rbtTotal").on("click", function () {
      
        $("#rbtParcial").prop('checked', false);
        $("#chkV").attr("disabled", true);
        $("#chkE").attr("disabled", true);
        $("#chkC").attr("disabled", true);
        $("#chkG").attr("disabled", true);
    });

    $("#rbtParcial").on("click", function () {
        
        $("#rbtTotal").prop('checked', false);
        $("#chkV").removeAttr("disabled");
        $("#chkE").removeAttr("disabled");
        $("#chkC").removeAttr("disabled");
        $("#chkG").removeAttr("disabled");

    });

    //$("#rbtTotal", "#rbtParcial").change(function () {
    //    if ($("#rbtTotal").is(":checked")) {
    //        alert('total');
    //        $("#rbtParcial").prop('checked', false);
    //    }
    //    else if ($("#rbtParcial").is(":checked")) {
    //        alert('parcial');
    //        $("#rbtTotal").prop('checked', false);
    //    }
         
    //});
}


function VArea() {
    var Area = $('#cboCatAuxiliar').val();
    return Area;
}

//Se comenta porque no se usa esta función
//function VDatos() {
//    var ppersonal = $("#cboPersonalActivo").multipleSelect("getSelects");
//    var ppersonalcount = $('#cboPersonalActivo option').length;
//    var parperso;
//    var estados;

//    if (ppersonal.length == ppersonalcount) {
//        parperso = '';
//    } else {
//        parperso = ppersonal;
//    }
//    // , localidad, Area,  , proyecto, personal
//    var Area = $('#cboCatAuxiliar').val();
//    var localidad = $('#cboArea').val(), proyecto = $('#cboProyecto').val(), personal = parperso.toString(), estado = $('#cboEstado').val();
//    var ejercicio = $('#cboEjercicioIni').val(), flPeriodo = estados, PeriodoIni = $('#cboPeriodoIni').val(), PeriodoFin = $('#cboPeriodoFin').val(), PlanillaId = Get_Planilla_Id_Header();

//    var TDat = [];
//    TDat.push(localidad + "," + Area + "," + proyecto + "," + personal + "," + PlanillaId);
//    return TDat;
//}

function SeleccionarTodoGeneral() {
    $('#chkAllApro').change(function () {
        for (var i = 0; i <= lengthDatos; i++) {
            var datos = Data[i].personal_id + Data[i].Periodo_Id;

            if ($(this).prop('checked') == true) {
                $('#chk' + datos).prop("checked", true);
            }
            else {
                $('#chk' + datos).prop("checked", false);
            }
        }
    });
}

// checkvacaciones
function SelVacaciones() {
    $('#chkvac').change(function () {
        for (var i = 0; i <= lengthDatos; i++) {
            var datos = Data[i].personal_id + Data[i].Periodo_Id;

            if ($('#chkV' + datos).prop('disabled') == false) {
                if ($(this).prop('checked') == true) {
                    $('#chkV' + datos).prop("checked", true);
                }
                else {
                    $('#chkV' + datos).prop("checked", false);
                }
            }
        }
    });
}

//check cts
function SelCts() {
    $('#chkcts').change(function () {
        for (var i = 0; i <= lengthDatos; i++) {
            var datos = Data[i].personal_id + Data[i].Periodo_Id;

            if ($('#chkC' + datos).prop('disabled') == false) {
                if ($(this).prop('checked') == true) {
                    $('#chkC' + datos).prop("checked", true);
                }
                else {
                    $('#chkC' + datos).prop("checked", false);
                }
            }
        }
    });
}

//check gratificacion
function SelGrati() {
    $('#chkgrati').change(function () {
        for (var i = 0; i <= lengthDatos; i++) {
            var datos = Data[i].personal_id + Data[i].Periodo_Id;

            if ($('#chkG' + datos).prop('disabled') == false) {
                if ($(this).prop('checked') == true) {
                    $('#chkG' + datos).prop("checked", true);
                }
                else {
                    $('#chkG' + datos).prop("checked", false);
                }
            }
        }
    });
}

//check essalud
function SelEssa() {
    $('#chkessalud').change(function () {
        for (var i = 0; i <= lengthDatos; i++) {
            var datos = Data[i].personal_id + Data[i].Periodo_Id;

            if ($('#chkE' + datos).prop('disabled') == false) {
                if ($(this).prop('checked') == true) {
                    $('#chkE' + datos).prop("checked", true);
                }
                else {
                    $('#chkE' + datos).prop("checked", false);
                }
            }
        }
    });
}
