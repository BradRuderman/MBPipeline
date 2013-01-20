$(function () {
    clearModal();
});

function clearModal() {
    $('#modal_wrap').html("<div id=\"myModal\" class=\"modal hide fade\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myModalLabel\" aria-hidden=\"true\"><div class=\"modal-header\"><button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">×</button><h3 id=\"myModalLabel\"></h3></div><div class=\"modal-body\"></div></div>");
    $('#myModal').on('hidden', function () {
        clearModal();
    });
}

function LoadModal(header) {
    $('#myModalLabel').text(header);
   // alert('inside');
}

function accounts_index() {
    //alert('hi');
}

function MapsLoad() {
    initialize();
}