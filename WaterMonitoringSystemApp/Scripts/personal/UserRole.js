$(".changeRole").change(function () {

    var idRol = this.value;
    var padre = $(this).parent();
    var hermanoPadre = padre.siblings("div");
    var wordSpaceStatus = hermanoPadre.children("div");
    var idUser = $(this).siblings("input").val();
    wordSpaceStatus.addClass("SaveRolLoading");
    $.ajax(
        {
            url: "/UserRol/addRole/"+idUser+"/"+idRol,
            type: 'GET',
            success: function (response) {
                if (response.success) {

                    wordSpaceStatus.removeClass("SaveRolLoading");
                    wordSpaceStatus.addClass("SaveRolSuccess");
                    setTimeout(function () {
                        wordSpaceStatus.removeClass("SaveRolSuccess");
                    }, 2000);
                }
            },
            error: function (response) {
                wordSpaceStatus.removeClass("SaveRolLoading");
                wordSpaceStatus.addClass("SaveRolError");
                setTimeout(function () {
                    wordSpaceStatus.removeClass("SaveRolError");
                }, 2000);
            }
         });
});