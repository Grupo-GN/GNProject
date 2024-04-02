function initilize() {
    $('#TabContainer').tabs();
    $('#TabContainer').tabs({ disabled: [1] });

    disGrabar = window.setInterval(function () {
        Disable_btnGrabar(true);
    }, 100);

    disCancel = window.setInterval(function () {
        Disable_btnCancelar(true);
    }, 100);

    disUpdate = window.setInterval(function () {
        Disable_btnActualizar(true);
    }, 100);

    disDelete = window.setInterval(function () {
        Disable_btnEliminar(true);
    }, 100);
    $('#txtBuscar').keyup(function () {
        if ($('#cboBusquedaEn').val() != 'Todos') {
            inicio = 0;
            Lista_Personal_x_Filtro_Columna(Get_Compania(), null, Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
        }
    });
    $('#tbodyPersonal').on('click', '.linkEditar', function () {
        PROCESO = '02';
        $('#TabContainer').tabs('enable');
        $('#TabContainer').tabs({ active: 1 });
    });
}