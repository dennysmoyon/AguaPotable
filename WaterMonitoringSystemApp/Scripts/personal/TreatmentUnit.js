

$("#btnAcTU").click(function () {
    console.log("datos del formulario");
    $("#modal-content").load("TreatmentUnit/Add")
    $(".modal-title").html("Agregar Tanque de Reserva (UT.)");
});


$(".btnAcTUUpdate").click(function () {
    console.log("datos del formulario update");
    $("#modal-content").load("TreatmentUnit/UpdateTu/" + $(this).data("id"))
    $(".modal-title").html("Editar Tanque de Reserva (UT.)");
});

$(".btnAcTUDetail").click(function () {
    $("#modal-content").load("TreatmentUnit/DetailTu/" + $(this).data("id"))
    $(".modal-title").html("Detalle Tanque de Reserva (UT.)");
});

$(".btnAcTUDelete").click(function(){
    var idTuDelete = $(this).data("id");
    $("#modal-content-small").load("TreatmentUnit/DeleteTu/" + $(this).data("id"));
    $(".title-small-modal").html("CONFIRMAR");
});
/*
var modalConfirm = function (callback) {

    $("#btn-confirm").on("click", function () {
        console.log("idTuDelete", idTuDelete);
        $("#miConfirm").modal('show');
    });

    $("#modal-btn-si").on("click", function () {
        callback(true);
        $("#miConfirm").modal('hide');
    });

    $("#modal-btn-no").on("click", function () {
        callback(false);
        $("#miConfirm").modal('hide');
    });
};


modalConfirm(function (confirm) {
    if (confirm) {
        //Acciones si el usuario confirma
        console.log("idTuDelete", idTuDelete);
    } 
});

*/