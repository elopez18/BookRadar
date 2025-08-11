$(document).ready(function () {

    inicializarTablaLibros();

});
function inicializarTablaLibros() {
    $('#tblHistory').DataTable({
        destroy: true,
        paging: true,
        lengthChange: true,
        searching: true,
        ordering: true,
        info: true,
        autoWidth: true,
        lengthMenu: [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Mostrar Todo"]],
        language: {
            search: "Buscar:",
            sLengthMenu: "Mostrar _MENU_ registros",
            paginate: {
                first: "Primero",
                previous: "Anterior",
                next: "Siguiente",
                last: "Ultimo",
            },
            info: "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            zeroRecords: "No se han encontrado coincidencias.",
        }
    });
}