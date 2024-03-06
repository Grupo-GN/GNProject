




function Menu_RecursosHumanos() {
    $('#nav').html('');

    /*---------AYUDA---------*/
    var acc_ayuda = '<li ><a href="#">RRHH</a>';
    acc_ayuda += '<ul class="subs">';
    acc_ayuda += '<li><a href="#">Procesos</a>';
    acc_ayuda += '<ul>';
    acc_ayuda += '<li><a href="../caPasarPlanilla/sPasarPlanilla.aspx">Pasar Novedades a Planilla</a></li>';
    acc_ayuda += '<li><a href="JustificacionRRHH.aspx">Permisos y Justificaciones</a></li>';
    acc_ayuda += '</ul>';
    acc_ayuda += '</li>';
    acc_ayuda += '</ul>';
    acc_ayuda += '</li>';
    $(acc_ayuda).appendTo("#nav");
    /*---------END AYUDA---------*/

    var acc_salir = '<li ><a href="Acceso.aspx">SALIR</a>';
    acc_salir += '</li>';
    $(acc_salir).appendTo("#nav");
};