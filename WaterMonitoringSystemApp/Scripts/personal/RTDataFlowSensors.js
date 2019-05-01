console.log("ws", ws);
var lstUnitTreatment = [];
var idEq = 0;

window.onload = () => {

    //Escuchamos eventos de conexion de websockeet
    if (ws) {
        ws.addEventListener("message", function (event) {

            if (event.data == "successfull") {

                console.log("Its  this conected ", event.data);
            } else {
                fillDataFlow(event.data)
            }
        });
    }

 
    //Actualizamos la tabla
    function fillDataFlow(data) {
        var dataJson = JSON.parse(data);
        var htm = '<tr><td class="col-xs-1">';
        htm += dataJson.Data_Sensor_PH + "</td><td class='col-xs-2'>";
        htm += dataJson.Data_Sensor_LW + "</td><td  class='col-xs-2'>";
        htm += dataJson.Data_Sensor_OD + "</td><td  class='col-xs-2'>";
        htm += dataJson.Data_Sensor_CT + "</td><td  class='col-xs-1'>";
        htm += dataJson.Data_Sensor_ORP + "</td><td  class='col-xs-2'>";
        htm += getDateFormat(dataJson.Date_Register) + "</td><td  class='col-xs-2'>";
        htm += dataJson.EquipmentDTO.Cod_Equipment + "</td></tr>";
        $("#tableFlowSensors tbody").prepend(htm);
    }

    function getDateFormat(date) {
        var date = new Date(date);
        var options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
        return date.toLocaleDateString('es' , options);
        //return date.getDay() + "/" + date.getMonth() + "/" + date.getYear() + "\n" + date.getHours() +":"+ date.getMinutes() +":"+ date.getSeconds()  
    }

}

   $(document).ready(function() {
        
       $(function () {

           //btn
           $("#btnCharts").prop("disabled", true);

           $("#btnCharts").click(function () {
               var iframe = $('#iframedfs');
               iframe.attr('src', '');
               _dateSince = $("#datePick1").val();
               _dateUntil = $("#datePick2").val();
               console.log("_dateUntil", _dateUntil);
               console.log("_dateSince", _dateSince);
               if (idEq == 0) {
                   alert("No se ha definido el Equipo")
                   return;
               }

               var url = "FlowDataSensors/reportSensors/" + _dateSince + "/" + _dateUntil + "/" + idEq;
               iframe.attr('src', url);
           });

           //Date pic 1
           $('#datetimepicker1').datetimepicker({
               format: "DD-MM-YYYY",
           });

           //Date pic 2
           $('#datetimepicker2').datetimepicker({
               format: "DD-MM-YYYY",
               useCurrent: false
           }).on("dp.change", function (e) {

               if ($("#datePick1").val() != "" && $("#datePick2").val() != "") {
                   $("#btnCharts").prop("disabled", false);
               }
           });


           //Date pic 1
           $("#datetimepicker1").on("dp.change", function (e) {
               $("#btnCharts").prop("disabled", true);
               $('#datePick2').val("");
               $('#datetimepicker2').data("DateTimePicker").minDate(e.date);
               var _maxDate = moment(e.date, "dd-mm-yyyy").add(30, 'days');
               $('#datetimepicker2').data("DateTimePicker").maxDate(_maxDate);
           });
       });
   });

   $(Document).ready(function () {

       setSelectTu();
   });

   function setSelectTu() {

       $("#treatment").empty();
       $.ajax({
           url: "/TreatmentUnit/getTu/",
           type: 'GET',
           success: function (response) {
               lstUnitTreatment = response;
               $("#treatment").empty();
               option = new Option("Seleccione una UT", "", true, true);
               $(option).html("Seleccione una UT");
               $("#treatment").append(option);
                
               if (lstUnitTreatment.length > 0) {
                   for (var item in lstUnitTreatment) {
                       var text = lstUnitTreatment[item].Cod_Tu + " " + lstUnitTreatment[item].Description;
                       option = new Option(text, lstUnitTreatment[item].Id_Tu, false, false);
                       $(option).html(text);
                       $("#treatment").append(option);
                   }
               }
           },
           error: function (response) {
               //wordSpaceStatus.removeClass("SaveRolLoading");
               //wordSpaceStatus.addClass("SaveRolError");
               //setTimeout(function () {
               //    wordSpaceStatus.removeClass("SaveRolError");
               //}, 2000);
           }
       });
   }

   function setValueUt(value) {

       $("#equipment").empty();
       option = new Option("Seleccione una EQ", "", true, true);
       $(option).html("Seleccione una EQ");
       $("#equipment").append(option);

       if (value == "") {

           $("#equipment").prop('disabled', true);
           return;
       }

       var equimentsFilter = [];
       if (lstUnitTreatment.length > 0) {
           
           var tu = lstUnitTreatment.find(function (element) {
               return element.Id_Tu = value;
           });

           if (tu == null) {
               return;
           }
           
           equimentsFilter = tu.Equipments;
           $("#equipment").prop('disabled', false);
           if (equimentsFilter.length > 0) {

               for (var item in equimentsFilter) {
                   var text = equimentsFilter[item].Cod_Equipment + " " + equimentsFilter[item].Description;
                   option = new Option(text, equimentsFilter[item].Id_Equipment, false, false);
                   $(option).html(text);
                   $("#equipment").append(option);
               }
           }

       }
   }

   function setValueEq(valueEq) {
       console.log("valueEq", valueEq)

       idEq = 0;
       if (valueEq == "")
           return null;

       idEq = valueEq;
   }