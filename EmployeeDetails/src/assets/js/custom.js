// JavaScript Document

$(document).ready(function () {
    $(function () {
        $('.login-bg').css({
            height: $(window).innerHeight()
        });
    });

    $('#tyre-status').multiselect();
    $('#cashing-type').multiselect();
    $('#reason-complaint').multiselect();
    $('#reason-failure').multiselect();
    $('#resolution').multiselect();
    $('#vec-app').multiselect();
    $('#tyre-pos').multiselect();
    $('#tyre-app').multiselect();
    $('#dismount-reason').multiselect();
});

function loadTable() {
    $(document).ready(function () {
        $(".res-table").reflowTable();
        /*$('#reason-complaint').multiselect();
        $('#reason-failure').multiselect();
        $('#resolution').multiselect();*/
    });

    var signaturePad;
    jQuery(document).ready(function () {
        var signaturePadCanvas = document.querySelector('#signature-pad-canvas');
        if(signaturePadCanvas){
            var parentWidth = jQuery(signaturePadCanvas).parent().outerWidth();
            signaturePadCanvas.setAttribute("width", parentWidth);
            signaturePad = new SignaturePad(signaturePadCanvas);
        }       
    });

}

