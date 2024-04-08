$(document).ready(function () {
    console.log(urlProc("/Procesos/FrmGenerarPago.aspx"));

    $("#grid-basic").bootgrid({
        ajax: true,
        rowCount: [15, 25, 50],
        keepSelection: false,
        sorting: false,
        searchSettings: {
            delay: 250,
            characters: 3
        },
        labels: {
            all: "TODOS",
            loading: "Cargando...",
            infos: "Mostrando del {{ctx.start}} al {{ctx.end}} de {{ctx.total}} registros",
            noResults: "¡No se han encontrado resultados!",
            refresh: "Refrescar",
            search: "Buscar"
        },
        post: function () {

        },
        url: urlProc("/Personal/ListarCargoPersonal"),
        formatters: {
            "commands": function (column, row) {
                return "<button type=\"button\" class=\"btn btn-xs btn-default command-edit\" data-row-id=\"" + row.id + "\"><span class=\"fa fa-pencil\"></span></button> " +
                    "<button type=\"button\" class=\"btn btn-xs btn-default command-delete\" data-row-id=\"" + row.id + "\"><span class=\"fa fa-trash-o\"></span></button>";
            }
        }
    });


});

