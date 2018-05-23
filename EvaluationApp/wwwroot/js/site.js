// Write your JavaScript code.

$(document).ready(function () {
    $(".nav-tabs a").click(function () {
        $(this).tab('show');
    });
});

$(function () {
    $("select").chosen();
});


function createModal(url) {
    $('#modelContent').load(url);
    $('#myModal').modal('show');
}

$(document).ready(function () {
    $('#table_id').DataTable({
        "order": [],
        "columnDefs": [{
            "targets": 'no-sort',
            "orderable": false,
        }]
    });
});
    

$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});