
$("#btnAcEQ").click(function () {
    $("#modal-content").load("Equipment/Add")
    $(".modal-title").html("Agregar Equipo");
});

$(".btnAcEQUpdate").click(function () {
    $("#modal-content").load("Equipment/UpdateEq/" + $(this).data("id"))
    $(".modal-title").html("Editar Equipo");
});

$(".btnAcEQDetail").click(function () {
    $("#modal-content").load("Equipment/DetailEq/" + $(this).data("id"))
    $(".modal-title").html("Datos del Equipo");
});

$(".btnAcEQDelete").click(function () {
    $("#modal-content-small").load("Equipment/DeleteEq/" + $(this).data("id"))
    $(".modal-title").html("CONFIRMAR");
});

/*************Components****************/

$(".btnAcCP").click(function () {
    console.log("componentes", $(this).data("id"));
    $("#modal-content").load("Component/AddCmp/" + $(this).data("id"));
     $(".modal-title").html("Gestión de componentes");
});

$(".btnDetailCP").click(function () {
    $("#modal-content").load("Component/DetailCmp/" + $(this).data("id"));
    $(".modal-title").html("Gestión de componentes");
});

$(".btnEditCP").click(function () {
    $("#modal-content").load("Component/UpdateCmp/" + $(this).data("id"));
    $(".modal-title").html("Gestión de componentes");
});

$(".btnDeleteCP").click(function () {
    $("#modal-content-small").load("Component/DeleteCmp/" + $(this).data("id"));
    $(".modal-title").html("Gestión de componentes");
});


