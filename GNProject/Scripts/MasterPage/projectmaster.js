
function Get_DatosUsuario_Logeo(Personal_Id) {
    var params = {
        Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "../../MasterPage/Helpert.aspx/Get_DatosUsuario_Logeo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var PersonalLogin = response.d;
            if (PersonalLogin) {
                Session.set('UsuarioSistema', PersonalLogin);
                $('#lblUsuarioGlobal').html(PersonalLogin.PersonalNombres);
            } else {
                setTimeout("location.href='../../Login.aspx'", 250);
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
};
function Get_ValidarDatosUsuario_Logeo(Personal_Id) {
    var params = {
        Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "../../MasterPage/Helpert.aspx/Get_ValidarDatosUsuario_Logeo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var PersonalLogin = response.d;
            if (window.location.href.indexOf('Matenimientos/CambiarClave.aspx') == -1) {
                if (PersonalLogin.split('#')[0] == 'true') {
                    alert(PersonalLogin.split('#')[1]);
                    setTimeout("location.href='../Matenimientos/CambiarClave.aspx'", 250);
                }
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: true
    });
};



function Redireccionar_Rol() {

    var usuarioSes = Session.get('UsuarioSistema');

    var Rol = usuarioSes.NivelAcc;

    if (Rol == '01') {
        /*---------ADMINISTRADOR---------*/
        var mainLin = '<li><a href="#" >Mantenimiento</a>';
        mainLin += '<ul class="subs">';
        mainLin += '<li><a href="#">MANTENIMIENTO</a>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../Matenimientos/MHorarios.aspx">Horarios</a></li>';
        mainLin += '</ul>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../caAsignarHVariable/cAsignarHVariable.aspx">Horarios Variables</a></li>';
        mainLin += '</ul>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../Matenimientos/MTurnos.aspx">Turnos</a></li>';
        mainLin += '</ul>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../Matenimientos/MPermisos.aspx">Registro de Permisos</a></li>';
        mainLin += '</ul>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../Matenimientos/MFeriados.aspx">Feriados</a></li>';
        mainLin += '</ul>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../Matenimientos/MAsignarHorarioPersona.aspx">Asignar Horarios x Persona</a></li>';
        mainLin += '</ul>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../Matenimientos/MAsignarHorarioMasivo.aspx">Asignar Horarios Masivo</a></li>';
        mainLin += '</ul>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../Matenimientos/MAsignarTurnoPersona.aspx">Asignar Turnos x Persona</a></li>';
        mainLin += '</ul>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../Matenimientos/MAsignarTurnoMasivos.aspx">Asignar Turnos Masivos</a></li>';
        mainLin += '</ul>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../Matenimientos/MParametros.aspx">Parametros</a></li>';
        mainLin += '</ul>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../Matenimientos/MParametrosPersona.aspx">Parametros por Persona</a></li>';
        mainLin += '</ul>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../Matenimientos/MPeriodoAsistencia.aspx">Periodo de Asistencia</a></li>';
        mainLin += '</ul>';
        mainLin += '<ul>';

        mainLin += '<li><a href="../Matenimientos/MHorarios.aspx">Horarios</a></li>';
        mainLin += '<li><a href="../caAsignarHVariable/cAsignarHVariable.aspx">Horarios Variables</a></li>';
        mainLin += '<li><a href="../Matenimientos/MTurnos.aspx">Turnos</a></li>';
        mainLin += '<li><a href="../Matenimientos/MPermisos.aspx">Registro de Permisos</a></li>';
        mainLin += '<li><a href="../Matenimientos/MFeriados.aspx">Feriados</a></li>';
        mainLin += '<li><a href="../Matenimientos/MAsignarHorarioPersona.aspx">Asignar Horarios x Persona</a></li>';
        mainLin += '<li><a href="../Matenimientos/MAsignarHorarioMasivo.aspx">Asignar Horarios Masivo</a></li>';
        //mainLin += '<li><a href="../Matenimientos/MAsignarTurnoPersona.aspx">Asignar Turnos x Persona</a></li>';
        mainLin += '<li><a href="../Matenimientos/MAsignarTurnoMasivos.aspx">Asignar Turnos Masivos</a></li>';
        mainLin += '<li><a href="../Matenimientos/MParametros.aspx">Parametros</a></li>';
        mainLin += '<li><a href="../Matenimientos/MParametrosPersona.aspx">Parametros por Persona</a></li>';
        mainLin += '<li><a href="../Matenimientos/MPeriodoAsistencia.aspx">Periodo de Asistencia</a></li>';
        mainLin += '<li><a href="../Matenimientos/MCorreoPersonal.aspx">Correo-Personal</a></li>';
        mainLin += '<li><a href="../Matenimientos/MJG.aspx">Configuración Jefe Personal</a></li>';
        mainLin += '<li><a href="../Matenimientos/MJefePersonal.aspx">Jefe Personal</a></li>';
        mainLin += '<li><a href="../Matenimientos/AsignaConceptos.aspx">Asignar Conceptos</a></li>';

        mainLin += '<li><a href="../Matenimientos/ParametroXConcepto.aspx">Asignar Parametro x Concepto</a></li>';

        mainLin += '</ul>';
        mainLin += '</li>';
        mainLin += '</ul>';
        mainLin += '</li>';

        $(mainLin).appendTo("#nav");

        /*---------PROCESOS---------*/
        var acc_procesos = '<li ><a href="#">Carga-Asistencia</a>';
        acc_procesos += '<ul class="subs">';
        acc_procesos += '<li><a href="#">CARGA-ASISTENCIA</a>';
        acc_procesos += '<ul>';
        acc_procesos += '<li><a href="../Matenimientos/CAAsignarCodigo.aspx">Asignar Codigo</a></li>';
        acc_procesos += '</ul>';
        acc_procesos += '<ul>';
        acc_procesos += '<li><a href="../Matenimientos/CAGenerarFaltas.aspx">Generar Faltas</a></li>';
        acc_procesos += '</ul>';
        acc_procesos += '<ul>';
        acc_procesos += '<li><a href="../Matenimientos/CAAsignarCodigo.aspx">Asignar Codigo</a></li>';
        acc_procesos += '<li><a href="../Matenimientos/CAGenerarFaltas.aspx">Generar Faltas</a></li>';
        acc_procesos += '<li><a href="../Matenimientos/CARegistrarMarcaciones.aspx">Procesar Marcaciones</a></li>';
        acc_procesos += '<li><a href="../Matenimientos/CAImportarMarcaciones.aspx">Sincronizar Marcaciones</a></li>';
        acc_procesos += '<li><a href="../caControlAsistencia/ca.aspx">Procesar CA</a></li>';
        acc_procesos += '<li><a href="../caPasarPlanilla/sPasarPlanilla.aspx">Pasar Novedades a Planilla</a></li>';
        acc_procesos += '<li><a href="http://novedades.gnrsgroup.com/" target="_blank">Registro de Novedades</a></li>';
        acc_procesos += '<li><a href="../caInfoMarcaciones/cInfoMarcacion.aspx">Informar Marcaciones</a></li>';
        //Justificaciones
        acc_procesos += '<li><a href="../Justificacion/JustificacionRRHH.aspx">Permisos y Justificaciones RRHH</a></li>';
        acc_procesos += '<li><a href="../Justificacion/JustificacionJefes.aspx">Permisos y Justificaciones Jefes</a></li>';
        acc_procesos += '<li><a href="../Justificacion/GenerarJustificacion.aspx">Generar Permisos Justificaciones y Compensaciones</a></li>';
        acc_procesos += '<li><a href="../caReporteGeneral/CaReporteHE.aspx">Generar Bolsa HE a Compensar</a></li>';
        //acc_procesos += '<li><a href="../Matenimientos/CAAsignarCodigo.aspx">Asignar Codigo</a></li>';
        acc_procesos += '</ul>';
        acc_procesos += '<ul>';
        //acc_procesos += '<li><a href="../caInfoMarcaciones/cInfoMarcacion.aspx">Informar Marcaciones</a></li>';
        acc_procesos += '</ul>';
        acc_procesos += '</li>';
        acc_procesos += '</ul>';
        $(acc_procesos).appendTo("#nav");

        /*---------END PROCESOS---------*/

        /*---------REPORTES---------*/
        var acc_reportes = '<li ><a href="#">REPORTES</a>';
        acc_reportes += '<ul class="subs">';
        acc_reportes += '<li><a href="#">Control Asistencia</a>';
        acc_reportes += '<ul>';
        acc_reportes += '<li><a href="../caReporteGeneral/ControlAsistencia.aspx">Control Asistencia</a></li>';
        acc_reportes += '<li><a href="../caReporteGeneral/cReporteGeneral.aspx">Reporte General</a></li>';
        acc_reportes += '<li><a href="../caIndicadoresMultiples/cIndicadoresMultiples.aspx">Reporte Indices</a></li>';
        acc_reportes += '<li><a href="../caReporteGeneral/CaReporteDiario.aspx">Reporte Diario Asistencia</a></li>';
        acc_reportes += '<li><a href="../Indicadores/IndicadoresGen.aspx">Indicadores</a></li>';

        acc_reportes += '<li><a href="../caVerBoletas/cVerBoletas.aspx">Boletas - Personal</a></li>';
        acc_reportes += '</ul>';
        acc_reportes += '</li>';
        acc_reportes += '</ul>';
        acc_reportes += '</li>';
        $(acc_reportes).appendTo("#nav");
        /*---------END REPORTES---------*/

        /*---------SEGURIDAD---------*/
        var acc_seguridad = '<li ><a href="#">SEGURIDAD</a>';
        acc_seguridad += '<ul class="subs">';
        acc_seguridad += '<li><a href="#">SEGURIDAD ADMIN</a>';
        acc_seguridad += '<ul>';
        acc_seguridad += '<li><a href="../Matenimientos/CambiarClave.aspx">Cambiar Contraseña</a></li>';
        acc_seguridad += '<li><a href="../Matenimientos/Reg_Usuario.aspx">Registro de Usuario</a></li>';
        acc_seguridad += '<li><a href="../Matenimientos/RegistrarPermisos.aspx">Administración de Niveles de Usuario</a></li>';
        acc_seguridad += '<li><a href="../Matenimientos/Personal_Dispositivo.aspx">Personal Dispositivo</a></li>';
        acc_seguridad += '</ul>';
        acc_seguridad += '</li>';
        acc_seguridad += '</ul>';
        acc_seguridad += '</li>';
        $(acc_seguridad).appendTo("#nav");
        /*---------END SEGURIDAD---------*/

        var acc_salir = '<li ><a href="../../Login.aspx">SALIR</a>';
        acc_salir += '</li>';

        $(acc_salir).appendTo("#nav");
    }

    if (Rol == '02') {
        /*---------recursos humanos---------*/
        var mainLin = '<li><a href="#">Administración</a>';
        mainLin += '<ul class="subs">';
        mainLin += '<li><a href="#">RRHH</a>';
        mainLin += '<ul>';
        /*mainLin += '<li><a href="../caVerBoletas/cVerBoletas.aspx">Boletas - Personal</a></li>';
        mainLin += '<li><a href="../caMiBoleta/cMiBoleta.aspx">Mis Boletas</a></li>';*/
        mainLin += '<li><a href="../caPasarPlanilla/sPasarPlanilla.aspx">Pasar Novedades a Planilla</a></li>';
        mainLin += '<li><a href="http://novedades.gnrsgroup.com/" target="_blank">Registro de Novedades</a></li>';
        mainLin += '</ul>';
        mainLin += '</li>';

        mainLin += '<li><a href="#">Control Asistencia</a>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../Justificacion/JustificacionRRHH.aspx">Permisos y Justificaciones</a></li>';
        mainLin += '<li><a href="../Justificacion/GenerarJustificacion.aspx">Generar Permisos Justificaciones y Compensaciones</a></li>';
        mainLin += '<li><a href="../caReporteGeneral/CaReporteHE.aspx">Generar Bolsa HE a Compensar</a></li>';
        //mainLin += '<li><a href="../Justificacion/Acceso.aspx">Permisos y Justificaciones</a></li>';
        mainLin += '</ul>';
        mainLin += '</li>';

        mainLin += '</ul>';
        mainLin += '</li>';
        $(mainLin).appendTo("#nav");

        var acc_rep = '<li><a href="#">Reportes</a>';
        acc_rep += '<ul class="subs">';
        acc_rep += '<li><a href="#">Control Asistencia</a>';
        acc_rep += '<ul>';
        acc_rep += '<li><a href="../caReporteGeneral/ControlAsistencia.aspx">Control Asistencia</a></li>';
        acc_rep += '<li><a href="../caReporteGeneral/cReporteGeneral.aspx">Reporte General</a></li>';
        acc_rep += '<li><a href="../caIndicadoresMultiples/cIndicadoresMultiples.aspx">Reporte Indices</a></li>';
        acc_rep += '<li><a href="../caReporteGeneral/CaReporteDiario.aspx">Reporte Diario Asistencia</a></li>';
        acc_rep += '<li><a href="../Indicadores/IndicadoresGen.aspx">Indicadores</a></li>';
        acc_rep += '</ul>';
        acc_rep += '</li>';
        acc_rep += '</ul>';
        acc_rep += '</li>';
        $(acc_rep).appendTo("#nav");

        /*---------SEGURIDAD---------*/
        var acc_seguridad = '<li ><a href="#">SEGURIDAD</a>';
        acc_seguridad += '<ul class="subs">';
        acc_seguridad += '<li><a href="#">Seguridad</a>';
        acc_seguridad += '<ul>';
        acc_seguridad += '<li><a href="../Matenimientos/CambiarClave.aspx">Cambiar Contraseña</a></li>';

        acc_seguridad += '</ul>';
        acc_seguridad += '</li>';
        acc_seguridad += '</ul>';
        acc_seguridad += '</li>';
        $(acc_seguridad).appendTo("#nav");
        /*---------END SEGURIDAD---------*/

        var acc_salir = '<li ><a href="../../Login.aspx">SALIR</a>';
        acc_salir += '</li>';
        $(acc_salir).appendTo("#nav");

    }

    if (Rol == '03') {

        /*---------jefatura---------*/
        var mainLin = '';
        /*var mainLin = '<li><a href="#">Administración</a>';
        mainLin += '<ul class="subs">';
        mainLin += '<li><a href="#">RRHH</a>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../caVerBoletasJefe/cVerBoletasJefe.aspx">Boletas - Personal</a></li>';
        mainLin += '<li><a href="../caMiBoleta/cMiBoleta.aspx">Mis Boletas</a></li>';
        mainLin += '</ul>';
        mainLin += '</li>';*/

        mainLin += '<li><a href="#">Control Asistencia</a>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../Matenimientos/CARegistrarMarcaciones.aspx">Procesar Marcaciones</a></li>';
        mainLin += '<li><a href="../caControlAsistencia/ca.aspx">Procesar CA</a></li>';
        mainLin += '<li><a href="../Justificacion/JustificacionJefes.aspx">Permisos y Justificaciones</a></li>';
        mainLin += '<li><a href="../Justificacion/GenerarJustificacion.aspx">Permisos, Justificaciones y Compensaciones</a></li>';
        mainLin += '<li><a href="../caInfoMarcaciones/cInfoMarcacion.aspx">Informar Marcaciones</a></li>';
        mainLin += '<li><a href="../caReporteGeneral/CaReporteHE.aspx">Generar Bolsa HE a Compensar</a></li>';
        mainLin += '</ul>';


        mainLin += '</li>';

        mainLin += '<li><a href="#">Reportes - Control Asistencia</a>';
        mainLin += '<ul>';
        acc_rep += '<li><a href="../caReporteGeneral/ControlAsistencia.aspx">Control Asistencia</a></li>';
        mainLin += '<li><a href="../caReporteGeneral/cReporteGeneral.aspx">Reporte General</a></li>';
        mainLin += '<li><a href="../caIndicadoresMultiples/cIndicadoresMultiples.aspx">Reporte Indices</a></li>';
        mainLin += '<li><a href="../caReporteGeneral/CaReporteDiario.aspx">Reporte Diario Asistencia</a></li>';
        mainLin += '<li><a href="../Indicadores/IndicadoresGen.aspx">Indicadores</a></li>';
        mainLin += '</ul>';
        mainLin += '</li>';

        mainLin += '<li><a href="#">Mantenimiento - Control Asistencia</a>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../Matenimientos/MAsignarHorarioMasivo.aspx">Asignar Horarios Masivo</a></li>';
        mainLin += '<li><a href="../Matenimientos/MAsignarTurnoMasivos.aspx">Asignar Turnos Masivos</a></li>';
        mainLin += '</ul>';
        mainLin += '</li>';

        mainLin += '</ul>';
        mainLin += '</li>';
        $(mainLin).appendTo("#nav");

        /*---------SEGURIDAD---------*/
        var acc_seguridad = '<li ><a href="#">SEGURIDAD</a>';
        acc_seguridad += '<ul class="subs">';
        acc_seguridad += '<li><a href="#">Seguridad</a>';
        acc_seguridad += '<ul>';
        acc_seguridad += '<li><a href="../Matenimientos/CambiarClave.aspx">Cambiar Contraseña</a></li>';
        acc_seguridad += '</ul>';
        acc_seguridad += '</li>';
        acc_seguridad += '</ul>';
        acc_seguridad += '</li>';
        $(acc_seguridad).appendTo("#nav");
        /*---------END SEGURIDAD---------*/

        var acc_salir = '<li ><a href="../../Login.aspx">SALIR</a>';
        acc_salir += '</li>';
        $(acc_salir).appendTo("#nav");
    }

    if (Rol == '04') {

        /*---------ADMINISTRADOR---------*/
        var mainLin = '';
        /*var mainLin = '<li><a href="#">Administración</a>';
        mainLin += '<ul class="subs">';
        mainLin += '<li><a href="#">RRHH</a>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../caMiBoleta/cMiBoleta.aspx">Mis Boletas</a></li>';
        mainLin += '</ul>';
        mainLin += '</li>';*/

        mainLin += '<li><a href="#">Control Asistencia</a>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../Justificacion/GenerarJustificacion.aspx">Permisos, Justificaciones y Compensaciones</a></li>';
        //mainLin += '<li><a href="../Matenimientos/MAsignarTurnoMasivos.aspx">Asignar Turnos Masivos</a></li>';
        mainLin += '</ul>';
        mainLin += '</li>';

        mainLin += '</ul>';
        mainLin += '</li>';
        $(mainLin).appendTo("#nav");

        /*---------REPORTES---------*/
        var acc_reportes = '<li ><a href="#">REPORTES</a>';
        acc_reportes += '<ul class="subs">';
        acc_reportes += '<li><a href="#">Control Asistencia</a>';
        acc_reportes += '<ul>';
        acc_reportes += '<li><a href="../caReporteGeneral/cReporteGeneral.aspx">Reporte General</a></li>';
        acc_reportes += '</ul>';
        acc_reportes += '</li>';
        acc_reportes += '</ul>';
        acc_reportes += '</li>';
        $(acc_reportes).appendTo("#nav");
        /*---------END REPORTES---------*/

        /*---------SEGURIDAD---------*/
        var acc_seguridad = '<li ><a href="#">SEGURIDAD</a>';
        acc_seguridad += '<ul class="subs">';
        acc_seguridad += '<li><a href="#">Seguridad</a>';
        acc_seguridad += '<ul>';
        acc_seguridad += '<li><a href="../Matenimientos/CambiarClave.aspx">Cambiar Contraseña</a></li>';
        acc_seguridad += '</ul>';
        acc_seguridad += '</li>';
        acc_seguridad += '</ul>';
        acc_seguridad += '</li>';
        $(acc_seguridad).appendTo("#nav");
        /*---------END SEGURIDAD---------*/

        var acc_salir = '<li ><a href="../../Login.aspx">SALIR</a>';
        acc_salir += '</li>';
        $(acc_salir).appendTo("#nav");
    }

    /// proteccion de codigo

    ////Disable cut copy paste
    //$('body').bind('cut copy paste', function (e) {
    //    e.preventDefault();
    //});

    ////Disable mouse right click
    //$("body").on("contextmenu", function (e) {
    //    return false;
    //});



    //$(document).keydown(function (event) {
    //    if (event.keyCode == 123) { // Prevent F12
    //        return false;
    //    } else if (event.ctrlKey && event.shiftKey && event.keyCode == 73) { // Prevent Ctrl+Shift+I        
    //        return false;
    //    }
    //});

};

//$(document).keydown(function (event) {
//    if (event.keyCode == 123) { // Prevent F12
//        return false;
//    } else if (event.ctrlKey && event.shiftKey && event.keyCode == 73) { // Prevent Ctrl+Shift+I        
//        return false;
//    }
//});

//funcion nueva
function RR() {
    if ($.browser.msie && $.browser.version.substr(0, 1) < 7) {
        $('li').has('ul')
            .mouseover(function () {
                $(this).children('ul').css('visibility', 'visible');
            })
            .mouseout(function () {
                $(this).children('ul').css('visibility', 'hidden');
            })
    }
}

// Utilities functions
function SelectAllCheckBoxes(CheckBoxControl, GridName) {
    if (CheckBoxControl.checked == true) {
        var i;
        for (i = 0; i < document.forms[0].elements.length; i++) {
            if ((document.forms[0].elements[i].type == 'checkbox') &&
                (document.forms[0].elements[i].name.indexOf(GridName) > -1)) {
                document.forms[0].elements[i].checked = true;
            }
        }
    }
    else {
        var i;
        for (i = 0; i < document.forms[0].elements.length; i++) {
            if ((document.forms[0].elements[i].type == 'checkbox') &&
                (document.forms[0].elements[i].name.indexOf(GridName) > -1)) {
                document.forms[0].elements[i].checked = false;
            }
        }
    }
}
