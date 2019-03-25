using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;
using DataAccessLayer.LN;

namespace WaterMonitoringSystemApp
{
    /// <summary>
    /// Descripción breve de WebSocketServer
    /// </summary>
    public class WebSocketServer : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest) {
                context.AcceptWebSocketRequest(new WebSocketImplement());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}