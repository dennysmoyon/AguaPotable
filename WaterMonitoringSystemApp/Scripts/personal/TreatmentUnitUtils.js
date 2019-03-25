$("#btnSalvarTu").click(function () {
    console.log("Salvar...............");
    var error = 0;
    $(':input[data-val-required]', '#formTU').each(function () {
        console.log("this", $(this).valid());
        $(this).valid();
        if ($(this).val() == '') {
            if (error == 0) {
                var tab = $(this).closest('.tab-pane').attr('id');

                $('#MyTabs a[href="#' + tab + '"]').tab('show');
                $(this).focus();
            }
            error = 1;
        }
    });
    if (error == 1) {
        console.log("no es correcto");
        return false;
    } else {
        $("#formTU").submit();
    }
});


$(".modal").on("hidden.bs.modal", function () {
    console.log("Limpiar modal");
    $("#modal-content").html("");
});

$(document).ready(function () {
    $(".latitude").numeric(".");
    $(".longitude").numeric(".");
    getLocation();
});

function getLocation() {
    console.log("Geolocalizacion");
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showInputPosition);
    } else {
        alert("No soporta la Geolocalización");
    }
}

function showInputPosition(position) {
    console.log("Geolocalizacion define");
    $(".latitude").val(position.coords.latitude);
    $(".longitude").val(position.coords.longitude);
}