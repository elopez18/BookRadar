$(document).ready(function () {

    inicializarTablaLibros();

});
function inicializarTablaLibros() {
    $('#tblLibros').DataTable({
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

function AbrirModalBuscarPorAutor() {
    $.ajax({
        url: urlAbrirModalBuscar,
        type: 'GET',
        success: function (data) {
            $('#modalBuscar .modal-content').html(data);
            $('#modalBuscar').modal('show');

         
        }
    });
};

function cancelBuscarModal () {
    var autorInput = $('#autorInput');
    autorInput.val("");
    $('#modalBuscar').modal('hide');
};


function BuscarPorAutor() {
    $("#spinner").show();
    var autorInput = $('#autorInput');
    $.ajax({
        url: urlbuscarPorAutor,
        type: 'POST',
        data: {
            Autor: autorInput.val(),
        },
        success: function (response) {
            if (response.resultado) {
                autorInput.val("");
                $("#spinner").hide();
                $('#modalBuscar').modal('hide');
                $('.modal-backdrop').remove();
                $('body').removeClass('modal-open');
                $('body').css('padding-right', '');
                $('#divLibros').html(response.vista);
                inicializarTablaLibros();
            } else {
                alertify.error("No se han encontrado coincidencias.");
                autorInput.val("");
                $("#spinner").hide();
                $('#modalBuscar').modal('hide');
                $('.modal-backdrop').remove();
                $('body').removeClass('modal-open');
                $('body').css('padding-right', '');
            }
        },
        error: function () {
            alertify.error('Error al intentar enviar la solicitud');
        }
    });
};


function GuardarBusqueda(titulo) {
    $("#spinner").show();
    $.ajax({
        url: urlGuardarBusqueda,
        type: 'POST',
        data: {
            titulo: titulo,
        },
        success: function (response) {
            if (response.resultado) {
                $("#spinner").hide();
                alertify.success(response.msg);
                alert(response.msg);
            } else {
                $("#spinner").hide();
                alertify.error(response.msg);
                alert(response.msg);
            }
        },
    });
};



