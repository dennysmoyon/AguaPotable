

function animatedBtn(even) {
        var icon = $(even).find(">:first-child");
        var inclass = icon.hasClass("card-icon");
        if (inclass) {
            icon[0].classList.remove("card-icon");
            icon.addClass("card-icon-reverse");
            console.log("true", icon);
        } else {
            icon[0].classList.remove("card-icon-reverse");
            icon.addClass("card-icon");
            console.log("false", icon);
        }
}

var map;
var pathIcon = "/../Content/images/iconTu.png";
var Markers = [];
var limitsMap = null;
var infowindow = null;
var idEquipment = null;
var pageLoad = 0;
var _idUt = 0;

function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -1.67098, lng: -78.64712 },
        zoom: 8
    });

    limitsMap = new google.maps.LatLngBounds();
    infowindow = new google.maps.InfoWindow();
    loadUnitTreatment();
}

function loadUnitTreatment() {
    $.get("http://cynaiot.com/api/FdsAPI/", (data, status) => {

        var tuJson = JSON.parse(data);

        markerDefault = new google.maps.Marker({
            position: { lat: -1.67098, lng: -78.64712 },
            icon: "",
            draggable: false,
        });

        limitsMap.extend(markerDefault.position);

        for (var item in tuJson) {
            console.log("elemento " + item, tuJson[item]);
            var marker = new google.maps.Marker({
                position: { lat: tuJson[item].Latitude, lng: tuJson[item].Longitude },
                icon: pathIcon,
                draggable: false,
                codTu: tuJson[item].Id_Tu,
                description: tuJson[item].Description,
                codigoUt: tuJson[item].Cod_Tu,
            });
            marker.setMap(map);
            Markers.push(marker);
            Markers.push(markerDefault);
            limitsMap.extend(marker.position);

            google.maps.event.addListener(marker, 'click', (function (marker, item) {
                return function () {
                    console.log("marker", marker.description);
                    infowindow.setContent(marker.description);
                    infowindow.open(map, marker);
                    loadModal(marker.codigoUt, marker.codTu);
                }
            })(marker, item));

            map.fitBounds(limitsMap);

        }
    });
}

function loadModal(codigoUt, idUt) {

    $("#codUT").html(codigoUt);
    $("#miConfirm").modal('show');
    var option = null;
    var equipments = [];
    console.log("pageLoad", pageLoad);

    if (pageLoad == 0 || _idUt != idUt) {

        $.get("http://cynaiot.com/api/TreatmentUnitAPI/" + idUt, (data, status) => {

            $("#equipment").empty();
            option = new Option("Seleccione un equipo", "",true,true);
            $(option).html("Seleccione un equipo");
            $("#equipment").append(option);
            _idUt = idUt;

            var jsonTu = JSON.parse(data);
            console.log("jsonTu ", jsonTu);
            if (data != null) {

                equipments = jsonTu.Equipments;
                if (equipments.length > 0) {

                    for (var item in equipments) {
                        var text = equipments[item].Cod_Equipment + " " + equipments[item].Description;
                        option = new Option(text, equipments[item].Id_Equipment, false, false);
                        $(option).html(text);
                        $("#equipment").append(option);
                    }
                    pageLoad = 1;
                }
            }
        });
    }
}

function setValue(valueSelect) {

    idEquipment = valueSelect;
}

$("#btnBuscarEquip").click(function () {

    if (idEquipment != null) {
        
        window.location.href = "FlowDataSensors/Monitor" + "/" + idEquipment;
    }else {
        alert("Tiene que selecionar un equipo");
    }
});