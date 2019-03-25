using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebSockets;
using ModelsSGH;
using Newtonsoft.Json;

namespace DataAccessLayer.LN
{
    public class WebSocketImplement : WebSocketHandler
    {

        private static WebSocketCollection clients = new WebSocketCollection();


        /// <summary>
        /// Abrimos la conexión al socket
        /// </summary>
        public override void OnOpen()
        {
            clients.Add(this);
            clients.Broadcast("successfull");
        }

        public static void notifier(DataFlowSensorsDTO data) {

            string dataJson = JsonConvert.SerializeObject(data);
            clients.Broadcast(dataJson);
        }
    }
}
