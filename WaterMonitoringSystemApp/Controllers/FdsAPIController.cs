using DataAccessLayer;
using DataAccessLayer.LN;
using ModelsSGH;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WaterMonitoringSystemApp.Controllers
{
    public class FdsAPIController : ApiController
    {
        IData_Sensors _dfsl;
        public FdsAPIController(IData_Sensors dfs)
        {
            _dfsl = dfs;
        }

        public FdsAPIController() : this(new Data_Sensors())
        {

        }

        // GET: api/FlowDataSensorsAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FlowDataSensorsAPI/5
        public string Get(int id)
        {
            return "Hola amigos:" + id;
        }

        // POST: api/FlowDataSensorsAPI
        public string Post([FromBody]DataFlowSensorsDTO _dfs)
        {
            _dfs = _dfsl.addDataSensors(_dfs);
            string dataJson = JsonConvert.SerializeObject(_dfs);
            // var saludo = _sal.saludos("hola amigos");
            return dataJson;
        }

        // PUT: api/FlowDataSensorsAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FlowDataSensorsAPI/5
        public void Delete(int id)
        {
        }
    }
}
