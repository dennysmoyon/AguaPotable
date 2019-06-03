var url = 'ws://sairiot.com/WebSocketServer.ashx';

var ws = "";

$(document).ready(()=>{
    conectar();
});

function conectar() {

    console.log("url", url);
    ws = new WebSocket(url);
    ws.onerror = function (err) {
        console.log("Error Al conectar con servidor de websocket", err);
    }

    ws.onmessage = function (msg) {

        if (msg.data == 'successfull') {
            console.log("se ha conectado exitosamente")
        }
    }

    ws.onopen = function () {
        console.log("El cliente se ha conectado con exito");
    }

    ws.onclose = function () {
        console.log("mis panas  se ha cerrado la conexion");
    }
    return ws;
}