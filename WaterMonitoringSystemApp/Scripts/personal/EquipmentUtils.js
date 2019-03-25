$("#btnSalvarEq").click(function () {
    var error = 0;
    $(':input[data-val-required]', '#formEQ').each(function () {
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
        $("#formEQ").submit();
    }
});


$(".modal").on("hidden.bs.modal", function () {
    console.log("Limpiar modal");
    $("#modal-content").html("");
});



/****Validacion para formulario de componentes****/
$("#btnSalvarCmp").click(function () {
    var error = 0;
    $(':input[data-val-required]', '#formCPM').each(function () {
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
        $("#formCMP").submit();
    }
});