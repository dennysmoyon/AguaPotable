console.log("ws", ws);
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
        var htm = '<tr><td class="col-xs-2">';
        htm += dataJson.Data_Sensor_PH + "</td><td class='col-xs-2'>";
        htm += dataJson.Data_Sensor_LW + "</td><td  class='col-xs-2'>";
        htm += dataJson.Data_Sensor_OD + "</td><td  class='col-xs-2'>";
        htm += dataJson.Data_Sensor_CT + "</td><td  class='col-xs-2'>";
        htm += dataJson.Data_Sensor_ORP + "</td><td  class='col-xs-2'>";
        htm += getDateFormat(dataJson.Date_Register) + "</td></tr>";
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
               var url = "FlowDataSensors/reportSensors/" + _dateSince + "!" + _dateUntil;
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