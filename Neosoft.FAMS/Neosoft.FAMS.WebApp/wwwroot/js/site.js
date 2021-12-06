// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
console.log(1);

$(document).ready(function () {
    $('#myTable').dataTable({
        'aoColumnDefs': [{
            'bSortable': false,
            'aTargets': ['nosort']
        }]
    });

    $('.hideAfter3Sec').delay(5000).fadeOut(2000);
});

function loaderVisible() {
    $('.ajax-loader').css("visibility", "visible");
}

function loaderHide() {
    $('.ajax-loader').css("visibility", "hidden");
}
function ajaxErrorOccured() {
    $('.ajaxError').css("visibility", "visible");
}
   
