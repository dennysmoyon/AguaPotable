const OD = "chart-containerOX";
const PH = "chart-containerPH";
const LW = "chart-containerLW";
const CD = "chart-containerCD";
const ORP = "chart-containerORP";

var _dataSourceOD = {}
var _dataSourceLW = {};
var _dataSourceORP = {};
var _dataSourceCT = {};
var _dataSourcePH = {};
var _dataSourceFullChars = {};
var _category = [];
var _data = [];
var _dateLabel = "";
var idEquipment = "";

/*
*Escucha eventos del socket
*/
window.onload = () => {
    console.log("Datos a verificar")
    if (ws) {
        ws.addEventListener("message", function (event) {

            if (event.data == "successfull") {

                console.log("Its  this conected ", event.data);
            } else {

                idEquipment = $("#idEquipment").val();
                console.log("idEquip", idEquip);

                var jsonData = JSON.parse(event.data);
                console.log("_dataSourceLW", _dataSourceLW);
                var newData = $.extend({}, _dataSourceLW);
                newData.value = jsonData.Data_Sensor_LW.toString();
                $("#chart-containerLW").updateFusionCharts({
                    dataFormat: "json",
                    dataSource: newData
                });
                console.log("jsonData ", jsonData);
                updateCharts(OD, jsonData.Data_Sensor_OD, jsonData, _dataSourceOD);
                updateCharts(ORP, jsonData.Data_Sensor_ORP, jsonData, _dataSourceORP);
                updateCharts(PH, jsonData.Data_Sensor_PH, jsonData, _dataSourcePH);
                updateCharts(CD, jsonData.Data_Sensor_CT, jsonData, _dataSourceCT);
            }
        });
    }


/////////////////////////////////////////////// SECCION DE SCRIPTS DE GRAFICAS //////////////////////////////////////////////////////////////////

//////Seccion para procesar escripts en el monitor ////
    
    var divOX = document.getElementById("chartOX");
    divOX.addEventListener("click", function () {
        //Proceso para abrir el modal
    });

    //LLenamos el grafico OX
    getDataSensorsDB(OD);

   
    //conectar();
///////////////////////
}


///////////////////////////////////////////////////////////////////////////
////////////// SECCION PARA DEFINICION DE GRAFICOS POR TIPO ///////////////
function setChartOX(_dataSourceOD) {
    $("#chart-containerOX").insertFusionCharts({
        type: "scrollline2d",
        width: "100%",
        height: "100%",
        dataFormat: "json",
        dataSource: _dataSourceOD
    });
}


function setChartsORP(_dataSourceORP) {
    $("#chart-containerORP").insertFusionCharts({
        type: "scrollline2d",
        width: "100%",
        height: "100%",
        dataFormat: "json",
        dataSource: _dataSourceORP
    });
}


function setChartsPH(_dataSourcePH) {
    $("#chart-containerPH").insertFusionCharts({
        type: "scrollline2d",
        width: "100%",
        height: "100%",
        dataFormat: "json",
        dataSource: _dataSourcePH
    });
}


function setChartsCT(_dataSourceCT) {
    $("#chart-containerCD").insertFusionCharts({
        type: "scrollline2d",
        width: "100%",
        height: "100%",
        dataFormat: "json",
        dataSource: _dataSourceCT
    });
}

/*** Proceso de llenado de datos grafica general**/
function setFullCharts(_dataSourceFullChars) {
    console.log("Se procede a llenar los datos grafico completo");
    $(".chart-container-full").insertFusionCharts({
        type: "scrollcombidy2d",
        width: "100%",
        height: "100%",
        dataFormat: "json",
        dataSource: _dataSourceFullChars
    });
}

/*** Proceso de llenado de datos de niveles de agua**/
function setChartLW(lastData) {

    _dataSourceLW = {
        "chart": {
            "caption": "Indicador de Nivel de Agua",
            "lowerlimit": "0",
            "upperlimit": "25",
            "numbersuffix": " mPA",
            "plottooltext": "Nivel actual: <b>$dataValue</b>",
            "theme": "fusion"
        },
        "value": lastData
    };

    $("#chart-containerLW").insertFusionCharts({
        type: "cylinder",
        width: "100%",
        height: "100%",
        dataFormat: "json",
        dataSource: _dataSourceLW
    });
}


/*
*Inicializar datos en los datasource
*/
function initDataSourceOX(_category, _data) {
    _dataSourceOD = {
        "chart": {
            "subcaption": "Ultimo registro " + _dateLabel,
            "yaxisname": "Valor OX",
            "showvalues": "0",
            "numvisibleplot": "12",
            "plottooltext": "<b>$dataValue</b> niveles de O.D $label",
            "theme": "fusion"
        },
        "categories": [
          {
              "category": _category
          }
        ],
        "dataset": [
          {
              "data": _data
          }
        ]
    }
    
    setChartOX(_dataSourceOD);
}

/*
* Iniciamos el grafico para seguimiento de datos de ORP
*/
function initDataSourceORP(categoryORP, dataORP) {

    _dataSourceORP = {
        "chart": {
            "subcaption": "Ultimo registro " + _dateLabel,
            "yaxisname": "Valor ORP",
            "showvalues": "0",
            "numvisibleplot": "12",
            "plottooltext": "<b>$dataValue</b> niveles de O.R.P $label",
            "theme": "gammel"
        },
        "categories": [
          {
              "category": categoryORP
          }
        ],
        "dataset": [
          {
              "data": dataORP
          }
        ]
    }

    setChartsORP(_dataSourceORP);
}

/*
* Iniciamos el grafico para seguimiento de datos de PH
*/
function initDataSourcePH(categoryPh, dataPh) {

    _dataSourcePH = {
        "chart": {
            "subcaption": "Ultimo registro " + _dateLabel,
            "yaxisname": "Valor PH",
            "showvalues": "0",
            "numvisibleplot": "12",
            "plottooltext": "<b>$dataValue</b> niveles de P.H. $label",
            "theme": "candy"
        },
        "categories": [
          {
              "category": categoryPh
          }
        ],
        "dataset": [
          {
              "data": dataPh
          }
        ]
    }

    setChartsPH(_dataSourcePH);
}

/*
* Iniciamos el grafico para seguimiento de datos de PH
*/
function initDataSourceCT(categoryCt, dataCt) {

    _dataSourceCT = {
        "chart": {
            "subcaption": "Ultimo registro " + _dateLabel,
            "yaxisname": "Valor PH",
            "showvalues": "0",
            "numvisibleplot": "12",
            "plottooltext": "<b>$dataValue</b> niveles de C.T. $label",
            "theme": "zune"
        },
        "categories": [
          {
              "category": categoryCt
          }
        ],
        "dataset": [
          {
              "data": dataCt
          }
        ]
    }

    setChartsCT(_dataSourceCT);
}

/*
* Iniciamos el grafico para seguimiento de datos todos los sensores
*/
function initFullCharts(dataPh, dataOrp, dataCt, dataOd, dataLw) {
    _dataSourceFullChars = {
        "chart": {
            "caption": "Gráfica de sensores",
            //"yaxisname": "Population Count",
            //"syaxisname": "Subsidies % of Income",
            "labeldisplay": "rotate",
            //"snumbersuffix": "%",
            "scrollheight": "12",
            "numvisibleplot": "10",
            "drawcrossline": "1",
            "theme": "gammel"
        },
        "categories": [
          {
              "category": _category
          }
        ],
        "dataset": [
          {
              "seriesname": "O.D.",
              "initiallyHidden": "0",
              "parentyaxis": "S",
              "renderas": "line",
              "plottooltext": "<b>$dataValue</b> niveles de O.D $label",
              "showvalues": "0",
              "data": dataOd
          },
          {
              "seriesname": "O.R.P.",
              "initiallyHidden": "0",
              "parentyaxis": "S",
              "renderas": "line",
              "plottooltext": "<b>$dataValue</b> niveles de O.R.P $label",
              "showvalues": "0",
              "data": dataOrp
          },
          {
              "seriesname": "P.H.",
              "initiallyHidden": "0",
              "parentyaxis": "S",
              "renderas": "line",
              "plottooltext": "<b>$dataValue</b> niveles de P.H. $label",
              "showvalues": "0",
              "data": dataPh
          },
          {
              "seriesname": "C.T.",
              "initiallyHidden": "0",
              "parentyaxis": "S",
              "renderas": "line",
              "plottooltext": "<b>$dataValue</b> niveles de C.T. $label",
              "showvalues": "0",
              "data": dataCt
          },
          {
              "seriesname": "N.A.",
              "initiallyHidden": "0",
              "parentyaxis": "S",
              "renderas": "line",
              "plottooltext": "<b>$dataValue</b> niveles de agua $label",
              "showvalues": "0",
              "data": dataLw
          }
        ]
    }

    setFullCharts(_dataSourceFullChars);
}

/*Llama al metodo de base de datos*/
function getDataSensorsDB(typeFill) {
    idEquipment = $("#idEquipment").val();
    console.log("IdEquipment.......", idEquipment);
    $.getJSON('/FlowDataSensors/getFlowDataSensors/'+idEquipment, (dataSnDB) => {

        console.log("LLega los datos de los sensores", dataSnDB);
        
        _category = [];
        _data = [];
        var _dataOrp = [];
        var _dataPh = [];
        var _dataCt = [];
        var _dataLw = [];
        var item;

        //filtro de datos
        for (item in dataSnDB) {
            if (dataSnDB[item]._now) {
                _dateLabel = getDateFormat(new Date(parseInt(dataSnDB[item].Date_Register.replace("/Date(", "").replace(")/", ""), 10)));
            }

            _category.push({
                "label": dataSnDB[item].hours,
                "tooltext": "{br}Fecha: " + getDateFormat(new Date(parseInt(dataSnDB[item].Date_Register.replace("/Date(", "").replace(")/", ""), 10))) + "{br}" + "hora: " + dataSnDB[item].hours
            });
            _data.push({ "value": dataSnDB[item].Data_Sensor_OD })
            _dataOrp.push({"value": dataSnDB[item].Data_Sensor_ORP});
            _dataCt.push({"value" : dataSnDB[item].Data_Sensor_CT});
            _dataPh.push({"value" : dataSnDB[item].Data_Sensor_PH});
            _dataLw.push({"value" : dataSnDB[item].Data_Sensor_LW});
        }

        if (_dateLabel == "" && dataSnDB.length > 0) {
            _dateLabel = getDateFormat(new Date(parseInt(dataSnDB[0].Date_Register.replace("/Date(", "").replace(")/", ""), 10)));
        }


        //establecemos los valores de los graficos
        initDataSourceOX(_category, _data);
        if (dataSnDB.length > 0) {
            setChartLW(dataSnDB[0].Data_Sensor_LW);
        }
        initDataSourceORP(_category, _dataOrp);
        initDataSourcePH(_category, _dataPh);
        initDataSourceCT(_category, _dataCt);
        initFullCharts(_dataPh, _dataOrp, _dataCt, _data, _dataLw);

    });
}

/*
*Proceso para actualizacion de graficas.
*/
function updateCharts(chart, value, json, dataSourceUpdate) {
    var newData = $.extend({}, dataSourceUpdate);
    newData.dataset[0].data.unshift({ "value": value });
    newData.categories[0].category.unshift({
        "label": json.hours,
        "tooltext" : "{br}Fecha: " + getDateFormat(new Date(parseInt(json.Date_Register.replace("/Date(", "").replace(")/", ""), 10))) + "{br}" + "hora: " + json.hours
    });
    $("#"+chart).updateFusionCharts({
        dataFormat: "json",
        dataSource: newData
    });
}

/***Metodos Extras**/
function getDateLegent(date) {

    _dateLabel = Date(date.getYear(), date.getMonth(), date.getDay());
}

function setNewValor() {

    return Math.floor(Math.random() * (25 - 0)) + 0;
}

function getDateFormat(date) {

    /* var stringDate = date.getDay() + "/" + date.getMonth() + "/" + date.getYear();
    var event = new Date(date.getYear(), date.getMonth(), date.getDay());*/
    var options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
    return date.toLocaleString('es', options);
}

$(".card-anim").click(function () {
    var idKeySensor = $(this).find(".chart-monitor").attr("id");
    setSelectedSensor(idKeySensor, () => {
        console.log("Abrimos el modal");
        //setTimeout(() => {
            $('#modalChartsFull').modal('toggle');
        //}, 3000);
    });
 
})


function setSelectedSensor(idSensor, callback) {
    var newData = $.extend({}, _dataSourceFullChars);
    newData.dataset.forEach((item, index, array) => {
        newData.dataset[index].initiallyHidden = "1";
    });

    switch (idSensor) {
        case OD:
            console.log("idSensor", idSensor);
            newData.dataset[0].initiallyHidden = "0";
            break;
        case ORP:
            console.log("idSensor", idSensor);
            newData.dataset[1].initiallyHidden = "0";
            break;
        case PH:
            console.log("idSensor", idSensor);
            newData.dataset[2].initiallyHidden = "0";
            break;
        case CD:
            console.log("idSensor", idSensor);
            newData.dataset[3].initiallyHidden = "0";
            break;
        case LW:
            console.log("idSensor", idSensor);
            newData.dataset[4].initiallyHidden = "0"
            break;
        default:
            console.log("idSensor", idSensor);
            newData.dataset[0].initiallyHidden = "0";
            newData.dataset[1].initiallyHidden = "0";
            newData.dataset[2].initiallyHidden = "0";
            newData.dataset[3].initiallyHidden = "0";
            newData.dataset[4].initiallyHidden = "0";
            break;

    }

    console.log("newData", newData);
    $(".chart-container-full").updateFusionCharts({
        dataFormat: "json",
        dataSource: newData
    });
    callback();
    //console.log("_dataSourceFullChars", newData.dataset)
}

$('#modalChartsFull').on('hidden.bs.modal', function () {
    setSelectedSensor("", function () {
        console.log("por Defecto");
    });
});