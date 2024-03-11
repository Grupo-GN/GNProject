function Get_PersonalLogin_Datos(Personal_id) {

    var params = {
        Personal_id: Personal_id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "../../MasterPage/HelpASP.aspx/Get_PersonalLogin_Datos",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var PersonalLogin = response.d;
            if (PersonalLogin) {
                Session.set('Usuario', PersonalLogin);
            } else {
                setTimeout("location.href='../pConfigReporte/sConfigReporte.aspx'", 5);
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });


};


function Get_Alertas_By_Rol() {

    var usuario = Session.get('Usuario');

    var params = {
        Usuario_Id: usuario.Personal_Id,
        Rol_Id: usuario.RolSistema
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "../../MasterPage/HelpASP.aspx/Get_Alertas_By_Rol",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var alertas = response.d;
            var sum = 0;
            var len = alertas.length - 1;
            $('#tblAlertas').html('');
            for (var i = 0; i <= len; i++) {
                sum += alertas[i];
            }

            if (sum == 0) {
                $('#barMensaje').hide();
            } else {
                $('#barMensaje').show();
                var html = '<tr>';
                html += '<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../pAlertas/sNuevos.aspx">Nuevos Reportes : </a></td>';
                html += '<td>' + alertas[0] + '</td>';
                if (usuario.RolSistema == '01') {
                    html += '<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../pRepPendientesADM/sRepPendientesADM.aspx">Reportes en Curso : </a></td>';
                    html += '<td>' + alertas[1] + '</td>';
                } else {
                    html += '<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../pRepPendientes/sRepPendientes.aspx">Reportes en Curso : </a></td>';
                    html += '<td>' + alertas[1] + '</td>';
                }

                html += '<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../pAlertas/sAccionesFin.aspx">Acciones por finalizar : </a></td>';
                html += '<td>' + alertas[2] + '</td>';
                html += '<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../pAlertas/sAccionesFFecha.aspx">Acciones fuera de fecha : </a></td>';
                html += '<td>' + alertas[3] + '</td>';
                html += '<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../pAlertas/sAccionesRevisar.aspx">Acciones por revisar : </a></td>';
                html += '<td>' + alertas[4] + '</td>';
                html += '<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../pAlertas/sAccionesDeprobados.aspx">Acciones desaprobadas : </a></td>';
                html += '<td>' + alertas[5] + '</td>';
                if (usuario.RolSistema == '01') {
                    html += '<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../pAlertas/sAlertOsigermin.aspx">Osigermin - Preliminar : </a></td>';
                    html += '<td>' + alertas[6] + '</td>';
                    html += '<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../pAlertas/sAlertOsigermin.aspx">Osigermin - Final: </a></td>';
                    html += '<td>' + alertas[7] + '</td>';
                }
                html += '</tr>';
                $(html).appendTo('#tblAlertas');

            }

        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Redireccionar_Rol() {

    var usuarioSes = Session.get('Usuario');    
   
    var Rol = usuarioSes.RolSistema;

    if (Rol == '01') {
        /*---------ADMINISTRADOR---------*/
        var mainLin = '<li><a href="#">Administrador</a>';
        mainLin += '<ul class="subs">';
        mainLin += '<li><a href="#">Acceso</a>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../pChangePass/sChangePass.aspx">Cambiar mi contraseña</a></li>';
        mainLin += '</ul>';
        mainLin += '</li>';
        mainLin += '<li><a href="#">Configurar Reporte</a>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../pConfigReporte/sConfigReporte.aspx">Datos para el Reporte</a></li>';
        mainLin += '<li><a href="../pMoreConfigReporte/sMConfigReporte.aspx">Configuraciones Adicionales</a></li>';
        mainLin += '</ul>';
        mainLin += '</li>';
        mainLin += '<li><a href="#">Personal</a>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../pPersonal/sPersonal.aspx">Personal</a></li>';
        mainLin += '<li><a href="../pInformeGerencia/sInformeGerencia.aspx">Gerentes</a></li>';
        mainLin += '<li><a href="../pCargo/sCargo.aspx">Cargo</a></li>';
        mainLin += '<li><a href="../pCategoriaAuxiliar/sCategoriaAuxiliar.aspx">Área</a></li>';
        mainLin += '<li><a href="../pCategoriaAuxiliar2/sCategoriaAuxiliar2.aspx">Sección</a></li>';
        mainLin += '</ul>';
        mainLin += '</li>';
        mainLin += '<li><a href="#">Ubicacion</a>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../pLocalidad/sLocalidad.aspx">Localidad</a></li>';
        mainLin += '</ul>';
        mainLin += '</li>';
        mainLin += '</ul>';
        mainLin += '</li>';
        $(mainLin).appendTo("#nav");

        /*---------PROCESOS---------*/
        var acc_procesos = '<li ><a href="../Inicio/InicioSis.aspx">PROCESOS</a>';
        acc_procesos += '<ul class="subs">';
        acc_procesos += '<li><a href="#">Incidencia</a>';
        acc_procesos += '<ul>';
        acc_procesos += '<li><a href="../pReporteIncidente/sReporteIncidente.aspx">Reportar Incidencia</a></li>';
        acc_procesos += '<li><a href="../pListReportes/ListReportes.aspx">Todos los Reportes de Incidencia</a></li>';
        acc_procesos += '<li><a href="../pRepPendientes/sRepPendientes.aspx">En Curso como Jefe</a></li>';
        acc_procesos += '<li><a href="../pRepPendientesADM/sRepPendientesADM.aspx">En Curso como Administrador</a></li>';
        
        acc_procesos += '</ul>';
        acc_procesos += '</li>';        
        acc_procesos += '</ul>';
        acc_procesos += '</li>';
        $(acc_procesos).appendTo("#nav");

        /*---------END PROCESOS---------*/

        /*---------REPORTES---------*/
        var acc_reportes = '<li ><a href="#">REPORTES</a>';
        acc_reportes += '<ul class="subs">';
        acc_reportes += '<li><a href="#">Multiples</a>';
        acc_reportes += '<ul>';
        acc_reportes += '<li><a href="../Reportes/rHistorial.aspx">Historial Multiple</a></li>';
        acc_reportes += '<li><a href="../Reportes/IndicesMultriples.aspx">Indices Multiples</a></li>';
        acc_reportes += '</ul>';
        acc_reportes += '</li>';
        acc_reportes += '</ul>';
        acc_reportes += '</li>';
        $(acc_reportes).appendTo("#nav");
        /*---------END REPORTES---------*/

        /*---------AYUDA---------*/
        var acc_ayuda = '<li ><a href="../Inicio/InicioSis.aspx">AYUDA</a>';
        acc_ayuda += '<ul class="subs">';
        acc_ayuda += '<li><a href="#">Manuales</a>';
        acc_ayuda += '<ul>';
        acc_ayuda += '<li><a href="../../Manuales/Manual de Usuario Administrador_Sistema de Incidencia.pdf" target="_blank" >Para el Administrador</a></li>';
        acc_ayuda += '<li><a href="../../Manuales/Manual de Usuario Jefe_Sistema de Incidencia.pdf" target="_blank" >Para el Jefe</a></li>';
        acc_ayuda += '<li><a href="../../Manuales/Manual de Usuario - Realización de AC.pdf" target="_blank" >Como desarrollar una acción correctiva</a></li>';
        acc_ayuda += '</ul>';
        acc_ayuda += '</li>';
        acc_ayuda += '</ul>';
        acc_ayuda += '</li>';
        $(acc_ayuda).appendTo("#nav");
        /*---------END AYUDA---------*/


        var acc_salir = '<li ><a href="../../Login/Acceso.aspx">SALIR</a>';
        acc_salir += '</li>';
        $(acc_salir).appendTo("#nav");
    }

    if (Rol == '02') {
        /*---------ADMINISTRADOR---------*/
        var mainLin = '<li><a href="#">Administración</a>';
        mainLin += '<ul class="subs">';
        mainLin += '<li><a href="#">Acceso</a>';
        mainLin += '<ul>';
        mainLin += '<li><a href="../pChangePass/sChangePass.aspx">Cambiar mi contraseña</a></li>';
        mainLin += '</ul>';
        mainLin += '</li>';
        mainLin += '</ul>';
        mainLin += '</li>';
        $(mainLin).appendTo("#nav");

        /*---------PROCESOS---------*/
        var acc_procesos = '<li ><a href="../Inicio/InicioSis.aspx">PROCESOS</a>';
        acc_procesos += '<ul class="subs">';
        acc_procesos += '<li><a href="#">Incidencia</a>';
        acc_procesos += '<ul>';
        acc_procesos += '<li><a href="../pReporteIncidente/sReporteIncidente.aspx">Reportar Incidencia</a></li>';
        acc_procesos += '<li><a href="../pListReportesPlanta/sListReportesPlanta.aspx">Mis Reportes</a></li>';
        acc_procesos += '<li><a href="../pRepPendientes/sRepPendientes.aspx">En Curso</a></li>';
        acc_procesos += '</ul>';
        acc_procesos += '</li>';
        acc_procesos += '</ul>';
        acc_procesos += '</li>';
        $(acc_procesos).appendTo("#nav");
        /*---------END PROCESOS---------*/

        /*---------AYUDA---------*/
        var acc_ayuda = '<li ><a href="../Inicio/InicioSis.aspx">AYUDA</a>';
        acc_ayuda += '<ul class="subs">';
        acc_ayuda += '<li><a href="#">Manuales</a>';
        acc_ayuda += '<ul>';
        acc_ayuda += '<li><a href="../../Manuales/Manual de Usuario Jefe_Sistema de Incidencia.pdf" target="_blank" >Para el Jefe</a></li>';
        acc_ayuda += '<li><a href="../../Manuales/Manual de Usuario - Realización de AC.pdf" target="_blank" >Como desarrollar una acción correctiva</a></li>';
        acc_ayuda += '</ul>';
        acc_ayuda += '</li>';
        acc_ayuda += '</ul>';
        acc_ayuda += '</li>';
        $(acc_ayuda).appendTo("#nav");
        /*---------END AYUDA---------*/

        var acc_salir= '<li ><a href="../../Login/Acceso.aspx">SALIR</a>';
        acc_salir += '</li>';
        $(acc_salir).appendTo("#nav");
    }

};