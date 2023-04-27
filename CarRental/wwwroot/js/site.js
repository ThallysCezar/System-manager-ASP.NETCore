// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

getDatatable('#table-departments');
getDatatable('#table-seller');
getDatatable('#table-user');


function getDatatable(id) {
    $(document).ready(function () {
        $(id).DataTable();
    });
}

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});